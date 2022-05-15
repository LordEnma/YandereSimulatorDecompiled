using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000347 RID: 839
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x0600192F RID: 6447 RVA: 0x000FDBED File Offset: 0x000FBDED
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

	// Token: 0x06001930 RID: 6448 RVA: 0x000FDC18 File Offset: 0x000FBE18
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

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001931 RID: 6449 RVA: 0x000FDE90 File Offset: 0x000FC090
	// (set) Token: 0x06001932 RID: 6450 RVA: 0x000FDE98 File Offset: 0x000FC098
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

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001933 RID: 6451 RVA: 0x000FDEA1 File Offset: 0x000FC0A1
	// (set) Token: 0x06001934 RID: 6452 RVA: 0x000FDEA9 File Offset: 0x000FC0A9
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

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06001935 RID: 6453 RVA: 0x000FDEB2 File Offset: 0x000FC0B2
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06001936 RID: 6454 RVA: 0x000FDEBA File Offset: 0x000FC0BA
	// (set) Token: 0x06001937 RID: 6455 RVA: 0x000FDEC2 File Offset: 0x000FC0C2
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

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06001938 RID: 6456 RVA: 0x000FDECB File Offset: 0x000FC0CB
	// (set) Token: 0x06001939 RID: 6457 RVA: 0x000FDED3 File Offset: 0x000FC0D3
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

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x0600193A RID: 6458 RVA: 0x000FDEDC File Offset: 0x000FC0DC
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x0600193B RID: 6459 RVA: 0x000FDEE4 File Offset: 0x000FC0E4
	// (set) Token: 0x0600193C RID: 6460 RVA: 0x000FDEEC File Offset: 0x000FC0EC
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

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x0600193D RID: 6461 RVA: 0x000FDEF5 File Offset: 0x000FC0F5
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x0600193E RID: 6462 RVA: 0x000FDEFD File Offset: 0x000FC0FD
	// (set) Token: 0x0600193F RID: 6463 RVA: 0x000FDF05 File Offset: 0x000FC105
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

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001940 RID: 6464 RVA: 0x000FDF0E File Offset: 0x000FC10E
	// (set) Token: 0x06001941 RID: 6465 RVA: 0x000FDF16 File Offset: 0x000FC116
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

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001942 RID: 6466 RVA: 0x000FDF1F File Offset: 0x000FC11F
	// (set) Token: 0x06001943 RID: 6467 RVA: 0x000FDF27 File Offset: 0x000FC127
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

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06001944 RID: 6468 RVA: 0x000FDF30 File Offset: 0x000FC130
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001945 RID: 6469 RVA: 0x000FDF38 File Offset: 0x000FC138
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001946 RID: 6470 RVA: 0x000FDF40 File Offset: 0x000FC140
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001947 RID: 6471 RVA: 0x000FDF48 File Offset: 0x000FC148
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001948 RID: 6472 RVA: 0x000FDF50 File Offset: 0x000FC150
	// (set) Token: 0x06001949 RID: 6473 RVA: 0x000FDF58 File Offset: 0x000FC158
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

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600194A RID: 6474 RVA: 0x000FDF61 File Offset: 0x000FC161
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x0600194B RID: 6475 RVA: 0x000FDF69 File Offset: 0x000FC169
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x0600194C RID: 6476 RVA: 0x000FDF71 File Offset: 0x000FC171
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x0600194D RID: 6477 RVA: 0x000FDF7C File Offset: 0x000FC17C
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

	// Token: 0x0600194E RID: 6478 RVA: 0x000FDFCD File Offset: 0x000FC1CD
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x040027B4 RID: 10164
	[SerializeField]
	private string name;

	// Token: 0x040027B5 RID: 10165
	[SerializeField]
	private string realname;

	// Token: 0x040027B6 RID: 10166
	[SerializeField]
	private int gender;

	// Token: 0x040027B7 RID: 10167
	[SerializeField]
	private int classID;

	// Token: 0x040027B8 RID: 10168
	[SerializeField]
	private int seat;

	// Token: 0x040027B9 RID: 10169
	[SerializeField]
	private ClubType club;

	// Token: 0x040027BA RID: 10170
	[SerializeField]
	private PersonaType persona;

	// Token: 0x040027BB RID: 10171
	[SerializeField]
	private int crush;

	// Token: 0x040027BC RID: 10172
	[SerializeField]
	private float breastSize;

	// Token: 0x040027BD RID: 10173
	[SerializeField]
	private int strength;

	// Token: 0x040027BE RID: 10174
	[SerializeField]
	private string hairstyle;

	// Token: 0x040027BF RID: 10175
	[SerializeField]
	private string color;

	// Token: 0x040027C0 RID: 10176
	[SerializeField]
	private string eyes;

	// Token: 0x040027C1 RID: 10177
	[SerializeField]
	private string eyeType;

	// Token: 0x040027C2 RID: 10178
	[SerializeField]
	private string stockings;

	// Token: 0x040027C3 RID: 10179
	[SerializeField]
	private string accessory;

	// Token: 0x040027C4 RID: 10180
	[SerializeField]
	private string info;

	// Token: 0x040027C5 RID: 10181
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x040027C6 RID: 10182
	[SerializeField]
	private bool success;
}
