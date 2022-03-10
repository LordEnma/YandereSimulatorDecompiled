using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

// Token: 0x0200007B RID: 123
[Serializable]
public class PropertyReference
{
	// Token: 0x17000068 RID: 104
	// (get) Token: 0x0600044F RID: 1103 RVA: 0x0002C1BC File Offset: 0x0002A3BC
	// (set) Token: 0x06000450 RID: 1104 RVA: 0x0002C1C4 File Offset: 0x0002A3C4
	public Component target
	{
		get
		{
			return this.mTarget;
		}
		set
		{
			this.mTarget = value;
			this.mProperty = null;
			this.mField = null;
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x06000451 RID: 1105 RVA: 0x0002C1DB File Offset: 0x0002A3DB
	// (set) Token: 0x06000452 RID: 1106 RVA: 0x0002C1E3 File Offset: 0x0002A3E3
	public string name
	{
		get
		{
			return this.mName;
		}
		set
		{
			this.mName = value;
			this.mProperty = null;
			this.mField = null;
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x06000453 RID: 1107 RVA: 0x0002C1FA File Offset: 0x0002A3FA
	public bool isValid
	{
		get
		{
			return this.mTarget != null && !string.IsNullOrEmpty(this.mName);
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000454 RID: 1108 RVA: 0x0002C21C File Offset: 0x0002A41C
	public bool isEnabled
	{
		get
		{
			if (this.mTarget == null)
			{
				return false;
			}
			MonoBehaviour monoBehaviour = this.mTarget as MonoBehaviour;
			return monoBehaviour == null || monoBehaviour.enabled;
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0002C256 File Offset: 0x0002A456
	public PropertyReference()
	{
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0002C25E File Offset: 0x0002A45E
	public PropertyReference(Component target, string fieldName)
	{
		this.mTarget = target;
		this.mName = fieldName;
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0002C274 File Offset: 0x0002A474
	public Type GetPropertyType()
	{
		if (this.mProperty == null && this.mField == null && this.isValid)
		{
			this.Cache();
		}
		if (this.mProperty != null)
		{
			return this.mProperty.PropertyType;
		}
		if (this.mField != null)
		{
			return this.mField.FieldType;
		}
		return typeof(void);
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0002C2EC File Offset: 0x0002A4EC
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return !this.isValid;
		}
		if (obj is PropertyReference)
		{
			PropertyReference propertyReference = obj as PropertyReference;
			return this.mTarget == propertyReference.mTarget && string.Equals(this.mName, propertyReference.mName);
		}
		return false;
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0002C33D File Offset: 0x0002A53D
	public override int GetHashCode()
	{
		return PropertyReference.s_Hash;
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0002C344 File Offset: 0x0002A544
	public void Set(Component target, string methodName)
	{
		this.mTarget = target;
		this.mName = methodName;
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x0002C354 File Offset: 0x0002A554
	public void Clear()
	{
		this.mTarget = null;
		this.mName = null;
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x0002C364 File Offset: 0x0002A564
	public void Reset()
	{
		this.mField = null;
		this.mProperty = null;
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0002C374 File Offset: 0x0002A574
	public override string ToString()
	{
		return PropertyReference.ToString(this.mTarget, this.name);
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x0002C388 File Offset: 0x0002A588
	public static string ToString(Component comp, string property)
	{
		if (!(comp != null))
		{
			return null;
		}
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

	// Token: 0x0600045F RID: 1119 RVA: 0x0002C3E4 File Offset: 0x0002A5E4
	[DebuggerHidden]
	[DebuggerStepThrough]
	public object Get()
	{
		if (this.mProperty == null && this.mField == null && this.isValid)
		{
			this.Cache();
		}
		if (this.mProperty != null)
		{
			if (this.mProperty.CanRead)
			{
				return this.mProperty.GetValue(this.mTarget, null);
			}
		}
		else if (this.mField != null)
		{
			return this.mField.GetValue(this.mTarget);
		}
		return null;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0002C46C File Offset: 0x0002A66C
	[DebuggerHidden]
	[DebuggerStepThrough]
	public bool Set(object value)
	{
		if (this.mProperty == null && this.mField == null && this.isValid)
		{
			this.Cache();
		}
		if (this.mProperty == null && this.mField == null)
		{
			return false;
		}
		if (value == null)
		{
			try
			{
				if (!(this.mProperty != null))
				{
					this.mField.SetValue(this.mTarget, null);
					return true;
				}
				if (this.mProperty.CanWrite)
				{
					this.mProperty.SetValue(this.mTarget, null, null);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		if (!this.Convert(ref value))
		{
			if (Application.isPlaying)
			{
				string str = "Unable to convert ";
				Type type = value.GetType();
				string str2 = (type != null) ? type.ToString() : null;
				string str3 = " to ";
				Type propertyType = this.GetPropertyType();
				UnityEngine.Debug.LogError(str + str2 + str3 + ((propertyType != null) ? propertyType.ToString() : null));
			}
		}
		else
		{
			if (this.mField != null)
			{
				this.mField.SetValue(this.mTarget, value);
				return true;
			}
			if (this.mProperty.CanWrite)
			{
				this.mProperty.SetValue(this.mTarget, value, null);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0002C5C0 File Offset: 0x0002A7C0
	[DebuggerHidden]
	[DebuggerStepThrough]
	private bool Cache()
	{
		if (this.mTarget != null && !string.IsNullOrEmpty(this.mName))
		{
			Type type = this.mTarget.GetType();
			this.mField = type.GetField(this.mName);
			this.mProperty = type.GetProperty(this.mName);
		}
		else
		{
			this.mField = null;
			this.mProperty = null;
		}
		return this.mField != null || this.mProperty != null;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0002C644 File Offset: 0x0002A844
	private bool Convert(ref object value)
	{
		if (this.mTarget == null)
		{
			return false;
		}
		Type propertyType = this.GetPropertyType();
		Type from;
		if (value == null)
		{
			if (!propertyType.IsClass)
			{
				return false;
			}
			from = propertyType;
		}
		else
		{
			from = value.GetType();
		}
		return PropertyReference.Convert(ref value, from, propertyType);
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x0002C68C File Offset: 0x0002A88C
	public static bool Convert(Type from, Type to)
	{
		object obj = null;
		return PropertyReference.Convert(ref obj, from, to);
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x0002C6A4 File Offset: 0x0002A8A4
	public static bool Convert(object value, Type to)
	{
		if (value == null)
		{
			value = null;
			return PropertyReference.Convert(ref value, to, to);
		}
		return PropertyReference.Convert(ref value, value.GetType(), to);
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x0002C6C4 File Offset: 0x0002A8C4
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
				int num;
				if (int.TryParse((string)value, out num))
				{
					value = num;
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
				float num2;
				if (float.TryParse((string)value, out num2))
				{
					value = num2;
					return true;
				}
			}
			else if (from == typeof(double))
			{
				value = (float)((double)value);
			}
			else if (from == typeof(int))
			{
				value = (float)((int)value);
			}
		}
		else if (to == typeof(double))
		{
			if (from == typeof(string))
			{
				double num3;
				if (double.TryParse((string)value, out num3))
				{
					value = num3;
					return true;
				}
			}
			else if (from == typeof(float))
			{
				value = (double)((float)value);
			}
			else if (from == typeof(int))
			{
				value = (double)((int)value);
			}
		}
		return false;
	}

	// Token: 0x040004FB RID: 1275
	[SerializeField]
	private Component mTarget;

	// Token: 0x040004FC RID: 1276
	[SerializeField]
	private string mName;

	// Token: 0x040004FD RID: 1277
	private FieldInfo mField;

	// Token: 0x040004FE RID: 1278
	private PropertyInfo mProperty;

	// Token: 0x040004FF RID: 1279
	private static int s_Hash = "PropertyBinding".GetHashCode();
}
