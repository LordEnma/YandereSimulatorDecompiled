using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class GameGlobals
{
	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015D0 RID: 5584 RVA: 0x000DBF87 File Offset: 0x000DA187
	// (set) Token: 0x060015D1 RID: 5585 RVA: 0x000DBF93 File Offset: 0x000DA193
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
	// (get) Token: 0x060015D2 RID: 5586 RVA: 0x000DBFA0 File Offset: 0x000DA1A0
	// (set) Token: 0x060015D3 RID: 5587 RVA: 0x000DBFAC File Offset: 0x000DA1AC
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
	// (get) Token: 0x060015D4 RID: 5588 RVA: 0x000DBFBC File Offset: 0x000DA1BC
	// (set) Token: 0x060015D5 RID: 5589 RVA: 0x000DBFEC File Offset: 0x000DA1EC
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
	// (get) Token: 0x060015D6 RID: 5590 RVA: 0x000DC01C File Offset: 0x000DA21C
	// (set) Token: 0x060015D7 RID: 5591 RVA: 0x000DC04C File Offset: 0x000DA24C
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
	// (get) Token: 0x060015D8 RID: 5592 RVA: 0x000DC07C File Offset: 0x000DA27C
	// (set) Token: 0x060015D9 RID: 5593 RVA: 0x000DC0AC File Offset: 0x000DA2AC
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
	// (get) Token: 0x060015DA RID: 5594 RVA: 0x000DC0DC File Offset: 0x000DA2DC
	// (set) Token: 0x060015DB RID: 5595 RVA: 0x000DC10C File Offset: 0x000DA30C
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
	// (get) Token: 0x060015DC RID: 5596 RVA: 0x000DC13C File Offset: 0x000DA33C
	// (set) Token: 0x060015DD RID: 5597 RVA: 0x000DC16C File Offset: 0x000DA36C
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
	// (get) Token: 0x060015DE RID: 5598 RVA: 0x000DC19C File Offset: 0x000DA39C
	// (set) Token: 0x060015DF RID: 5599 RVA: 0x000DC1CC File Offset: 0x000DA3CC
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
	// (get) Token: 0x060015E0 RID: 5600 RVA: 0x000DC1FB File Offset: 0x000DA3FB
	// (set) Token: 0x060015E1 RID: 5601 RVA: 0x000DC207 File Offset: 0x000DA407
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
	// (get) Token: 0x060015E2 RID: 5602 RVA: 0x000DC214 File Offset: 0x000DA414
	// (set) Token: 0x060015E3 RID: 5603 RVA: 0x000DC220 File Offset: 0x000DA420
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
	// (get) Token: 0x060015E4 RID: 5604 RVA: 0x000DC22D File Offset: 0x000DA42D
	// (set) Token: 0x060015E5 RID: 5605 RVA: 0x000DC239 File Offset: 0x000DA439
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
	// (get) Token: 0x060015E6 RID: 5606 RVA: 0x000DC248 File Offset: 0x000DA448
	// (set) Token: 0x060015E7 RID: 5607 RVA: 0x000DC278 File Offset: 0x000DA478
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
	// (get) Token: 0x060015E8 RID: 5608 RVA: 0x000DC2A8 File Offset: 0x000DA4A8
	// (set) Token: 0x060015E9 RID: 5609 RVA: 0x000DC2D8 File Offset: 0x000DA4D8
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
	// (get) Token: 0x060015EA RID: 5610 RVA: 0x000DC308 File Offset: 0x000DA508
	// (set) Token: 0x060015EB RID: 5611 RVA: 0x000DC338 File Offset: 0x000DA538
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
	// (get) Token: 0x060015EC RID: 5612 RVA: 0x000DC368 File Offset: 0x000DA568
	// (set) Token: 0x060015ED RID: 5613 RVA: 0x000DC398 File Offset: 0x000DA598
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
	// (get) Token: 0x060015EE RID: 5614 RVA: 0x000DC3C8 File Offset: 0x000DA5C8
	// (set) Token: 0x060015EF RID: 5615 RVA: 0x000DC3F8 File Offset: 0x000DA5F8
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
	// (get) Token: 0x060015F0 RID: 5616 RVA: 0x000DC427 File Offset: 0x000DA627
	// (set) Token: 0x060015F1 RID: 5617 RVA: 0x000DC433 File Offset: 0x000DA633
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
	// (get) Token: 0x060015F2 RID: 5618 RVA: 0x000DC440 File Offset: 0x000DA640
	// (set) Token: 0x060015F3 RID: 5619 RVA: 0x000DC470 File Offset: 0x000DA670
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
	// (get) Token: 0x060015F4 RID: 5620 RVA: 0x000DC4A0 File Offset: 0x000DA6A0
	// (set) Token: 0x060015F5 RID: 5621 RVA: 0x000DC4D0 File Offset: 0x000DA6D0
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
	// (get) Token: 0x060015F6 RID: 5622 RVA: 0x000DC500 File Offset: 0x000DA700
	// (set) Token: 0x060015F7 RID: 5623 RVA: 0x000DC530 File Offset: 0x000DA730
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
	// (get) Token: 0x060015F8 RID: 5624 RVA: 0x000DC560 File Offset: 0x000DA760
	// (set) Token: 0x060015F9 RID: 5625 RVA: 0x000DC590 File Offset: 0x000DA790
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
	// (get) Token: 0x060015FA RID: 5626 RVA: 0x000DC5C0 File Offset: 0x000DA7C0
	// (set) Token: 0x060015FB RID: 5627 RVA: 0x000DC5F0 File Offset: 0x000DA7F0
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
	// (get) Token: 0x060015FC RID: 5628 RVA: 0x000DC620 File Offset: 0x000DA820
	// (set) Token: 0x060015FD RID: 5629 RVA: 0x000DC650 File Offset: 0x000DA850
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
	// (get) Token: 0x060015FE RID: 5630 RVA: 0x000DC680 File Offset: 0x000DA880
	// (set) Token: 0x060015FF RID: 5631 RVA: 0x000DC6B0 File Offset: 0x000DA8B0
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
	// (get) Token: 0x06001600 RID: 5632 RVA: 0x000DC6E0 File Offset: 0x000DA8E0
	// (set) Token: 0x06001601 RID: 5633 RVA: 0x000DC710 File Offset: 0x000DA910
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
	// (get) Token: 0x06001602 RID: 5634 RVA: 0x000DC740 File Offset: 0x000DA940
	// (set) Token: 0x06001603 RID: 5635 RVA: 0x000DC770 File Offset: 0x000DA970
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
	// (get) Token: 0x06001604 RID: 5636 RVA: 0x000DC7A0 File Offset: 0x000DA9A0
	// (set) Token: 0x06001605 RID: 5637 RVA: 0x000DC7D0 File Offset: 0x000DA9D0
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
	// (get) Token: 0x06001606 RID: 5638 RVA: 0x000DC800 File Offset: 0x000DAA00
	// (set) Token: 0x06001607 RID: 5639 RVA: 0x000DC830 File Offset: 0x000DAA30
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
	// (get) Token: 0x06001608 RID: 5640 RVA: 0x000DC860 File Offset: 0x000DAA60
	// (set) Token: 0x06001609 RID: 5641 RVA: 0x000DC890 File Offset: 0x000DAA90
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
	// (get) Token: 0x0600160A RID: 5642 RVA: 0x000DC8C0 File Offset: 0x000DAAC0
	// (set) Token: 0x0600160B RID: 5643 RVA: 0x000DC8F0 File Offset: 0x000DAAF0
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
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DC920 File Offset: 0x000DAB20
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DC950 File Offset: 0x000DAB50
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
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DC97F File Offset: 0x000DAB7F
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DC98B File Offset: 0x000DAB8B
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
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DC998 File Offset: 0x000DAB98
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DC9C8 File Offset: 0x000DABC8
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
	// (get) Token: 0x06001612 RID: 5650 RVA: 0x000DC9F8 File Offset: 0x000DABF8
	// (set) Token: 0x06001613 RID: 5651 RVA: 0x000DCA28 File Offset: 0x000DAC28
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
	// (get) Token: 0x06001614 RID: 5652 RVA: 0x000DCA58 File Offset: 0x000DAC58
	// (set) Token: 0x06001615 RID: 5653 RVA: 0x000DCA88 File Offset: 0x000DAC88
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
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000DCAB8 File Offset: 0x000DACB8
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000DCAE8 File Offset: 0x000DACE8
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
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DCB18 File Offset: 0x000DAD18
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DCB48 File Offset: 0x000DAD48
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

	// Token: 0x0600161A RID: 5658 RVA: 0x000DCB78 File Offset: 0x000DAD78
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x0600161B RID: 5659 RVA: 0x000DCBB0 File Offset: 0x000DADB0
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x0600161C RID: 5660 RVA: 0x000DCC0C File Offset: 0x000DAE0C
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x0600161D RID: 5661 RVA: 0x000DCC3C File Offset: 0x000DAE3C
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x0600161E RID: 5662 RVA: 0x000DCC74 File Offset: 0x000DAE74
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x0600161F RID: 5663 RVA: 0x000DCCD0 File Offset: 0x000DAED0
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DCD00 File Offset: 0x000DAF00
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DCD30 File Offset: 0x000DAF30
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
	// (get) Token: 0x06001622 RID: 5666 RVA: 0x000DCD60 File Offset: 0x000DAF60
	// (set) Token: 0x06001623 RID: 5667 RVA: 0x000DCD90 File Offset: 0x000DAF90
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
	// (get) Token: 0x06001624 RID: 5668 RVA: 0x000DCDC0 File Offset: 0x000DAFC0
	// (set) Token: 0x06001625 RID: 5669 RVA: 0x000DCDF0 File Offset: 0x000DAFF0
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
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DCE20 File Offset: 0x000DB020
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DCE50 File Offset: 0x000DB050
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
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DCE7F File Offset: 0x000DB07F
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DCE8B File Offset: 0x000DB08B
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
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DCE98 File Offset: 0x000DB098
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DCEA4 File Offset: 0x000DB0A4
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

	// Token: 0x0600162C RID: 5676 RVA: 0x000DCEB4 File Offset: 0x000DB0B4
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

	// Token: 0x04002215 RID: 8725
	private const string Str_Profile = "Profile";

	// Token: 0x04002216 RID: 8726
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x04002217 RID: 8727
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x04002218 RID: 8728
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x04002219 RID: 8729
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x0400221A RID: 8730
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x0400221B RID: 8731
	private const string Str_HardMode = "HardMode";

	// Token: 0x0400221C RID: 8732
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x0400221D RID: 8733
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x0400221E RID: 8734
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x0400221F RID: 8735
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x04002220 RID: 8736
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x04002221 RID: 8737
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x04002222 RID: 8738
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x04002223 RID: 8739
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x04002224 RID: 8740
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x04002225 RID: 8741
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x04002226 RID: 8742
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x04002227 RID: 8743
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x04002228 RID: 8744
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x04002229 RID: 8745
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x0400222A RID: 8746
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x0400222B RID: 8747
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x0400222C RID: 8748
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x0400222D RID: 8749
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x0400222E RID: 8750
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x0400222F RID: 8751
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x04002230 RID: 8752
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x04002231 RID: 8753
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x04002232 RID: 8754
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x04002233 RID: 8755
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x04002234 RID: 8756
	private const string Str_Eighties = "Eighties";

	// Token: 0x04002235 RID: 8757
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x04002236 RID: 8758
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x04002237 RID: 8759
	private const string Str_Debug = "Debug";

	// Token: 0x04002238 RID: 8760
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x04002239 RID: 8761
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x0400223A RID: 8762
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x0400223B RID: 8763
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x0400223C RID: 8764
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x0400223D RID: 8765
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x0400223E RID: 8766
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x0400223F RID: 8767
	private const string Str_AbductionTarget = "AbductionTarget";

	// Token: 0x04002240 RID: 8768
	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";

	// Token: 0x04002241 RID: 8769
	private const string Str_VtuberID = "VtuberID";
}
