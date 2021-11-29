using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class StudentGlobals
{
	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001717 RID: 5911 RVA: 0x000DEAC4 File Offset: 0x000DCCC4
	// (set) Token: 0x06001718 RID: 5912 RVA: 0x000DEAF4 File Offset: 0x000DCCF4
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

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001719 RID: 5913 RVA: 0x000DEB24 File Offset: 0x000DCD24
	// (set) Token: 0x0600171A RID: 5914 RVA: 0x000DEB54 File Offset: 0x000DCD54
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

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x0600171B RID: 5915 RVA: 0x000DEB84 File Offset: 0x000DCD84
	// (set) Token: 0x0600171C RID: 5916 RVA: 0x000DEBB4 File Offset: 0x000DCDB4
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

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x0600171D RID: 5917 RVA: 0x000DEBE4 File Offset: 0x000DCDE4
	// (set) Token: 0x0600171E RID: 5918 RVA: 0x000DEC14 File Offset: 0x000DCE14
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

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000DEC44 File Offset: 0x000DCE44
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000DEC74 File Offset: 0x000DCE74
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

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000DECA4 File Offset: 0x000DCEA4
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000DECD4 File Offset: 0x000DCED4
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

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x06001723 RID: 5923 RVA: 0x000DED04 File Offset: 0x000DCF04
	// (set) Token: 0x06001724 RID: 5924 RVA: 0x000DED34 File Offset: 0x000DCF34
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

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06001725 RID: 5925 RVA: 0x000DED64 File Offset: 0x000DCF64
	// (set) Token: 0x06001726 RID: 5926 RVA: 0x000DED94 File Offset: 0x000DCF94
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

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06001727 RID: 5927 RVA: 0x000DEDC4 File Offset: 0x000DCFC4
	// (set) Token: 0x06001728 RID: 5928 RVA: 0x000DEDF4 File Offset: 0x000DCFF4
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

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001729 RID: 5929 RVA: 0x000DEE24 File Offset: 0x000DD024
	// (set) Token: 0x0600172A RID: 5930 RVA: 0x000DEE54 File Offset: 0x000DD054
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

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x0600172B RID: 5931 RVA: 0x000DEE84 File Offset: 0x000DD084
	// (set) Token: 0x0600172C RID: 5932 RVA: 0x000DEEB4 File Offset: 0x000DD0B4
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

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x0600172D RID: 5933 RVA: 0x000DEEE4 File Offset: 0x000DD0E4
	// (set) Token: 0x0600172E RID: 5934 RVA: 0x000DEF14 File Offset: 0x000DD114
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

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x0600172F RID: 5935 RVA: 0x000DEF44 File Offset: 0x000DD144
	// (set) Token: 0x06001730 RID: 5936 RVA: 0x000DEF74 File Offset: 0x000DD174
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

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06001731 RID: 5937 RVA: 0x000DEFA4 File Offset: 0x000DD1A4
	// (set) Token: 0x06001732 RID: 5938 RVA: 0x000DEFD4 File Offset: 0x000DD1D4
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

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06001733 RID: 5939 RVA: 0x000DF004 File Offset: 0x000DD204
	// (set) Token: 0x06001734 RID: 5940 RVA: 0x000DF034 File Offset: 0x000DD234
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

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06001735 RID: 5941 RVA: 0x000DF064 File Offset: 0x000DD264
	// (set) Token: 0x06001736 RID: 5942 RVA: 0x000DF094 File Offset: 0x000DD294
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

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06001737 RID: 5943 RVA: 0x000DF0C4 File Offset: 0x000DD2C4
	// (set) Token: 0x06001738 RID: 5944 RVA: 0x000DF0F4 File Offset: 0x000DD2F4
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

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06001739 RID: 5945 RVA: 0x000DF124 File Offset: 0x000DD324
	// (set) Token: 0x0600173A RID: 5946 RVA: 0x000DF154 File Offset: 0x000DD354
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

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x0600173B RID: 5947 RVA: 0x000DF184 File Offset: 0x000DD384
	// (set) Token: 0x0600173C RID: 5948 RVA: 0x000DF1B4 File Offset: 0x000DD3B4
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

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x0600173D RID: 5949 RVA: 0x000DF1E4 File Offset: 0x000DD3E4
	// (set) Token: 0x0600173E RID: 5950 RVA: 0x000DF214 File Offset: 0x000DD414
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

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000DF244 File Offset: 0x000DD444
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000DF274 File Offset: 0x000DD474
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

	// Token: 0x06001741 RID: 5953 RVA: 0x000DF2A4 File Offset: 0x000DD4A4
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x000DF2DC File Offset: 0x000DD4DC
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x06001743 RID: 5955 RVA: 0x000DF338 File Offset: 0x000DD538
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x06001744 RID: 5956 RVA: 0x000DF368 File Offset: 0x000DD568
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x06001745 RID: 5957 RVA: 0x000DF3A0 File Offset: 0x000DD5A0
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x06001746 RID: 5958 RVA: 0x000DF3FC File Offset: 0x000DD5FC
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x06001747 RID: 5959 RVA: 0x000DF42C File Offset: 0x000DD62C
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x000DF464 File Offset: 0x000DD664
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x000DF4C0 File Offset: 0x000DD6C0
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x000DF4F0 File Offset: 0x000DD6F0
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x000DF528 File Offset: 0x000DD728
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x000DF584 File Offset: 0x000DD784
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x000DF5B4 File Offset: 0x000DD7B4
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x0600174E RID: 5966 RVA: 0x000DF5EC File Offset: 0x000DD7EC
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x000DF648 File Offset: 0x000DD848
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x000DF678 File Offset: 0x000DD878
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x06001751 RID: 5969 RVA: 0x000DF6B0 File Offset: 0x000DD8B0
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x06001752 RID: 5970 RVA: 0x000DF70C File Offset: 0x000DD90C
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x000DF73C File Offset: 0x000DD93C
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x000DF774 File Offset: 0x000DD974
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x000DF7D0 File Offset: 0x000DD9D0
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x000DF800 File Offset: 0x000DDA00
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x000DF838 File Offset: 0x000DDA38
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000DF894 File Offset: 0x000DDA94
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000DF8C4 File Offset: 0x000DDAC4
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000DF8FC File Offset: 0x000DDAFC
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x000DF958 File Offset: 0x000DDB58
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x000DF988 File Offset: 0x000DDB88
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x000DF9C0 File Offset: 0x000DDBC0
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x000DFA1C File Offset: 0x000DDC1C
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x000DFA4C File Offset: 0x000DDC4C
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x000DFA84 File Offset: 0x000DDC84
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x000DFAE0 File Offset: 0x000DDCE0
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000DFB10 File Offset: 0x000DDD10
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000DFB48 File Offset: 0x000DDD48
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000DFBA4 File Offset: 0x000DDDA4
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000DFBD4 File Offset: 0x000DDDD4
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000DFC0C File Offset: 0x000DDE0C
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000DFC68 File Offset: 0x000DDE68
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000DFC98 File Offset: 0x000DDE98
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000DFCD0 File Offset: 0x000DDED0
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000DFD2C File Offset: 0x000DDF2C
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000DFD5C File Offset: 0x000DDF5C
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000DFD94 File Offset: 0x000DDF94
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000DFDF0 File Offset: 0x000DDFF0
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000DFE20 File Offset: 0x000DE020
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000DFE58 File Offset: 0x000DE058
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000DFEB4 File Offset: 0x000DE0B4
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000DFEE4 File Offset: 0x000DE0E4
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x000DFF1C File Offset: 0x000DE11C
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000DFF78 File Offset: 0x000DE178
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000DFFA8 File Offset: 0x000DE1A8
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000DFFE0 File Offset: 0x000DE1E0
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x06001776 RID: 6006 RVA: 0x000E003C File Offset: 0x000DE23C
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000E006C File Offset: 0x000DE26C
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000E00A4 File Offset: 0x000DE2A4
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x06001779 RID: 6009 RVA: 0x000E0100 File Offset: 0x000DE300
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x0600177A RID: 6010 RVA: 0x000E0130 File Offset: 0x000DE330
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x0600177B RID: 6011 RVA: 0x000E0168 File Offset: 0x000DE368
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E01C4 File Offset: 0x000DE3C4
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x0600177D RID: 6013 RVA: 0x000E01F4 File Offset: 0x000DE3F4
	// (set) Token: 0x0600177E RID: 6014 RVA: 0x000E0224 File Offset: 0x000DE424
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

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x0600177F RID: 6015 RVA: 0x000E0254 File Offset: 0x000DE454
	// (set) Token: 0x06001780 RID: 6016 RVA: 0x000E0284 File Offset: 0x000DE484
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

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06001781 RID: 6017 RVA: 0x000E02B4 File Offset: 0x000DE4B4
	// (set) Token: 0x06001782 RID: 6018 RVA: 0x000E02E4 File Offset: 0x000DE4E4
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

	// Token: 0x06001783 RID: 6019 RVA: 0x000E0314 File Offset: 0x000DE514
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

	// Token: 0x06001784 RID: 6020 RVA: 0x000E0364 File Offset: 0x000DE564
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

	// Token: 0x06001785 RID: 6021 RVA: 0x000E03B4 File Offset: 0x000DE5B4
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000E03EC File Offset: 0x000DE5EC
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000E0448 File Offset: 0x000DE648
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x000E0478 File Offset: 0x000DE678
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

	// Token: 0x04002244 RID: 8772
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x04002245 RID: 8773
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x04002246 RID: 8774
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x04002247 RID: 8775
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x04002248 RID: 8776
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x04002249 RID: 8777
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x0400224A RID: 8778
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x0400224B RID: 8779
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x0400224C RID: 8780
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x0400224D RID: 8781
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x0400224E RID: 8782
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x0400224F RID: 8783
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x04002250 RID: 8784
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x04002251 RID: 8785
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x04002252 RID: 8786
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x04002253 RID: 8787
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x04002254 RID: 8788
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x04002255 RID: 8789
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x04002256 RID: 8790
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x04002257 RID: 8791
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x04002258 RID: 8792
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x04002259 RID: 8793
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x0400225A RID: 8794
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x0400225B RID: 8795
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x0400225C RID: 8796
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x0400225D RID: 8797
	private const string Str_StudentName = "StudentName_";

	// Token: 0x0400225E RID: 8798
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x0400225F RID: 8799
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x04002260 RID: 8800
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x04002261 RID: 8801
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x04002262 RID: 8802
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x04002263 RID: 8803
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x04002264 RID: 8804
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x04002265 RID: 8805
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x04002266 RID: 8806
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x04002267 RID: 8807
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x04002268 RID: 8808
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x04002269 RID: 8809
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x0400226A RID: 8810
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x0400226B RID: 8811
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x0400226C RID: 8812
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x0400226D RID: 8813
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x0400226E RID: 8814
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x0400226F RID: 8815
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x04002270 RID: 8816
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x04002271 RID: 8817
	private const string Str_MemorialStudent9 = "MemorialStudent9";
}
