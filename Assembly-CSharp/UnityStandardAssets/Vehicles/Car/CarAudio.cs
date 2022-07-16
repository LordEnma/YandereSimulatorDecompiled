// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.CarAudio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  [RequireComponent(typeof (CarController))]
  public class CarAudio : MonoBehaviour
  {
    public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;
    public AudioClip lowAccelClip;
    public AudioClip lowDecelClip;
    public AudioClip highAccelClip;
    public AudioClip highDecelClip;
    public float pitchMultiplier = 1f;
    public float lowPitchMin = 1f;
    public float lowPitchMax = 6f;
    public float highPitchMultiplier = 0.25f;
    public float maxRolloffDistance = 500f;
    public float dopplerLevel = 1f;
    public bool useDoppler = true;
    private AudioSource m_LowAccel;
    private AudioSource m_LowDecel;
    private AudioSource m_HighAccel;
    private AudioSource m_HighDecel;
    private bool m_StartedSound;
    private CarController m_CarController;

    private void StartSound()
    {
      this.m_CarController = this.GetComponent<CarController>();
      this.m_HighAccel = this.SetUpEngineAudioSource(this.highAccelClip);
      if (this.engineSoundStyle == CarAudio.EngineAudioOptions.FourChannel)
      {
        this.m_LowAccel = this.SetUpEngineAudioSource(this.lowAccelClip);
        this.m_LowDecel = this.SetUpEngineAudioSource(this.lowDecelClip);
        this.m_HighDecel = this.SetUpEngineAudioSource(this.highDecelClip);
      }
      this.m_StartedSound = true;
    }

    private void StopSound()
    {
      foreach (Object component in this.GetComponents<AudioSource>())
        Object.Destroy(component);
      this.m_StartedSound = false;
    }

    private void Update()
    {
      float sqrMagnitude = (Camera.main.transform.position - this.transform.position).sqrMagnitude;
      if (this.m_StartedSound && (double) sqrMagnitude > (double) this.maxRolloffDistance * (double) this.maxRolloffDistance)
        this.StopSound();
      if (!this.m_StartedSound && (double) sqrMagnitude < (double) this.maxRolloffDistance * (double) this.maxRolloffDistance)
        this.StartSound();
      if (!this.m_StartedSound)
        return;
      float num1 = Mathf.Min(this.lowPitchMax, CarAudio.ULerp(this.lowPitchMin, this.lowPitchMax, this.m_CarController.Revs));
      if (this.engineSoundStyle == CarAudio.EngineAudioOptions.Simple)
      {
        this.m_HighAccel.pitch = num1 * this.pitchMultiplier * this.highPitchMultiplier;
        this.m_HighAccel.dopplerLevel = this.useDoppler ? this.dopplerLevel : 0.0f;
        this.m_HighAccel.volume = 1f;
      }
      else
      {
        this.m_LowAccel.pitch = num1 * this.pitchMultiplier;
        this.m_LowDecel.pitch = num1 * this.pitchMultiplier;
        this.m_HighAccel.pitch = num1 * this.highPitchMultiplier * this.pitchMultiplier;
        this.m_HighDecel.pitch = num1 * this.highPitchMultiplier * this.pitchMultiplier;
        float num2 = Mathf.Abs(this.m_CarController.AccelInput);
        float num3 = 1f - num2;
        float num4 = Mathf.InverseLerp(0.2f, 0.8f, this.m_CarController.Revs);
        float num5 = 1f - num4;
        float num6 = (float) (1.0 - (1.0 - (double) num4) * (1.0 - (double) num4));
        float num7 = (float) (1.0 - (1.0 - (double) num5) * (1.0 - (double) num5));
        float num8 = (float) (1.0 - (1.0 - (double) num2) * (1.0 - (double) num2));
        float num9 = (float) (1.0 - (1.0 - (double) num3) * (1.0 - (double) num3));
        this.m_LowAccel.volume = num7 * num8;
        this.m_LowDecel.volume = num7 * num9;
        this.m_HighAccel.volume = num6 * num8;
        this.m_HighDecel.volume = num6 * num9;
        this.m_HighAccel.dopplerLevel = this.useDoppler ? this.dopplerLevel : 0.0f;
        this.m_LowAccel.dopplerLevel = this.useDoppler ? this.dopplerLevel : 0.0f;
        this.m_HighDecel.dopplerLevel = this.useDoppler ? this.dopplerLevel : 0.0f;
        this.m_LowDecel.dopplerLevel = this.useDoppler ? this.dopplerLevel : 0.0f;
      }
    }

    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
      AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
      audioSource.clip = clip;
      audioSource.volume = 0.0f;
      audioSource.loop = true;
      audioSource.time = Random.Range(0.0f, clip.length);
      audioSource.Play();
      audioSource.minDistance = 5f;
      audioSource.maxDistance = this.maxRolloffDistance;
      audioSource.dopplerLevel = 0.0f;
      return audioSource;
    }

    private static float ULerp(float from, float to, float value) => (float) ((1.0 - (double) value) * (double) from + (double) value * (double) to);

    public enum EngineAudioOptions
    {
      Simple,
      FourChannel,
    }
  }
}
