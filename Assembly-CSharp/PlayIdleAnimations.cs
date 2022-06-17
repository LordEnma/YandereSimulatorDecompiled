// Decompiled with JetBrains decompiler
// Type: PlayIdleAnimations
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Examples/Play Idle Animations")]
public class PlayIdleAnimations : MonoBehaviour
{
  private Animation mAnim;
  private AnimationClip mIdle;
  private List<AnimationClip> mBreaks = new List<AnimationClip>();
  private float mNextBreak;
  private int mLastIndex;

  private void Start()
  {
    this.mAnim = this.GetComponentInChildren<Animation>();
    if ((Object) this.mAnim == (Object) null)
    {
      Debug.LogWarning((object) (NGUITools.GetHierarchy(this.gameObject) + " has no Animation component"));
      Object.Destroy((Object) this);
    }
    else
    {
      foreach (AnimationState animationState in this.mAnim)
      {
        if (animationState.clip.name == "idle")
        {
          animationState.layer = 0;
          this.mIdle = animationState.clip;
          this.mAnim.Play(this.mIdle.name);
        }
        else if (animationState.clip.name.StartsWith("idle"))
        {
          animationState.layer = 1;
          this.mBreaks.Add(animationState.clip);
        }
      }
      if (this.mBreaks.Count != 0)
        return;
      Object.Destroy((Object) this);
    }
  }

  private void Update()
  {
    if ((double) this.mNextBreak >= (double) Time.time)
      return;
    if (this.mBreaks.Count == 1)
    {
      AnimationClip mBreak = this.mBreaks[0];
      this.mNextBreak = Time.time + mBreak.length + Random.Range(5f, 15f);
      this.mAnim.CrossFade(mBreak.name);
    }
    else
    {
      int index = Random.Range(0, this.mBreaks.Count - 1);
      if (this.mLastIndex == index)
      {
        ++index;
        if (index >= this.mBreaks.Count)
          index = 0;
      }
      this.mLastIndex = index;
      AnimationClip mBreak = this.mBreaks[index];
      this.mNextBreak = Time.time + mBreak.length + Random.Range(2f, 8f);
      this.mAnim.CrossFade(mBreak.name);
    }
  }
}
