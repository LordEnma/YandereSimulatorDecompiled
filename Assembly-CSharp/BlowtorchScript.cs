// Decompiled with JetBrains decompiler
// Type: BlowtorchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BlowtorchScript : MonoBehaviour
{
  public YandereScript Yandere;
  public RagdollScript Corpse;
  public PickUpScript PickUp;
  public PromptScript Prompt;
  public Transform Flame;
  public float Timer;

  private void Start()
  {
    this.Flame.localScale = Vector3.zero;
    this.enabled = false;
  }

  private void Update()
  {
    this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
    float num = Random.Range(0.9f, 1f);
    this.Flame.localScale = new Vector3(num, num, num);
    if ((double) this.Timer != 5.0 || this.Yandere.Chased || this.Yandere.Sprayed)
      return;
    this.Flame.localScale = Vector3.zero;
    this.Yandere.Cauterizing = false;
    this.Yandere.CanMove = true;
    this.enabled = false;
    this.GetComponent<AudioSource>().Stop();
    this.Timer = 0.0f;
  }
}
