using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class GameSaveData
{
	// Token: 0x06001C3A RID: 7226 RVA: 0x0014A7D6 File Offset: 0x001489D6
	public static GameSaveData ReadFromGlobals()
	{
		return new GameSaveData
		{
			loveSick = GameGlobals.LoveSick,
			masksBanned = GameGlobals.MasksBanned,
			paranormal = GameGlobals.Paranormal
		};
	}

	// Token: 0x06001C3B RID: 7227 RVA: 0x0014A7FE File Offset: 0x001489FE
	public static void WriteToGlobals(GameSaveData data)
	{
		GameGlobals.LoveSick = data.loveSick;
		GameGlobals.MasksBanned = data.masksBanned;
		GameGlobals.Paranormal = data.paranormal;
	}

	// Token: 0x040031BF RID: 12735
	public bool loveSick;

	// Token: 0x040031C0 RID: 12736
	public bool masksBanned;

	// Token: 0x040031C1 RID: 12737
	public bool paranormal;
}
