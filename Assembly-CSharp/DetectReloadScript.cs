using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000281 RID: 641
public class DetectReloadScript : MonoBehaviour
{
	// Token: 0x0600138E RID: 5006 RVA: 0x000B4505 File Offset: 0x000B2705
	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.ResetPostProcessingSettings();
	}

	// Token: 0x0600138F RID: 5007 RVA: 0x000B4518 File Offset: 0x000B2718
	private void OnBeforeAssemblyReload()
	{
	}

	// Token: 0x06001390 RID: 5008 RVA: 0x000B451A File Offset: 0x000B271A
	private void OnAfterAssemblyReload()
	{
		this.ResetSettings = true;
	}

	// Token: 0x06001391 RID: 5009 RVA: 0x000B4524 File Offset: 0x000B2724
	private void ResetPostProcessingSettings()
	{
		this.Profile.fog.enabled = OptionGlobals.Fog;
		this.Profile.antialiasing.enabled = !OptionGlobals.DisablePostAliasing;
		this.Profile.ambientOcclusion.enabled = !OptionGlobals.DisableObscurance;
		this.Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
		this.Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
		this.Profile.bloom.enabled = !OptionGlobals.DisableBloom;
		this.Profile.chromaticAberration.enabled = !OptionGlobals.DisableAbberation;
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x000B45D0 File Offset: 0x000B27D0
	private void Update()
	{
		if (this.ResetSettings)
		{
			this.ResetPostProcessingSettings();
			this.ResetSettings = false;
		}
	}

	// Token: 0x04001CEF RID: 7407
	public PostProcessingProfile Profile;

	// Token: 0x04001CF0 RID: 7408
	public bool ResetSettings;
}
