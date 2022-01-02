using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BEE RID: 7150 RVA: 0x00143EB6 File Offset: 0x001420B6
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x00143EDE File Offset: 0x001420DE
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040030FF RID: 12543
	public bool loveSick;

	// Token: 0x04003100 RID: 12544
	public bool masksBanned;

	// Token: 0x04003101 RID: 12545
	public bool paranormal;
}
