using UnityEngine;

public static class AudioGlobals
{
	private const string Str_EffectVolume = "EffectVolume";

	private const string Str_MusicVolume = "MusicVolume";

	private const string Str_VoiceVolume = "VoiceVolume";

	private const string Str_VolumeInitialized = "VolumeInitialized";

	public static float EffectVolume
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_EffectVolume");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_EffectVolume", value);
		}
	}

	public static float MusicVolume
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_MusicVolume");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_MusicVolume", value);
		}
	}

	public static float VoiceVolume
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile + "_VoiceVolume");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_VoiceVolume", value);
		}
	}

	public static bool VolumeInitialized
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_VolumeInitialized");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_VolumeInitialized", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_EffectVolume");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_MusicVolume");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_VoiceVolume");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_VolumeInitialized");
	}
}
