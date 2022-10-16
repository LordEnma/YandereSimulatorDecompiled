// Decompiled with JetBrains decompiler
// Type: IntroCircleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IntroCircleScript : MonoBehaviour
{
  public UISprite Sprite;
  public UILabel Label;
  public float[] StartTime;
  public float[] Duration;
  public string[] Text;
  public float CurrentTime;
  public float LastTime;
  public float Timer;
  public int ID;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (this.ID < this.StartTime.Length && (double) this.Timer > (double) this.StartTime[this.ID])
    {
      this.CurrentTime = this.Duration[this.ID];
      this.LastTime = this.Duration[this.ID];
      this.Label.text = this.Text[this.ID];
      ++this.ID;
    }
    if ((double) this.CurrentTime > 0.0)
      this.CurrentTime -= Time.deltaTime;
    if ((double) this.Timer > 1.0)
    {
      this.Sprite.fillAmount = this.CurrentTime / this.LastTime;
      if ((double) this.Sprite.fillAmount == 0.0)
        this.Label.text = string.Empty;
    }
    if (!Input.GetKeyDown(KeyCode.Space))
      return;
    this.CurrentTime -= 5f;
    this.Timer += 5f;
  }
}
