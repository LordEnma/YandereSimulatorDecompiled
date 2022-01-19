using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200005B RID: 91
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Play Animation")]
public class UIPlayAnimation : MonoBehaviour
{
	// Token: 0x1700001C RID: 28
	// (get) Token: 0x060001FF RID: 511 RVA: 0x000188C5 File Offset: 0x00016AC5
	private bool dualState
	{
		get
		{
			return this.trigger == Trigger.OnPress || this.trigger == Trigger.OnHover;
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x000188DC File Offset: 0x00016ADC
	private void Awake()
	{
		UIButton component = base.GetComponent<UIButton>();
		if (component != null)
		{
			this.dragHighlight = component.dragHighlight;
		}
		if (this.eventReceiver != null && EventDelegate.IsValid(this.onFinished))
		{
			this.eventReceiver = null;
			this.callWhenFinished = null;
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00018930 File Offset: 0x00016B30
	private void Start()
	{
		this.mStarted = true;
		if (this.target == null && this.animator == null)
		{
			this.animator = base.GetComponentInChildren<Animator>();
		}
		if (this.animator != null)
		{
			if (this.animator.enabled)
			{
				this.animator.enabled = false;
			}
			return;
		}
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<Animation>();
		}
		if (this.target != null && this.target.enabled)
		{
			this.target.enabled = false;
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x000189D8 File Offset: 0x00016BD8
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

	// Token: 0x06000203 RID: 515 RVA: 0x00018A88 File Offset: 0x00016C88
	private void OnDisable()
	{
		UIToggle component = base.GetComponent<UIToggle>();
		if (component != null)
		{
			EventDelegate.Remove(component.onChange, new EventDelegate.Callback(this.OnToggle));
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00018ABD File Offset: 0x00016CBD
	private void OnHover(bool isOver)
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.trigger == Trigger.OnHover || (this.trigger == Trigger.OnHoverTrue && isOver) || (this.trigger == Trigger.OnHoverFalse && !isOver))
		{
			this.Play(isOver, this.dualState);
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x00018AF8 File Offset: 0x00016CF8
	private void OnPress(bool isPressed)
	{
		if (!base.enabled)
		{
			return;
		}
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		if (this.trigger == Trigger.OnPress || (this.trigger == Trigger.OnPressTrue && isPressed) || (this.trigger == Trigger.OnPressFalse && !isPressed))
		{
			this.Play(isPressed, this.dualState);
		}
	}

	// Token: 0x06000206 RID: 518 RVA: 0x00018B50 File Offset: 0x00016D50
	private void OnClick()
	{
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		if (base.enabled && this.trigger == Trigger.OnClick)
		{
			this.Play(true, false);
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00018B7D File Offset: 0x00016D7D
	private void OnDoubleClick()
	{
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		if (base.enabled && this.trigger == Trigger.OnDoubleClick)
		{
			this.Play(true, false);
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00018BAC File Offset: 0x00016DAC
	private void OnSelect(bool isSelected)
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.trigger == Trigger.OnSelect || (this.trigger == Trigger.OnSelectTrue && isSelected) || (this.trigger == Trigger.OnSelectFalse && !isSelected))
		{
			this.Play(isSelected, this.dualState);
		}
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00018BEC File Offset: 0x00016DEC
	private void OnToggle()
	{
		if (!base.enabled || UIToggle.current == null)
		{
			return;
		}
		if (this.trigger == Trigger.OnActivate || (this.trigger == Trigger.OnActivateTrue && UIToggle.current.value) || (this.trigger == Trigger.OnActivateFalse && !UIToggle.current.value))
		{
			this.Play(UIToggle.current.value, this.dualState);
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00018C5C File Offset: 0x00016E5C
	private void OnDragOver()
	{
		if (base.enabled && this.dualState)
		{
			if (UICamera.currentTouch.dragged == base.gameObject)
			{
				this.Play(true, true);
				return;
			}
			if (this.dragHighlight && this.trigger == Trigger.OnPress)
			{
				this.Play(true, true);
			}
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00018CB2 File Offset: 0x00016EB2
	private void OnDragOut()
	{
		if (base.enabled && this.dualState && UICamera.hoveredObject != base.gameObject)
		{
			this.Play(false, true);
		}
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00018CDE File Offset: 0x00016EDE
	private void OnDrop(GameObject go)
	{
		if (base.enabled && this.trigger == Trigger.OnPress && UICamera.currentTouch.dragged != base.gameObject)
		{
			this.Play(false, true);
		}
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00018D10 File Offset: 0x00016F10
	public void Play(bool forward)
	{
		this.Play(forward, true);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00018D1C File Offset: 0x00016F1C
	public void Play(bool forward, bool onlyIfDifferent)
	{
		if (this.target || this.animator)
		{
			if (onlyIfDifferent)
			{
				if (this.mActivated == forward)
				{
					return;
				}
				this.mActivated = forward;
			}
			if (this.clearSelection && UICamera.selectedObject == base.gameObject)
			{
				UICamera.selectedObject = null;
			}
			int num = (int)(-(int)this.playDirection);
			AnimationOrTween.Direction direction = forward ? this.playDirection : ((AnimationOrTween.Direction)num);
			ActiveAnimation activeAnimation = this.target ? ActiveAnimation.Play(this.target, this.clipName, direction, this.ifDisabledOnPlay, this.disableWhenFinished) : ActiveAnimation.Play(this.animator, this.clipName, direction, this.ifDisabledOnPlay, this.disableWhenFinished);
			if (activeAnimation != null)
			{
				if (this.resetOnPlay)
				{
					activeAnimation.Reset();
				}
				for (int i = 0; i < this.onFinished.Count; i++)
				{
					EventDelegate.Add(activeAnimation.onFinished, new EventDelegate.Callback(this.OnFinished), true);
				}
			}
		}
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00018E21 File Offset: 0x00017021
	public void PlayForward()
	{
		this.Play(true);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00018E2A File Offset: 0x0001702A
	public void PlayReverse()
	{
		this.Play(false);
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00018E34 File Offset: 0x00017034
	private void OnFinished()
	{
		if (UIPlayAnimation.current == null)
		{
			UIPlayAnimation.current = this;
			EventDelegate.Execute(this.onFinished);
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				this.eventReceiver.SendMessage(this.callWhenFinished, SendMessageOptions.DontRequireReceiver);
			}
			this.eventReceiver = null;
			UIPlayAnimation.current = null;
		}
	}

	// Token: 0x040003A4 RID: 932
	public static UIPlayAnimation current;

	// Token: 0x040003A5 RID: 933
	public Animation target;

	// Token: 0x040003A6 RID: 934
	public Animator animator;

	// Token: 0x040003A7 RID: 935
	public string clipName;

	// Token: 0x040003A8 RID: 936
	public Trigger trigger;

	// Token: 0x040003A9 RID: 937
	public AnimationOrTween.Direction playDirection = AnimationOrTween.Direction.Forward;

	// Token: 0x040003AA RID: 938
	public bool resetOnPlay;

	// Token: 0x040003AB RID: 939
	public bool clearSelection;

	// Token: 0x040003AC RID: 940
	public EnableCondition ifDisabledOnPlay;

	// Token: 0x040003AD RID: 941
	public DisableCondition disableWhenFinished;

	// Token: 0x040003AE RID: 942
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x040003AF RID: 943
	[HideInInspector]
	[SerializeField]
	private GameObject eventReceiver;

	// Token: 0x040003B0 RID: 944
	[HideInInspector]
	[SerializeField]
	private string callWhenFinished;

	// Token: 0x040003B1 RID: 945
	private bool mStarted;

	// Token: 0x040003B2 RID: 946
	private bool mActivated;

	// Token: 0x040003B3 RID: 947
	private bool dragHighlight;
}
