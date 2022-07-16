// Decompiled with JetBrains decompiler
// Type: WeaponMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WeaponMenuScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputDeviceScript InputDevice;
  public PauseScreenScript PauseScreen;
  public YandereScript Yandere;
  public InputManagerScript IM;
  public UIPanel KeyboardPanel;
  public UIPanel Panel;
  public Transform KeyboardMenu;
  public bool KeyboardShow;
  public bool Released = true;
  public bool Show;
  public UISprite[] BG;
  public UISprite[] Outline;
  public UISprite[] Item;
  public UISprite[] KeyboardBG;
  public UISprite[] KeyboardOutline;
  public UISprite[] KeyboardItem;
  public UISprite EquipCaseWeaponButton;
  public UILabel EquipCaseWeaponKey;
  public int Selected = 1;
  public Color OriginalColor;
  public Transform Button;
  public float Timer;

  private void Start()
  {
    this.KeyboardMenu.localScale = Vector3.zero;
    this.transform.localScale = Vector3.zero;
    this.OriginalColor = this.BG[1].color;
    this.UpdateSprites();
  }

  private void Update()
  {
    if (!this.PauseScreen.Show && !this.Yandere.DebugMenu.activeInHierarchy)
    {
      if (this.Yandere.CanMove && !this.Yandere.Aiming || this.Yandere.Chased && !this.Yandere.Struggling && !this.Yandere.Sprayed && !this.Yandere.DelinquentFighting)
      {
        if (this.IM.DPadUp && this.IM.TappedUp || this.IM.DPadDown && this.IM.TappedDown || this.IM.DPadLeft && this.IM.TappedLeft || this.IM.DPadRight && this.IM.TappedRight)
        {
          this.Yandere.EmptyHands();
          if (this.IM.DPadLeft)
          {
            this.Button.localPosition = new Vector3(-320f, 0.0f, 0.0f);
            this.Selected = 1;
          }
          else if (this.IM.DPadRight)
          {
            this.Button.localPosition = new Vector3(320f, 0.0f, 0.0f);
            this.Selected = 2;
          }
          else if (this.IM.DPadUp)
          {
            if (!this.Show)
              this.Selected = 6;
            if (this.Selected == 6)
            {
              this.Button.localPosition = new Vector3(64f, 190f, 0.0f);
              this.Selected = 3;
            }
            else
            {
              this.Button.localPosition = new Vector3(64f, 380f, 0.0f);
              this.Selected = 6;
            }
          }
          else if (this.IM.DPadDown)
          {
            if (this.Selected == 4)
            {
              this.Button.localPosition = new Vector3(64f, -250f, 0.0f);
              this.Selected = 5;
            }
            else
            {
              this.Button.localPosition = new Vector3(64f, -125f, 0.0f);
              this.Selected = 4;
            }
          }
          if (this.IM.DPadLeft || this.IM.DPadRight || this.IM.DPadUp || (Object) this.Yandere.Mask != (Object) null)
          {
            this.KeyboardShow = false;
            this.Panel.enabled = true;
            this.Show = true;
          }
          this.UpdateSprites();
        }
        if (!this.Yandere.EasterEggMenu.activeInHierarchy && !this.Yandere.DebugMenu.activeInHierarchy && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) && (double) this.Yandere.DebugTimer == 0.0))
        {
          this.Yandere.EmptyHands();
          this.KeyboardPanel.enabled = true;
          this.KeyboardShow = true;
          this.Show = false;
          this.Timer = 0.0f;
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
            this.Selected = 4;
            if (this.Yandere.Equipped > 0)
            {
              this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
              this.Yandere.ReachWeight = 1f;
              this.Yandere.Unequip();
            }
            if ((Object) this.Yandere.PickUp != (Object) null)
              this.Yandere.PickUp.Drop();
            this.Yandere.Mopping = false;
          }
          else if (Input.GetKeyDown(KeyCode.Alpha2))
          {
            this.Selected = 1;
            this.Equip();
          }
          else if (Input.GetKeyDown(KeyCode.Alpha3))
          {
            this.Selected = 2;
            this.Equip();
          }
          else if (Input.GetKeyDown(KeyCode.Alpha4))
          {
            this.Selected = 3;
            if ((Object) this.Yandere.Container != (Object) null)
              this.Yandere.ObstacleDetector.gameObject.SetActive(true);
          }
          else if (Input.GetKeyDown(KeyCode.Alpha5))
          {
            this.Selected = 5;
            this.DropMask();
          }
          else if (Input.GetKeyDown(KeyCode.Alpha6) && (double) this.Yandere.DebugTimer == 0.0)
          {
            this.Selected = 6;
            this.DropBookbag();
          }
          this.UpdateSprites();
        }
      }
      if (this.Yandere.CanMove || this.Yandere.Chased && !this.Yandere.Sprayed && !this.StudentManager.PinningDown)
      {
        if (!this.Show)
        {
          if ((double) Input.GetAxis("DpadY") < -0.5)
          {
            if (this.Yandere.Equipped > 0)
            {
              if (this.Yandere.EquippedWeapon.Concealable)
              {
                this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
                this.Yandere.ReachWeight = 1f;
              }
              this.Yandere.Unequip();
            }
            if ((Object) this.Yandere.PickUp != (Object) null)
              this.Yandere.PickUp.Drop();
            this.Yandere.Mopping = false;
          }
        }
        else
        {
          if (Input.GetButtonDown("A"))
          {
            if (this.Selected < 3)
            {
              if ((Object) this.Yandere.Weapon[this.Selected] != (Object) null)
                this.Equip();
            }
            else if (this.Selected == 3)
            {
              if ((Object) this.Yandere.Container != (Object) null)
                this.Yandere.ObstacleDetector.gameObject.SetActive(true);
            }
            else if (this.Selected == 5)
              this.DropMask();
            else if (this.Selected == 6)
            {
              this.DropBookbag();
            }
            else
            {
              if (this.Yandere.Equipped > 0)
                this.Yandere.Unequip();
              if ((Object) this.Yandere.PickUp != (Object) null)
                this.Yandere.PickUp.Drop();
              this.Yandere.Mopping = false;
            }
          }
          if (this.EquipCaseWeaponButton.enabled && Input.GetButtonDown("Y"))
          {
            if ((Object) this.Yandere.Container.TrashCan.ConcealedWeapon != (Object) null)
            {
              WeaponScript concealedWeapon = this.Yandere.Container.TrashCan.ConcealedWeapon;
            }
            this.Yandere.Container.TrashCan.RemoveContents();
            this.UpdateSprites();
            this.Show = false;
          }
          if (Input.GetButtonDown("B"))
            this.Show = false;
        }
      }
    }
    if (!this.Show)
    {
      if ((double) this.transform.localScale.x > 0.100000001490116)
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      else if (this.Panel.enabled)
      {
        this.transform.localScale = Vector3.zero;
        this.Panel.enabled = false;
      }
    }
    else
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if ((!this.Yandere.CanMove || this.Yandere.Aiming || this.PauseScreen.Show || this.InputDevice.Type == InputDeviceType.MouseAndKeyboard) && (!this.Yandere.Chased || this.Yandere.Sprayed))
        this.Show = false;
    }
    if (!this.KeyboardShow)
    {
      if ((double) this.KeyboardMenu.localScale.x > 0.100000001490116)
      {
        this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else
      {
        if (!this.KeyboardPanel.enabled)
          return;
        this.KeyboardMenu.localScale = Vector3.zero;
        this.KeyboardPanel.enabled = false;
      }
    }
    else
    {
      this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 5.0)
        this.KeyboardShow = false;
      if (this.EquipCaseWeaponKey.enabled && Input.GetButtonDown("Y"))
      {
        if ((Object) this.Yandere.Container.TrashCan.ConcealedWeapon != (Object) null)
        {
          WeaponScript concealedWeapon = this.Yandere.Container.TrashCan.ConcealedWeapon;
        }
        this.Yandere.Container.TrashCan.RemoveContents();
        this.UpdateSprites();
      }
      if (this.Yandere.CanMove && !this.Yandere.Aiming && !this.PauseScreen.Show && this.InputDevice.Type != InputDeviceType.Gamepad && !Input.GetButton("Y"))
        return;
      this.KeyboardShow = false;
    }
  }

  public void Equip()
  {
    if (!((Object) this.Yandere.Weapon[this.Selected] != (Object) null))
      return;
    this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
    this.Yandere.ReachWeight = 1f;
    if ((Object) this.Yandere.PickUp != (Object) null)
      this.Yandere.PickUp.Drop();
    if (this.Yandere.Equipped == 3)
      this.Yandere.Weapon[3].Drop();
    if ((Object) this.Yandere.Weapon[1] != (Object) null)
      this.Yandere.Weapon[1].gameObject.SetActive(false);
    if ((Object) this.Yandere.Weapon[2] != (Object) null)
      this.Yandere.Weapon[2].gameObject.SetActive(false);
    this.Yandere.Equipped = this.Selected;
    this.Yandere.EquippedWeapon.gameObject.SetActive(true);
    if (this.Yandere.EquippedWeapon.Flaming)
      this.Yandere.EquippedWeapon.FireEffect.Play();
    if (!this.Yandere.Gloved)
      this.Yandere.EquippedWeapon.FingerprintID = 100;
    this.Yandere.StudentManager.UpdateStudents();
    this.Yandere.WeaponManager.UpdateLabels();
    if (this.Yandere.EquippedWeapon.Suspicious)
    {
      if (!this.Yandere.WeaponWarning)
      {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
        this.Yandere.WeaponWarning = true;
      }
    }
    else
      this.Yandere.WeaponWarning = false;
    AudioSource.PlayClipAtPoint(this.Yandere.EquippedWeapon.EquipClip, Camera.main.transform.position);
    this.Show = false;
  }

  public void UpdateSprites()
  {
    this.EquipCaseWeaponButton.enabled = false;
    this.EquipCaseWeaponKey.enabled = false;
    for (int index = 1; index < 3; ++index)
    {
      UISprite uiSprite1 = this.KeyboardBG[index];
      UISprite uiSprite2 = this.BG[index];
      if (this.Selected == index)
      {
        uiSprite1.color = new Color(1f, 1f, 1f, 1f);
        uiSprite2.color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        uiSprite1.color = this.OriginalColor;
        uiSprite2.color = this.OriginalColor;
      }
      UISprite uiSprite3 = this.Item[index];
      UISprite uiSprite4 = this.Outline[index];
      UISprite uiSprite5 = this.KeyboardItem[index];
      UISprite uiSprite6 = this.KeyboardOutline[index];
      if ((Object) this.Yandere.Weapon[index] == (Object) null)
      {
        uiSprite3.color = new Color(uiSprite3.color.r, uiSprite3.color.g, uiSprite3.color.b, 0.0f);
        uiSprite2.color = new Color(uiSprite2.color.r, uiSprite2.color.g, uiSprite2.color.b, 0.5f);
        uiSprite4.color = new Color(uiSprite4.color.r, uiSprite4.color.g, uiSprite4.color.b, 0.5f);
        uiSprite5.color = new Color(uiSprite5.color.r, uiSprite5.color.g, uiSprite5.color.b, 0.0f);
        uiSprite1.color = new Color(uiSprite1.color.r, uiSprite1.color.g, uiSprite1.color.b, 0.5f);
        uiSprite6.color = new Color(uiSprite6.color.r, uiSprite6.color.g, uiSprite6.color.b, 0.5f);
      }
      else
      {
        uiSprite3.spriteName = this.Yandere.Weapon[index].SpriteName;
        uiSprite3.color = new Color(uiSprite3.color.r, uiSprite3.color.g, uiSprite3.color.b, 1f);
        uiSprite2.color = new Color(uiSprite2.color.r, uiSprite2.color.g, uiSprite2.color.b, 1f);
        uiSprite4.color = new Color(uiSprite4.color.r, uiSprite4.color.g, uiSprite4.color.b, 1f);
        uiSprite5.spriteName = this.Yandere.Weapon[index].SpriteName;
        uiSprite5.color = new Color(uiSprite5.color.r, uiSprite5.color.g, uiSprite5.color.b, 1f);
        uiSprite1.color = new Color(uiSprite1.color.r, uiSprite1.color.g, uiSprite1.color.b, 1f);
        uiSprite6.color = new Color(uiSprite6.color.r, uiSprite6.color.g, uiSprite6.color.b, 1f);
      }
    }
    UISprite uiSprite7 = this.KeyboardItem[3];
    UISprite uiSprite8 = this.Item[3];
    UISprite uiSprite9 = this.KeyboardBG[3];
    UISprite uiSprite10 = this.BG[3];
    UISprite uiSprite11 = this.Outline[3];
    UISprite uiSprite12 = this.KeyboardOutline[3];
    if ((Object) this.Yandere.Container == (Object) null)
    {
      uiSprite7.color = new Color(uiSprite7.color.r, uiSprite7.color.g, uiSprite7.color.b, 0.0f);
      uiSprite8.color = new Color(uiSprite8.color.r, uiSprite8.color.g, uiSprite8.color.b, 0.0f);
      if (this.Selected == 3)
      {
        uiSprite9.color = new Color(1f, 1f, 1f, 1f);
        uiSprite10.color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        uiSprite9.color = this.OriginalColor;
        uiSprite10.color = this.OriginalColor;
      }
      uiSprite10.color = new Color(uiSprite10.color.r, uiSprite10.color.g, uiSprite10.color.b, 0.5f);
      uiSprite11.color = new Color(uiSprite11.color.r, uiSprite11.color.g, uiSprite11.color.b, 0.5f);
      uiSprite9.color = new Color(uiSprite9.color.r, uiSprite9.color.g, uiSprite9.color.b, 0.5f);
      uiSprite12.color = new Color(uiSprite12.color.r, uiSprite12.color.g, uiSprite12.color.b, 0.5f);
    }
    else
    {
      uiSprite8.color = new Color(uiSprite8.color.r, uiSprite8.color.g, uiSprite8.color.b, 1f);
      uiSprite10.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite11.color = new Color(uiSprite11.color.r, uiSprite11.color.g, uiSprite11.color.b, 1f);
      uiSprite7.spriteName = this.Yandere.Container.SpriteName;
      uiSprite7.color = new Color(uiSprite7.color.r, uiSprite7.color.g, uiSprite7.color.b, 1f);
      uiSprite9.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite12.color = new Color(uiSprite12.color.r, uiSprite12.color.g, uiSprite12.color.b, 1f);
    }
    UISprite uiSprite13 = this.KeyboardItem[5];
    UISprite uiSprite14 = this.Item[5];
    UISprite uiSprite15 = this.KeyboardBG[5];
    UISprite uiSprite16 = this.BG[5];
    UISprite uiSprite17 = this.Outline[5];
    UISprite uiSprite18 = this.KeyboardOutline[5];
    if ((Object) this.Yandere.Mask == (Object) null)
    {
      uiSprite13.color = new Color(uiSprite13.color.r, uiSprite13.color.g, uiSprite13.color.b, 0.0f);
      uiSprite14.color = new Color(uiSprite14.color.r, uiSprite14.color.g, uiSprite14.color.b, 0.0f);
      if (this.Selected == 5)
      {
        uiSprite15.color = new Color(1f, 1f, 1f, 1f);
        uiSprite16.color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        uiSprite15.color = this.OriginalColor;
        uiSprite16.color = this.OriginalColor;
      }
      uiSprite16.color = new Color(uiSprite16.color.r, uiSprite16.color.g, uiSprite16.color.b, 0.5f);
      uiSprite17.color = new Color(uiSprite17.color.r, uiSprite17.color.g, uiSprite17.color.b, 0.5f);
      uiSprite15.color = new Color(uiSprite15.color.r, uiSprite15.color.g, uiSprite15.color.b, 0.5f);
      uiSprite18.color = new Color(uiSprite18.color.r, uiSprite18.color.g, uiSprite18.color.b, 0.5f);
    }
    else
    {
      uiSprite13.color = new Color(uiSprite13.color.r, uiSprite13.color.g, uiSprite13.color.b, 1f);
      uiSprite14.color = new Color(uiSprite14.color.r, uiSprite14.color.g, uiSprite14.color.b, 1f);
      uiSprite16.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite17.color = new Color(uiSprite17.color.r, uiSprite17.color.g, uiSprite17.color.b, 1f);
      uiSprite13.color = new Color(uiSprite13.color.r, uiSprite13.color.g, uiSprite13.color.b, 1f);
      uiSprite15.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite18.color = new Color(uiSprite18.color.r, uiSprite18.color.g, uiSprite18.color.b, 1f);
    }
    UISprite uiSprite19 = this.KeyboardItem[6];
    UISprite uiSprite20 = this.Item[6];
    UISprite uiSprite21 = this.KeyboardBG[6];
    UISprite uiSprite22 = this.BG[6];
    UISprite uiSprite23 = this.Outline[6];
    UISprite uiSprite24 = this.KeyboardOutline[6];
    if ((Object) this.Yandere.Bookbag == (Object) null)
    {
      uiSprite19.color = new Color(uiSprite19.color.r, uiSprite19.color.g, uiSprite19.color.b, 0.0f);
      uiSprite20.color = new Color(uiSprite20.color.r, uiSprite20.color.g, uiSprite20.color.b, 0.0f);
      if (this.Selected == 6)
      {
        uiSprite21.color = new Color(1f, 1f, 1f, 1f);
        uiSprite22.color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        uiSprite21.color = this.OriginalColor;
        uiSprite22.color = this.OriginalColor;
      }
      uiSprite22.color = new Color(uiSprite22.color.r, uiSprite22.color.g, uiSprite22.color.b, 0.5f);
      uiSprite23.color = new Color(uiSprite23.color.r, uiSprite23.color.g, uiSprite23.color.b, 0.5f);
      uiSprite21.color = new Color(uiSprite21.color.r, uiSprite21.color.g, uiSprite21.color.b, 0.5f);
      uiSprite24.color = new Color(uiSprite24.color.r, uiSprite24.color.g, uiSprite24.color.b, 0.5f);
    }
    else
    {
      uiSprite19.color = new Color(uiSprite19.color.r, uiSprite19.color.g, uiSprite19.color.b, 1f);
      uiSprite20.color = new Color(uiSprite20.color.r, uiSprite20.color.g, uiSprite20.color.b, 1f);
      uiSprite22.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite23.color = new Color(uiSprite23.color.r, uiSprite23.color.g, uiSprite23.color.b, 1f);
      uiSprite19.color = new Color(uiSprite19.color.r, uiSprite19.color.g, uiSprite19.color.b, 1f);
      uiSprite21.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
      uiSprite24.color = new Color(uiSprite24.color.r, uiSprite24.color.g, uiSprite24.color.b, 1f);
    }
    if (this.Selected == 4)
    {
      this.KeyboardBG[4].color = new Color(1f, 1f, 1f, 1f);
      this.BG[4].color = new Color(1f, 1f, 1f, 1f);
    }
    else
    {
      this.KeyboardBG[4].color = this.OriginalColor;
      this.BG[4].color = this.OriginalColor;
    }
    this.Yandere.UpdateConcealedWeaponStatus();
  }

  private void DropMask()
  {
    if (!((Object) this.Yandere.Mask != (Object) null))
      return;
    this.StudentManager.CanAnyoneSeeYandere();
    if (!this.StudentManager.YandereVisible && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      this.Yandere.Mask.Drop();
      this.UpdateSprites();
      this.StudentManager.UpdateStudents();
    }
    else
    {
      this.Yandere.NotificationManager.CustomText = "Not now. Too suspicious.";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  private void DropBookbag()
  {
    if ((Object) this.Yandere.Bookbag != (Object) null)
    {
      this.Yandere.Bookbag.Drop();
      this.Yandere.UpdateConcealedWeaponStatus();
    }
    this.UpdateSprites();
  }

  public void InstantHide()
  {
    this.KeyboardMenu.localScale = Vector3.zero;
    this.transform.localScale = Vector3.zero;
  }
}
