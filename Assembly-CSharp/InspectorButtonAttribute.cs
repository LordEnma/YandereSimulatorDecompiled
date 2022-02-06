using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000966 RID: 2406 RVA: 0x0004B3B7 File Offset: 0x000495B7
	// (set) Token: 0x06000967 RID: 2407 RVA: 0x0004B3BF File Offset: 0x000495BF
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

	// Token: 0x06000968 RID: 2408 RVA: 0x0004B3C8 File Offset: 0x000495C8
	public InspectorButtonAttribute(string MethodName)
	{
		this.MethodName = MethodName;
	}

	// Token: 0x04000804 RID: 2052
	public static float kDefaultButtonWidth = 150f;

	// Token: 0x04000805 RID: 2053
	public readonly string MethodName;

	// Token: 0x04000806 RID: 2054
	private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;
}
