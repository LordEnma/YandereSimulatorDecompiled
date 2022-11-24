// Decompiled with JetBrains decompiler
// Type: PropertyReference
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

[Serializable]
public class PropertyReference
{
  [SerializeField]
  private Component mTarget;
  [SerializeField]
  private string mName;
  private FieldInfo mField;
  private PropertyInfo mProperty;
  private static int s_Hash = "PropertyBinding".GetHashCode();

  public Component target
  {
    get => this.mTarget;
    set
    {
      this.mTarget = value;
      this.mProperty = (PropertyInfo) null;
      this.mField = (FieldInfo) null;
    }
  }

  public string name
  {
    get => this.mName;
    set
    {
      this.mName = value;
      this.mProperty = (PropertyInfo) null;
      this.mField = (FieldInfo) null;
    }
  }

  public bool isValid => (UnityEngine.Object) this.mTarget != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.mName);

  public bool isEnabled
  {
    get
    {
      if ((UnityEngine.Object) this.mTarget == (UnityEngine.Object) null)
        return false;
      MonoBehaviour mTarget = this.mTarget as MonoBehaviour;
      return (UnityEngine.Object) mTarget == (UnityEngine.Object) null || mTarget.enabled;
    }
  }

  public PropertyReference()
  {
  }

  public PropertyReference(Component target, string fieldName)
  {
    this.mTarget = target;
    this.mName = fieldName;
  }

  public System.Type GetPropertyType()
  {
    if (this.mProperty == (PropertyInfo) null && this.mField == (FieldInfo) null && this.isValid)
      this.Cache();
    if (this.mProperty != (PropertyInfo) null)
      return this.mProperty.PropertyType;
    return this.mField != (FieldInfo) null ? this.mField.FieldType : typeof (void);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return !this.isValid;
    if (!(obj is PropertyReference))
      return false;
    PropertyReference propertyReference = obj as PropertyReference;
    return (UnityEngine.Object) this.mTarget == (UnityEngine.Object) propertyReference.mTarget && string.Equals(this.mName, propertyReference.mName);
  }

  public override int GetHashCode() => PropertyReference.s_Hash;

  public void Set(Component target, string methodName)
  {
    this.mTarget = target;
    this.mName = methodName;
  }

  public void Clear()
  {
    this.mTarget = (Component) null;
    this.mName = (string) null;
  }

  public void Reset()
  {
    this.mField = (FieldInfo) null;
    this.mProperty = (PropertyInfo) null;
  }

  public override string ToString() => PropertyReference.ToString(this.mTarget, this.name);

  public static string ToString(Component comp, string property)
  {
    if (!((UnityEngine.Object) comp != (UnityEngine.Object) null))
      return (string) null;
    string str = ((object) comp).GetType().ToString();
    int num = str.LastIndexOf('.');
    if (num > 0)
      str = str.Substring(num + 1);
    return !string.IsNullOrEmpty(property) ? str + "." + property : str + ".[property]";
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public object Get()
  {
    if (this.mProperty == (PropertyInfo) null && this.mField == (FieldInfo) null && this.isValid)
      this.Cache();
    if (this.mProperty != (PropertyInfo) null)
    {
      if (this.mProperty.CanRead)
        return this.mProperty.GetValue((object) this.mTarget, (object[]) null);
    }
    else if (this.mField != (FieldInfo) null)
      return this.mField.GetValue((object) this.mTarget);
    return (object) null;
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public bool Set(object value)
  {
    if (this.mProperty == (PropertyInfo) null && this.mField == (FieldInfo) null && this.isValid)
      this.Cache();
    if (this.mProperty == (PropertyInfo) null && this.mField == (FieldInfo) null)
      return false;
    if (value == null)
    {
      try
      {
        if (this.mProperty != (PropertyInfo) null)
        {
          if (this.mProperty.CanWrite)
          {
            this.mProperty.SetValue((object) this.mTarget, (object) null, (object[]) null);
            return true;
          }
        }
        else
        {
          this.mField.SetValue((object) this.mTarget, (object) null);
          return true;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    if (!this.Convert(ref value))
    {
      if (Application.isPlaying)
        UnityEngine.Debug.LogError((object) ("Unable to convert " + value.GetType()?.ToString() + " to " + this.GetPropertyType()?.ToString()));
    }
    else
    {
      if (this.mField != (FieldInfo) null)
      {
        this.mField.SetValue((object) this.mTarget, value);
        return true;
      }
      if (this.mProperty.CanWrite)
      {
        this.mProperty.SetValue((object) this.mTarget, value, (object[]) null);
        return true;
      }
    }
    return false;
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  private bool Cache()
  {
    if ((UnityEngine.Object) this.mTarget != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.mName))
    {
      System.Type type = ((object) this.mTarget).GetType();
      this.mField = type.GetField(this.mName);
      this.mProperty = type.GetProperty(this.mName);
    }
    else
    {
      this.mField = (FieldInfo) null;
      this.mProperty = (PropertyInfo) null;
    }
    return this.mField != (FieldInfo) null || this.mProperty != (PropertyInfo) null;
  }

  private bool Convert(ref object value)
  {
    if ((UnityEngine.Object) this.mTarget == (UnityEngine.Object) null)
      return false;
    System.Type propertyType = this.GetPropertyType();
    System.Type from;
    if (value == null)
    {
      if (!propertyType.IsClass)
        return false;
      from = propertyType;
    }
    else
      from = value.GetType();
    return PropertyReference.Convert(ref value, from, propertyType);
  }

  public static bool Convert(System.Type from, System.Type to)
  {
    object obj = (object) null;
    return PropertyReference.Convert(ref obj, from, to);
  }

  public static bool Convert(object value, System.Type to)
  {
    if (value != null)
      return PropertyReference.Convert(ref value, value.GetType(), to);
    value = (object) null;
    return PropertyReference.Convert(ref value, to, to);
  }

  public static bool Convert(ref object value, System.Type from, System.Type to)
  {
    if (to.IsAssignableFrom(from))
      return true;
    if (to == typeof (string))
    {
      value = value != null ? (object) value.ToString() : (object) "null";
      return true;
    }
    if (value == null)
      return false;
    if (to == typeof (int))
    {
      if (from == typeof (string))
      {
        int result;
        if (int.TryParse((string) value, out result))
        {
          value = (object) result;
          return true;
        }
      }
      else
      {
        if (from == typeof (float))
        {
          value = (object) Mathf.RoundToInt((float) value);
          return true;
        }
        if (from == typeof (double))
          value = (object) (int) Math.Round((double) value);
      }
    }
    else if (to == typeof (float))
    {
      if (from == typeof (string))
      {
        float result;
        if (float.TryParse((string) value, out result))
        {
          value = (object) result;
          return true;
        }
      }
      else if (from == typeof (double))
        value = (object) (float) (double) value;
      else if (from == typeof (int))
        value = (object) (float) (int) value;
    }
    else if (to == typeof (double))
    {
      if (from == typeof (string))
      {
        double result;
        if (double.TryParse((string) value, out result))
        {
          value = (object) result;
          return true;
        }
      }
      else if (from == typeof (float))
        value = (object) (double) (float) value;
      else if (from == typeof (int))
        value = (object) (double) (int) value;
    }
    return false;
  }
}
