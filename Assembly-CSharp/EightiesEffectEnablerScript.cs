using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x06001403 RID: 5123 RVA: 0x000BE298 File Offset: 0x000BC498
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

	// Token: 0x06001404 RID: 5124 RVA: 0x000BE2E8 File Offset: 0x000BC4E8
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
		}
	}

	// Token: 0x04001DEA RID: 7658
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001DEB RID: 7659
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001DEC RID: 7660
	public int Eights;
}
