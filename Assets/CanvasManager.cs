using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] SimpleSkinLoader skinLoader;
    
    public async void Load()
    {
        var address = inputField.text;
        var loadedSkinData = await skinLoader.LoadSkinSO(address);
        var instanceGo = await loadedSkinData.SpawnInstance(null);
        instanceGo.transform.position = Random.onUnitSphere;
    }

    public void UnloadBath()
    {
        skinLoader.UnloadSkin(SkinCategory.Bath);
    }
    public void UnloadWheel()
    {
        skinLoader.UnloadSkin(SkinCategory.Wheels);
    }
}
