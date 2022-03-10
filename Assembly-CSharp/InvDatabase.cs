using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000029 RID: 41
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x060000A3 RID: 163 RVA: 0x00011A08 File Offset: 0x0000FC08
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

	// Token: 0x060000A4 RID: 164 RVA: 0x00011A26 File Offset: 0x0000FC26
	private void OnEnable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00011A2E File Offset: 0x0000FC2E
	private void OnDisable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00011A38 File Offset: 0x0000FC38
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

	// Token: 0x060000A7 RID: 167 RVA: 0x00011A78 File Offset: 0x0000FC78
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

	// Token: 0x060000A8 RID: 168 RVA: 0x00011AB0 File Offset: 0x0000FCB0
	public static InvBaseItem FindByID(int id32)
	{
		InvDatabase database = InvDatabase.GetDatabase(id32 >> 16);
		if (!(database != null))
		{
			return null;
		}
		return database.GetItem(id32 & 65535);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00011AE0 File Offset: 0x0000FCE0
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

	// Token: 0x060000AA RID: 170 RVA: 0x00011B44 File Offset: 0x0000FD44
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

	// Token: 0x04000288 RID: 648
	private static InvDatabase[] mList;

	// Token: 0x04000289 RID: 649
	private static bool mIsDirty = true;

	// Token: 0x0400028A RID: 650
	public int databaseID;

	// Token: 0x0400028B RID: 651
	public List<InvBaseItem> items = new List<InvBaseItem>();

	// Token: 0x0400028C RID: 652
	public UnityEngine.Object iconAtlas;
}
