using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DBA40 File Offset: 0x000D9C40
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DBA70 File Offset: 0x000D9C70
	public static int Week
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week", value);
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DBAA0 File Offset: 0x000D9CA0
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DBAD0 File Offset: 0x000D9CD0
	public static DayOfWeek Weekday
	{
		get
		{
			return GlobalsHelper.GetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		}
		set
		{
			GlobalsHelper.SetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday", value);
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DBB00 File Offset: 0x000D9D00
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DBB30 File Offset: 0x000D9D30
	public static int PassDays
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays", value);
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x060015A4 RID: 5540 RVA: 0x000DBB60 File Offset: 0x000D9D60
	// (set) Token: 0x060015A5 RID: 5541 RVA: 0x000DBB90 File Offset: 0x000D9D90
	public static bool DayPassed
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed", value);
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000DBBC0 File Offset: 0x000D9DC0
	// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000DBBF0 File Offset: 0x000D9DF0
	public static int GameplayDay
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay", value);
		}
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x060015A8 RID: 5544 RVA: 0x000DBC20 File Offset: 0x000D9E20
	// (set) Token: 0x060015A9 RID: 5545 RVA: 0x000DBC50 File Offset: 0x000D9E50
	public static bool ForceSkip
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip", value);
		}
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x000DBC80 File Offset: 0x000D9E80
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x04002210 RID: 8720
	private const string Str_Week = "Week";

	// Token: 0x04002211 RID: 8721
	private const string Str_Weekday = "Weekday";

	// Token: 0x04002212 RID: 8722
	private const string Str_PassDays = "PassDays";

	// Token: 0x04002213 RID: 8723
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x04002214 RID: 8724
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x04002215 RID: 8725
	private const string Str_ForceSkip = "ForceSkip";
}
