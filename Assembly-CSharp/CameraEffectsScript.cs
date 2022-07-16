// Decompiled with JetBrains decompiler
// Type: CameraEffectsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using XInputDotNetPure;

public class CameraEffectsScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public YandereScript Yandere;
  public UITexture MurderStreaks;
  public UITexture Streaks;
  public float EffectStrength;
  public float VibrationTimer;
  public bool VibrationCheck;
  public bool OneCamera;
  public AudioClip MurderNoticed;
  public AudioClip SenpaiNoticed;
  public AudioClip Noticed;
  public Camera SmartphoneCamera;

  private void Start()
  {
    this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 0.0f);
    this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 0.0f);
    this.Profile.colorGrading.enabled = false;
    this.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
  }

  private void Update()
  {
    if (this.VibrationCheck)
    {
      this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0.0f, Time.deltaTime);
      if ((double) this.VibrationTimer == 0.0)
      {
        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        this.VibrationCheck = false;
      }
    }
    if ((double) this.Streaks.color.a > 0.0)
    {
      this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, this.Streaks.color.a - Time.deltaTime);
      this.UpdateBloom((float) (1.0 + (double) this.Streaks.color.a * 4.0));
      if ((double) this.Streaks.color.a <= 0.0)
        this.UpdateBloom(1f);
    }
    if ((double) this.MurderStreaks.color.a > 0.0)
      this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, this.MurderStreaks.color.a - Time.deltaTime);
    float target = (float) (1.0 - (double) this.Yandere.Sanity * 0.00999999977648258);
    if ((double) this.EffectStrength == (double) target)
      return;
    this.EffectStrength = Mathf.MoveTowards(this.EffectStrength, target, Time.deltaTime * 10f);
    this.UpdateVignette(this.EffectStrength);
    this.UpdateChroma(this.EffectStrength);
  }

  public void Alarm()
  {
    GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
    this.VibrationCheck = true;
    this.VibrationTimer = 0.1f;
    this.UpdateBloom(2f);
    this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
    AudioSource.PlayClipAtPoint(this.Noticed, this.Yandere.Head.position);
  }

  public void MurderWitnessed()
  {
    GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
    this.VibrationCheck = true;
    this.VibrationTimer = 0.1f;
    this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
    this.Yandere.Jukebox.SFX.PlayOneShot(this.Yandere.Noticed ? this.SenpaiNoticed : this.MurderNoticed);
  }

  public void DisableCamera()
  {
    if (!this.OneCamera)
      this.OneCamera = true;
    else
      this.OneCamera = false;
  }

  public void UpdateBloom(float Bloom)
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.intensity = Bloom;
    this.Profile.bloom.settings = settings;
  }

  public void UpdateThreshold(float Threshold)
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.threshold = Threshold;
    this.Profile.bloom.settings = settings;
  }

  public void UpdateBloomKnee(float Knee)
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.softKnee = Knee;
    this.Profile.bloom.settings = settings;
  }

  public void UpdateBloomRadius(float Radius)
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.radius = Radius;
    this.Profile.bloom.settings = settings;
  }

  public void EnableBloom() => this.Profile.bloom.enabled = true;

  public void UpdateChroma(float Chroma) => this.Profile.chromaticAberration.settings = this.Profile.chromaticAberration.settings with
  {
    intensity = Chroma
  };

  public void UpdateVignette(float Vignette)
  {
    VignetteModel.Settings settings = this.Profile.vignette.settings;
    if (!this.Yandere.YandereVision)
      settings.intensity = (float) (0.5 - 0.25 * (double) Vignette);
    settings.color = new Color((float) (1.0 - 1.0 * (double) Vignette), (float) (0.75 - 0.75 * (double) Vignette), (float) (1.0 - 1.0 * (double) Vignette), 1f);
    this.Profile.vignette.settings = settings;
  }

  public void SetVignettePink() => this.Profile.vignette.settings = this.Profile.vignette.settings with
  {
    color = new Color(1f, 0.75f, 1f, 1f)
  };

  public void UpdateDOF(float Focus)
  {
    Focus *= (float) (((double) Screen.width / 1280.0 + (double) Screen.height / 720.0) * 0.5);
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = Focus
    };
  }
}
