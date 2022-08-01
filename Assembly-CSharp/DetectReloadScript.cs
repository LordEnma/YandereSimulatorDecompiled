// Decompiled with JetBrains decompiler
// Type: DetectReloadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;

public class DetectReloadScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public bool ResetSettings;

  private void Start()
  {
    Object.DontDestroyOnLoad((Object) this.gameObject);
    this.ResetPostProcessingSettings();
  }

  private void OnBeforeAssemblyReload()
  {
  }

  private void OnAfterAssemblyReload() => this.ResetSettings = true;

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

  private void Update()
  {
    if (!this.ResetSettings)
      return;
    this.ResetPostProcessingSettings();
    this.ResetSettings = false;
  }
}
