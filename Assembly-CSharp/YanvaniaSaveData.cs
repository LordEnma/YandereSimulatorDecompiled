using System;

// Token: 0x02000407 RID: 1031
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C25 RID: 7205 RVA: 0x00147DD0 File Offset: 0x00145FD0
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x00147DED File Offset: 0x00145FED
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003188 RID: 12680
	public bool draculaDefeated;

	// Token: 0x04003189 RID: 12681
	public bool midoriEasterEgg;
}
