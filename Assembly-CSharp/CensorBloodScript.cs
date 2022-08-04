// Decompiled with JetBrains decompiler
// Type: CensorBloodScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
