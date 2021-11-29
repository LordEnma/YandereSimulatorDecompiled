using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BE4 RID: 7140 RVA: 0x001431FA File Offset: 0x001413FA
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x00143222 File Offset: 0x00141422
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040030CE RID: 12494
	public bool loveSick;

	// Token: 0x040030CF RID: 12495
	public bool masksBanned;

	// Token: 0x040030D0 RID: 12496
	public bool paranormal;
}
