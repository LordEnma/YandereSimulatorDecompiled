using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000966 RID: 2406 RVA: 0x0004B6A7 File Offset: 0x000498A7
	// (set) Token: 0x06000967 RID: 2407 RVA: 0x0004B6AF File Offset: 0x000498AF
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

	// Token: 0x06000968 RID: 2408 RVA: 0x0004B6B8 File Offset: 0x000498B8
	public InspectorButtonAttribute(string MethodName)
	{
		this.MethodName = MethodName;
	}

	// Token: 0x0400080F RID: 2063
	public static float kDefaultButtonWidth = 150f;

	// Token: 0x04000810 RID: 2064
	public readonly string MethodName;

	// Token: 0x04000811 RID: 2065
	private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;
}
