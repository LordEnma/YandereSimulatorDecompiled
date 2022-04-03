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

	// Token: 0x020005C7 RID: 1479
	public enum Slot
	{
		// Token: 0x04004D9C RID: 19868
		None,
		// Token: 0x04004D9D RID: 19869
		Weapon,
		// Token: 0x04004D9E RID: 19870
		Shield,
		// Token: 0x04004D9F RID: 19871
		Body,
		// Token: 0x04004DA0 RID: 19872
		Shoulders,
		// Token: 0x04004DA1 RID: 19873
		Bracers,
		// Token: 0x04004DA2 RID: 19874
		Boots,
		// Token: 0x04004DA3 RID: 19875
		Trinket,
		// Token: 0x04004DA4 RID: 19876
		_LastDoNotUse
	}
}
