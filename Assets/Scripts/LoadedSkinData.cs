using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadedSkinData
{
    // SkinCategory skinCategory;
    // SkinSO skinSO;
    // List<GameObject> instances = new();
    //
    // public LoadedSkinData(SkinCategory skinCategory, SkinSO skinSO)
    // {
    //     this.skinCategory = skinCategory;
    //     this.skinSO = skinSO;
    // }
    //
    // public SkinSO SkinSO => skinSO;
    // public SkinCategory SkinCategory => skinCategory;
    //
    // public async UniTask<GameObject> SpawnInstance(Transform parent)
    // {
    //     var instance = await skinSO.Prefab.InstantiateAsync(parent);
    //     instances.Add(instance);
    //     return instance;
    // }
    //
    // public async void UnloadAll()
    // {
    //     foreach (var instance in instances)
    //     {
    //         Addressables.ReleaseInstance(instance);
    //     }
    //     
    //     instances.Clear();
    // }
}
