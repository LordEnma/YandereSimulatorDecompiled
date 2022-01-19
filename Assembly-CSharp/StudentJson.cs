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
	// (get) Token: 0x060018FB RID: 6395 RVA: 0x000FA8F3 File Offset: 0x000F8AF3
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

	// Token: 0x060018FC RID: 6396 RVA: 0x000FA91C File Offset: 0x000F8B1C
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
	// (get) Token: 0x060018FD RID: 6397 RVA: 0x000FAB94 File Offset: 0x000F8D94
	// (set) Token: 0x060018FE RID: 6398 RVA: 0x000FAB9C File Offset: 0x000F8D9C
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
	// (get) Token: 0x060018FF RID: 6399 RVA: 0x000FABA5 File Offset: 0x000F8DA5
	// (set) Token: 0x06001900 RID: 6400 RVA: 0x000FABAD File Offset: 0x000F8DAD
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
	// (get) Token: 0x06001901 RID: 6401 RVA: 0x000FABB6 File Offset: 0x000F8DB6
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001902 RID: 6402 RVA: 0x000FABBE File Offset: 0x000F8DBE
	// (set) Token: 0x06001903 RID: 6403 RVA: 0x000FABC6 File Offset: 0x000F8DC6
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
	// (get) Token: 0x06001904 RID: 6404 RVA: 0x000FABCF File Offset: 0x000F8DCF
	// (set) Token: 0x06001905 RID: 6405 RVA: 0x000FABD7 File Offset: 0x000F8DD7
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
	// (get) Token: 0x06001906 RID: 6406 RVA: 0x000FABE0 File Offset: 0x000F8DE0
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001907 RID: 6407 RVA: 0x000FABE8 File Offset: 0x000F8DE8
	// (set) Token: 0x06001908 RID: 6408 RVA: 0x000FABF0 File Offset: 0x000F8DF0
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
	// (get) Token: 0x06001909 RID: 6409 RVA: 0x000FABF9 File Offset: 0x000F8DF9
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600190A RID: 6410 RVA: 0x000FAC01 File Offset: 0x000F8E01
	// (set) Token: 0x0600190B RID: 6411 RVA: 0x000FAC09 File Offset: 0x000F8E09
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
	// (get) Token: 0x0600190C RID: 6412 RVA: 0x000FAC12 File Offset: 0x000F8E12
	// (set) Token: 0x0600190D RID: 6413 RVA: 0x000FAC1A File Offset: 0x000F8E1A
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
	// (get) Token: 0x0600190E RID: 6414 RVA: 0x000FAC23 File Offset: 0x000F8E23
	// (set) Token: 0x0600190F RID: 6415 RVA: 0x000FAC2B File Offset: 0x000F8E2B
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
	// (get) Token: 0x06001910 RID: 6416 RVA: 0x000FAC34 File Offset: 0x000F8E34
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000FAC3C File Offset: 0x000F8E3C
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FAC44 File Offset: 0x000F8E44
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001913 RID: 6419 RVA: 0x000FAC4C File Offset: 0x000F8E4C
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000FAC54 File Offset: 0x000F8E54
	// (set) Token: 0x06001915 RID: 6421 RVA: 0x000FAC5C File Offset: 0x000F8E5C
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
	// (get) Token: 0x06001916 RID: 6422 RVA: 0x000FAC65 File Offset: 0x000F8E65
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001917 RID: 6423 RVA: 0x000FAC6D File Offset: 0x000F8E6D
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FAC75 File Offset: 0x000F8E75
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x000FAC80 File Offset: 0x000F8E80
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

	// Token: 0x0600191A RID: 6426 RVA: 0x000FACD1 File Offset: 0x000F8ED1
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400272A RID: 10026
	[SerializeField]
	private string name;

	// Token: 0x0400272B RID: 10027
	[SerializeField]
	private string realname;

	// Token: 0x0400272C RID: 10028
	[SerializeField]
	private int gender;

	// Token: 0x0400272D RID: 10029
	[SerializeField]
	private int classID;

	// Token: 0x0400272E RID: 10030
	[SerializeField]
	private int seat;

	// Token: 0x0400272F RID: 10031
	[SerializeField]
	private ClubType club;

	// Token: 0x04002730 RID: 10032
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002731 RID: 10033
	[SerializeField]
	private int crush;

	// Token: 0x04002732 RID: 10034
	[SerializeField]
	private float breastSize;

	// Token: 0x04002733 RID: 10035
	[SerializeField]
	private int strength;

	// Token: 0x04002734 RID: 10036
	[SerializeField]
	private string hairstyle;

	// Token: 0x04002735 RID: 10037
	[SerializeField]
	private string color;

	// Token: 0x04002736 RID: 10038
	[SerializeField]
	private string eyes;

	// Token: 0x04002737 RID: 10039
	[SerializeField]
	private string eyeType;

	// Token: 0x04002738 RID: 10040
	[SerializeField]
	private string stockings;

	// Token: 0x04002739 RID: 10041
	[SerializeField]
	private string accessory;

	// Token: 0x0400273A RID: 10042
	[SerializeField]
	private string info;

	// Token: 0x0400273B RID: 10043
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x0400273C RID: 10044
	[SerializeField]
	private bool success;
}
