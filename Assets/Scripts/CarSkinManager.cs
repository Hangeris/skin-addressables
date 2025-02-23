using UnityEngine;

public class CarSkinManager : MonoBehaviour
{
    [SerializeField] IRef<ISkinHandler> bathHandler;
    [SerializeField] IRef<ISkinHandler> wheelHandler;
    // ISkinHandler characterHandler = new CharacterSkinHandler();
    // ISkinHandler parachuteHandler = new ParachuteSkinHandler();
    
    AddressableAssetManager assetManager;
    
    public void Init(AddressableAssetManager assetManager)
    {
        this.assetManager = assetManager;
    }
    
    public void ApplySkin(SkinSO skinSO)
    {
        if (assetManager == null)
        {
            Debug.LogError($"{ToString()}.ApplySkin: AssetManager is null");
            return;
        }
        
        if (skinSO == null)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
            return;
        }

        switch (skinSO.SkinCategory)
        {
            case SkinCategory.Bath:
                bathHandler.Value.ApplySkin(assetManager, skinSO, this);
                break;
            case SkinCategory.Wheels:
                wheelHandler.Value.ApplySkin(assetManager, skinSO, this);
                break;
            // case SkinCategory.Character:
            //     characterHandler.ApplySkin(assetManager, skinSO, this);
            //     break;
            // case SkinCategory.Parachute:
            //     parachuteHandler.ApplySkin(assetManager, skinSO, this);
            //     break;
            default:
                Debug.LogError($"{ToString()}.ApplySkin: Invalid skin category '{skinSO.SkinCategory}'");
                break;
        }
    }
    
    public void UnloadSkin(SkinCategory skinCategory)
    {
        switch (skinCategory)
        {
            case SkinCategory.Bath:
                bathHandler.Value.UnloadSkin(assetManager);
                break;
            case SkinCategory.Wheels:
                wheelHandler.Value.UnloadSkin(assetManager);
                break;
            // case SkinCategory.Character:
            //     characterHandler.UnloadSkin(assetManager);
            //     break;
            // case SkinCategory.Parachute:
            //     parachuteHandler.UnloadSkin(assetManager);
            //     break;
            default:
                Debug.LogError($"{ToString()}.UnloadSkin: Invalid skin category '{skinCategory}'");
                break;
        }
    }
}