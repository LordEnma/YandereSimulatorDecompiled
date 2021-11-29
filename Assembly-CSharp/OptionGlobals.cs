using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class OptionGlobals
{
	// Token: 0x170003CD RID: 973
	// (get) Token: 0x0600161F RID: 5663 RVA: 0x000DAC48 File Offset: 0x000D8E48
	// (set) Token: 0x06001620 RID: 5664 RVA: 0x000DAC74 File Offset: 0x000D8E74
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
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DACA0 File Offset: 0x000D8EA0
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DACCC File Offset: 0x000D8ECC
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
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DACF8 File Offset: 0x000D8EF8
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DAD24 File Offset: 0x000D8F24
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
	// (get) Token: 0x06001625 RID: 5669 RVA: 0x000DAD50 File Offset: 0x000D8F50
	// (set) Token: 0x06001626 RID: 5670 RVA: 0x000DAD7C File Offset: 0x000D8F7C
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
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DADA8 File Offset: 0x000D8FA8
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DADD4 File Offset: 0x000D8FD4
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
	// (get) Token: 0x06001629 RID: 5673 RVA: 0x000DAE00 File Offset: 0x000D9000
	// (set) Token: 0x0600162A RID: 5674 RVA: 0x000DAE2C File Offset: 0x000D902C
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
	// (get) Token: 0x0600162B RID: 5675 RVA: 0x000DAE58 File Offset: 0x000D9058
	// (set) Token: 0x0600162C RID: 5676 RVA: 0x000DAE84 File Offset: 0x000D9084
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
	// (get) Token: 0x0600162D RID: 5677 RVA: 0x000DAEB0 File Offset: 0x000D90B0
	// (set) Token: 0x0600162E RID: 5678 RVA: 0x000DAEDC File Offset: 0x000D90DC
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
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x000DAF08 File Offset: 0x000D9108
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x000DAF34 File Offset: 0x000D9134
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
	// (get) Token: 0x06001631 RID: 5681 RVA: 0x000DAF60 File Offset: 0x000D9160
	// (set) Token: 0x06001632 RID: 5682 RVA: 0x000DAF8C File Offset: 0x000D918C
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
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DAFB8 File Offset: 0x000D91B8
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DAFE4 File Offset: 0x000D91E4
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
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DB010 File Offset: 0x000D9210
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DB03C File Offset: 0x000D923C
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
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DB068 File Offset: 0x000D9268
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DB094 File Offset: 0x000D9294
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
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DB0C0 File Offset: 0x000D92C0
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DB0EC File Offset: 0x000D92EC
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
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DB118 File Offset: 0x000D9318
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DB144 File Offset: 0x000D9344
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
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DB170 File Offset: 0x000D9370
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DB19C File Offset: 0x000D939C
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
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DB1C8 File Offset: 0x000D93C8
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DB1F4 File Offset: 0x000D93F4
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
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DB220 File Offset: 0x000D9420
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DB24C File Offset: 0x000D944C
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
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DB278 File Offset: 0x000D9478
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DB2A4 File Offset: 0x000D94A4
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
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DB2D0 File Offset: 0x000D94D0
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DB2FC File Offset: 0x000D94FC
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
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DB328 File Offset: 0x000D9528
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DB354 File Offset: 0x000D9554
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
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DB380 File Offset: 0x000D9580
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DB3AC File Offset: 0x000D95AC
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
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DB3D8 File Offset: 0x000D95D8
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DB404 File Offset: 0x000D9604
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
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000DB430 File Offset: 0x000D9630
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000DB45C File Offset: 0x000D965C
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
	// (get) Token: 0x0600164F RID: 5711 RVA: 0x000DB488 File Offset: 0x000D9688
	// (set) Token: 0x06001650 RID: 5712 RVA: 0x000DB4B4 File Offset: 0x000D96B4
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
	// (get) Token: 0x06001651 RID: 5713 RVA: 0x000DB4E0 File Offset: 0x000D96E0
	// (set) Token: 0x06001652 RID: 5714 RVA: 0x000DB50C File Offset: 0x000D970C
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
	// (get) Token: 0x06001653 RID: 5715 RVA: 0x000DB538 File Offset: 0x000D9738
	// (set) Token: 0x06001654 RID: 5716 RVA: 0x000DB564 File Offset: 0x000D9764
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
	// (get) Token: 0x06001655 RID: 5717 RVA: 0x000DB590 File Offset: 0x000D9790
	// (set) Token: 0x06001656 RID: 5718 RVA: 0x000DB5BC File Offset: 0x000D97BC
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
	// (get) Token: 0x06001657 RID: 5719 RVA: 0x000DB5E8 File Offset: 0x000D97E8
	// (set) Token: 0x06001658 RID: 5720 RVA: 0x000DB614 File Offset: 0x000D9814
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
	// (get) Token: 0x06001659 RID: 5721 RVA: 0x000DB640 File Offset: 0x000D9840
	// (set) Token: 0x0600165A RID: 5722 RVA: 0x000DB66C File Offset: 0x000D986C
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
	// (get) Token: 0x0600165B RID: 5723 RVA: 0x000DB698 File Offset: 0x000D9898
	// (set) Token: 0x0600165C RID: 5724 RVA: 0x000DB6C4 File Offset: 0x000D98C4
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
	// (get) Token: 0x0600165D RID: 5725 RVA: 0x000DB6F0 File Offset: 0x000D98F0
	// (set) Token: 0x0600165E RID: 5726 RVA: 0x000DB71C File Offset: 0x000D991C
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
	// (get) Token: 0x0600165F RID: 5727 RVA: 0x000DB748 File Offset: 0x000D9948
	// (set) Token: 0x06001660 RID: 5728 RVA: 0x000DB774 File Offset: 0x000D9974
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
	// (get) Token: 0x06001661 RID: 5729 RVA: 0x000DB7A0 File Offset: 0x000D99A0
	// (set) Token: 0x06001662 RID: 5730 RVA: 0x000DB7CC File Offset: 0x000D99CC
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
	// (get) Token: 0x06001663 RID: 5731 RVA: 0x000DB7F8 File Offset: 0x000D99F8
	// (set) Token: 0x06001664 RID: 5732 RVA: 0x000DB824 File Offset: 0x000D9A24
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
	// (get) Token: 0x06001665 RID: 5733 RVA: 0x000DB850 File Offset: 0x000D9A50
	// (set) Token: 0x06001666 RID: 5734 RVA: 0x000DB87C File Offset: 0x000D9A7C
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
	// (get) Token: 0x06001667 RID: 5735 RVA: 0x000DB8A8 File Offset: 0x000D9AA8
	// (set) Token: 0x06001668 RID: 5736 RVA: 0x000DB8D4 File Offset: 0x000D9AD4
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
	// (get) Token: 0x06001669 RID: 5737 RVA: 0x000DB900 File Offset: 0x000D9B00
	// (set) Token: 0x0600166A RID: 5738 RVA: 0x000DB92C File Offset: 0x000D9B2C
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

	// Token: 0x0600166B RID: 5739 RVA: 0x000DB958 File Offset: 0x000D9B58
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

	// Token: 0x040021D4 RID: 8660
	private const string Str_DisableBloom = "DisableBloom";

	// Token: 0x040021D5 RID: 8661
	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	// Token: 0x040021D6 RID: 8662
	private const string Str_DisableOutlines = "DisableOutlines";

	// Token: 0x040021D7 RID: 8663
	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	// Token: 0x040021D8 RID: 8664
	private const string Str_EnableShadows = "EnableShadows";

	// Token: 0x040021D9 RID: 8665
	private const string Str_DisableObscurance = "DisableObscurance";

	// Token: 0x040021DA RID: 8666
	private const string Str_DrawDistance = "DrawDistance";

	// Token: 0x040021DB RID: 8667
	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	// Token: 0x040021DC RID: 8668
	private const string Str_Vsync = "Vsync";

	// Token: 0x040021DD RID: 8669
	private const string Str_Fog = "Fog";

	// Token: 0x040021DE RID: 8670
	private const string Str_FPSIndex = "FPSIndex";

	// Token: 0x040021DF RID: 8671
	private const string Str_HighPopulation = "HighPopulation";

	// Token: 0x040021E0 RID: 8672
	private const string Str_LowDetailStudents = "LowDetailStudents";

	// Token: 0x040021E1 RID: 8673
	private const string Str_ParticleCount = "ParticleCount";

	// Token: 0x040021E2 RID: 8674
	private const string Str_RimLight = "RimLight";

	// Token: 0x040021E3 RID: 8675
	private const string Str_DepthOfField = "DepthOfField";

	// Token: 0x040021E4 RID: 8676
	private const string Str_Sensitivity = "Sensitivity";

	// Token: 0x040021E5 RID: 8677
	private const string Str_InvertAxisX = "InvertAxisX";

	// Token: 0x040021E6 RID: 8678
	private const string Str_InvertAxisY = "InvertAxisY";

	// Token: 0x040021E7 RID: 8679
	private const string Str_TutorialsOff = "TutorialsOff";

	// Token: 0x040021E8 RID: 8680
	private const string Str_HintsOff = "HintsOff";

	// Token: 0x040021E9 RID: 8681
	private const string Str_CameraPosition = "CameraPosition";

	// Token: 0x040021EA RID: 8682
	private const string Str_ToggleRun = "ToggleRun";

	// Token: 0x040021EB RID: 8683
	private const string Str_OpaqueWindows = "OpaqueWindows";

	// Token: 0x040021EC RID: 8684
	private const string Str_ColorGrading = "ColorGrading";

	// Token: 0x040021ED RID: 8685
	private const string Str_ToggleGrass = "ToggleGrass";

	// Token: 0x040021EE RID: 8686
	private const string Str_HairPhysics = "HairPhysics";

	// Token: 0x040021EF RID: 8687
	private const string Str_MotionBlur = "MotionBlur";

	// Token: 0x040021F0 RID: 8688
	private const string Str_DisplayFPS = "DisplayFPS";

	// Token: 0x040021F1 RID: 8689
	private const string Str_SubtitleSize = "SubtitleSize";

	// Token: 0x040021F2 RID: 8690
	private const string Str_DisableStatic = "DisableStatic";

	// Token: 0x040021F3 RID: 8691
	private const string Str_DisableDisplacement = "DisableDisplacement";

	// Token: 0x040021F4 RID: 8692
	private const string Str_DisableAbberation = "DisableAbberation";

	// Token: 0x040021F5 RID: 8693
	private const string Str_DisableVignette = "DisableVignette";

	// Token: 0x040021F6 RID: 8694
	private const string Str_DisableDistortion = "DisableDistortion";

	// Token: 0x040021F7 RID: 8695
	private const string Str_DisableScanlines = "DisableScanlines";

	// Token: 0x040021F8 RID: 8696
	private const string Str_DisableNoise = "DisableNoise";

	// Token: 0x040021F9 RID: 8697
	private const string Str_DisableTint = "DisableTint";
}
