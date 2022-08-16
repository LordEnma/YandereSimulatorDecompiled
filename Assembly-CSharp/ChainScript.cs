// Decompiled with JetBrains decompiler
// Type: ChainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChainScript : MonoBehaviour
{
  public PromptScript Prompt;
  public TarpScript Tarp;
  public AudioClip ChainRattle;
  public GameObject[] Chains;
  public int Unlocked;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Prompt.Yandere.Inventory.MysteriousKeys <= 0)
      return;
    AudioSource.PlayClipAtPoint(this.ChainRattle, this.transform.position);
    ++this.Unlocked;
    this.Chains[this.Unlocked].SetActive(false);
    --this.Prompt.Yandere.Inventory.MysteriousKeys;
    if (this.Unlocked != 5)
      return;
    this.Tarp.Prompt.enabled = true;
    this.Tarp.enabled = true;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    Object.Destroy((Object) this.gameObject);
  }
}
