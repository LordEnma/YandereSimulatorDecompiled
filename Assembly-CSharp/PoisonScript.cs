// Decompiled with JetBrains decompiler
// Type: PoisonScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    ++this.Yandere.Inventory.LethalPoisons;
    this.Yandere.StudentManager.UpdateAllBentos();
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.transform.parent.gameObject.SetActive(false);
  }
}
