using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class ClubSaveData
{
	// Token: 0x06001C11 RID: 7185 RVA: 0x001482F4 File Offset: 0x001464F4
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

	// Token: 0x06001C12 RID: 7186 RVA: 0x001483A0 File Offset: 0x001465A0
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

	// Token: 0x04003173 RID: 12659
	public ClubType club;

	// Token: 0x04003174 RID: 12660
	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	// Token: 0x04003175 RID: 12661
	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	// Token: 0x04003176 RID: 12662
	public ClubTypeHashSet quitClub = new ClubTypeHashSet();
}
