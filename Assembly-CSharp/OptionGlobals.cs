using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class OptionGlobals
{
	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DB408 File Offset: 0x000D9608
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DB434 File Offset: 0x000D9634
	public static bool DisableBloom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableBloom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableBloom", value);
		}
	}

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DB460 File Offset: 0x000D9660
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DB48C File Offset: 0x000D968C
	public static int DisableFarAnimations
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DisableFarAnimations");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DisableFarAnimations", value);
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DB4B8 File Offset: 0x000D96B8
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DB4E4 File Offset: 0x000D96E4
	public static bool DisableOutlines
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableOutlines");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableOutlines", value);
		}
	}

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DB510 File Offset: 0x000D9710
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DB53C File Offset: 0x000D973C
	public static bool DisablePostAliasing
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisablePostAliasing");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisablePostAliasing", value);
		}
	}

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DB568 File Offset: 0x000D9768
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DB594 File Offset: 0x000D9794
	public static bool EnableShadows
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_EnableShadows");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_EnableShadows", value);
		}
	}

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DB5C0 File Offset: 0x000D97C0
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DB5EC File Offset: 0x000D97EC
	public static bool DisableObscurance
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableObscurance");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableObscurance", value);
		}
	}

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x000DB618 File Offset: 0x000D9818
	// (set) Token: 0x06001633 RID: 5683 RVA: 0x000DB644 File Offset: 0x000D9844
	public static int DrawDistance
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DrawDistance");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DrawDistance", value);
		}
	}

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x06001634 RID: 5684 RVA: 0x000DB670 File Offset: 0x000D9870
	// (set) Token: 0x06001635 RID: 5685 RVA: 0x000DB69C File Offset: 0x000D989C
	public static int DrawDistanceLimit
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_DrawDistanceLimit");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_DrawDistanceLimit", value);
		}
	}

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x06001636 RID: 5686 RVA: 0x000DB6C8 File Offset: 0x000D98C8
	// (set) Token: 0x06001637 RID: 5687 RVA: 0x000DB6F4 File Offset: 0x000D98F4
	public static bool Vsync
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_Vsync");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_Vsync", value);
		}
	}

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x06001638 RID: 5688 RVA: 0x000DB720 File Offset: 0x000D9920
	// (set) Token: 0x06001639 RID: 5689 RVA: 0x000DB74C File Offset: 0x000D994C
	public static bool Fog
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_Fog");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_Fog", value);
		}
	}

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x0600163A RID: 5690 RVA: 0x000DB778 File Offset: 0x000D9978
	// (set) Token: 0x0600163B RID: 5691 RVA: 0x000DB7A4 File Offset: 0x000D99A4
	public static int FPSIndex
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_FPSIndex");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_FPSIndex", value);
		}
	}

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x0600163C RID: 5692 RVA: 0x000DB7D0 File Offset: 0x000D99D0
	// (set) Token: 0x0600163D RID: 5693 RVA: 0x000DB7FC File Offset: 0x000D99FC
	public static bool HighPopulation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HighPopulation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HighPopulation", value);
		}
	}

	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x0600163E RID: 5694 RVA: 0x000DB828 File Offset: 0x000D9A28
	// (set) Token: 0x0600163F RID: 5695 RVA: 0x000DB854 File Offset: 0x000D9A54
	public static int LowDetailStudents
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_LowDetailStudents");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_LowDetailStudents", value);
		}
	}

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x06001640 RID: 5696 RVA: 0x000DB880 File Offset: 0x000D9A80
	// (set) Token: 0x06001641 RID: 5697 RVA: 0x000DB8AC File Offset: 0x000D9AAC
	public static int ParticleCount
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_ParticleCount");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_ParticleCount", value);
		}
	}

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x06001642 RID: 5698 RVA: 0x000DB8D8 File Offset: 0x000D9AD8
	// (set) Token: 0x06001643 RID: 5699 RVA: 0x000DB904 File Offset: 0x000D9B04
	public static bool RimLight
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_RimLight");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_RimLight", value);
		}
	}

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06001644 RID: 5700 RVA: 0x000DB930 File Offset: 0x000D9B30
	// (set) Token: 0x06001645 RID: 5701 RVA: 0x000DB95C File Offset: 0x000D9B5C
	public static bool DepthOfField
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DepthOfField");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DepthOfField", value);
		}
	}

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x06001646 RID: 5702 RVA: 0x000DB988 File Offset: 0x000D9B88
	// (set) Token: 0x06001647 RID: 5703 RVA: 0x000DB9B4 File Offset: 0x000D9BB4
	public static bool MotionBlur
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_MotionBlur");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_MotionBlur", value);
		}
	}

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x06001648 RID: 5704 RVA: 0x000DB9E0 File Offset: 0x000D9BE0
	// (set) Token: 0x06001649 RID: 5705 RVA: 0x000DBA0C File Offset: 0x000D9C0C
	public static int Sensitivity
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_Sensitivity");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_Sensitivity", value);
		}
	}

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x0600164A RID: 5706 RVA: 0x000DBA38 File Offset: 0x000D9C38
	// (set) Token: 0x0600164B RID: 5707 RVA: 0x000DBA64 File Offset: 0x000D9C64
	public static bool InvertAxisX
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_InvertAxisX");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_InvertAxisX", value);
		}
	}

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x0600164C RID: 5708 RVA: 0x000DBA90 File Offset: 0x000D9C90
	// (set) Token: 0x0600164D RID: 5709 RVA: 0x000DBABC File Offset: 0x000D9CBC
	public static bool InvertAxisY
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_InvertAxisY");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_InvertAxisY", value);
		}
	}

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x0600164E RID: 5710 RVA: 0x000DBAE8 File Offset: 0x000D9CE8
	// (set) Token: 0x0600164F RID: 5711 RVA: 0x000DBB14 File Offset: 0x000D9D14
	public static bool SubtitleSize
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_SubtitleSize");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_SubtitleSize", value);
		}
	}

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06001650 RID: 5712 RVA: 0x000DBB40 File Offset: 0x000D9D40
	// (set) Token: 0x06001651 RID: 5713 RVA: 0x000DBB6C File Offset: 0x000D9D6C
	public static bool TutorialsOff
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_TutorialsOff");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_TutorialsOff", value);
		}
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06001652 RID: 5714 RVA: 0x000DBB98 File Offset: 0x000D9D98
	// (set) Token: 0x06001653 RID: 5715 RVA: 0x000DBBC4 File Offset: 0x000D9DC4
	public static bool HintsOff
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HintsOff");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HintsOff", value);
		}
	}

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06001654 RID: 5716 RVA: 0x000DBBF0 File Offset: 0x000D9DF0
	// (set) Token: 0x06001655 RID: 5717 RVA: 0x000DBC1C File Offset: 0x000D9E1C
	public static int CameraPosition
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0.ToString() + "_CameraPosition");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0.ToString() + "_CameraPosition", value);
		}
	}

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x06001656 RID: 5718 RVA: 0x000DBC48 File Offset: 0x000D9E48
	// (set) Token: 0x06001657 RID: 5719 RVA: 0x000DBC74 File Offset: 0x000D9E74
	public static bool ToggleRun
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ToggleRun");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ToggleRun", value);
		}
	}

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x06001658 RID: 5720 RVA: 0x000DBCA0 File Offset: 0x000D9EA0
	// (set) Token: 0x06001659 RID: 5721 RVA: 0x000DBCCC File Offset: 0x000D9ECC
	public static bool OpaqueWindows
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_OpaqueWindows");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_OpaqueWindows", value);
		}
	}

	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x0600165A RID: 5722 RVA: 0x000DBCF8 File Offset: 0x000D9EF8
	// (set) Token: 0x0600165B RID: 5723 RVA: 0x000DBD24 File Offset: 0x000D9F24
	public static bool ColorGrading
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ColorGrading");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ColorGrading", value);
		}
	}

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x0600165C RID: 5724 RVA: 0x000DBD50 File Offset: 0x000D9F50
	// (set) Token: 0x0600165D RID: 5725 RVA: 0x000DBD7C File Offset: 0x000D9F7C
	public static bool ToggleGrass
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_ToggleGrass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_ToggleGrass", value);
		}
	}

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x0600165E RID: 5726 RVA: 0x000DBDA8 File Offset: 0x000D9FA8
	// (set) Token: 0x0600165F RID: 5727 RVA: 0x000DBDD4 File Offset: 0x000D9FD4
	public static bool HairPhysics
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_HairPhysics");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_HairPhysics", value);
		}
	}

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x06001660 RID: 5728 RVA: 0x000DBE00 File Offset: 0x000DA000
	// (set) Token: 0x06001661 RID: 5729 RVA: 0x000DBE2C File Offset: 0x000DA02C
	public static bool DisplayFPS
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisplayFPS");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisplayFPS", value);
		}
	}

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x06001662 RID: 5730 RVA: 0x000DBE58 File Offset: 0x000DA058
	// (set) Token: 0x06001663 RID: 5731 RVA: 0x000DBE84 File Offset: 0x000DA084
	public static bool DisableStatic
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableStatic");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableStatic", value);
		}
	}

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x06001664 RID: 5732 RVA: 0x000DBEB0 File Offset: 0x000DA0B0
	// (set) Token: 0x06001665 RID: 5733 RVA: 0x000DBEDC File Offset: 0x000DA0DC
	public static bool DisableDisplacement
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableDisplacement");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableDisplacement", value);
		}
	}

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x06001666 RID: 5734 RVA: 0x000DBF08 File Offset: 0x000DA108
	// (set) Token: 0x06001667 RID: 5735 RVA: 0x000DBF34 File Offset: 0x000DA134
	public static bool DisableAbberation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableAbberation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableAbberation", value);
		}
	}

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x06001668 RID: 5736 RVA: 0x000DBF60 File Offset: 0x000DA160
	// (set) Token: 0x06001669 RID: 5737 RVA: 0x000DBF8C File Offset: 0x000DA18C
	public static bool DisableVignette
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableVignette");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableVignette", value);
		}
	}

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x0600166A RID: 5738 RVA: 0x000DBFB8 File Offset: 0x000DA1B8
	// (set) Token: 0x0600166B RID: 5739 RVA: 0x000DBFE4 File Offset: 0x000DA1E4
	public static bool DisableDistortion
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableDistortion");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableDistortion", value);
		}
	}

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x0600166C RID: 5740 RVA: 0x000DC010 File Offset: 0x000DA210
	// (set) Token: 0x0600166D RID: 5741 RVA: 0x000DC03C File Offset: 0x000DA23C
	public static bool DisableScanlines
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableScanlines");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableScanlines", value);
		}
	}

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x0600166E RID: 5742 RVA: 0x000DC068 File Offset: 0x000DA268
	// (set) Token: 0x0600166F RID: 5743 RVA: 0x000DC094 File Offset: 0x000DA294
	public static bool DisableNoise
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableNoise");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableNoise", value);
		}
	}

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x06001670 RID: 5744 RVA: 0x000DC0C0 File Offset: 0x000DA2C0
	// (set) Token: 0x06001671 RID: 5745 RVA: 0x000DC0EC File Offset: 0x000DA2EC
	public static bool DisableTint
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0.ToString() + "_DisableTint");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0.ToString() + "_DisableTint", value);
		}
	}

	// Token: 0x06001672 RID: 5746 RVA: 0x000DC118 File Offset: 0x000DA318
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableBloom");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableFarAnimations");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableOutlines");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisablePostAliasing");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnableShadows");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableObscurance");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DrawDistance");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DrawDistanceLimit");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Vsync");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Fog");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FPSIndex");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighPopulation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LowDetailStudents");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ParticleCount");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RimLight");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DepthOfField");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Sensitivity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InvertAxisX");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InvertAxisY");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TutorialsOff");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HintsOff");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CameraPosition");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ToggleRun");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OpaqueWindows");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ColorGrading");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ToggleGrass");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HairPhysics");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MotionBlur");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisplayFPS");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SubtitleSize");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableStatic");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableDisplacement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableAbberation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableVignette");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableDistortion");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableScanlines");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableNoise");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DisableTint");
	}

	// Token: 0x040021F4 RID: 8692
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x040021F5 RID: 8693
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x040021F6 RID: 8694
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x040021F7 RID: 8695
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x040021F8 RID: 8696
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x040021F9 RID: 8697
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x040021FA RID: 8698
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x040021FB RID: 8699
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x040021FC RID: 8700
	private const string Str_Vsync = "Vsync";

	// Token: 0x040021FD RID: 8701
	private const string Str_Fog = "Fog";

	// Token: 0x040021FE RID: 8702
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x040021FF RID: 8703
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x04002200 RID: 8704
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x04002201 RID: 8705
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x04002202 RID: 8706
	private const string Str_RimLight = "RimLight";

	// Token: 0x04002203 RID: 8707
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x04002204 RID: 8708
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x04002205 RID: 8709
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x04002206 RID: 8710
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x04002207 RID: 8711
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x04002208 RID: 8712
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x04002209 RID: 8713
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x0400220A RID: 8714
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x0400220B RID: 8715
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x0400220C RID: 8716
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x0400220D RID: 8717
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x0400220E RID: 8718
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x0400220F RID: 8719
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x04002210 RID: 8720
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x04002211 RID: 8721
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x04002212 RID: 8722
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x04002213 RID: 8723
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x04002214 RID: 8724
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x04002215 RID: 8725
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x04002216 RID: 8726
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x04002217 RID: 8727
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x04002218 RID: 8728
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x04002219 RID: 8729
	private const string Str_DisableTint = "DisableTint";
}
