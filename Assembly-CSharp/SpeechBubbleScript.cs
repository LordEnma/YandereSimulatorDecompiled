// Decompiled with JetBrains decompiler
// Type: SpeechBubbleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpeechBubbleScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public StudentScript Student;
  public string[] Dialogue;
  public int[] Speaker;
  public UILabel Label;
  public UISprite[] Bubbles;
  public UISprite Arrow;
  public int CurrentBubble;
  public int ID = 1;
  public bool FadeOut;
  public bool Stop;
  public float Timer;

  private void Start() => this.Resize();

  private void LateUpdate()
  {
    if (!this.Stop)
    {
      if ((Object) this.Student != (Object) null)
      {
        Vector2 screenPoint = (Vector2) this.StudentManager.Yandere.MainCamera.WorldToScreenPoint(this.Student.transform.position + this.transform.up * 2f);
        this.transform.position = this.StudentManager.Yandere.UICamera.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 1f));
        if ((double) this.Student.DistanceToPlayer < 5.0 && !this.Student.Alone)
        {
          if (!this.FadeOut)
          {
            this.Bubbles[this.CurrentBubble].alpha = Mathf.MoveTowards(this.Bubbles[this.CurrentBubble].alpha, 1f, Time.deltaTime);
            this.Arrow.alpha = this.Bubbles[this.CurrentBubble].alpha;
            this.Label.alpha = this.Arrow.alpha;
            this.Timer += Time.deltaTime;
            if ((double) this.Timer <= 6.0)
              return;
            this.FadeOut = true;
            this.Timer = 0.0f;
          }
          else
          {
            this.Bubbles[this.CurrentBubble].alpha = Mathf.MoveTowards(this.Bubbles[this.CurrentBubble].alpha, 0.0f, Time.deltaTime);
            this.Arrow.alpha = this.Bubbles[this.CurrentBubble].alpha;
            this.Label.alpha = this.Arrow.alpha;
            if ((double) this.Label.alpha != 0.0)
              return;
            this.FadeOut = false;
            ++this.ID;
            if (this.ID < this.Speaker.Length)
            {
              this.Student = this.StudentManager.Students[this.Speaker[this.ID]];
              this.Label.text = this.Dialogue[this.ID];
            }
            else
              this.Stop = true;
            this.Resize();
          }
        }
        else
        {
          this.Bubbles[this.CurrentBubble].alpha = Mathf.MoveTowards(this.Bubbles[this.CurrentBubble].alpha, 0.0f, Time.deltaTime);
          this.Arrow.alpha = this.Bubbles[this.CurrentBubble].alpha;
          this.Label.alpha = this.Arrow.alpha;
        }
      }
      else
      {
        this.Student = this.StudentManager.Students[this.Speaker[this.ID]];
        this.Label.text = this.Dialogue[this.ID];
        this.Resize();
      }
    }
    else
    {
      if (!Input.GetKeyDown(KeyCode.R))
        return;
      this.Stop = false;
      this.ID = 1;
      this.Student = this.StudentManager.Students[this.Speaker[this.ID]];
      this.Label.text = this.Dialogue[this.ID];
      this.Resize();
    }
  }

  public void Resize()
  {
    this.Arrow.alpha = 0.0f;
    this.Label.alpha = 0.0f;
    this.Bubbles[1].enabled = false;
    this.Bubbles[2].enabled = false;
    this.Bubbles[3].enabled = false;
    this.Bubbles[4].enabled = false;
    this.Bubbles[5].enabled = false;
    this.Bubbles[1].alpha = 0.0f;
    this.Bubbles[2].alpha = 0.0f;
    this.Bubbles[3].alpha = 0.0f;
    this.Bubbles[4].alpha = 0.0f;
    this.Bubbles[5].alpha = 0.0f;
    this.CurrentBubble = this.Label.text.Length >= 41 ? (this.Label.text.Length >= 81 ? (this.Label.text.Length >= 121 ? (this.Label.text.Length >= 161 ? 5 : 4) : 3) : 2) : 1;
    this.Bubbles[this.CurrentBubble].enabled = true;
  }
}
