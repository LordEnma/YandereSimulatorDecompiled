using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000341 RID: 833
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x060018F5 RID: 6389 RVA: 0x000FA18F File Offset: 0x000F838F
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

	// Token: 0x060018F6 RID: 6390 RVA: 0x000FA1B8 File Offset: 0x000F83B8
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

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x060018F7 RID: 6391 RVA: 0x000FA430 File Offset: 0x000F8630
	// (set) Token: 0x060018F8 RID: 6392 RVA: 0x000FA438 File Offset: 0x000F8638
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

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x060018F9 RID: 6393 RVA: 0x000FA441 File Offset: 0x000F8641
	// (set) Token: 0x060018FA RID: 6394 RVA: 0x000FA449 File Offset: 0x000F8649
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

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x060018FB RID: 6395 RVA: 0x000FA452 File Offset: 0x000F8652
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x060018FC RID: 6396 RVA: 0x000FA45A File Offset: 0x000F865A
	// (set) Token: 0x060018FD RID: 6397 RVA: 0x000FA462 File Offset: 0x000F8662
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

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x060018FE RID: 6398 RVA: 0x000FA46B File Offset: 0x000F866B
	// (set) Token: 0x060018FF RID: 6399 RVA: 0x000FA473 File Offset: 0x000F8673
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

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001900 RID: 6400 RVA: 0x000FA47C File Offset: 0x000F867C
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001901 RID: 6401 RVA: 0x000FA484 File Offset: 0x000F8684
	// (set) Token: 0x06001902 RID: 6402 RVA: 0x000FA48C File Offset: 0x000F868C
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

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001903 RID: 6403 RVA: 0x000FA495 File Offset: 0x000F8695
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06001904 RID: 6404 RVA: 0x000FA49D File Offset: 0x000F869D
	// (set) Token: 0x06001905 RID: 6405 RVA: 0x000FA4A5 File Offset: 0x000F86A5
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

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06001906 RID: 6406 RVA: 0x000FA4AE File Offset: 0x000F86AE
	// (set) Token: 0x06001907 RID: 6407 RVA: 0x000FA4B6 File Offset: 0x000F86B6
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

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06001908 RID: 6408 RVA: 0x000FA4BF File Offset: 0x000F86BF
	// (set) Token: 0x06001909 RID: 6409 RVA: 0x000FA4C7 File Offset: 0x000F86C7
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

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x0600190A RID: 6410 RVA: 0x000FA4D0 File Offset: 0x000F86D0
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x000FA4D8 File Offset: 0x000F86D8
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x0600190C RID: 6412 RVA: 0x000FA4E0 File Offset: 0x000F86E0
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x0600190D RID: 6413 RVA: 0x000FA4E8 File Offset: 0x000F86E8
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x0600190E RID: 6414 RVA: 0x000FA4F0 File Offset: 0x000F86F0
	// (set) Token: 0x0600190F RID: 6415 RVA: 0x000FA4F8 File Offset: 0x000F86F8
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

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001910 RID: 6416 RVA: 0x000FA501 File Offset: 0x000F8701
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000FA509 File Offset: 0x000F8709
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FA511 File Offset: 0x000F8711
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x000FA51C File Offset: 0x000F871C
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

	// Token: 0x06001914 RID: 6420 RVA: 0x000FA56D File Offset: 0x000F876D
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x0400271F RID: 10015
	[SerializeField]
	private string name;

	// Token: 0x04002720 RID: 10016
	[SerializeField]
	private string realname;

	// Token: 0x04002721 RID: 10017
	[SerializeField]
	private int gender;

	// Token: 0x04002722 RID: 10018
	[SerializeField]
	private int classID;

	// Token: 0x04002723 RID: 10019
	[SerializeField]
	private int seat;

	// Token: 0x04002724 RID: 10020
	[SerializeField]
	private ClubType club;

	// Token: 0x04002725 RID: 10021
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002726 RID: 10022
	[SerializeField]
	private int crush;

	// Token: 0x04002727 RID: 10023
	[SerializeField]
	private float breastSize;

	// Token: 0x04002728 RID: 10024
	[SerializeField]
	private int strength;

	// Token: 0x04002729 RID: 10025
	[SerializeField]
	private string hairstyle;

	// Token: 0x0400272A RID: 10026
	[SerializeField]
	private string color;

	// Token: 0x0400272B RID: 10027
	[SerializeField]
	private string eyes;

	// Token: 0x0400272C RID: 10028
	[SerializeField]
	private string eyeType;

	// Token: 0x0400272D RID: 10029
	[SerializeField]
	private string stockings;

	// Token: 0x0400272E RID: 10030
	[SerializeField]
	private string accessory;

	// Token: 0x0400272F RID: 10031
	[SerializeField]
	private string info;

	// Token: 0x04002730 RID: 10032
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x04002731 RID: 10033
	[SerializeField]
	private bool success;
}
