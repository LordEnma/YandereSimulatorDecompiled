// Decompiled with JetBrains decompiler
// Type: TitleSponsorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleSponsorScript : MonoBehaviour
{
  public NewTitleScreenScript NewTitleScreen;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public string[] SponsorURLs;
  public string[] Sponsors;
  public UILabel SponsorName;
  public Transform Highlight;
  public bool Show;
  public int Columns;
  public int Rows;
  private int Column;
  private int Row;
  public UISprite BlackSprite;
  public UISprite[] RedSprites;
  public UILabel[] Labels;

  private void Start()
  {
    this.UpdateHighlight();
    if (!GameGlobals.LoveSick)
      return;
    this.TurnLoveSick();
  }

  public int GetSponsorIndex() => this.Column + this.Row * this.Columns;

  public bool SponsorHasWebsite(int index) => !string.IsNullOrEmpty(this.SponsorURLs[index]);

  private void Update()
  {
    if (this.InputManager.TappedUp)
      this.Row = this.Row > 0 ? this.Row - 1 : this.Rows - 1;
    if (this.InputManager.TappedDown)
      this.Row = this.Row < this.Rows - 1 ? this.Row + 1 : 0;
    if (this.InputManager.TappedRight)
      this.Column = this.Column < this.Columns - 1 ? this.Column + 1 : 0;
    if (this.InputManager.TappedLeft)
      this.Column = this.Column > 0 ? this.Column - 1 : this.Columns - 1;
    if ((this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight ? 1 : (this.InputManager.TappedLeft ? 1 : 0)) != 0)
      this.UpdateHighlight();
    if ((double) this.NewTitleScreen.Speed <= 3.0)
      return;
    if (!this.PromptBar.Show)
    {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Make Selection";
      this.PromptBar.Label[1].text = "Go Back";
      this.PromptBar.Label[4].text = "Change Selection";
      this.PromptBar.Label[5].text = "Change Selection";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
    }
    if (Input.GetButtonDown("A"))
    {
      int sponsorIndex = this.GetSponsorIndex();
      if (this.SponsorHasWebsite(sponsorIndex))
        Application.OpenURL(this.SponsorURLs[sponsorIndex]);
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.NewTitleScreen.Speed = 0.0f;
    this.NewTitleScreen.Phase = 2;
    this.PromptBar.Show = false;
    this.enabled = false;
  }

  private void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3((float) ((double) this.Column * 256.0 - 384.0), (float) (128.0 - (double) this.Row * 256.0), this.Highlight.localPosition.z);
    this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
  }

  private void TurnLoveSick()
  {
    this.BlackSprite.color = Color.black;
    foreach (UISprite redSprite in this.RedSprites)
      redSprite.color = new Color(1f, 0.0f, 0.0f, redSprite.color.a);
    foreach (UILabel label in this.Labels)
      label.color = new Color(1f, 0.0f, 0.0f, label.color.a);
  }
}
