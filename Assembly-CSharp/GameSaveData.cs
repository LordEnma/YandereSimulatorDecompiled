using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C19 RID: 7193 RVA: 0x0014816A File Offset: 0x0014636A
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00148192 File Offset: 0x00146392
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003174 RID: 12660
	public bool loveSick;

	// Token: 0x04003175 RID: 12661
	public bool masksBanned;

	// Token: 0x04003176 RID: 12662
	public bool paranormal;
}
