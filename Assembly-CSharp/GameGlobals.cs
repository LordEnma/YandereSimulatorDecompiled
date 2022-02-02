using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class GameGlobals
{
	// Token: 0x17000396 RID: 918
	// (get) Token: 0x060015B1 RID: 5553 RVA: 0x000DA613 File Offset: 0x000D8813
	// (set) Token: 0x060015B2 RID: 5554 RVA: 0x000DA61F File Offset: 0x000D881F
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

	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000DA62C File Offset: 0x000D882C
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000DA638 File Offset: 0x000D8838
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

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DA648 File Offset: 0x000D8848
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DA678 File Offset: 0x000D8878
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

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x060015B7 RID: 5559 RVA: 0x000DA6A8 File Offset: 0x000D88A8
	// (set) Token: 0x060015B8 RID: 5560 RVA: 0x000DA6D8 File Offset: 0x000D88D8
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

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x060015B9 RID: 5561 RVA: 0x000DA708 File Offset: 0x000D8908
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x000DA738 File Offset: 0x000D8938
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

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x060015BB RID: 5563 RVA: 0x000DA768 File Offset: 0x000D8968
	// (set) Token: 0x060015BC RID: 5564 RVA: 0x000DA798 File Offset: 0x000D8998
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

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000DA7C8 File Offset: 0x000D89C8
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000DA7F8 File Offset: 0x000D89F8
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

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000DA828 File Offset: 0x000D8A28
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000DA858 File Offset: 0x000D8A58
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

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DA887 File Offset: 0x000D8A87
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DA893 File Offset: 0x000D8A93
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

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DA8A0 File Offset: 0x000D8AA0
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DA8AC File Offset: 0x000D8AAC
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

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DA8B9 File Offset: 0x000D8AB9
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DA8C5 File Offset: 0x000D8AC5
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

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DA8D4 File Offset: 0x000D8AD4
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DA904 File Offset: 0x000D8B04
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

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DA934 File Offset: 0x000D8B34
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DA964 File Offset: 0x000D8B64
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

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DA994 File Offset: 0x000D8B94
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DA9C4 File Offset: 0x000D8BC4
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

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DA9F4 File Offset: 0x000D8BF4
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DAA24 File Offset: 0x000D8C24
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

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DAA54 File Offset: 0x000D8C54
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DAA84 File Offset: 0x000D8C84
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

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DAAB3 File Offset: 0x000D8CB3
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DAABF File Offset: 0x000D8CBF
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

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DAACC File Offset: 0x000D8CCC
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DAAFC File Offset: 0x000D8CFC
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

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000DAB2C File Offset: 0x000D8D2C
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000DAB5C File Offset: 0x000D8D5C
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

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x060015D7 RID: 5591 RVA: 0x000DAB8C File Offset: 0x000D8D8C
	// (set) Token: 0x060015D8 RID: 5592 RVA: 0x000DABBC File Offset: 0x000D8DBC
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

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x060015D9 RID: 5593 RVA: 0x000DABEC File Offset: 0x000D8DEC
	// (set) Token: 0x060015DA RID: 5594 RVA: 0x000DAC1C File Offset: 0x000D8E1C
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

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x060015DB RID: 5595 RVA: 0x000DAC4C File Offset: 0x000D8E4C
	// (set) Token: 0x060015DC RID: 5596 RVA: 0x000DAC7C File Offset: 0x000D8E7C
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

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x060015DD RID: 5597 RVA: 0x000DACAC File Offset: 0x000D8EAC
	// (set) Token: 0x060015DE RID: 5598 RVA: 0x000DACDC File Offset: 0x000D8EDC
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

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x060015DF RID: 5599 RVA: 0x000DAD0C File Offset: 0x000D8F0C
	// (set) Token: 0x060015E0 RID: 5600 RVA: 0x000DAD3C File Offset: 0x000D8F3C
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

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x060015E1 RID: 5601 RVA: 0x000DAD6C File Offset: 0x000D8F6C
	// (set) Token: 0x060015E2 RID: 5602 RVA: 0x000DAD9C File Offset: 0x000D8F9C
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

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000DADCC File Offset: 0x000D8FCC
	// (set) Token: 0x060015E4 RID: 5604 RVA: 0x000DADFC File Offset: 0x000D8FFC
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

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x060015E5 RID: 5605 RVA: 0x000DAE2C File Offset: 0x000D902C
	// (set) Token: 0x060015E6 RID: 5606 RVA: 0x000DAE5C File Offset: 0x000D905C
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

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x060015E7 RID: 5607 RVA: 0x000DAE8C File Offset: 0x000D908C
	// (set) Token: 0x060015E8 RID: 5608 RVA: 0x000DAEBC File Offset: 0x000D90BC
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

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000DAEEC File Offset: 0x000D90EC
	// (set) Token: 0x060015EA RID: 5610 RVA: 0x000DAF1C File Offset: 0x000D911C
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

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x060015EB RID: 5611 RVA: 0x000DAF4C File Offset: 0x000D914C
	// (set) Token: 0x060015EC RID: 5612 RVA: 0x000DAF7C File Offset: 0x000D917C
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

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x060015ED RID: 5613 RVA: 0x000DAFAC File Offset: 0x000D91AC
	// (set) Token: 0x060015EE RID: 5614 RVA: 0x000DAFDC File Offset: 0x000D91DC
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

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x060015EF RID: 5615 RVA: 0x000DB00B File Offset: 0x000D920B
	// (set) Token: 0x060015F0 RID: 5616 RVA: 0x000DB017 File Offset: 0x000D9217
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

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x060015F1 RID: 5617 RVA: 0x000DB024 File Offset: 0x000D9224
	// (set) Token: 0x060015F2 RID: 5618 RVA: 0x000DB054 File Offset: 0x000D9254
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

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x060015F3 RID: 5619 RVA: 0x000DB084 File Offset: 0x000D9284
	// (set) Token: 0x060015F4 RID: 5620 RVA: 0x000DB0B4 File Offset: 0x000D92B4
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

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x060015F5 RID: 5621 RVA: 0x000DB0E4 File Offset: 0x000D92E4
	// (set) Token: 0x060015F6 RID: 5622 RVA: 0x000DB114 File Offset: 0x000D9314
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

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x060015F7 RID: 5623 RVA: 0x000DB144 File Offset: 0x000D9344
	// (set) Token: 0x060015F8 RID: 5624 RVA: 0x000DB174 File Offset: 0x000D9374
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

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x060015F9 RID: 5625 RVA: 0x000DB1A4 File Offset: 0x000D93A4
	// (set) Token: 0x060015FA RID: 5626 RVA: 0x000DB1D4 File Offset: 0x000D93D4
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

	// Token: 0x060015FB RID: 5627 RVA: 0x000DB204 File Offset: 0x000D9404
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x060015FC RID: 5628 RVA: 0x000DB23C File Offset: 0x000D943C
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x060015FD RID: 5629 RVA: 0x000DB298 File Offset: 0x000D9498
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x060015FE RID: 5630 RVA: 0x000DB2C8 File Offset: 0x000D94C8
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x060015FF RID: 5631 RVA: 0x000DB300 File Offset: 0x000D9500
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001600 RID: 5632 RVA: 0x000DB35C File Offset: 0x000D955C
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06001601 RID: 5633 RVA: 0x000DB38C File Offset: 0x000D958C
	// (set) Token: 0x06001602 RID: 5634 RVA: 0x000DB3BC File Offset: 0x000D95BC
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

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001603 RID: 5635 RVA: 0x000DB3EC File Offset: 0x000D95EC
	// (set) Token: 0x06001604 RID: 5636 RVA: 0x000DB41C File Offset: 0x000D961C
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

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x06001605 RID: 5637 RVA: 0x000DB44C File Offset: 0x000D964C
	// (set) Token: 0x06001606 RID: 5638 RVA: 0x000DB47C File Offset: 0x000D967C
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

	// Token: 0x170003BE RID: 958
	// (get) Token: 0x06001607 RID: 5639 RVA: 0x000DB4AC File Offset: 0x000D96AC
	// (set) Token: 0x06001608 RID: 5640 RVA: 0x000DB4DC File Offset: 0x000D96DC
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

	// Token: 0x06001609 RID: 5641 RVA: 0x000DB50C File Offset: 0x000D970C
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
		for (int i = 1; i < 11; i++)
		{
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", GameGlobals.KeysOfRivalEliminations());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", GameGlobals.KeysOfSpecificEliminations());
	}

	// Token: 0x040021C9 RID: 8649
	private const string Str_Profile = "Profile";

	// Token: 0x040021CA RID: 8650
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x040021CB RID: 8651
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x040021CC RID: 8652
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x040021CD RID: 8653
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x040021CE RID: 8654
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x040021CF RID: 8655
	private const string Str_HardMode = "HardMode";

	// Token: 0x040021D0 RID: 8656
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x040021D1 RID: 8657
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x040021D2 RID: 8658
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x040021D3 RID: 8659
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x040021D4 RID: 8660
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x040021D5 RID: 8661
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x040021D6 RID: 8662
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x040021D7 RID: 8663
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x040021D8 RID: 8664
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x040021D9 RID: 8665
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x040021DA RID: 8666
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x040021DB RID: 8667
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x040021DC RID: 8668
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x040021DD RID: 8669
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x040021DE RID: 8670
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x040021DF RID: 8671
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x040021E0 RID: 8672
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x040021E1 RID: 8673
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x040021E2 RID: 8674
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x040021E3 RID: 8675
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x040021E4 RID: 8676
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x040021E5 RID: 8677
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x040021E6 RID: 8678
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x040021E7 RID: 8679
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x040021E8 RID: 8680
	private const string Str_Eighties = "Eighties";

	// Token: 0x040021E9 RID: 8681
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x040021EA RID: 8682
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x040021EB RID: 8683
	private const string Str_Debug = "Debug";

	// Token: 0x040021EC RID: 8684
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x040021ED RID: 8685
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x040021EE RID: 8686
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x040021EF RID: 8687
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x040021F0 RID: 8688
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x040021F1 RID: 8689
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x040021F2 RID: 8690
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x040021F3 RID: 8691
	private const string Str_AbductionTarget = "AbductionTarget";
}
