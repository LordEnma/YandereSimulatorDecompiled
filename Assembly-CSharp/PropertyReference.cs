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
		get
		{
			return mTarget;
		}
		set
		{
			mTarget = value;
			mProperty = null;
			mField = null;
		}
	}

	public string name
	{
		get
		{
			return mName;
		}
		set
		{
			mName = value;
			mProperty = null;
			mField = null;
		}
	}

	public bool isValid
	{
		get
		{
			if (mTarget != null)
			{
				return !string.IsNullOrEmpty(mName);
			}
			return false;
		}
	}

	public bool isEnabled
	{
		get
		{
			if (mTarget == null)
			{
				return false;
			}
			MonoBehaviour monoBehaviour = mTarget as MonoBehaviour;
			if (!(monoBehaviour == null))
			{
				return monoBehaviour.enabled;
			}
			return true;
		}
	}

	public PropertyReference()
	{
	}

	public PropertyReference(Component target, string fieldName)
	{
		mTarget = target;
		mName = fieldName;
	}

	public Type GetPropertyType()
	{
		if (mProperty == null && mField == null && isValid)
		{
			Cache();
		}
		if (mProperty != null)
		{
			return mProperty.PropertyType;
		}
		if (mField != null)
		{
			return mField.FieldType;
		}
		return typeof(void);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return !isValid;
		}
		if (obj is PropertyReference)
		{
			PropertyReference propertyReference = obj as PropertyReference;
			if (mTarget == propertyReference.mTarget)
			{
				return string.Equals(mName, propertyReference.mName);
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return s_Hash;
	}

	public void Set(Component target, string methodName)
	{
		mTarget = target;
		mName = methodName;
	}

	public void Clear()
	{
		mTarget = null;
		mName = null;
	}

	public void Reset()
	{
		mField = null;
		mProperty = null;
	}

	public override string ToString()
	{
		return ToString(mTarget, name);
	}

	public static string ToString(Component comp, string property)
	{
		if (comp != null)
		{
			string text = comp.GetType().ToString();
			int num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			if (!string.IsNullOrEmpty(property))
			{
				return text + "." + property;
			}
			return text + ".[property]";
		}
		return null;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public object Get()
	{
		if (mProperty == null && mField == null && isValid)
		{
			Cache();
		}
		if (mProperty != null)
		{
			if (mProperty.CanRead)
			{
				return mProperty.GetValue(mTarget, null);
			}
		}
		else if (mField != null)
		{
			return mField.GetValue(mTarget);
		}
		return null;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public bool Set(object value)
	{
		if (mProperty == null && mField == null && isValid)
		{
			Cache();
		}
		if (mProperty == null && mField == null)
		{
			return false;
		}
		if (value == null)
		{
			try
			{
				if (!(mProperty != null))
				{
					mField.SetValue(mTarget, null);
					return true;
				}
				if (mProperty.CanWrite)
				{
					mProperty.SetValue(mTarget, null, null);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		if (!Convert(ref value))
		{
			if (Application.isPlaying)
			{
				UnityEngine.Debug.LogError("Unable to convert " + value.GetType()?.ToString() + " to " + GetPropertyType());
			}
		}
		else
		{
			if (mField != null)
			{
				mField.SetValue(mTarget, value);
				return true;
			}
			if (mProperty.CanWrite)
			{
				mProperty.SetValue(mTarget, value, null);
				return true;
			}
		}
		return false;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	private bool Cache()
	{
		if (mTarget != null && !string.IsNullOrEmpty(mName))
		{
			Type type = mTarget.GetType();
			mField = type.GetField(mName);
			mProperty = type.GetProperty(mName);
		}
		else
		{
			mField = null;
			mProperty = null;
		}
		if (!(mField != null))
		{
			return mProperty != null;
		}
		return true;
	}

	private bool Convert(ref object value)
	{
		if (mTarget == null)
		{
			return false;
		}
		Type propertyType = GetPropertyType();
		Type type;
		if (value == null)
		{
			if (!propertyType.IsClass)
			{
				return false;
			}
			type = propertyType;
		}
		else
		{
			type = value.GetType();
		}
		return Convert(ref value, type, propertyType);
	}

	public static bool Convert(Type from, Type to)
	{
		object value = null;
		return Convert(ref value, from, to);
	}

	public static bool Convert(object value, Type to)
	{
		if (value == null)
		{
			value = null;
			return Convert(ref value, to, to);
		}
		return Convert(ref value, value.GetType(), to);
	}

	public static bool Convert(ref object value, Type from, Type to)
	{
		if (to.IsAssignableFrom(from))
		{
			return true;
		}
		if (to == typeof(string))
		{
			value = ((value != null) ? value.ToString() : "null");
			return true;
		}
		if (value == null)
		{
			return false;
		}
		if (to == typeof(int))
		{
			if (from == typeof(string))
			{
				if (int.TryParse((string)value, out var result))
				{
					value = result;
					return true;
				}
			}
			else
			{
				if (from == typeof(float))
				{
					value = Mathf.RoundToInt((float)value);
					return true;
				}
				if (from == typeof(double))
				{
					value = (int)Math.Round((double)value);
				}
			}
		}
		else if (to == typeof(float))
		{
			if (from == typeof(string))
			{
				if (float.TryParse((string)value, out var result2))
				{
					value = result2;
					return true;
				}
			}
			else if (from == typeof(double))
			{
				value = (float)(double)value;
			}
			else if (from == typeof(int))
			{
				value = (float)(int)value;
			}
		}
		else if (to == typeof(double))
		{
			if (from == typeof(string))
			{
				if (double.TryParse((string)value, out var result3))
				{
					value = result3;
					return true;
				}
			}
			else if (from == typeof(float))
			{
				value = (double)(float)value;
			}
			else if (from == typeof(int))
			{
				value = (double)(int)value;
			}
		}
		return false;
	}
}
