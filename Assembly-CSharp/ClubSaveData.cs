using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00149224 File Offset: 0x00147424
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

	// Token: 0x06001C23 RID: 7203 RVA: 0x001492D0 File Offset: 0x001474D0
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

	// Token: 0x04003190 RID: 12688
	public ClubType club;

	// Token: 0x04003191 RID: 12689
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x04003192 RID: 12690
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x04003193 RID: 12691
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
