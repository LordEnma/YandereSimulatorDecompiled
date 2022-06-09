// Decompiled with JetBrains decompiler
// Type: FavorMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FavorMenuScript : MonoBehaviour
{
  public TutorialWindowScript TutorialWindow;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public ServicesScript ServicesMenu;
  public SchemesScript SchemesMenu;
  public DropsScript DropsMenu;
  public PromptBarScript PromptBar;
  public GameObject BountyMenu;
  public GameObject Panel;
  public Transform Highlight;
  public UITexture Portrait;
  public int ID = 1;

  private void Update()
  {
    if (!this.BountyMenu.activeInHierarchy)
    {
      if (this.InputManager.TappedRight)
      {
        ++this.ID;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedLeft)
      {
        --this.ID;
        this.UpdateHighlight();
      }
      if (this.TutorialWindow.Hide || this.TutorialWindow.Show)
        return;
      if (Input.GetButtonDown("A"))
      {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        if (this.ID == 1)
        {
          this.SchemesMenu.UpdatePantyCount();
          this.SchemesMenu.UpdateSchemeList();
          this.SchemesMenu.UpdateSchemeInfo();
          this.SchemesMenu.gameObject.SetActive(true);
          this.gameObject.SetActive(false);
        }
        else if (this.ID == 2)
        {
          this.ServicesMenu.UpdatePantyCount();
          this.ServicesMenu.UpdateList();
          this.ServicesMenu.UpdateDesc();
          this.ServicesMenu.gameObject.SetActive(true);
          this.gameObject.SetActive(false);
        }
        else if (this.ID == 3)
        {
          this.DropsMenu.UpdatePantyCount();
          this.DropsMenu.UpdateList();
          this.DropsMenu.UpdateDesc();
          this.DropsMenu.gameObject.SetActive(true);
          this.gameObject.SetActive(false);
        }
        else
        {
          if (this.ID != 4)
            return;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[1].text = "Back";
          this.PromptBar.UpdateButtons();
          this.Panel.SetActive(false);
          this.BountyMenu.SetActive(true);
        }
      }
      else if (Input.GetButtonDown("X"))
      {
        this.TutorialWindow.TitleLabel.text = "Info Points";
        this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.PointsString;
        this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.TutorialLabel.text.Replace('@', '\n');
        this.TutorialWindow.TutorialImage.mainTexture = this.TutorialWindow.InfoTexture;
        this.TutorialWindow.ForcingTutorial = true;
        this.TutorialWindow.enabled = true;
        this.TutorialWindow.SummonWindow();
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PauseScreen.MainMenu.SetActive(true);
        this.PauseScreen.Sideways = false;
        this.PauseScreen.PressedB = true;
        this.gameObject.SetActive(false);
      }
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.Panel.SetActive(true);
      this.BountyMenu.SetActive(false);
    }
  }

  private void UpdateHighlight()
  {
    if (this.ID > 4)
      this.ID = 1;
    else if (this.ID < 1)
      this.ID = 4;
    this.Highlight.transform.localPosition = new Vector3((float) (200.0 * (double) this.ID - 500.0), this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
  }
}
