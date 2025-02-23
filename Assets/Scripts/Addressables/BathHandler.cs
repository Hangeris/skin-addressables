using Cysharp.Threading.Tasks;
using UnityEngine;

public class BathHandler : MonoBehaviour, ISkinHandler
{
    [SerializeField] Transform spawnPointT;
    
    public SkinCategory SkinCategory => SkinCategory.Bath;
    public SkinSO LoadedSkinSO { get; set; }

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

        UnloadLoadedSkin(assetManager);

        LoadedSkinSO = skinSO;
        
        var bathPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);  // TODO: check if this is key is valid
        var bathInstance = Instantiate(bathPrefab, spawnPointT);
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
        foreach (Transform child in spawnPointT)
        {
            Destroy(child.gameObject);
        }
    }
}