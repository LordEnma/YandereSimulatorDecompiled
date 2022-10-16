// Decompiled with JetBrains decompiler
// Type: WorkbenchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WorkbenchScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public WeaponScript MakeshiftKnife;
  public InventoryScript Inventory;
  public PromptBarScript PromptBar;
  public PromptScript Prompt;
  public GameObject ConfirmationWindow;
  public GameObject EleventhOption;
  public GameObject OutcomeCamera;
  public Transform WorkbenchWindow;
  public Transform Highlight;
  public UILabel ConfirmationLabel;
  public UILabel HeaderLabel;
  public UILabel HintLabel;
  public AudioSource MyAudio;
  public AudioClip Success;
  public UISprite Darkness;
  public GameObject[] MaterialModel;
  public GameObject[] OutcomeModel;
  public GameObject[] Checkmark;
  public AudioClip[] LiquidSFX;
  public AudioClip[] SolidSFX;
  public AudioClip[] SFX;
  public UILabel[] Label;
  public string[] Hints;
  public int[] Material;
  public bool[] InStock;
  public bool[] Solids;
  public bool CraftingSequence;
  public bool Chemistry;
  public bool Triple;
  public bool Return;
  public bool Show;
  public string Outcome = "";
  public int Checkmarks;
  public int Selection = 1;
  public int OutcomeID = 1;
  public int Limit = 11;
  public float Rotation;

  private void Start()
  {
    this.WorkbenchWindow.gameObject.SetActive(false);
    this.RemoveCheckmarks();
  }

  private void Update()
  {
    if (!this.Show)
    {
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Prompt.Yandere.Chased || this.Prompt.Yandere.Chasers != 0)
        return;
      if (!this.Chemistry)
      {
        this.Prompt.Yandere.MainCamera.transform.position = new Vector3(26f, 5.55f, 5f);
        this.Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(54f, 0.0f, 0.0f);
        this.Prompt.Yandere.transform.position = new Vector3(26f, 4f, 4f);
      }
      else
      {
        this.Prompt.Yandere.MainCamera.transform.position = new Vector3(26f, 5.55f, -9.307f);
        this.Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(54f, 180f, 0.0f);
        this.Prompt.Yandere.transform.position = new Vector3(26f, 4f, -8.5f);
      }
      this.Prompt.Yandere.MyController.enabled = false;
      this.Prompt.Yandere.RPGCamera.enabled = false;
      this.Prompt.Yandere.CanMove = false;
      this.WorkbenchWindow.gameObject.SetActive(true);
      this.PromptBar.Label[0].text = "Select";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.Show = true;
      this.Selection = 1;
      this.UpdateHighlight();
      if (!this.Chemistry)
      {
        this.Limit = 11;
        this.CheckInventory();
        this.EleventhOption.SetActive(true);
        this.HeaderLabel.text = "Materials";
      }
      else
      {
        this.Limit = 10;
        this.CheckChemicals();
        this.EleventhOption.SetActive(false);
        this.HeaderLabel.text = "Chemicals";
      }
    }
    else
    {
      if ((Object) this.MakeshiftKnife != (Object) null)
      {
        Debug.Log((object) "Telling the damn knife to use gravity.");
        this.MakeshiftKnife.MyRigidbody.useGravity = true;
        this.MakeshiftKnife.MyRigidbody.isKinematic = false;
        this.MakeshiftKnife = (WeaponScript) null;
      }
      if (!this.CraftingSequence)
      {
        if (!this.ConfirmationWindow.activeInHierarchy)
        {
          if (this.InputManager.TappedUp)
          {
            --this.Selection;
            this.UpdateHighlight();
          }
          else if (this.InputManager.TappedDown)
          {
            ++this.Selection;
            this.UpdateHighlight();
          }
          if (Input.GetButtonDown("A"))
          {
            if (!this.InStock[this.Selection] || (double) this.Label[this.Selection].alpha != 1.0)
              return;
            this.MaterialModel[this.Selection].SetActive(!this.MaterialModel[this.Selection].activeInHierarchy);
            this.Checkmark[this.Selection].SetActive(!this.Checkmark[this.Selection].activeInHierarchy);
            if (this.Checkmark[this.Selection].activeInHierarchy)
              this.Material[this.Checkmarks + 1] = this.Selection;
            else
              this.Material[this.Checkmarks] = 0;
            this.CountCheckmarks();
            this.PlayRandomSound();
          }
          else if (Input.GetButtonDown("B"))
          {
            this.WorkbenchWindow.gameObject.SetActive(false);
            this.Prompt.Yandere.MyController.enabled = true;
            this.Prompt.Yandere.RPGCamera.enabled = true;
            this.Prompt.Yandere.CanMove = true;
            this.PromptBar.ClearButtons();
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = false;
            this.RemoveCheckmarks();
            this.Material[1] = 0;
            this.Material[2] = 0;
            this.Material[3] = 0;
            this.Triple = false;
            this.Show = false;
          }
          else
          {
            if (!Input.GetButtonDown("X") || !(this.PromptBar.Label[2].text != ""))
              return;
            this.ConfirmationWindow.SetActive(true);
            this.PromptBar.Label[0].text = "";
            if (!this.Chemistry)
            {
              this.ConfirmationLabel.text = "Combine these objects to make " + this.Outcome + "?";
              this.PromptBar.Label[0].text = "Yes";
            }
            else if (this.Prompt.Yandere.Class.ChemistryGrade + this.Prompt.Yandere.Class.ChemistryBonus < this.OutcomeID)
            {
              this.ConfirmationLabel.text = "You lack the chemistry knowledge to combine these chemicals effectively. Raise your Chemistry stat to at least " + this.OutcomeID.ToString() + " and try again.";
            }
            else
            {
              this.ConfirmationLabel.text = "Synthesize these chemicals to create " + this.Outcome + "?";
              this.PromptBar.Label[0].text = "Yes";
            }
            this.PromptBar.Label[1].text = "No";
            this.PromptBar.Label[2].text = "";
            this.PromptBar.UpdateButtons();
          }
        }
        else if (this.PromptBar.Label[0].text != "" && Input.GetButtonDown("A"))
        {
          this.ConfirmationWindow.SetActive(false);
          this.OutcomeModel[this.OutcomeID].transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
          this.OutcomeModel[this.OutcomeID].SetActive(true);
          this.OutcomeCamera.SetActive(true);
          this.CraftingSequence = true;
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.Label[1].text = "";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          if (this.Chemistry)
          {
            this.MyAudio.clip = this.Success;
            this.MyAudio.Play();
          }
          else
            this.PlayRandomSound();
        }
        else
        {
          if (!Input.GetButtonDown("B"))
            return;
          this.ConfirmationWindow.SetActive(false);
          this.PromptBar.Label[0].text = "Select";
          this.PromptBar.Label[1].text = "Exit";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
        }
      }
      else if (!this.Return)
      {
        this.Rotation = Mathf.Lerp(this.Rotation, 360f, Time.deltaTime * 10f);
        this.OutcomeModel[this.OutcomeID].transform.localScale = Vector3.Lerp(this.OutcomeModel[this.OutcomeID].transform.localScale, Vector3.one, Time.deltaTime * 10f);
        this.OutcomeModel[this.OutcomeID].transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
        this.Darkness.alpha = Mathf.Lerp(this.Darkness.alpha, 0.5f, Time.deltaTime * 10f);
        if ((double) this.Darkness.alpha <= 0.49000000953674316 || !Input.GetButtonDown("A"))
          return;
        if (!this.Chemistry)
        {
          if (this.OutcomeID == 1)
          {
            this.Inventory.Ammonium = false;
            this.Inventory.Balloons = false;
            GameObject gameObject = Object.Instantiate<GameObject>(this.Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[13], this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.5f), Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.name = "Box of Stink Bombs";
          }
          else if (this.OutcomeID == 2)
          {
            this.Inventory.Hairpins = false;
            this.Inventory.PaperClips = false;
            this.Inventory.LockPick = true;
          }
          else if (this.OutcomeID == 3)
          {
            this.Inventory.SilverFulminate = false;
            this.Inventory.Paper = false;
            GameObject gameObject = Object.Instantiate<GameObject>(this.Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[12], this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.5f), Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.name = "Box of Bang Snaps";
          }
          else if (this.OutcomeID == 4)
          {
            this.Inventory.Nails = false;
            this.Prompt.Yandere.EquippedWeapon.Nails.SetActive(true);
          }
          else if (this.OutcomeID == 5)
          {
            this.Inventory.Bandages = false;
            this.Inventory.WoodenSticks = false;
            this.Inventory.Glass = false;
            this.MakeshiftKnife = this.Prompt.Yandere.WeaponManager.Weapons[45];
            this.MakeshiftKnife.gameObject.SetActive(true);
            this.MakeshiftKnife.transform.position = this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.5f);
            this.MakeshiftKnife.Start();
            this.MakeshiftKnife.MyRigidbody.useGravity = true;
            this.MakeshiftKnife.MyRigidbody.isKinematic = false;
          }
        }
        else
        {
          if (this.OutcomeID == 1)
          {
            this.Inventory.Mustard = false;
            this.Inventory.Salt = false;
            this.Inventory.EmeticChemical = true;
            ++this.Inventory.EmeticPoisons;
          }
          else if (this.OutcomeID == 2)
          {
            this.Inventory.Tyramine = false;
            this.Inventory.Phenylethylamine = false;
            this.Inventory.HeadacheChemical = true;
            ++this.Inventory.HeadachePoisons;
          }
          else if (this.OutcomeID == 3)
          {
            this.Inventory.Acetone = false;
            this.Inventory.Chloroform = false;
            this.Inventory.SedativeChemical = true;
            ++this.Inventory.SedativePoisons;
          }
          else if (this.OutcomeID == 4)
          {
            this.Inventory.AceticAcid = false;
            this.Inventory.BariumCarbonate = false;
            this.Inventory.LethalChemical = true;
            ++this.Inventory.LethalPoisons;
          }
          else if (this.OutcomeID == 5)
          {
            this.Inventory.PotassiumNitrate = false;
            this.Inventory.Sugar = false;
            GameObject gameObject = Object.Instantiate<GameObject>(this.Prompt.Yandere.PauseScreen.FavorMenu.DropsMenu.InfoChanWindow.Drops[14], this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.5f), Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.name = "Smoke Bomb";
          }
          this.Prompt.Yandere.StudentManager.UpdateAllBentos();
        }
        this.RemoveCheckmarks();
        if (!this.Chemistry)
          this.CheckInventory();
        else
          this.CheckChemicals();
        this.Return = true;
      }
      else
      {
        this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
        this.OutcomeModel[this.OutcomeID].transform.localScale = Vector3.Lerp(this.OutcomeModel[this.OutcomeID].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.OutcomeModel[this.OutcomeID].transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
        if ((double) this.Darkness.alpha != 0.0)
          return;
        this.OutcomeModel[this.OutcomeID].transform.localScale = Vector3.zero;
        this.OutcomeModel[this.OutcomeID].SetActive(false);
        this.OutcomeCamera.SetActive(false);
        this.PromptBar.Label[0].text = "Select";
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.CraftingSequence = false;
        this.Return = false;
      }
    }
  }

  private void PlayRandomSound()
  {
    this.MyAudio.clip = !this.Chemistry ? this.SFX[Random.Range(1, this.SFX.Length)] : (!this.Solids[this.Selection] ? this.LiquidSFX[Random.Range(1, this.LiquidSFX.Length)] : this.SolidSFX[Random.Range(1, this.SolidSFX.Length)]);
    this.MyAudio.Play();
  }

  private void CheckInventory()
  {
    Debug.Log((object) "The game is now checking what items are currently in Yandere-chan's inventory.");
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      this.Label[index].text = "?????";
      this.InStock[index] = false;
    }
    if (this.Inventory.Ammonium)
    {
      this.Label[1].text = "Ammonium";
      this.InStock[1] = true;
    }
    if (this.Inventory.Balloons)
    {
      this.Label[2].text = "Balloons";
      this.InStock[2] = true;
    }
    if (this.Inventory.Bandages)
    {
      this.Label[3].text = "Bandages";
      this.InStock[3] = true;
    }
    if (this.Inventory.Glass)
    {
      this.Label[4].text = "Glass Shards";
      this.InStock[4] = true;
    }
    if (this.Inventory.Hairpins)
    {
      this.Label[5].text = "Hair Pins";
      this.InStock[5] = true;
    }
    if (this.Inventory.Nails)
    {
      this.Label[6].text = "Nails";
      this.InStock[6] = true;
    }
    if (this.Inventory.Paper)
    {
      this.Label[7].text = "Paper";
      this.InStock[7] = true;
    }
    if (this.Inventory.PaperClips)
    {
      this.Label[8].text = "Paper Clips";
      this.InStock[8] = true;
    }
    if (this.Inventory.SilverFulminate)
    {
      this.Label[9].text = "Silver Fulminate";
      this.InStock[9] = true;
    }
    if (this.Inventory.WoodenSticks)
    {
      this.Label[10].text = "Wooden Sticks";
      this.InStock[10] = true;
    }
    if (this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.WeaponID == 9 && !this.Prompt.Yandere.EquippedWeapon.Nails.activeInHierarchy)
    {
      this.Label[11].text = "Baseball Bat";
      this.InStock[11] = true;
    }
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Label[index].text != "?????")
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
  }

  private void CheckChemicals()
  {
    Debug.Log((object) "The game is now checking what chemicals are currently in Yandere-chan's inventory.");
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      this.Label[index].text = "?????";
      this.InStock[index] = false;
    }
    if (this.Inventory.Mustard)
    {
      this.Label[1].text = "Mustard";
      this.InStock[1] = true;
    }
    if (this.Inventory.Salt)
    {
      this.Label[2].text = "Salt";
      this.InStock[2] = true;
    }
    if (this.Inventory.Tyramine)
    {
      this.Label[3].text = "Tyramine";
      this.InStock[3] = true;
    }
    if (this.Inventory.Phenylethylamine)
    {
      this.Label[4].text = "Phenylethylamine";
      this.InStock[4] = true;
    }
    if (this.Inventory.Acetone)
    {
      this.Label[5].text = "Acetone";
      this.InStock[5] = true;
    }
    if (this.Inventory.Chloroform)
    {
      this.Label[6].text = "Chloroform";
      this.InStock[6] = true;
    }
    if (this.Inventory.AceticAcid)
    {
      this.Label[7].text = "Acetic Acid";
      this.InStock[7] = true;
    }
    if (this.Inventory.BariumCarbonate)
    {
      this.Label[8].text = "Barium Carbonate";
      this.InStock[8] = true;
    }
    if (this.Inventory.PotassiumNitrate)
    {
      this.Label[9].text = "Potassium Nitrate";
      this.InStock[9] = true;
    }
    if (this.Inventory.Sugar)
    {
      this.Label[10].text = "Sugar";
      this.InStock[10] = true;
    }
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Label[index].text != "?????")
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
  }

  private void UpdateHighlight()
  {
    if (this.Selection > this.Limit)
      this.Selection = 1;
    else if (this.Selection < 1)
      this.Selection = this.Limit;
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (440.0 - 80.0 * (double) this.Selection), this.Highlight.localPosition.z);
    this.HintLabel.text = this.Hints[this.Selection];
  }

  private void CountCheckmarks()
  {
    Debug.Log((object) "The game is now counting how many checkmarks are currently displayed.");
    this.PromptBar.Label[2].text = "";
    this.Checkmarks = 0;
    this.Triple = false;
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Checkmark[index].activeInHierarchy)
      {
        ++this.Checkmarks;
        if (!this.Chemistry && (index == 3 || index == 4 || index == 10))
          this.Triple = true;
      }
    }
    if (!this.Triple && this.Checkmarks == 2)
      this.PromptBar.Label[2].text = "Combine";
    else if (this.Checkmarks == 3)
      this.PromptBar.Label[2].text = "Combine";
    this.PromptBar.UpdateButtons();
    if (!this.Chemistry)
      this.DisableInvalidOptions();
    else
      this.DisableInvalidChemicals();
  }

  private void RemoveCheckmarks()
  {
    for (int index = 1; index < this.Limit + 1; ++index)
    {
      this.MaterialModel[index].SetActive(false);
      this.Checkmark[index].SetActive(false);
    }
    this.Checkmarks = 0;
  }

  private void DisableInvalidOptions()
  {
    Debug.Log((object) "The player has picked a material, and the game is now disabling the materials that cannot be applied to that material.");
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Checkmarks > 0)
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      else
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    if (!this.Triple)
    {
      if (this.Material[1] == 1 || this.Material[1] == 2)
      {
        this.Label[1].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[2].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "five stink bombs";
        this.OutcomeID = 1;
      }
      else if (this.Material[1] == 5 || this.Material[1] == 8)
      {
        this.Label[5].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[8].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "a lockpick";
        this.OutcomeID = 2;
      }
      else if (this.Material[1] == 7 || this.Material[1] == 9)
      {
        this.Label[7].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[9].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "five bang snaps";
        this.OutcomeID = 3;
      }
      else if (this.Material[1] == 6 || this.Material[1] == 11)
      {
        this.Label[11].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[6].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "a spiked baseball bat";
        this.OutcomeID = 4;
      }
    }
    if (this.Triple && (this.Material[1] == 3 || this.Material[2] == 3 || this.Material[1] == 4 || this.Material[2] == 4 || this.Material[1] == 10 || this.Material[2] == 10))
    {
      this.Label[3].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Label[4].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Label[10].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Outcome = "a makeshift knife";
      this.OutcomeID = 5;
    }
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Label[index].text == "?????")
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    }
  }

  private void DisableInvalidChemicals()
  {
    Debug.Log((object) "The player has picked a chemical, and the game is now disabling the chemicals that cannot be synthesized with that chemical.");
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Checkmarks > 0)
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      else
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    if (!this.Triple)
    {
      if (this.Material[1] == 1 || this.Material[1] == 2)
      {
        this.Label[1].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[2].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "emetic poison";
        this.OutcomeID = 1;
      }
      else if (this.Material[1] == 3 || this.Material[1] == 4)
      {
        this.Label[3].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[4].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "headache poison";
        this.OutcomeID = 2;
      }
      else if (this.Material[1] == 5 || this.Material[1] == 6)
      {
        this.Label[5].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[6].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "a sedative";
        this.OutcomeID = 3;
      }
      else if (this.Material[1] == 7 || this.Material[1] == 8)
      {
        this.Label[7].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[8].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "lethal poison";
        this.OutcomeID = 4;
      }
      else if (this.Material[1] == 9 || this.Material[1] == 10)
      {
        this.Label[9].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Label[10].color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Outcome = "a smoke bomb";
        this.OutcomeID = 5;
      }
    }
    for (int index = 1; index < this.Checkmark.Length; ++index)
    {
      if (this.Label[index].text == "?????")
        this.Label[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    }
  }
}
