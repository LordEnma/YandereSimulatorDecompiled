using System;

// Token: 0x02000408 RID: 1032
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C2E RID: 7214 RVA: 0x00148848 File Offset: 0x00146A48
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C2F RID: 7215 RVA: 0x00148865 File Offset: 0x00146A65
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003198 RID: 12696
	public bool draculaDefeated;

	// Token: 0x04003199 RID: 12697
	public bool midoriEasterEgg;
}
