using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[Serializable]
public class InvBaseItem
{
	// Token: 0x04000273 RID: 627
	public int id16;

	// Token: 0x04000274 RID: 628
	public string name;

	// Token: 0x04000275 RID: 629
	public string description;

	// Token: 0x04000276 RID: 630
	public InvBaseItem.Slot slot;

	// Token: 0x04000277 RID: 631
	public int minItemLevel = 1;

	// Token: 0x04000278 RID: 632
	public int maxItemLevel = 50;

	// Token: 0x04000279 RID: 633
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x0400027A RID: 634
	public GameObject attachment;

	// Token: 0x0400027B RID: 635
	public Color color = Color.white;

	// Token: 0x0400027C RID: 636
	public UnityEngine.Object iconAtlas;

	// Token: 0x0400027D RID: 637
	public string iconName = "";

	// Token: 0x020005BB RID: 1467
	public enum Slot
	{
		// Token: 0x04004CD2 RID: 19666
		None,
		// Token: 0x04004CD3 RID: 19667
		Weapon,
		// Token: 0x04004CD4 RID: 19668
		Shield,
		// Token: 0x04004CD5 RID: 19669
		Body,
		// Token: 0x04004CD6 RID: 19670
		Shoulders,
		// Token: 0x04004CD7 RID: 19671
		Bracers,
		// Token: 0x04004CD8 RID: 19672
		Boots,
		// Token: 0x04004CD9 RID: 19673
		Trinket,
		// Token: 0x04004CDA RID: 19674
		_LastDoNotUse
	}
}
