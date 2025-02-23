using System.Collections.Generic;
using UnityEngine;

public class CarSkinManager : MonoBehaviour
{
    [SerializeField] List<IRef<ISkinHandler>> skinHandlers;
    
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

        var handler = skinHandlers.Find(s => s.Value.SkinCategory == skinSO.SkinCategory);
        if (handler == null)
        {
            Debug.LogError($"{ToString()}.ApplySkin: Skin handler not found for category '{skinSO.SkinCategory}'");
            return;
        }
        
        handler.Value.ApplySkin(assetManager, skinSO, this);
    }
    
    public void UnloadSkin(SkinCategory skinCategory)
    {
        var handler = skinHandlers.Find(s => s.Value.SkinCategory == skinCategory);
        if (handler == null)
        {
            Debug.LogError($"{ToString()}.UnloadSkin: Skin handler not found for category '{skinCategory}'");
            return;
        }
        
        handler.Value.UnloadLoadedSkin(assetManager);
    }
}