using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadedSkinData
{
    private SkinCategory skinCategory;
    private SkinSO skinSO;
    private GameObject instance;
    
    public LoadedSkinData(SkinCategory skinCategory, SkinSO skinSO, GameObject instance)
    {
        this.skinCategory = skinCategory;
        this.skinSO = skinSO;
        this.instance = instance;
    }

    public SkinSO SkinSO => skinSO;
    public SkinCategory SkinCategory => skinCategory;
    
    public void Unload()
    {
        Addressables.ReleaseInstance(instance);
    }
}
