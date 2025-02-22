using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SkinSO : ScriptableObject
{
    [SerializeField] AssetReferenceGameObject prefab;
    [SerializeField] List<AssetReferenceT<Material>> materials;

    public virtual SkinCategory SkinCategory => SkinCategory.None;
    public AssetReferenceGameObject Prefab => prefab;
    
    public bool IsSameSkin(SkinSO other)
    {
        return other != null && other.Prefab.RuntimeKeyIsValid() && Prefab.RuntimeKeyIsValid() && other.Prefab.RuntimeKey == Prefab.RuntimeKey;
    }
}