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
	// (get) Token: 0x060018FC RID: 6396 RVA: 0x000FAD2B File Offset: 0x000F8F2B
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

	// Token: 0x060018FD RID: 6397 RVA: 0x000FAD54 File Offset: 0x000F8F54
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
	// (get) Token: 0x060018FE RID: 6398 RVA: 0x000FAFCC File Offset: 0x000F91CC
	// (set) Token: 0x060018FF RID: 6399 RVA: 0x000FAFD4 File Offset: 0x000F91D4
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
	// (get) Token: 0x06001900 RID: 6400 RVA: 0x000FAFDD File Offset: 0x000F91DD
	// (set) Token: 0x06001901 RID: 6401 RVA: 0x000FAFE5 File Offset: 0x000F91E5
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
	// (get) Token: 0x06001902 RID: 6402 RVA: 0x000FAFEE File Offset: 0x000F91EE
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001903 RID: 6403 RVA: 0x000FAFF6 File Offset: 0x000F91F6
	// (set) Token: 0x06001904 RID: 6404 RVA: 0x000FAFFE File Offset: 0x000F91FE
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
	// (get) Token: 0x06001905 RID: 6405 RVA: 0x000FB007 File Offset: 0x000F9207
	// (set) Token: 0x06001906 RID: 6406 RVA: 0x000FB00F File Offset: 0x000F920F
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
	// (get) Token: 0x06001907 RID: 6407 RVA: 0x000FB018 File Offset: 0x000F9218
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001908 RID: 6408 RVA: 0x000FB020 File Offset: 0x000F9220
	// (set) Token: 0x06001909 RID: 6409 RVA: 0x000FB028 File Offset: 0x000F9228
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
	// (get) Token: 0x0600190A RID: 6410 RVA: 0x000FB031 File Offset: 0x000F9231
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x000FB039 File Offset: 0x000F9239
	// (set) Token: 0x0600190C RID: 6412 RVA: 0x000FB041 File Offset: 0x000F9241
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
	// (get) Token: 0x0600190D RID: 6413 RVA: 0x000FB04A File Offset: 0x000F924A
	// (set) Token: 0x0600190E RID: 6414 RVA: 0x000FB052 File Offset: 0x000F9252
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
	// (get) Token: 0x0600190F RID: 6415 RVA: 0x000FB05B File Offset: 0x000F925B
	// (set) Token: 0x06001910 RID: 6416 RVA: 0x000FB063 File Offset: 0x000F9263
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
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000FB06C File Offset: 0x000F926C
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FB074 File Offset: 0x000F9274
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001913 RID: 6419 RVA: 0x000FB07C File Offset: 0x000F927C
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000FB084 File Offset: 0x000F9284
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001915 RID: 6421 RVA: 0x000FB08C File Offset: 0x000F928C
	// (set) Token: 0x06001916 RID: 6422 RVA: 0x000FB094 File Offset: 0x000F9294
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
	// (get) Token: 0x06001917 RID: 6423 RVA: 0x000FB09D File Offset: 0x000F929D
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FB0A5 File Offset: 0x000F92A5
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001919 RID: 6425 RVA: 0x000FB0AD File Offset: 0x000F92AD
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x0600191A RID: 6426 RVA: 0x000FB0B8 File Offset: 0x000F92B8
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

	// Token: 0x0600191B RID: 6427 RVA: 0x000FB109 File Offset: 0x000F9309
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x04002730 RID: 10032
	[SerializeField]
	private string name;

	// Token: 0x04002731 RID: 10033
	[SerializeField]
	private string realname;

	// Token: 0x04002732 RID: 10034
	[SerializeField]
	private int gender;

	// Token: 0x04002733 RID: 10035
	[SerializeField]
	private int classID;

	// Token: 0x04002734 RID: 10036
	[SerializeField]
	private int seat;

	// Token: 0x04002735 RID: 10037
	[SerializeField]
	private ClubType club;

	// Token: 0x04002736 RID: 10038
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002737 RID: 10039
	[SerializeField]
	private int crush;

	// Token: 0x04002738 RID: 10040
	[SerializeField]
	private float breastSize;

	// Token: 0x04002739 RID: 10041
	[SerializeField]
	private int strength;

	// Token: 0x0400273A RID: 10042
	[SerializeField]
	private string hairstyle;

	// Token: 0x0400273B RID: 10043
	[SerializeField]
	private string color;

	// Token: 0x0400273C RID: 10044
	[SerializeField]
	private string eyes;

	// Token: 0x0400273D RID: 10045
	[SerializeField]
	private string eyeType;

	// Token: 0x0400273E RID: 10046
	[SerializeField]
	private string stockings;

	// Token: 0x0400273F RID: 10047
	[SerializeField]
	private string accessory;

	// Token: 0x04002740 RID: 10048
	[SerializeField]
	private string info;

	// Token: 0x04002741 RID: 10049
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x04002742 RID: 10050
	[SerializeField]
	private bool success;
}
