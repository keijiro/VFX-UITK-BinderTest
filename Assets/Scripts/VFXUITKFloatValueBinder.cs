
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

namespace Rcam3 {

[AddComponentMenu("VFX/Property Binders/UI Toolkit Float Value Binder")]
[VFXBinder("UI Toolkit/Float Value")]
public sealed class VFXUITKFloatValueBinder : VFXBinderBase
{
    [VFXPropertyBinding("System.Single")]
    public ExposedProperty Property = "FloatParameter";

    public UIDocument Target = null;
    public string ElementName = "float-value";

    BaseField<float> _targetElement;

    BaseField<float> TargetElement
      //=> _targetElement ?? (_targetElement = Target?.rootVisualElement.Q<BaseField<float>>(ElementName));
      => GetTargetElement();

    void OnEnable()
    {
        Debug.Log("Enable");
        base.OnEnable();
    }

    void OnDisable()
    {
        Debug.Log("Disable");
        base.OnDisable();
        _targetElement = null;
    }

    BaseField<float> GetTargetElement()
    {
        if (_targetElement != null) return _targetElement;
        _targetElement = Target?.rootVisualElement.Q<BaseField<float>>(ElementName);
        Debug.Log("UPDATE");
        return _targetElement;
    }

    public override bool IsValid(VisualEffect component)
      => Target != null &&
         TargetElement != null &&
         component.HasFloat(Property);

    public override void UpdateBinding(VisualEffect component)
      => component.SetFloat(Property, TargetElement.value);

    public override string ToString()
      => $"UITK Float : {Property} -> {ElementName}";
}

} // namespace Rcam3
