using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C3B RID: 7227 RVA: 0x0014AA92 File Offset: 0x00148C92
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x0014AABA File Offset: 0x00148CBA
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040031C7 RID: 12743
	public bool loveSick;

	// Token: 0x040031C8 RID: 12744
	public bool masksBanned;

	// Token: 0x040031C9 RID: 12745
	public bool paranormal;
}
