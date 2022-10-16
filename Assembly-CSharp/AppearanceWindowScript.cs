// Decompiled with JetBrains decompiler
// Type: AppearanceWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AppearanceWindowScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public Transform Highlight;
  public Transform Window;
  public UISprite[] Checks;
  public int Selected;
  public bool Ready;
  public bool Show;

  private void Start()
  {
    this.Window.localScale = Vector3.zero;
    for (int checkID = 1; checkID < 10; ++checkID)
      this.Checks[checkID].enabled = DatingGlobals.GetSuitorCheck(checkID);
  }

  private void Update()
  {
    if (!this.Show)
    {
      if (!this.Window.gameObject.activeInHierarchy)
        return;
      if ((double) this.Window.localScale.x > 0.10000000149011612)
      {
        this.Window.localScale = Vector3.Lerp(this.Window.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else
      {
        this.Window.localScale = Vector3.zero;
        this.Window.gameObject.SetActive(false);
      }
    }
    else
    {
      this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.Ready)
      {
        if (this.InputManager.TappedUp)
        {
          --this.Selected;
          if (this.Selected == 10)
            this.Selected = 9;
          this.UpdateHighlight();
        }
        if (this.InputManager.TappedDown)
        {
          ++this.Selected;
          if (this.Selected == 10)
            this.Selected = 11;
          this.UpdateHighlight();
        }
        if (Input.GetButtonDown("A"))
        {
          if (this.Selected == 1)
          {
            if (!this.Checks[1].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorHair = 55;
              this.Checks[1].enabled = true;
              this.Checks[2].enabled = false;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorHair = 0;
              this.Checks[1].enabled = false;
            }
          }
          else if (this.Selected == 2)
          {
            if (!this.Checks[2].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorHair = 56;
              this.Checks[1].enabled = false;
              this.Checks[2].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorHair = 0;
              this.Checks[2].enabled = false;
            }
          }
          else if (this.Selected == 3)
          {
            if (!this.Checks[3].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorAccessory = 17;
              this.Checks[3].enabled = true;
              this.Checks[4].enabled = false;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorAccessory = 0;
              this.Checks[3].enabled = false;
            }
          }
          else if (this.Selected == 4)
          {
            if (!this.Checks[4].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorAccessory = 1;
              this.Checks[3].enabled = false;
              this.Checks[4].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorAccessory = 0;
              this.Checks[4].enabled = false;
            }
          }
          else if (this.Selected == 5)
          {
            if (!this.Checks[5].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorEyewear = 6;
              this.Checks[5].enabled = true;
              this.Checks[6].enabled = false;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorEyewear = 0;
              this.Checks[5].enabled = false;
            }
          }
          else if (this.Selected == 6)
          {
            if (!this.Checks[6].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorEyewear = 3;
              this.Checks[5].enabled = false;
              this.Checks[6].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorEyewear = 0;
              this.Checks[6].enabled = false;
            }
          }
          else if (this.Selected == 7)
          {
            if (!this.Checks[7].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorTan = true;
              this.Checks[7].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorTan = false;
              this.Checks[7].enabled = false;
            }
          }
          else if (this.Selected == 8)
          {
            if (!this.Checks[8].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorBlack = true;
              this.Checks[8].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorBlack = false;
              this.Checks[8].enabled = false;
            }
          }
          else if (this.Selected == 9)
          {
            if (!this.Checks[9].enabled)
            {
              this.StudentManager.LoveManager.CustomSuitorJewelry = 1;
              this.Checks[9].enabled = true;
            }
            else
            {
              this.StudentManager.LoveManager.CustomSuitorJewelry = 0;
              this.Checks[9].enabled = false;
            }
          }
          else if (this.Selected == 11)
          {
            Debug.Log((object) "The game believes that we just exited the Appearance Window.");
            this.StudentManager.LoveManager.CustomSuitor = true;
            this.PromptBar.ClearButtons();
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = false;
            this.Yandere.Interaction = YandereInteractionType.ChangingAppearance;
            this.Yandere.TalkTimer = 3f;
            this.Ready = false;
            this.Show = false;
          }
        }
      }
      if (!Input.GetButtonUp("A"))
        return;
      this.Ready = true;
    }
  }

  private void UpdateHighlight()
  {
    if (this.Selected < 1)
      this.Selected = 11;
    else if (this.Selected > 11)
      this.Selected = 1;
    this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, (float) (300.0 - 50.0 * (double) this.Selected), this.Highlight.transform.localPosition.z);
  }

  private void Exit()
  {
    this.Selected = 1;
    this.UpdateHighlight();
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Show = false;
  }
}
