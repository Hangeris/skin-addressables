using UnityEngine;

public abstract class SkinSO : ScriptableObject
{
    [SerializeField] SkinCategory skinCategory;
    
    public SkinCategory SkinCategory => skinCategory;

    public abstract string RuntimeKey { get; }
    public abstract bool IsSameCategory(SkinSO other); 
    public abstract bool IsSameSkin(SkinSO other);
    // public abstract UniTask<bool> TryApplySkin(AddressableAssetManager assetManager); // This should get AddressablesManager, Car references
}