using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class SchoolGlobals
{
	// Token: 0x060016F8 RID: 5880 RVA: 0x000DE904 File Offset: 0x000DCB04
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000DE93C File Offset: 0x000DCB3C
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x000DE998 File Offset: 0x000DCB98
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x000DE9C8 File Offset: 0x000DCBC8
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x000DEA00 File Offset: 0x000DCC00
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x000DEA5C File Offset: 0x000DCC5C
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060016FE RID: 5886 RVA: 0x000DEA8C File Offset: 0x000DCC8C
	// (set) Token: 0x060016FF RID: 5887 RVA: 0x000DEABC File Offset: 0x000DCCBC
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
	// (get) Token: 0x06001700 RID: 5888 RVA: 0x000DEAEC File Offset: 0x000DCCEC
	// (set) Token: 0x06001701 RID: 5889 RVA: 0x000DEB1C File Offset: 0x000DCD1C
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
	// (get) Token: 0x06001702 RID: 5890 RVA: 0x000DEB4C File Offset: 0x000DCD4C
	// (set) Token: 0x06001703 RID: 5891 RVA: 0x000DEB7C File Offset: 0x000DCD7C
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
	// (get) Token: 0x06001704 RID: 5892 RVA: 0x000DEBAC File Offset: 0x000DCDAC
	// (set) Token: 0x06001705 RID: 5893 RVA: 0x000DEBDC File Offset: 0x000DCDDC
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
	// (get) Token: 0x06001706 RID: 5894 RVA: 0x000DEC0C File Offset: 0x000DCE0C
	// (set) Token: 0x06001707 RID: 5895 RVA: 0x000DEC3C File Offset: 0x000DCE3C
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
	// (get) Token: 0x06001708 RID: 5896 RVA: 0x000DEC6C File Offset: 0x000DCE6C
	// (set) Token: 0x06001709 RID: 5897 RVA: 0x000DEC9C File Offset: 0x000DCE9C
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
	// (get) Token: 0x0600170A RID: 5898 RVA: 0x000DECCC File Offset: 0x000DCECC
	// (set) Token: 0x0600170B RID: 5899 RVA: 0x000DECFC File Offset: 0x000DCEFC
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
	// (get) Token: 0x0600170C RID: 5900 RVA: 0x000DED2C File Offset: 0x000DCF2C
	// (set) Token: 0x0600170D RID: 5901 RVA: 0x000DED5C File Offset: 0x000DCF5C
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

	// Token: 0x0600170E RID: 5902 RVA: 0x000DED8C File Offset: 0x000DCF8C
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

	// Token: 0x04002253 RID: 8787
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x04002254 RID: 8788
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x04002255 RID: 8789
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x04002256 RID: 8790
	private const string Str_Population = "Population";

	// Token: 0x04002257 RID: 8791
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x04002258 RID: 8792
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x04002259 RID: 8793
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x0400225A RID: 8794
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x0400225B RID: 8795
	private const string Str_SCP = "SCP";

	// Token: 0x0400225C RID: 8796
	private const string Str_HighSecurity = "HighSecurity";
}
