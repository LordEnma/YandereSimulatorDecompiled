// Decompiled with JetBrains decompiler
// Type: CensorBloodScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
