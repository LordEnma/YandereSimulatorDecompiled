using System;

// Token: 0x020003F1 RID: 1009
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BDC RID: 7132 RVA: 0x00143584 File Offset: 0x00141784
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

	// Token: 0x06001BDD RID: 7133 RVA: 0x00143630 File Offset: 0x00141830
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

	// Token: 0x040030E5 RID: 12517
	public ClubType club;

	// Token: 0x040030E6 RID: 12518
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030E7 RID: 12519
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030E8 RID: 12520
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
