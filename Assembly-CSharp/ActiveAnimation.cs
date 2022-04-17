using System;
using System.Collections;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200006C RID: 108
[AddComponentMenu("NGUI/Internal/Active Animation")]
public class ActiveAnimation : MonoBehaviour
{
	// Token: 0x17000046 RID: 70
	// (get) Token: 0x060002ED RID: 749 RVA: 0x0001F820 File Offset: 0x0001DA20
	private float playbackTime
	{
		get
		{
			return Mathf.Clamp01(this.mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
		}
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x060002EE RID: 750 RVA: 0x0001F848 File Offset: 0x0001DA48
	public bool isPlaying
	{
		get
		{
			if (!(this.mAnim == null))
			{
				foreach (object obj in this.mAnim)
				{
					AnimationState animationState = (AnimationState)obj;
					if (this.mAnim.IsPlaying(animationState.name))
					{
						if (this.mLastDirection == AnimationOrTween.Direction.Forward)
						{
							if (animationState.time < animationState.length)
							{
								return true;
							}
						}
						else
						{
							if (this.mLastDirection != AnimationOrTween.Direction.Reverse)
							{
								return true;
							}
							if (animationState.time > 0f)
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			if (this.mAnimator != null)
			{
				if (this.mLastDirection == AnimationOrTween.Direction.Reverse)
				{
					if (this.playbackTime == 0f)
					{
						return false;
					}
				}
				else if (this.playbackTime == 1f)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0001F930 File Offset: 0x0001DB30
	public void Finish()
	{
		if (this.mAnim != null)
		{
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (this.mLastDirection == AnimationOrTween.Direction.Forward)
				{
					animationState.time = animationState.length;
				}
				else if (this.mLastDirection == AnimationOrTween.Direction.Reverse)
				{
					animationState.time = 0f;
				}
			}
			this.mAnim.Sample();
			return;
		}
		if (this.mAnimator != null)
		{
			this.mAnimator.Play(this.mClip, 0, (this.mLastDirection == AnimationOrTween.Direction.Forward) ? 1f : 0f);
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0001F9FC File Offset: 0x0001DBFC
	public void Reset()
	{
		if (this.mAnim != null)
		{
			using (IEnumerator enumerator = this.mAnim.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					AnimationState animationState = (AnimationState)obj;
					if (this.mLastDirection == AnimationOrTween.Direction.Reverse)
					{
						animationState.time = animationState.length;
					}
					else if (this.mLastDirection == AnimationOrTween.Direction.Forward)
					{
						animationState.time = 0f;
					}
				}
				return;
			}
		}
		if (this.mAnimator != null)
		{
			this.mAnimator.Play(this.mClip, 0, (this.mLastDirection == AnimationOrTween.Direction.Reverse) ? 1f : 0f);
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0001FABC File Offset: 0x0001DCBC
	private void Start()
	{
		if (this.eventReceiver != null && EventDelegate.IsValid(this.onFinished))
		{
			this.eventReceiver = null;
			this.callWhenFinished = null;
		}
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0001FAE8 File Offset: 0x0001DCE8
	private void Update()
	{
		float deltaTime = RealTime.deltaTime;
		if (deltaTime == 0f)
		{
			return;
		}
		if (this.mAnimator != null)
		{
			this.mAnimator.Update((this.mLastDirection == AnimationOrTween.Direction.Reverse) ? (-deltaTime) : deltaTime);
			if (this.isPlaying)
			{
				return;
			}
			this.mAnimator.enabled = false;
			base.enabled = false;
		}
		else
		{
			if (!(this.mAnim != null))
			{
				base.enabled = false;
				return;
			}
			bool flag = false;
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (this.mAnim.IsPlaying(animationState.name))
				{
					float num = animationState.speed * deltaTime;
					animationState.time += num;
					if (num < 0f)
					{
						if (animationState.time > 0f)
						{
							flag = true;
						}
						else
						{
							animationState.time = 0f;
						}
					}
					else if (animationState.time < animationState.length)
					{
						flag = true;
					}
					else
					{
						animationState.time = animationState.length;
					}
				}
			}
			this.mAnim.Sample();
			if (flag)
			{
				return;
			}
			base.enabled = false;
		}
		if (this.mNotify)
		{
			this.mNotify = false;
			if (ActiveAnimation.current == null)
			{
				ActiveAnimation.current = this;
				EventDelegate.Execute(this.onFinished);
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, SendMessageOptions.DontRequireReceiver);
				}
				ActiveAnimation.current = null;
			}
			if (this.mDisableDirection != AnimationOrTween.Direction.Toggle && this.mLastDirection == this.mDisableDirection)
			{
				NGUITools.SetActive(base.gameObject, false);
			}
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0001FCC0 File Offset: 0x0001DEC0
	private void Play(string clipName, AnimationOrTween.Direction playDirection)
	{
		if (playDirection == AnimationOrTween.Direction.Toggle)
		{
			playDirection = ((this.mLastDirection != AnimationOrTween.Direction.Forward) ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse);
		}
		if (this.mAnim != null)
		{
			base.enabled = true;
			this.mAnim.enabled = false;
			if (string.IsNullOrEmpty(clipName))
			{
				if (!this.mAnim.isPlaying)
				{
					this.mAnim.Play();
				}
			}
			else if (!this.mAnim.IsPlaying(clipName))
			{
				this.mAnim.Play(clipName);
			}
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (string.IsNullOrEmpty(clipName) || animationState.name == clipName)
				{
					float num = Mathf.Abs(animationState.speed);
					animationState.speed = num * (float)playDirection;
					if (playDirection == AnimationOrTween.Direction.Reverse && animationState.time == 0f)
					{
						animationState.time = animationState.length;
					}
					else if (playDirection == AnimationOrTween.Direction.Forward && animationState.time == animationState.length)
					{
						animationState.time = 0f;
					}
				}
			}
			this.mLastDirection = playDirection;
			this.mNotify = true;
			this.mAnim.Sample();
			return;
		}
		if (this.mAnimator != null)
		{
			if (base.enabled && this.isPlaying && this.mClip == clipName)
			{
				this.mLastDirection = playDirection;
				return;
			}
			base.enabled = true;
			this.mNotify = true;
			this.mLastDirection = playDirection;
			this.mClip = clipName;
			this.mAnimator.Play(this.mClip, 0, (playDirection == AnimationOrTween.Direction.Forward) ? 0f : 1f);
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0001FE7C File Offset: 0x0001E07C
	public static ActiveAnimation Play(Animation anim, string clipName, AnimationOrTween.Direction playDirection, EnableCondition enableBeforePlay, DisableCondition disableCondition)
	{
		if (!NGUITools.GetActive(anim.gameObject))
		{
			if (enableBeforePlay != EnableCondition.EnableThenPlay)
			{
				return null;
			}
			NGUITools.SetActive(anim.gameObject, true);
			UIPanel[] componentsInChildren = anim.gameObject.GetComponentsInChildren<UIPanel>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].Refresh();
				i++;
			}
		}
		ActiveAnimation activeAnimation = anim.GetComponent<ActiveAnimation>();
		if (activeAnimation == null)
		{
			activeAnimation = anim.gameObject.AddComponent<ActiveAnimation>();
		}
		activeAnimation.mAnim = anim;
		activeAnimation.mDisableDirection = (AnimationOrTween.Direction)disableCondition;
		activeAnimation.onFinished.Clear();
		activeAnimation.Play(clipName, playDirection);
		if (activeAnimation.mAnim != null)
		{
			activeAnimation.mAnim.Sample();
		}
		else if (activeAnimation.mAnimator != null)
		{
			activeAnimation.mAnimator.Update(0f);
		}
		return activeAnimation;
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0001FF44 File Offset: 0x0001E144
	public static ActiveAnimation Play(Animation anim, string clipName, AnimationOrTween.Direction playDirection)
	{
		return ActiveAnimation.Play(anim, clipName, playDirection, EnableCondition.DoNothing, DisableCondition.DoNotDisable);
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0001FF50 File Offset: 0x0001E150
	public static ActiveAnimation Play(Animation anim, AnimationOrTween.Direction playDirection)
	{
		return ActiveAnimation.Play(anim, null, playDirection, EnableCondition.DoNothing, DisableCondition.DoNotDisable);
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0001FF5C File Offset: 0x0001E15C
	public static ActiveAnimation Play(Animator anim, string clipName, AnimationOrTween.Direction playDirection, EnableCondition enableBeforePlay, DisableCondition disableCondition)
	{
		if (enableBeforePlay != EnableCondition.IgnoreDisabledState && !NGUITools.GetActive(anim.gameObject))
		{
			if (enableBeforePlay != EnableCondition.EnableThenPlay)
			{
				return null;
			}
			NGUITools.SetActive(anim.gameObject, true);
			UIPanel[] componentsInChildren = anim.gameObject.GetComponentsInChildren<UIPanel>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].Refresh();
				i++;
			}
		}
		ActiveAnimation activeAnimation = anim.GetComponent<ActiveAnimation>();
		if (activeAnimation == null)
		{
			activeAnimation = anim.gameObject.AddComponent<ActiveAnimation>();
		}
		activeAnimation.mAnimator = anim;
		activeAnimation.mDisableDirection = (AnimationOrTween.Direction)disableCondition;
		activeAnimation.onFinished.Clear();
		activeAnimation.Play(clipName, playDirection);
		if (activeAnimation.mAnim != null)
		{
			activeAnimation.mAnim.Sample();
		}
		else if (activeAnimation.mAnimator != null)
		{
			activeAnimation.mAnimator.Update(0f);
		}
		return activeAnimation;
	}

	// Token: 0x0400047E RID: 1150
	public static ActiveAnimation current;

	// Token: 0x0400047F RID: 1151
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x04000480 RID: 1152
	[HideInInspector]
	public GameObject eventReceiver;

	// Token: 0x04000481 RID: 1153
	[HideInInspector]
	public string callWhenFinished;

	// Token: 0x04000482 RID: 1154
	private Animation mAnim;

	// Token: 0x04000483 RID: 1155
	private AnimationOrTween.Direction mLastDirection;

	// Token: 0x04000484 RID: 1156
	private AnimationOrTween.Direction mDisableDirection;

	// Token: 0x04000485 RID: 1157
	private bool mNotify;

	// Token: 0x04000486 RID: 1158
	private Animator mAnimator;

	// Token: 0x04000487 RID: 1159
	private string mClip = "";
}
