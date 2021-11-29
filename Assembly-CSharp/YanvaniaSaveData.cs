using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class YanvaniaSaveData
{
	// Token: 0x06001C08 RID: 7176 RVA: 0x00144CB8 File Offset: 0x00142EB8
	public static YanvaniaSaveData ReadFromGlobals()
	{
		return new YanvaniaSaveData
		{
			draculaDefeated = YanvaniaGlobals.DraculaDefeated,
			midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
		};
	}

	// Token: 0x06001C09 RID: 7177 RVA: 0x00144CD5 File Offset: 0x00142ED5
	public static void WriteToGlobals(YanvaniaSaveData data)
	{
		YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
		YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
	}

	// Token: 0x0400313C RID: 12604
	public bool draculaDefeated;

	// Token: 0x0400313D RID: 12605
	public bool midoriEasterEgg;
}
