using Cysharp.Threading.Tasks;

public interface ISkinHandler
{
    SkinCategory SkinCategory { get; }
    SkinSO LoadedSkinSO { get; set; }
    UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager);
    void UnloadLoadedSkin(AddressableAssetManager assetManager);
}