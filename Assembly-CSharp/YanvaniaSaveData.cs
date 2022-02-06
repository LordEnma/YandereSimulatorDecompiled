using System;

// Token: 0x02000406 RID: 1030
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C1E RID: 7198 RVA: 0x00147AD0 File Offset: 0x00145CD0
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00147AED File Offset: 0x00145CED
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x04003182 RID: 12674
	public bool draculaDefeated;

	// Token: 0x04003183 RID: 12675
	public bool midoriEasterEgg;
}
