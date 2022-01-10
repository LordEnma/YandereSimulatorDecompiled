using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000342 RID: 834
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x060018FB RID: 6395 RVA: 0x000FA78B File Offset: 0x000F898B
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

	// Token: 0x060018FC RID: 6396 RVA: 0x000FA7B4 File Offset: 0x000F89B4
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

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x060018FD RID: 6397 RVA: 0x000FAA2C File Offset: 0x000F8C2C
	// (set) Token: 0x060018FE RID: 6398 RVA: 0x000FAA34 File Offset: 0x000F8C34
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

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x060018FF RID: 6399 RVA: 0x000FAA3D File Offset: 0x000F8C3D
	// (set) Token: 0x06001900 RID: 6400 RVA: 0x000FAA45 File Offset: 0x000F8C45
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

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06001901 RID: 6401 RVA: 0x000FAA4E File Offset: 0x000F8C4E
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001902 RID: 6402 RVA: 0x000FAA56 File Offset: 0x000F8C56
	// (set) Token: 0x06001903 RID: 6403 RVA: 0x000FAA5E File Offset: 0x000F8C5E
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

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001904 RID: 6404 RVA: 0x000FAA67 File Offset: 0x000F8C67
	// (set) Token: 0x06001905 RID: 6405 RVA: 0x000FAA6F File Offset: 0x000F8C6F
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

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001906 RID: 6406 RVA: 0x000FAA78 File Offset: 0x000F8C78
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001907 RID: 6407 RVA: 0x000FAA80 File Offset: 0x000F8C80
	// (set) Token: 0x06001908 RID: 6408 RVA: 0x000FAA88 File Offset: 0x000F8C88
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

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06001909 RID: 6409 RVA: 0x000FAA91 File Offset: 0x000F8C91
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600190A RID: 6410 RVA: 0x000FAA99 File Offset: 0x000F8C99
	// (set) Token: 0x0600190B RID: 6411 RVA: 0x000FAAA1 File Offset: 0x000F8CA1
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

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x0600190C RID: 6412 RVA: 0x000FAAAA File Offset: 0x000F8CAA
	// (set) Token: 0x0600190D RID: 6413 RVA: 0x000FAAB2 File Offset: 0x000F8CB2
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

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x0600190E RID: 6414 RVA: 0x000FAABB File Offset: 0x000F8CBB
	// (set) Token: 0x0600190F RID: 6415 RVA: 0x000FAAC3 File Offset: 0x000F8CC3
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

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06001910 RID: 6416 RVA: 0x000FAACC File Offset: 0x000F8CCC
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000FAAD4 File Offset: 0x000F8CD4
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FAADC File Offset: 0x000F8CDC
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001913 RID: 6419 RVA: 0x000FAAE4 File Offset: 0x000F8CE4
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000FAAEC File Offset: 0x000F8CEC
	// (set) Token: 0x06001915 RID: 6421 RVA: 0x000FAAF4 File Offset: 0x000F8CF4
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

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06001916 RID: 6422 RVA: 0x000FAAFD File Offset: 0x000F8CFD
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001917 RID: 6423 RVA: 0x000FAB05 File Offset: 0x000F8D05
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FAB0D File Offset: 0x000F8D0D
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x000FAB18 File Offset: 0x000F8D18
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

	// Token: 0x0600191A RID: 6426 RVA: 0x000FAB69 File Offset: 0x000F8D69
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x04002727 RID: 10023
	[SerializeField]
	private string name;

	// Token: 0x04002728 RID: 10024
	[SerializeField]
	private string realname;

	// Token: 0x04002729 RID: 10025
	[SerializeField]
	private int gender;

	// Token: 0x0400272A RID: 10026
	[SerializeField]
	private int classID;

	// Token: 0x0400272B RID: 10027
	[SerializeField]
	private int seat;

	// Token: 0x0400272C RID: 10028
	[SerializeField]
	private ClubType club;

	// Token: 0x0400272D RID: 10029
	[SerializeField]
	private PersonaType persona;

	// Token: 0x0400272E RID: 10030
	[SerializeField]
	private int crush;

	// Token: 0x0400272F RID: 10031
	[SerializeField]
	private float breastSize;

	// Token: 0x04002730 RID: 10032
	[SerializeField]
	private int strength;

	// Token: 0x04002731 RID: 10033
	[SerializeField]
	private string hairstyle;

	// Token: 0x04002732 RID: 10034
	[SerializeField]
	private string color;

	// Token: 0x04002733 RID: 10035
	[SerializeField]
	private string eyes;

	// Token: 0x04002734 RID: 10036
	[SerializeField]
	private string eyeType;

	// Token: 0x04002735 RID: 10037
	[SerializeField]
	private string stockings;

	// Token: 0x04002736 RID: 10038
	[SerializeField]
	private string accessory;

	// Token: 0x04002737 RID: 10039
	[SerializeField]
	private string info;

	// Token: 0x04002738 RID: 10040
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x04002739 RID: 10041
	[SerializeField]
	private bool success;
}
