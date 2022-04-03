using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x06001415 RID: 5141 RVA: 0x000BF450 File Offset: 0x000BD650
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

	// Token: 0x06001416 RID: 5142 RVA: 0x000BF4A0 File Offset: 0x000BD6A0
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

	// Token: 0x04001E1E RID: 7710
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001E1F RID: 7711
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001E20 RID: 7712
	public int Eights;
}
