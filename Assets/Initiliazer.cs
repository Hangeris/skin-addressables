using UnityEngine;

public class Initiliazer : MonoBehaviour
{
    [SerializeField] CarSkinManager carSkinManager;
    
    AddressableAssetManager assetManager;

    public AddressableAssetManager AssetManager => assetManager;
    public CarSkinManager CarSkinManager => carSkinManager;
    
    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        assetManager = new AddressableAssetManager();
        carSkinManager.Init(assetManager);
    }
}
