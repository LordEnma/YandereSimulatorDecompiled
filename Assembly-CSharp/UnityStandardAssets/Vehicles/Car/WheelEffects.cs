// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.WheelEffects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  [RequireComponent(typeof (AudioSource))]
  public class WheelEffects : MonoBehaviour
  {
    public Transform SkidTrailPrefab;
    public static Transform skidTrailsDetachedParent;
    public ParticleSystem skidParticles;
    private AudioSource m_AudioSource;
    private Transform m_SkidTrail;
    private WheelCollider m_WheelCollider;

    public bool skidding { get; private set; }

    public bool PlayingAudio { get; private set; }

    private void Start()
    {
      this.skidParticles = this.transform.root.GetComponentInChildren<ParticleSystem>();
      if ((Object) this.skidParticles == (Object) null)
        Debug.LogWarning((object) " no particle system found on car to generate smoke particles", (Object) this.gameObject);
      else
        this.skidParticles.Stop();
      this.m_WheelCollider = this.GetComponent<WheelCollider>();
      this.m_AudioSource = this.GetComponent<AudioSource>();
      this.PlayingAudio = false;
      if (!((Object) WheelEffects.skidTrailsDetachedParent == (Object) null))
        return;
      WheelEffects.skidTrailsDetachedParent = new GameObject("Skid Trails - Detached").transform;
    }

    public void EmitTyreSmoke()
    {
      this.skidParticles.transform.position = this.transform.position - this.transform.up * this.m_WheelCollider.radius;
      this.skidParticles.Emit(1);
      if (this.skidding)
        return;
      this.StartCoroutine(this.StartSkidTrail());
    }

    public void PlayAudio()
    {
      this.m_AudioSource.Play();
      this.PlayingAudio = true;
    }

    public void StopAudio()
    {
      this.m_AudioSource.Stop();
      this.PlayingAudio = false;
    }

    public IEnumerator StartSkidTrail()
    {
      WheelEffects wheelEffects = this;
      wheelEffects.skidding = true;
      wheelEffects.m_SkidTrail = Object.Instantiate<Transform>(wheelEffects.SkidTrailPrefab);
      while ((Object) wheelEffects.m_SkidTrail == (Object) null)
        yield return (object) null;
      wheelEffects.m_SkidTrail.parent = wheelEffects.transform;
      wheelEffects.m_SkidTrail.localPosition = -Vector3.up * wheelEffects.m_WheelCollider.radius;
    }

    public void EndSkidTrail()
    {
      if (!this.skidding)
        return;
      this.skidding = false;
      this.m_SkidTrail.parent = WheelEffects.skidTrailsDetachedParent;
      Object.Destroy((Object) this.m_SkidTrail.gameObject, 10f);
    }
  }
}
