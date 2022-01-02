using System;
using UnityEngine;

// Token: 0x020002A8 RID: 680
[Serializable]
public class Club
{
	// Token: 0x06001434 RID: 5172 RVA: 0x000C4F6A File Offset: 0x000C316A
	public Club(ClubType type)
	{
		this.type = type;
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C4F79 File Offset: 0x000C3179
	// (set) Token: 0x06001436 RID: 5174 RVA: 0x000C4F81 File Offset: 0x000C3181
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

	// Token: 0x04001EE6 RID: 7910
	[SerializeField]
	private ClubType type;

	// Token: 0x04001EE7 RID: 7911
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

	// Token: 0x04001EE8 RID: 7912
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
