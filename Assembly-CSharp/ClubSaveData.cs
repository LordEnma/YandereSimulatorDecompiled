using System;

[Serializable]
public class ClubSaveData
{
	public ClubType club;

	public ClubTypeHashSet clubClosed = new ClubTypeHashSet();

	public ClubTypeHashSet clubKicked = new ClubTypeHashSet();

	public ClubTypeHashSet quitClub = new ClubTypeHashSet();

	public static ClubSaveData ReadFromGlobals()
	{
		ClubSaveData clubSaveData = new ClubSaveData();
		clubSaveData.club = ClubGlobals.Club;
		ClubType[] array = ClubGlobals.KeysOfClubClosed();
		foreach (ClubType clubType in array)
		{
			if (ClubGlobals.GetClubClosed(clubType))
			{
				clubSaveData.clubClosed.Add(clubType);
			}
		}
		array = ClubGlobals.KeysOfClubKicked();
		foreach (ClubType clubType2 in array)
		{
			if (ClubGlobals.GetClubKicked(clubType2))
			{
				clubSaveData.clubKicked.Add(clubType2);
			}
		}
		array = ClubGlobals.KeysOfQuitClub();
		foreach (ClubType clubType3 in array)
		{
			if (ClubGlobals.GetQuitClub(clubType3))
			{
				clubSaveData.quitClub.Add(clubType3);
			}
		}
		return clubSaveData;
	}

	public static void WriteToGlobals(ClubSaveData data)
	{
		ClubGlobals.Club = data.club;
		foreach (ClubType item in data.clubClosed)
		{
			ClubGlobals.SetClubClosed(item, value: true);
		}
		foreach (ClubType item2 in data.clubKicked)
		{
			ClubGlobals.SetClubKicked(item2, value: true);
		}
		foreach (ClubType item3 in data.quitClub)
		{
			ClubGlobals.SetQuitClub(item3, value: true);
		}
	}
}
