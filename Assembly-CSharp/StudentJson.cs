using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000344 RID: 836
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06001915 RID: 6421 RVA: 0x000FC4C3 File Offset: 0x000FA6C3
	public static string FilePath
	{
		get
		{
			if (!GameGlobals.Eighties)
			{
				return Path.Combine(JsonData.FolderPath, "Students.json");
			}
			return Path.Combine(JsonData.FolderPath, "Eighties.json");
		}
	}

	// Token: 0x06001916 RID: 6422 RVA: 0x000FC4EC File Offset: 0x000FA6EC
	public static StudentJson[] LoadFromJson(string path)
	{
		StudentJson[] array = new StudentJson[101];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new StudentJson();
		}
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			int num = TFUtils.LoadInt(dictionary, "ID");
			if (num == 0)
			{
				break;
			}
			StudentJson studentJson = array[num];
			studentJson.name = TFUtils.LoadString(dictionary, "Name");
			studentJson.realname = TFUtils.LoadString(dictionary, "RealName");
			studentJson.gender = TFUtils.LoadInt(dictionary, "Gender");
			studentJson.classID = TFUtils.LoadInt(dictionary, "Class");
			studentJson.seat = TFUtils.LoadInt(dictionary, "Seat");
			studentJson.club = (ClubType)TFUtils.LoadInt(dictionary, "Club");
			studentJson.persona = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
			studentJson.crush = TFUtils.LoadInt(dictionary, "Crush");
			studentJson.breastSize = TFUtils.LoadFloat(dictionary, "BreastSize");
			studentJson.strength = TFUtils.LoadInt(dictionary, "Strength");
			studentJson.hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
			studentJson.color = TFUtils.LoadString(dictionary, "Color");
			studentJson.eyes = TFUtils.LoadString(dictionary, "Eyes");
			studentJson.eyeType = TFUtils.LoadString(dictionary, "EyeType");
			studentJson.stockings = TFUtils.LoadString(dictionary, "Stockings");
			studentJson.accessory = TFUtils.LoadString(dictionary, "Accessory");
			studentJson.info = TFUtils.LoadString(dictionary, "Info");
			if (GameGlobals.LoveSick)
			{
				studentJson.name = studentJson.realname;
				studentJson.realname = "";
			}
			if (OptionGlobals.HighPopulation && studentJson.name == "Unknown")
			{
				studentJson.name = "Random";
			}
			float[] array3 = StudentJson.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
			string[] array4 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
			string[] array5 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
			studentJson.scheduleBlocks = new ScheduleBlock[array3.Length];
			for (int k = 0; k < studentJson.scheduleBlocks.Length; k++)
			{
				studentJson.scheduleBlocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
			}
			studentJson.success = true;
		}
		return array;
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001917 RID: 6423 RVA: 0x000FC764 File Offset: 0x000FA964
	// (set) Token: 0x06001918 RID: 6424 RVA: 0x000FC76C File Offset: 0x000FA96C
	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
	}

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001919 RID: 6425 RVA: 0x000FC775 File Offset: 0x000FA975
	// (set) Token: 0x0600191A RID: 6426 RVA: 0x000FC77D File Offset: 0x000FA97D
	public string RealName
	{
		get
		{
			return this.realname;
		}
		set
		{
			this.realname = value;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x0600191B RID: 6427 RVA: 0x000FC786 File Offset: 0x000FA986
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x0600191C RID: 6428 RVA: 0x000FC78E File Offset: 0x000FA98E
	// (set) Token: 0x0600191D RID: 6429 RVA: 0x000FC796 File Offset: 0x000FA996
	public int Class
	{
		get
		{
			return this.classID;
		}
		set
		{
			this.classID = value;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x0600191E RID: 6430 RVA: 0x000FC79F File Offset: 0x000FA99F
	// (set) Token: 0x0600191F RID: 6431 RVA: 0x000FC7A7 File Offset: 0x000FA9A7
	public int Seat
	{
		get
		{
			return this.seat;
		}
		set
		{
			this.seat = value;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06001920 RID: 6432 RVA: 0x000FC7B0 File Offset: 0x000FA9B0
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FC7B8 File Offset: 0x000FA9B8
	// (set) Token: 0x06001922 RID: 6434 RVA: 0x000FC7C0 File Offset: 0x000FA9C0
	public PersonaType Persona
	{
		get
		{
			return this.persona;
		}
		set
		{
			this.persona = value;
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06001923 RID: 6435 RVA: 0x000FC7C9 File Offset: 0x000FA9C9
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06001924 RID: 6436 RVA: 0x000FC7D1 File Offset: 0x000FA9D1
	// (set) Token: 0x06001925 RID: 6437 RVA: 0x000FC7D9 File Offset: 0x000FA9D9
	public float BreastSize
	{
		get
		{
			return this.breastSize;
		}
		set
		{
			this.breastSize = value;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001926 RID: 6438 RVA: 0x000FC7E2 File Offset: 0x000FA9E2
	// (set) Token: 0x06001927 RID: 6439 RVA: 0x000FC7EA File Offset: 0x000FA9EA
	public int Strength
	{
		get
		{
			return this.strength;
		}
		set
		{
			this.strength = value;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001928 RID: 6440 RVA: 0x000FC7F3 File Offset: 0x000FA9F3
	// (set) Token: 0x06001929 RID: 6441 RVA: 0x000FC7FB File Offset: 0x000FA9FB
	public string Hairstyle
	{
		get
		{
			return this.hairstyle;
		}
		set
		{
			this.hairstyle = value;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x0600192A RID: 6442 RVA: 0x000FC804 File Offset: 0x000FAA04
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x0600192B RID: 6443 RVA: 0x000FC80C File Offset: 0x000FAA0C
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x0600192C RID: 6444 RVA: 0x000FC814 File Offset: 0x000FAA14
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x0600192D RID: 6445 RVA: 0x000FC81C File Offset: 0x000FAA1C
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x0600192E RID: 6446 RVA: 0x000FC824 File Offset: 0x000FAA24
	// (set) Token: 0x0600192F RID: 6447 RVA: 0x000FC82C File Offset: 0x000FAA2C
	public string Accessory
	{
		get
		{
			return this.accessory;
		}
		set
		{
			this.accessory = value;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001930 RID: 6448 RVA: 0x000FC835 File Offset: 0x000FAA35
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001931 RID: 6449 RVA: 0x000FC83D File Offset: 0x000FAA3D
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001932 RID: 6450 RVA: 0x000FC845 File Offset: 0x000FAA45
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001933 RID: 6451 RVA: 0x000FC850 File Offset: 0x000FAA50
	private static float[] ConstructTempFloatArray(string str)
	{
		string[] array = str.Split(new char[]
		{
			'_'
		});
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			float num;
			if (float.TryParse(array[i], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out num))
			{
				array2[i] = num;
			}
		}
		return array2;
	}

	// Token: 0x06001934 RID: 6452 RVA: 0x000FC8A1 File Offset: 0x000FAAA1
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400277C RID: 10108
	[SerializeField]
	private string name;

	// Token: 0x0400277D RID: 10109
	[SerializeField]
	private string realname;

	// Token: 0x0400277E RID: 10110
	[SerializeField]
	private int gender;

	// Token: 0x0400277F RID: 10111
	[SerializeField]
	private int classID;

	// Token: 0x04002780 RID: 10112
	[SerializeField]
	private int seat;

	// Token: 0x04002781 RID: 10113
	[SerializeField]
	private ClubType club;

	// Token: 0x04002782 RID: 10114
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002783 RID: 10115
	[SerializeField]
	private int crush;

	// Token: 0x04002784 RID: 10116
	[SerializeField]
	private float breastSize;

	// Token: 0x04002785 RID: 10117
	[SerializeField]
	private int strength;

	// Token: 0x04002786 RID: 10118
	[SerializeField]
	private string hairstyle;

	// Token: 0x04002787 RID: 10119
	[SerializeField]
	private string color;

	// Token: 0x04002788 RID: 10120
	[SerializeField]
	private string eyes;

	// Token: 0x04002789 RID: 10121
	[SerializeField]
	private string eyeType;

	// Token: 0x0400278A RID: 10122
	[SerializeField]
	private string stockings;

	// Token: 0x0400278B RID: 10123
	[SerializeField]
	private string accessory;

	// Token: 0x0400278C RID: 10124
	[SerializeField]
	private string info;

	// Token: 0x0400278D RID: 10125
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x0400278E RID: 10126
	[SerializeField]
	private bool success;
}
