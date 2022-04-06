using System;

// Token: 0x0200040D RID: 1037
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C4D RID: 7245 RVA: 0x0014A9C8 File Offset: 0x00148BC8
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x0014A9E5 File Offset: 0x00148BE5
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x040031FE RID: 12798
	public bool draculaDefeated;

	// Token: 0x040031FF RID: 12799
	public bool midoriEasterEgg;
}
