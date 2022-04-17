using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001C1B RID: 7195 RVA: 0x001489E8 File Offset: 0x00146BE8
	public static ClubSaveData ReadFromGlobals()
	{
		ClubSaveData clubSaveData = new ClubSaveData();
		clubSaveData.club = ClubGlobals.Club;
		foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed())
		{
			if (ClubGlobals.GetClubClosed(clubType))
			{
				clubSaveData.clubClosed.Add(clubType);
			}
		}
		foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked())
		{
			if (ClubGlobals.GetClubKicked(clubType2))
			{
				clubSaveData.clubKicked.Add(clubType2);
			}
		}
		foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub())
		{
			if (ClubGlobals.GetQuitClub(clubType3))
			{
				clubSaveData.quitClub.Add(clubType3);
			}
		}
		return clubSaveData;
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x00148A94 File Offset: 0x00146C94
	public static void WriteToGlobals(ClubSaveData data)
	{
		ClubGlobals.Club = data.club;
		foreach (ClubType clubID in data.clubClosed)
		{
			ClubGlobals.SetClubClosed(clubID, true);
		}
		foreach (ClubType clubID2 in data.clubKicked)
		{
			ClubGlobals.SetClubKicked(clubID2, true);
		}
		foreach (ClubType clubID3 in data.quitClub)
		{
			ClubGlobals.SetQuitClub(clubID3, true);
		}
	}

	// Token: 0x04003181 RID: 12673
	public ClubType club;

	// Token: 0x04003182 RID: 12674
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x04003183 RID: 12675
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x04003184 RID: 12676
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
