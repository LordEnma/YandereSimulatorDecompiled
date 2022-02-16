using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x001459E0 File Offset: 0x00143BE0
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

	// Token: 0x06001BF0 RID: 7152 RVA: 0x00145A8C File Offset: 0x00143C8C
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

	// Token: 0x04003100 RID: 12544
	public ClubType club;

	// Token: 0x04003101 RID: 12545
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x04003102 RID: 12546
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x04003103 RID: 12547
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
