// Decompiled with JetBrains decompiler
// Type: RandomAnimScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RandomAnimScript : MonoBehaviour
{
  public string[] AnimationNames;
  public string CurrentAnim = string.Empty;

  private void Start()
  {
    this.PickRandomAnim();
    this.GetComponent<Animation>().CrossFade(this.CurrentAnim);
  }

  private void Update()
  {
    AnimationState animationState = this.GetComponent<Animation>()[this.CurrentAnim];
    if ((double) animationState.time < (double) animationState.length)
      return;
    this.PickRandomAnim();
  }

  private void PickRandomAnim()
  {
    this.CurrentAnim = this.AnimationNames[Random.Range(0, this.AnimationNames.Length)];
    this.GetComponent<Animation>().CrossFade(this.CurrentAnim);
  }
}
