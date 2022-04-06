using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C29 RID: 7209 RVA: 0x00148F0A File Offset: 0x0014710A
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x00148F32 File Offset: 0x00147132
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x04003190 RID: 12688
	public bool loveSick;

	// Token: 0x04003191 RID: 12689
	public bool masksBanned;

	// Token: 0x04003192 RID: 12690
	public bool paranormal;
}
