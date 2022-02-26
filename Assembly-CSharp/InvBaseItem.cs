using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[Serializable]
public class InvBaseItem
{
	// Token: 0x04000274 RID: 628
	public int id16;

	// Token: 0x04000275 RID: 629
	public string name;

	// Token: 0x04000276 RID: 630
	public string description;

	// Token: 0x04000277 RID: 631
	public InvBaseItem.Slot slot;

	// Token: 0x04000278 RID: 632
	public int minItemLevel = 1;

	// Token: 0x04000279 RID: 633
	public int maxItemLevel = 50;

	// Token: 0x0400027A RID: 634
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x0400027B RID: 635
	public GameObject attachment;

	// Token: 0x0400027C RID: 636
	public Color color = Color.white;

	// Token: 0x0400027D RID: 637
	public UnityEngine.Object iconAtlas;

	// Token: 0x0400027E RID: 638
	public string iconName = "";

	// Token: 0x020005BD RID: 1469
	public enum Slot
	{
		// Token: 0x04004CEE RID: 19694
		None,
		// Token: 0x04004CEF RID: 19695
		Weapon,
		// Token: 0x04004CF0 RID: 19696
		Shield,
		// Token: 0x04004CF1 RID: 19697
		Body,
		// Token: 0x04004CF2 RID: 19698
		Shoulders,
		// Token: 0x04004CF3 RID: 19699
		Bracers,
		// Token: 0x04004CF4 RID: 19700
		Boots,
		// Token: 0x04004CF5 RID: 19701
		Trinket,
		// Token: 0x04004CF6 RID: 19702
		_LastDoNotUse
	}
}
