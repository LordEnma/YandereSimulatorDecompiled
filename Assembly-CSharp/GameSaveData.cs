using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BEC RID: 7148 RVA: 0x00143ABA File Offset: 0x00141CBA
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x00143AE2 File Offset: 0x00141CE2
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040030F8 RID: 12536
	public bool loveSick;

	// Token: 0x040030F9 RID: 12537
	public bool masksBanned;

	// Token: 0x040030FA RID: 12538
	public bool paranormal;
}
