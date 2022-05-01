using System;

// Token: 0x0200040E RID: 1038
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x0014B614 File Offset: 0x00149814
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x0014B631 File Offset: 0x00149831
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003218 RID: 12824
	public bool draculaDefeated;

	// Token: 0x04003219 RID: 12825
	public bool midoriEasterEgg;
}
