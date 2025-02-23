using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "S_M_", menuName = "Skins/Material Skin")]
public class MaterialSkinSO : SkinSO
{
    public AssetReference materialRef;

    public override string RuntimeKey => materialRef.AssetGUID;

    public override bool IsSameCategory(SkinSO other)
    {
        return other.SkinCategory == SkinCategory;
    }

    public override bool IsSameSkin(SkinSO other)
    {
        return other is MaterialSkinSO otherSkin && RuntimeKey == otherSkin.RuntimeKey;
    }

    // public override async UniTask<bool> TryApplySkin(AddressableAssetManager assetManager)
    // {
    //     var material = await assetManager.GetAssetAsync<Material>(materialRef.AssetGUID);
    //     // Apply Material skin logic
    //     return material != null;
    // }
}