using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x00145D76 File Offset: 0x00143F76
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x00145D9E File Offset: 0x00143F9E
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003110 RID: 12560
	public bool loveSick;

	// Token: 0x04003111 RID: 12561
	public bool masksBanned;

	// Token: 0x04003112 RID: 12562
	public bool paranormal;
}
