using System;

// Token: 0x020003F0 RID: 1008
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x001428C8 File Offset: 0x00140AC8
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

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00142974 File Offset: 0x00140B74
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

	// Token: 0x040030B4 RID: 12468
	public ClubType club;

	// Token: 0x040030B5 RID: 12469
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030B6 RID: 12470
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030B7 RID: 12471
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
