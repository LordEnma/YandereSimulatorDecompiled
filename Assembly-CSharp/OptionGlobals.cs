using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class OptionGlobals
{
	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x06001650 RID: 5712 RVA: 0x000DDA58 File Offset: 0x000DBC58
	// (set) Token: 0x06001651 RID: 5713 RVA: 0x000DDA84 File Offset: 0x000DBC84
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

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06001652 RID: 5714 RVA: 0x000DDAB0 File Offset: 0x000DBCB0
	// (set) Token: 0x06001653 RID: 5715 RVA: 0x000DDADC File Offset: 0x000DBCDC
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

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06001654 RID: 5716 RVA: 0x000DDB08 File Offset: 0x000DBD08
	// (set) Token: 0x06001655 RID: 5717 RVA: 0x000DDB34 File Offset: 0x000DBD34
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

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x06001656 RID: 5718 RVA: 0x000DDB60 File Offset: 0x000DBD60
	// (set) Token: 0x06001657 RID: 5719 RVA: 0x000DDB8C File Offset: 0x000DBD8C
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

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x06001658 RID: 5720 RVA: 0x000DDBB8 File Offset: 0x000DBDB8
	// (set) Token: 0x06001659 RID: 5721 RVA: 0x000DDBE4 File Offset: 0x000DBDE4
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

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x0600165A RID: 5722 RVA: 0x000DDC10 File Offset: 0x000DBE10
	// (set) Token: 0x0600165B RID: 5723 RVA: 0x000DDC3C File Offset: 0x000DBE3C
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

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x0600165C RID: 5724 RVA: 0x000DDC68 File Offset: 0x000DBE68
	// (set) Token: 0x0600165D RID: 5725 RVA: 0x000DDC94 File Offset: 0x000DBE94
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

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x0600165E RID: 5726 RVA: 0x000DDCC0 File Offset: 0x000DBEC0
	// (set) Token: 0x0600165F RID: 5727 RVA: 0x000DDCEC File Offset: 0x000DBEEC
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

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x06001660 RID: 5728 RVA: 0x000DDD18 File Offset: 0x000DBF18
	// (set) Token: 0x06001661 RID: 5729 RVA: 0x000DDD44 File Offset: 0x000DBF44
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

	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x06001662 RID: 5730 RVA: 0x000DDD70 File Offset: 0x000DBF70
	// (set) Token: 0x06001663 RID: 5731 RVA: 0x000DDD9C File Offset: 0x000DBF9C
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

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x06001664 RID: 5732 RVA: 0x000DDDC8 File Offset: 0x000DBFC8
	// (set) Token: 0x06001665 RID: 5733 RVA: 0x000DDDF4 File Offset: 0x000DBFF4
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

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x06001666 RID: 5734 RVA: 0x000DDE20 File Offset: 0x000DC020
	// (set) Token: 0x06001667 RID: 5735 RVA: 0x000DDE4C File Offset: 0x000DC04C
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

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06001668 RID: 5736 RVA: 0x000DDE78 File Offset: 0x000DC078
	// (set) Token: 0x06001669 RID: 5737 RVA: 0x000DDEA4 File Offset: 0x000DC0A4
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

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x0600166A RID: 5738 RVA: 0x000DDED0 File Offset: 0x000DC0D0
	// (set) Token: 0x0600166B RID: 5739 RVA: 0x000DDEFC File Offset: 0x000DC0FC
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

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x0600166C RID: 5740 RVA: 0x000DDF28 File Offset: 0x000DC128
	// (set) Token: 0x0600166D RID: 5741 RVA: 0x000DDF54 File Offset: 0x000DC154
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

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x0600166E RID: 5742 RVA: 0x000DDF80 File Offset: 0x000DC180
	// (set) Token: 0x0600166F RID: 5743 RVA: 0x000DDFAC File Offset: 0x000DC1AC
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

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x06001670 RID: 5744 RVA: 0x000DDFD8 File Offset: 0x000DC1D8
	// (set) Token: 0x06001671 RID: 5745 RVA: 0x000DE004 File Offset: 0x000DC204
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

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x06001672 RID: 5746 RVA: 0x000DE030 File Offset: 0x000DC230
	// (set) Token: 0x06001673 RID: 5747 RVA: 0x000DE05C File Offset: 0x000DC25C
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

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06001674 RID: 5748 RVA: 0x000DE088 File Offset: 0x000DC288
	// (set) Token: 0x06001675 RID: 5749 RVA: 0x000DE0B4 File Offset: 0x000DC2B4
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

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06001676 RID: 5750 RVA: 0x000DE0E0 File Offset: 0x000DC2E0
	// (set) Token: 0x06001677 RID: 5751 RVA: 0x000DE10C File Offset: 0x000DC30C
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

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06001678 RID: 5752 RVA: 0x000DE138 File Offset: 0x000DC338
	// (set) Token: 0x06001679 RID: 5753 RVA: 0x000DE164 File Offset: 0x000DC364
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

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x0600167A RID: 5754 RVA: 0x000DE190 File Offset: 0x000DC390
	// (set) Token: 0x0600167B RID: 5755 RVA: 0x000DE1BC File Offset: 0x000DC3BC
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

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x0600167C RID: 5756 RVA: 0x000DE1E8 File Offset: 0x000DC3E8
	// (set) Token: 0x0600167D RID: 5757 RVA: 0x000DE214 File Offset: 0x000DC414
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

	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x0600167E RID: 5758 RVA: 0x000DE240 File Offset: 0x000DC440
	// (set) Token: 0x0600167F RID: 5759 RVA: 0x000DE26C File Offset: 0x000DC46C
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

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x06001680 RID: 5760 RVA: 0x000DE298 File Offset: 0x000DC498
	// (set) Token: 0x06001681 RID: 5761 RVA: 0x000DE2C4 File Offset: 0x000DC4C4
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

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x06001682 RID: 5762 RVA: 0x000DE2F0 File Offset: 0x000DC4F0
	// (set) Token: 0x06001683 RID: 5763 RVA: 0x000DE31C File Offset: 0x000DC51C
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

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x06001684 RID: 5764 RVA: 0x000DE348 File Offset: 0x000DC548
	// (set) Token: 0x06001685 RID: 5765 RVA: 0x000DE374 File Offset: 0x000DC574
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

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x000DE3A0 File Offset: 0x000DC5A0
	// (set) Token: 0x06001687 RID: 5767 RVA: 0x000DE3CC File Offset: 0x000DC5CC
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

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x000DE3F8 File Offset: 0x000DC5F8
	// (set) Token: 0x06001689 RID: 5769 RVA: 0x000DE424 File Offset: 0x000DC624
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

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x000DE450 File Offset: 0x000DC650
	// (set) Token: 0x0600168B RID: 5771 RVA: 0x000DE47C File Offset: 0x000DC67C
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

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x000DE4A8 File Offset: 0x000DC6A8
	// (set) Token: 0x0600168D RID: 5773 RVA: 0x000DE4D4 File Offset: 0x000DC6D4
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

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x000DE500 File Offset: 0x000DC700
	// (set) Token: 0x0600168F RID: 5775 RVA: 0x000DE52C File Offset: 0x000DC72C
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

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x000DE558 File Offset: 0x000DC758
	// (set) Token: 0x06001691 RID: 5777 RVA: 0x000DE584 File Offset: 0x000DC784
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

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x06001692 RID: 5778 RVA: 0x000DE5B0 File Offset: 0x000DC7B0
	// (set) Token: 0x06001693 RID: 5779 RVA: 0x000DE5DC File Offset: 0x000DC7DC
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

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x06001694 RID: 5780 RVA: 0x000DE608 File Offset: 0x000DC808
	// (set) Token: 0x06001695 RID: 5781 RVA: 0x000DE634 File Offset: 0x000DC834
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

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x06001696 RID: 5782 RVA: 0x000DE660 File Offset: 0x000DC860
	// (set) Token: 0x06001697 RID: 5783 RVA: 0x000DE68C File Offset: 0x000DC88C
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

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x06001698 RID: 5784 RVA: 0x000DE6B8 File Offset: 0x000DC8B8
	// (set) Token: 0x06001699 RID: 5785 RVA: 0x000DE6E4 File Offset: 0x000DC8E4
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

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x0600169A RID: 5786 RVA: 0x000DE710 File Offset: 0x000DC910
	// (set) Token: 0x0600169B RID: 5787 RVA: 0x000DE73C File Offset: 0x000DC93C
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

	// Token: 0x0600169C RID: 5788 RVA: 0x000DE768 File Offset: 0x000DC968
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

	// Token: 0x04002253 RID: 8787
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x04002254 RID: 8788
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x04002255 RID: 8789
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x04002256 RID: 8790
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x04002257 RID: 8791
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x04002258 RID: 8792
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x04002259 RID: 8793
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x0400225A RID: 8794
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x0400225B RID: 8795
	private const string Str_Vsync = "Vsync";

	// Token: 0x0400225C RID: 8796
	private const string Str_Fog = "Fog";

	// Token: 0x0400225D RID: 8797
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x0400225E RID: 8798
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x0400225F RID: 8799
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x04002260 RID: 8800
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x04002261 RID: 8801
	private const string Str_RimLight = "RimLight";

	// Token: 0x04002262 RID: 8802
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x04002263 RID: 8803
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x04002264 RID: 8804
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x04002265 RID: 8805
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x04002266 RID: 8806
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x04002267 RID: 8807
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x04002268 RID: 8808
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x04002269 RID: 8809
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x0400226A RID: 8810
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x0400226B RID: 8811
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x0400226C RID: 8812
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x0400226D RID: 8813
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x0400226E RID: 8814
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x0400226F RID: 8815
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x04002270 RID: 8816
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x04002271 RID: 8817
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x04002272 RID: 8818
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x04002273 RID: 8819
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x04002274 RID: 8820
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x04002275 RID: 8821
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x04002276 RID: 8822
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x04002277 RID: 8823
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x04002278 RID: 8824
	private const string Str_DisableTint = "DisableTint";
}
