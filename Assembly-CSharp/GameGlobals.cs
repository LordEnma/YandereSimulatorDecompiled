using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class GameGlobals
{
	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015D8 RID: 5592 RVA: 0x000DC90F File Offset: 0x000DAB0F
	// (set) Token: 0x060015D9 RID: 5593 RVA: 0x000DC91B File Offset: 0x000DAB1B
	public static int Profile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile", value);
		}
	}

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x060015DA RID: 5594 RVA: 0x000DC928 File Offset: 0x000DAB28
	// (set) Token: 0x060015DB RID: 5595 RVA: 0x000DC934 File Offset: 0x000DAB34
	public static int MostRecentSlot
	{
		get
		{
			return PlayerPrefs.GetInt("MostRecentSlot");
		}
		set
		{
			PlayerPrefs.SetInt("MostRecentSlot", value);
		}
	}

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x060015DC RID: 5596 RVA: 0x000DC944 File Offset: 0x000DAB44
	// (set) Token: 0x060015DD RID: 5597 RVA: 0x000DC974 File Offset: 0x000DAB74
	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick", value);
		}
	}

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x060015DE RID: 5598 RVA: 0x000DC9A4 File Offset: 0x000DABA4
	// (set) Token: 0x060015DF RID: 5599 RVA: 0x000DC9D4 File Offset: 0x000DABD4
	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned", value);
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x060015E0 RID: 5600 RVA: 0x000DCA04 File Offset: 0x000DAC04
	// (set) Token: 0x060015E1 RID: 5601 RVA: 0x000DCA34 File Offset: 0x000DAC34
	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal", value);
		}
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x060015E2 RID: 5602 RVA: 0x000DCA64 File Offset: 0x000DAC64
	// (set) Token: 0x060015E3 RID: 5603 RVA: 0x000DCA94 File Offset: 0x000DAC94
	public static bool EasyMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode", value);
		}
	}

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x060015E4 RID: 5604 RVA: 0x000DCAC4 File Offset: 0x000DACC4
	// (set) Token: 0x060015E5 RID: 5605 RVA: 0x000DCAF4 File Offset: 0x000DACF4
	public static bool HardMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode", value);
		}
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x060015E6 RID: 5606 RVA: 0x000DCB24 File Offset: 0x000DAD24
	// (set) Token: 0x060015E7 RID: 5607 RVA: 0x000DCB54 File Offset: 0x000DAD54
	public static bool EmptyDemon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon", value);
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x060015E8 RID: 5608 RVA: 0x000DCB83 File Offset: 0x000DAD83
	// (set) Token: 0x060015E9 RID: 5609 RVA: 0x000DCB8F File Offset: 0x000DAD8F
	public static bool CensorBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorBlood", value);
		}
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x060015EA RID: 5610 RVA: 0x000DCB9C File Offset: 0x000DAD9C
	// (set) Token: 0x060015EB RID: 5611 RVA: 0x000DCBA8 File Offset: 0x000DADA8
	public static bool CensorPanties
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorPanties");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorPanties", value);
		}
	}

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x060015EC RID: 5612 RVA: 0x000DCBB5 File Offset: 0x000DADB5
	// (set) Token: 0x060015ED RID: 5613 RVA: 0x000DCBC1 File Offset: 0x000DADC1
	public static bool CensorKillingAnims
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorKillingAnims");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorKillingAnims", value);
		}
	}

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x060015EE RID: 5614 RVA: 0x000DCBD0 File Offset: 0x000DADD0
	// (set) Token: 0x060015EF RID: 5615 RVA: 0x000DCC00 File Offset: 0x000DAE00
	public static bool SpareUniform
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform", value);
		}
	}

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x060015F0 RID: 5616 RVA: 0x000DCC30 File Offset: 0x000DAE30
	// (set) Token: 0x060015F1 RID: 5617 RVA: 0x000DCC60 File Offset: 0x000DAE60
	public static bool BlondeHair
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair", value);
		}
	}

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x060015F2 RID: 5618 RVA: 0x000DCC90 File Offset: 0x000DAE90
	// (set) Token: 0x060015F3 RID: 5619 RVA: 0x000DCCC0 File Offset: 0x000DAEC0
	public static bool SenpaiMourning
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning", value);
		}
	}

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x060015F4 RID: 5620 RVA: 0x000DCCF0 File Offset: 0x000DAEF0
	// (set) Token: 0x060015F5 RID: 5621 RVA: 0x000DCD20 File Offset: 0x000DAF20
	public static int RivalEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID", value);
		}
	}

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x060015F6 RID: 5622 RVA: 0x000DCD50 File Offset: 0x000DAF50
	// (set) Token: 0x060015F7 RID: 5623 RVA: 0x000DCD80 File Offset: 0x000DAF80
	public static int SpecificEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID", value);
		}
	}

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x060015F8 RID: 5624 RVA: 0x000DCDAF File Offset: 0x000DAFAF
	// (set) Token: 0x060015F9 RID: 5625 RVA: 0x000DCDBB File Offset: 0x000DAFBB
	public static bool NonlethalElimination
	{
		get
		{
			return GlobalsHelper.GetBool("NonlethalElimination");
		}
		set
		{
			GlobalsHelper.SetBool("NonlethalElimination", value);
		}
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x060015FA RID: 5626 RVA: 0x000DCDC8 File Offset: 0x000DAFC8
	// (set) Token: 0x060015FB RID: 5627 RVA: 0x000DCDF8 File Offset: 0x000DAFF8
	public static bool ReputationsInitialized
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized", value);
		}
	}

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x060015FC RID: 5628 RVA: 0x000DCE28 File Offset: 0x000DB028
	// (set) Token: 0x060015FD RID: 5629 RVA: 0x000DCE58 File Offset: 0x000DB058
	public static bool AnswerSheetUnavailable
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable", value);
		}
	}

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x060015FE RID: 5630 RVA: 0x000DCE88 File Offset: 0x000DB088
	// (set) Token: 0x060015FF RID: 5631 RVA: 0x000DCEB8 File Offset: 0x000DB0B8
	public static bool AlphabetMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode", value);
		}
	}

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x06001600 RID: 5632 RVA: 0x000DCEE8 File Offset: 0x000DB0E8
	// (set) Token: 0x06001601 RID: 5633 RVA: 0x000DCF18 File Offset: 0x000DB118
	public static bool PoliceYesterday
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday", value);
		}
	}

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x06001602 RID: 5634 RVA: 0x000DCF48 File Offset: 0x000DB148
	// (set) Token: 0x06001603 RID: 5635 RVA: 0x000DCF78 File Offset: 0x000DB178
	public static bool DarkEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding", value);
		}
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06001604 RID: 5636 RVA: 0x000DCFA8 File Offset: 0x000DB1A8
	// (set) Token: 0x06001605 RID: 5637 RVA: 0x000DCFD8 File Offset: 0x000DB1D8
	public static bool SenpaiSawOsanaCorpse
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse", value);
		}
	}

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x06001606 RID: 5638 RVA: 0x000DD008 File Offset: 0x000DB208
	// (set) Token: 0x06001607 RID: 5639 RVA: 0x000DD038 File Offset: 0x000DB238
	public static bool TransitionToPostCredits
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits", value);
		}
	}

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06001608 RID: 5640 RVA: 0x000DD068 File Offset: 0x000DB268
	// (set) Token: 0x06001609 RID: 5641 RVA: 0x000DD098 File Offset: 0x000DB298
	public static bool PlayerHasBeatenDemo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo", value);
		}
	}

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x0600160A RID: 5642 RVA: 0x000DD0C8 File Offset: 0x000DB2C8
	// (set) Token: 0x0600160B RID: 5643 RVA: 0x000DD0F8 File Offset: 0x000DB2F8
	public static bool InformedAboutSkipping
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping", value);
		}
	}

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DD128 File Offset: 0x000DB328
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DD158 File Offset: 0x000DB358
	public static bool RingStolen
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen", value);
		}
	}

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DD188 File Offset: 0x000DB388
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DD1B8 File Offset: 0x000DB3B8
	public static int BeatEmUpDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty", value);
		}
	}

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DD1E8 File Offset: 0x000DB3E8
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DD218 File Offset: 0x000DB418
	public static bool BeatEmUpSuccess
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess", value);
		}
	}

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x06001612 RID: 5650 RVA: 0x000DD248 File Offset: 0x000DB448
	// (set) Token: 0x06001613 RID: 5651 RVA: 0x000DD278 File Offset: 0x000DB478
	public static int EightiesCutsceneID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID", value);
		}
	}

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x06001614 RID: 5652 RVA: 0x000DD2A8 File Offset: 0x000DB4A8
	// (set) Token: 0x06001615 RID: 5653 RVA: 0x000DD2D8 File Offset: 0x000DB4D8
	public static bool EightiesTutorial
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial", value);
		}
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000DD307 File Offset: 0x000DB507
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000DD313 File Offset: 0x000DB513
	public static bool Eighties
	{
		get
		{
			return GlobalsHelper.GetBool("Eighties");
		}
		set
		{
			GlobalsHelper.SetBool("Eighties", value);
		}
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DD320 File Offset: 0x000DB520
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DD350 File Offset: 0x000DB550
	public static int YakuzaPhase
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase", value);
		}
	}

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x0600161A RID: 5658 RVA: 0x000DD380 File Offset: 0x000DB580
	// (set) Token: 0x0600161B RID: 5659 RVA: 0x000DD3B0 File Offset: 0x000DB5B0
	public static bool MetBarber
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber", value);
		}
	}

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DD3E0 File Offset: 0x000DB5E0
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DD410 File Offset: 0x000DB610
	public static bool IntroducedAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction", value);
		}
	}

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DD440 File Offset: 0x000DB640
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DD470 File Offset: 0x000DB670
	public static bool IntroducedRansom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom", value);
		}
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DD4A0 File Offset: 0x000DB6A0
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DD4D0 File Offset: 0x000DB6D0
	public static bool Debug
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug", value);
		}
	}

	// Token: 0x06001622 RID: 5666 RVA: 0x000DD500 File Offset: 0x000DB700
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x06001623 RID: 5667 RVA: 0x000DD538 File Offset: 0x000DB738
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x06001624 RID: 5668 RVA: 0x000DD594 File Offset: 0x000DB794
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x06001625 RID: 5669 RVA: 0x000DD5C4 File Offset: 0x000DB7C4
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x000DD5FC File Offset: 0x000DB7FC
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x000DD658 File Offset: 0x000DB858
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DD688 File Offset: 0x000DB888
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DD6B8 File Offset: 0x000DB8B8
	public static bool TrueEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding", value);
		}
	}

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DD6E8 File Offset: 0x000DB8E8
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DD718 File Offset: 0x000DB918
	public static bool JustKidnapped
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped", value);
		}
	}

	// Token: 0x170003BE RID: 958
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DD748 File Offset: 0x000DB948
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DD778 File Offset: 0x000DB978
	public static bool ShowAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction", value);
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DD7A8 File Offset: 0x000DB9A8
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DD7D8 File Offset: 0x000DB9D8
	public static int AbductionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget", value);
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DD807 File Offset: 0x000DBA07
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DD813 File Offset: 0x000DBA13
	public static bool CameFromTitleScreen
	{
		get
		{
			return GlobalsHelper.GetBool("CameFromTitleScreen");
		}
		set
		{
			GlobalsHelper.SetBool("CameFromTitleScreen", value);
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x000DD820 File Offset: 0x000DBA20
	// (set) Token: 0x06001633 RID: 5683 RVA: 0x000DD82C File Offset: 0x000DBA2C
	public static int VtuberID
	{
		get
		{
			return PlayerPrefs.GetInt("VtuberID");
		}
		set
		{
			PlayerPrefs.SetInt("VtuberID", value);
		}
	}

	// Token: 0x06001634 RID: 5684 RVA: 0x000DD83C File Offset: 0x000DBA3C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorBlood");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorPanties");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorKillingAnims");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NonlethalElimination");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MostRecentSlot");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Eighties");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CameFromTitleScreen");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VtuberID");
		for (int i = 1; i < 11; i++)
		{
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", GameGlobals.KeysOfRivalEliminations());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", GameGlobals.KeysOfSpecificEliminations());
	}

	// Token: 0x04002229 RID: 8745
	private const string Str_Profile = "Profile";

	// Token: 0x0400222A RID: 8746
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x0400222B RID: 8747
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x0400222C RID: 8748
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x0400222D RID: 8749
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x0400222E RID: 8750
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x0400222F RID: 8751
	private const string Str_HardMode = "HardMode";

	// Token: 0x04002230 RID: 8752
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x04002231 RID: 8753
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x04002232 RID: 8754
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x04002233 RID: 8755
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x04002234 RID: 8756
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x04002235 RID: 8757
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x04002236 RID: 8758
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x04002237 RID: 8759
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x04002238 RID: 8760
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x04002239 RID: 8761
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x0400223A RID: 8762
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x0400223B RID: 8763
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x0400223C RID: 8764
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x0400223D RID: 8765
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x0400223E RID: 8766
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x0400223F RID: 8767
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x04002240 RID: 8768
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x04002241 RID: 8769
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x04002242 RID: 8770
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x04002243 RID: 8771
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x04002244 RID: 8772
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x04002245 RID: 8773
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x04002246 RID: 8774
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x04002247 RID: 8775
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x04002248 RID: 8776
	private const string Str_Eighties = "Eighties";

	// Token: 0x04002249 RID: 8777
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x0400224A RID: 8778
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x0400224B RID: 8779
	private const string Str_Debug = "Debug";

	// Token: 0x0400224C RID: 8780
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x0400224D RID: 8781
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x0400224E RID: 8782
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x0400224F RID: 8783
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x04002250 RID: 8784
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x04002251 RID: 8785
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x04002252 RID: 8786
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x04002253 RID: 8787
	private const string Str_AbductionTarget = "AbductionTarget";

	// Token: 0x04002254 RID: 8788
	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";

	// Token: 0x04002255 RID: 8789
	private const string Str_VtuberID = "VtuberID";
}
