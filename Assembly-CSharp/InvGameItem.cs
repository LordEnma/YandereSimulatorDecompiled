using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200002B RID: 43
[Serializable]
public class InvGameItem
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000B6 RID: 182 RVA: 0x00011CED File Offset: 0x0000FEED
	public int baseItemID
	{
		get
		{
			return this.mBaseItemID;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000B7 RID: 183 RVA: 0x00011CF5 File Offset: 0x0000FEF5
	public InvBaseItem baseItem
	{
		get
		{
			if (this.mBaseItem == null)
			{
				this.mBaseItem = InvDatabase.FindByID(this.baseItemID);
			}
			return this.mBaseItem;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060000B8 RID: 184 RVA: 0x00011D16 File Offset: 0x0000FF16
	public string name
	{
		get
		{
			if (this.baseItem == null)
			{
				return null;
			}
			return this.quality.ToString() + " " + this.baseItem.name;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060000B9 RID: 185 RVA: 0x00011D48 File Offset: 0x0000FF48
	public float statMultiplier
	{
		get
		{
			float num = 0f;
			switch (this.quality)
			{
			case InvGameItem.Quality.Broken:
				num = 0f;
				break;
			case InvGameItem.Quality.Cursed:
				num = -1f;
				break;
			case InvGameItem.Quality.Damaged:
				num = 0.25f;
				break;
			case InvGameItem.Quality.Worn:
				num = 0.9f;
				break;
			case InvGameItem.Quality.Sturdy:
				num = 1f;
				break;
			case InvGameItem.Quality.Polished:
				num = 1.1f;
				break;
			case InvGameItem.Quality.Improved:
				num = 1.25f;
				break;
			case InvGameItem.Quality.Crafted:
				num = 1.5f;
				break;
			case InvGameItem.Quality.Superior:
				num = 1.75f;
				break;
			case InvGameItem.Quality.Enchanted:
				num = 2f;
				break;
			case InvGameItem.Quality.Epic:
				num = 2.5f;
				break;
			case InvGameItem.Quality.Legendary:
				num = 3f;
				break;
			}
			float num2 = (float)this.itemLevel / 50f;
			return num * Mathf.Lerp(num2, num2 * num2, 0.5f);
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000BA RID: 186 RVA: 0x00011E18 File Offset: 0x00010018
	public Color color
	{
		get
		{
			Color result = Color.white;
			switch (this.quality)
			{
			case InvGameItem.Quality.Broken:
				result = new Color(0.4f, 0.2f, 0.2f);
				break;
			case InvGameItem.Quality.Cursed:
				result = Color.red;
				break;
			case InvGameItem.Quality.Damaged:
				result = new Color(0.4f, 0.4f, 0.4f);
				break;
			case InvGameItem.Quality.Worn:
				result = new Color(0.7f, 0.7f, 0.7f);
				break;
			case InvGameItem.Quality.Sturdy:
				result = new Color(1f, 1f, 1f);
				break;
			case InvGameItem.Quality.Polished:
				result = NGUIMath.HexToColor(3774856959U);
				break;
			case InvGameItem.Quality.Improved:
				result = NGUIMath.HexToColor(2480359935U);
				break;
			case InvGameItem.Quality.Crafted:
				result = NGUIMath.HexToColor(1325334783U);
				break;
			case InvGameItem.Quality.Superior:
				result = NGUIMath.HexToColor(12255231U);
				break;
			case InvGameItem.Quality.Enchanted:
				result = NGUIMath.HexToColor(1937178111U);
				break;
			case InvGameItem.Quality.Epic:
				result = NGUIMath.HexToColor(2516647935U);
				break;
			case InvGameItem.Quality.Legendary:
				result = NGUIMath.HexToColor(4287627519U);
				break;
			}
			return result;
		}
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00011F38 File Offset: 0x00010138
	public InvGameItem(int id)
	{
		this.mBaseItemID = id;
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00011F55 File Offset: 0x00010155
	public InvGameItem(int id, InvBaseItem bi)
	{
		this.mBaseItemID = id;
		this.mBaseItem = bi;
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00011F7C File Offset: 0x0001017C
	public List<InvStat> CalculateStats()
	{
		List<InvStat> list = new List<InvStat>();
		if (this.baseItem != null)
		{
			float statMultiplier = this.statMultiplier;
			List<InvStat> stats = this.baseItem.stats;
			int i = 0;
			int count = stats.Count;
			while (i < count)
			{
				InvStat invStat = stats[i];
				int num = Mathf.RoundToInt(statMultiplier * (float)invStat.amount);
				if (num != 0)
				{
					bool flag = false;
					int j = 0;
					int count2 = list.Count;
					while (j < count2)
					{
						InvStat invStat2 = list[j];
						if (invStat2.id == invStat.id && invStat2.modifier == invStat.modifier)
						{
							invStat2.amount += num;
							flag = true;
							break;
						}
						j++;
					}
					if (!flag)
					{
						list.Add(new InvStat
						{
							id = invStat.id,
							amount = num,
							modifier = invStat.modifier
						});
					}
				}
				i++;
			}
			list.Sort(new Comparison<InvStat>(InvStat.CompareArmor));
		}
		return list;
	}

	// Token: 0x04000286 RID: 646
	[SerializeField]
	private int mBaseItemID;

	// Token: 0x04000287 RID: 647
	public InvGameItem.Quality quality = InvGameItem.Quality.Sturdy;

	// Token: 0x04000288 RID: 648
	public int itemLevel = 1;

	// Token: 0x04000289 RID: 649
	private InvBaseItem mBaseItem;

	// Token: 0x020005BD RID: 1469
	public enum Quality
	{
		// Token: 0x04004CE8 RID: 19688
		Broken,
		// Token: 0x04004CE9 RID: 19689
		Cursed,
		// Token: 0x04004CEA RID: 19690
		Damaged,
		// Token: 0x04004CEB RID: 19691
		Worn,
		// Token: 0x04004CEC RID: 19692
		Sturdy,
		// Token: 0x04004CED RID: 19693
		Polished,
		// Token: 0x04004CEE RID: 19694
		Improved,
		// Token: 0x04004CEF RID: 19695
		Crafted,
		// Token: 0x04004CF0 RID: 19696
		Superior,
		// Token: 0x04004CF1 RID: 19697
		Enchanted,
		// Token: 0x04004CF2 RID: 19698
		Epic,
		// Token: 0x04004CF3 RID: 19699
		Legendary,
		// Token: 0x04004CF4 RID: 19700
		_LastDoNotUse
	}
}
