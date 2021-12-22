using System;
using System.Reflection;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class ScriptSetter : MonoBehaviour
{
	// Token: 0x0600210F RID: 8463 RVA: 0x001E3514 File Offset: 0x001E1714
	private void Start()
	{
		foreach (Component component in base.GetComponents(typeof(Component)))
		{
			string[] array = new string[6];
			array[0] = "name ";
			array[1] = component.name;
			array[2] = " type ";
			int num = 3;
			Type type = component.GetType();
			array[num] = ((type != null) ? type.ToString() : null);
			array[4] = " basetype ";
			int num2 = 5;
			Type baseType = component.GetType().BaseType;
			array[num2] = ((baseType != null) ? baseType.ToString() : null);
			Debug.Log(string.Concat(array));
			foreach (FieldInfo fieldInfo in component.GetType().GetFields())
			{
				object obj = component;
				string name = fieldInfo.Name;
				string str = " value is: ";
				object value = fieldInfo.GetValue(obj);
				Debug.Log(name + str + ((value != null) ? value.ToString() : null));
			}
		}
	}

	// Token: 0x0400488B RID: 18571
	public StudentScript OldStudent;

	// Token: 0x0400488C RID: 18572
	public StudentScript NewStudent;
}
