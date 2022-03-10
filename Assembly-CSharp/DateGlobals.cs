using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001587 RID: 5511 RVA: 0x000DA638 File Offset: 0x000D8838
	// (set) Token: 0x06001588 RID: 5512 RVA: 0x000DA668 File Offset: 0x000D8868
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
	// (get) Token: 0x06001589 RID: 5513 RVA: 0x000DA698 File Offset: 0x000D8898
	// (set) Token: 0x0600158A RID: 5514 RVA: 0x000DA6C8 File Offset: 0x000D88C8
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
	// (get) Token: 0x0600158B RID: 5515 RVA: 0x000DA6F8 File Offset: 0x000D88F8
	// (set) Token: 0x0600158C RID: 5516 RVA: 0x000DA728 File Offset: 0x000D8928
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
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000DA758 File Offset: 0x000D8958
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000DA788 File Offset: 0x000D8988
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
	// (get) Token: 0x0600158F RID: 5519 RVA: 0x000DA7B8 File Offset: 0x000D89B8
	// (set) Token: 0x06001590 RID: 5520 RVA: 0x000DA7E8 File Offset: 0x000D89E8
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
	// (get) Token: 0x06001591 RID: 5521 RVA: 0x000DA818 File Offset: 0x000D8A18
	// (set) Token: 0x06001592 RID: 5522 RVA: 0x000DA848 File Offset: 0x000D8A48
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

	// Token: 0x06001593 RID: 5523 RVA: 0x000DA878 File Offset: 0x000D8A78
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021DC RID: 8668
	private const string Str_Week = "Week";

	// Token: 0x040021DD RID: 8669
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021DE RID: 8670
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021DF RID: 8671
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021E0 RID: 8672
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x040021E1 RID: 8673
	private const string Str_ForceSkip = "ForceSkip";
}
