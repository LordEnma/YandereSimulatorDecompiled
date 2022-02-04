using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class GameGlobals
{
	// Token: 0x17000396 RID: 918
	// (get) Token: 0x060015B1 RID: 5553 RVA: 0x000DA6CB File Offset: 0x000D88CB
	// (set) Token: 0x060015B2 RID: 5554 RVA: 0x000DA6D7 File Offset: 0x000D88D7
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
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000DA6E4 File Offset: 0x000D88E4
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000DA6F0 File Offset: 0x000D88F0
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
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DA700 File Offset: 0x000D8900
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DA730 File Offset: 0x000D8930
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
	// (get) Token: 0x060015B7 RID: 5559 RVA: 0x000DA760 File Offset: 0x000D8960
	// (set) Token: 0x060015B8 RID: 5560 RVA: 0x000DA790 File Offset: 0x000D8990
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
	// (get) Token: 0x060015B9 RID: 5561 RVA: 0x000DA7C0 File Offset: 0x000D89C0
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x000DA7F0 File Offset: 0x000D89F0
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
	// (get) Token: 0x060015BB RID: 5563 RVA: 0x000DA820 File Offset: 0x000D8A20
	// (set) Token: 0x060015BC RID: 5564 RVA: 0x000DA850 File Offset: 0x000D8A50
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
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000DA880 File Offset: 0x000D8A80
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000DA8B0 File Offset: 0x000D8AB0
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
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000DA8E0 File Offset: 0x000D8AE0
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000DA910 File Offset: 0x000D8B10
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
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DA93F File Offset: 0x000D8B3F
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DA94B File Offset: 0x000D8B4B
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DA958 File Offset: 0x000D8B58
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DA964 File Offset: 0x000D8B64
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DA971 File Offset: 0x000D8B71
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DA97D File Offset: 0x000D8B7D
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DA98C File Offset: 0x000D8B8C
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DA9BC File Offset: 0x000D8BBC
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DA9EC File Offset: 0x000D8BEC
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DAA1C File Offset: 0x000D8C1C
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DAA4C File Offset: 0x000D8C4C
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DAA7C File Offset: 0x000D8C7C
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DAAAC File Offset: 0x000D8CAC
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DAADC File Offset: 0x000D8CDC
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DAB0C File Offset: 0x000D8D0C
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DAB3C File Offset: 0x000D8D3C
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DAB6B File Offset: 0x000D8D6B
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DAB77 File Offset: 0x000D8D77
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DAB84 File Offset: 0x000D8D84
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DABB4 File Offset: 0x000D8DB4
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
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000DABE4 File Offset: 0x000D8DE4
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000DAC14 File Offset: 0x000D8E14
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
	// (get) Token: 0x060015D7 RID: 5591 RVA: 0x000DAC44 File Offset: 0x000D8E44
	// (set) Token: 0x060015D8 RID: 5592 RVA: 0x000DAC74 File Offset: 0x000D8E74
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
	// (get) Token: 0x060015D9 RID: 5593 RVA: 0x000DACA4 File Offset: 0x000D8EA4
	// (set) Token: 0x060015DA RID: 5594 RVA: 0x000DACD4 File Offset: 0x000D8ED4
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
	// (get) Token: 0x060015DB RID: 5595 RVA: 0x000DAD04 File Offset: 0x000D8F04
	// (set) Token: 0x060015DC RID: 5596 RVA: 0x000DAD34 File Offset: 0x000D8F34
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
	// (get) Token: 0x060015DD RID: 5597 RVA: 0x000DAD64 File Offset: 0x000D8F64
	// (set) Token: 0x060015DE RID: 5598 RVA: 0x000DAD94 File Offset: 0x000D8F94
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
	// (get) Token: 0x060015DF RID: 5599 RVA: 0x000DADC4 File Offset: 0x000D8FC4
	// (set) Token: 0x060015E0 RID: 5600 RVA: 0x000DADF4 File Offset: 0x000D8FF4
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
	// (get) Token: 0x060015E1 RID: 5601 RVA: 0x000DAE24 File Offset: 0x000D9024
	// (set) Token: 0x060015E2 RID: 5602 RVA: 0x000DAE54 File Offset: 0x000D9054
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
	// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000DAE84 File Offset: 0x000D9084
	// (set) Token: 0x060015E4 RID: 5604 RVA: 0x000DAEB4 File Offset: 0x000D90B4
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
	// (get) Token: 0x060015E5 RID: 5605 RVA: 0x000DAEE4 File Offset: 0x000D90E4
	// (set) Token: 0x060015E6 RID: 5606 RVA: 0x000DAF14 File Offset: 0x000D9114
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
	// (get) Token: 0x060015E7 RID: 5607 RVA: 0x000DAF44 File Offset: 0x000D9144
	// (set) Token: 0x060015E8 RID: 5608 RVA: 0x000DAF74 File Offset: 0x000D9174
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
	// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000DAFA4 File Offset: 0x000D91A4
	// (set) Token: 0x060015EA RID: 5610 RVA: 0x000DAFD4 File Offset: 0x000D91D4
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
	// (get) Token: 0x060015EB RID: 5611 RVA: 0x000DB004 File Offset: 0x000D9204
	// (set) Token: 0x060015EC RID: 5612 RVA: 0x000DB034 File Offset: 0x000D9234
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
	// (get) Token: 0x060015ED RID: 5613 RVA: 0x000DB064 File Offset: 0x000D9264
	// (set) Token: 0x060015EE RID: 5614 RVA: 0x000DB094 File Offset: 0x000D9294
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
	// (get) Token: 0x060015EF RID: 5615 RVA: 0x000DB0C3 File Offset: 0x000D92C3
	// (set) Token: 0x060015F0 RID: 5616 RVA: 0x000DB0CF File Offset: 0x000D92CF
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
	// (get) Token: 0x060015F1 RID: 5617 RVA: 0x000DB0DC File Offset: 0x000D92DC
	// (set) Token: 0x060015F2 RID: 5618 RVA: 0x000DB10C File Offset: 0x000D930C
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
	// (get) Token: 0x060015F3 RID: 5619 RVA: 0x000DB13C File Offset: 0x000D933C
	// (set) Token: 0x060015F4 RID: 5620 RVA: 0x000DB16C File Offset: 0x000D936C
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
	// (get) Token: 0x060015F5 RID: 5621 RVA: 0x000DB19C File Offset: 0x000D939C
	// (set) Token: 0x060015F6 RID: 5622 RVA: 0x000DB1CC File Offset: 0x000D93CC
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
	// (get) Token: 0x060015F7 RID: 5623 RVA: 0x000DB1FC File Offset: 0x000D93FC
	// (set) Token: 0x060015F8 RID: 5624 RVA: 0x000DB22C File Offset: 0x000D942C
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
	// (get) Token: 0x060015F9 RID: 5625 RVA: 0x000DB25C File Offset: 0x000D945C
	// (set) Token: 0x060015FA RID: 5626 RVA: 0x000DB28C File Offset: 0x000D948C
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

	// Token: 0x060015FB RID: 5627 RVA: 0x000DB2BC File Offset: 0x000D94BC
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x060015FC RID: 5628 RVA: 0x000DB2F4 File Offset: 0x000D94F4
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x060015FD RID: 5629 RVA: 0x000DB350 File Offset: 0x000D9550
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x060015FE RID: 5630 RVA: 0x000DB380 File Offset: 0x000D9580
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x060015FF RID: 5631 RVA: 0x000DB3B8 File Offset: 0x000D95B8
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001600 RID: 5632 RVA: 0x000DB414 File Offset: 0x000D9614
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06001601 RID: 5633 RVA: 0x000DB444 File Offset: 0x000D9644
	// (set) Token: 0x06001602 RID: 5634 RVA: 0x000DB474 File Offset: 0x000D9674
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
	// (get) Token: 0x06001603 RID: 5635 RVA: 0x000DB4A4 File Offset: 0x000D96A4
	// (set) Token: 0x06001604 RID: 5636 RVA: 0x000DB4D4 File Offset: 0x000D96D4
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
	// (get) Token: 0x06001605 RID: 5637 RVA: 0x000DB504 File Offset: 0x000D9704
	// (set) Token: 0x06001606 RID: 5638 RVA: 0x000DB534 File Offset: 0x000D9734
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
	// (get) Token: 0x06001607 RID: 5639 RVA: 0x000DB564 File Offset: 0x000D9764
	// (set) Token: 0x06001608 RID: 5640 RVA: 0x000DB594 File Offset: 0x000D9794
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

	// Token: 0x06001609 RID: 5641 RVA: 0x000DB5C4 File Offset: 0x000D97C4
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

	// Token: 0x040021CA RID: 8650
	private const string Str_Profile = "Profile";

	// Token: 0x040021CB RID: 8651
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x040021CC RID: 8652
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x040021CD RID: 8653
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x040021CE RID: 8654
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x040021CF RID: 8655
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x040021D0 RID: 8656
	private const string Str_HardMode = "HardMode";

	// Token: 0x040021D1 RID: 8657
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x040021D2 RID: 8658
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x040021D3 RID: 8659
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x040021D4 RID: 8660
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x040021D5 RID: 8661
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x040021D6 RID: 8662
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x040021D7 RID: 8663
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x040021D8 RID: 8664
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x040021D9 RID: 8665
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x040021DA RID: 8666
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x040021DB RID: 8667
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x040021DC RID: 8668
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x040021DD RID: 8669
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x040021DE RID: 8670
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x040021DF RID: 8671
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x040021E0 RID: 8672
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x040021E1 RID: 8673
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x040021E2 RID: 8674
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x040021E3 RID: 8675
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x040021E4 RID: 8676
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x040021E5 RID: 8677
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x040021E6 RID: 8678
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x040021E7 RID: 8679
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x040021E8 RID: 8680
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x040021E9 RID: 8681
	private const string Str_Eighties = "Eighties";

	// Token: 0x040021EA RID: 8682
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x040021EB RID: 8683
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x040021EC RID: 8684
	private const string Str_Debug = "Debug";

	// Token: 0x040021ED RID: 8685
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x040021EE RID: 8686
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x040021EF RID: 8687
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x040021F0 RID: 8688
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x040021F1 RID: 8689
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x040021F2 RID: 8690
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x040021F3 RID: 8691
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x040021F4 RID: 8692
	private const string Str_AbductionTarget = "AbductionTarget";
}
