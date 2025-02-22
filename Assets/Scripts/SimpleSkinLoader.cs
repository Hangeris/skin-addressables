using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SimpleSkinLoader : MonoBehaviour
{
    Dictionary<SkinCategory, LoadedSkinData> loadedSkinTypeToLoadedSkinData = new();

    public void LoadSkinSO(string skinSOAddress)
    {
        Addressables.LoadAssetAsync<SkinSO>(skinSOAddress).Completed += soHandle =>
        {
            if (soHandle.Status == AsyncOperationStatus.Succeeded)
            {
                var skinData = soHandle.Result;
                if (skinData == null || !skinData.Prefab.RuntimeKeyIsValid())
                {
                    Debug.LogError("Invalid SkinSO or prefab reference!");
                    return;
                }
                
                LoadPrefab(skinData);
            }
            else
            {
                Debug.LogError($"Failed to load SkinSO: {skinSOAddress}");
            }
        };
    }
    
    public void UnloadSkin(SkinCategory skinCategory)
    {
        if (!loadedSkinTypeToLoadedSkinData.TryGetValue(skinCategory, out var loadedSkinData))
        {
            return;
        }
        
        loadedSkinData.Unload();
        loadedSkinTypeToLoadedSkinData.Remove(skinCategory);
    }
    
    private void LoadPrefab(SkinSO skinData)
    {
        skinData.Prefab.InstantiateAsync(transform).Completed += prefabHandle =>
        {
            if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
            {
                var currentSkinType = skinData.SkinCategory;
                if (loadedSkinTypeToLoadedSkinData.TryGetValue(currentSkinType, out var previousLoadedSkinData))
                {
                    previousLoadedSkinData.Unload();
                    loadedSkinTypeToLoadedSkinData.Remove(currentSkinType);
                }
                
                loadedSkinTypeToLoadedSkinData.Add(currentSkinType, new LoadedSkinData(currentSkinType, skinData, prefabHandle.Result));
            }
            else
            {
                Debug.LogError("Failed to instantiate prefab.");
            }
        };
    }
}