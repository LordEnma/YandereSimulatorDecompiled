// Decompiled with JetBrains decompiler
// Type: TitleDemoChecklistScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDemoChecklistScript : MonoBehaviour
{
  public NewTitleScreenScript NewTitleScreen;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public UISprite[] ConfirmBlocks;
  public string[] ItemNames;
  public string[] ItemDescs;
  public UILabel ItemNameLabel;
  public UILabel ItemDescLabel;
  public UILabel ResetLabel;
  public Vector3 OriginalPosition;
  public GameObject ResetWindow;
  public Transform Highlight;
  public bool DeletingGlobals;
  public bool Shrink;
  public bool Show;
  public bool Zoom;
  public int Confirmations;
  public int Columns;
  public int Rows;
  private int Column;
  private int Row;
  private int Selected = 1;
  public UITexture[] Items;
  public Texture[] ItemTextures;

  private void Start()
  {
    this.UpdateHighlight();
    if (PlayerPrefs.GetInt("Attack") == 1)
      this.Items[1].mainTexture = this.ItemTextures[1];
    if (PlayerPrefs.GetInt("Befriend") == 1)
      this.Items[2].mainTexture = this.ItemTextures[2];
    if (PlayerPrefs.GetInt("Betray") == 1)
      this.Items[3].mainTexture = this.ItemTextures[3];
    if (PlayerPrefs.GetInt("Bully") == 1)
      this.Items[4].mainTexture = this.ItemTextures[4];
    if (PlayerPrefs.GetInt("Burn") == 1)
      this.Items[5].mainTexture = this.ItemTextures[5];
    if (PlayerPrefs.GetInt("Crush") == 1)
      this.Items[6].mainTexture = this.ItemTextures[6];
    if (PlayerPrefs.GetInt("Drown") == 1)
      this.Items[7].mainTexture = this.ItemTextures[7];
    if (PlayerPrefs.GetInt("Electrocute") == 1)
      this.Items[8].mainTexture = this.ItemTextures[8];
    if (PlayerPrefs.GetInt("Expel") == 1)
      this.Items[9].mainTexture = this.ItemTextures[9];
    if (PlayerPrefs.GetInt("Fan") == 1)
      this.Items[10].mainTexture = this.ItemTextures[10];
    if (PlayerPrefs.GetInt("Frame") == 1)
      this.Items[11].mainTexture = this.ItemTextures[11];
    if (PlayerPrefs.GetInt("Kidnap") == 1)
      this.Items[12].mainTexture = this.ItemTextures[12];
    if (PlayerPrefs.GetInt("Matchmake") == 1)
      this.Items[13].mainTexture = this.ItemTextures[13];
    if (PlayerPrefs.GetInt("MurderSuicide") == 1)
      this.Items[14].mainTexture = this.ItemTextures[14];
    if (PlayerPrefs.GetInt("Poison") == 1)
      this.Items[15].mainTexture = this.ItemTextures[15];
    if (PlayerPrefs.GetInt("Pool") == 1)
      this.Items[16].mainTexture = this.ItemTextures[16];
    if (PlayerPrefs.GetInt("Push") == 1)
      this.Items[17].mainTexture = this.ItemTextures[17];
    if (PlayerPrefs.GetInt("Reject") == 1)
      this.Items[18].mainTexture = this.ItemTextures[18];
    if (PlayerPrefs.GetInt("Suicide") == 1)
      this.Items[19].mainTexture = this.ItemTextures[19];
    if (PlayerPrefs.GetInt("DrivenToMurder") == 1)
      this.Items[20].mainTexture = this.ItemTextures[20];
    if (PlayerPrefs.GetInt("HeadHunter") > 9)
      this.Items[21].mainTexture = this.ItemTextures[21];
    if (PlayerPrefs.GetInt("PantyQueen") == 1)
      this.Items[22].mainTexture = this.ItemTextures[22];
    if (PlayerPrefs.GetInt("RichGirl") == 1)
      this.Items[23].mainTexture = this.ItemTextures[23];
    if (PlayerPrefs.GetInt("WeaponMaster") != 1)
      return;
    this.Items[24].mainTexture = this.ItemTextures[24];
  }

  public void GetIndex() => this.Selected = this.Column + this.Row * this.Columns + 1;

  private void Update()
  {
    if (this.Zoom)
    {
      if (!this.Shrink)
      {
        this.Items[this.Selected].transform.localPosition = Vector3.Lerp(this.Items[this.Selected].transform.localPosition, new Vector3(0.0f, 25f, 0.0f), Time.deltaTime * 10f);
        this.Items[this.Selected].transform.localScale = Vector3.Lerp(this.Items[this.Selected].transform.localScale, Vector3.one, Time.deltaTime * 10f);
        if (!Input.GetButtonDown("B"))
          return;
        this.Items[this.Selected].depth = 0;
        this.Shrink = true;
      }
      else
      {
        this.Items[this.Selected].transform.localPosition = Vector3.Lerp(this.Items[this.Selected].transform.localPosition, this.OriginalPosition, Time.deltaTime * 10f);
        this.Items[this.Selected].transform.localScale = Vector3.Lerp(this.Items[this.Selected].transform.localScale, new Vector3(0.195f, 0.195f, 0.195f), Time.deltaTime * 10f);
        if ((double) this.Items[this.Selected].transform.localScale.x >= 0.20000000298023224)
          return;
        this.Items[this.Selected].transform.localPosition = this.OriginalPosition;
        this.Items[this.Selected].transform.localScale = new Vector3(0.195f, 0.195f, 0.195f);
        this.Shrink = false;
        this.Zoom = false;
      }
    }
    else if (!this.ResetWindow.activeInHierarchy)
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
        this.PromptBar.Label[0].text = "View Image";
        this.PromptBar.Label[1].text = "Go Back";
        this.PromptBar.Label[2].text = "Reset Progress";
        this.PromptBar.Label[4].text = "Change Selection";
        this.PromptBar.Label[5].text = "Change Selection";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
      if (Input.GetButtonDown("A"))
      {
        this.OriginalPosition = this.Items[this.Selected].transform.localPosition;
        this.Items[this.Selected].depth = 2;
        this.Zoom = true;
      }
      else if (Input.GetButtonDown("X"))
        this.ResetWindow.SetActive(true);
      else if (Input.GetButtonDown("B"))
      {
        this.NewTitleScreen.Speed = 0.0f;
        this.NewTitleScreen.Phase = 2;
        this.PromptBar.Show = false;
        this.enabled = false;
      }
      else
      {
        if (!Input.GetKeyDown("r"))
          return;
        this.ResetLabel.text = "This is a hidden debug command for completely removing all Yandere Simulator data from your computer's registry. This command will delete all of your save data, but may fix certain types of bugs that cannot be fixed in any other way.";
        this.DeletingGlobals = true;
        this.ResetWindow.SetActive(true);
      }
    }
    else if (Input.GetButtonDown("A"))
    {
      ++this.Confirmations;
      this.ConfirmBlocks[this.Confirmations].color = new Color(1f, 1f, 1f, 1f);
      if (this.Confirmations != 10)
        return;
      if (this.DeletingGlobals)
      {
        PlayerPrefs.DeleteAll();
        OptionGlobals.DisableScanlines = true;
      }
      else
      {
        PlayerPrefs.SetInt("Attack", 0);
        PlayerPrefs.SetInt("Befriend", 0);
        PlayerPrefs.SetInt("Betray", 0);
        PlayerPrefs.SetInt("Bully", 0);
        PlayerPrefs.SetInt("Burn", 0);
        PlayerPrefs.SetInt("Crush", 0);
        PlayerPrefs.SetInt("Drown", 0);
        PlayerPrefs.SetInt("Electrocute", 0);
        PlayerPrefs.SetInt("Expel", 0);
        PlayerPrefs.SetInt("Fan", 0);
        PlayerPrefs.SetInt("Frame", 0);
        PlayerPrefs.SetInt("Kidnap", 0);
        PlayerPrefs.SetInt("Matchmake", 0);
        PlayerPrefs.SetInt("MurderSuicide", 0);
        PlayerPrefs.SetInt("Poison", 0);
        PlayerPrefs.SetInt("Pool", 0);
        PlayerPrefs.SetInt("Push", 0);
        PlayerPrefs.SetInt("Reject", 0);
        PlayerPrefs.SetInt("Suicide", 0);
        PlayerPrefs.SetInt("DrivenToMurder", 0);
        PlayerPrefs.SetInt("HeadHunter", 0);
        PlayerPrefs.SetInt("PantyQueen", 0);
        PlayerPrefs.SetInt("RichGirl", 0);
        PlayerPrefs.SetInt("WeaponMaster", 0);
      }
      SceneManager.LoadScene("ResolutionScene");
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.ResetConfirmations();
    }
  }

  private void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3((float) ((double) this.Column * 100.0 - 350.0), (float) (100.0 - (double) this.Row * 100.0), this.Highlight.localPosition.z);
    this.GetIndex();
    this.ItemNameLabel.text = this.ItemNames[this.Selected];
    this.ItemDescLabel.text = this.ItemDescs[this.Selected];
  }

  private void ResetConfirmations()
  {
    this.ResetLabel.text = "Are you ABSOLUTELY CERTAIN that you want to reset your Demo Checklist progress?\n\nMash the Confirm button 10 times to reaffirm this decision.";
    this.ResetWindow.SetActive(false);
    this.DeletingGlobals = false;
    this.PromptBar.Show = true;
    this.Confirmations = 0;
    this.ConfirmBlocks[1].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[2].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[3].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[4].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[5].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[6].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[7].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[8].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[9].color = new Color(1f, 1f, 1f, 0.5f);
    this.ConfirmBlocks[10].color = new Color(1f, 1f, 1f, 0.5f);
  }
}
