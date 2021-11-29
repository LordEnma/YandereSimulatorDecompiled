using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class PlayerGlobals
{
	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x0600166C RID: 5740 RVA: 0x000DBE4C File Offset: 0x000DA04C
	// (set) Token: 0x0600166D RID: 5741 RVA: 0x000DBE7C File Offset: 0x000DA07C
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
	// (get) Token: 0x0600166E RID: 5742 RVA: 0x000DBEAC File Offset: 0x000DA0AC
	// (set) Token: 0x0600166F RID: 5743 RVA: 0x000DBEDC File Offset: 0x000DA0DC
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
	// (get) Token: 0x06001670 RID: 5744 RVA: 0x000DBF0C File Offset: 0x000DA10C
	// (set) Token: 0x06001671 RID: 5745 RVA: 0x000DBF3C File Offset: 0x000DA13C
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
	// (get) Token: 0x06001672 RID: 5746 RVA: 0x000DBF6C File Offset: 0x000DA16C
	// (set) Token: 0x06001673 RID: 5747 RVA: 0x000DBF9C File Offset: 0x000DA19C
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
	// (get) Token: 0x06001674 RID: 5748 RVA: 0x000DBFCC File Offset: 0x000DA1CC
	// (set) Token: 0x06001675 RID: 5749 RVA: 0x000DBFFC File Offset: 0x000DA1FC
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
	// (get) Token: 0x06001676 RID: 5750 RVA: 0x000DC02C File Offset: 0x000DA22C
	// (set) Token: 0x06001677 RID: 5751 RVA: 0x000DC05C File Offset: 0x000DA25C
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
	// (get) Token: 0x06001678 RID: 5752 RVA: 0x000DC08C File Offset: 0x000DA28C
	// (set) Token: 0x06001679 RID: 5753 RVA: 0x000DC0BC File Offset: 0x000DA2BC
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
	// (get) Token: 0x0600167A RID: 5754 RVA: 0x000DC0EC File Offset: 0x000DA2EC
	// (set) Token: 0x0600167B RID: 5755 RVA: 0x000DC11C File Offset: 0x000DA31C
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
	// (get) Token: 0x0600167C RID: 5756 RVA: 0x000DC14C File Offset: 0x000DA34C
	// (set) Token: 0x0600167D RID: 5757 RVA: 0x000DC17C File Offset: 0x000DA37C
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
	// (get) Token: 0x0600167E RID: 5758 RVA: 0x000DC1AC File Offset: 0x000DA3AC
	// (set) Token: 0x0600167F RID: 5759 RVA: 0x000DC1DC File Offset: 0x000DA3DC
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
	// (get) Token: 0x06001680 RID: 5760 RVA: 0x000DC20C File Offset: 0x000DA40C
	// (set) Token: 0x06001681 RID: 5761 RVA: 0x000DC23C File Offset: 0x000DA43C
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
	// (get) Token: 0x06001682 RID: 5762 RVA: 0x000DC26C File Offset: 0x000DA46C
	// (set) Token: 0x06001683 RID: 5763 RVA: 0x000DC29C File Offset: 0x000DA49C
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
	// (get) Token: 0x06001684 RID: 5764 RVA: 0x000DC2CC File Offset: 0x000DA4CC
	// (set) Token: 0x06001685 RID: 5765 RVA: 0x000DC2FC File Offset: 0x000DA4FC
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
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x000DC32C File Offset: 0x000DA52C
	// (set) Token: 0x06001687 RID: 5767 RVA: 0x000DC35C File Offset: 0x000DA55C
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
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x000DC38C File Offset: 0x000DA58C
	// (set) Token: 0x06001689 RID: 5769 RVA: 0x000DC3BC File Offset: 0x000DA5BC
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

	// Token: 0x0600168A RID: 5770 RVA: 0x000DC3EC File Offset: 0x000DA5EC
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x0600168B RID: 5771 RVA: 0x000DC424 File Offset: 0x000DA624
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x0600168C RID: 5772 RVA: 0x000DC480 File Offset: 0x000DA680
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x0600168D RID: 5773 RVA: 0x000DC4B0 File Offset: 0x000DA6B0
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x0600168E RID: 5774 RVA: 0x000DC4E8 File Offset: 0x000DA6E8
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x0600168F RID: 5775 RVA: 0x000DC544 File Offset: 0x000DA744
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x06001690 RID: 5776 RVA: 0x000DC574 File Offset: 0x000DA774
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x06001691 RID: 5777 RVA: 0x000DC5AC File Offset: 0x000DA7AC
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x06001692 RID: 5778 RVA: 0x000DC608 File Offset: 0x000DA808
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x06001693 RID: 5779 RVA: 0x000DC638 File Offset: 0x000DA838
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x06001694 RID: 5780 RVA: 0x000DC670 File Offset: 0x000DA870
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x06001695 RID: 5781 RVA: 0x000DC6CC File Offset: 0x000DA8CC
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x06001696 RID: 5782 RVA: 0x000DC6FC File Offset: 0x000DA8FC
	// (set) Token: 0x06001697 RID: 5783 RVA: 0x000DC72C File Offset: 0x000DA92C
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
	// (get) Token: 0x06001698 RID: 5784 RVA: 0x000DC75C File Offset: 0x000DA95C
	// (set) Token: 0x06001699 RID: 5785 RVA: 0x000DC78C File Offset: 0x000DA98C
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
	// (get) Token: 0x0600169A RID: 5786 RVA: 0x000DC7BC File Offset: 0x000DA9BC
	// (set) Token: 0x0600169B RID: 5787 RVA: 0x000DC7EC File Offset: 0x000DA9EC
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

	// Token: 0x0600169C RID: 5788 RVA: 0x000DC81C File Offset: 0x000DAA1C
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x0600169D RID: 5789 RVA: 0x000DC854 File Offset: 0x000DAA54
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x0600169E RID: 5790 RVA: 0x000DC8B0 File Offset: 0x000DAAB0
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x0600169F RID: 5791 RVA: 0x000DC8E8 File Offset: 0x000DAAE8
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016A0 RID: 5792 RVA: 0x000DC944 File Offset: 0x000DAB44
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016A1 RID: 5793 RVA: 0x000DC974 File Offset: 0x000DAB74
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016A2 RID: 5794 RVA: 0x000DC9A4 File Offset: 0x000DABA4
	// (set) Token: 0x060016A3 RID: 5795 RVA: 0x000DC9D4 File Offset: 0x000DABD4
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
	// (get) Token: 0x060016A4 RID: 5796 RVA: 0x000DCA04 File Offset: 0x000DAC04
	// (set) Token: 0x060016A5 RID: 5797 RVA: 0x000DCA34 File Offset: 0x000DAC34
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
	// (get) Token: 0x060016A6 RID: 5798 RVA: 0x000DCA64 File Offset: 0x000DAC64
	// (set) Token: 0x060016A7 RID: 5799 RVA: 0x000DCA94 File Offset: 0x000DAC94
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
	// (get) Token: 0x060016A8 RID: 5800 RVA: 0x000DCAC4 File Offset: 0x000DACC4
	// (set) Token: 0x060016A9 RID: 5801 RVA: 0x000DCAF4 File Offset: 0x000DACF4
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
	// (get) Token: 0x060016AA RID: 5802 RVA: 0x000DCB24 File Offset: 0x000DAD24
	// (set) Token: 0x060016AB RID: 5803 RVA: 0x000DCB54 File Offset: 0x000DAD54
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

	// Token: 0x060016AC RID: 5804 RVA: 0x000DCB84 File Offset: 0x000DAD84
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x000DCBBC File Offset: 0x000DADBC
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016AE RID: 5806 RVA: 0x000DCC18 File Offset: 0x000DAE18
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x000DCC48 File Offset: 0x000DAE48
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016B0 RID: 5808 RVA: 0x000DCC80 File Offset: 0x000DAE80
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016B1 RID: 5809 RVA: 0x000DCCDC File Offset: 0x000DAEDC
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x000DCD0C File Offset: 0x000DAF0C
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x000DCD3C File Offset: 0x000DAF3C
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x000DCD74 File Offset: 0x000DAF74
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x060016B5 RID: 5813 RVA: 0x000DCDD0 File Offset: 0x000DAFD0
	// (set) Token: 0x060016B6 RID: 5814 RVA: 0x000DCE00 File Offset: 0x000DB000
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
	// (get) Token: 0x060016B7 RID: 5815 RVA: 0x000DCE30 File Offset: 0x000DB030
	// (set) Token: 0x060016B8 RID: 5816 RVA: 0x000DCE60 File Offset: 0x000DB060
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
	// (get) Token: 0x060016B9 RID: 5817 RVA: 0x000DCE90 File Offset: 0x000DB090
	// (set) Token: 0x060016BA RID: 5818 RVA: 0x000DCEC0 File Offset: 0x000DB0C0
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
	// (get) Token: 0x060016BB RID: 5819 RVA: 0x000DCEF0 File Offset: 0x000DB0F0
	// (set) Token: 0x060016BC RID: 5820 RVA: 0x000DCF20 File Offset: 0x000DB120
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

	// Token: 0x060016BD RID: 5821 RVA: 0x000DCF50 File Offset: 0x000DB150
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x000DCF80 File Offset: 0x000DB180
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x000DCFB8 File Offset: 0x000DB1B8
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060016C0 RID: 5824 RVA: 0x000DD014 File Offset: 0x000DB214
	// (set) Token: 0x060016C1 RID: 5825 RVA: 0x000DD044 File Offset: 0x000DB244
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
	// (get) Token: 0x060016C2 RID: 5826 RVA: 0x000DD074 File Offset: 0x000DB274
	// (set) Token: 0x060016C3 RID: 5827 RVA: 0x000DD0A4 File Offset: 0x000DB2A4
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
	// (get) Token: 0x060016C4 RID: 5828 RVA: 0x000DD0D4 File Offset: 0x000DB2D4
	// (set) Token: 0x060016C5 RID: 5829 RVA: 0x000DD104 File Offset: 0x000DB304
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
	// (get) Token: 0x060016C6 RID: 5830 RVA: 0x000DD134 File Offset: 0x000DB334
	// (set) Token: 0x060016C7 RID: 5831 RVA: 0x000DD164 File Offset: 0x000DB364
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
	// (get) Token: 0x060016C8 RID: 5832 RVA: 0x000DD194 File Offset: 0x000DB394
	// (set) Token: 0x060016C9 RID: 5833 RVA: 0x000DD1C4 File Offset: 0x000DB3C4
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
	// (get) Token: 0x060016CA RID: 5834 RVA: 0x000DD1F4 File Offset: 0x000DB3F4
	// (set) Token: 0x060016CB RID: 5835 RVA: 0x000DD224 File Offset: 0x000DB424
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
	// (get) Token: 0x060016CC RID: 5836 RVA: 0x000DD254 File Offset: 0x000DB454
	// (set) Token: 0x060016CD RID: 5837 RVA: 0x000DD284 File Offset: 0x000DB484
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
	// (get) Token: 0x060016CE RID: 5838 RVA: 0x000DD2B4 File Offset: 0x000DB4B4
	// (set) Token: 0x060016CF RID: 5839 RVA: 0x000DD2E4 File Offset: 0x000DB4E4
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

	// Token: 0x060016D0 RID: 5840 RVA: 0x000DD314 File Offset: 0x000DB514
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

	// Token: 0x040021FA RID: 8698
	private const string Str_Money = "Money";

	// Token: 0x040021FB RID: 8699
	private const string Str_Alerts = "Alerts";

	// Token: 0x040021FC RID: 8700
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x040021FD RID: 8701
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x040021FE RID: 8702
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x040021FF RID: 8703
	private const string Str_Friends = "Friends";

	// Token: 0x04002200 RID: 8704
	private const string Str_Headset = "Headset";

	// Token: 0x04002201 RID: 8705
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x04002202 RID: 8706
	private const string Str_FakeID = "FakeID";

	// Token: 0x04002203 RID: 8707
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x04002204 RID: 8708
	private const string Str_Kills = "Kills";

	// Token: 0x04002205 RID: 8709
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x04002206 RID: 8710
	private const string Str_Numbness = "Numbness";

	// Token: 0x04002207 RID: 8711
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002208 RID: 8712
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002209 RID: 8713
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x0400220A RID: 8714
	private const string Str_Photo = "Photo_";

	// Token: 0x0400220B RID: 8715
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x0400220C RID: 8716
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x0400220D RID: 8717
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x0400220E RID: 8718
	private const string Str_Reputation = "Reputation";

	// Token: 0x0400220F RID: 8719
	private const string Str_Seduction = "Seduction";

	// Token: 0x04002210 RID: 8720
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x04002211 RID: 8721
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x04002212 RID: 8722
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x04002213 RID: 8723
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x04002214 RID: 8724
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x04002215 RID: 8725
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x04002216 RID: 8726
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x04002217 RID: 8727
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x04002218 RID: 8728
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x04002219 RID: 8729
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x0400221A RID: 8730
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x0400221B RID: 8731
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x0400221C RID: 8732
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x0400221D RID: 8733
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x0400221E RID: 8734
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x0400221F RID: 8735
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x04002220 RID: 8736
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x04002221 RID: 8737
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x04002222 RID: 8738
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x04002223 RID: 8739
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x04002224 RID: 8740
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x04002225 RID: 8741
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x04002226 RID: 8742
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
