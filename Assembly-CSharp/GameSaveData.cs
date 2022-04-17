using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C2D RID: 7213 RVA: 0x0014931A File Offset: 0x0014751A
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C2E RID: 7214 RVA: 0x00149342 File Offset: 0x00147542
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x0400319B RID: 12699
	public bool loveSick;

	// Token: 0x0400319C RID: 12700
	public bool masksBanned;

	// Token: 0x0400319D RID: 12701
	public bool paranormal;
}
