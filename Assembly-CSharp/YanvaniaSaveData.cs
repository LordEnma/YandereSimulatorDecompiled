using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C12 RID: 7186 RVA: 0x00145974 File Offset: 0x00143B74
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C13 RID: 7187 RVA: 0x00145991 File Offset: 0x00143B91
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x0400316D RID: 12653
	public bool draculaDefeated;

	// Token: 0x0400316E RID: 12654
	public bool midoriEasterEgg;
}
