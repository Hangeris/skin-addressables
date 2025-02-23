using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] SimpleSkinLoader skinLoader;
    [SerializeField] Initiliazer initiliazer;
    
    public async void Load()
    {
        var address = inputField.text;

        var skinSO = await initiliazer.AssetManager.GetAssetAsync<SkinSO>(address);
        if (skinSO == null)
        {
            Debug.LogError($"SkinSO is null for address '{address}'");
            return;
        }
        
        initiliazer.CarSkinManager.ApplySkin(skinSO);
        
        // var loadedSkinData = await skinLoader.LoadSkinSO(address);
        // var instanceGo = await loadedSkinData.SpawnInstance(null);
        // instanceGo.transform.position = Random.onUnitSphere;
    }

    public void UnloadBath()
    {
        // skinLoader.UnloadSkin(SkinCategory.Bath);
    }
    public void UnloadWheel()
    {
        // skinLoader.UnloadSkin(SkinCategory.Wheels);
    }
}
