using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x060013F9 RID: 5113 RVA: 0x000BD9AC File Offset: 0x000BBBAC
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

	// Token: 0x060013FA RID: 5114 RVA: 0x000BD9FC File Offset: 0x000BBBFC
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

	// Token: 0x04001DC4 RID: 7620
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001DC5 RID: 7621
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001DC6 RID: 7622
	public int Eights;
}
