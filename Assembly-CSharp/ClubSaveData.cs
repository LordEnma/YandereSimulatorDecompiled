using System;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BE8 RID: 7144 RVA: 0x001456E0 File Offset: 0x001438E0
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

	// Token: 0x06001BE9 RID: 7145 RVA: 0x0014578C File Offset: 0x0014398C
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

	// Token: 0x040030FA RID: 12538
	public ClubType club;

	// Token: 0x040030FB RID: 12539
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030FC RID: 12540
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030FD RID: 12541
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
