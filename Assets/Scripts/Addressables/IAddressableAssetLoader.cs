using Cysharp.Threading.Tasks;

public interface IAddressableAssetLoader
{
    UniTask<T> LoadAssetAsync<T>(string key) where T : UnityEngine.Object;
    void ReleaseAsset<T>(string key) where T : UnityEngine.Object;
    void ClearUnusedAssets();
}