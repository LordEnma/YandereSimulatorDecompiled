using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000966 RID: 2406 RVA: 0x0004B567 File Offset: 0x00049767
	// (set) Token: 0x06000967 RID: 2407 RVA: 0x0004B56F File Offset: 0x0004976F
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

	// Token: 0x06000968 RID: 2408 RVA: 0x0004B578 File Offset: 0x00049778
	public InspectorButtonAttribute(string MethodName)
	{
		this.MethodName = MethodName;
	}

	// Token: 0x0400080D RID: 2061
	public static float kDefaultButtonWidth = 150f;

	// Token: 0x0400080E RID: 2062
	public readonly string MethodName;

	// Token: 0x0400080F RID: 2063
	private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;
}
