// Decompiled with JetBrains decompiler
// Type: ShoePairScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ShoePairScript : MonoBehaviour
{
  public PoliceScript Police;
  public PromptScript Prompt;
  public GameObject Note;

  private void Start()
  {
    this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
    this.Note.SetActive(false);
  }

  private void Update()
  {
    if (this.Prompt.Yandere.Class.LanguageGrade + this.Prompt.Yandere.Class.LanguageBonus < 1)
      this.Prompt.enabled = false;
    else
      this.Prompt.enabled = true;
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Police.SuicideNote = true;
    this.Note.SetActive(true);
    this.enabled = false;
  }
}
