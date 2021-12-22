using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001574 RID: 5492 RVA: 0x000D8D44 File Offset: 0x000D6F44
	// (set) Token: 0x06001575 RID: 5493 RVA: 0x000D8D74 File Offset: 0x000D6F74
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
	// (get) Token: 0x06001576 RID: 5494 RVA: 0x000D8DA4 File Offset: 0x000D6FA4
	// (set) Token: 0x06001577 RID: 5495 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
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
	// (get) Token: 0x06001578 RID: 5496 RVA: 0x000D8E04 File Offset: 0x000D7004
	// (set) Token: 0x06001579 RID: 5497 RVA: 0x000D8E34 File Offset: 0x000D7034
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
	// (get) Token: 0x0600157A RID: 5498 RVA: 0x000D8E64 File Offset: 0x000D7064
	// (set) Token: 0x0600157B RID: 5499 RVA: 0x000D8E94 File Offset: 0x000D7094
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
	// (get) Token: 0x0600157C RID: 5500 RVA: 0x000D8EC4 File Offset: 0x000D70C4
	// (set) Token: 0x0600157D RID: 5501 RVA: 0x000D8EF4 File Offset: 0x000D70F4
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

	// Token: 0x0600157E RID: 5502 RVA: 0x000D8F24 File Offset: 0x000D7124
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x040021A2 RID: 8610
	private const string Str_Week = "Week";

	// Token: 0x040021A3 RID: 8611
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021A4 RID: 8612
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021A5 RID: 8613
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021A6 RID: 8614
	private const string Str_GameplayDay = "GameplayDay";
}
