using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000346 RID: 838
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001925 RID: 6437 RVA: 0x000FCEE3 File Offset: 0x000FB0E3
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

	// Token: 0x06001926 RID: 6438 RVA: 0x000FCF0C File Offset: 0x000FB10C
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

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001927 RID: 6439 RVA: 0x000FD184 File Offset: 0x000FB384
	// (set) Token: 0x06001928 RID: 6440 RVA: 0x000FD18C File Offset: 0x000FB38C
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

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001929 RID: 6441 RVA: 0x000FD195 File Offset: 0x000FB395
	// (set) Token: 0x0600192A RID: 6442 RVA: 0x000FD19D File Offset: 0x000FB39D
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

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x0600192B RID: 6443 RVA: 0x000FD1A6 File Offset: 0x000FB3A6
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x0600192C RID: 6444 RVA: 0x000FD1AE File Offset: 0x000FB3AE
	// (set) Token: 0x0600192D RID: 6445 RVA: 0x000FD1B6 File Offset: 0x000FB3B6
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

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600192E RID: 6446 RVA: 0x000FD1BF File Offset: 0x000FB3BF
	// (set) Token: 0x0600192F RID: 6447 RVA: 0x000FD1C7 File Offset: 0x000FB3C7
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

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06001930 RID: 6448 RVA: 0x000FD1D0 File Offset: 0x000FB3D0
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06001931 RID: 6449 RVA: 0x000FD1D8 File Offset: 0x000FB3D8
	// (set) Token: 0x06001932 RID: 6450 RVA: 0x000FD1E0 File Offset: 0x000FB3E0
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

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06001933 RID: 6451 RVA: 0x000FD1E9 File Offset: 0x000FB3E9
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001934 RID: 6452 RVA: 0x000FD1F1 File Offset: 0x000FB3F1
	// (set) Token: 0x06001935 RID: 6453 RVA: 0x000FD1F9 File Offset: 0x000FB3F9
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

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001936 RID: 6454 RVA: 0x000FD202 File Offset: 0x000FB402
	// (set) Token: 0x06001937 RID: 6455 RVA: 0x000FD20A File Offset: 0x000FB40A
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

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001938 RID: 6456 RVA: 0x000FD213 File Offset: 0x000FB413
	// (set) Token: 0x06001939 RID: 6457 RVA: 0x000FD21B File Offset: 0x000FB41B
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

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x0600193A RID: 6458 RVA: 0x000FD224 File Offset: 0x000FB424
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x0600193B RID: 6459 RVA: 0x000FD22C File Offset: 0x000FB42C
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x0600193C RID: 6460 RVA: 0x000FD234 File Offset: 0x000FB434
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x0600193D RID: 6461 RVA: 0x000FD23C File Offset: 0x000FB43C
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x0600193E RID: 6462 RVA: 0x000FD244 File Offset: 0x000FB444
	// (set) Token: 0x0600193F RID: 6463 RVA: 0x000FD24C File Offset: 0x000FB44C
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

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001940 RID: 6464 RVA: 0x000FD255 File Offset: 0x000FB455
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001941 RID: 6465 RVA: 0x000FD25D File Offset: 0x000FB45D
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001942 RID: 6466 RVA: 0x000FD265 File Offset: 0x000FB465
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001943 RID: 6467 RVA: 0x000FD270 File Offset: 0x000FB470
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

	// Token: 0x06001944 RID: 6468 RVA: 0x000FD2C1 File Offset: 0x000FB4C1
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400279A RID: 10138
	[SerializeField]
	private string name;

	// Token: 0x0400279B RID: 10139
	[SerializeField]
	private string realname;

	// Token: 0x0400279C RID: 10140
	[SerializeField]
	private int gender;

	// Token: 0x0400279D RID: 10141
	[SerializeField]
	private int classID;

	// Token: 0x0400279E RID: 10142
	[SerializeField]
	private int seat;

	// Token: 0x0400279F RID: 10143
	[SerializeField]
	private ClubType club;

	// Token: 0x040027A0 RID: 10144
	[SerializeField]
	private PersonaType persona;

	// Token: 0x040027A1 RID: 10145
	[SerializeField]
	private int crush;

	// Token: 0x040027A2 RID: 10146
	[SerializeField]
	private float breastSize;

	// Token: 0x040027A3 RID: 10147
	[SerializeField]
	private int strength;

	// Token: 0x040027A4 RID: 10148
	[SerializeField]
	private string hairstyle;

	// Token: 0x040027A5 RID: 10149
	[SerializeField]
	private string color;

	// Token: 0x040027A6 RID: 10150
	[SerializeField]
	private string eyes;

	// Token: 0x040027A7 RID: 10151
	[SerializeField]
	private string eyeType;

	// Token: 0x040027A8 RID: 10152
	[SerializeField]
	private string stockings;

	// Token: 0x040027A9 RID: 10153
	[SerializeField]
	private string accessory;

	// Token: 0x040027AA RID: 10154
	[SerializeField]
	private string info;

	// Token: 0x040027AB RID: 10155
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x040027AC RID: 10156
	[SerializeField]
	private bool success;
}
