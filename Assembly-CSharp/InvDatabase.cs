using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000029 RID: 41
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x060000A3 RID: 163 RVA: 0x00011C00 File Offset: 0x0000FE00
	public static InvDatabase[] list
	{
		get
		{
			if (InvDatabase.mIsDirty)
			{
				InvDatabase.mIsDirty = false;
				InvDatabase.mList = NGUITools.FindActive<InvDatabase>();
			}
			return InvDatabase.mList;
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00011C1E File Offset: 0x0000FE1E
	private void OnEnable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00011C26 File Offset: 0x0000FE26
	private void OnDisable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00011C30 File Offset: 0x0000FE30
	private InvBaseItem GetItem(int id16)
	{
		int i = 0;
		int count = this.items.Count;
		while (i < count)
		{
			InvBaseItem invBaseItem = this.items[i];
			if (invBaseItem.id16 == id16)
			{
				return invBaseItem;
			}
			i++;
		}
		return null;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00011C70 File Offset: 0x0000FE70
	private static InvDatabase GetDatabase(int dbID)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			if (invDatabase.databaseID == dbID)
			{
				return invDatabase;
			}
			i++;
		}
		return null;
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00011CA8 File Offset: 0x0000FEA8
	public static InvBaseItem FindByID(int id32)
	{
		InvDatabase database = InvDatabase.GetDatabase(id32 >> 16);
		if (!(database != null))
		{
			return null;
		}
		return database.GetItem(id32 & 65535);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00011CD8 File Offset: 0x0000FED8
	public static InvBaseItem FindByName(string exact)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			int j = 0;
			int count = invDatabase.items.Count;
			while (j < count)
			{
				InvBaseItem invBaseItem = invDatabase.items[j];
				if (invBaseItem.name == exact)
				{
					return invBaseItem;
				}
				j++;
			}
			i++;
		}
		return null;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00011D3C File Offset: 0x0000FF3C
	public static int FindItemID(InvBaseItem item)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			if (invDatabase.items.Contains(item))
			{
				return invDatabase.databaseID << 16 | item.id16;
			}
			i++;
		}
		return -1;
	}

	// Token: 0x0400028A RID: 650
	private static InvDatabase[] mList;

	// Token: 0x0400028B RID: 651
	private static bool mIsDirty = true;

	// Token: 0x0400028C RID: 652
	public int databaseID;

	// Token: 0x0400028D RID: 653
	public List<InvBaseItem> items = new List<InvBaseItem>();

	// Token: 0x0400028E RID: 654
	public UnityEngine.Object iconAtlas;
}
