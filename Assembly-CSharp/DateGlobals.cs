using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000DB2A0 File Offset: 0x000D94A0
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000DB2D0 File Offset: 0x000D94D0
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
	// (get) Token: 0x0600159A RID: 5530 RVA: 0x000DB300 File Offset: 0x000D9500
	// (set) Token: 0x0600159B RID: 5531 RVA: 0x000DB330 File Offset: 0x000D9530
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
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DB360 File Offset: 0x000D9560
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DB390 File Offset: 0x000D9590
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DB3C0 File Offset: 0x000D95C0
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DB3F0 File Offset: 0x000D95F0
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DB420 File Offset: 0x000D9620
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DB450 File Offset: 0x000D9650
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
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DB480 File Offset: 0x000D9680
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DB4B0 File Offset: 0x000D96B0
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

	// Token: 0x060015A4 RID: 5540 RVA: 0x000DB4E0 File Offset: 0x000D96E0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021FE RID: 8702
	private const string Str_Week = "Week";

	// Token: 0x040021FF RID: 8703
	private const string Str_Weekday = "Weekday";

	// Token: 0x04002200 RID: 8704
	private const string Str_PassDays = "PassDays";

	// Token: 0x04002201 RID: 8705
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x04002202 RID: 8706
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x04002203 RID: 8707
	private const string Str_ForceSkip = "ForceSkip";
}
