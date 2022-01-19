using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BE5 RID: 7141 RVA: 0x00145000 File Offset: 0x00143200
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

	// Token: 0x06001BE6 RID: 7142 RVA: 0x001450AC File Offset: 0x001432AC
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

	// Token: 0x040030F0 RID: 12528
	public ClubType club;

	// Token: 0x040030F1 RID: 12529
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030F2 RID: 12530
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030F3 RID: 12531
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
