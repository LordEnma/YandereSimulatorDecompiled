// Decompiled with JetBrains decompiler
// Type: TranquilizerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
