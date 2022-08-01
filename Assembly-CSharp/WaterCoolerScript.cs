// Decompiled with JetBrains decompiler
// Type: WaterCoolerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
  public Renderer CylinderRenderer;
  public GameObject TripwireTrap;
  public Rigidbody MyRigidbody;
  public Transform Cylinder;
  public bool BrownPaint;
  public bool Gasoline;
  public bool Water;
  public bool Blood;
  public bool TrapSet;
  public bool Empty;
  public float Timer;
  public Color[] OriginalColor;

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
    else if (!this.TrapSet)
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
          this.Yandere.SuspiciousActionTimer = 1f;
          this.SetTrap();
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
