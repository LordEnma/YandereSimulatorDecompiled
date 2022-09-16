// Decompiled with JetBrains decompiler
// Type: CensorBloodScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CensorBloodScript : MonoBehaviour
{
  public ParticleSystem MyParticles;
  public Texture Flower;

  private void Start()
  {
    if (!GameGlobals.CensorBlood)
      return;
    this.MyParticles.main.startColor = (ParticleSystem.MinMaxGradient) new Color(1f, 1f, 1f, 1f);
    this.MyParticles.colorOverLifetime.enabled = false;
    this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
  }
}
