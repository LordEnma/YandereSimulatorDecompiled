using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x00146D8A File Offset: 0x00144F8A
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x00146DB2 File Offset: 0x00144FB2
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x0400312A RID: 12586
	public bool loveSick;

	// Token: 0x0400312B RID: 12587
	public bool masksBanned;

	// Token: 0x0400312C RID: 12588
	public bool paranormal;
}
