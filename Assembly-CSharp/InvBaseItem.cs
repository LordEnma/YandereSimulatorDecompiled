using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[Serializable]
public class InvBaseItem
{
	// Token: 0x0400027D RID: 637
	public int id16;

	// Token: 0x0400027E RID: 638
	public string name;

	// Token: 0x0400027F RID: 639
	public string description;

	// Token: 0x04000280 RID: 640
	public InvBaseItem.Slot slot;

	// Token: 0x04000281 RID: 641
	public int minItemLevel = 1;

	// Token: 0x04000282 RID: 642
	public int maxItemLevel = 50;

	// Token: 0x04000283 RID: 643
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x04000284 RID: 644
	public GameObject attachment;

	// Token: 0x04000285 RID: 645
	public Color color = Color.white;

	// Token: 0x04000286 RID: 646
	public UnityEngine.Object iconAtlas;

	// Token: 0x04000287 RID: 647
	public string iconName = "";

	// Token: 0x020005C2 RID: 1474
	public enum Slot
	{
		// Token: 0x04004D6A RID: 19818
		None,
		// Token: 0x04004D6B RID: 19819
		Weapon,
		// Token: 0x04004D6C RID: 19820
		Shield,
		// Token: 0x04004D6D RID: 19821
		Body,
		// Token: 0x04004D6E RID: 19822
		Shoulders,
		// Token: 0x04004D6F RID: 19823
		Bracers,
		// Token: 0x04004D70 RID: 19824
		Boots,
		// Token: 0x04004D71 RID: 19825
		Trinket,
		// Token: 0x04004D72 RID: 19826
		_LastDoNotUse
	}
}
