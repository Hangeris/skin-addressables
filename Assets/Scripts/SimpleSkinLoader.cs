using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SimpleSkinLoader : MonoBehaviour
{
    Dictionary<SkinCategory, LoadedSkinData> loadedSkinTypeToLoadedSkinData = new();

    public async UniTask<LoadedSkinData> LoadSkinSO(string skinSOAddress)
    {
        var handle = Addressables.LoadAssetAsync<SkinSO>(skinSOAddress);
        await handle;

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError($"SimpleSkinLoader LoadSkinSO Failed to load SkinSO: {skinSOAddress}");
            return null;
        }

        var skinData = handle.Result;
        if (skinData == null || !skinData.Prefab.RuntimeKeyIsValid())
        {
            Debug.LogError("Invalid SkinSO or prefab reference!");
            return null;
        }

        if (loadedSkinTypeToLoadedSkinData.TryGetValue(skinData.SkinCategory, out var previousLoadedSkinData))
        {
            if (skinData.IsSameSkin(previousLoadedSkinData.SkinSO))
            {
                Debug.LogError($"SimpleSkinLoader LoadSingSO SkinSO {skinSOAddress} is already loaded.");
                return previousLoadedSkinData;
            }

            previousLoadedSkinData.UnloadAll();
            loadedSkinTypeToLoadedSkinData.Remove(skinData.SkinCategory);
        }
        
        var loadedSkinData = new LoadedSkinData(skinData.SkinCategory, skinData);
        loadedSkinTypeToLoadedSkinData.Add(skinData.SkinCategory, loadedSkinData);
        return loadedSkinData;
    }
    
    public void UnloadSkin(SkinCategory skinCategory)
    {
        if (!loadedSkinTypeToLoadedSkinData.TryGetValue(skinCategory, out var loadedSkinData))
        {
            return;
        }
        
        loadedSkinData.UnloadAll();
        loadedSkinTypeToLoadedSkinData.Remove(skinCategory);
    }
}