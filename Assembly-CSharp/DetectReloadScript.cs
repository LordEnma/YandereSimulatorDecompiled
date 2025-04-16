using UnityEngine;
using UnityEngine.PostProcessing;

public class DetectReloadScript : MonoBehaviour
{
	private static DetectReloadScript instance;

	public PostProcessingProfile Profile;

	public bool ResetSettings;

	private void Start()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
		ResetPostProcessingSettings();
	}

	private void OnBeforeAssemblyReload()
	{
	}

	private void OnAfterAssemblyReload()
	{
		ResetSettings = true;
	}

	private void ResetPostProcessingSettings()
	{
		Profile.fog.enabled = OptionGlobals.Fog;
		Profile.antialiasing.enabled = !OptionGlobals.DisablePostAliasing;
		Profile.ambientOcclusion.enabled = !OptionGlobals.DisableObscurance;
		Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
		Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
		Profile.bloom.enabled = !OptionGlobals.DisableBloom;
		Profile.chromaticAberration.enabled = !OptionGlobals.DisableAbberation;
		Profile.vignette.enabled = !OptionGlobals.DisableVignette;
	}

	private void Update()
	{
		if (ResetSettings)
		{
			ResetPostProcessingSettings();
			ResetSettings = false;
		}
	}
}
