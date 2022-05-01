using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000038 RID: 56
[AddComponentMenu("NGUI/Examples/Play Idle Animations")]
public class PlayIdleAnimations : MonoBehaviour
{
	// Token: 0x060000E5 RID: 229 RVA: 0x00012C88 File Offset: 0x00010E88
	private void Start()
	{
		this.mAnim = base.GetComponentInChildren<Animation>();
		if (this.mAnim == null)
		{
			Debug.LogWarning(NGUITools.GetHierarchy(base.gameObject) + " has no Animation component");
			UnityEngine.Object.Destroy(this);
			return;
		}
		foreach (object obj in this.mAnim)
		{
			AnimationState animationState = (AnimationState)obj;
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
		if (this.mBreaks.Count == 0)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00012DA0 File Offset: 0x00010FA0
	private void Update()
	{
		if (this.mNextBreak < Time.time)
		{
			if (this.mBreaks.Count == 1)
			{
				AnimationClip animationClip = this.mBreaks[0];
				this.mNextBreak = Time.time + animationClip.length + UnityEngine.Random.Range(5f, 15f);
				this.mAnim.CrossFade(animationClip.name);
				return;
			}
			int num = UnityEngine.Random.Range(0, this.mBreaks.Count - 1);
			if (this.mLastIndex == num)
			{
				num++;
				if (num >= this.mBreaks.Count)
				{
					num = 0;
				}
			}
			this.mLastIndex = num;
			AnimationClip animationClip2 = this.mBreaks[num];
			this.mNextBreak = Time.time + animationClip2.length + UnityEngine.Random.Range(2f, 8f);
			this.mAnim.CrossFade(animationClip2.name);
		}
	}

	// Token: 0x040002B6 RID: 694
	private Animation mAnim;

	// Token: 0x040002B7 RID: 695
	private AnimationClip mIdle;

	// Token: 0x040002B8 RID: 696
	private List<AnimationClip> mBreaks = new List<AnimationClip>();

	// Token: 0x040002B9 RID: 697
	private float mNextBreak;

	// Token: 0x040002BA RID: 698
	private int mLastIndex;
}
