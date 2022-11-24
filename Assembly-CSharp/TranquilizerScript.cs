// Decompiled with JetBrains decompiler
// Type: TranquilizerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TranquilizerScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    ++this.Prompt.Yandere.Inventory.SedativePoisons;
    this.Prompt.Yandere.StudentManager.UpdateAllBentos();
    this.Prompt.Yandere.TheftTimer = 0.1f;
    Object.Destroy((Object) this.gameObject);
  }
}
