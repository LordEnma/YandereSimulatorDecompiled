// Decompiled with JetBrains decompiler
// Type: WaterCoolerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WaterCoolerScript : MonoBehaviour
{
  public StringTrapScript Tripwire;
  public YandereScript Yandere;
  public PickUpScript PickUp;
  public PromptScript Prompt;
  public UIPanel WaterCoolerChecklist;
  public UISprite LiquidCheckmark;
  public UISprite WeaponCheckmark;
  public UISprite ThreadCheckmark;
  public UISprite TapeCheckmark;
  public Transform StringTrapParent;
  public Transform Cylinder;
  public Renderer CylinderRenderer;
  public GameObject TripwireTrap;
  public Rigidbody MyRigidbody;
  public bool BrownPaint;
  public bool Gasoline;
  public bool Water;
  public bool Blood;
  public bool TrapSet;
  public bool Empty;
  public float Timer;
  public Color[] OriginalColor;
  public bool TooCloseToWall;

  private void Start()
  {
    this.Cylinder.localScale = new Vector3(1f, 0.0f, 1f);
    this.TripwireTrap.SetActive(false);
    this.Prompt.HideButton[1] = true;
    this.OriginalColor[0] = this.Prompt.Label[1].gradientTop;
    this.OriginalColor[1] = this.Prompt.Label[1].gradientBottom;
  }

  private void Update()
  {
    if (this.Empty)
    {
      if ((Object) this.Yandere.PickUp != (Object) null)
      {
        if ((Object) this.Yandere.PickUp.Bucket != (Object) null && this.Yandere.PickUp.Bucket.Full || this.Yandere.PickUp.BrownPaint || this.Yandere.PickUp.JerryCan)
        {
          this.Prompt.HideButton[0] = false;
          if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
          {
            if ((Object) this.Yandere.PickUp.Bucket == (Object) null)
            {
              this.BrownPaint = this.Yandere.PickUp.BrownPaint;
              this.Gasoline = this.Yandere.PickUp.JerryCan;
              this.UpdateCylinderColor();
            }
            else
            {
              if (this.Yandere.PickUp.Bucket.DyedBrown)
                this.BrownPaint = true;
              else if ((double) this.Yandere.PickUp.Bucket.Bloodiness > 50.0)
                this.Blood = true;
              else if (this.Yandere.PickUp.Bucket.Gasoline)
                this.Gasoline = true;
              else
                this.Water = true;
              this.UpdateCylinderColor();
              this.Yandere.PickUp.Bucket.Empty();
            }
            this.Empty = false;
            this.Timer = 1f;
            this.Prompt.HideButton[0] = true;
          }
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else
        this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[1] = true;
    }
    else
    {
      if (!this.TrapSet)
      {
        bool flag = false;
        if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife || (Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].Type == WeaponType.Knife || (Object) this.Yandere.Weapon[2] != (Object) null && this.Yandere.Weapon[2].Type == WeaponType.Knife)
          flag = true;
        if (((!this.Yandere.Inventory.String ? 0 : (this.Yandere.Inventory.MaskingTape ? 1 : 0)) & (flag ? 1 : 0)) != 0)
        {
          this.Prompt.HideButton[1] = false;
          this.Prompt.Label[1].applyGradient = false;
          this.Prompt.Label[1].color = Color.red;
          if (SchemeGlobals.GetSchemeStage(1) == 2 || SchemeGlobals.GetSchemeStage(2) == 2)
          {
            SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
            this.Yandere.PauseScreen.Schemes.UpdateInstructions();
          }
          if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
          {
            this.Prompt.Circle[1].fillAmount = 1f;
            if ((double) this.transform.position.y < 0.10000000149011612 || (double) this.transform.position.y > 3.9000000953674316 && (double) this.transform.position.y < 4.0999999046325684 || (double) this.transform.position.y > 7.9000000953674316 && (double) this.transform.position.y < 8.1000003814697266 || (double) this.transform.position.y > 11.899999618530273 && (double) this.transform.position.y < 12.100000381469727)
            {
              this.CheckForWallInFront();
              if (this.TooCloseToWall)
              {
                this.Yandere.NotificationManager.CustomText = "Too close to wall!";
                this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
              }
              else
              {
                this.Yandere.SuspiciousActionTimer = 1f;
                this.Yandere.CreatingTripwireTrap = true;
                this.SetTrap();
              }
            }
            else
            {
              this.Yandere.NotificationManager.CustomText = "Set it on the ground!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
        }
        else
        {
          this.Prompt.HideButton[1] = true;
          this.Prompt.Label[1].applyGradient = true;
          this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
          this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
        }
      }
      else if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      {
        this.Prompt.Circle[1].fillAmount = 1f;
        this.Prompt.Label[1].text = "     Create Tripwire Trap";
        this.Prompt.Label[1].applyGradient = false;
        this.Prompt.Label[1].color = Color.red;
        this.TripwireTrap.SetActive(false);
        this.TrapSet = false;
        this.Prompt.HideButton[3] = false;
        this.PickUp.enabled = true;
        this.MyRigidbody.isKinematic = false;
      }
      if (this.Yandere.YandereVision && !this.Empty)
        this.UpdateCylinderColor();
    }
    if ((double) this.Timer > 0.0)
    {
      this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
      this.Cylinder.localScale = !this.Empty ? Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f) : Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 0.0f, 1f), Time.deltaTime * 10f);
    }
    if (this.Prompt.enabled && (double) this.Prompt.DistanceSqr < 1.0 || !this.Prompt.enabled && (double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
    {
      if ((double) this.WaterCoolerChecklist.alpha < 1.0)
      {
        this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 1f, Time.deltaTime * 10f);
        if (SchemeGlobals.GetSchemeStage(1) == 1 || SchemeGlobals.GetSchemeStage(2) == 1)
        {
          SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
          this.Yandere.PauseScreen.Schemes.UpdateInstructions();
        }
      }
      bool flag = false;
      if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife || (Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].Type == WeaponType.Knife || (Object) this.Yandere.Weapon[2] != (Object) null && this.Yandere.Weapon[2].Type == WeaponType.Knife)
        flag = true;
      this.WeaponCheckmark.spriteName = flag ? "Yes" : "No";
      this.TapeCheckmark.spriteName = this.Yandere.Inventory.MaskingTape ? "Yes" : "No";
      this.ThreadCheckmark.spriteName = this.Yandere.Inventory.String ? "Yes" : "No";
      this.LiquidCheckmark.spriteName = !this.Empty ? "Yes" : "No";
    }
    else
    {
      if ((double) this.WaterCoolerChecklist.alpha <= 0.0)
        return;
      this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 0.0f, Time.deltaTime * 10f);
    }
  }

  public void UpdateCylinderColor()
  {
    if (this.BrownPaint)
      this.CylinderRenderer.material.color = new Color(0.5f, 0.25f, 0.0f, 1f);
    else if (this.Blood)
      this.CylinderRenderer.material.color = new Color(1f, 0.0f, 0.0f, 1f);
    else if (this.Gasoline)
      this.CylinderRenderer.material.color = new Color(1f, 1f, 0.0f, 1f);
    else
      this.CylinderRenderer.material.color = new Color(0.0f, 1f, 1f, 1f);
  }

  private void CheckForWallInFront()
  {
    this.StringTrapParent.localScale = new Vector3(1f, 1f, 1f);
    this.TooCloseToWall = false;
    Debug.Log((object) "Checking for a wall in front of this object.");
    Transform transform = this.transform;
    Vector3 vector3 = this.transform.TransformDirection(this.transform.worldToLocalMatrix.MultiplyVector(this.transform.forward));
    Debug.DrawRay(transform.position + Vector3.up, vector3, Color.red);
    RaycastHit hitInfo;
    if (!Physics.Raycast(transform.position + Vector3.up, vector3, out hitInfo, float.PositiveInfinity, this.Yandere.StudentManager.Students[1].OnlyDefault))
      return;
    float num = Vector3.Distance(transform.position + Vector3.up, hitInfo.point);
    Debug.Log((object) ("There is a wall " + num.ToString() + " meters away."));
    if ((double) num > 3.5)
      this.StringTrapParent.localScale = new Vector3(1f, 1f, 1f);
    else if ((double) num > 2.5)
      this.StringTrapParent.localScale = new Vector3(1f, 1f, 0.75f);
    else if ((double) num > 1.5)
      this.StringTrapParent.localScale = new Vector3(1f, 1f, 0.5f);
    else if ((double) num > 0.5)
      this.StringTrapParent.localScale = new Vector3(1f, 1f, 0.25f);
    else
      this.TooCloseToWall = true;
  }

  public void SetTrap()
  {
    this.Prompt.Label[1].text = "     Remove Trap";
    this.Prompt.Label[1].applyGradient = true;
    this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
    this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
    this.Prompt.Label[1].color = Color.white;
    this.TripwireTrap.SetActive(true);
    this.TrapSet = true;
    this.Prompt.HideButton[1] = false;
    this.Prompt.HideButton[3] = true;
    this.PickUp.enabled = false;
    this.MyRigidbody.isKinematic = true;
  }
}
