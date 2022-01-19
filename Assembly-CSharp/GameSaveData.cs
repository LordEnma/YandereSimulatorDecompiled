using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x00145932 File Offset: 0x00143B32
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BF8 RID: 7160 RVA: 0x0014595A File Offset: 0x00143B5A
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x0400310A RID: 12554
	public bool loveSick;

	// Token: 0x0400310B RID: 12555
	public bool masksBanned;

	// Token: 0x0400310C RID: 12556
	public bool paranormal;
}
