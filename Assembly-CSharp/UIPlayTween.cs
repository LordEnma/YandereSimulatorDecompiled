﻿using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200005D RID: 93
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Play Tween")]
public class UIPlayTween : MonoBehaviour
{
	// Token: 0x0600021D RID: 541 RVA: 0x0001935D File Offset: 0x0001755D
	private void Awake()
	{
		if (this.eventReceiver != null && EventDelegate.IsValid(this.onFinished))
		{
			this.eventReceiver = null;
			this.callWhenFinished = null;
		}
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00019388 File Offset: 0x00017588
	private void Start()
	{
		this.mStarted = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000193AC File Offset: 0x000175AC
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
		if (UICamera.currentTouch != null)
		{
			if (this.trigger == Trigger.OnPress || this.trigger == Trigger.OnPressTrue)
			{
				this.mActivated = (UICamera.currentTouch.pressed == base.gameObject);
			}
			if (this.trigger == Trigger.OnHover || this.trigger == Trigger.OnHoverTrue)
			{
				this.mActivated = (UICamera.currentTouch.current == base.gameObject);
			}
		}
		UIToggle component = base.GetComponent<UIToggle>();
		if (component != null)
		{
			EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnToggle));
		}
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0001945C File Offset: 0x0001765C
	private void OnDisable()
	{
		UIToggle component = base.GetComponent<UIToggle>();
		if (component != null)
		{
			EventDelegate.Remove(component.onChange, new EventDelegate.Callback(this.OnToggle));
		}
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00019491 File Offset: 0x00017691
	private void OnDragOver()
	{
		if (this.trigger == Trigger.OnHover)
		{
			this.OnHover(true);
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x000194A4 File Offset: 0x000176A4
	private void OnHover(bool isOver)
	{
		if (base.enabled && (this.trigger == Trigger.OnHover || (this.trigger == Trigger.OnHoverTrue && isOver) || (this.trigger == Trigger.OnHoverFalse && !isOver)))
		{
			if (isOver == this.mActivated)
			{
				return;
			}
			if (!isOver && UICamera.hoveredObject != null && UICamera.hoveredObject.transform.IsChildOf(base.transform))
			{
				UICamera.onHover = (UICamera.BoolDelegate)Delegate.Combine(UICamera.onHover, new UICamera.BoolDelegate(this.CustomHoverListener));
				isOver = true;
				if (this.mActivated)
				{
					return;
				}
			}
			this.mActivated = (isOver && this.trigger == Trigger.OnHover);
			this.Play(isOver);
		}
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00019558 File Offset: 0x00017758
	private void CustomHoverListener(GameObject go, bool isOver)
	{
		if (!this)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if (!gameObject || !go || (!(go == gameObject) && !go.transform.IsChildOf(base.transform)))
		{
			this.OnHover(false);
			UICamera.onHover = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onHover, new UICamera.BoolDelegate(this.CustomHoverListener));
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x000195CE File Offset: 0x000177CE
	private void OnDragOut()
	{
		if (base.enabled && this.mActivated)
		{
			this.mActivated = false;
			this.Play(false);
		}
	}

	// Token: 0x06000225 RID: 549 RVA: 0x000195F0 File Offset: 0x000177F0
	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == Trigger.OnPress || (this.trigger == Trigger.OnPressTrue && isPressed) || (this.trigger == Trigger.OnPressFalse && !isPressed)))
		{
			this.mActivated = (isPressed && this.trigger == Trigger.OnPress);
			this.Play(isPressed);
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00019643 File Offset: 0x00017843
	private void OnClick()
	{
		if (base.enabled && this.trigger == Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0001965C File Offset: 0x0001785C
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00019678 File Offset: 0x00017878
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == Trigger.OnSelect || (this.trigger == Trigger.OnSelectTrue && isSelected) || (this.trigger == Trigger.OnSelectFalse && !isSelected)))
		{
			this.mActivated = (isSelected && this.trigger == Trigger.OnSelect);
			this.Play(isSelected);
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x000196D0 File Offset: 0x000178D0
	private void OnToggle()
	{
		if (!base.enabled || UIToggle.current == null)
		{
			return;
		}
		if (this.trigger == Trigger.OnActivate || (this.trigger == Trigger.OnActivateTrue && UIToggle.current.value) || (this.trigger == Trigger.OnActivateFalse && !UIToggle.current.value))
		{
			this.Play(UIToggle.current.value);
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00019738 File Offset: 0x00017938
	private void Update()
	{
		if (this.disableWhenFinished != DisableCondition.DoNotDisable && this.mTweens != null)
		{
			bool flag = true;
			bool flag2 = true;
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				UITweener uitweener = this.mTweens[i];
				if (uitweener.tweenGroup == this.tweenGroup)
				{
					if (uitweener.enabled)
					{
						flag = false;
						break;
					}
					if (uitweener.direction != (AnimationOrTween.Direction)this.disableWhenFinished)
					{
						flag2 = false;
					}
				}
				i++;
			}
			if (flag)
			{
				if (flag2)
				{
					NGUITools.SetActive(this.tweenTarget, false);
				}
				this.mTweens = null;
			}
		}
	}

	// Token: 0x0600022B RID: 555 RVA: 0x000197BE File Offset: 0x000179BE
	public void Play()
	{
		this.Play(true);
	}

	// Token: 0x0600022C RID: 556 RVA: 0x000197C8 File Offset: 0x000179C8
	public void Play(bool forward)
	{
		this.mActive = 0;
		GameObject gameObject = (this.tweenTarget == null) ? base.gameObject : this.tweenTarget;
		if (!NGUITools.GetActive(gameObject))
		{
			if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
			{
				return;
			}
			NGUITools.SetActive(gameObject, true);
		}
		this.mTweens = (this.includeChildren ? gameObject.GetComponentsInChildren<UITweener>() : gameObject.GetComponents<UITweener>());
		if (this.mTweens.Length == 0)
		{
			if (this.disableWhenFinished != DisableCondition.DoNotDisable)
			{
				NGUITools.SetActive(this.tweenTarget, false);
				return;
			}
		}
		else
		{
			bool flag = false;
			if (this.playDirection == AnimationOrTween.Direction.Reverse)
			{
				forward = !forward;
			}
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				UITweener uitweener = this.mTweens[i];
				if (uitweener.tweenGroup == this.tweenGroup)
				{
					if (!flag && !NGUITools.GetActive(gameObject))
					{
						flag = true;
						NGUITools.SetActive(gameObject, true);
					}
					this.mActive++;
					if (this.playDirection == AnimationOrTween.Direction.Toggle)
					{
						EventDelegate.Add(uitweener.onFinished, new EventDelegate.Callback(this.OnFinished), true);
						uitweener.Toggle();
					}
					else
					{
						if (this.resetOnPlay || (this.resetIfDisabled && !uitweener.enabled))
						{
							uitweener.Play(forward);
							uitweener.ResetToBeginning();
						}
						EventDelegate.Add(uitweener.onFinished, new EventDelegate.Callback(this.OnFinished), true);
						uitweener.Play(forward);
					}
				}
				i++;
			}
		}
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00019930 File Offset: 0x00017B30
	private void OnFinished()
	{
		int num = this.mActive - 1;
		this.mActive = num;
		if (num == 0 && UIPlayTween.current == null)
		{
			UIPlayTween.current = this;
			EventDelegate.Execute(this.onFinished);
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				this.eventReceiver.SendMessage(this.callWhenFinished, SendMessageOptions.DontRequireReceiver);
			}
			this.eventReceiver = null;
			UIPlayTween.current = null;
		}
	}

	// Token: 0x040003C5 RID: 965
	public static UIPlayTween current;

	// Token: 0x040003C6 RID: 966
	public GameObject tweenTarget;

	// Token: 0x040003C7 RID: 967
	public int tweenGroup;

	// Token: 0x040003C8 RID: 968
	public Trigger trigger;

	// Token: 0x040003C9 RID: 969
	public AnimationOrTween.Direction playDirection = AnimationOrTween.Direction.Forward;

	// Token: 0x040003CA RID: 970
	public bool resetOnPlay;

	// Token: 0x040003CB RID: 971
	public bool resetIfDisabled;

	// Token: 0x040003CC RID: 972
	public EnableCondition ifDisabledOnPlay;

	// Token: 0x040003CD RID: 973
	public DisableCondition disableWhenFinished;

	// Token: 0x040003CE RID: 974
	public bool includeChildren;

	// Token: 0x040003CF RID: 975
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x040003D0 RID: 976
	[HideInInspector]
	[SerializeField]
	private GameObject eventReceiver;

	// Token: 0x040003D1 RID: 977
	[HideInInspector]
	[SerializeField]
	private string callWhenFinished;

	// Token: 0x040003D2 RID: 978
	private UITweener[] mTweens;

	// Token: 0x040003D3 RID: 979
	private bool mStarted;

	// Token: 0x040003D4 RID: 980
	private int mActive;

	// Token: 0x040003D5 RID: 981
	private bool mActivated;
}
