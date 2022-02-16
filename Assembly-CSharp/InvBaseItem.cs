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

	// Token: 0x020005BC RID: 1468
	public enum Slot
	{
		// Token: 0x04004CDE RID: 19678
		None,
		// Token: 0x04004CDF RID: 19679
		Weapon,
		// Token: 0x04004CE0 RID: 19680
		Shield,
		// Token: 0x04004CE1 RID: 19681
		Body,
		// Token: 0x04004CE2 RID: 19682
		Shoulders,
		// Token: 0x04004CE3 RID: 19683
		Bracers,
		// Token: 0x04004CE4 RID: 19684
		Boots,
		// Token: 0x04004CE5 RID: 19685
		Trinket,
		// Token: 0x04004CE6 RID: 19686
		_LastDoNotUse
	}
}
