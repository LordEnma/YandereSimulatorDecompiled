using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029F RID: 671
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x0600141F RID: 5151 RVA: 0x000BFB80 File Offset: 0x000BDD80
	public void Start()
	{
		if (this.EightiesEffects != null)
		{
			this.EightiesEffects.enabled = GameGlobals.Eighties;
			if (this.EightiesFilter != null)
			{
				this.EightiesFilter.enabled = GameGlobals.Eighties;
			}
		}
		this.UpdateEightiesEffects();
	}

	// Token: 0x06001420 RID: 5152 RVA: 0x000BFBD0 File Offset: 0x000BDDD0
	public void UpdateEightiesEffects()
	{
		if (this.EightiesEffects != null)
		{
			this.EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
			this.EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
			this.EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
			this.EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
			this.EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
			this.EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
			this.EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
			this.EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		}
		if (this.EightiesFilter != null)
		{
			this.EightiesFilter.enabled = !OptionGlobals.DisableTint;
			return;
		}
		Debug.Log("No 80s tint in this scene. Consider adding one to " + base.gameObject.name + "?");
	}

	// Token: 0x04001E2A RID: 7722
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001E2B RID: 7723
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001E2C RID: 7724
	public int Eights;
}
