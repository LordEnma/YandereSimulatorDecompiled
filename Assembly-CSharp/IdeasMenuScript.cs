// Decompiled with JetBrains decompiler
// Type: IdeasMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IdeasMenuScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public Transform Highlight;
  public UILabel Description;
  public string[] IdeaNames;
  public string[] Ideas;
  public UILabel[] Labels;
  public GameObject List;
  public int ListSize = 21;
  public int Selected = 1;
  public int Offset;
  public int Limit = 27;

  private void Start()
  {
    for (int giftID = 1; giftID < 11; ++giftID)
    {
      if (!CollectibleGlobals.GetAdvicePurchased(giftID))
      {
        this.IdeaNames[17 + giftID] = "?????";
        this.Ideas[17 + giftID] = "To unlock this information, you'll need to find someone who has experience getting away with murder...";
      }
    }
    this.UpdateHighlightPosition();
    this.Description.enabled = false;
    this.List.SetActive(true);
  }

  private void Update()
  {
    if (this.List.activeInHierarchy)
    {
      if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        this.UpdateHighlightPosition();
      }
      else if (this.InputManager.TappedUp)
      {
        --this.Selected;
        this.UpdateHighlightPosition();
      }
      else if (Input.GetButtonDown("A"))
      {
        this.PauseScreen.PromptBar.ClearButtons();
        this.PauseScreen.PromptBar.Label[1].text = "Back";
        this.PauseScreen.PromptBar.UpdateButtons();
        this.PauseScreen.PromptBar.Show = true;
        this.Description.text = this.Ideas[this.Selected + this.Offset];
        this.Description.text = this.Description.text.Replace('@', '\n');
        this.Description.enabled = true;
        this.List.SetActive(false);
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.PauseScreen.PromptBar.ClearButtons();
        this.PauseScreen.PromptBar.Label[0].text = "Accept";
        this.PauseScreen.PromptBar.Label[1].text = "Exit";
        this.PauseScreen.PromptBar.Label[4].text = "Choose";
        this.PauseScreen.PromptBar.Label[5].text = "Choose";
        this.PauseScreen.PromptBar.UpdateButtons();
        this.PauseScreen.MainMenu.SetActive(true);
        this.gameObject.SetActive(false);
      }
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.PauseScreen.PromptBar.ClearButtons();
      this.PauseScreen.PromptBar.Label[0].text = "Confirm";
      this.PauseScreen.PromptBar.Label[1].text = "Back";
      this.PauseScreen.PromptBar.Label[4].text = "Choose";
      this.PauseScreen.PromptBar.UpdateButtons();
      this.PauseScreen.PromptBar.Show = true;
      this.Description.enabled = false;
      this.List.SetActive(true);
    }
  }

  private void UpdateHighlightPosition()
  {
    if (this.Selected < 1)
    {
      this.Selected = 1;
      --this.Offset;
    }
    else if (this.Selected > this.ListSize)
    {
      this.Selected = this.ListSize;
      ++this.Offset;
    }
    if (this.Offset < 0)
    {
      this.Selected = this.ListSize;
      this.Offset = this.Limit - this.ListSize;
    }
    else if (this.Offset > this.Limit - this.ListSize)
    {
      this.Selected = 1;
      this.Offset = 0;
    }
    for (int index = 1; index < this.Labels.Length; ++index)
      this.Labels[index].text = this.IdeaNames[index + this.Offset];
    this.Highlight.transform.localPosition = new Vector3(-125f, (float) (550 - this.Selected * 50), 0.0f);
  }
}
