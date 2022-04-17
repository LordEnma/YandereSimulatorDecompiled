using System;

// Token: 0x0200040D RID: 1037
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C51 RID: 7249 RVA: 0x0014ADD8 File Offset: 0x00148FD8
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x0014ADF5 File Offset: 0x00148FF5
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003209 RID: 12809
	public bool draculaDefeated;

	// Token: 0x0400320A RID: 12810
	public bool midoriEasterEgg;
}
