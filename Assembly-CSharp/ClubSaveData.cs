using System;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BE3 RID: 7139 RVA: 0x001438F8 File Offset: 0x00141AF8
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

	// Token: 0x06001BE4 RID: 7140 RVA: 0x001439A4 File Offset: 0x00141BA4
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

	// Token: 0x040030EB RID: 12523
	public ClubType club;

	// Token: 0x040030EC RID: 12524
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040030ED RID: 12525
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040030EE RID: 12526
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
