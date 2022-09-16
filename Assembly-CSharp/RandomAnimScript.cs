// Decompiled with JetBrains decompiler
// Type: RandomAnimScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
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
