// Decompiled with JetBrains decompiler
// Type: BarrelScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BarrelScript : MonoBehaviour
{
  public GameObject Corpse;
  public PromptScript Prompt;
  public bool Fall;
  public int Frame;

  private void Update()
  {
    if (this.Fall)
    {
      this.Corpse.GetComponent<StudentScript>().CharacterAnimation.Stop();
      this.Corpse.GetComponent<StudentScript>().CharacterAnimation.enabled = false;
      this.Corpse.GetComponent<RagdollScript>().enabled = true;
      this.Fall = false;
      this.Frame = 0;
    }
    if (this.Prompt.Yandere.Carrying)
    {
      this.Prompt.enabled = true;
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Corpse = this.Prompt.Yandere.Ragdoll;
      this.Prompt.Yandere.EmptyHands();
      this.Corpse.transform.position = this.transform.position + Vector3.up * 2.583333f;
      this.Corpse.transform.eulerAngles = new Vector3(0.0f, 135f, 180f);
      this.Corpse.GetComponent<RagdollScript>().enabled = false;
      this.Corpse.GetComponent<StudentScript>().CharacterAnimation.enabled = true;
      this.Corpse.GetComponent<StudentScript>().CharacterAnimation.Play("f02_idleShort_00");
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Fall = true;
    }
    else
    {
      if (!this.Prompt.enabled)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }
}
