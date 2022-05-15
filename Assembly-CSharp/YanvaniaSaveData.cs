using System;

// Token: 0x0200040F RID: 1039
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C5E RID: 7262 RVA: 0x0014C294 File Offset: 0x0014A494
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014C2B1 File Offset: 0x0014A4B1
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x0400322D RID: 12845
	public bool draculaDefeated;

	// Token: 0x0400322E RID: 12846
	public bool midoriEasterEgg;
}
