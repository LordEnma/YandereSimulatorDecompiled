// Decompiled with JetBrains decompiler
// Type: ChallengeIconScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChallengeIconScript : MonoBehaviour
{
  public UITexture LargeIcon;
  public UISprite IconFrame;
  public UISprite NameFrame;
  public UITexture Icon;
  public UILabel Name;
  public float Dark;
  private float R;
  private float G;
  private float B;

  private void Start()
  {
    if (GameGlobals.LoveSick)
    {
      this.R = 1f;
      this.G = 0.0f;
      this.B = 0.0f;
    }
    else
    {
      this.R = 1f;
      this.G = 1f;
      this.B = 1f;
    }
  }

  private void Update()
  {
    if ((double) this.transform.position.x > -0.125 && (double) this.transform.position.x < 0.125)
    {
      if ((Object) this.Icon != (Object) null)
        this.LargeIcon.mainTexture = this.Icon.mainTexture;
      this.Dark -= Time.deltaTime * 10f;
      if ((double) this.Dark < 0.0)
        this.Dark = 0.0f;
    }
    else
    {
      this.Dark += Time.deltaTime * 10f;
      if ((double) this.Dark > 1.0)
        this.Dark = 1f;
    }
    this.IconFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    this.NameFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    this.Name.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    if (!GameGlobals.LoveSick)
      return;
    if ((double) this.transform.position.x > -0.125 && (double) this.transform.position.x < 0.125)
    {
      this.IconFrame.color = Color.white;
      this.NameFrame.color = Color.white;
      this.Name.color = Color.white;
    }
    else
    {
      this.IconFrame.color = new Color(this.R, this.G, this.B, 1f);
      this.NameFrame.color = new Color(this.R, this.G, this.B, 1f);
      this.Name.color = new Color(this.R, this.G, this.B, 1f);
    }
  }
}
