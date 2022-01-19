using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class Club
{
	// Token: 0x06001438 RID: 5176 RVA: 0x000C5276 File Offset: 0x000C3476
	public Club(ClubType type)
	{
		this.type = type;
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C5285 File Offset: 0x000C3485
	// (set) Token: 0x0600143A RID: 5178 RVA: 0x000C528D File Offset: 0x000C348D
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

	// Token: 0x04001EEA RID: 7914
	[SerializeField]
	private ClubType type;

	// Token: 0x04001EEB RID: 7915
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

	// Token: 0x04001EEC RID: 7916
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
