using System;

// Token: 0x020003FD RID: 1021
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001C29 RID: 7209 RVA: 0x0014A160 File Offset: 0x00148360
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

	// Token: 0x06001C2A RID: 7210 RVA: 0x0014A20C File Offset: 0x0014840C
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

	// Token: 0x040031AD RID: 12717
	public ClubType club;

	// Token: 0x040031AE RID: 12718
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x040031AF RID: 12719
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x040031B0 RID: 12720
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
