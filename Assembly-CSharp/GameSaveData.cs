using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C34 RID: 7220 RVA: 0x00149B56 File Offset: 0x00147D56
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C35 RID: 7221 RVA: 0x00149B7E File Offset: 0x00147D7E
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040031AA RID: 12714
	public bool loveSick;

	// Token: 0x040031AB RID: 12715
	public bool masksBanned;

	// Token: 0x040031AC RID: 12716
	public bool paranormal;
}
