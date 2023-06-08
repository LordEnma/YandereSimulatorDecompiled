using UnityEngine;

public static class OptionGlobals
{
	private const string Str_DisableBloom = "DisableBloom";

	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	private const string Str_DisableOutlines = "DisableOutlines";

	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	private const string Str_EnableShadows = "EnableShadows";

	private const string Str_DisableObscurance = "DisableObscurance";

	private const string Str_DrawDistance = "DrawDistance";

	private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

	private const string Str_Vsync = "Vsync";

	private const string Str_Fog = "Fog";

	private const string Str_FPSIndex = "FPSIndex";

	private const string Str_HighPopulation = "HighPopulation";

	private const string Str_LowDetailStudents = "LowDetailStudents";

	private const string Str_ParticleCount = "ParticleCount";

	private const string Str_RimLight = "RimLight";

	private const string Str_DepthOfField = "DepthOfField";

	private const string Str_Sensitivity = "Sensitivity";

	private const string Str_InvertAxisX = "InvertAxisX";

	private const string Str_InvertAxisY = "InvertAxisY";

	private const string Str_TutorialsOff = "TutorialsOff";

	private const string Str_HintsOff = "HintsOff";

	private const string Str_CameraPosition = "CameraPosition";

	private const string Str_ToggleRun = "ToggleRun";

	private const string Str_OpaqueWindows = "OpaqueWindows";

	private const string Str_ColorGrading = "ColorGrading";

	private const string Str_ToggleGrass = "ToggleGrass";

	private const string Str_HairPhysics = "HairPhysics";

	private const string Str_MotionBlur = "MotionBlur";

	private const string Str_DisplayFPS = "DisplayFPS";

	private const string Str_SubtitleSize = "SubtitleSize";

	private const string Str_RivalDeathSlowMo = "RivalDeathSlowMo";

	private const string Str_DisableStatic = "DisableStatic";

	private const string Str_DisableDisplacement = "DisableDisplacement";

	private const string Str_DisableAbberation = "DisableAbberation";

	private const string Str_DisableVignette = "DisableVignette";

	private const string Str_DisableDistortion = "DisableDistortion";

	private const string Str_DisableScanlines = "DisableScanlines";

	private const string Str_DisableNoise = "DisableNoise";

	private const string Str_DisableTint = "DisableTint";

	private const string Str_ResolutionID = "ResolutionID";

	private const string Str_MinimalistHUD = "MinimalistHUD";

	public static bool DisableBloom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableBloom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableBloom", value);
		}
	}

	public static int DisableFarAnimations
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_DisableFarAnimations");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_DisableFarAnimations", value);
		}
	}

	public static bool DisableOutlines
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableOutlines");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableOutlines", value);
		}
	}

	public static bool DisablePostAliasing
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisablePostAliasing");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisablePostAliasing", value);
		}
	}

	public static bool EnableShadows
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_EnableShadows");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_EnableShadows", value);
		}
	}

	public static bool DisableObscurance
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableObscurance");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableObscurance", value);
		}
	}

	public static int DrawDistance
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_DrawDistance");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_DrawDistance", value);
		}
	}

	public static int DrawDistanceLimit
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_DrawDistanceLimit");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_DrawDistanceLimit", value);
		}
	}

	public static bool Vsync
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_Vsync");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_Vsync", value);
		}
	}

	public static bool Fog
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_Fog");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_Fog", value);
		}
	}

	public static int FPSIndex
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_FPSIndex");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_FPSIndex", value);
		}
	}

	public static bool HighPopulation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_HighPopulation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_HighPopulation", value);
		}
	}

	public static int LowDetailStudents
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_LowDetailStudents");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_LowDetailStudents", value);
		}
	}

	public static int ParticleCount
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_ParticleCount");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_ParticleCount", value);
		}
	}

	public static bool RimLight
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_RimLight");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_RimLight", value);
		}
	}

	public static bool DepthOfField
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DepthOfField");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DepthOfField", value);
		}
	}

	public static bool MotionBlur
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_MotionBlur");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_MotionBlur", value);
		}
	}

	public static int Sensitivity
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_Sensitivity");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_Sensitivity", value);
		}
	}

	public static bool InvertAxisX
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_InvertAxisX");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_InvertAxisX", value);
		}
	}

	public static bool InvertAxisY
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_InvertAxisY");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_InvertAxisY", value);
		}
	}

	public static int SubtitleSize
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_SubtitleSize");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_SubtitleSize", value);
		}
	}

	public static bool RivalDeathSlowMo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_RivalDeathSlowMo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_RivalDeathSlowMo", value);
		}
	}

	public static bool TutorialsOff
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_TutorialsOff");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_TutorialsOff", value);
		}
	}

	public static bool HintsOff
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_HintsOff");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_HintsOff", value);
		}
	}

	public static int CameraPosition
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_CameraPosition");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_CameraPosition", value);
		}
	}

	public static bool ToggleRun
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_ToggleRun");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_ToggleRun", value);
		}
	}

	public static bool OpaqueWindows
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_OpaqueWindows");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_OpaqueWindows", value);
		}
	}

	public static bool ColorGrading
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_ColorGrading");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_ColorGrading", value);
		}
	}

	public static bool ToggleGrass
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_ToggleGrass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_ToggleGrass", value);
		}
	}

	public static bool HairPhysics
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_HairPhysics");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_HairPhysics", value);
		}
	}

	public static bool DisplayFPS
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisplayFPS");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisplayFPS", value);
		}
	}

	public static bool DisableStatic
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableStatic");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableStatic", value);
		}
	}

	public static bool DisableDisplacement
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableDisplacement");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableDisplacement", value);
		}
	}

	public static bool DisableAbberation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableAbberation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableAbberation", value);
		}
	}

	public static bool DisableVignette
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableVignette");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableVignette", value);
		}
	}

	public static bool DisableDistortion
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableDistortion");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableDistortion", value);
		}
	}

	public static bool DisableScanlines
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableScanlines");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableScanlines", value);
		}
	}

	public static bool DisableNoise
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableNoise");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableNoise", value);
		}
	}

	public static bool DisableTint
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_DisableTint");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_DisableTint", value);
		}
	}

	public static int ResolutionID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + 0 + "_ResolutionID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + 0 + "_ResolutionID", value);
		}
	}

	public static bool MinimalistHUD
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + 0 + "_MinimalistHUD");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + 0 + "_MinimalistHUD", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableBloom");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableFarAnimations");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableOutlines");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisablePostAliasing");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EnableShadows");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableObscurance");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DrawDistance");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DrawDistanceLimit");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Vsync");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Fog");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_FPSIndex");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HighPopulation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_LowDetailStudents");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ParticleCount");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RimLight");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DepthOfField");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_Sensitivity");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InvertAxisX");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_InvertAxisY");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_TutorialsOff");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HintsOff");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CameraPosition");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ToggleRun");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_OpaqueWindows");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ColorGrading");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ToggleGrass");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_HairPhysics");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MotionBlur");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisplayFPS");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SubtitleSize");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_RivalDeathSlowMo");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableStatic");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableDisplacement");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableAbberation");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableVignette");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableDistortion");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableScanlines");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableNoise");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_DisableTint");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_ResolutionID");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MinimalistHUD");
	}
}
