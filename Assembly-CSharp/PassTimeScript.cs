// Decompiled with JetBrains decompiler
// Type: PassTimeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PassTimeScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public ClockScript Clock;
  public UILabel TimeDisplay;
  public Transform Highlight;
  public float[] MinimumDigits;
  public float[] Digits;
  public int TargetTime;
  public int Selected = 1;
  public string AMPM = "AM";

  private void Update()
  {
    if (this.InputManager.TappedLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      --this.Selected;
      if (this.Selected < 1)
        this.Selected = 3;
      this.UpdateHighlightPosition();
    }
    if (this.InputManager.TappedRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      ++this.Selected;
      if (this.Selected > 3)
        this.Selected = 1;
      this.UpdateHighlightPosition();
    }
    if (this.InputManager.TappedUp || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
      this.UpdateTime(1);
    if (!this.InputManager.TappedDown && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.DownArrow))
      return;
    this.UpdateTime(-1);
  }

  private void UpdateHighlightPosition()
  {
    if (this.Selected == 1)
      this.Highlight.localPosition = new Vector3(-130f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    else if (this.Selected == 2)
    {
      this.Highlight.localPosition = new Vector3(-40f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    }
    else
    {
      if (this.Selected != 3)
        return;
      this.Highlight.localPosition = new Vector3(15f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
    }
  }

  public void GetCurrentTime()
  {
    this.Digits[1] = this.Clock.Hour;
    if ((double) this.Clock.Minute < 9.0)
    {
      this.Digits[2] = 0.0f;
      this.Digits[3] = this.Clock.Minute;
    }
    else
    {
      this.Digits[2] = this.Clock.Minute * 0.1f;
      this.Digits[2] = Mathf.Floor(this.Digits[2]);
      this.Digits[3] = this.Clock.Minute - this.Digits[2] * 10f;
    }
    this.MinimumDigits[1] = this.Digits[1];
    this.MinimumDigits[2] = this.Digits[2];
    this.MinimumDigits[3] = this.Digits[3];
    this.UpdateTime(0);
  }

  private void UpdateTime(int Increment)
  {
    this.Digits[this.Selected] += (float) Increment;
    if (this.Selected == 1)
    {
      if ((double) this.Digits[1] < (double) this.MinimumDigits[1])
        this.Digits[1] = this.MinimumDigits[1];
      else if ((double) this.Digits[1] > 17.0)
        this.Digits[1] = 17f;
      if ((double) this.Digits[1] == (double) this.MinimumDigits[1])
      {
        if ((double) this.Digits[2] < (double) this.MinimumDigits[2])
          this.Digits[2] = this.MinimumDigits[2];
        if ((double) this.Digits[2] == (double) this.MinimumDigits[2] && (double) this.Digits[3] < (double) this.MinimumDigits[3])
          this.Digits[3] = this.MinimumDigits[3];
      }
    }
    else if (this.Selected == 2)
    {
      if ((double) this.Digits[1] == (double) this.MinimumDigits[1])
      {
        if ((double) this.Digits[2] < (double) this.MinimumDigits[2])
          this.Digits[2] = this.MinimumDigits[2];
        else if ((double) this.Digits[2] > 5.0)
          this.Digits[2] = this.MinimumDigits[2];
        if ((double) this.Digits[2] == (double) this.MinimumDigits[2] && (double) this.Digits[3] < (double) this.MinimumDigits[3])
          this.Digits[3] = this.MinimumDigits[3];
      }
      else if ((double) this.Digits[2] < 0.0)
        this.Digits[2] = 5f;
      else if ((double) this.Digits[2] > 5.0)
        this.Digits[2] = 0.0f;
    }
    else if (this.Selected == 3)
    {
      if ((double) this.Digits[1] == (double) this.MinimumDigits[1] && (double) this.Digits[2] == (double) this.MinimumDigits[2])
      {
        if ((double) this.Digits[3] < (double) this.MinimumDigits[3])
          this.Digits[3] = this.MinimumDigits[3];
        else if ((double) this.Digits[3] > 9.0)
          this.Digits[3] = this.MinimumDigits[3];
      }
      else if ((double) this.Digits[3] < 0.0)
        this.Digits[3] = 9f;
      else if ((double) this.Digits[3] > 9.0)
        this.Digits[3] = 0.0f;
    }
    this.AMPM = (double) this.Digits[1] >= 12.0 ? " PM" : " AM";
    if ((double) this.Digits[1] < 10.0)
      this.TimeDisplay.text = "0" + this.Digits[1].ToString() + ":" + this.Digits[2].ToString() + this.Digits[3].ToString() + this.AMPM;
    else if ((double) this.Digits[1] < 13.0)
      this.TimeDisplay.text = this.Digits[1].ToString() + ":" + this.Digits[2].ToString() + this.Digits[3].ToString() + this.AMPM;
    else
      this.TimeDisplay.text = "0" + (this.Digits[1] - 12f).ToString() + ":" + this.Digits[2].ToString() + this.Digits[3].ToString() + this.AMPM;
    this.TargetTime = (int) ((double) this.Digits[1] * 60.0 + (double) this.Digits[2] * 10.0 + (double) this.Digits[3]);
  }
}
