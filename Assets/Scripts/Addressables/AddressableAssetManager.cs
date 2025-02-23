using Cysharp.Threading.Tasks;

public class AddressableAssetManager
{
    readonly IAddressableAssetLoader loader;

    public AddressableAssetManager()
    {
        loader = new AddressableAssetLoader();
    }

    public async UniTask<SkinSO> LoadSkinSOAsync(string key)
    {
        return await GetAssetAsync<SkinSO>(key);
    }
    
    public UniTask<T> GetAssetAsync<T>(string key) where T : UnityEngine.Object
    {
        return loader.LoadAssetAsync<T>(key);
    }

    public void ReleaseAsset<T>(string key) where T : UnityEngine.Object
    {
        loader.ReleaseAsset<T>(key);
    }

    public void TryClearMemory()
    {
        loader.ClearUnusedAssets();
    }
}