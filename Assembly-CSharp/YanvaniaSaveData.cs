using System;

// Token: 0x0200040C RID: 1036
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C47 RID: 7239 RVA: 0x0014A6E4 File Offset: 0x001488E4
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C48 RID: 7240 RVA: 0x0014A701 File Offset: 0x00148901
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x040031FB RID: 12795
	public bool draculaDefeated;

	// Token: 0x040031FC RID: 12796
	public bool midoriEasterEgg;
}
