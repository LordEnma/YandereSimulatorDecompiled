using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class OptionGlobals
{
	// Token: 0x170003CF RID: 975
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DCA84 File Offset: 0x000DAC84
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DCAB0 File Offset: 0x000DACB0
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

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DCADC File Offset: 0x000DACDC
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DCB08 File Offset: 0x000DAD08
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

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DCB34 File Offset: 0x000DAD34
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DCB60 File Offset: 0x000DAD60
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

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DCB8C File Offset: 0x000DAD8C
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DCBB8 File Offset: 0x000DADB8
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

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DCBE4 File Offset: 0x000DADE4
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DCC10 File Offset: 0x000DAE10
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

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DCC3C File Offset: 0x000DAE3C
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DCC68 File Offset: 0x000DAE68
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

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DCC94 File Offset: 0x000DAE94
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DCCC0 File Offset: 0x000DAEC0
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

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DCCEC File Offset: 0x000DAEEC
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DCD18 File Offset: 0x000DAF18
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

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000DCD44 File Offset: 0x000DAF44
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000DCD70 File Offset: 0x000DAF70
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

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x0600164F RID: 5711 RVA: 0x000DCD9C File Offset: 0x000DAF9C
	// (set) Token: 0x06001650 RID: 5712 RVA: 0x000DCDC8 File Offset: 0x000DAFC8
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

	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x06001651 RID: 5713 RVA: 0x000DCDF4 File Offset: 0x000DAFF4
	// (set) Token: 0x06001652 RID: 5714 RVA: 0x000DCE20 File Offset: 0x000DB020
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

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x06001653 RID: 5715 RVA: 0x000DCE4C File Offset: 0x000DB04C
	// (set) Token: 0x06001654 RID: 5716 RVA: 0x000DCE78 File Offset: 0x000DB078
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

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x06001655 RID: 5717 RVA: 0x000DCEA4 File Offset: 0x000DB0A4
	// (set) Token: 0x06001656 RID: 5718 RVA: 0x000DCED0 File Offset: 0x000DB0D0
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

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06001657 RID: 5719 RVA: 0x000DCEFC File Offset: 0x000DB0FC
	// (set) Token: 0x06001658 RID: 5720 RVA: 0x000DCF28 File Offset: 0x000DB128
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

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x06001659 RID: 5721 RVA: 0x000DCF54 File Offset: 0x000DB154
	// (set) Token: 0x0600165A RID: 5722 RVA: 0x000DCF80 File Offset: 0x000DB180
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

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x0600165B RID: 5723 RVA: 0x000DCFAC File Offset: 0x000DB1AC
	// (set) Token: 0x0600165C RID: 5724 RVA: 0x000DCFD8 File Offset: 0x000DB1D8
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

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x0600165D RID: 5725 RVA: 0x000DD004 File Offset: 0x000DB204
	// (set) Token: 0x0600165E RID: 5726 RVA: 0x000DD030 File Offset: 0x000DB230
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

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x0600165F RID: 5727 RVA: 0x000DD05C File Offset: 0x000DB25C
	// (set) Token: 0x06001660 RID: 5728 RVA: 0x000DD088 File Offset: 0x000DB288
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

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x06001661 RID: 5729 RVA: 0x000DD0B4 File Offset: 0x000DB2B4
	// (set) Token: 0x06001662 RID: 5730 RVA: 0x000DD0E0 File Offset: 0x000DB2E0
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

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06001663 RID: 5731 RVA: 0x000DD10C File Offset: 0x000DB30C
	// (set) Token: 0x06001664 RID: 5732 RVA: 0x000DD138 File Offset: 0x000DB338
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

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06001665 RID: 5733 RVA: 0x000DD164 File Offset: 0x000DB364
	// (set) Token: 0x06001666 RID: 5734 RVA: 0x000DD190 File Offset: 0x000DB390
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

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06001667 RID: 5735 RVA: 0x000DD1BC File Offset: 0x000DB3BC
	// (set) Token: 0x06001668 RID: 5736 RVA: 0x000DD1E8 File Offset: 0x000DB3E8
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

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x06001669 RID: 5737 RVA: 0x000DD214 File Offset: 0x000DB414
	// (set) Token: 0x0600166A RID: 5738 RVA: 0x000DD240 File Offset: 0x000DB440
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

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x0600166B RID: 5739 RVA: 0x000DD26C File Offset: 0x000DB46C
	// (set) Token: 0x0600166C RID: 5740 RVA: 0x000DD298 File Offset: 0x000DB498
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

	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x0600166D RID: 5741 RVA: 0x000DD2C4 File Offset: 0x000DB4C4
	// (set) Token: 0x0600166E RID: 5742 RVA: 0x000DD2F0 File Offset: 0x000DB4F0
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

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x0600166F RID: 5743 RVA: 0x000DD31C File Offset: 0x000DB51C
	// (set) Token: 0x06001670 RID: 5744 RVA: 0x000DD348 File Offset: 0x000DB548
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

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x06001671 RID: 5745 RVA: 0x000DD374 File Offset: 0x000DB574
	// (set) Token: 0x06001672 RID: 5746 RVA: 0x000DD3A0 File Offset: 0x000DB5A0
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

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x06001673 RID: 5747 RVA: 0x000DD3CC File Offset: 0x000DB5CC
	// (set) Token: 0x06001674 RID: 5748 RVA: 0x000DD3F8 File Offset: 0x000DB5F8
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

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x06001675 RID: 5749 RVA: 0x000DD424 File Offset: 0x000DB624
	// (set) Token: 0x06001676 RID: 5750 RVA: 0x000DD450 File Offset: 0x000DB650
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

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x06001677 RID: 5751 RVA: 0x000DD47C File Offset: 0x000DB67C
	// (set) Token: 0x06001678 RID: 5752 RVA: 0x000DD4A8 File Offset: 0x000DB6A8
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

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x06001679 RID: 5753 RVA: 0x000DD4D4 File Offset: 0x000DB6D4
	// (set) Token: 0x0600167A RID: 5754 RVA: 0x000DD500 File Offset: 0x000DB700
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

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x0600167B RID: 5755 RVA: 0x000DD52C File Offset: 0x000DB72C
	// (set) Token: 0x0600167C RID: 5756 RVA: 0x000DD558 File Offset: 0x000DB758
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

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x0600167D RID: 5757 RVA: 0x000DD584 File Offset: 0x000DB784
	// (set) Token: 0x0600167E RID: 5758 RVA: 0x000DD5B0 File Offset: 0x000DB7B0
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

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x0600167F RID: 5759 RVA: 0x000DD5DC File Offset: 0x000DB7DC
	// (set) Token: 0x06001680 RID: 5760 RVA: 0x000DD608 File Offset: 0x000DB808
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

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x06001681 RID: 5761 RVA: 0x000DD634 File Offset: 0x000DB834
	// (set) Token: 0x06001682 RID: 5762 RVA: 0x000DD660 File Offset: 0x000DB860
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

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x06001683 RID: 5763 RVA: 0x000DD68C File Offset: 0x000DB88C
	// (set) Token: 0x06001684 RID: 5764 RVA: 0x000DD6B8 File Offset: 0x000DB8B8
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

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x06001685 RID: 5765 RVA: 0x000DD6E4 File Offset: 0x000DB8E4
	// (set) Token: 0x06001686 RID: 5766 RVA: 0x000DD710 File Offset: 0x000DB910
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

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x06001687 RID: 5767 RVA: 0x000DD73C File Offset: 0x000DB93C
	// (set) Token: 0x06001688 RID: 5768 RVA: 0x000DD768 File Offset: 0x000DB968
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

	// Token: 0x06001689 RID: 5769 RVA: 0x000DD794 File Offset: 0x000DB994
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

	// Token: 0x0400221C RID: 8732
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x0400221D RID: 8733
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x0400221E RID: 8734
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x0400221F RID: 8735
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x04002220 RID: 8736
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x04002221 RID: 8737
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x04002222 RID: 8738
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x04002223 RID: 8739
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x04002224 RID: 8740
	private const string Str_Vsync = "Vsync";

	// Token: 0x04002225 RID: 8741
	private const string Str_Fog = "Fog";

	// Token: 0x04002226 RID: 8742
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x04002227 RID: 8743
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x04002228 RID: 8744
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x04002229 RID: 8745
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x0400222A RID: 8746
	private const string Str_RimLight = "RimLight";

	// Token: 0x0400222B RID: 8747
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x0400222C RID: 8748
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x0400222D RID: 8749
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x0400222E RID: 8750
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x0400222F RID: 8751
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x04002230 RID: 8752
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x04002231 RID: 8753
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x04002232 RID: 8754
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x04002233 RID: 8755
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x04002234 RID: 8756
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x04002235 RID: 8757
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x04002236 RID: 8758
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x04002237 RID: 8759
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x04002238 RID: 8760
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x04002239 RID: 8761
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x0400223A RID: 8762
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x0400223B RID: 8763
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x0400223C RID: 8764
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x0400223D RID: 8765
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x0400223E RID: 8766
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x0400223F RID: 8767
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x04002240 RID: 8768
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x04002241 RID: 8769
	private const string Str_DisableTint = "DisableTint";
}
