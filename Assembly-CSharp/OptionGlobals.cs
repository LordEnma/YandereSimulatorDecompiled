using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class OptionGlobals
{
	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x06001654 RID: 5716 RVA: 0x000DDEF4 File Offset: 0x000DC0F4
	// (set) Token: 0x06001655 RID: 5717 RVA: 0x000DDF20 File Offset: 0x000DC120
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
	// (get) Token: 0x06001656 RID: 5718 RVA: 0x000DDF4C File Offset: 0x000DC14C
	// (set) Token: 0x06001657 RID: 5719 RVA: 0x000DDF78 File Offset: 0x000DC178
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
	// (get) Token: 0x06001658 RID: 5720 RVA: 0x000DDFA4 File Offset: 0x000DC1A4
	// (set) Token: 0x06001659 RID: 5721 RVA: 0x000DDFD0 File Offset: 0x000DC1D0
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
	// (get) Token: 0x0600165A RID: 5722 RVA: 0x000DDFFC File Offset: 0x000DC1FC
	// (set) Token: 0x0600165B RID: 5723 RVA: 0x000DE028 File Offset: 0x000DC228
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
	// (get) Token: 0x0600165C RID: 5724 RVA: 0x000DE054 File Offset: 0x000DC254
	// (set) Token: 0x0600165D RID: 5725 RVA: 0x000DE080 File Offset: 0x000DC280
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
	// (get) Token: 0x0600165E RID: 5726 RVA: 0x000DE0AC File Offset: 0x000DC2AC
	// (set) Token: 0x0600165F RID: 5727 RVA: 0x000DE0D8 File Offset: 0x000DC2D8
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
	// (get) Token: 0x06001660 RID: 5728 RVA: 0x000DE104 File Offset: 0x000DC304
	// (set) Token: 0x06001661 RID: 5729 RVA: 0x000DE130 File Offset: 0x000DC330
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
	// (get) Token: 0x06001662 RID: 5730 RVA: 0x000DE15C File Offset: 0x000DC35C
	// (set) Token: 0x06001663 RID: 5731 RVA: 0x000DE188 File Offset: 0x000DC388
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
	// (get) Token: 0x06001664 RID: 5732 RVA: 0x000DE1B4 File Offset: 0x000DC3B4
	// (set) Token: 0x06001665 RID: 5733 RVA: 0x000DE1E0 File Offset: 0x000DC3E0
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
	// (get) Token: 0x06001666 RID: 5734 RVA: 0x000DE20C File Offset: 0x000DC40C
	// (set) Token: 0x06001667 RID: 5735 RVA: 0x000DE238 File Offset: 0x000DC438
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
	// (get) Token: 0x06001668 RID: 5736 RVA: 0x000DE264 File Offset: 0x000DC464
	// (set) Token: 0x06001669 RID: 5737 RVA: 0x000DE290 File Offset: 0x000DC490
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
	// (get) Token: 0x0600166A RID: 5738 RVA: 0x000DE2BC File Offset: 0x000DC4BC
	// (set) Token: 0x0600166B RID: 5739 RVA: 0x000DE2E8 File Offset: 0x000DC4E8
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
	// (get) Token: 0x0600166C RID: 5740 RVA: 0x000DE314 File Offset: 0x000DC514
	// (set) Token: 0x0600166D RID: 5741 RVA: 0x000DE340 File Offset: 0x000DC540
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
	// (get) Token: 0x0600166E RID: 5742 RVA: 0x000DE36C File Offset: 0x000DC56C
	// (set) Token: 0x0600166F RID: 5743 RVA: 0x000DE398 File Offset: 0x000DC598
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
	// (get) Token: 0x06001670 RID: 5744 RVA: 0x000DE3C4 File Offset: 0x000DC5C4
	// (set) Token: 0x06001671 RID: 5745 RVA: 0x000DE3F0 File Offset: 0x000DC5F0
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
	// (get) Token: 0x06001672 RID: 5746 RVA: 0x000DE41C File Offset: 0x000DC61C
	// (set) Token: 0x06001673 RID: 5747 RVA: 0x000DE448 File Offset: 0x000DC648
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
	// (get) Token: 0x06001674 RID: 5748 RVA: 0x000DE474 File Offset: 0x000DC674
	// (set) Token: 0x06001675 RID: 5749 RVA: 0x000DE4A0 File Offset: 0x000DC6A0
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
	// (get) Token: 0x06001676 RID: 5750 RVA: 0x000DE4CC File Offset: 0x000DC6CC
	// (set) Token: 0x06001677 RID: 5751 RVA: 0x000DE4F8 File Offset: 0x000DC6F8
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
	// (get) Token: 0x06001678 RID: 5752 RVA: 0x000DE524 File Offset: 0x000DC724
	// (set) Token: 0x06001679 RID: 5753 RVA: 0x000DE550 File Offset: 0x000DC750
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
	// (get) Token: 0x0600167A RID: 5754 RVA: 0x000DE57C File Offset: 0x000DC77C
	// (set) Token: 0x0600167B RID: 5755 RVA: 0x000DE5A8 File Offset: 0x000DC7A8
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
	// (get) Token: 0x0600167C RID: 5756 RVA: 0x000DE5D4 File Offset: 0x000DC7D4
	// (set) Token: 0x0600167D RID: 5757 RVA: 0x000DE600 File Offset: 0x000DC800
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
	// (get) Token: 0x0600167E RID: 5758 RVA: 0x000DE62C File Offset: 0x000DC82C
	// (set) Token: 0x0600167F RID: 5759 RVA: 0x000DE658 File Offset: 0x000DC858
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
	// (get) Token: 0x06001680 RID: 5760 RVA: 0x000DE684 File Offset: 0x000DC884
	// (set) Token: 0x06001681 RID: 5761 RVA: 0x000DE6B0 File Offset: 0x000DC8B0
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
	// (get) Token: 0x06001682 RID: 5762 RVA: 0x000DE6DC File Offset: 0x000DC8DC
	// (set) Token: 0x06001683 RID: 5763 RVA: 0x000DE708 File Offset: 0x000DC908
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
	// (get) Token: 0x06001684 RID: 5764 RVA: 0x000DE734 File Offset: 0x000DC934
	// (set) Token: 0x06001685 RID: 5765 RVA: 0x000DE760 File Offset: 0x000DC960
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
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x000DE78C File Offset: 0x000DC98C
	// (set) Token: 0x06001687 RID: 5767 RVA: 0x000DE7B8 File Offset: 0x000DC9B8
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
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x000DE7E4 File Offset: 0x000DC9E4
	// (set) Token: 0x06001689 RID: 5769 RVA: 0x000DE810 File Offset: 0x000DCA10
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
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x000DE83C File Offset: 0x000DCA3C
	// (set) Token: 0x0600168B RID: 5771 RVA: 0x000DE868 File Offset: 0x000DCA68
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
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x000DE894 File Offset: 0x000DCA94
	// (set) Token: 0x0600168D RID: 5773 RVA: 0x000DE8C0 File Offset: 0x000DCAC0
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
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x000DE8EC File Offset: 0x000DCAEC
	// (set) Token: 0x0600168F RID: 5775 RVA: 0x000DE918 File Offset: 0x000DCB18
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
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x000DE944 File Offset: 0x000DCB44
	// (set) Token: 0x06001691 RID: 5777 RVA: 0x000DE970 File Offset: 0x000DCB70
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
	// (get) Token: 0x06001692 RID: 5778 RVA: 0x000DE99C File Offset: 0x000DCB9C
	// (set) Token: 0x06001693 RID: 5779 RVA: 0x000DE9C8 File Offset: 0x000DCBC8
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
	// (get) Token: 0x06001694 RID: 5780 RVA: 0x000DE9F4 File Offset: 0x000DCBF4
	// (set) Token: 0x06001695 RID: 5781 RVA: 0x000DEA20 File Offset: 0x000DCC20
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
	// (get) Token: 0x06001696 RID: 5782 RVA: 0x000DEA4C File Offset: 0x000DCC4C
	// (set) Token: 0x06001697 RID: 5783 RVA: 0x000DEA78 File Offset: 0x000DCC78
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
	// (get) Token: 0x06001698 RID: 5784 RVA: 0x000DEAA4 File Offset: 0x000DCCA4
	// (set) Token: 0x06001699 RID: 5785 RVA: 0x000DEAD0 File Offset: 0x000DCCD0
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
	// (get) Token: 0x0600169A RID: 5786 RVA: 0x000DEAFC File Offset: 0x000DCCFC
	// (set) Token: 0x0600169B RID: 5787 RVA: 0x000DEB28 File Offset: 0x000DCD28
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
	// (get) Token: 0x0600169C RID: 5788 RVA: 0x000DEB54 File Offset: 0x000DCD54
	// (set) Token: 0x0600169D RID: 5789 RVA: 0x000DEB80 File Offset: 0x000DCD80
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
	// (get) Token: 0x0600169E RID: 5790 RVA: 0x000DEBAC File Offset: 0x000DCDAC
	// (set) Token: 0x0600169F RID: 5791 RVA: 0x000DEBD8 File Offset: 0x000DCDD8
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

	// Token: 0x060016A0 RID: 5792 RVA: 0x000DEC04 File Offset: 0x000DCE04
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

	// Token: 0x0400225C RID: 8796
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x0400225D RID: 8797
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x0400225E RID: 8798
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x0400225F RID: 8799
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x04002260 RID: 8800
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x04002261 RID: 8801
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x04002262 RID: 8802
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x04002263 RID: 8803
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x04002264 RID: 8804
	private const string Str_Vsync = "Vsync";

	// Token: 0x04002265 RID: 8805
	private const string Str_Fog = "Fog";

	// Token: 0x04002266 RID: 8806
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x04002267 RID: 8807
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x04002268 RID: 8808
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x04002269 RID: 8809
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x0400226A RID: 8810
	private const string Str_RimLight = "RimLight";

	// Token: 0x0400226B RID: 8811
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x0400226C RID: 8812
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x0400226D RID: 8813
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x0400226E RID: 8814
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x0400226F RID: 8815
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x04002270 RID: 8816
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x04002271 RID: 8817
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x04002272 RID: 8818
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x04002273 RID: 8819
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x04002274 RID: 8820
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x04002275 RID: 8821
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x04002276 RID: 8822
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x04002277 RID: 8823
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x04002278 RID: 8824
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x04002279 RID: 8825
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x0400227A RID: 8826
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x0400227B RID: 8827
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x0400227C RID: 8828
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x0400227D RID: 8829
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x0400227E RID: 8830
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x0400227F RID: 8831
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x04002280 RID: 8832
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x04002281 RID: 8833
	private const string Str_DisableTint = "DisableTint";
}
