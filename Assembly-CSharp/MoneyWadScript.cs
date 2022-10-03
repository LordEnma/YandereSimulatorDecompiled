// Decompiled with JetBrains decompiler
// Type: MoneyWadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MoneyWadScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.Inventory.Money += 20f;
    this.Prompt.Yandere.Inventory.UpdateMoney();
    if ((double) this.Prompt.Yandere.Inventory.Money > 1000.0)
    {
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("RichGirl", 1);
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("a", 1);
    }
    Object.Destroy((Object) this.gameObject);
  }
}
