using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "S_GO_", menuName = "Skins/GameObject Skin")]
public class GameObjectSkinSO : SkinSO
{
    public AssetReferenceGameObject prefabRef;

    public override string RuntimeKey => prefabRef.AssetGUID;
    
    public override bool IsSameCategory(SkinSO other)
    {
        return other.SkinCategory == SkinCategory;
    }

    public override bool IsSameSkin(SkinSO other)
    {
        return other is GameObjectSkinSO otherSkin && RuntimeKey == otherSkin.RuntimeKey;
    }

    // public override async UniTask<bool> TryApplySkin(AddressableAssetManager assetManager)
    // {
    //     var gameObject = await assetManager.GetAssetAsync<GameObject>(prefabRef.AssetGUID);
    //     // Apply GameObject skin logic
    //     return gameObject != null;
    // }
}