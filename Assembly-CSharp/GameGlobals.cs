using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class GameGlobals
{
	// Token: 0x17000396 RID: 918
	// (get) Token: 0x060015A5 RID: 5541 RVA: 0x000D93D3 File Offset: 0x000D75D3
	// (set) Token: 0x060015A6 RID: 5542 RVA: 0x000D93DF File Offset: 0x000D75DF
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
	// (get) Token: 0x060015A7 RID: 5543 RVA: 0x000D93EC File Offset: 0x000D75EC
	// (set) Token: 0x060015A8 RID: 5544 RVA: 0x000D93F8 File Offset: 0x000D75F8
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
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000D9408 File Offset: 0x000D7608
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000D9438 File Offset: 0x000D7638
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
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x000D9468 File Offset: 0x000D7668
	// (set) Token: 0x060015AC RID: 5548 RVA: 0x000D9498 File Offset: 0x000D7698
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
	// (get) Token: 0x060015AD RID: 5549 RVA: 0x000D94C8 File Offset: 0x000D76C8
	// (set) Token: 0x060015AE RID: 5550 RVA: 0x000D94F8 File Offset: 0x000D76F8
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
	// (get) Token: 0x060015AF RID: 5551 RVA: 0x000D9528 File Offset: 0x000D7728
	// (set) Token: 0x060015B0 RID: 5552 RVA: 0x000D9558 File Offset: 0x000D7758
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
	// (get) Token: 0x060015B1 RID: 5553 RVA: 0x000D9588 File Offset: 0x000D7788
	// (set) Token: 0x060015B2 RID: 5554 RVA: 0x000D95B8 File Offset: 0x000D77B8
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
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000D95E8 File Offset: 0x000D77E8
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000D9618 File Offset: 0x000D7818
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
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000D9647 File Offset: 0x000D7847
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000D9653 File Offset: 0x000D7853
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
	// (get) Token: 0x060015B7 RID: 5559 RVA: 0x000D9660 File Offset: 0x000D7860
	// (set) Token: 0x060015B8 RID: 5560 RVA: 0x000D966C File Offset: 0x000D786C
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
	// (get) Token: 0x060015B9 RID: 5561 RVA: 0x000D9679 File Offset: 0x000D7879
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x000D9685 File Offset: 0x000D7885
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
	// (get) Token: 0x060015BB RID: 5563 RVA: 0x000D9694 File Offset: 0x000D7894
	// (set) Token: 0x060015BC RID: 5564 RVA: 0x000D96C4 File Offset: 0x000D78C4
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
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000D96F4 File Offset: 0x000D78F4
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000D9724 File Offset: 0x000D7924
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
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000D9754 File Offset: 0x000D7954
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000D9784 File Offset: 0x000D7984
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
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000D97B4 File Offset: 0x000D79B4
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000D97E4 File Offset: 0x000D79E4
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000D9814 File Offset: 0x000D7A14
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000D9844 File Offset: 0x000D7A44
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000D9873 File Offset: 0x000D7A73
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000D987F File Offset: 0x000D7A7F
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000D988C File Offset: 0x000D7A8C
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000D98BC File Offset: 0x000D7ABC
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000D98EC File Offset: 0x000D7AEC
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000D991C File Offset: 0x000D7B1C
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000D994C File Offset: 0x000D7B4C
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000D997C File Offset: 0x000D7B7C
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000D99AC File Offset: 0x000D7BAC
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000D99DC File Offset: 0x000D7BDC
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000D9A0C File Offset: 0x000D7C0C
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000D9A3C File Offset: 0x000D7C3C
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000D9A6C File Offset: 0x000D7C6C
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000D9A9C File Offset: 0x000D7C9C
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000D9ACC File Offset: 0x000D7CCC
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000D9AFC File Offset: 0x000D7CFC
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
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000D9B2C File Offset: 0x000D7D2C
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000D9B5C File Offset: 0x000D7D5C
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
	// (get) Token: 0x060015D7 RID: 5591 RVA: 0x000D9B8C File Offset: 0x000D7D8C
	// (set) Token: 0x060015D8 RID: 5592 RVA: 0x000D9BBC File Offset: 0x000D7DBC
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
	// (get) Token: 0x060015D9 RID: 5593 RVA: 0x000D9BEC File Offset: 0x000D7DEC
	// (set) Token: 0x060015DA RID: 5594 RVA: 0x000D9C1C File Offset: 0x000D7E1C
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
	// (get) Token: 0x060015DB RID: 5595 RVA: 0x000D9C4C File Offset: 0x000D7E4C
	// (set) Token: 0x060015DC RID: 5596 RVA: 0x000D9C7C File Offset: 0x000D7E7C
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
	// (get) Token: 0x060015DD RID: 5597 RVA: 0x000D9CAC File Offset: 0x000D7EAC
	// (set) Token: 0x060015DE RID: 5598 RVA: 0x000D9CDC File Offset: 0x000D7EDC
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
	// (get) Token: 0x060015DF RID: 5599 RVA: 0x000D9D0C File Offset: 0x000D7F0C
	// (set) Token: 0x060015E0 RID: 5600 RVA: 0x000D9D3C File Offset: 0x000D7F3C
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
	// (get) Token: 0x060015E1 RID: 5601 RVA: 0x000D9D6C File Offset: 0x000D7F6C
	// (set) Token: 0x060015E2 RID: 5602 RVA: 0x000D9D9C File Offset: 0x000D7F9C
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
	// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000D9DCB File Offset: 0x000D7FCB
	// (set) Token: 0x060015E4 RID: 5604 RVA: 0x000D9DD7 File Offset: 0x000D7FD7
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
	// (get) Token: 0x060015E5 RID: 5605 RVA: 0x000D9DE4 File Offset: 0x000D7FE4
	// (set) Token: 0x060015E6 RID: 5606 RVA: 0x000D9E14 File Offset: 0x000D8014
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
	// (get) Token: 0x060015E7 RID: 5607 RVA: 0x000D9E44 File Offset: 0x000D8044
	// (set) Token: 0x060015E8 RID: 5608 RVA: 0x000D9E74 File Offset: 0x000D8074
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
	// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000D9EA4 File Offset: 0x000D80A4
	// (set) Token: 0x060015EA RID: 5610 RVA: 0x000D9ED4 File Offset: 0x000D80D4
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
	// (get) Token: 0x060015EB RID: 5611 RVA: 0x000D9F04 File Offset: 0x000D8104
	// (set) Token: 0x060015EC RID: 5612 RVA: 0x000D9F34 File Offset: 0x000D8134
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
	// (get) Token: 0x060015ED RID: 5613 RVA: 0x000D9F64 File Offset: 0x000D8164
	// (set) Token: 0x060015EE RID: 5614 RVA: 0x000D9F94 File Offset: 0x000D8194
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

	// Token: 0x060015EF RID: 5615 RVA: 0x000D9FC4 File Offset: 0x000D81C4
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x060015F0 RID: 5616 RVA: 0x000D9FFC File Offset: 0x000D81FC
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x060015F1 RID: 5617 RVA: 0x000DA058 File Offset: 0x000D8258
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x060015F2 RID: 5618 RVA: 0x000DA088 File Offset: 0x000D8288
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x060015F3 RID: 5619 RVA: 0x000DA0C0 File Offset: 0x000D82C0
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x060015F4 RID: 5620 RVA: 0x000DA11C File Offset: 0x000D831C
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x060015F5 RID: 5621 RVA: 0x000DA14C File Offset: 0x000D834C
	// (set) Token: 0x060015F6 RID: 5622 RVA: 0x000DA17C File Offset: 0x000D837C
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
	// (get) Token: 0x060015F7 RID: 5623 RVA: 0x000DA1AC File Offset: 0x000D83AC
	// (set) Token: 0x060015F8 RID: 5624 RVA: 0x000DA1DC File Offset: 0x000D83DC
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
	// (get) Token: 0x060015F9 RID: 5625 RVA: 0x000DA20C File Offset: 0x000D840C
	// (set) Token: 0x060015FA RID: 5626 RVA: 0x000DA23C File Offset: 0x000D843C
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
	// (get) Token: 0x060015FB RID: 5627 RVA: 0x000DA26C File Offset: 0x000D846C
	// (set) Token: 0x060015FC RID: 5628 RVA: 0x000DA29C File Offset: 0x000D849C
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

	// Token: 0x060015FD RID: 5629 RVA: 0x000DA2CC File Offset: 0x000D84CC
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

	// Token: 0x0400219A RID: 8602
	private const string Str_Profile = "Profile";

	// Token: 0x0400219B RID: 8603
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x0400219C RID: 8604
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x0400219D RID: 8605
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x0400219E RID: 8606
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x0400219F RID: 8607
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x040021A0 RID: 8608
	private const string Str_HardMode = "HardMode";

	// Token: 0x040021A1 RID: 8609
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x040021A2 RID: 8610
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x040021A3 RID: 8611
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x040021A4 RID: 8612
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x040021A5 RID: 8613
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x040021A6 RID: 8614
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x040021A7 RID: 8615
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x040021A8 RID: 8616
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x040021A9 RID: 8617
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x040021AA RID: 8618
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x040021AB RID: 8619
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x040021AC RID: 8620
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x040021AD RID: 8621
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x040021AE RID: 8622
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x040021AF RID: 8623
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x040021B0 RID: 8624
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x040021B1 RID: 8625
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x040021B2 RID: 8626
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x040021B3 RID: 8627
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x040021B4 RID: 8628
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x040021B5 RID: 8629
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x040021B6 RID: 8630
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x040021B7 RID: 8631
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x040021B8 RID: 8632
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x040021B9 RID: 8633
	private const string Str_Eighties = "Eighties";

	// Token: 0x040021BA RID: 8634
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x040021BB RID: 8635
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x040021BC RID: 8636
	private const string Str_Debug = "Debug";

	// Token: 0x040021BD RID: 8637
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x040021BE RID: 8638
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x040021BF RID: 8639
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x040021C0 RID: 8640
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x040021C1 RID: 8641
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x040021C2 RID: 8642
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x040021C3 RID: 8643
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x040021C4 RID: 8644
	private const string Str_AbductionTarget = "AbductionTarget";
}
