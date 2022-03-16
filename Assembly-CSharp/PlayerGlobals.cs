using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class PlayerGlobals
{
	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x0600168F RID: 5775 RVA: 0x000DE464 File Offset: 0x000DC664
	// (set) Token: 0x06001690 RID: 5776 RVA: 0x000DE494 File Offset: 0x000DC694
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
	// (get) Token: 0x06001691 RID: 5777 RVA: 0x000DE4C4 File Offset: 0x000DC6C4
	// (set) Token: 0x06001692 RID: 5778 RVA: 0x000DE4F4 File Offset: 0x000DC6F4
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
	// (get) Token: 0x06001693 RID: 5779 RVA: 0x000DE524 File Offset: 0x000DC724
	// (set) Token: 0x06001694 RID: 5780 RVA: 0x000DE554 File Offset: 0x000DC754
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
	// (get) Token: 0x06001695 RID: 5781 RVA: 0x000DE584 File Offset: 0x000DC784
	// (set) Token: 0x06001696 RID: 5782 RVA: 0x000DE5B4 File Offset: 0x000DC7B4
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
	// (get) Token: 0x06001697 RID: 5783 RVA: 0x000DE5E4 File Offset: 0x000DC7E4
	// (set) Token: 0x06001698 RID: 5784 RVA: 0x000DE614 File Offset: 0x000DC814
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
	// (get) Token: 0x06001699 RID: 5785 RVA: 0x000DE644 File Offset: 0x000DC844
	// (set) Token: 0x0600169A RID: 5786 RVA: 0x000DE674 File Offset: 0x000DC874
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
	// (get) Token: 0x0600169B RID: 5787 RVA: 0x000DE6A4 File Offset: 0x000DC8A4
	// (set) Token: 0x0600169C RID: 5788 RVA: 0x000DE6D4 File Offset: 0x000DC8D4
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
	// (get) Token: 0x0600169D RID: 5789 RVA: 0x000DE704 File Offset: 0x000DC904
	// (set) Token: 0x0600169E RID: 5790 RVA: 0x000DE734 File Offset: 0x000DC934
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
	// (get) Token: 0x0600169F RID: 5791 RVA: 0x000DE764 File Offset: 0x000DC964
	// (set) Token: 0x060016A0 RID: 5792 RVA: 0x000DE794 File Offset: 0x000DC994
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
	// (get) Token: 0x060016A1 RID: 5793 RVA: 0x000DE7C4 File Offset: 0x000DC9C4
	// (set) Token: 0x060016A2 RID: 5794 RVA: 0x000DE7F4 File Offset: 0x000DC9F4
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
	// (get) Token: 0x060016A3 RID: 5795 RVA: 0x000DE824 File Offset: 0x000DCA24
	// (set) Token: 0x060016A4 RID: 5796 RVA: 0x000DE854 File Offset: 0x000DCA54
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
	// (get) Token: 0x060016A5 RID: 5797 RVA: 0x000DE884 File Offset: 0x000DCA84
	// (set) Token: 0x060016A6 RID: 5798 RVA: 0x000DE8B4 File Offset: 0x000DCAB4
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
	// (get) Token: 0x060016A7 RID: 5799 RVA: 0x000DE8E4 File Offset: 0x000DCAE4
	// (set) Token: 0x060016A8 RID: 5800 RVA: 0x000DE914 File Offset: 0x000DCB14
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
	// (get) Token: 0x060016A9 RID: 5801 RVA: 0x000DE944 File Offset: 0x000DCB44
	// (set) Token: 0x060016AA RID: 5802 RVA: 0x000DE974 File Offset: 0x000DCB74
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
	// (get) Token: 0x060016AB RID: 5803 RVA: 0x000DE9A4 File Offset: 0x000DCBA4
	// (set) Token: 0x060016AC RID: 5804 RVA: 0x000DE9D4 File Offset: 0x000DCBD4
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

	// Token: 0x060016AD RID: 5805 RVA: 0x000DEA04 File Offset: 0x000DCC04
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x060016AE RID: 5806 RVA: 0x000DEA3C File Offset: 0x000DCC3C
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x000DEA98 File Offset: 0x000DCC98
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x060016B0 RID: 5808 RVA: 0x000DEAC8 File Offset: 0x000DCCC8
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x060016B1 RID: 5809 RVA: 0x000DEB00 File Offset: 0x000DCD00
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x000DEB5C File Offset: 0x000DCD5C
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x000DEB8C File Offset: 0x000DCD8C
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x000DEBC4 File Offset: 0x000DCDC4
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x000DEC20 File Offset: 0x000DCE20
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x000DEC50 File Offset: 0x000DCE50
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x060016B7 RID: 5815 RVA: 0x000DEC88 File Offset: 0x000DCE88
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x000DECE4 File Offset: 0x000DCEE4
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016B9 RID: 5817 RVA: 0x000DED14 File Offset: 0x000DCF14
	// (set) Token: 0x060016BA RID: 5818 RVA: 0x000DED44 File Offset: 0x000DCF44
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
	// (get) Token: 0x060016BB RID: 5819 RVA: 0x000DED74 File Offset: 0x000DCF74
	// (set) Token: 0x060016BC RID: 5820 RVA: 0x000DEDA4 File Offset: 0x000DCFA4
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
	// (get) Token: 0x060016BD RID: 5821 RVA: 0x000DEDD4 File Offset: 0x000DCFD4
	// (set) Token: 0x060016BE RID: 5822 RVA: 0x000DEE04 File Offset: 0x000DD004
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

	// Token: 0x060016BF RID: 5823 RVA: 0x000DEE34 File Offset: 0x000DD034
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x000DEE6C File Offset: 0x000DD06C
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x060016C1 RID: 5825 RVA: 0x000DEEC8 File Offset: 0x000DD0C8
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x060016C2 RID: 5826 RVA: 0x000DEF00 File Offset: 0x000DD100
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016C3 RID: 5827 RVA: 0x000DEF5C File Offset: 0x000DD15C
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x000DEF8C File Offset: 0x000DD18C
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x060016C5 RID: 5829 RVA: 0x000DEFBC File Offset: 0x000DD1BC
	// (set) Token: 0x060016C6 RID: 5830 RVA: 0x000DEFEC File Offset: 0x000DD1EC
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
	// (get) Token: 0x060016C7 RID: 5831 RVA: 0x000DF01C File Offset: 0x000DD21C
	// (set) Token: 0x060016C8 RID: 5832 RVA: 0x000DF04C File Offset: 0x000DD24C
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
	// (get) Token: 0x060016C9 RID: 5833 RVA: 0x000DF07C File Offset: 0x000DD27C
	// (set) Token: 0x060016CA RID: 5834 RVA: 0x000DF0AC File Offset: 0x000DD2AC
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
	// (get) Token: 0x060016CB RID: 5835 RVA: 0x000DF0DC File Offset: 0x000DD2DC
	// (set) Token: 0x060016CC RID: 5836 RVA: 0x000DF10C File Offset: 0x000DD30C
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
	// (get) Token: 0x060016CD RID: 5837 RVA: 0x000DF13C File Offset: 0x000DD33C
	// (set) Token: 0x060016CE RID: 5838 RVA: 0x000DF16C File Offset: 0x000DD36C
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

	// Token: 0x060016CF RID: 5839 RVA: 0x000DF19C File Offset: 0x000DD39C
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x000DF1D4 File Offset: 0x000DD3D4
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x000DF230 File Offset: 0x000DD430
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x000DF260 File Offset: 0x000DD460
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x000DF298 File Offset: 0x000DD498
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x000DF2F4 File Offset: 0x000DD4F4
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x000DF324 File Offset: 0x000DD524
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x000DF354 File Offset: 0x000DD554
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x000DF38C File Offset: 0x000DD58C
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000DF3E8 File Offset: 0x000DD5E8
	// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000DF418 File Offset: 0x000DD618
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
	// (get) Token: 0x060016DA RID: 5850 RVA: 0x000DF448 File Offset: 0x000DD648
	// (set) Token: 0x060016DB RID: 5851 RVA: 0x000DF478 File Offset: 0x000DD678
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
	// (get) Token: 0x060016DC RID: 5852 RVA: 0x000DF4A8 File Offset: 0x000DD6A8
	// (set) Token: 0x060016DD RID: 5853 RVA: 0x000DF4D8 File Offset: 0x000DD6D8
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
	// (get) Token: 0x060016DE RID: 5854 RVA: 0x000DF508 File Offset: 0x000DD708
	// (set) Token: 0x060016DF RID: 5855 RVA: 0x000DF538 File Offset: 0x000DD738
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

	// Token: 0x060016E0 RID: 5856 RVA: 0x000DF568 File Offset: 0x000DD768
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x000DF598 File Offset: 0x000DD798
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x000DF5D0 File Offset: 0x000DD7D0
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060016E3 RID: 5859 RVA: 0x000DF62C File Offset: 0x000DD82C
	// (set) Token: 0x060016E4 RID: 5860 RVA: 0x000DF65C File Offset: 0x000DD85C
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
	// (get) Token: 0x060016E5 RID: 5861 RVA: 0x000DF68C File Offset: 0x000DD88C
	// (set) Token: 0x060016E6 RID: 5862 RVA: 0x000DF6BC File Offset: 0x000DD8BC
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
	// (get) Token: 0x060016E7 RID: 5863 RVA: 0x000DF6EC File Offset: 0x000DD8EC
	// (set) Token: 0x060016E8 RID: 5864 RVA: 0x000DF71C File Offset: 0x000DD91C
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
	// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000DF74C File Offset: 0x000DD94C
	// (set) Token: 0x060016EA RID: 5866 RVA: 0x000DF77C File Offset: 0x000DD97C
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
	// (get) Token: 0x060016EB RID: 5867 RVA: 0x000DF7AC File Offset: 0x000DD9AC
	// (set) Token: 0x060016EC RID: 5868 RVA: 0x000DF7DC File Offset: 0x000DD9DC
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
	// (get) Token: 0x060016ED RID: 5869 RVA: 0x000DF80C File Offset: 0x000DDA0C
	// (set) Token: 0x060016EE RID: 5870 RVA: 0x000DF83C File Offset: 0x000DDA3C
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
	// (get) Token: 0x060016EF RID: 5871 RVA: 0x000DF86C File Offset: 0x000DDA6C
	// (set) Token: 0x060016F0 RID: 5872 RVA: 0x000DF89C File Offset: 0x000DDA9C
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
	// (get) Token: 0x060016F1 RID: 5873 RVA: 0x000DF8CC File Offset: 0x000DDACC
	// (set) Token: 0x060016F2 RID: 5874 RVA: 0x000DF8FC File Offset: 0x000DDAFC
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

	// Token: 0x060016F3 RID: 5875 RVA: 0x000DF92C File Offset: 0x000DDB2C
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

	// Token: 0x04002267 RID: 8807
	private const string Str_Money = "Money";

	// Token: 0x04002268 RID: 8808
	private const string Str_Alerts = "Alerts";

	// Token: 0x04002269 RID: 8809
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x0400226A RID: 8810
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x0400226B RID: 8811
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x0400226C RID: 8812
	private const string Str_Friends = "Friends";

	// Token: 0x0400226D RID: 8813
	private const string Str_Headset = "Headset";

	// Token: 0x0400226E RID: 8814
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x0400226F RID: 8815
	private const string Str_FakeID = "FakeID";

	// Token: 0x04002270 RID: 8816
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x04002271 RID: 8817
	private const string Str_Kills = "Kills";

	// Token: 0x04002272 RID: 8818
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x04002273 RID: 8819
	private const string Str_Numbness = "Numbness";

	// Token: 0x04002274 RID: 8820
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002275 RID: 8821
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002276 RID: 8822
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x04002277 RID: 8823
	private const string Str_Photo = "Photo_";

	// Token: 0x04002278 RID: 8824
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x04002279 RID: 8825
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x0400227A RID: 8826
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x0400227B RID: 8827
	private const string Str_Reputation = "Reputation";

	// Token: 0x0400227C RID: 8828
	private const string Str_Seduction = "Seduction";

	// Token: 0x0400227D RID: 8829
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x0400227E RID: 8830
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x0400227F RID: 8831
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x04002280 RID: 8832
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x04002281 RID: 8833
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x04002282 RID: 8834
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x04002283 RID: 8835
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x04002284 RID: 8836
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x04002285 RID: 8837
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x04002286 RID: 8838
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x04002287 RID: 8839
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x04002288 RID: 8840
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x04002289 RID: 8841
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x0400228A RID: 8842
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x0400228B RID: 8843
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x0400228C RID: 8844
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x0400228D RID: 8845
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x0400228E RID: 8846
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x0400228F RID: 8847
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x04002290 RID: 8848
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x04002291 RID: 8849
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x04002292 RID: 8850
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x04002293 RID: 8851
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
