using System;
using System.Reflection;
using UnityEngine;

public class ScriptSetter : MonoBehaviour
{
	public StudentScript OldStudent;

	public StudentScript NewStudent;

	private void Start()
	{
		Component[] components = GetComponents(typeof(Component));
		foreach (Component component in components)
		{
			string[] obj = new string[6] { "name ", component.name, " type ", null, null, null };
			Type type = component.GetType();
			obj[3] = (((object)type != null) ? type.ToString() : null);
			obj[4] = " basetype ";
			Type baseType = component.GetType().BaseType;
			obj[5] = (((object)baseType != null) ? baseType.ToString() : null);
			Debug.Log(string.Concat(obj));
			FieldInfo[] fields = component.GetType().GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				object obj2 = component;
				string text = fieldInfo.Name;
				object value = fieldInfo.GetValue(obj2);
				Debug.Log(text + " value is: " + ((value != null) ? value.ToString() : null));
			}
		}
	}
}
