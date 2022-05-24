using System;

// Token: 0x0200040F RID: 1039
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C5F RID: 7263 RVA: 0x0014C550 File Offset: 0x0014A750
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0014C56D File Offset: 0x0014A76D
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003235 RID: 12853
	public bool draculaDefeated;

	// Token: 0x04003236 RID: 12854
	public bool midoriEasterEgg;
}
