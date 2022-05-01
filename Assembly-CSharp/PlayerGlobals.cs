using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class PlayerGlobals
{
	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x060016A1 RID: 5793 RVA: 0x000DF12C File Offset: 0x000DD32C
	// (set) Token: 0x060016A2 RID: 5794 RVA: 0x000DF15C File Offset: 0x000DD35C
	public static float Money
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money", value);
		}
	}

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x060016A3 RID: 5795 RVA: 0x000DF18C File Offset: 0x000DD38C
	// (set) Token: 0x060016A4 RID: 5796 RVA: 0x000DF1BC File Offset: 0x000DD3BC
	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts", value);
		}
	}

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x060016A5 RID: 5797 RVA: 0x000DF1EC File Offset: 0x000DD3EC
	// (set) Token: 0x060016A6 RID: 5798 RVA: 0x000DF21C File Offset: 0x000DD41C
	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment", value);
		}
	}

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x060016A7 RID: 5799 RVA: 0x000DF24C File Offset: 0x000DD44C
	// (set) Token: 0x060016A8 RID: 5800 RVA: 0x000DF27C File Offset: 0x000DD47C
	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus", value);
		}
	}

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x060016A9 RID: 5801 RVA: 0x000DF2AC File Offset: 0x000DD4AC
	// (set) Token: 0x060016AA RID: 5802 RVA: 0x000DF2DC File Offset: 0x000DD4DC
	public static int Friends
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends", value);
		}
	}

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x060016AB RID: 5803 RVA: 0x000DF30C File Offset: 0x000DD50C
	// (set) Token: 0x060016AC RID: 5804 RVA: 0x000DF33C File Offset: 0x000DD53C
	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset", value);
		}
	}

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x060016AD RID: 5805 RVA: 0x000DF36C File Offset: 0x000DD56C
	// (set) Token: 0x060016AE RID: 5806 RVA: 0x000DF39C File Offset: 0x000DD59C
	public static bool DirectionalMic
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic", value);
		}
	}

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x060016AF RID: 5807 RVA: 0x000DF3CC File Offset: 0x000DD5CC
	// (set) Token: 0x060016B0 RID: 5808 RVA: 0x000DF3FC File Offset: 0x000DD5FC
	public static bool FakeID
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID", value);
		}
	}

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x060016B1 RID: 5809 RVA: 0x000DF42C File Offset: 0x000DD62C
	// (set) Token: 0x060016B2 RID: 5810 RVA: 0x000DF45C File Offset: 0x000DD65C
	public static bool RaibaruLoner
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner", value);
		}
	}

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x060016B3 RID: 5811 RVA: 0x000DF48C File Offset: 0x000DD68C
	// (set) Token: 0x060016B4 RID: 5812 RVA: 0x000DF4BC File Offset: 0x000DD6BC
	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills", value);
		}
	}

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x060016B5 RID: 5813 RVA: 0x000DF4EC File Offset: 0x000DD6EC
	// (set) Token: 0x060016B6 RID: 5814 RVA: 0x000DF51C File Offset: 0x000DD71C
	public static int CorpsesDiscovered
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered", value);
		}
	}

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x060016B7 RID: 5815 RVA: 0x000DF54C File Offset: 0x000DD74C
	// (set) Token: 0x060016B8 RID: 5816 RVA: 0x000DF57C File Offset: 0x000DD77C
	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness", value);
		}
	}

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x060016B9 RID: 5817 RVA: 0x000DF5AC File Offset: 0x000DD7AC
	// (set) Token: 0x060016BA RID: 5818 RVA: 0x000DF5DC File Offset: 0x000DD7DC
	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus", value);
		}
	}

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x060016BB RID: 5819 RVA: 0x000DF60C File Offset: 0x000DD80C
	// (set) Token: 0x060016BC RID: 5820 RVA: 0x000DF63C File Offset: 0x000DD83C
	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped", value);
		}
	}

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x060016BD RID: 5821 RVA: 0x000DF66C File Offset: 0x000DD86C
	// (set) Token: 0x060016BE RID: 5822 RVA: 0x000DF69C File Offset: 0x000DD89C
	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots", value);
		}
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x000DF6CC File Offset: 0x000DD8CC
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x000DF704 File Offset: 0x000DD904
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x060016C1 RID: 5825 RVA: 0x000DF760 File Offset: 0x000DD960
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x060016C2 RID: 5826 RVA: 0x000DF790 File Offset: 0x000DD990
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x060016C3 RID: 5827 RVA: 0x000DF7C8 File Offset: 0x000DD9C8
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x000DF824 File Offset: 0x000DDA24
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x000DF854 File Offset: 0x000DDA54
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x000DF88C File Offset: 0x000DDA8C
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x000DF8E8 File Offset: 0x000DDAE8
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x000DF918 File Offset: 0x000DDB18
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x000DF950 File Offset: 0x000DDB50
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x000DF9AC File Offset: 0x000DDBAC
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016CB RID: 5835 RVA: 0x000DF9DC File Offset: 0x000DDBDC
	// (set) Token: 0x060016CC RID: 5836 RVA: 0x000DFA0C File Offset: 0x000DDC0C
	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation", value);
		}
	}

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x060016CD RID: 5837 RVA: 0x000DFA3C File Offset: 0x000DDC3C
	// (set) Token: 0x060016CE RID: 5838 RVA: 0x000DFA6C File Offset: 0x000DDC6C
	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction", value);
		}
	}

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x060016CF RID: 5839 RVA: 0x000DFA9C File Offset: 0x000DDC9C
	// (set) Token: 0x060016D0 RID: 5840 RVA: 0x000DFACC File Offset: 0x000DDCCC
	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus", value);
		}
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x000DFAFC File Offset: 0x000DDCFC
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x000DFB34 File Offset: 0x000DDD34
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x000DFB90 File Offset: 0x000DDD90
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x000DFBC8 File Offset: 0x000DDDC8
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x000DFC24 File Offset: 0x000DDE24
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x000DFC54 File Offset: 0x000DDE54
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x060016D7 RID: 5847 RVA: 0x000DFC84 File Offset: 0x000DDE84
	// (set) Token: 0x060016D8 RID: 5848 RVA: 0x000DFCB4 File Offset: 0x000DDEB4
	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots", value);
		}
	}

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x060016D9 RID: 5849 RVA: 0x000DFCE4 File Offset: 0x000DDEE4
	// (set) Token: 0x060016DA RID: 5850 RVA: 0x000DFD14 File Offset: 0x000DDF14
	public static int SenpaiShotsTexted
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted", value);
		}
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x060016DB RID: 5851 RVA: 0x000DFD44 File Offset: 0x000DDF44
	// (set) Token: 0x060016DC RID: 5852 RVA: 0x000DFD74 File Offset: 0x000DDF74
	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus", value);
		}
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x060016DD RID: 5853 RVA: 0x000DFDA4 File Offset: 0x000DDFA4
	// (set) Token: 0x060016DE RID: 5854 RVA: 0x000DFDD4 File Offset: 0x000DDFD4
	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus", value);
		}
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DFE04 File Offset: 0x000DE004
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DFE34 File Offset: 0x000DE034
	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus", value);
		}
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x000DFE64 File Offset: 0x000DE064
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x000DFE9C File Offset: 0x000DE09C
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x000DFEF8 File Offset: 0x000DE0F8
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016E4 RID: 5860 RVA: 0x000DFF28 File Offset: 0x000DE128
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x000DFF60 File Offset: 0x000DE160
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x000DFFBC File Offset: 0x000DE1BC
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x000DFFEC File Offset: 0x000DE1EC
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x000E001C File Offset: 0x000DE21C
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x000E0054 File Offset: 0x000DE254
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060016EA RID: 5866 RVA: 0x000E00B0 File Offset: 0x000DE2B0
	// (set) Token: 0x060016EB RID: 5867 RVA: 0x000E00E0 File Offset: 0x000DE2E0
	public static bool UsingGamepad
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad", value);
		}
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060016EC RID: 5868 RVA: 0x000E0110 File Offset: 0x000DE310
	// (set) Token: 0x060016ED RID: 5869 RVA: 0x000E0140 File Offset: 0x000DE340
	public static int PersonaID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID", value);
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060016EE RID: 5870 RVA: 0x000E0170 File Offset: 0x000DE370
	// (set) Token: 0x060016EF RID: 5871 RVA: 0x000E01A0 File Offset: 0x000DE3A0
	public static int ShrineItems
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems", value);
		}
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060016F0 RID: 5872 RVA: 0x000E01D0 File Offset: 0x000DE3D0
	// (set) Token: 0x060016F1 RID: 5873 RVA: 0x000E0200 File Offset: 0x000DE400
	public static int BringingItem
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem", value);
		}
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000E0230 File Offset: 0x000DE430
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000E0260 File Offset: 0x000DE460
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000E0298 File Offset: 0x000DE498
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060016F5 RID: 5877 RVA: 0x000E02F4 File Offset: 0x000DE4F4
	// (set) Token: 0x060016F6 RID: 5878 RVA: 0x000E0324 File Offset: 0x000DE524
	public static bool BoughtLockpick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick", value);
		}
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060016F7 RID: 5879 RVA: 0x000E0354 File Offset: 0x000DE554
	// (set) Token: 0x060016F8 RID: 5880 RVA: 0x000E0384 File Offset: 0x000DE584
	public static bool BoughtSedative
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative", value);
		}
	}

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060016F9 RID: 5881 RVA: 0x000E03B4 File Offset: 0x000DE5B4
	// (set) Token: 0x060016FA RID: 5882 RVA: 0x000E03E4 File Offset: 0x000DE5E4
	public static bool BoughtNarcotics
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics", value);
		}
	}

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060016FB RID: 5883 RVA: 0x000E0414 File Offset: 0x000DE614
	// (set) Token: 0x060016FC RID: 5884 RVA: 0x000E0444 File Offset: 0x000DE644
	public static bool BoughtPoison
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison", value);
		}
	}

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060016FD RID: 5885 RVA: 0x000E0474 File Offset: 0x000DE674
	// (set) Token: 0x060016FE RID: 5886 RVA: 0x000E04A4 File Offset: 0x000DE6A4
	public static bool BoughtExplosive
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive", value);
		}
	}

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016FF RID: 5887 RVA: 0x000E04D4 File Offset: 0x000DE6D4
	// (set) Token: 0x06001700 RID: 5888 RVA: 0x000E0504 File Offset: 0x000DE704
	public static int PoliceVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits", value);
		}
	}

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x06001701 RID: 5889 RVA: 0x000E0534 File Offset: 0x000DE734
	// (set) Token: 0x06001702 RID: 5890 RVA: 0x000E0564 File Offset: 0x000DE764
	public static int BloodWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed", value);
		}
	}

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x06001703 RID: 5891 RVA: 0x000E0594 File Offset: 0x000DE794
	// (set) Token: 0x06001704 RID: 5892 RVA: 0x000E05C4 File Offset: 0x000DE7C4
	public static int WeaponWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed", value);
		}
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000E05F4 File Offset: 0x000DE7F4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Money");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", PlayerGlobals.KeysOfPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", PlayerGlobals.KeysOfPhotoOnCorkboard());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", PlayerGlobals.KeysOfPhotoPosition());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", PlayerGlobals.KeysOfPhotoRotation());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", PlayerGlobals.KeysOfBullyPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", PlayerGlobals.KeysOfShrineCollectible());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", PlayerGlobals.KeysOfCannotBringItem());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
	}

	// Token: 0x04002282 RID: 8834
	private const string Str_Money = "Money";

	// Token: 0x04002283 RID: 8835
	private const string Str_Alerts = "Alerts";

	// Token: 0x04002284 RID: 8836
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x04002285 RID: 8837
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x04002286 RID: 8838
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x04002287 RID: 8839
	private const string Str_Friends = "Friends";

	// Token: 0x04002288 RID: 8840
	private const string Str_Headset = "Headset";

	// Token: 0x04002289 RID: 8841
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x0400228A RID: 8842
	private const string Str_FakeID = "FakeID";

	// Token: 0x0400228B RID: 8843
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x0400228C RID: 8844
	private const string Str_Kills = "Kills";

	// Token: 0x0400228D RID: 8845
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x0400228E RID: 8846
	private const string Str_Numbness = "Numbness";

	// Token: 0x0400228F RID: 8847
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002290 RID: 8848
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002291 RID: 8849
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x04002292 RID: 8850
	private const string Str_Photo = "Photo_";

	// Token: 0x04002293 RID: 8851
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x04002294 RID: 8852
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x04002295 RID: 8853
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x04002296 RID: 8854
	private const string Str_Reputation = "Reputation";

	// Token: 0x04002297 RID: 8855
	private const string Str_Seduction = "Seduction";

	// Token: 0x04002298 RID: 8856
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x04002299 RID: 8857
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x0400229A RID: 8858
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x0400229B RID: 8859
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x0400229C RID: 8860
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x0400229D RID: 8861
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x0400229E RID: 8862
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x0400229F RID: 8863
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x040022A0 RID: 8864
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x040022A1 RID: 8865
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x040022A2 RID: 8866
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x040022A3 RID: 8867
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x040022A4 RID: 8868
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x040022A5 RID: 8869
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x040022A6 RID: 8870
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x040022A7 RID: 8871
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x040022A8 RID: 8872
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x040022A9 RID: 8873
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x040022AA RID: 8874
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x040022AB RID: 8875
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x040022AC RID: 8876
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x040022AD RID: 8877
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x040022AE RID: 8878
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
