// Decompiled with JetBrains decompiler
// Type: TranquilizerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
