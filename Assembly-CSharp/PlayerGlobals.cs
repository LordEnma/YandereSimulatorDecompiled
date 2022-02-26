using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class PlayerGlobals
{
	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x000DDC88 File Offset: 0x000DBE88
	// (set) Token: 0x0600168B RID: 5771 RVA: 0x000DDCB8 File Offset: 0x000DBEB8
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

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x000DDCE8 File Offset: 0x000DBEE8
	// (set) Token: 0x0600168D RID: 5773 RVA: 0x000DDD18 File Offset: 0x000DBF18
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

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x000DDD48 File Offset: 0x000DBF48
	// (set) Token: 0x0600168F RID: 5775 RVA: 0x000DDD78 File Offset: 0x000DBF78
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

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x000DDDA8 File Offset: 0x000DBFA8
	// (set) Token: 0x06001691 RID: 5777 RVA: 0x000DDDD8 File Offset: 0x000DBFD8
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

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x06001692 RID: 5778 RVA: 0x000DDE08 File Offset: 0x000DC008
	// (set) Token: 0x06001693 RID: 5779 RVA: 0x000DDE38 File Offset: 0x000DC038
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

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x06001694 RID: 5780 RVA: 0x000DDE68 File Offset: 0x000DC068
	// (set) Token: 0x06001695 RID: 5781 RVA: 0x000DDE98 File Offset: 0x000DC098
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

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x06001696 RID: 5782 RVA: 0x000DDEC8 File Offset: 0x000DC0C8
	// (set) Token: 0x06001697 RID: 5783 RVA: 0x000DDEF8 File Offset: 0x000DC0F8
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

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x06001698 RID: 5784 RVA: 0x000DDF28 File Offset: 0x000DC128
	// (set) Token: 0x06001699 RID: 5785 RVA: 0x000DDF58 File Offset: 0x000DC158
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

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x0600169A RID: 5786 RVA: 0x000DDF88 File Offset: 0x000DC188
	// (set) Token: 0x0600169B RID: 5787 RVA: 0x000DDFB8 File Offset: 0x000DC1B8
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

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x0600169C RID: 5788 RVA: 0x000DDFE8 File Offset: 0x000DC1E8
	// (set) Token: 0x0600169D RID: 5789 RVA: 0x000DE018 File Offset: 0x000DC218
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

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x0600169E RID: 5790 RVA: 0x000DE048 File Offset: 0x000DC248
	// (set) Token: 0x0600169F RID: 5791 RVA: 0x000DE078 File Offset: 0x000DC278
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

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x060016A0 RID: 5792 RVA: 0x000DE0A8 File Offset: 0x000DC2A8
	// (set) Token: 0x060016A1 RID: 5793 RVA: 0x000DE0D8 File Offset: 0x000DC2D8
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

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x060016A2 RID: 5794 RVA: 0x000DE108 File Offset: 0x000DC308
	// (set) Token: 0x060016A3 RID: 5795 RVA: 0x000DE138 File Offset: 0x000DC338
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

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x060016A4 RID: 5796 RVA: 0x000DE168 File Offset: 0x000DC368
	// (set) Token: 0x060016A5 RID: 5797 RVA: 0x000DE198 File Offset: 0x000DC398
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

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x060016A6 RID: 5798 RVA: 0x000DE1C8 File Offset: 0x000DC3C8
	// (set) Token: 0x060016A7 RID: 5799 RVA: 0x000DE1F8 File Offset: 0x000DC3F8
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

	// Token: 0x060016A8 RID: 5800 RVA: 0x000DE228 File Offset: 0x000DC428
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x060016A9 RID: 5801 RVA: 0x000DE260 File Offset: 0x000DC460
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x060016AA RID: 5802 RVA: 0x000DE2BC File Offset: 0x000DC4BC
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x060016AB RID: 5803 RVA: 0x000DE2EC File Offset: 0x000DC4EC
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x060016AC RID: 5804 RVA: 0x000DE324 File Offset: 0x000DC524
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x000DE380 File Offset: 0x000DC580
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x060016AE RID: 5806 RVA: 0x000DE3B0 File Offset: 0x000DC5B0
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x000DE3E8 File Offset: 0x000DC5E8
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x060016B0 RID: 5808 RVA: 0x000DE444 File Offset: 0x000DC644
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x060016B1 RID: 5809 RVA: 0x000DE474 File Offset: 0x000DC674
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x000DE4AC File Offset: 0x000DC6AC
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x000DE508 File Offset: 0x000DC708
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x060016B4 RID: 5812 RVA: 0x000DE538 File Offset: 0x000DC738
	// (set) Token: 0x060016B5 RID: 5813 RVA: 0x000DE568 File Offset: 0x000DC768
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

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016B6 RID: 5814 RVA: 0x000DE598 File Offset: 0x000DC798
	// (set) Token: 0x060016B7 RID: 5815 RVA: 0x000DE5C8 File Offset: 0x000DC7C8
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

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x060016B8 RID: 5816 RVA: 0x000DE5F8 File Offset: 0x000DC7F8
	// (set) Token: 0x060016B9 RID: 5817 RVA: 0x000DE628 File Offset: 0x000DC828
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

	// Token: 0x060016BA RID: 5818 RVA: 0x000DE658 File Offset: 0x000DC858
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x000DE690 File Offset: 0x000DC890
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x000DE6EC File Offset: 0x000DC8EC
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x000DE724 File Offset: 0x000DC924
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x000DE780 File Offset: 0x000DC980
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x000DE7B0 File Offset: 0x000DC9B0
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x060016C0 RID: 5824 RVA: 0x000DE7E0 File Offset: 0x000DC9E0
	// (set) Token: 0x060016C1 RID: 5825 RVA: 0x000DE810 File Offset: 0x000DCA10
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

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x060016C2 RID: 5826 RVA: 0x000DE840 File Offset: 0x000DCA40
	// (set) Token: 0x060016C3 RID: 5827 RVA: 0x000DE870 File Offset: 0x000DCA70
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

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x060016C4 RID: 5828 RVA: 0x000DE8A0 File Offset: 0x000DCAA0
	// (set) Token: 0x060016C5 RID: 5829 RVA: 0x000DE8D0 File Offset: 0x000DCAD0
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

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x060016C6 RID: 5830 RVA: 0x000DE900 File Offset: 0x000DCB00
	// (set) Token: 0x060016C7 RID: 5831 RVA: 0x000DE930 File Offset: 0x000DCB30
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

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x060016C8 RID: 5832 RVA: 0x000DE960 File Offset: 0x000DCB60
	// (set) Token: 0x060016C9 RID: 5833 RVA: 0x000DE990 File Offset: 0x000DCB90
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

	// Token: 0x060016CA RID: 5834 RVA: 0x000DE9C0 File Offset: 0x000DCBC0
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x000DE9F8 File Offset: 0x000DCBF8
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016CC RID: 5836 RVA: 0x000DEA54 File Offset: 0x000DCC54
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016CD RID: 5837 RVA: 0x000DEA84 File Offset: 0x000DCC84
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016CE RID: 5838 RVA: 0x000DEABC File Offset: 0x000DCCBC
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016CF RID: 5839 RVA: 0x000DEB18 File Offset: 0x000DCD18
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x000DEB48 File Offset: 0x000DCD48
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x000DEB78 File Offset: 0x000DCD78
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x000DEBB0 File Offset: 0x000DCDB0
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060016D3 RID: 5843 RVA: 0x000DEC0C File Offset: 0x000DCE0C
	// (set) Token: 0x060016D4 RID: 5844 RVA: 0x000DEC3C File Offset: 0x000DCE3C
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

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060016D5 RID: 5845 RVA: 0x000DEC6C File Offset: 0x000DCE6C
	// (set) Token: 0x060016D6 RID: 5846 RVA: 0x000DEC9C File Offset: 0x000DCE9C
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

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060016D7 RID: 5847 RVA: 0x000DECCC File Offset: 0x000DCECC
	// (set) Token: 0x060016D8 RID: 5848 RVA: 0x000DECFC File Offset: 0x000DCEFC
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

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060016D9 RID: 5849 RVA: 0x000DED2C File Offset: 0x000DCF2C
	// (set) Token: 0x060016DA RID: 5850 RVA: 0x000DED5C File Offset: 0x000DCF5C
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

	// Token: 0x060016DB RID: 5851 RVA: 0x000DED8C File Offset: 0x000DCF8C
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x000DEDBC File Offset: 0x000DCFBC
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x000DEDF4 File Offset: 0x000DCFF4
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060016DE RID: 5854 RVA: 0x000DEE50 File Offset: 0x000DD050
	// (set) Token: 0x060016DF RID: 5855 RVA: 0x000DEE80 File Offset: 0x000DD080
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

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060016E0 RID: 5856 RVA: 0x000DEEB0 File Offset: 0x000DD0B0
	// (set) Token: 0x060016E1 RID: 5857 RVA: 0x000DEEE0 File Offset: 0x000DD0E0
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

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060016E2 RID: 5858 RVA: 0x000DEF10 File Offset: 0x000DD110
	// (set) Token: 0x060016E3 RID: 5859 RVA: 0x000DEF40 File Offset: 0x000DD140
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

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000DEF70 File Offset: 0x000DD170
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000DEFA0 File Offset: 0x000DD1A0
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

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060016E6 RID: 5862 RVA: 0x000DEFD0 File Offset: 0x000DD1D0
	// (set) Token: 0x060016E7 RID: 5863 RVA: 0x000DF000 File Offset: 0x000DD200
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

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060016E8 RID: 5864 RVA: 0x000DF030 File Offset: 0x000DD230
	// (set) Token: 0x060016E9 RID: 5865 RVA: 0x000DF060 File Offset: 0x000DD260
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

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016EA RID: 5866 RVA: 0x000DF090 File Offset: 0x000DD290
	// (set) Token: 0x060016EB RID: 5867 RVA: 0x000DF0C0 File Offset: 0x000DD2C0
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

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060016EC RID: 5868 RVA: 0x000DF0F0 File Offset: 0x000DD2F0
	// (set) Token: 0x060016ED RID: 5869 RVA: 0x000DF120 File Offset: 0x000DD320
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

	// Token: 0x060016EE RID: 5870 RVA: 0x000DF150 File Offset: 0x000DD350
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

	// Token: 0x04002242 RID: 8770
	private const string Str_Money = "Money";

	// Token: 0x04002243 RID: 8771
	private const string Str_Alerts = "Alerts";

	// Token: 0x04002244 RID: 8772
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x04002245 RID: 8773
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x04002246 RID: 8774
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x04002247 RID: 8775
	private const string Str_Friends = "Friends";

	// Token: 0x04002248 RID: 8776
	private const string Str_Headset = "Headset";

	// Token: 0x04002249 RID: 8777
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x0400224A RID: 8778
	private const string Str_FakeID = "FakeID";

	// Token: 0x0400224B RID: 8779
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x0400224C RID: 8780
	private const string Str_Kills = "Kills";

	// Token: 0x0400224D RID: 8781
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x0400224E RID: 8782
	private const string Str_Numbness = "Numbness";

	// Token: 0x0400224F RID: 8783
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002250 RID: 8784
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002251 RID: 8785
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x04002252 RID: 8786
	private const string Str_Photo = "Photo_";

	// Token: 0x04002253 RID: 8787
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x04002254 RID: 8788
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x04002255 RID: 8789
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x04002256 RID: 8790
	private const string Str_Reputation = "Reputation";

	// Token: 0x04002257 RID: 8791
	private const string Str_Seduction = "Seduction";

	// Token: 0x04002258 RID: 8792
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x04002259 RID: 8793
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x0400225A RID: 8794
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x0400225B RID: 8795
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x0400225C RID: 8796
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x0400225D RID: 8797
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x0400225E RID: 8798
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x0400225F RID: 8799
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x04002260 RID: 8800
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x04002261 RID: 8801
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x04002262 RID: 8802
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x04002263 RID: 8803
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x04002264 RID: 8804
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x04002265 RID: 8805
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x04002266 RID: 8806
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x04002267 RID: 8807
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x04002268 RID: 8808
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x04002269 RID: 8809
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x0400226A RID: 8810
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x0400226B RID: 8811
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x0400226C RID: 8812
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x0400226D RID: 8813
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x0400226E RID: 8814
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
