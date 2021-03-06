using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class InitModel
{
    [RealtimeProperty(1, true, true)]
    public string _name;

    [RealtimeProperty(2, true, true)]
    public int _value;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class InitModel : RealtimeModel {
    public string name {
        get {
            return _nameProperty.value;
        }
        set {
            if (_nameProperty.value == value) return;
            _nameProperty.value = value;
            InvalidateReliableLength();
            FireNameDidChange(value);
        }
    }
    
    public int value {
        get {
            return _valueProperty.value;
        }
        set {
            if (_valueProperty.value == value) return;
            _valueProperty.value = value;
            InvalidateReliableLength();
            FireValueDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(InitModel model, T value);
    public event PropertyChangedHandler<string> nameDidChange;
    public event PropertyChangedHandler<int> valueDidChange;
    
    public enum PropertyID : uint {
        Name = 1,
        Value = 2,
    }
    
    #region Properties
    
    private ReliableProperty<string> _nameProperty;
    
    private ReliableProperty<int> _valueProperty;
    
    #endregion
    
    public InitModel() : base(null) {
        _nameProperty = new ReliableProperty<string>(1, _name);
        _valueProperty = new ReliableProperty<int>(2, _value);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _nameProperty.UnsubscribeCallback();
        _valueProperty.UnsubscribeCallback();
    }
    
    private void FireNameDidChange(string value) {
        try {
            nameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireValueDidChange(int value) {
        try {
            valueDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _nameProperty.WriteLength(context);
        length += _valueProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _nameProperty.Write(stream, context);
        writes |= _valueProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Name: {
                    changed = _nameProperty.Read(stream, context);
                    if (changed) FireNameDidChange(name);
                    break;
                }
                case (uint) PropertyID.Value: {
                    changed = _valueProperty.Read(stream, context);
                    if (changed) FireValueDidChange(value);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _name = name;
        _value = value;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
