using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SchoolGlobals
{
	// Token: 0x060016F1 RID: 5873 RVA: 0x000DE144 File Offset: 0x000DC344
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000DE17C File Offset: 0x000DC37C
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000DE1D8 File Offset: 0x000DC3D8
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000DE208 File Offset: 0x000DC408
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000DE240 File Offset: 0x000DC440
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x000DE29C File Offset: 0x000DC49C
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060016F7 RID: 5879 RVA: 0x000DE2CC File Offset: 0x000DC4CC
	// (set) Token: 0x060016F8 RID: 5880 RVA: 0x000DE2FC File Offset: 0x000DC4FC
	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim", value);
		}
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x060016F9 RID: 5881 RVA: 0x000DE32C File Offset: 0x000DC52C
	// (set) Token: 0x060016FA RID: 5882 RVA: 0x000DE35C File Offset: 0x000DC55C
	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population", value);
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x060016FB RID: 5883 RVA: 0x000DE38C File Offset: 0x000DC58C
	// (set) Token: 0x060016FC RID: 5884 RVA: 0x000DE3BC File Offset: 0x000DC5BC
	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence", value);
		}
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x060016FD RID: 5885 RVA: 0x000DE3EC File Offset: 0x000DC5EC
	// (set) Token: 0x060016FE RID: 5886 RVA: 0x000DE41C File Offset: 0x000DC61C
	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere", value);
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x060016FF RID: 5887 RVA: 0x000DE44C File Offset: 0x000DC64C
	// (set) Token: 0x06001700 RID: 5888 RVA: 0x000DE47C File Offset: 0x000DC67C
	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet", value);
		}
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x06001701 RID: 5889 RVA: 0x000DE4AC File Offset: 0x000DC6AC
	// (set) Token: 0x06001702 RID: 5890 RVA: 0x000DE4DC File Offset: 0x000DC6DC
	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader", value);
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x06001703 RID: 5891 RVA: 0x000DE50C File Offset: 0x000DC70C
	// (set) Token: 0x06001704 RID: 5892 RVA: 0x000DE53C File Offset: 0x000DC73C
	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity", value);
		}
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x06001705 RID: 5893 RVA: 0x000DE56C File Offset: 0x000DC76C
	// (set) Token: 0x06001706 RID: 5894 RVA: 0x000DE59C File Offset: 0x000DC79C
	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP", value);
		}
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x000DE5CC File Offset: 0x000DC7CC
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", SchoolGlobals.KeysOfDemonActive());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
	}

	// Token: 0x04002233 RID: 8755
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x04002234 RID: 8756
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x04002235 RID: 8757
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x04002236 RID: 8758
	private const string Str_Population = "Population";

	// Token: 0x04002237 RID: 8759
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x04002238 RID: 8760
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x04002239 RID: 8761
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x0400223A RID: 8762
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x0400223B RID: 8763
	private const string Str_SCP = "SCP";

	// Token: 0x0400223C RID: 8764
	private const string Str_HighSecurity = "HighSecurity";
}
