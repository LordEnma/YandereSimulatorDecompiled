using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C19 RID: 7193 RVA: 0x00145CE8 File Offset: 0x00143EE8
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00145D05 File Offset: 0x00143F05
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003173 RID: 12659
	public bool draculaDefeated;

	// Token: 0x04003174 RID: 12660
	public bool midoriEasterEgg;
}
