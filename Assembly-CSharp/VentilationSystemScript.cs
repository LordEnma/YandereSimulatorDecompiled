// Decompiled with JetBrains decompiler
// Type: VentilationSystemScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class VentilationSystemScript : MonoBehaviour
{
  public GameObject FirstFloorShadow;
  public GameObject ThirdFloorShadow;
  public GameObject StinkBombCloud;
  public GameObject Window;
  public PromptBarScript PromptBar;
  public UILabel ExplanationLabel;
  public string[] Floor1RoomNames;
  public string[] Floor2RoomNames;
  public string[] Floor3RoomNames;
  public string[] FloorNames;
  public UILabel[] RoomLabels;
  public PromptScript Prompt;
  public Transform Highlight;
  public UILabel FloorLabel;
  public Transform[] Rooms;
  public bool CanStink;
  public bool Eighties;
  public bool Show;
  public int RoomID;
  public int Floor = 1;
  public int Column = 3;
  public int Row = 1;

  private void Start()
  {
    this.Window.SetActive(false);
    this.UpdateHighlight();
    this.UpdateRoomNameLabels();
    if (!GameGlobals.Eighties)
      return;
    this.Floor3RoomNames[3] = "Newspaper Club";
    this.Eighties = true;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
    {
      Time.timeScale = 0.0001f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[2].text = "Change Floor";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Yandere.RPGCamera.enabled = false;
      this.Prompt.Yandere.CanMove = false;
      this.Window.SetActive(true);
      this.Show = true;
      this.CheckForStinkBombs();
    }
    if (!this.Show)
      return;
    if (this.CanStink && Input.GetButtonDown("A"))
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.StinkBombCloud, this.Rooms[this.RoomID].position + Vector3.up * (float) (this.Floor - 1) * 4f, Quaternion.identity);
      if (this.Column > 1 && this.Column < 5)
        gameObject.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
      PickUpScript pickUp = this.Prompt.Yandere.PickUp;
      this.Prompt.Yandere.PickUp.Drop();
      Object.Destroy((Object) pickUp.gameObject);
      if (this.Floor == 3 && this.RoomID == 23)
        this.Prompt.Yandere.StudentManager.Portal.GetComponent<PortalScript>().Headmaster.SetActive(false);
      this.Exit();
    }
    if (Input.GetButtonDown("B"))
      this.Exit();
    if (Input.GetButtonDown("X"))
    {
      ++this.Floor;
      if (this.Floor > 3)
        this.Floor = 1;
      this.UpdateRoomNameLabels();
    }
    if (this.Prompt.Yandere.PauseScreen.InputManager.TappedRight)
    {
      if (this.Row == 1 || this.Row == 5)
      {
        ++this.Column;
        if (this.Column > 4)
          this.Column = 2;
      }
      else
        this.Column = this.Column != 1 ? 1 : 5;
      this.UpdateHighlight();
    }
    if (this.Prompt.Yandere.PauseScreen.InputManager.TappedLeft)
    {
      if (this.Row == 1 || this.Row == 5)
      {
        --this.Column;
        if (this.Column < 2)
          this.Column = 4;
      }
      else
        this.Column = this.Column != 1 ? 1 : 5;
      this.UpdateHighlight();
    }
    if (this.Prompt.Yandere.PauseScreen.InputManager.TappedDown)
    {
      if (this.Row == 1)
        this.Column = this.Column != 2 ? 5 : 1;
      else if (this.Row == 4)
        this.Column = this.Column != 1 ? 4 : 2;
      ++this.Row;
      if (this.Row > 5)
        this.Row = 1;
      this.UpdateHighlight();
    }
    if (!this.Prompt.Yandere.PauseScreen.InputManager.TappedUp)
      return;
    if (this.Row == 5)
      this.Column = this.Column != 2 ? 5 : 1;
    else if (this.Row == 2)
      this.Column = this.Column != 1 ? 4 : 2;
    --this.Row;
    if (this.Row < 1)
      this.Row = 5;
    this.UpdateHighlight();
  }

  private void CheckForStinkBombs()
  {
    this.CanStink = false;
    this.PromptBar.Label[0].text = "";
    if (this.Floor == 1 && this.RoomID == 6)
      this.ExplanationLabel.text = "The guidance counselor is too professional to abandon her duties because of a bad smell.";
    else if (this.Floor == 3 && this.RoomID == 3 && !this.Eighties)
      this.ExplanationLabel.text = "It looks like Info-chan has hacked the ventilation system and made it impossible to send any gases into her room...";
    else if ((Object) this.Prompt.Yandere.PickUp != (Object) null && this.Prompt.Yandere.PickUp.StinkBombs)
    {
      this.ExplanationLabel.text = "You have a box of stink bombs! Choose a room and press the 'accept' button to fill that room with a horrible stench, causing its inhabitants to evacuate it for a few minutes.";
      this.PromptBar.Label[0].text = "Accept";
      this.CanStink = true;
    }
    else
      this.ExplanationLabel.text = "If you come here with a box of stink bombs, you can fill one room with a horrible stench, causing its inhabitants to evacuate it for a few minutes.";
    this.PromptBar.UpdateButtons();
  }

  private void Exit()
  {
    this.Prompt.Yandere.RPGCamera.enabled = true;
    this.Prompt.Yandere.CanMove = true;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Window.SetActive(false);
    this.Prompt.enabled = true;
    Time.timeScale = 1f;
    this.Show = false;
  }

  public void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3((float) (180 * this.Column - 540), (float) (540 - 180 * this.Row), 0.0f);
    this.RoomID = this.Column + (this.Row - 1) * 5;
    this.CheckForStinkBombs();
  }

  public void UpdateRoomNameLabels()
  {
    this.FloorLabel.text = this.FloorNames[this.Floor];
    for (int index = 1; index < this.RoomLabels.Length; ++index)
    {
      if ((Object) this.RoomLabels[index] != (Object) null)
      {
        if (this.Floor == 1)
          this.RoomLabels[index].text = this.Floor1RoomNames[index];
        else if (this.Floor == 2)
          this.RoomLabels[index].text = this.Floor2RoomNames[index];
        else if (this.Floor == 3)
          this.RoomLabels[index].text = this.Floor3RoomNames[index];
      }
    }
    if (this.Floor == 1)
    {
      this.FirstFloorShadow.SetActive(true);
      this.ThirdFloorShadow.SetActive(false);
    }
    else if (this.Floor == 3)
    {
      this.FirstFloorShadow.SetActive(false);
      if (!this.Eighties)
        this.ThirdFloorShadow.SetActive(true);
    }
    else
    {
      this.FirstFloorShadow.SetActive(false);
      this.ThirdFloorShadow.SetActive(false);
    }
    this.CheckForStinkBombs();
  }
}
