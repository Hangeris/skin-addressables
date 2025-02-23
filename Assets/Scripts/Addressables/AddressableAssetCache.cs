using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableAssetCache
{
    Dictionary<string, UnityEngine.Object> cache = new();

    public void Add(string key, UnityEngine.Object asset)
    {
        if (asset == null)
        {
            Debug.LogError($"AssetCache.Add Asset is null: {key}");
            return;
        }
        
        if (cache.ContainsKey(key))
        {
            Debug.LogError($"AssetCache.Add Asset already exists: {key}");
            return;
        }
        
        cache[key] = asset;
    }
    
    public bool TryGet<T>(string key, out T asset) where T : UnityEngine.Object
    {
        if (cache.TryGetValue(key, out var obj) && obj is T castedAsset)
        {
            asset = castedAsset;
            return true;
        }
        
        asset = null;
        return false;
    }

    public void Remove(string key)
    {
        if (!cache.ContainsKey(key))
        {
            return;
        }
        
        Addressables.Release(cache[key]);
        cache.Remove(key);
    }

    public void Clear()
    {
        foreach (var asset in cache.Values)
        {
            Addressables.Release(asset);
        }
        cache.Clear();
    }
}