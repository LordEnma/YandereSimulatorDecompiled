// Decompiled with JetBrains decompiler
// Type: TaskPickupScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TaskPickupScript : MonoBehaviour
{
  public PromptScript Prompt;
  public int ButtonID = 3;

  private void Update()
  {
    if ((double) this.Prompt.Circle[this.ButtonID].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
    this.Prompt.Yandere.Inventory.Bra = true;
  }
}
