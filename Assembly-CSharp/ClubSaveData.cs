using System;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x00147838 File Offset: 0x00145A38
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

	// Token: 0x06001C08 RID: 7176 RVA: 0x001478E4 File Offset: 0x00145AE4
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

	// Token: 0x0400315A RID: 12634
	public ClubType club;

	// Token: 0x0400315B RID: 12635
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x0400315C RID: 12636
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x0400315D RID: 12637
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
