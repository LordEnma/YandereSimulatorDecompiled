using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00145578 File Offset: 0x00143778
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x00145595 File Offset: 0x00143795
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003166 RID: 12646
	public bool draculaDefeated;

	// Token: 0x04003167 RID: 12647
	public bool midoriEasterEgg;
}
