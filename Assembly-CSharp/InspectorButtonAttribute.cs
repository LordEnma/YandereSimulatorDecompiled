using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000966 RID: 2406 RVA: 0x0004B3BF File Offset: 0x000495BF
	// (set) Token: 0x06000967 RID: 2407 RVA: 0x0004B3C7 File Offset: 0x000495C7
	public float ButtonWidth
	{
		get
		{
			return this._buttonWidth;
		}
		set
		{
			this._buttonWidth = value;
		}
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x0004B3D0 File Offset: 0x000495D0
	public InspectorButtonAttribute(string MethodName)
	{
		this.MethodName = MethodName;
	}

	// Token: 0x04000802 RID: 2050
	public static float kDefaultButtonWidth = 150f;

	// Token: 0x04000803 RID: 2051
	public readonly string MethodName;

	// Token: 0x04000804 RID: 2052
	private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;
}
