using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x0014422A File Offset: 0x0014242A
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BF6 RID: 7158 RVA: 0x00144252 File Offset: 0x00142452
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003105 RID: 12549
	public bool loveSick;

	// Token: 0x04003106 RID: 12550
	public bool masksBanned;

	// Token: 0x04003107 RID: 12551
	public bool paranormal;
}
