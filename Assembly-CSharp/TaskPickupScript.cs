// Decompiled with JetBrains decompiler
// Type: TaskPickupScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TaskPickupScript : MonoBehaviour
{
  public PromptScript Prompt;
  public int TaskObjectID;
  public int ButtonID = 3;

  private void Update()
  {
    if ((double) this.Prompt.Circle[this.ButtonID].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
    if (this.TaskObjectID != 25)
      return;
    this.Prompt.Yandere.Inventory.Bra = true;
  }
}
