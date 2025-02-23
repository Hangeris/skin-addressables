using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ISkinHandler
{
    SkinSO LoadedSkinSO { get; set; }
    UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager);
    void UnloadSkin(AddressableAssetManager assetManager);
}

// public class SpoilerSkinHandler : ISkinHandler
// {
//     public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
//     {
//         if (skinSO == null)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
//             return;
//         }
//         
//         if (skinSO is not GameObjectSkinSO gameObjectSkinSo || skinSO.SkinCategory != SkinCategory.Spoiler)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
//             return;
//         }
//
//         var spoilerPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);
//         // Apply spoiler skin logic
//     }
// }
//
// public class CharacterSkinHandler : ISkinHandler
// {
//     public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
//     {
//         if (skinSO == null)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
//             return;
//         }
//         
//         if (skinSO is not MaterialSkinSO materialSkinSo || skinSO.SkinCategory != SkinCategory.Character)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
//             return;
//         }
//
//         var characterMaterial = await assetManager.GetAssetAsync<Material>(materialSkinSo.materialRef.AssetGUID);
//         // Apply character skin logic
//     }
// }
//
// public class HeadAccessorySkinHandler : ISkinHandler
// {
//     public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
//     {
//         if (skinSO == null)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
//             return;
//         }
//         
//         if (skinSO is not GameObjectSkinSO gameObjectSkinSo || skinSO.SkinCategory != SkinCategory.HeadAccessory)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
//             return;
//         }
//
//         var headAccessoryPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);
//         // Apply head accessory skin logic
//     }
// }
//
// public class ParachuteSkinHandler : ISkinHandler
// {
//     public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
//     {
//         if (skinSO == null)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
//             return;
//         }
//         
//         if (skinSO is not MaterialSkinSO materialSkinSo || skinSO.SkinCategory != SkinCategory.Parachute)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
//             return;
//         }
//
//         var parachuteMaterial = await assetManager.GetAssetAsync<Material>(materialSkinSo.materialRef.AssetGUID);
//         // Apply parachute skin logic
//     }
// }
//
// public class HornSkinHandler : ISkinHandler
// {
//     public async UniTask ApplySkin(AddressableAssetManager assetManager, SkinSO skinSO, CarSkinManager carSkinManager)
//     {
//         if (skinSO == null)
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Skin is null");
//             return;
//         }
//         
//         if (skinSO is not GameObjectSkinSO gameObjectSkinSo || skinSO.SkinCategory != SkinCategory.Horn)    // TODO: this should have it's own skinSO type
//         {
//             Debug.LogError($"{ToString()}.ApplySkin: Invalid skin type '{skinSO.GetType()}' or category '{skinSO.SkinCategory}'");
//             return;
//         }
//
//         var hornPrefab = await assetManager.GetAssetAsync<GameObject>(gameObjectSkinSo.prefabRef.AssetGUID);
//         // Apply horn skin logic
//     }
// }
