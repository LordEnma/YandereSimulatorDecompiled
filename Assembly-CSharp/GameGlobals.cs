using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class GameGlobals
{
	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DB1D7 File Offset: 0x000D93D7
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DB1E3 File Offset: 0x000D93E3
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DB1F0 File Offset: 0x000D93F0
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DB1FC File Offset: 0x000D93FC
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DB20C File Offset: 0x000D940C
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DB23C File Offset: 0x000D943C
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DB26C File Offset: 0x000D946C
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DB29C File Offset: 0x000D949C
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DB2CC File Offset: 0x000D94CC
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DB2FC File Offset: 0x000D94FC
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DB32C File Offset: 0x000D952C
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DB35C File Offset: 0x000D955C
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DB38C File Offset: 0x000D958C
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DB3BC File Offset: 0x000D95BC
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DB3EC File Offset: 0x000D95EC
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DB41C File Offset: 0x000D961C
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DB44B File Offset: 0x000D964B
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DB457 File Offset: 0x000D9657
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DB464 File Offset: 0x000D9664
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DB470 File Offset: 0x000D9670
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
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000DB47D File Offset: 0x000D967D
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000DB489 File Offset: 0x000D9689
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
	// (get) Token: 0x060015D7 RID: 5591 RVA: 0x000DB498 File Offset: 0x000D9698
	// (set) Token: 0x060015D8 RID: 5592 RVA: 0x000DB4C8 File Offset: 0x000D96C8
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
	// (get) Token: 0x060015D9 RID: 5593 RVA: 0x000DB4F8 File Offset: 0x000D96F8
	// (set) Token: 0x060015DA RID: 5594 RVA: 0x000DB528 File Offset: 0x000D9728
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
	// (get) Token: 0x060015DB RID: 5595 RVA: 0x000DB558 File Offset: 0x000D9758
	// (set) Token: 0x060015DC RID: 5596 RVA: 0x000DB588 File Offset: 0x000D9788
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
	// (get) Token: 0x060015DD RID: 5597 RVA: 0x000DB5B8 File Offset: 0x000D97B8
	// (set) Token: 0x060015DE RID: 5598 RVA: 0x000DB5E8 File Offset: 0x000D97E8
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
	// (get) Token: 0x060015DF RID: 5599 RVA: 0x000DB618 File Offset: 0x000D9818
	// (set) Token: 0x060015E0 RID: 5600 RVA: 0x000DB648 File Offset: 0x000D9848
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
	// (get) Token: 0x060015E1 RID: 5601 RVA: 0x000DB677 File Offset: 0x000D9877
	// (set) Token: 0x060015E2 RID: 5602 RVA: 0x000DB683 File Offset: 0x000D9883
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
	// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000DB690 File Offset: 0x000D9890
	// (set) Token: 0x060015E4 RID: 5604 RVA: 0x000DB6C0 File Offset: 0x000D98C0
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
	// (get) Token: 0x060015E5 RID: 5605 RVA: 0x000DB6F0 File Offset: 0x000D98F0
	// (set) Token: 0x060015E6 RID: 5606 RVA: 0x000DB720 File Offset: 0x000D9920
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
	// (get) Token: 0x060015E7 RID: 5607 RVA: 0x000DB750 File Offset: 0x000D9950
	// (set) Token: 0x060015E8 RID: 5608 RVA: 0x000DB780 File Offset: 0x000D9980
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
	// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000DB7B0 File Offset: 0x000D99B0
	// (set) Token: 0x060015EA RID: 5610 RVA: 0x000DB7E0 File Offset: 0x000D99E0
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
	// (get) Token: 0x060015EB RID: 5611 RVA: 0x000DB810 File Offset: 0x000D9A10
	// (set) Token: 0x060015EC RID: 5612 RVA: 0x000DB840 File Offset: 0x000D9A40
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
	// (get) Token: 0x060015ED RID: 5613 RVA: 0x000DB870 File Offset: 0x000D9A70
	// (set) Token: 0x060015EE RID: 5614 RVA: 0x000DB8A0 File Offset: 0x000D9AA0
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
	// (get) Token: 0x060015EF RID: 5615 RVA: 0x000DB8D0 File Offset: 0x000D9AD0
	// (set) Token: 0x060015F0 RID: 5616 RVA: 0x000DB900 File Offset: 0x000D9B00
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
	// (get) Token: 0x060015F1 RID: 5617 RVA: 0x000DB930 File Offset: 0x000D9B30
	// (set) Token: 0x060015F2 RID: 5618 RVA: 0x000DB960 File Offset: 0x000D9B60
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
	// (get) Token: 0x060015F3 RID: 5619 RVA: 0x000DB990 File Offset: 0x000D9B90
	// (set) Token: 0x060015F4 RID: 5620 RVA: 0x000DB9C0 File Offset: 0x000D9BC0
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
	// (get) Token: 0x060015F5 RID: 5621 RVA: 0x000DB9F0 File Offset: 0x000D9BF0
	// (set) Token: 0x060015F6 RID: 5622 RVA: 0x000DBA20 File Offset: 0x000D9C20
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
	// (get) Token: 0x060015F7 RID: 5623 RVA: 0x000DBA50 File Offset: 0x000D9C50
	// (set) Token: 0x060015F8 RID: 5624 RVA: 0x000DBA80 File Offset: 0x000D9C80
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
	// (get) Token: 0x060015F9 RID: 5625 RVA: 0x000DBAB0 File Offset: 0x000D9CB0
	// (set) Token: 0x060015FA RID: 5626 RVA: 0x000DBAE0 File Offset: 0x000D9CE0
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
	// (get) Token: 0x060015FB RID: 5627 RVA: 0x000DBB10 File Offset: 0x000D9D10
	// (set) Token: 0x060015FC RID: 5628 RVA: 0x000DBB40 File Offset: 0x000D9D40
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
	// (get) Token: 0x060015FD RID: 5629 RVA: 0x000DBB70 File Offset: 0x000D9D70
	// (set) Token: 0x060015FE RID: 5630 RVA: 0x000DBBA0 File Offset: 0x000D9DA0
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
	// (get) Token: 0x060015FF RID: 5631 RVA: 0x000DBBCF File Offset: 0x000D9DCF
	// (set) Token: 0x06001600 RID: 5632 RVA: 0x000DBBDB File Offset: 0x000D9DDB
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
	// (get) Token: 0x06001601 RID: 5633 RVA: 0x000DBBE8 File Offset: 0x000D9DE8
	// (set) Token: 0x06001602 RID: 5634 RVA: 0x000DBC18 File Offset: 0x000D9E18
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
	// (get) Token: 0x06001603 RID: 5635 RVA: 0x000DBC48 File Offset: 0x000D9E48
	// (set) Token: 0x06001604 RID: 5636 RVA: 0x000DBC78 File Offset: 0x000D9E78
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
	// (get) Token: 0x06001605 RID: 5637 RVA: 0x000DBCA8 File Offset: 0x000D9EA8
	// (set) Token: 0x06001606 RID: 5638 RVA: 0x000DBCD8 File Offset: 0x000D9ED8
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
	// (get) Token: 0x06001607 RID: 5639 RVA: 0x000DBD08 File Offset: 0x000D9F08
	// (set) Token: 0x06001608 RID: 5640 RVA: 0x000DBD38 File Offset: 0x000D9F38
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
	// (get) Token: 0x06001609 RID: 5641 RVA: 0x000DBD68 File Offset: 0x000D9F68
	// (set) Token: 0x0600160A RID: 5642 RVA: 0x000DBD98 File Offset: 0x000D9F98
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

	// Token: 0x0600160B RID: 5643 RVA: 0x000DBDC8 File Offset: 0x000D9FC8
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x0600160C RID: 5644 RVA: 0x000DBE00 File Offset: 0x000DA000
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x000DBE5C File Offset: 0x000DA05C
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x0600160E RID: 5646 RVA: 0x000DBE8C File Offset: 0x000DA08C
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x0600160F RID: 5647 RVA: 0x000DBEC4 File Offset: 0x000DA0C4
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x000DBF20 File Offset: 0x000DA120
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001611 RID: 5649 RVA: 0x000DBF50 File Offset: 0x000DA150
	// (set) Token: 0x06001612 RID: 5650 RVA: 0x000DBF80 File Offset: 0x000DA180
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
	// (get) Token: 0x06001613 RID: 5651 RVA: 0x000DBFB0 File Offset: 0x000DA1B0
	// (set) Token: 0x06001614 RID: 5652 RVA: 0x000DBFE0 File Offset: 0x000DA1E0
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
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DC010 File Offset: 0x000DA210
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DC040 File Offset: 0x000DA240
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
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DC070 File Offset: 0x000DA270
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DC0A0 File Offset: 0x000DA2A0
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
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DC0CF File Offset: 0x000DA2CF
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DC0DB File Offset: 0x000DA2DB
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

	// Token: 0x0600161B RID: 5659 RVA: 0x000DC0E8 File Offset: 0x000DA2E8
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

	// Token: 0x040021E1 RID: 8673
	private const string Str_Profile = "Profile";

	// Token: 0x040021E2 RID: 8674
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x040021E3 RID: 8675
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x040021E4 RID: 8676
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x040021E5 RID: 8677
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x040021E6 RID: 8678
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x040021E7 RID: 8679
	private const string Str_HardMode = "HardMode";

	// Token: 0x040021E8 RID: 8680
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x040021E9 RID: 8681
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x040021EA RID: 8682
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x040021EB RID: 8683
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x040021EC RID: 8684
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x040021ED RID: 8685
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x040021EE RID: 8686
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x040021EF RID: 8687
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x040021F0 RID: 8688
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x040021F1 RID: 8689
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x040021F2 RID: 8690
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x040021F3 RID: 8691
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x040021F4 RID: 8692
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x040021F5 RID: 8693
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x040021F6 RID: 8694
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x040021F7 RID: 8695
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x040021F8 RID: 8696
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x040021F9 RID: 8697
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x040021FA RID: 8698
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x040021FB RID: 8699
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x040021FC RID: 8700
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x040021FD RID: 8701
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x040021FE RID: 8702
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x040021FF RID: 8703
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x04002200 RID: 8704
	private const string Str_Eighties = "Eighties";

	// Token: 0x04002201 RID: 8705
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x04002202 RID: 8706
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x04002203 RID: 8707
	private const string Str_Debug = "Debug";

	// Token: 0x04002204 RID: 8708
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x04002205 RID: 8709
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x04002206 RID: 8710
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x04002207 RID: 8711
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x04002208 RID: 8712
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x04002209 RID: 8713
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x0400220A RID: 8714
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x0400220B RID: 8715
	private const string Str_AbductionTarget = "AbductionTarget";

	// Token: 0x0400220C RID: 8716
	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";
}
