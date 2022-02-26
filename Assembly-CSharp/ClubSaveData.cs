using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x00146458 File Offset: 0x00144658
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

	// Token: 0x06001BF9 RID: 7161 RVA: 0x00146504 File Offset: 0x00144704
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

	// Token: 0x04003110 RID: 12560
	public ClubType club;

	// Token: 0x04003111 RID: 12561
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x04003112 RID: 12562
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x04003113 RID: 12563
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
