// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplaneAudio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  public class AeroplaneAudio : MonoBehaviour
  {
    [SerializeField]
    private AudioClip m_EngineSound;
    [SerializeField]
    private float m_EngineMinThrottlePitch = 0.4f;
    [SerializeField]
    private float m_EngineMaxThrottlePitch = 2f;
    [SerializeField]
    private float m_EngineFwdSpeedMultiplier = 1f / 500f;
    [SerializeField]
    private AudioClip m_WindSound;
    [SerializeField]
    private float m_WindBasePitch = 0.2f;
    [SerializeField]
    private float m_WindSpeedPitchFactor = 0.004f;
    [SerializeField]
    private float m_WindMaxSpeedVolume = 100f;
    [SerializeField]
    private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();
    private AudioSource m_EngineSoundSource;
    private AudioSource m_WindSoundSource;
    private AeroplaneController m_Plane;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
      this.m_Plane = this.GetComponent<AeroplaneController>();
      this.m_Rigidbody = this.GetComponent<Rigidbody>();
      this.m_EngineSoundSource = this.gameObject.AddComponent<AudioSource>();
      this.m_EngineSoundSource.playOnAwake = false;
      this.m_WindSoundSource = this.gameObject.AddComponent<AudioSource>();
      this.m_WindSoundSource.playOnAwake = false;
      this.m_EngineSoundSource.clip = this.m_EngineSound;
      this.m_WindSoundSource.clip = this.m_WindSound;
      this.m_EngineSoundSource.minDistance = this.m_AdvancedSetttings.engineMinDistance;
      this.m_EngineSoundSource.maxDistance = this.m_AdvancedSetttings.engineMaxDistance;
      this.m_EngineSoundSource.loop = true;
      this.m_EngineSoundSource.dopplerLevel = this.m_AdvancedSetttings.engineDopplerLevel;
      this.m_WindSoundSource.minDistance = this.m_AdvancedSetttings.windMinDistance;
      this.m_WindSoundSource.maxDistance = this.m_AdvancedSetttings.windMaxDistance;
      this.m_WindSoundSource.loop = true;
      this.m_WindSoundSource.dopplerLevel = this.m_AdvancedSetttings.windDopplerLevel;
      this.Update();
      this.m_EngineSoundSource.Play();
      this.m_WindSoundSource.Play();
    }

    private void Update()
    {
      this.m_EngineSoundSource.pitch = Mathf.Lerp(this.m_EngineMinThrottlePitch, this.m_EngineMaxThrottlePitch, Mathf.InverseLerp(0.0f, this.m_Plane.MaxEnginePower, this.m_Plane.EnginePower));
      this.m_EngineSoundSource.pitch += this.m_Plane.ForwardSpeed * this.m_EngineFwdSpeedMultiplier;
      this.m_EngineSoundSource.volume = Mathf.InverseLerp(0.0f, this.m_Plane.MaxEnginePower * this.m_AdvancedSetttings.engineMasterVolume, this.m_Plane.EnginePower);
      float magnitude = this.m_Rigidbody.velocity.magnitude;
      this.m_WindSoundSource.pitch = this.m_WindBasePitch + magnitude * this.m_WindSpeedPitchFactor;
      this.m_WindSoundSource.volume = Mathf.InverseLerp(0.0f, this.m_WindMaxSpeedVolume, magnitude) * this.m_AdvancedSetttings.windMasterVolume;
    }

    [Serializable]
    public class AdvancedSetttings
    {
      public float engineMinDistance = 50f;
      public float engineMaxDistance = 1000f;
      public float engineDopplerLevel = 1f;
      [Range(0.0f, 1f)]
      public float engineMasterVolume = 0.5f;
      public float windMinDistance = 10f;
      public float windMaxDistance = 100f;
      public float windDopplerLevel = 1f;
      [Range(0.0f, 1f)]
      public float windMasterVolume = 0.5f;
    }
  }
}
