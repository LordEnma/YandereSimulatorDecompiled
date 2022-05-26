// Decompiled with JetBrains decompiler
// Type: CensorBloodScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
