using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class GameGlobals
{
	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DB507 File Offset: 0x000D9707
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DB513 File Offset: 0x000D9713
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DB520 File Offset: 0x000D9720
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DB52C File Offset: 0x000D972C
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DB53C File Offset: 0x000D973C
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DB56C File Offset: 0x000D976C
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DB59C File Offset: 0x000D979C
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DB5CC File Offset: 0x000D97CC
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DB5FC File Offset: 0x000D97FC
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DB62C File Offset: 0x000D982C
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DB65C File Offset: 0x000D985C
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DB68C File Offset: 0x000D988C
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DB6BC File Offset: 0x000D98BC
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DB6EC File Offset: 0x000D98EC
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DB71C File Offset: 0x000D991C
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DB74C File Offset: 0x000D994C
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DB77B File Offset: 0x000D997B
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DB787 File Offset: 0x000D9987
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DB794 File Offset: 0x000D9994
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DB7A0 File Offset: 0x000D99A0
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
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000DB7AD File Offset: 0x000D99AD
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000DB7B9 File Offset: 0x000D99B9
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
	// (get) Token: 0x060015D7 RID: 5591 RVA: 0x000DB7C8 File Offset: 0x000D99C8
	// (set) Token: 0x060015D8 RID: 5592 RVA: 0x000DB7F8 File Offset: 0x000D99F8
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
	// (get) Token: 0x060015D9 RID: 5593 RVA: 0x000DB828 File Offset: 0x000D9A28
	// (set) Token: 0x060015DA RID: 5594 RVA: 0x000DB858 File Offset: 0x000D9A58
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
	// (get) Token: 0x060015DB RID: 5595 RVA: 0x000DB888 File Offset: 0x000D9A88
	// (set) Token: 0x060015DC RID: 5596 RVA: 0x000DB8B8 File Offset: 0x000D9AB8
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
	// (get) Token: 0x060015DD RID: 5597 RVA: 0x000DB8E8 File Offset: 0x000D9AE8
	// (set) Token: 0x060015DE RID: 5598 RVA: 0x000DB918 File Offset: 0x000D9B18
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
	// (get) Token: 0x060015DF RID: 5599 RVA: 0x000DB948 File Offset: 0x000D9B48
	// (set) Token: 0x060015E0 RID: 5600 RVA: 0x000DB978 File Offset: 0x000D9B78
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
	// (get) Token: 0x060015E1 RID: 5601 RVA: 0x000DB9A7 File Offset: 0x000D9BA7
	// (set) Token: 0x060015E2 RID: 5602 RVA: 0x000DB9B3 File Offset: 0x000D9BB3
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
	// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000DB9C0 File Offset: 0x000D9BC0
	// (set) Token: 0x060015E4 RID: 5604 RVA: 0x000DB9F0 File Offset: 0x000D9BF0
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
	// (get) Token: 0x060015E5 RID: 5605 RVA: 0x000DBA20 File Offset: 0x000D9C20
	// (set) Token: 0x060015E6 RID: 5606 RVA: 0x000DBA50 File Offset: 0x000D9C50
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
	// (get) Token: 0x060015E7 RID: 5607 RVA: 0x000DBA80 File Offset: 0x000D9C80
	// (set) Token: 0x060015E8 RID: 5608 RVA: 0x000DBAB0 File Offset: 0x000D9CB0
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
	// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000DBAE0 File Offset: 0x000D9CE0
	// (set) Token: 0x060015EA RID: 5610 RVA: 0x000DBB10 File Offset: 0x000D9D10
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
	// (get) Token: 0x060015EB RID: 5611 RVA: 0x000DBB40 File Offset: 0x000D9D40
	// (set) Token: 0x060015EC RID: 5612 RVA: 0x000DBB70 File Offset: 0x000D9D70
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
	// (get) Token: 0x060015ED RID: 5613 RVA: 0x000DBBA0 File Offset: 0x000D9DA0
	// (set) Token: 0x060015EE RID: 5614 RVA: 0x000DBBD0 File Offset: 0x000D9DD0
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
	// (get) Token: 0x060015EF RID: 5615 RVA: 0x000DBC00 File Offset: 0x000D9E00
	// (set) Token: 0x060015F0 RID: 5616 RVA: 0x000DBC30 File Offset: 0x000D9E30
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
	// (get) Token: 0x060015F1 RID: 5617 RVA: 0x000DBC60 File Offset: 0x000D9E60
	// (set) Token: 0x060015F2 RID: 5618 RVA: 0x000DBC90 File Offset: 0x000D9E90
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
	// (get) Token: 0x060015F3 RID: 5619 RVA: 0x000DBCC0 File Offset: 0x000D9EC0
	// (set) Token: 0x060015F4 RID: 5620 RVA: 0x000DBCF0 File Offset: 0x000D9EF0
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
	// (get) Token: 0x060015F5 RID: 5621 RVA: 0x000DBD20 File Offset: 0x000D9F20
	// (set) Token: 0x060015F6 RID: 5622 RVA: 0x000DBD50 File Offset: 0x000D9F50
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
	// (get) Token: 0x060015F7 RID: 5623 RVA: 0x000DBD80 File Offset: 0x000D9F80
	// (set) Token: 0x060015F8 RID: 5624 RVA: 0x000DBDB0 File Offset: 0x000D9FB0
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
	// (get) Token: 0x060015F9 RID: 5625 RVA: 0x000DBDE0 File Offset: 0x000D9FE0
	// (set) Token: 0x060015FA RID: 5626 RVA: 0x000DBE10 File Offset: 0x000DA010
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
	// (get) Token: 0x060015FB RID: 5627 RVA: 0x000DBE40 File Offset: 0x000DA040
	// (set) Token: 0x060015FC RID: 5628 RVA: 0x000DBE70 File Offset: 0x000DA070
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
	// (get) Token: 0x060015FD RID: 5629 RVA: 0x000DBEA0 File Offset: 0x000DA0A0
	// (set) Token: 0x060015FE RID: 5630 RVA: 0x000DBED0 File Offset: 0x000DA0D0
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
	// (get) Token: 0x060015FF RID: 5631 RVA: 0x000DBEFF File Offset: 0x000DA0FF
	// (set) Token: 0x06001600 RID: 5632 RVA: 0x000DBF0B File Offset: 0x000DA10B
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
	// (get) Token: 0x06001601 RID: 5633 RVA: 0x000DBF18 File Offset: 0x000DA118
	// (set) Token: 0x06001602 RID: 5634 RVA: 0x000DBF48 File Offset: 0x000DA148
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
	// (get) Token: 0x06001603 RID: 5635 RVA: 0x000DBF78 File Offset: 0x000DA178
	// (set) Token: 0x06001604 RID: 5636 RVA: 0x000DBFA8 File Offset: 0x000DA1A8
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
	// (get) Token: 0x06001605 RID: 5637 RVA: 0x000DBFD8 File Offset: 0x000DA1D8
	// (set) Token: 0x06001606 RID: 5638 RVA: 0x000DC008 File Offset: 0x000DA208
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
	// (get) Token: 0x06001607 RID: 5639 RVA: 0x000DC038 File Offset: 0x000DA238
	// (set) Token: 0x06001608 RID: 5640 RVA: 0x000DC068 File Offset: 0x000DA268
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
	// (get) Token: 0x06001609 RID: 5641 RVA: 0x000DC098 File Offset: 0x000DA298
	// (set) Token: 0x0600160A RID: 5642 RVA: 0x000DC0C8 File Offset: 0x000DA2C8
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

	// Token: 0x0600160B RID: 5643 RVA: 0x000DC0F8 File Offset: 0x000DA2F8
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x0600160C RID: 5644 RVA: 0x000DC130 File Offset: 0x000DA330
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x000DC18C File Offset: 0x000DA38C
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x0600160E RID: 5646 RVA: 0x000DC1BC File Offset: 0x000DA3BC
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x0600160F RID: 5647 RVA: 0x000DC1F4 File Offset: 0x000DA3F4
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x000DC250 File Offset: 0x000DA450
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001611 RID: 5649 RVA: 0x000DC280 File Offset: 0x000DA480
	// (set) Token: 0x06001612 RID: 5650 RVA: 0x000DC2B0 File Offset: 0x000DA4B0
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
	// (get) Token: 0x06001613 RID: 5651 RVA: 0x000DC2E0 File Offset: 0x000DA4E0
	// (set) Token: 0x06001614 RID: 5652 RVA: 0x000DC310 File Offset: 0x000DA510
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
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DC340 File Offset: 0x000DA540
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DC370 File Offset: 0x000DA570
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
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DC3A0 File Offset: 0x000DA5A0
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DC3D0 File Offset: 0x000DA5D0
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
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DC3FF File Offset: 0x000DA5FF
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DC40B File Offset: 0x000DA60B
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

	// Token: 0x0600161B RID: 5659 RVA: 0x000DC418 File Offset: 0x000DA618
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
		for (int i = 1; i < 11; i++)
		{
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", GameGlobals.KeysOfRivalEliminations());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", GameGlobals.KeysOfSpecificEliminations());
	}

	// Token: 0x040021F5 RID: 8693
	private const string Str_Profile = "Profile";

	// Token: 0x040021F6 RID: 8694
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x040021F7 RID: 8695
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x040021F8 RID: 8696
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x040021F9 RID: 8697
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x040021FA RID: 8698
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x040021FB RID: 8699
	private const string Str_HardMode = "HardMode";

	// Token: 0x040021FC RID: 8700
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x040021FD RID: 8701
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x040021FE RID: 8702
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x040021FF RID: 8703
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x04002200 RID: 8704
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x04002201 RID: 8705
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x04002202 RID: 8706
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x04002203 RID: 8707
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x04002204 RID: 8708
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x04002205 RID: 8709
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x04002206 RID: 8710
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x04002207 RID: 8711
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x04002208 RID: 8712
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x04002209 RID: 8713
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x0400220A RID: 8714
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x0400220B RID: 8715
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x0400220C RID: 8716
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x0400220D RID: 8717
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x0400220E RID: 8718
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x0400220F RID: 8719
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x04002210 RID: 8720
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x04002211 RID: 8721
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x04002212 RID: 8722
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x04002213 RID: 8723
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x04002214 RID: 8724
	private const string Str_Eighties = "Eighties";

	// Token: 0x04002215 RID: 8725
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x04002216 RID: 8726
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x04002217 RID: 8727
	private const string Str_Debug = "Debug";

	// Token: 0x04002218 RID: 8728
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x04002219 RID: 8729
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x0400221A RID: 8730
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x0400221B RID: 8731
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x0400221C RID: 8732
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x0400221D RID: 8733
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x0400221E RID: 8734
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x0400221F RID: 8735
	private const string Str_AbductionTarget = "AbductionTarget";

	// Token: 0x04002220 RID: 8736
	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";
}
