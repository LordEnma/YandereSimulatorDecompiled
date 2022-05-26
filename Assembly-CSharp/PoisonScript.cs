// Decompiled with JetBrains decompiler
// Type: PoisonScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoisonScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public GameObject Bottle;

  public void Start()
  {
    if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
      this.gameObject.SetActive(false);
    else
      this.gameObject.SetActive(true);
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Yandere.Inventory.ChemicalPoison = true;
    ++this.Yandere.Inventory.LethalPoisons;
    this.Yandere.StudentManager.UpdateAllBentos();
    Object.Destroy((Object) this.gameObject);
    Object.Destroy((Object) this.Bottle);
  }
}
