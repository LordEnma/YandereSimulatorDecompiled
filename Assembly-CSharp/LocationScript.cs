// Decompiled with JetBrains decompiler
// Type: LocationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationScript : MonoBehaviour
{
  public UILabel Label;
  public UISprite BG;
  public bool Show;

  private void Start()
  {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0.0f);
    this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0.0f);
  }

  private void Update()
  {
    if (this.Show)
    {
      this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a + Time.deltaTime * 10f);
      if ((double) this.BG.color.a > 1.0)
        this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 1f);
      this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
    }
    else
    {
      this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a - Time.deltaTime * 10f);
      if ((double) this.BG.color.a < 0.0)
        this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0.0f);
      this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
    }
  }
}
