// Decompiled with JetBrains decompiler
// Type: SabotageVendingMachineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SabotageVendingMachineScript : MonoBehaviour
{
  public VendingMachineScript VendingMachine;
  public GameObject SabotageSparks;
  public YandereScript Yandere;
  public PromptScript Prompt;

  private void Start()
  {
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  private void Update()
  {
    if (this.Yandere.Armed)
    {
      if (this.Yandere.EquippedWeapon.WeaponID != 6)
        return;
      this.Prompt.enabled = true;
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      if (SchemeGlobals.GetSchemeStage(4) == 2)
      {
        SchemeGlobals.SetSchemeStage(4, 3);
        this.Yandere.PauseScreen.Schemes.UpdateInstructions();
      }
      if ((UnityEngine.Object) this.Yandere.StudentManager.Students[11] != (UnityEngine.Object) null && DateGlobals.Weekday == DayOfWeek.Thursday)
      {
        this.Yandere.StudentManager.Students[11].Hungry = true;
        this.Yandere.StudentManager.Students[11].Fed = false;
      }
      UnityEngine.Object.Instantiate<GameObject>(this.SabotageSparks, new Vector3(-2.5f, 5.3605f, -32.982f), Quaternion.identity);
      this.VendingMachine.Sabotaged = true;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.enabled = false;
    }
    else
    {
      if (!this.Prompt.enabled)
        return;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
  }
}
