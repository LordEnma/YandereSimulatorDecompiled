using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C1B RID: 7195 RVA: 0x001473F0 File Offset: 0x001455F0
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x0014740D File Offset: 0x0014560D
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003178 RID: 12664
	public bool draculaDefeated;

	// Token: 0x04003179 RID: 12665
	public bool midoriEasterEgg;
}
