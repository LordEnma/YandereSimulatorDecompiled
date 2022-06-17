// Decompiled with JetBrains decompiler
// Type: ChallengeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChallengeScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public CalendarScript Calendar;
  public GameObject ViewButton;
  public Transform Arrows;
  public Transform[] ChallengeList;
  public int[] Challenges;
  public UIPanel[] Panels;
  public UIPanel ChallengePanel;
  public UIPanel CalendarPanel;
  public UITexture LargeIcon;
  public UISprite Shadow;
  public bool Viewing;
  public bool Switch;
  public int Phase = 1;
  public int List;

  private void Update()
  {
    if (!this.Viewing)
    {
      if (!this.Switch)
      {
        if (this.InputManager.TappedUp || this.InputManager.TappedDown)
        {
          if (this.List == 0)
          {
            this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, -300f, this.Arrows.localPosition.z);
            this.ViewButton.SetActive(true);
            this.Panels[0].alpha = 0.5f;
            this.Panels[1].alpha = 1f;
            this.List = 1;
          }
          else
          {
            this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, 200f, this.Arrows.localPosition.z);
            this.ViewButton.SetActive(false);
            this.Panels[0].alpha = 1f;
            this.Panels[1].alpha = 0.5f;
            this.List = 0;
          }
        }
        Transform challenge = this.ChallengeList[this.List];
        if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
          challenge.localPosition = new Vector3(challenge.localPosition.x - Time.deltaTime * 1000f, challenge.localPosition.y, challenge.localPosition.z);
        if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
          challenge.localPosition = new Vector3(challenge.localPosition.x + Time.deltaTime * 1000f, challenge.localPosition.y, challenge.localPosition.z);
        challenge.localPosition = new Vector3(challenge.localPosition.x + Input.GetAxis("Horizontal") * -10f, challenge.localPosition.y, challenge.localPosition.z);
        if ((double) challenge.localPosition.x > 500.0)
          challenge.localPosition = new Vector3(500f, challenge.localPosition.y, challenge.localPosition.z);
        else if ((double) challenge.localPosition.x < -250.0 * ((double) this.Challenges[this.List] - 3.0))
          challenge.localPosition = new Vector3((float) (-250.0 * ((double) this.Challenges[this.List] - 3.0)), challenge.localPosition.y, challenge.localPosition.z);
        if ((double) this.LargeIcon.color.a > 0.0)
        {
          this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a - Time.deltaTime * 10f);
          if ((double) this.LargeIcon.color.a < 0.0)
            this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 0.0f);
        }
      }
    }
    else if ((double) this.LargeIcon.color.a < 1.0)
    {
      this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a + Time.deltaTime * 10f);
      if ((double) this.LargeIcon.color.a > 1.0)
        this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 1f);
    }
    this.Shadow.color = new Color(this.Shadow.color.r, this.Shadow.color.g, this.Shadow.color.b, this.LargeIcon.color.a * 0.75f);
    if (!this.Switch && Input.GetButtonDown("A") && this.List == 1)
      this.Viewing = true;
    if (Input.GetButtonDown("B"))
    {
      if (this.Viewing)
        this.Viewing = false;
      else
        this.Switch = true;
    }
    if (!this.Switch)
      return;
    if (this.Phase == 1)
    {
      this.ChallengePanel.alpha -= Time.deltaTime;
      if ((double) this.ChallengePanel.alpha > 0.0)
        return;
      ++this.Phase;
    }
    else
    {
      this.CalendarPanel.alpha += Time.deltaTime;
      if ((double) this.CalendarPanel.alpha < 1.0)
        return;
      this.Calendar.enabled = true;
      this.enabled = false;
      this.Switch = false;
      this.Phase = 1;
    }
  }
}
