using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class StudentGlobals
{
	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06001752 RID: 5970 RVA: 0x000E22E8 File Offset: 0x000E04E8
	// (set) Token: 0x06001753 RID: 5971 RVA: 0x000E2318 File Offset: 0x000E0518
	public static bool CustomSuitor
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor", value);
		}
	}

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x06001754 RID: 5972 RVA: 0x000E2348 File Offset: 0x000E0548
	// (set) Token: 0x06001755 RID: 5973 RVA: 0x000E2378 File Offset: 0x000E0578
	public static int CustomSuitorAccessory
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory", value);
		}
	}

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06001756 RID: 5974 RVA: 0x000E23A8 File Offset: 0x000E05A8
	// (set) Token: 0x06001757 RID: 5975 RVA: 0x000E23D8 File Offset: 0x000E05D8
	public static bool CustomSuitorBlonde
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde", value);
		}
	}

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06001758 RID: 5976 RVA: 0x000E2408 File Offset: 0x000E0608
	// (set) Token: 0x06001759 RID: 5977 RVA: 0x000E2438 File Offset: 0x000E0638
	public static bool CustomSuitorBlack
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack", value);
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x0600175A RID: 5978 RVA: 0x000E2468 File Offset: 0x000E0668
	// (set) Token: 0x0600175B RID: 5979 RVA: 0x000E2498 File Offset: 0x000E0698
	public static int CustomSuitorEyewear
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear", value);
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x0600175C RID: 5980 RVA: 0x000E24C8 File Offset: 0x000E06C8
	// (set) Token: 0x0600175D RID: 5981 RVA: 0x000E24F8 File Offset: 0x000E06F8
	public static int CustomSuitorHair
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair", value);
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x0600175E RID: 5982 RVA: 0x000E2528 File Offset: 0x000E0728
	// (set) Token: 0x0600175F RID: 5983 RVA: 0x000E2558 File Offset: 0x000E0758
	public static int CustomSuitorJewelry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry", value);
		}
	}

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06001760 RID: 5984 RVA: 0x000E2588 File Offset: 0x000E0788
	// (set) Token: 0x06001761 RID: 5985 RVA: 0x000E25B8 File Offset: 0x000E07B8
	public static bool CustomSuitorTan
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan", value);
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06001762 RID: 5986 RVA: 0x000E25E8 File Offset: 0x000E07E8
	// (set) Token: 0x06001763 RID: 5987 RVA: 0x000E2618 File Offset: 0x000E0818
	public static int ExpelProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress", value);
		}
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06001764 RID: 5988 RVA: 0x000E2648 File Offset: 0x000E0848
	// (set) Token: 0x06001765 RID: 5989 RVA: 0x000E2678 File Offset: 0x000E0878
	public static int FemaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform", value);
		}
	}

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06001766 RID: 5990 RVA: 0x000E26A8 File Offset: 0x000E08A8
	// (set) Token: 0x06001767 RID: 5991 RVA: 0x000E26D8 File Offset: 0x000E08D8
	public static int MaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform", value);
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06001768 RID: 5992 RVA: 0x000E2708 File Offset: 0x000E0908
	// (set) Token: 0x06001769 RID: 5993 RVA: 0x000E2738 File Offset: 0x000E0938
	public static int MemorialStudents
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents", value);
		}
	}

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x0600176A RID: 5994 RVA: 0x000E2768 File Offset: 0x000E0968
	// (set) Token: 0x0600176B RID: 5995 RVA: 0x000E2798 File Offset: 0x000E0998
	public static int MemorialStudent1
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1", value);
		}
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x0600176C RID: 5996 RVA: 0x000E27C8 File Offset: 0x000E09C8
	// (set) Token: 0x0600176D RID: 5997 RVA: 0x000E27F8 File Offset: 0x000E09F8
	public static int MemorialStudent2
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2", value);
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x0600176E RID: 5998 RVA: 0x000E2828 File Offset: 0x000E0A28
	// (set) Token: 0x0600176F RID: 5999 RVA: 0x000E2858 File Offset: 0x000E0A58
	public static int MemorialStudent3
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3", value);
		}
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06001770 RID: 6000 RVA: 0x000E2888 File Offset: 0x000E0A88
	// (set) Token: 0x06001771 RID: 6001 RVA: 0x000E28B8 File Offset: 0x000E0AB8
	public static int MemorialStudent4
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4", value);
		}
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x06001772 RID: 6002 RVA: 0x000E28E8 File Offset: 0x000E0AE8
	// (set) Token: 0x06001773 RID: 6003 RVA: 0x000E2918 File Offset: 0x000E0B18
	public static int MemorialStudent5
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5", value);
		}
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06001774 RID: 6004 RVA: 0x000E2948 File Offset: 0x000E0B48
	// (set) Token: 0x06001775 RID: 6005 RVA: 0x000E2978 File Offset: 0x000E0B78
	public static int MemorialStudent6
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6", value);
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06001776 RID: 6006 RVA: 0x000E29A8 File Offset: 0x000E0BA8
	// (set) Token: 0x06001777 RID: 6007 RVA: 0x000E29D8 File Offset: 0x000E0BD8
	public static int MemorialStudent7
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7", value);
		}
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06001778 RID: 6008 RVA: 0x000E2A08 File Offset: 0x000E0C08
	// (set) Token: 0x06001779 RID: 6009 RVA: 0x000E2A38 File Offset: 0x000E0C38
	public static int MemorialStudent8
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8", value);
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x0600177A RID: 6010 RVA: 0x000E2A68 File Offset: 0x000E0C68
	// (set) Token: 0x0600177B RID: 6011 RVA: 0x000E2A98 File Offset: 0x000E0C98
	public static int MemorialStudent9
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9", value);
		}
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E2AC8 File Offset: 0x000E0CC8
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000E2B00 File Offset: 0x000E0D00
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x0600177E RID: 6014 RVA: 0x000E2B5C File Offset: 0x000E0D5C
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000E2B8C File Offset: 0x000E0D8C
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000E2BC4 File Offset: 0x000E0DC4
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000E2C20 File Offset: 0x000E0E20
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000E2C50 File Offset: 0x000E0E50
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000E2C88 File Offset: 0x000E0E88
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x000E2CE4 File Offset: 0x000E0EE4
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x06001785 RID: 6021 RVA: 0x000E2D14 File Offset: 0x000E0F14
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000E2D4C File Offset: 0x000E0F4C
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000E2DA8 File Offset: 0x000E0FA8
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x000E2DD8 File Offset: 0x000E0FD8
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x06001789 RID: 6025 RVA: 0x000E2E10 File Offset: 0x000E1010
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x0600178A RID: 6026 RVA: 0x000E2E6C File Offset: 0x000E106C
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x0600178B RID: 6027 RVA: 0x000E2E9C File Offset: 0x000E109C
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x000E2ED4 File Offset: 0x000E10D4
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x000E2F30 File Offset: 0x000E1130
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x0600178E RID: 6030 RVA: 0x000E2F60 File Offset: 0x000E1160
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x000E2F98 File Offset: 0x000E1198
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x06001790 RID: 6032 RVA: 0x000E2FF4 File Offset: 0x000E11F4
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x06001791 RID: 6033 RVA: 0x000E3024 File Offset: 0x000E1224
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x06001792 RID: 6034 RVA: 0x000E305C File Offset: 0x000E125C
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x06001793 RID: 6035 RVA: 0x000E30B8 File Offset: 0x000E12B8
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001794 RID: 6036 RVA: 0x000E30E8 File Offset: 0x000E12E8
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x06001795 RID: 6037 RVA: 0x000E3120 File Offset: 0x000E1320
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x06001796 RID: 6038 RVA: 0x000E317C File Offset: 0x000E137C
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x06001797 RID: 6039 RVA: 0x000E31AC File Offset: 0x000E13AC
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x06001798 RID: 6040 RVA: 0x000E31E4 File Offset: 0x000E13E4
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x000E3240 File Offset: 0x000E1440
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x0600179A RID: 6042 RVA: 0x000E3270 File Offset: 0x000E1470
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x0600179B RID: 6043 RVA: 0x000E32A8 File Offset: 0x000E14A8
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x000E3304 File Offset: 0x000E1504
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x0600179D RID: 6045 RVA: 0x000E3334 File Offset: 0x000E1534
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x0600179E RID: 6046 RVA: 0x000E336C File Offset: 0x000E156C
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x0600179F RID: 6047 RVA: 0x000E33C8 File Offset: 0x000E15C8
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x060017A0 RID: 6048 RVA: 0x000E33F8 File Offset: 0x000E15F8
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x000E3430 File Offset: 0x000E1630
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x060017A2 RID: 6050 RVA: 0x000E348C File Offset: 0x000E168C
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x060017A3 RID: 6051 RVA: 0x000E34BC File Offset: 0x000E16BC
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x060017A4 RID: 6052 RVA: 0x000E34F4 File Offset: 0x000E16F4
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x000E3550 File Offset: 0x000E1750
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x000E3580 File Offset: 0x000E1780
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x000E35B8 File Offset: 0x000E17B8
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x060017A8 RID: 6056 RVA: 0x000E3614 File Offset: 0x000E1814
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x060017A9 RID: 6057 RVA: 0x000E3644 File Offset: 0x000E1844
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x000E367C File Offset: 0x000E187C
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x060017AB RID: 6059 RVA: 0x000E36D8 File Offset: 0x000E18D8
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000E3708 File Offset: 0x000E1908
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x000E3740 File Offset: 0x000E1940
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x000E379C File Offset: 0x000E199C
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x060017AF RID: 6063 RVA: 0x000E37CC File Offset: 0x000E19CC
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x000E3804 File Offset: 0x000E1A04
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x000E3860 File Offset: 0x000E1A60
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x000E3890 File Offset: 0x000E1A90
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x000E38C8 File Offset: 0x000E1AC8
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x000E3924 File Offset: 0x000E1B24
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x000E3954 File Offset: 0x000E1B54
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x000E398C File Offset: 0x000E1B8C
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x060017B7 RID: 6071 RVA: 0x000E39E8 File Offset: 0x000E1BE8
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E3A18 File Offset: 0x000E1C18
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E3A48 File Offset: 0x000E1C48
	public static int StudentSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave", value);
		}
	}

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017BA RID: 6074 RVA: 0x000E3A78 File Offset: 0x000E1C78
	// (set) Token: 0x060017BB RID: 6075 RVA: 0x000E3AA8 File Offset: 0x000E1CA8
	public static int FragileSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave", value);
		}
	}

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017BC RID: 6076 RVA: 0x000E3AD8 File Offset: 0x000E1CD8
	// (set) Token: 0x060017BD RID: 6077 RVA: 0x000E3B08 File Offset: 0x000E1D08
	public static int FragileTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget", value);
		}
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x000E3B38 File Offset: 0x000E1D38
	public static Vector3 GetReputationTriangle(int studentID)
	{
		return GlobalsHelper.GetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}));
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x000E3B88 File Offset: 0x000E1D88
	public static void SetReputationTriangle(int studentID, Vector3 triangle)
	{
		GlobalsHelper.SetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}), triangle);
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x000E3BD8 File Offset: 0x000E1DD8
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x000E3C10 File Offset: 0x000E1E10
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x000E3C6C File Offset: 0x000E1E6C
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E3C9C File Offset: 0x000E1E9C
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E3CCC File Offset: 0x000E1ECC
	public static bool UpdateRivalReputation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation", value);
		}
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000E3CFC File Offset: 0x000E1EFC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_UpdateRivalReputation");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", StudentGlobals.KeysOfStudentArrested());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", StudentGlobals.KeysOfStudentBroken());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", StudentGlobals.KeysOfStudentColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", StudentGlobals.KeysOfStudentDead());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", StudentGlobals.KeysOfStudentDying());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", StudentGlobals.KeysOfStudentExposed());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", StudentGlobals.KeysOfStudentMissing());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", StudentGlobals.KeysOfStudentName());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", StudentGlobals.KeysOfStudentPhoneStolen());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", StudentGlobals.KeysOfStudentReputation());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", StudentGlobals.KeysOfStudentSanity());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", StudentGlobals.KeysOfStudentRansomed());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
	}

	// Token: 0x040022D8 RID: 8920
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x040022D9 RID: 8921
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x040022DA RID: 8922
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x040022DB RID: 8923
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x040022DC RID: 8924
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x040022DD RID: 8925
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x040022DE RID: 8926
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x040022DF RID: 8927
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x040022E0 RID: 8928
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x040022E1 RID: 8929
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x040022E2 RID: 8930
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x040022E3 RID: 8931
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x040022E4 RID: 8932
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x040022E5 RID: 8933
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x040022E6 RID: 8934
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x040022E7 RID: 8935
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x040022E8 RID: 8936
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x040022E9 RID: 8937
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x040022EA RID: 8938
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x040022EB RID: 8939
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x040022EC RID: 8940
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x040022ED RID: 8941
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x040022EE RID: 8942
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x040022EF RID: 8943
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x040022F0 RID: 8944
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x040022F1 RID: 8945
	private const string Str_StudentName = "StudentName_";

	// Token: 0x040022F2 RID: 8946
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x040022F3 RID: 8947
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x040022F4 RID: 8948
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x040022F5 RID: 8949
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x040022F6 RID: 8950
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x040022F7 RID: 8951
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x040022F8 RID: 8952
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x040022F9 RID: 8953
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x040022FA RID: 8954
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x040022FB RID: 8955
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x040022FC RID: 8956
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x040022FD RID: 8957
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x040022FE RID: 8958
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x040022FF RID: 8959
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x04002300 RID: 8960
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x04002301 RID: 8961
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x04002302 RID: 8962
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x04002303 RID: 8963
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x04002304 RID: 8964
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x04002305 RID: 8965
	private const string Str_MemorialStudent9 = "MemorialStudent9";

	// Token: 0x04002306 RID: 8966
	private const string Str_UpdateRivalReputation = "UpdateRivalReputation";
}
