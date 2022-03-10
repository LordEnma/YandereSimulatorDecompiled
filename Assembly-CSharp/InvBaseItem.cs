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

	// Token: 0x020005BE RID: 1470
	public enum Slot
	{
		// Token: 0x04004D0B RID: 19723
		None,
		// Token: 0x04004D0C RID: 19724
		Weapon,
		// Token: 0x04004D0D RID: 19725
		Shield,
		// Token: 0x04004D0E RID: 19726
		Body,
		// Token: 0x04004D0F RID: 19727
		Shoulders,
		// Token: 0x04004D10 RID: 19728
		Bracers,
		// Token: 0x04004D11 RID: 19729
		Boots,
		// Token: 0x04004D12 RID: 19730
		Trinket,
		// Token: 0x04004D13 RID: 19731
		_LastDoNotUse
	}
}
