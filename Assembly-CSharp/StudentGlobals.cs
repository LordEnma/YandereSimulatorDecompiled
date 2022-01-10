using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class StudentGlobals
{
	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000DF87C File Offset: 0x000DDA7C
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000DF8AC File Offset: 0x000DDAAC
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

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x000DF8DC File Offset: 0x000DDADC
	// (set) Token: 0x06001727 RID: 5927 RVA: 0x000DF90C File Offset: 0x000DDB0C
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

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000DF93C File Offset: 0x000DDB3C
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000DF96C File Offset: 0x000DDB6C
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

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000DF99C File Offset: 0x000DDB9C
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000DF9CC File Offset: 0x000DDBCC
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

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000DF9FC File Offset: 0x000DDBFC
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000DFA2C File Offset: 0x000DDC2C
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

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000DFA5C File Offset: 0x000DDC5C
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000DFA8C File Offset: 0x000DDC8C
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

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000DFABC File Offset: 0x000DDCBC
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000DFAEC File Offset: 0x000DDCEC
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

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000DFB1C File Offset: 0x000DDD1C
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000DFB4C File Offset: 0x000DDD4C
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

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000DFB7C File Offset: 0x000DDD7C
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000DFBAC File Offset: 0x000DDDAC
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

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000DFBDC File Offset: 0x000DDDDC
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000DFC0C File Offset: 0x000DDE0C
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

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000DFC3C File Offset: 0x000DDE3C
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000DFC6C File Offset: 0x000DDE6C
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

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000DFC9C File Offset: 0x000DDE9C
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000DFCCC File Offset: 0x000DDECC
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

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000DFCFC File Offset: 0x000DDEFC
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000DFD2C File Offset: 0x000DDF2C
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

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x0600173E RID: 5950 RVA: 0x000DFD5C File Offset: 0x000DDF5C
	// (set) Token: 0x0600173F RID: 5951 RVA: 0x000DFD8C File Offset: 0x000DDF8C
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

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06001740 RID: 5952 RVA: 0x000DFDBC File Offset: 0x000DDFBC
	// (set) Token: 0x06001741 RID: 5953 RVA: 0x000DFDEC File Offset: 0x000DDFEC
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

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06001742 RID: 5954 RVA: 0x000DFE1C File Offset: 0x000DE01C
	// (set) Token: 0x06001743 RID: 5955 RVA: 0x000DFE4C File Offset: 0x000DE04C
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

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06001744 RID: 5956 RVA: 0x000DFE7C File Offset: 0x000DE07C
	// (set) Token: 0x06001745 RID: 5957 RVA: 0x000DFEAC File Offset: 0x000DE0AC
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

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06001746 RID: 5958 RVA: 0x000DFEDC File Offset: 0x000DE0DC
	// (set) Token: 0x06001747 RID: 5959 RVA: 0x000DFF0C File Offset: 0x000DE10C
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

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06001748 RID: 5960 RVA: 0x000DFF3C File Offset: 0x000DE13C
	// (set) Token: 0x06001749 RID: 5961 RVA: 0x000DFF6C File Offset: 0x000DE16C
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

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x0600174A RID: 5962 RVA: 0x000DFF9C File Offset: 0x000DE19C
	// (set) Token: 0x0600174B RID: 5963 RVA: 0x000DFFCC File Offset: 0x000DE1CC
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

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x0600174C RID: 5964 RVA: 0x000DFFFC File Offset: 0x000DE1FC
	// (set) Token: 0x0600174D RID: 5965 RVA: 0x000E002C File Offset: 0x000DE22C
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

	// Token: 0x0600174E RID: 5966 RVA: 0x000E005C File Offset: 0x000DE25C
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x000E0094 File Offset: 0x000DE294
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x000E00F0 File Offset: 0x000DE2F0
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x06001751 RID: 5969 RVA: 0x000E0120 File Offset: 0x000DE320
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x06001752 RID: 5970 RVA: 0x000E0158 File Offset: 0x000DE358
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x000E01B4 File Offset: 0x000DE3B4
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x000E01E4 File Offset: 0x000DE3E4
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x000E021C File Offset: 0x000DE41C
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x000E0278 File Offset: 0x000DE478
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x000E02A8 File Offset: 0x000DE4A8
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000E02E0 File Offset: 0x000DE4E0
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000E033C File Offset: 0x000DE53C
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000E036C File Offset: 0x000DE56C
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x000E03A4 File Offset: 0x000DE5A4
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x000E0400 File Offset: 0x000DE600
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x000E0430 File Offset: 0x000DE630
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x000E0468 File Offset: 0x000DE668
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x000E04C4 File Offset: 0x000DE6C4
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x000E04F4 File Offset: 0x000DE6F4
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x000E052C File Offset: 0x000DE72C
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000E0588 File Offset: 0x000DE788
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000E05B8 File Offset: 0x000DE7B8
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000E05F0 File Offset: 0x000DE7F0
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000E064C File Offset: 0x000DE84C
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000E067C File Offset: 0x000DE87C
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000E06B4 File Offset: 0x000DE8B4
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000E0710 File Offset: 0x000DE910
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000E0740 File Offset: 0x000DE940
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000E0778 File Offset: 0x000DE978
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000E07D4 File Offset: 0x000DE9D4
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000E0804 File Offset: 0x000DEA04
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000E083C File Offset: 0x000DEA3C
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000E0898 File Offset: 0x000DEA98
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000E08C8 File Offset: 0x000DEAC8
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000E0900 File Offset: 0x000DEB00
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000E095C File Offset: 0x000DEB5C
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x000E098C File Offset: 0x000DEB8C
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000E09C4 File Offset: 0x000DEBC4
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000E0A20 File Offset: 0x000DEC20
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000E0A50 File Offset: 0x000DEC50
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x06001776 RID: 6006 RVA: 0x000E0A88 File Offset: 0x000DEC88
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000E0AE4 File Offset: 0x000DECE4
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000E0B14 File Offset: 0x000DED14
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x06001779 RID: 6009 RVA: 0x000E0B4C File Offset: 0x000DED4C
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x0600177A RID: 6010 RVA: 0x000E0BA8 File Offset: 0x000DEDA8
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x0600177B RID: 6011 RVA: 0x000E0BD8 File Offset: 0x000DEDD8
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E0C10 File Offset: 0x000DEE10
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000E0C6C File Offset: 0x000DEE6C
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x0600177E RID: 6014 RVA: 0x000E0C9C File Offset: 0x000DEE9C
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000E0CD4 File Offset: 0x000DEED4
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000E0D30 File Offset: 0x000DEF30
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000E0D60 File Offset: 0x000DEF60
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000E0D98 File Offset: 0x000DEF98
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000E0DF4 File Offset: 0x000DEFF4
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x000E0E24 File Offset: 0x000DF024
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x06001785 RID: 6021 RVA: 0x000E0E5C File Offset: 0x000DF05C
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000E0EB8 File Offset: 0x000DF0B8
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000E0EE8 File Offset: 0x000DF0E8
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x000E0F20 File Offset: 0x000DF120
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x06001789 RID: 6025 RVA: 0x000E0F7C File Offset: 0x000DF17C
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x0600178A RID: 6026 RVA: 0x000E0FAC File Offset: 0x000DF1AC
	// (set) Token: 0x0600178B RID: 6027 RVA: 0x000E0FDC File Offset: 0x000DF1DC
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

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x0600178C RID: 6028 RVA: 0x000E100C File Offset: 0x000DF20C
	// (set) Token: 0x0600178D RID: 6029 RVA: 0x000E103C File Offset: 0x000DF23C
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

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x0600178E RID: 6030 RVA: 0x000E106C File Offset: 0x000DF26C
	// (set) Token: 0x0600178F RID: 6031 RVA: 0x000E109C File Offset: 0x000DF29C
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

	// Token: 0x06001790 RID: 6032 RVA: 0x000E10CC File Offset: 0x000DF2CC
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

	// Token: 0x06001791 RID: 6033 RVA: 0x000E111C File Offset: 0x000DF31C
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

	// Token: 0x06001792 RID: 6034 RVA: 0x000E116C File Offset: 0x000DF36C
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x06001793 RID: 6035 RVA: 0x000E11A4 File Offset: 0x000DF3A4
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x06001794 RID: 6036 RVA: 0x000E1200 File Offset: 0x000DF400
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x06001795 RID: 6037 RVA: 0x000E1230 File Offset: 0x000DF430
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

	// Token: 0x0400226C RID: 8812
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x0400226D RID: 8813
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x0400226E RID: 8814
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x0400226F RID: 8815
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x04002270 RID: 8816
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x04002271 RID: 8817
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x04002272 RID: 8818
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x04002273 RID: 8819
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x04002274 RID: 8820
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x04002275 RID: 8821
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x04002276 RID: 8822
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x04002277 RID: 8823
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x04002278 RID: 8824
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x04002279 RID: 8825
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x0400227A RID: 8826
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x0400227B RID: 8827
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x0400227C RID: 8828
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x0400227D RID: 8829
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x0400227E RID: 8830
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x0400227F RID: 8831
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x04002280 RID: 8832
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x04002281 RID: 8833
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x04002282 RID: 8834
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x04002283 RID: 8835
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x04002284 RID: 8836
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x04002285 RID: 8837
	private const string Str_StudentName = "StudentName_";

	// Token: 0x04002286 RID: 8838
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x04002287 RID: 8839
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x04002288 RID: 8840
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x04002289 RID: 8841
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x0400228A RID: 8842
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x0400228B RID: 8843
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x0400228C RID: 8844
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x0400228D RID: 8845
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x0400228E RID: 8846
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x0400228F RID: 8847
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x04002290 RID: 8848
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x04002291 RID: 8849
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x04002292 RID: 8850
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x04002293 RID: 8851
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x04002294 RID: 8852
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x04002295 RID: 8853
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x04002296 RID: 8854
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x04002297 RID: 8855
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x04002298 RID: 8856
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x04002299 RID: 8857
	private const string Str_MemorialStudent9 = "MemorialStudent9";
}
