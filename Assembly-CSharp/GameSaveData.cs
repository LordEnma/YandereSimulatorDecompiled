using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C0C RID: 7180 RVA: 0x001472C6 File Offset: 0x001454C6
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x001472EE File Offset: 0x001454EE
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003140 RID: 12608
	public bool loveSick;

	// Token: 0x04003141 RID: 12609
	public bool masksBanned;

	// Token: 0x04003142 RID: 12610
	public bool paranormal;
}
