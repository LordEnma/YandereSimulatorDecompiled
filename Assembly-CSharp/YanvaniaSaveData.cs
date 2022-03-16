using System;

// Token: 0x02000409 RID: 1033
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C3D RID: 7229 RVA: 0x00149C28 File Offset: 0x00147E28
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C3E RID: 7230 RVA: 0x00149C45 File Offset: 0x00147E45
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x040031E2 RID: 12770
	public bool draculaDefeated;

	// Token: 0x040031E3 RID: 12771
	public bool midoriEasterEgg;
}
