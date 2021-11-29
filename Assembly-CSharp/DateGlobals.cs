using System;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600156D RID: 5485 RVA: 0x000D8584 File Offset: 0x000D6784
	// (set) Token: 0x0600156E RID: 5486 RVA: 0x000D85B4 File Offset: 0x000D67B4
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
	// (get) Token: 0x0600156F RID: 5487 RVA: 0x000D85E4 File Offset: 0x000D67E4
	// (set) Token: 0x06001570 RID: 5488 RVA: 0x000D8614 File Offset: 0x000D6814
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
	// (get) Token: 0x06001571 RID: 5489 RVA: 0x000D8644 File Offset: 0x000D6844
	// (set) Token: 0x06001572 RID: 5490 RVA: 0x000D8674 File Offset: 0x000D6874
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
	// (get) Token: 0x06001573 RID: 5491 RVA: 0x000D86A4 File Offset: 0x000D68A4
	// (set) Token: 0x06001574 RID: 5492 RVA: 0x000D86D4 File Offset: 0x000D68D4
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
	// (get) Token: 0x06001575 RID: 5493 RVA: 0x000D8704 File Offset: 0x000D6904
	// (set) Token: 0x06001576 RID: 5494 RVA: 0x000D8734 File Offset: 0x000D6934
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

	// Token: 0x06001577 RID: 5495 RVA: 0x000D8764 File Offset: 0x000D6964
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x04002182 RID: 8578
	private const string Str_Week = "Week";

	// Token: 0x04002183 RID: 8579
	private const string Str_Weekday = "Weekday";

	// Token: 0x04002184 RID: 8580
	private const string Str_PassDays = "PassDays";

	// Token: 0x04002185 RID: 8581
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x04002186 RID: 8582
	private const string Str_GameplayDay = "GameplayDay";
}
