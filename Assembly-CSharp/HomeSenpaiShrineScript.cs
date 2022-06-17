// Decompiled with JetBrains decompiler
// Type: HomeSenpaiShrineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeSenpaiShrineScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public GameObject[] Collectibles;
  public Transform[] Destinations;
  public Transform[] Targets;
  public Transform RightDoor;
  public Transform LeftDoor;
  public UILabel NameLabel;
  public UILabel DescLabel;
  public string[] Names;
  public string[] Descs;
  public float Rotation;
  private int Rows = 5;
  private int Columns = 3;
  private int X = 1;
  private int Y = 3;
  public bool Open;

  public void Start()
  {
    this.UpdateText(this.GetCurrentIndex());
    for (int ID = 1; ID < 11; ++ID)
    {
      if (PlayerGlobals.GetShrineCollectible(ID))
        this.Collectibles[ID].SetActive(true);
    }
  }

  private bool InUpperHalf() => this.Y < 2;

  private int GetCurrentIndex() => this.InUpperHalf() ? this.Y : 2 + (this.X + (this.Y - 2) * this.Columns);

  private void Update()
  {
    if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
    {
      if (this.HomeCamera.ID == 6)
      {
        this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
        this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
        this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
        if (this.InputManager.TappedUp)
          this.Y = this.Y > 0 ? this.Y - 1 : this.Rows - 1;
        if (this.InputManager.TappedDown)
          this.Y = this.Y < this.Rows - 1 ? this.Y + 1 : 0;
        if (this.InputManager.TappedRight && !this.InUpperHalf())
          this.X = this.X < this.Columns - 1 ? this.X + 1 : 0;
        if (this.InputManager.TappedLeft && !this.InUpperHalf())
          this.X = this.X > 0 ? this.X - 1 : this.Columns - 1;
        if (this.InUpperHalf())
          this.X = 1;
        int currentIndex = this.GetCurrentIndex();
        this.HomeCamera.Destination = this.Destinations[currentIndex];
        this.HomeCamera.Target = this.Targets[currentIndex];
        if ((this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight ? 1 : (this.InputManager.TappedLeft ? 1 : 0)) != 0)
          this.UpdateText(currentIndex - 1);
        if (Input.GetButtonDown("B"))
        {
          this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
          this.HomeCamera.Target = this.HomeCamera.Targets[0];
          this.HomeYandere.CanMove = true;
          this.HomeYandere.gameObject.SetActive(true);
          this.HomeWindow.Show = false;
        }
      }
    }
    else if (!this.Open)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
      this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
      this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, this.Rotation, this.LeftDoor.localEulerAngles.z);
    }
    if (!this.Open)
      return;
    this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
    this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
    this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
  }

  private void UpdateText(int newIndex)
  {
    if (newIndex == -1)
      newIndex = 10;
    if (newIndex == 0)
    {
      this.NameLabel.text = this.Names[newIndex];
      this.DescLabel.text = this.Descs[newIndex];
    }
    else if (PlayerGlobals.GetShrineCollectible(newIndex))
    {
      this.NameLabel.text = this.Names[newIndex];
      this.DescLabel.text = this.Descs[newIndex];
    }
    else
    {
      this.NameLabel.text = "???";
      this.DescLabel.text = "I'd like to find something that Senpai touched and keep it here...";
    }
  }
}
