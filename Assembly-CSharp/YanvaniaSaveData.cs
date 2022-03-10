using System;

// Token: 0x02000408 RID: 1032
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C30 RID: 7216 RVA: 0x00148D84 File Offset: 0x00146F84
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x00148DA1 File Offset: 0x00146FA1
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x040031AE RID: 12718
	public bool draculaDefeated;

	// Token: 0x040031AF RID: 12719
	public bool midoriEasterEgg;
}
