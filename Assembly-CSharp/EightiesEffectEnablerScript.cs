// Decompiled with JetBrains decompiler
// Type: EightiesEffectEnablerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using RetroAesthetics;
using UnityEngine;

public class EightiesEffectEnablerScript : MonoBehaviour
{
  public RetroCameraEffect EightiesEffects;
  public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;
  public int Eights;

  public void Start()
  {
    if ((Object) this.EightiesEffects != (Object) null)
    {
      this.EightiesEffects.enabled = GameGlobals.Eighties;
      if ((Object) this.EightiesFilter != (Object) null)
        this.EightiesFilter.enabled = GameGlobals.Eighties;
    }
    this.UpdateEightiesEffects();
  }

  public void UpdateEightiesEffects()
  {
    if ((Object) this.EightiesEffects != (Object) null)
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
    if ((Object) this.EightiesFilter != (Object) null)
      this.EightiesFilter.enabled = !OptionGlobals.DisableTint;
    else
      Debug.Log((object) ("No 80s tint in this scene. Consider adding one to " + this.gameObject.name + "?"));
  }
}
