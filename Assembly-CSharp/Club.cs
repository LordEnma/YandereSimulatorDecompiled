using System;
using UnityEngine;

[Serializable]
public class Club
{
	[SerializeField]
	private ClubType type;

	public static readonly ClubTypeAndStringDictionary ClubNames = new ClubTypeAndStringDictionary
	{
		{
			ClubType.None,
			"No Club"
		},
		{
			ClubType.Cooking,
			"Cooking"
		},
		{
			ClubType.Drama,
			"Drama"
		},
		{
			ClubType.Occult,
			"Occult"
		},
		{
			ClubType.Art,
			"Art"
		},
		{
			ClubType.LightMusic,
			"Light Music"
		},
		{
			ClubType.MartialArts,
			"Martial Arts"
		},
		{
			ClubType.Photography,
			"Photography"
		},
		{
			ClubType.Science,
			"Science"
		},
		{
			ClubType.Sports,
			"Sports"
		},
		{
			ClubType.Gardening,
			"Gardening"
		},
		{
			ClubType.Gaming,
			"Gaming"
		},
		{
			ClubType.Council,
			"Student Council"
		},
		{
			ClubType.Delinquent,
			"Delinquent"
		},
		{
			ClubType.Bully,
			"No Club"
		},
		{
			ClubType.Newspaper,
			"Newspaper"
		},
		{
			ClubType.Nemesis,
			"?????"
		}
	};

	public static readonly IntAndStringDictionary TeacherClubNames = new IntAndStringDictionary
	{
		{ 0, "Gym Teacher" },
		{ 1, "School Nurse" },
		{ 2, "Guidance Counselor" },
		{ 3, "Headmaster" },
		{ 4, "?????" },
		{ 11, "Teacher of Class 1-1" },
		{ 12, "Teacher of Class 1-2" },
		{ 21, "Teacher of Class 2-1" },
		{ 22, "Teacher of Class 2-2" },
		{ 31, "Teacher of Class 3-1" },
		{ 32, "Teacher of Class 3-2" }
	};

	public ClubType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	public Club(ClubType type)
	{
		this.type = type;
	}
}
