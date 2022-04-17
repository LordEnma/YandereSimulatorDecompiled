using System;
using UnityEngine;

// Token: 0x020002AC RID: 684
[Serializable]
public class Club
{
	// Token: 0x06001451 RID: 5201 RVA: 0x000C693A File Offset: 0x000C4B3A
	public Club(ClubType type)
	{
		this.type = type;
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001452 RID: 5202 RVA: 0x000C6949 File Offset: 0x000C4B49
	// (set) Token: 0x06001453 RID: 5203 RVA: 0x000C6951 File Offset: 0x000C4B51
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

	// Token: 0x04001F25 RID: 7973
	[SerializeField]
	private ClubType type;

	// Token: 0x04001F26 RID: 7974
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

	// Token: 0x04001F27 RID: 7975
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
