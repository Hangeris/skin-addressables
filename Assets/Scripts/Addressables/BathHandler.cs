using Cysharp.Threading.Tasks;
using UnityEngine;

public class BathHandler : MonoBehaviour, ISkinHandler
{
    [SerializeField] Transform spawnPointT;
    
    public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
    {
        if (skinSO == null)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
            return;
        }

        if (skinSO is not GameObjectSkinSO gameObjectSkinSo || skinSO.SkinCategory != SkinCategory.Bath)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
            return;
        }

        var bathPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);  // TODO: check if this is key is valid
        var bathInstance = Instantiate(bathPrefab, spawnPointT);
        
        // TODO: probably unload previously loaded bath in BathHandler
        //carSkinManager.SetupNewBath(skinSO, bathPrefab);
    }
}