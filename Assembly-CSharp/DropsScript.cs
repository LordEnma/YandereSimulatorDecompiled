// Decompiled with JetBrains decompiler
// Type: DropsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DropsScript : MonoBehaviour
{
  public InfoChanWindowScript InfoChanWindow;
  public InputManagerScript InputManager;
  public InventoryScript Inventory;
  public PromptBarScript PromptBar;
  public SchemesScript Schemes;
  public GameObject FavorMenu;
  public Transform Highlight;
  public UILabel PantyCount;
  public UITexture DropIcon;
  public UILabel DropDesc;
  public UILabel[] CostLabels;
  public UILabel[] NameLabels;
  public bool[] InfiniteSupply;
  public bool[] Purchased;
  public Texture[] DropIcons;
  public int[] DropCosts;
  public string[] DropDescs;
  public string[] DropNames;
  public int Selected = 1;
  public int ID = 1;
  public AudioClip InfoUnavailable;
  public AudioClip InfoPurchase;
  public AudioClip InfoAfford;
  public float HeldDown;
  public float HeldUp;

  private void Start()
  {
    for (this.ID = 1; this.ID < this.DropNames.Length; ++this.ID)
      this.NameLabels[this.ID].text = this.DropNames[this.ID];
    if (!MissionModeGlobals.MissionMode)
      return;
    this.CostLabels[5].text = "10";
    this.InfiniteSupply[5] = true;
    this.DropCosts[5] = 10;
    this.CostLabels[6].text = "10";
    this.InfiniteSupply[6] = true;
    this.DropCosts[6] = 10;
  }

  private void Update()
  {
    if (this.InputManager.DPadUp || this.InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
      this.HeldUp += Time.unscaledDeltaTime;
    else
      this.HeldUp = 0.0f;
    if (this.InputManager.DPadDown || this.InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
      this.HeldDown += Time.unscaledDeltaTime;
    else
      this.HeldDown = 0.0f;
    if (this.InputManager.TappedUp || (double) this.HeldUp > 0.5)
    {
      if ((double) this.HeldUp > 0.5)
        this.HeldUp = 0.45f;
      --this.Selected;
      if (this.Selected < 1)
        this.Selected = this.DropNames.Length - 1;
      this.UpdateDesc();
    }
    if (this.InputManager.TappedDown || (double) this.HeldDown > 0.5)
    {
      if ((double) this.HeldDown > 0.5)
        this.HeldDown = 0.45f;
      ++this.Selected;
      if (this.Selected > this.DropNames.Length - 1)
        this.Selected = 1;
      this.UpdateDesc();
    }
    if (Input.GetButtonDown("A"))
    {
      AudioSource component = this.GetComponent<AudioSource>();
      if (!this.Purchased[this.Selected] && this.InfoChanWindow.Orders < 11)
      {
        if (this.PromptBar.Label[0].text != string.Empty)
        {
          if (this.Inventory.PantyShots >= this.DropCosts[this.Selected])
          {
            this.Inventory.PantyShots -= this.DropCosts[this.Selected];
            if (!this.InfiniteSupply[this.Selected])
              this.Purchased[this.Selected] = true;
            ++this.InfoChanWindow.Orders;
            this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
            this.InfoChanWindow.DropObject();
            this.UpdateList();
            this.UpdateDesc();
            component.clip = this.InfoPurchase;
            component.Play();
            if (this.Selected == 2)
            {
              SchemeGlobals.SetSchemeStage(3, 2);
              this.Schemes.UpdateInstructions();
            }
          }
        }
        else if (this.Inventory.PantyShots < this.DropCosts[this.Selected])
        {
          component.clip = this.InfoAfford;
          component.Play();
        }
        else
        {
          component.clip = this.InfoUnavailable;
          component.Play();
        }
      }
      else
      {
        component.clip = this.InfoUnavailable;
        component.Play();
      }
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[5].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.FavorMenu.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public void UpdateList()
  {
    for (this.ID = 1; this.ID < this.DropNames.Length; ++this.ID)
    {
      UILabel nameLabel = this.NameLabels[this.ID];
      if (!this.Purchased[this.ID])
      {
        this.CostLabels[this.ID].text = this.DropCosts[this.ID].ToString();
        nameLabel.color = new Color(nameLabel.color.r, nameLabel.color.g, nameLabel.color.b, 1f);
      }
      else
      {
        this.CostLabels[this.ID].text = string.Empty;
        nameLabel.color = new Color(nameLabel.color.r, nameLabel.color.g, nameLabel.color.b, 0.5f);
      }
    }
  }

  public void UpdateDesc()
  {
    if (!this.Purchased[this.Selected])
    {
      if (this.Inventory.PantyShots >= this.DropCosts[this.Selected])
      {
        this.PromptBar.Label[0].text = "Purchase";
        this.PromptBar.UpdateButtons();
      }
      else
      {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.UpdateButtons();
      }
    }
    else
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (200.0 - 25.0 * (double) this.Selected), this.Highlight.localPosition.z);
    this.DropIcon.mainTexture = this.DropIcons[this.Selected];
    this.DropDesc.text = this.DropDescs[this.Selected];
    this.UpdatePantyCount();
  }

  public void UpdatePantyCount() => this.PantyCount.text = this.Inventory.PantyShots.ToString();
}
