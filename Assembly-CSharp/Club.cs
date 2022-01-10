using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class Club
{
	// Token: 0x06001438 RID: 5176 RVA: 0x000C51A2 File Offset: 0x000C33A2
	public Club(ClubType type)
	{
		this.type = type;
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C51B1 File Offset: 0x000C33B1
	// (set) Token: 0x0600143A RID: 5178 RVA: 0x000C51B9 File Offset: 0x000C33B9
	public ClubType Type
	{
		get
		{
			return this.type;
		}
		set
		{
			this.type = value;
		}
	}

	// Token: 0x04001EE7 RID: 7911
	[SerializeField]
	private ClubType type;

	// Token: 0x04001EE8 RID: 7912
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

	// Token: 0x04001EE9 RID: 7913
	public static readonly IntAndStringDictionary TeacherClubNames = new IntAndStringDictionary
	{
		{
			0,
			"Gym Teacher"
		},
		{
			1,
			"School Nurse"
		},
		{
			2,
			"Guidance Counselor"
		},
		{
			3,
			"Headmaster"
		},
		{
			4,
			"?????"
		},
		{
			11,
			"Teacher of Class 1-1"
		},
		{
			12,
			"Teacher of Class 1-2"
		},
		{
			21,
			"Teacher of Class 2-1"
		},
		{
			22,
			"Teacher of Class 2-2"
		},
		{
			31,
			"Teacher of Class 3-1"
		},
		{
			32,
			"Teacher of Class 3-2"
		}
	};
}
