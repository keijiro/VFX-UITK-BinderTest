using UnityEngine.UIElements;

[System.Serializable]
public sealed class UIFieldReference<T>
{
    public UIDocument Component;
    public string ElementName;

    public BaseField<T> Field => GetField();

    BaseField<T> _cached;

    public void ClearReference() => _cached = null;

    BaseField<T> GetField()
    {
        if (_cached == null)
            _cached = Component?.rootVisualElement.Q<BaseField<T>>(ElementName);
        return _cached;
    }
}
