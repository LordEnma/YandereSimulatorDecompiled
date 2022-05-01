using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[Serializable]
public class InvBaseItem
{
	// Token: 0x0400027F RID: 639
	public int id16;

	// Token: 0x04000280 RID: 640
	public string name;

	// Token: 0x04000281 RID: 641
	public string description;

	// Token: 0x04000282 RID: 642
	public InvBaseItem.Slot slot;

	// Token: 0x04000283 RID: 643
	public int minItemLevel = 1;

	// Token: 0x04000284 RID: 644
	public int maxItemLevel = 50;

	// Token: 0x04000285 RID: 645
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x04000286 RID: 646
	public GameObject attachment;

	// Token: 0x04000287 RID: 647
	public Color color = Color.white;

	// Token: 0x04000288 RID: 648
	public UnityEngine.Object iconAtlas;

	// Token: 0x04000289 RID: 649
	public string iconName = "";

	// Token: 0x020005C9 RID: 1481
	public enum Slot
	{
		// Token: 0x04004DD0 RID: 19920
		None,
		// Token: 0x04004DD1 RID: 19921
		Weapon,
		// Token: 0x04004DD2 RID: 19922
		Shield,
		// Token: 0x04004DD3 RID: 19923
		Body,
		// Token: 0x04004DD4 RID: 19924
		Shoulders,
		// Token: 0x04004DD5 RID: 19925
		Bracers,
		// Token: 0x04004DD6 RID: 19926
		Boots,
		// Token: 0x04004DD7 RID: 19927
		Trinket,
		// Token: 0x04004DD8 RID: 19928
		_LastDoNotUse
	}
}
