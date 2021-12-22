using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[Serializable]
public class InvBaseItem
{
	// Token: 0x04000272 RID: 626
	public int id16;

	// Token: 0x04000273 RID: 627
	public string name;

	// Token: 0x04000274 RID: 628
	public string description;

	// Token: 0x04000275 RID: 629
	public InvBaseItem.Slot slot;

	// Token: 0x04000276 RID: 630
	public int minItemLevel = 1;

	// Token: 0x04000277 RID: 631
	public int maxItemLevel = 50;

	// Token: 0x04000278 RID: 632
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x04000279 RID: 633
	public GameObject attachment;

	// Token: 0x0400027A RID: 634
	public Color color = Color.white;

	// Token: 0x0400027B RID: 635
	public UnityEngine.Object iconAtlas;

	// Token: 0x0400027C RID: 636
	public string iconName = "";

	// Token: 0x020005BE RID: 1470
	public enum Slot
	{
		// Token: 0x04004CCB RID: 19659
		None,
		// Token: 0x04004CCC RID: 19660
		Weapon,
		// Token: 0x04004CCD RID: 19661
		Shield,
		// Token: 0x04004CCE RID: 19662
		Body,
		// Token: 0x04004CCF RID: 19663
		Shoulders,
		// Token: 0x04004CD0 RID: 19664
		Bracers,
		// Token: 0x04004CD1 RID: 19665
		Boots,
		// Token: 0x04004CD2 RID: 19666
		Trinket,
		// Token: 0x04004CD3 RID: 19667
		_LastDoNotUse
	}
}
