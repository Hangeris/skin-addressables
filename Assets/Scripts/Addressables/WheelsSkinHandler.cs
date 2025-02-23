using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WheelsSkinHandler : MonoBehaviour, ISkinHandler
{
    [SerializeField] List<Transform> spawnPointsT;
    
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

        // TODO; probably remove previously loaded wheels in WheelsSkinHandler
        var wheelsPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);
        foreach (var spawnPointT in spawnPointsT)
        {
            var wheelsInstance = Instantiate(wheelsPrefab, spawnPointT);
        }
        
        // Apply wheels skin logic
    }
}