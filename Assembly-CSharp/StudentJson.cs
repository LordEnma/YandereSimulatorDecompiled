using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000340 RID: 832
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x060018EE RID: 6382 RVA: 0x000F997F File Offset: 0x000F7B7F
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

	// Token: 0x060018EF RID: 6383 RVA: 0x000F99A8 File Offset: 0x000F7BA8
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
	// (get) Token: 0x060018F0 RID: 6384 RVA: 0x000F9C20 File Offset: 0x000F7E20
	// (set) Token: 0x060018F1 RID: 6385 RVA: 0x000F9C28 File Offset: 0x000F7E28
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
	// (get) Token: 0x060018F2 RID: 6386 RVA: 0x000F9C31 File Offset: 0x000F7E31
	// (set) Token: 0x060018F3 RID: 6387 RVA: 0x000F9C39 File Offset: 0x000F7E39
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
	// (get) Token: 0x060018F4 RID: 6388 RVA: 0x000F9C42 File Offset: 0x000F7E42
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x060018F5 RID: 6389 RVA: 0x000F9C4A File Offset: 0x000F7E4A
	// (set) Token: 0x060018F6 RID: 6390 RVA: 0x000F9C52 File Offset: 0x000F7E52
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
	// (get) Token: 0x060018F7 RID: 6391 RVA: 0x000F9C5B File Offset: 0x000F7E5B
	// (set) Token: 0x060018F8 RID: 6392 RVA: 0x000F9C63 File Offset: 0x000F7E63
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
	// (get) Token: 0x060018F9 RID: 6393 RVA: 0x000F9C6C File Offset: 0x000F7E6C
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x060018FA RID: 6394 RVA: 0x000F9C74 File Offset: 0x000F7E74
	// (set) Token: 0x060018FB RID: 6395 RVA: 0x000F9C7C File Offset: 0x000F7E7C
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
	// (get) Token: 0x060018FC RID: 6396 RVA: 0x000F9C85 File Offset: 0x000F7E85
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x060018FD RID: 6397 RVA: 0x000F9C8D File Offset: 0x000F7E8D
	// (set) Token: 0x060018FE RID: 6398 RVA: 0x000F9C95 File Offset: 0x000F7E95
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
	// (get) Token: 0x060018FF RID: 6399 RVA: 0x000F9C9E File Offset: 0x000F7E9E
	// (set) Token: 0x06001900 RID: 6400 RVA: 0x000F9CA6 File Offset: 0x000F7EA6
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
	// (get) Token: 0x06001901 RID: 6401 RVA: 0x000F9CAF File Offset: 0x000F7EAF
	// (set) Token: 0x06001902 RID: 6402 RVA: 0x000F9CB7 File Offset: 0x000F7EB7
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
	// (get) Token: 0x06001903 RID: 6403 RVA: 0x000F9CC0 File Offset: 0x000F7EC0
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06001904 RID: 6404 RVA: 0x000F9CC8 File Offset: 0x000F7EC8
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001905 RID: 6405 RVA: 0x000F9CD0 File Offset: 0x000F7ED0
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001906 RID: 6406 RVA: 0x000F9CD8 File Offset: 0x000F7ED8
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001907 RID: 6407 RVA: 0x000F9CE0 File Offset: 0x000F7EE0
	// (set) Token: 0x06001908 RID: 6408 RVA: 0x000F9CE8 File Offset: 0x000F7EE8
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
	// (get) Token: 0x06001909 RID: 6409 RVA: 0x000F9CF1 File Offset: 0x000F7EF1
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x0600190A RID: 6410 RVA: 0x000F9CF9 File Offset: 0x000F7EF9
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x000F9D01 File Offset: 0x000F7F01
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x000F9D0C File Offset: 0x000F7F0C
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

	// Token: 0x0600190D RID: 6413 RVA: 0x000F9D5D File Offset: 0x000F7F5D
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x040026FA RID: 9978
	[SerializeField]
	private string name;

	// Token: 0x040026FB RID: 9979
	[SerializeField]
	private string realname;

	// Token: 0x040026FC RID: 9980
	[SerializeField]
	private int gender;

	// Token: 0x040026FD RID: 9981
	[SerializeField]
	private int classID;

	// Token: 0x040026FE RID: 9982
	[SerializeField]
	private int seat;

	// Token: 0x040026FF RID: 9983
	[SerializeField]
	private ClubType club;

	// Token: 0x04002700 RID: 9984
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002701 RID: 9985
	[SerializeField]
	private int crush;

	// Token: 0x04002702 RID: 9986
	[SerializeField]
	private float breastSize;

	// Token: 0x04002703 RID: 9987
	[SerializeField]
	private int strength;

	// Token: 0x04002704 RID: 9988
	[SerializeField]
	private string hairstyle;

	// Token: 0x04002705 RID: 9989
	[SerializeField]
	private string color;

	// Token: 0x04002706 RID: 9990
	[SerializeField]
	private string eyes;

	// Token: 0x04002707 RID: 9991
	[SerializeField]
	private string eyeType;

	// Token: 0x04002708 RID: 9992
	[SerializeField]
	private string stockings;

	// Token: 0x04002709 RID: 9993
	[SerializeField]
	private string accessory;

	// Token: 0x0400270A RID: 9994
	[SerializeField]
	private string info;

	// Token: 0x0400270B RID: 9995
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x0400270C RID: 9996
	[SerializeField]
	private bool success;
}
