using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class GameSaveData
{
	// Token: 0x06001BFA RID: 7162 RVA: 0x00146012 File Offset: 0x00144212
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001BFB RID: 7163 RVA: 0x0014603A File Offset: 0x0014423A
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003114 RID: 12564
	public bool loveSick;

	// Token: 0x04003115 RID: 12565
	public bool masksBanned;

	// Token: 0x04003116 RID: 12566
	public bool paranormal;
}
