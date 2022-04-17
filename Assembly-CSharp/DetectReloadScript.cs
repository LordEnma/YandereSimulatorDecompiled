using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000281 RID: 641
public class DetectReloadScript : MonoBehaviour
{
	// Token: 0x0600138A RID: 5002 RVA: 0x000B406D File Offset: 0x000B226D
	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.ResetPostProcessingSettings();
	}

	// Token: 0x0600138B RID: 5003 RVA: 0x000B4080 File Offset: 0x000B2280
	private void OnBeforeAssemblyReload()
	{
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000B4082 File Offset: 0x000B2282
	private void OnAfterAssemblyReload()
	{
		this.ResetSettings = true;
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x000B408C File Offset: 0x000B228C
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

	// Token: 0x0600138E RID: 5006 RVA: 0x000B4138 File Offset: 0x000B2338
	private void Update()
	{
		if (this.ResetSettings)
		{
			this.ResetPostProcessingSettings();
			this.ResetSettings = false;
		}
	}

	// Token: 0x04001CE7 RID: 7399
	public PostProcessingProfile Profile;

	// Token: 0x04001CE8 RID: 7400
	public bool ResetSettings;
}
