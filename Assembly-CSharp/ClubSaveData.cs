using System;

// Token: 0x020003F1 RID: 1009
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BDA RID: 7130 RVA: 0x00143188 File Offset: 0x00141388
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

	// Token: 0x06001BDB RID: 7131 RVA: 0x00143234 File Offset: 0x00141434
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

	// Token: 0x040030DE RID: 12510
	public ClubType club;

	// Token: 0x040030DF RID: 12511
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030E0 RID: 12512
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030E1 RID: 12513
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
