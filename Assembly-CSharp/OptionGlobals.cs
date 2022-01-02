using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class OptionGlobals
{
	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DB658 File Offset: 0x000D9858
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DB684 File Offset: 0x000D9884
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
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DB6B0 File Offset: 0x000D98B0
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DB6DC File Offset: 0x000D98DC
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
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DB708 File Offset: 0x000D9908
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DB734 File Offset: 0x000D9934
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
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DB760 File Offset: 0x000D9960
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DB78C File Offset: 0x000D998C
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
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DB7B8 File Offset: 0x000D99B8
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DB7E4 File Offset: 0x000D99E4
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
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DB810 File Offset: 0x000D9A10
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DB83C File Offset: 0x000D9A3C
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
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x000DB868 File Offset: 0x000D9A68
	// (set) Token: 0x06001633 RID: 5683 RVA: 0x000DB894 File Offset: 0x000D9A94
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
	// (get) Token: 0x06001634 RID: 5684 RVA: 0x000DB8C0 File Offset: 0x000D9AC0
	// (set) Token: 0x06001635 RID: 5685 RVA: 0x000DB8EC File Offset: 0x000D9AEC
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
	// (get) Token: 0x06001636 RID: 5686 RVA: 0x000DB918 File Offset: 0x000D9B18
	// (set) Token: 0x06001637 RID: 5687 RVA: 0x000DB944 File Offset: 0x000D9B44
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
	// (get) Token: 0x06001638 RID: 5688 RVA: 0x000DB970 File Offset: 0x000D9B70
	// (set) Token: 0x06001639 RID: 5689 RVA: 0x000DB99C File Offset: 0x000D9B9C
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
	// (get) Token: 0x0600163A RID: 5690 RVA: 0x000DB9C8 File Offset: 0x000D9BC8
	// (set) Token: 0x0600163B RID: 5691 RVA: 0x000DB9F4 File Offset: 0x000D9BF4
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
	// (get) Token: 0x0600163C RID: 5692 RVA: 0x000DBA20 File Offset: 0x000D9C20
	// (set) Token: 0x0600163D RID: 5693 RVA: 0x000DBA4C File Offset: 0x000D9C4C
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
	// (get) Token: 0x0600163E RID: 5694 RVA: 0x000DBA78 File Offset: 0x000D9C78
	// (set) Token: 0x0600163F RID: 5695 RVA: 0x000DBAA4 File Offset: 0x000D9CA4
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
	// (get) Token: 0x06001640 RID: 5696 RVA: 0x000DBAD0 File Offset: 0x000D9CD0
	// (set) Token: 0x06001641 RID: 5697 RVA: 0x000DBAFC File Offset: 0x000D9CFC
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
	// (get) Token: 0x06001642 RID: 5698 RVA: 0x000DBB28 File Offset: 0x000D9D28
	// (set) Token: 0x06001643 RID: 5699 RVA: 0x000DBB54 File Offset: 0x000D9D54
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
	// (get) Token: 0x06001644 RID: 5700 RVA: 0x000DBB80 File Offset: 0x000D9D80
	// (set) Token: 0x06001645 RID: 5701 RVA: 0x000DBBAC File Offset: 0x000D9DAC
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
	// (get) Token: 0x06001646 RID: 5702 RVA: 0x000DBBD8 File Offset: 0x000D9DD8
	// (set) Token: 0x06001647 RID: 5703 RVA: 0x000DBC04 File Offset: 0x000D9E04
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
	// (get) Token: 0x06001648 RID: 5704 RVA: 0x000DBC30 File Offset: 0x000D9E30
	// (set) Token: 0x06001649 RID: 5705 RVA: 0x000DBC5C File Offset: 0x000D9E5C
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
	// (get) Token: 0x0600164A RID: 5706 RVA: 0x000DBC88 File Offset: 0x000D9E88
	// (set) Token: 0x0600164B RID: 5707 RVA: 0x000DBCB4 File Offset: 0x000D9EB4
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
	// (get) Token: 0x0600164C RID: 5708 RVA: 0x000DBCE0 File Offset: 0x000D9EE0
	// (set) Token: 0x0600164D RID: 5709 RVA: 0x000DBD0C File Offset: 0x000D9F0C
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
	// (get) Token: 0x0600164E RID: 5710 RVA: 0x000DBD38 File Offset: 0x000D9F38
	// (set) Token: 0x0600164F RID: 5711 RVA: 0x000DBD64 File Offset: 0x000D9F64
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
	// (get) Token: 0x06001650 RID: 5712 RVA: 0x000DBD90 File Offset: 0x000D9F90
	// (set) Token: 0x06001651 RID: 5713 RVA: 0x000DBDBC File Offset: 0x000D9FBC
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
	// (get) Token: 0x06001652 RID: 5714 RVA: 0x000DBDE8 File Offset: 0x000D9FE8
	// (set) Token: 0x06001653 RID: 5715 RVA: 0x000DBE14 File Offset: 0x000DA014
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
	// (get) Token: 0x06001654 RID: 5716 RVA: 0x000DBE40 File Offset: 0x000DA040
	// (set) Token: 0x06001655 RID: 5717 RVA: 0x000DBE6C File Offset: 0x000DA06C
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
	// (get) Token: 0x06001656 RID: 5718 RVA: 0x000DBE98 File Offset: 0x000DA098
	// (set) Token: 0x06001657 RID: 5719 RVA: 0x000DBEC4 File Offset: 0x000DA0C4
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
	// (get) Token: 0x06001658 RID: 5720 RVA: 0x000DBEF0 File Offset: 0x000DA0F0
	// (set) Token: 0x06001659 RID: 5721 RVA: 0x000DBF1C File Offset: 0x000DA11C
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
	// (get) Token: 0x0600165A RID: 5722 RVA: 0x000DBF48 File Offset: 0x000DA148
	// (set) Token: 0x0600165B RID: 5723 RVA: 0x000DBF74 File Offset: 0x000DA174
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
	// (get) Token: 0x0600165C RID: 5724 RVA: 0x000DBFA0 File Offset: 0x000DA1A0
	// (set) Token: 0x0600165D RID: 5725 RVA: 0x000DBFCC File Offset: 0x000DA1CC
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
	// (get) Token: 0x0600165E RID: 5726 RVA: 0x000DBFF8 File Offset: 0x000DA1F8
	// (set) Token: 0x0600165F RID: 5727 RVA: 0x000DC024 File Offset: 0x000DA224
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
	// (get) Token: 0x06001660 RID: 5728 RVA: 0x000DC050 File Offset: 0x000DA250
	// (set) Token: 0x06001661 RID: 5729 RVA: 0x000DC07C File Offset: 0x000DA27C
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
	// (get) Token: 0x06001662 RID: 5730 RVA: 0x000DC0A8 File Offset: 0x000DA2A8
	// (set) Token: 0x06001663 RID: 5731 RVA: 0x000DC0D4 File Offset: 0x000DA2D4
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
	// (get) Token: 0x06001664 RID: 5732 RVA: 0x000DC100 File Offset: 0x000DA300
	// (set) Token: 0x06001665 RID: 5733 RVA: 0x000DC12C File Offset: 0x000DA32C
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
	// (get) Token: 0x06001666 RID: 5734 RVA: 0x000DC158 File Offset: 0x000DA358
	// (set) Token: 0x06001667 RID: 5735 RVA: 0x000DC184 File Offset: 0x000DA384
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
	// (get) Token: 0x06001668 RID: 5736 RVA: 0x000DC1B0 File Offset: 0x000DA3B0
	// (set) Token: 0x06001669 RID: 5737 RVA: 0x000DC1DC File Offset: 0x000DA3DC
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
	// (get) Token: 0x0600166A RID: 5738 RVA: 0x000DC208 File Offset: 0x000DA408
	// (set) Token: 0x0600166B RID: 5739 RVA: 0x000DC234 File Offset: 0x000DA434
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
	// (get) Token: 0x0600166C RID: 5740 RVA: 0x000DC260 File Offset: 0x000DA460
	// (set) Token: 0x0600166D RID: 5741 RVA: 0x000DC28C File Offset: 0x000DA48C
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
	// (get) Token: 0x0600166E RID: 5742 RVA: 0x000DC2B8 File Offset: 0x000DA4B8
	// (set) Token: 0x0600166F RID: 5743 RVA: 0x000DC2E4 File Offset: 0x000DA4E4
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
	// (get) Token: 0x06001670 RID: 5744 RVA: 0x000DC310 File Offset: 0x000DA510
	// (set) Token: 0x06001671 RID: 5745 RVA: 0x000DC33C File Offset: 0x000DA53C
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

	// Token: 0x06001672 RID: 5746 RVA: 0x000DC368 File Offset: 0x000DA568
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

	// Token: 0x040021F7 RID: 8695
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x040021F8 RID: 8696
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x040021F9 RID: 8697
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x040021FA RID: 8698
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x040021FB RID: 8699
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x040021FC RID: 8700
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x040021FD RID: 8701
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x040021FE RID: 8702
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x040021FF RID: 8703
	private const string Str_Vsync = "Vsync";

	// Token: 0x04002200 RID: 8704
	private const string Str_Fog = "Fog";

	// Token: 0x04002201 RID: 8705
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x04002202 RID: 8706
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x04002203 RID: 8707
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x04002204 RID: 8708
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x04002205 RID: 8709
	private const string Str_RimLight = "RimLight";

	// Token: 0x04002206 RID: 8710
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x04002207 RID: 8711
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x04002208 RID: 8712
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x04002209 RID: 8713
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x0400220A RID: 8714
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x0400220B RID: 8715
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x0400220C RID: 8716
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x0400220D RID: 8717
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x0400220E RID: 8718
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x0400220F RID: 8719
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x04002210 RID: 8720
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x04002211 RID: 8721
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x04002212 RID: 8722
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x04002213 RID: 8723
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x04002214 RID: 8724
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x04002215 RID: 8725
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x04002216 RID: 8726
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x04002217 RID: 8727
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x04002218 RID: 8728
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x04002219 RID: 8729
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x0400221A RID: 8730
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x0400221B RID: 8731
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x0400221C RID: 8732
	private const string Str_DisableTint = "DisableTint";
}
