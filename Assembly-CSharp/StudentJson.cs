using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000343 RID: 835
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06001905 RID: 6405 RVA: 0x000FB097 File Offset: 0x000F9297
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

	// Token: 0x06001906 RID: 6406 RVA: 0x000FB0C0 File Offset: 0x000F92C0
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
	// (get) Token: 0x06001907 RID: 6407 RVA: 0x000FB338 File Offset: 0x000F9538
	// (set) Token: 0x06001908 RID: 6408 RVA: 0x000FB340 File Offset: 0x000F9540
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
	// (get) Token: 0x06001909 RID: 6409 RVA: 0x000FB349 File Offset: 0x000F9549
	// (set) Token: 0x0600190A RID: 6410 RVA: 0x000FB351 File Offset: 0x000F9551
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
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x000FB35A File Offset: 0x000F955A
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x0600190C RID: 6412 RVA: 0x000FB362 File Offset: 0x000F9562
	// (set) Token: 0x0600190D RID: 6413 RVA: 0x000FB36A File Offset: 0x000F956A
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
	// (get) Token: 0x0600190E RID: 6414 RVA: 0x000FB373 File Offset: 0x000F9573
	// (set) Token: 0x0600190F RID: 6415 RVA: 0x000FB37B File Offset: 0x000F957B
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
	// (get) Token: 0x06001910 RID: 6416 RVA: 0x000FB384 File Offset: 0x000F9584
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000FB38C File Offset: 0x000F958C
	// (set) Token: 0x06001912 RID: 6418 RVA: 0x000FB394 File Offset: 0x000F9594
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
	// (get) Token: 0x06001913 RID: 6419 RVA: 0x000FB39D File Offset: 0x000F959D
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000FB3A5 File Offset: 0x000F95A5
	// (set) Token: 0x06001915 RID: 6421 RVA: 0x000FB3AD File Offset: 0x000F95AD
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
	// (get) Token: 0x06001916 RID: 6422 RVA: 0x000FB3B6 File Offset: 0x000F95B6
	// (set) Token: 0x06001917 RID: 6423 RVA: 0x000FB3BE File Offset: 0x000F95BE
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
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FB3C7 File Offset: 0x000F95C7
	// (set) Token: 0x06001919 RID: 6425 RVA: 0x000FB3CF File Offset: 0x000F95CF
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
	// (get) Token: 0x0600191A RID: 6426 RVA: 0x000FB3D8 File Offset: 0x000F95D8
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x0600191B RID: 6427 RVA: 0x000FB3E0 File Offset: 0x000F95E0
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x0600191C RID: 6428 RVA: 0x000FB3E8 File Offset: 0x000F95E8
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x0600191D RID: 6429 RVA: 0x000FB3F0 File Offset: 0x000F95F0
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x0600191E RID: 6430 RVA: 0x000FB3F8 File Offset: 0x000F95F8
	// (set) Token: 0x0600191F RID: 6431 RVA: 0x000FB400 File Offset: 0x000F9600
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
	// (get) Token: 0x06001920 RID: 6432 RVA: 0x000FB409 File Offset: 0x000F9609
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FB411 File Offset: 0x000F9611
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001922 RID: 6434 RVA: 0x000FB419 File Offset: 0x000F9619
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x000FB424 File Offset: 0x000F9624
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

	// Token: 0x06001924 RID: 6436 RVA: 0x000FB475 File Offset: 0x000F9675
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400273A RID: 10042
	[SerializeField]
	private string name;

	// Token: 0x0400273B RID: 10043
	[SerializeField]
	private string realname;

	// Token: 0x0400273C RID: 10044
	[SerializeField]
	private int gender;

	// Token: 0x0400273D RID: 10045
	[SerializeField]
	private int classID;

	// Token: 0x0400273E RID: 10046
	[SerializeField]
	private int seat;

	// Token: 0x0400273F RID: 10047
	[SerializeField]
	private ClubType club;

	// Token: 0x04002740 RID: 10048
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002741 RID: 10049
	[SerializeField]
	private int crush;

	// Token: 0x04002742 RID: 10050
	[SerializeField]
	private float breastSize;

	// Token: 0x04002743 RID: 10051
	[SerializeField]
	private int strength;

	// Token: 0x04002744 RID: 10052
	[SerializeField]
	private string hairstyle;

	// Token: 0x04002745 RID: 10053
	[SerializeField]
	private string color;

	// Token: 0x04002746 RID: 10054
	[SerializeField]
	private string eyes;

	// Token: 0x04002747 RID: 10055
	[SerializeField]
	private string eyeType;

	// Token: 0x04002748 RID: 10056
	[SerializeField]
	private string stockings;

	// Token: 0x04002749 RID: 10057
	[SerializeField]
	private string accessory;

	// Token: 0x0400274A RID: 10058
	[SerializeField]
	private string info;

	// Token: 0x0400274B RID: 10059
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x0400274C RID: 10060
	[SerializeField]
	private bool success;
}
