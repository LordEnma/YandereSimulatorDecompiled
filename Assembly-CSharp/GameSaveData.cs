using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C01 RID: 7169 RVA: 0x00146312 File Offset: 0x00144512
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x0014633A File Offset: 0x0014453A
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x0400311A RID: 12570
	public bool loveSick;

	// Token: 0x0400311B RID: 12571
	public bool masksBanned;

	// Token: 0x0400311C RID: 12572
	public bool paranormal;
}
