using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetLoader : IAddressableAssetLoader
{
    readonly AddressableAssetCache addressableAssetCache = new();
    
    public async UniTask<T> LoadAssetAsync<T>(string key) where T : UnityEngine.Object
    {
        if (addressableAssetCache.TryGet(key, out T cachedAsset))
        {
            if (cachedAsset != null)
            {
                return cachedAsset;
            }
            
            Debug.LogError($"AddressableAssetLoader.LoadAssetAsync Cached asset is null: {key}");
            addressableAssetCache.Remove(key);
        }

        var handle = Addressables.LoadAssetAsync<T>(key);
        await handle.ToUniTask();

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            addressableAssetCache.Add(key, handle.Result);
            return handle.Result;
        }
        
        Debug.LogError($"AddressableAssetLoader.LoadAssetAsync Failed to load asset: {key}");
        return null;
    }

    public void ReleaseAsset<T>(string key) where T : UnityEngine.Object
    {
        addressableAssetCache.Remove(key);
    }

    public void ClearUnusedAssets()
    {
        addressableAssetCache.Clear(); // This might remove more than it should
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}