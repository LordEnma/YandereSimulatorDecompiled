// Decompiled with JetBrains decompiler
// Type: CheapFilmGrainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CheapFilmGrainScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public float Floor = 100f;
  public float Ceiling = 200f;

  private void Update() => this.MyRenderer.material.mainTextureScale = new Vector2(Random.Range(this.Floor, this.Ceiling), Random.Range(this.Floor, this.Ceiling));
}
