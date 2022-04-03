using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C23 RID: 7203 RVA: 0x00148C26 File Offset: 0x00146E26
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x00148C4E File Offset: 0x00146E4E
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x0400318D RID: 12685
	public bool loveSick;

	// Token: 0x0400318E RID: 12686
	public bool masksBanned;

	// Token: 0x0400318F RID: 12687
	public bool paranormal;
}
