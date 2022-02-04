using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class PlayerGlobals
{
	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x06001678 RID: 5752 RVA: 0x000DD144 File Offset: 0x000DB344
	// (set) Token: 0x06001679 RID: 5753 RVA: 0x000DD174 File Offset: 0x000DB374
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

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x0600167A RID: 5754 RVA: 0x000DD1A4 File Offset: 0x000DB3A4
	// (set) Token: 0x0600167B RID: 5755 RVA: 0x000DD1D4 File Offset: 0x000DB3D4
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

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x0600167C RID: 5756 RVA: 0x000DD204 File Offset: 0x000DB404
	// (set) Token: 0x0600167D RID: 5757 RVA: 0x000DD234 File Offset: 0x000DB434
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

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x0600167E RID: 5758 RVA: 0x000DD264 File Offset: 0x000DB464
	// (set) Token: 0x0600167F RID: 5759 RVA: 0x000DD294 File Offset: 0x000DB494
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

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x06001680 RID: 5760 RVA: 0x000DD2C4 File Offset: 0x000DB4C4
	// (set) Token: 0x06001681 RID: 5761 RVA: 0x000DD2F4 File Offset: 0x000DB4F4
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

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x06001682 RID: 5762 RVA: 0x000DD324 File Offset: 0x000DB524
	// (set) Token: 0x06001683 RID: 5763 RVA: 0x000DD354 File Offset: 0x000DB554
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

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x06001684 RID: 5764 RVA: 0x000DD384 File Offset: 0x000DB584
	// (set) Token: 0x06001685 RID: 5765 RVA: 0x000DD3B4 File Offset: 0x000DB5B4
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

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x000DD3E4 File Offset: 0x000DB5E4
	// (set) Token: 0x06001687 RID: 5767 RVA: 0x000DD414 File Offset: 0x000DB614
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

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x000DD444 File Offset: 0x000DB644
	// (set) Token: 0x06001689 RID: 5769 RVA: 0x000DD474 File Offset: 0x000DB674
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

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x000DD4A4 File Offset: 0x000DB6A4
	// (set) Token: 0x0600168B RID: 5771 RVA: 0x000DD4D4 File Offset: 0x000DB6D4
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

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x000DD504 File Offset: 0x000DB704
	// (set) Token: 0x0600168D RID: 5773 RVA: 0x000DD534 File Offset: 0x000DB734
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

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x000DD564 File Offset: 0x000DB764
	// (set) Token: 0x0600168F RID: 5775 RVA: 0x000DD594 File Offset: 0x000DB794
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

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x000DD5C4 File Offset: 0x000DB7C4
	// (set) Token: 0x06001691 RID: 5777 RVA: 0x000DD5F4 File Offset: 0x000DB7F4
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

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x06001692 RID: 5778 RVA: 0x000DD624 File Offset: 0x000DB824
	// (set) Token: 0x06001693 RID: 5779 RVA: 0x000DD654 File Offset: 0x000DB854
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

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x06001694 RID: 5780 RVA: 0x000DD684 File Offset: 0x000DB884
	// (set) Token: 0x06001695 RID: 5781 RVA: 0x000DD6B4 File Offset: 0x000DB8B4
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

	// Token: 0x06001696 RID: 5782 RVA: 0x000DD6E4 File Offset: 0x000DB8E4
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x000DD71C File Offset: 0x000DB91C
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x000DD778 File Offset: 0x000DB978
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x06001699 RID: 5785 RVA: 0x000DD7A8 File Offset: 0x000DB9A8
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x0600169A RID: 5786 RVA: 0x000DD7E0 File Offset: 0x000DB9E0
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x0600169B RID: 5787 RVA: 0x000DD83C File Offset: 0x000DBA3C
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x0600169C RID: 5788 RVA: 0x000DD86C File Offset: 0x000DBA6C
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x0600169D RID: 5789 RVA: 0x000DD8A4 File Offset: 0x000DBAA4
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x0600169E RID: 5790 RVA: 0x000DD900 File Offset: 0x000DBB00
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x0600169F RID: 5791 RVA: 0x000DD930 File Offset: 0x000DBB30
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x060016A0 RID: 5792 RVA: 0x000DD968 File Offset: 0x000DBB68
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x060016A1 RID: 5793 RVA: 0x000DD9C4 File Offset: 0x000DBBC4
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x060016A2 RID: 5794 RVA: 0x000DD9F4 File Offset: 0x000DBBF4
	// (set) Token: 0x060016A3 RID: 5795 RVA: 0x000DDA24 File Offset: 0x000DBC24
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

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x060016A4 RID: 5796 RVA: 0x000DDA54 File Offset: 0x000DBC54
	// (set) Token: 0x060016A5 RID: 5797 RVA: 0x000DDA84 File Offset: 0x000DBC84
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

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x060016A6 RID: 5798 RVA: 0x000DDAB4 File Offset: 0x000DBCB4
	// (set) Token: 0x060016A7 RID: 5799 RVA: 0x000DDAE4 File Offset: 0x000DBCE4
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

	// Token: 0x060016A8 RID: 5800 RVA: 0x000DDB14 File Offset: 0x000DBD14
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x060016A9 RID: 5801 RVA: 0x000DDB4C File Offset: 0x000DBD4C
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x060016AA RID: 5802 RVA: 0x000DDBA8 File Offset: 0x000DBDA8
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x060016AB RID: 5803 RVA: 0x000DDBE0 File Offset: 0x000DBDE0
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016AC RID: 5804 RVA: 0x000DDC3C File Offset: 0x000DBE3C
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x000DDC6C File Offset: 0x000DBE6C
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016AE RID: 5806 RVA: 0x000DDC9C File Offset: 0x000DBE9C
	// (set) Token: 0x060016AF RID: 5807 RVA: 0x000DDCCC File Offset: 0x000DBECC
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

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x060016B0 RID: 5808 RVA: 0x000DDCFC File Offset: 0x000DBEFC
	// (set) Token: 0x060016B1 RID: 5809 RVA: 0x000DDD2C File Offset: 0x000DBF2C
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

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x060016B2 RID: 5810 RVA: 0x000DDD5C File Offset: 0x000DBF5C
	// (set) Token: 0x060016B3 RID: 5811 RVA: 0x000DDD8C File Offset: 0x000DBF8C
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

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x060016B4 RID: 5812 RVA: 0x000DDDBC File Offset: 0x000DBFBC
	// (set) Token: 0x060016B5 RID: 5813 RVA: 0x000DDDEC File Offset: 0x000DBFEC
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

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x060016B6 RID: 5814 RVA: 0x000DDE1C File Offset: 0x000DC01C
	// (set) Token: 0x060016B7 RID: 5815 RVA: 0x000DDE4C File Offset: 0x000DC04C
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

	// Token: 0x060016B8 RID: 5816 RVA: 0x000DDE7C File Offset: 0x000DC07C
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x000DDEB4 File Offset: 0x000DC0B4
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x000DDF10 File Offset: 0x000DC110
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x000DDF40 File Offset: 0x000DC140
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x000DDF78 File Offset: 0x000DC178
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x000DDFD4 File Offset: 0x000DC1D4
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x000DE004 File Offset: 0x000DC204
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x000DE034 File Offset: 0x000DC234
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x000DE06C File Offset: 0x000DC26C
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x060016C1 RID: 5825 RVA: 0x000DE0C8 File Offset: 0x000DC2C8
	// (set) Token: 0x060016C2 RID: 5826 RVA: 0x000DE0F8 File Offset: 0x000DC2F8
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

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x060016C3 RID: 5827 RVA: 0x000DE128 File Offset: 0x000DC328
	// (set) Token: 0x060016C4 RID: 5828 RVA: 0x000DE158 File Offset: 0x000DC358
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

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060016C5 RID: 5829 RVA: 0x000DE188 File Offset: 0x000DC388
	// (set) Token: 0x060016C6 RID: 5830 RVA: 0x000DE1B8 File Offset: 0x000DC3B8
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

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060016C7 RID: 5831 RVA: 0x000DE1E8 File Offset: 0x000DC3E8
	// (set) Token: 0x060016C8 RID: 5832 RVA: 0x000DE218 File Offset: 0x000DC418
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

	// Token: 0x060016C9 RID: 5833 RVA: 0x000DE248 File Offset: 0x000DC448
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x000DE278 File Offset: 0x000DC478
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x000DE2B0 File Offset: 0x000DC4B0
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060016CC RID: 5836 RVA: 0x000DE30C File Offset: 0x000DC50C
	// (set) Token: 0x060016CD RID: 5837 RVA: 0x000DE33C File Offset: 0x000DC53C
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

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060016CE RID: 5838 RVA: 0x000DE36C File Offset: 0x000DC56C
	// (set) Token: 0x060016CF RID: 5839 RVA: 0x000DE39C File Offset: 0x000DC59C
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

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060016D0 RID: 5840 RVA: 0x000DE3CC File Offset: 0x000DC5CC
	// (set) Token: 0x060016D1 RID: 5841 RVA: 0x000DE3FC File Offset: 0x000DC5FC
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

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060016D2 RID: 5842 RVA: 0x000DE42C File Offset: 0x000DC62C
	// (set) Token: 0x060016D3 RID: 5843 RVA: 0x000DE45C File Offset: 0x000DC65C
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

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060016D4 RID: 5844 RVA: 0x000DE48C File Offset: 0x000DC68C
	// (set) Token: 0x060016D5 RID: 5845 RVA: 0x000DE4BC File Offset: 0x000DC6BC
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

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060016D6 RID: 5846 RVA: 0x000DE4EC File Offset: 0x000DC6EC
	// (set) Token: 0x060016D7 RID: 5847 RVA: 0x000DE51C File Offset: 0x000DC71C
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

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000DE54C File Offset: 0x000DC74C
	// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000DE57C File Offset: 0x000DC77C
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

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060016DA RID: 5850 RVA: 0x000DE5AC File Offset: 0x000DC7AC
	// (set) Token: 0x060016DB RID: 5851 RVA: 0x000DE5DC File Offset: 0x000DC7DC
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

	// Token: 0x060016DC RID: 5852 RVA: 0x000DE60C File Offset: 0x000DC80C
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

	// Token: 0x0400222A RID: 8746
	private const string Str_Money = "Money";

	// Token: 0x0400222B RID: 8747
	private const string Str_Alerts = "Alerts";

	// Token: 0x0400222C RID: 8748
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x0400222D RID: 8749
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x0400222E RID: 8750
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x0400222F RID: 8751
	private const string Str_Friends = "Friends";

	// Token: 0x04002230 RID: 8752
	private const string Str_Headset = "Headset";

	// Token: 0x04002231 RID: 8753
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x04002232 RID: 8754
	private const string Str_FakeID = "FakeID";

	// Token: 0x04002233 RID: 8755
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x04002234 RID: 8756
	private const string Str_Kills = "Kills";

	// Token: 0x04002235 RID: 8757
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x04002236 RID: 8758
	private const string Str_Numbness = "Numbness";

	// Token: 0x04002237 RID: 8759
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002238 RID: 8760
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002239 RID: 8761
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x0400223A RID: 8762
	private const string Str_Photo = "Photo_";

	// Token: 0x0400223B RID: 8763
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x0400223C RID: 8764
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x0400223D RID: 8765
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x0400223E RID: 8766
	private const string Str_Reputation = "Reputation";

	// Token: 0x0400223F RID: 8767
	private const string Str_Seduction = "Seduction";

	// Token: 0x04002240 RID: 8768
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x04002241 RID: 8769
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x04002242 RID: 8770
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x04002243 RID: 8771
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x04002244 RID: 8772
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x04002245 RID: 8773
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x04002246 RID: 8774
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x04002247 RID: 8775
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x04002248 RID: 8776
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x04002249 RID: 8777
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x0400224A RID: 8778
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x0400224B RID: 8779
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x0400224C RID: 8780
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x0400224D RID: 8781
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x0400224E RID: 8782
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x0400224F RID: 8783
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x04002250 RID: 8784
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x04002251 RID: 8785
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x04002252 RID: 8786
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x04002253 RID: 8787
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x04002254 RID: 8788
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x04002255 RID: 8789
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x04002256 RID: 8790
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
