using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class StudentGlobals
{
	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06001737 RID: 5943 RVA: 0x000E0CB0 File Offset: 0x000DEEB0
	// (set) Token: 0x06001738 RID: 5944 RVA: 0x000E0CE0 File Offset: 0x000DEEE0
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

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x06001739 RID: 5945 RVA: 0x000E0D10 File Offset: 0x000DEF10
	// (set) Token: 0x0600173A RID: 5946 RVA: 0x000E0D40 File Offset: 0x000DEF40
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

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x0600173B RID: 5947 RVA: 0x000E0D70 File Offset: 0x000DEF70
	// (set) Token: 0x0600173C RID: 5948 RVA: 0x000E0DA0 File Offset: 0x000DEFA0
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

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x0600173D RID: 5949 RVA: 0x000E0DD0 File Offset: 0x000DEFD0
	// (set) Token: 0x0600173E RID: 5950 RVA: 0x000E0E00 File Offset: 0x000DF000
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

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E0E30 File Offset: 0x000DF030
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E0E60 File Offset: 0x000DF060
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

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06001741 RID: 5953 RVA: 0x000E0E90 File Offset: 0x000DF090
	// (set) Token: 0x06001742 RID: 5954 RVA: 0x000E0EC0 File Offset: 0x000DF0C0
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

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E0EF0 File Offset: 0x000DF0F0
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E0F20 File Offset: 0x000DF120
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

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E0F50 File Offset: 0x000DF150
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E0F80 File Offset: 0x000DF180
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

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06001747 RID: 5959 RVA: 0x000E0FB0 File Offset: 0x000DF1B0
	// (set) Token: 0x06001748 RID: 5960 RVA: 0x000E0FE0 File Offset: 0x000DF1E0
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

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06001749 RID: 5961 RVA: 0x000E1010 File Offset: 0x000DF210
	// (set) Token: 0x0600174A RID: 5962 RVA: 0x000E1040 File Offset: 0x000DF240
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

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x0600174B RID: 5963 RVA: 0x000E1070 File Offset: 0x000DF270
	// (set) Token: 0x0600174C RID: 5964 RVA: 0x000E10A0 File Offset: 0x000DF2A0
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

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x0600174D RID: 5965 RVA: 0x000E10D0 File Offset: 0x000DF2D0
	// (set) Token: 0x0600174E RID: 5966 RVA: 0x000E1100 File Offset: 0x000DF300
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

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x0600174F RID: 5967 RVA: 0x000E1130 File Offset: 0x000DF330
	// (set) Token: 0x06001750 RID: 5968 RVA: 0x000E1160 File Offset: 0x000DF360
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

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06001751 RID: 5969 RVA: 0x000E1190 File Offset: 0x000DF390
	// (set) Token: 0x06001752 RID: 5970 RVA: 0x000E11C0 File Offset: 0x000DF3C0
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

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06001753 RID: 5971 RVA: 0x000E11F0 File Offset: 0x000DF3F0
	// (set) Token: 0x06001754 RID: 5972 RVA: 0x000E1220 File Offset: 0x000DF420
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

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06001755 RID: 5973 RVA: 0x000E1250 File Offset: 0x000DF450
	// (set) Token: 0x06001756 RID: 5974 RVA: 0x000E1280 File Offset: 0x000DF480
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

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06001757 RID: 5975 RVA: 0x000E12B0 File Offset: 0x000DF4B0
	// (set) Token: 0x06001758 RID: 5976 RVA: 0x000E12E0 File Offset: 0x000DF4E0
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

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06001759 RID: 5977 RVA: 0x000E1310 File Offset: 0x000DF510
	// (set) Token: 0x0600175A RID: 5978 RVA: 0x000E1340 File Offset: 0x000DF540
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

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x0600175B RID: 5979 RVA: 0x000E1370 File Offset: 0x000DF570
	// (set) Token: 0x0600175C RID: 5980 RVA: 0x000E13A0 File Offset: 0x000DF5A0
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

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x0600175D RID: 5981 RVA: 0x000E13D0 File Offset: 0x000DF5D0
	// (set) Token: 0x0600175E RID: 5982 RVA: 0x000E1400 File Offset: 0x000DF600
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

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x0600175F RID: 5983 RVA: 0x000E1430 File Offset: 0x000DF630
	// (set) Token: 0x06001760 RID: 5984 RVA: 0x000E1460 File Offset: 0x000DF660
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

	// Token: 0x06001761 RID: 5985 RVA: 0x000E1490 File Offset: 0x000DF690
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000E14C8 File Offset: 0x000DF6C8
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000E1524 File Offset: 0x000DF724
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000E1554 File Offset: 0x000DF754
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000E158C File Offset: 0x000DF78C
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000E15E8 File Offset: 0x000DF7E8
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000E1618 File Offset: 0x000DF818
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000E1650 File Offset: 0x000DF850
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000E16AC File Offset: 0x000DF8AC
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000E16DC File Offset: 0x000DF8DC
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000E1714 File Offset: 0x000DF914
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000E1770 File Offset: 0x000DF970
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000E17A0 File Offset: 0x000DF9A0
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000E17D8 File Offset: 0x000DF9D8
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000E1834 File Offset: 0x000DFA34
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000E1864 File Offset: 0x000DFA64
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000E189C File Offset: 0x000DFA9C
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x000E18F8 File Offset: 0x000DFAF8
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000E1928 File Offset: 0x000DFB28
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000E1960 File Offset: 0x000DFB60
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000E19BC File Offset: 0x000DFBBC
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x06001776 RID: 6006 RVA: 0x000E19EC File Offset: 0x000DFBEC
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000E1A24 File Offset: 0x000DFC24
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000E1A80 File Offset: 0x000DFC80
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001779 RID: 6009 RVA: 0x000E1AB0 File Offset: 0x000DFCB0
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x0600177A RID: 6010 RVA: 0x000E1AE8 File Offset: 0x000DFCE8
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x0600177B RID: 6011 RVA: 0x000E1B44 File Offset: 0x000DFD44
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E1B74 File Offset: 0x000DFD74
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000E1BAC File Offset: 0x000DFDAC
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x0600177E RID: 6014 RVA: 0x000E1C08 File Offset: 0x000DFE08
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000E1C38 File Offset: 0x000DFE38
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000E1C70 File Offset: 0x000DFE70
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000E1CCC File Offset: 0x000DFECC
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000E1CFC File Offset: 0x000DFEFC
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000E1D34 File Offset: 0x000DFF34
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x000E1D90 File Offset: 0x000DFF90
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x06001785 RID: 6021 RVA: 0x000E1DC0 File Offset: 0x000DFFC0
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000E1DF8 File Offset: 0x000DFFF8
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000E1E54 File Offset: 0x000E0054
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x000E1E84 File Offset: 0x000E0084
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x06001789 RID: 6025 RVA: 0x000E1EBC File Offset: 0x000E00BC
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x0600178A RID: 6026 RVA: 0x000E1F18 File Offset: 0x000E0118
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x0600178B RID: 6027 RVA: 0x000E1F48 File Offset: 0x000E0148
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x000E1F80 File Offset: 0x000E0180
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x000E1FDC File Offset: 0x000E01DC
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x0600178E RID: 6030 RVA: 0x000E200C File Offset: 0x000E020C
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x000E2044 File Offset: 0x000E0244
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x06001790 RID: 6032 RVA: 0x000E20A0 File Offset: 0x000E02A0
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x06001791 RID: 6033 RVA: 0x000E20D0 File Offset: 0x000E02D0
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x06001792 RID: 6034 RVA: 0x000E2108 File Offset: 0x000E0308
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x06001793 RID: 6035 RVA: 0x000E2164 File Offset: 0x000E0364
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x06001794 RID: 6036 RVA: 0x000E2194 File Offset: 0x000E0394
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x06001795 RID: 6037 RVA: 0x000E21CC File Offset: 0x000E03CC
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x06001796 RID: 6038 RVA: 0x000E2228 File Offset: 0x000E0428
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x06001797 RID: 6039 RVA: 0x000E2258 File Offset: 0x000E0458
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x06001798 RID: 6040 RVA: 0x000E2290 File Offset: 0x000E0490
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x000E22EC File Offset: 0x000E04EC
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x0600179A RID: 6042 RVA: 0x000E231C File Offset: 0x000E051C
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x0600179B RID: 6043 RVA: 0x000E2354 File Offset: 0x000E0554
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x000E23B0 File Offset: 0x000E05B0
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x0600179D RID: 6045 RVA: 0x000E23E0 File Offset: 0x000E05E0
	// (set) Token: 0x0600179E RID: 6046 RVA: 0x000E2410 File Offset: 0x000E0610
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

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x0600179F RID: 6047 RVA: 0x000E2440 File Offset: 0x000E0640
	// (set) Token: 0x060017A0 RID: 6048 RVA: 0x000E2470 File Offset: 0x000E0670
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

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x060017A1 RID: 6049 RVA: 0x000E24A0 File Offset: 0x000E06A0
	// (set) Token: 0x060017A2 RID: 6050 RVA: 0x000E24D0 File Offset: 0x000E06D0
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

	// Token: 0x060017A3 RID: 6051 RVA: 0x000E2500 File Offset: 0x000E0700
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

	// Token: 0x060017A4 RID: 6052 RVA: 0x000E2550 File Offset: 0x000E0750
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

	// Token: 0x060017A5 RID: 6053 RVA: 0x000E25A0 File Offset: 0x000E07A0
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x000E25D8 File Offset: 0x000E07D8
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x000E2634 File Offset: 0x000E0834
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x060017A8 RID: 6056 RVA: 0x000E2664 File Offset: 0x000E0864
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

	// Token: 0x040022A1 RID: 8865
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x040022A2 RID: 8866
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x040022A3 RID: 8867
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x040022A4 RID: 8868
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x040022A5 RID: 8869
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x040022A6 RID: 8870
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x040022A7 RID: 8871
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x040022A8 RID: 8872
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x040022A9 RID: 8873
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x040022AA RID: 8874
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x040022AB RID: 8875
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x040022AC RID: 8876
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x040022AD RID: 8877
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x040022AE RID: 8878
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x040022AF RID: 8879
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x040022B0 RID: 8880
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x040022B1 RID: 8881
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x040022B2 RID: 8882
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x040022B3 RID: 8883
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x040022B4 RID: 8884
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x040022B5 RID: 8885
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x040022B6 RID: 8886
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x040022B7 RID: 8887
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x040022B8 RID: 8888
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x040022B9 RID: 8889
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x040022BA RID: 8890
	private const string Str_StudentName = "StudentName_";

	// Token: 0x040022BB RID: 8891
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x040022BC RID: 8892
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x040022BD RID: 8893
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x040022BE RID: 8894
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x040022BF RID: 8895
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x040022C0 RID: 8896
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x040022C1 RID: 8897
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x040022C2 RID: 8898
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x040022C3 RID: 8899
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x040022C4 RID: 8900
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x040022C5 RID: 8901
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x040022C6 RID: 8902
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x040022C7 RID: 8903
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x040022C8 RID: 8904
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x040022C9 RID: 8905
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x040022CA RID: 8906
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x040022CB RID: 8907
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x040022CC RID: 8908
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x040022CD RID: 8909
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x040022CE RID: 8910
	private const string Str_MemorialStudent9 = "MemorialStudent9";
}
