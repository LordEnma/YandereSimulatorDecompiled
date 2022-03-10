using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000344 RID: 836
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x0600190E RID: 6414 RVA: 0x000FBD07 File Offset: 0x000F9F07
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

	// Token: 0x0600190F RID: 6415 RVA: 0x000FBD30 File Offset: 0x000F9F30
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

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06001910 RID: 6416 RVA: 0x000FBFA8 File Offset: 0x000FA1A8
	// (set) Token: 0x06001911 RID: 6417 RVA: 0x000FBFB0 File Offset: 0x000FA1B0
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

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FBFB9 File Offset: 0x000FA1B9
	// (set) Token: 0x06001913 RID: 6419 RVA: 0x000FBFC1 File Offset: 0x000FA1C1
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

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000FBFCA File Offset: 0x000FA1CA
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001915 RID: 6421 RVA: 0x000FBFD2 File Offset: 0x000FA1D2
	// (set) Token: 0x06001916 RID: 6422 RVA: 0x000FBFDA File Offset: 0x000FA1DA
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

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001917 RID: 6423 RVA: 0x000FBFE3 File Offset: 0x000FA1E3
	// (set) Token: 0x06001918 RID: 6424 RVA: 0x000FBFEB File Offset: 0x000FA1EB
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

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06001919 RID: 6425 RVA: 0x000FBFF4 File Offset: 0x000FA1F4
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600191A RID: 6426 RVA: 0x000FBFFC File Offset: 0x000FA1FC
	// (set) Token: 0x0600191B RID: 6427 RVA: 0x000FC004 File Offset: 0x000FA204
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

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x0600191C RID: 6428 RVA: 0x000FC00D File Offset: 0x000FA20D
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x0600191D RID: 6429 RVA: 0x000FC015 File Offset: 0x000FA215
	// (set) Token: 0x0600191E RID: 6430 RVA: 0x000FC01D File Offset: 0x000FA21D
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

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x0600191F RID: 6431 RVA: 0x000FC026 File Offset: 0x000FA226
	// (set) Token: 0x06001920 RID: 6432 RVA: 0x000FC02E File Offset: 0x000FA22E
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

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FC037 File Offset: 0x000FA237
	// (set) Token: 0x06001922 RID: 6434 RVA: 0x000FC03F File Offset: 0x000FA23F
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

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001923 RID: 6435 RVA: 0x000FC048 File Offset: 0x000FA248
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001924 RID: 6436 RVA: 0x000FC050 File Offset: 0x000FA250
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001925 RID: 6437 RVA: 0x000FC058 File Offset: 0x000FA258
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06001926 RID: 6438 RVA: 0x000FC060 File Offset: 0x000FA260
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001927 RID: 6439 RVA: 0x000FC068 File Offset: 0x000FA268
	// (set) Token: 0x06001928 RID: 6440 RVA: 0x000FC070 File Offset: 0x000FA270
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

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001929 RID: 6441 RVA: 0x000FC079 File Offset: 0x000FA279
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x0600192A RID: 6442 RVA: 0x000FC081 File Offset: 0x000FA281
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600192B RID: 6443 RVA: 0x000FC089 File Offset: 0x000FA289
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x0600192C RID: 6444 RVA: 0x000FC094 File Offset: 0x000FA294
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

	// Token: 0x0600192D RID: 6445 RVA: 0x000FC0E5 File Offset: 0x000FA2E5
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400275F RID: 10079
	[SerializeField]
	private string name;

	// Token: 0x04002760 RID: 10080
	[SerializeField]
	private string realname;

	// Token: 0x04002761 RID: 10081
	[SerializeField]
	private int gender;

	// Token: 0x04002762 RID: 10082
	[SerializeField]
	private int classID;

	// Token: 0x04002763 RID: 10083
	[SerializeField]
	private int seat;

	// Token: 0x04002764 RID: 10084
	[SerializeField]
	private ClubType club;

	// Token: 0x04002765 RID: 10085
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002766 RID: 10086
	[SerializeField]
	private int crush;

	// Token: 0x04002767 RID: 10087
	[SerializeField]
	private float breastSize;

	// Token: 0x04002768 RID: 10088
	[SerializeField]
	private int strength;

	// Token: 0x04002769 RID: 10089
	[SerializeField]
	private string hairstyle;

	// Token: 0x0400276A RID: 10090
	[SerializeField]
	private string color;

	// Token: 0x0400276B RID: 10091
	[SerializeField]
	private string eyes;

	// Token: 0x0400276C RID: 10092
	[SerializeField]
	private string eyeType;

	// Token: 0x0400276D RID: 10093
	[SerializeField]
	private string stockings;

	// Token: 0x0400276E RID: 10094
	[SerializeField]
	private string accessory;

	// Token: 0x0400276F RID: 10095
	[SerializeField]
	private string info;

	// Token: 0x04002770 RID: 10096
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x04002771 RID: 10097
	[SerializeField]
	private bool success;
}
