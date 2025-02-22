using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] SimpleSkinLoader skinLoader;
    
    public void Load()
    {
        var address = inputField.text;
        skinLoader.LoadSkinSO(address);
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
