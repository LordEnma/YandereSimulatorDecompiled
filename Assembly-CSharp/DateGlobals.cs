using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600157E RID: 5502 RVA: 0x000D9A24 File Offset: 0x000D7C24
	// (set) Token: 0x0600157F RID: 5503 RVA: 0x000D9A54 File Offset: 0x000D7C54
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
	// (get) Token: 0x06001580 RID: 5504 RVA: 0x000D9A84 File Offset: 0x000D7C84
	// (set) Token: 0x06001581 RID: 5505 RVA: 0x000D9AB4 File Offset: 0x000D7CB4
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
	// (get) Token: 0x06001582 RID: 5506 RVA: 0x000D9AE4 File Offset: 0x000D7CE4
	// (set) Token: 0x06001583 RID: 5507 RVA: 0x000D9B14 File Offset: 0x000D7D14
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
	// (get) Token: 0x06001584 RID: 5508 RVA: 0x000D9B44 File Offset: 0x000D7D44
	// (set) Token: 0x06001585 RID: 5509 RVA: 0x000D9B74 File Offset: 0x000D7D74
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
	// (get) Token: 0x06001586 RID: 5510 RVA: 0x000D9BA4 File Offset: 0x000D7DA4
	// (set) Token: 0x06001587 RID: 5511 RVA: 0x000D9BD4 File Offset: 0x000D7DD4
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
	// (get) Token: 0x06001588 RID: 5512 RVA: 0x000D9C04 File Offset: 0x000D7E04
	// (set) Token: 0x06001589 RID: 5513 RVA: 0x000D9C34 File Offset: 0x000D7E34
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

	// Token: 0x0600158A RID: 5514 RVA: 0x000D9C64 File Offset: 0x000D7E64
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021B9 RID: 8633
	private const string Str_Week = "Week";

	// Token: 0x040021BA RID: 8634
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021BB RID: 8635
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021BC RID: 8636
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021BD RID: 8637
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x040021BE RID: 8638
	private const string Str_ForceSkip = "ForceSkip";
}
