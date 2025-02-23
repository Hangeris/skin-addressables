using UnityEngine;

[System.Serializable]
public class IRef<T> : ISerializationCallbackReceiver where T : class
{
    public UnityEngine.Object target;
    public T Value { get => target as T; }
    public static implicit operator bool(IRef<T> iRef) => iRef.target != null;
    
    void OnValidate()
    {
        if (target is T)
        {
            return;
        }

        if (target is not GameObject go)
        {
            return;
        }
        
        target = null;
        foreach (var c in go.GetComponents<Component>())
        {
            if (c is not T)
            {
                continue;
            }
            
            target = c;
            break;
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() => this.OnValidate();
    void ISerializationCallbackReceiver.OnAfterDeserialize() { }
}