using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x06001411 RID: 5137 RVA: 0x000BEF2C File Offset: 0x000BD12C
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

	// Token: 0x06001412 RID: 5138 RVA: 0x000BEF7C File Offset: 0x000BD17C
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

	// Token: 0x04001E0C RID: 7692
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001E0D RID: 7693
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001E0E RID: 7694
	public int Eights;
}
