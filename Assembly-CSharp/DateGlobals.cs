using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DB73C File Offset: 0x000D993C
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DB76C File Offset: 0x000D996C
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DB79C File Offset: 0x000D999C
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DB7CC File Offset: 0x000D99CC
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DB7FC File Offset: 0x000D99FC
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DB82C File Offset: 0x000D9A2C
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
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DB85C File Offset: 0x000D9A5C
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DB88C File Offset: 0x000D9A8C
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
	// (get) Token: 0x060015A4 RID: 5540 RVA: 0x000DB8BC File Offset: 0x000D9ABC
	// (set) Token: 0x060015A5 RID: 5541 RVA: 0x000DB8EC File Offset: 0x000D9AEC
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
	// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000DB91C File Offset: 0x000D9B1C
	// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000DB94C File Offset: 0x000D9B4C
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

	// Token: 0x060015A8 RID: 5544 RVA: 0x000DB97C File Offset: 0x000D9B7C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x04002207 RID: 8711
	private const string Str_Week = "Week";

	// Token: 0x04002208 RID: 8712
	private const string Str_Weekday = "Weekday";

	// Token: 0x04002209 RID: 8713
	private const string Str_PassDays = "PassDays";

	// Token: 0x0400220A RID: 8714
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x0400220B RID: 8715
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x0400220C RID: 8716
	private const string Str_ForceSkip = "ForceSkip";
}
