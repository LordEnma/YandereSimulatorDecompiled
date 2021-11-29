﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class YanSaveIdentifier : MonoBehaviour
{
	// Token: 0x06002112 RID: 8466 RVA: 0x001E47A4 File Offset: 0x001E29A4
	public static GameObject GetObject(string id)
	{
		foreach (YanSaveIdentifier yanSaveIdentifier in YanSaveIdentifier.Identifiers)
		{
			if (yanSaveIdentifier.ObjectID == id)
			{
				return yanSaveIdentifier.gameObject;
			}
		}
		return null;
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x001E480C File Offset: 0x001E2A0C
	public static GameObject GetObject(SerializedGameObject serializedGameObject)
	{
		foreach (YanSaveIdentifier yanSaveIdentifier in YanSaveIdentifier.Identifiers)
		{
			if (yanSaveIdentifier.ObjectID == serializedGameObject.ObjectID)
			{
				return yanSaveIdentifier.gameObject;
			}
		}
		return null;
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E4878 File Offset: 0x001E2A78
	public void OnEnable()
	{
		if (!YanSaveIdentifier.Identifiers.Contains(this))
		{
			YanSaveIdentifier.Identifiers.Add(this);
		}
		if (string.IsNullOrEmpty(this.ObjectID))
		{
			this.ObjectID = base.gameObject.name;
		}
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x001E48B0 File Offset: 0x001E2AB0
	public void OnDestroy()
	{
		YanSaveIdentifier.Identifiers.Remove(this);
	}

	// Token: 0x04004876 RID: 18550
	public string ObjectID;

	// Token: 0x04004877 RID: 18551
	[HideInInspector]
	public bool AutoGenerated;

	// Token: 0x04004878 RID: 18552
	[HideInInspector]
	public List<Component> EnabledComponents = new List<Component>();

	// Token: 0x04004879 RID: 18553
	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledProperties = new List<DisabledYanSaveMember>();

	// Token: 0x0400487A RID: 18554
	[HideInInspector]
	public List<DisabledYanSaveMember> DisabledFields = new List<DisabledYanSaveMember>();

	// Token: 0x0400487B RID: 18555
	[HideInInspector]
	public bool InitializedInspector;

	// Token: 0x0400487C RID: 18556
	private static List<YanSaveIdentifier> Identifiers = new List<YanSaveIdentifier>();
}
