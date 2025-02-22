using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SkinSO : ScriptableObject
{
    [SerializeField] AssetReferenceGameObject prefab;
    [SerializeField] List<AssetReferenceT<Material>> materials;

    public virtual SkinCategory SkinCategory => SkinCategory.None;
    public AssetReferenceGameObject Prefab => prefab;
}