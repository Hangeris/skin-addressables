using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WheelsSkinHandler : MonoBehaviour, ISkinHandler
{
    [SerializeField] List<Transform> spawnPointsT;

    public SkinCategory SkinCategory => SkinCategory.Wheels;
    public SkinSO LoadedSkinSO { get; set; }

    public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
    {
        if (skinSO == null)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
            return;
        }
        
        if (skinSO is not GameObjectSkinSO gameObjectSkinSo || skinSO.SkinCategory != SkinCategory.Wheels)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
            return;
        }

        UnloadLoadedSkin(assetManager);
        
        var wheelsPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);
        foreach (var spawnPointT in spawnPointsT)
        {
            Instantiate(wheelsPrefab, spawnPointT);
        }
    }

    public void UnloadLoadedSkin(AddressableAssetManager assetManager)
    {
        DestroyGOs();
        
        if (LoadedSkinSO != null)
        {
            assetManager.ReleaseAsset<GameObject>(LoadedSkinSO.RuntimeKey);
            LoadedSkinSO = null;
        }
    }
    
    void DestroyGOs()
    {
        foreach (var spawnPointT in spawnPointsT)
        {
            foreach (Transform childT in spawnPointT)
            {
                Destroy(childT.gameObject);
            }
        }

    }
}