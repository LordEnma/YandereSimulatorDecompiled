using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000282 RID: 642
public class DetectReloadScript : MonoBehaviour
{
	// Token: 0x06001390 RID: 5008 RVA: 0x000B474D File Offset: 0x000B294D
	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.ResetPostProcessingSettings();
	}

	// Token: 0x06001391 RID: 5009 RVA: 0x000B4760 File Offset: 0x000B2960
	private void OnBeforeAssemblyReload()
	{
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x000B4762 File Offset: 0x000B2962
	private void OnAfterAssemblyReload()
	{
		this.ResetSettings = true;
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B476C File Offset: 0x000B296C
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

	// Token: 0x06001394 RID: 5012 RVA: 0x000B4818 File Offset: 0x000B2A18
	private void Update()
	{
		if (this.ResetSettings)
		{
			this.ResetPostProcessingSettings();
			this.ResetSettings = false;
		}
	}

	// Token: 0x04001CF6 RID: 7414
	public PostProcessingProfile Profile;

	// Token: 0x04001CF7 RID: 7415
	public bool ResetSettings;
}
