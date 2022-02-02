using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x00147834 File Offset: 0x00145A34
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x00147851 File Offset: 0x00145A51
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x0400317E RID: 12670
	public bool draculaDefeated;

	// Token: 0x0400317F RID: 12671
	public bool midoriEasterEgg;
}
