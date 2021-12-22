using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000067 RID: 103
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Toggle")]
public class UIToggle : UIWidgetContainer
{
	// Token: 0x17000043 RID: 67
	// (get) Token: 0x060002CE RID: 718 RVA: 0x0001E698 File Offset: 0x0001C898
	// (set) Token: 0x060002CF RID: 719 RVA: 0x0001E6AF File Offset: 0x0001C8AF
	public bool value
	{
		get
		{
			if (!this.mStarted)
			{
				return this.startsActive;
			}
			return this.mIsActive;
		}
		set
		{
			if (!this.mStarted)
			{
				this.startsActive = value;
				return;
			}
			if (this.group == 0 || value || this.optionCanBeNone || !this.mStarted)
			{
				this.Set(value, true);
			}
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x060002D0 RID: 720 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
	public bool isColliderEnabled
	{
		get
		{
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x060002D1 RID: 721 RVA: 0x0001E724 File Offset: 0x0001C924
	// (set) Token: 0x060002D2 RID: 722 RVA: 0x0001E72C File Offset: 0x0001C92C
	[Obsolete("Use 'value' instead")]
	public bool isChecked
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0001E738 File Offset: 0x0001C938
	public static UIToggle GetActiveToggle(int group)
	{
		for (int i = 0; i < UIToggle.list.size; i++)
		{
			UIToggle uitoggle = UIToggle.list.buffer[i];
			if (uitoggle != null && uitoggle.group == group && uitoggle.mIsActive)
			{
				return uitoggle;
			}
		}
		return null;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0001E784 File Offset: 0x0001C984
	private void OnEnable()
	{
		UIToggle.list.Add(this);
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0001E791 File Offset: 0x0001C991
	private void OnDisable()
	{
		UIToggle.list.Remove(this);
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x0001E7A0 File Offset: 0x0001C9A0
	public void Start()
	{
		if (this.mStarted)
		{
			return;
		}
		if (this.startsChecked)
		{
			this.startsChecked = false;
			this.startsActive = true;
		}
		if (!Application.isPlaying)
		{
			if (this.checkSprite != null && this.activeSprite == null)
			{
				this.activeSprite = this.checkSprite;
				this.checkSprite = null;
			}
			if (this.checkAnimation != null && this.activeAnimation == null)
			{
				this.activeAnimation = this.checkAnimation;
				this.checkAnimation = null;
			}
			if (Application.isPlaying && this.activeSprite != null)
			{
				this.activeSprite.alpha = (this.invertSpriteState ? (this.startsActive ? 0f : 1f) : (this.startsActive ? 1f : 0f));
			}
			if (EventDelegate.IsValid(this.onChange))
			{
				this.eventReceiver = null;
				this.functionName = null;
				return;
			}
		}
		else
		{
			this.mIsActive = !this.startsActive;
			this.mStarted = true;
			bool flag = this.instantTween;
			this.instantTween = true;
			this.Set(this.startsActive, true);
			this.instantTween = flag;
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0001E8DA File Offset: 0x0001CADA
	private void OnClick()
	{
		if (base.enabled && this.isColliderEnabled && UICamera.currentTouchID != -2)
		{
			this.value = !this.value;
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0001E904 File Offset: 0x0001CB04
	public void Set(bool state, bool notify = true)
	{
		if (this.validator != null && !this.validator(state))
		{
			return;
		}
		if (!this.mStarted)
		{
			this.mIsActive = state;
			this.startsActive = state;
			if (this.activeSprite != null)
			{
				this.activeSprite.alpha = (this.invertSpriteState ? (state ? 0f : 1f) : (state ? 1f : 0f));
				return;
			}
		}
		else if (this.mIsActive != state)
		{
			if (this.group != 0 && state)
			{
				int i = 0;
				int size = UIToggle.list.size;
				while (i < size)
				{
					UIToggle uitoggle = UIToggle.list.buffer[i];
					if (uitoggle != this && uitoggle.group == this.group)
					{
						uitoggle.Set(false, true);
					}
					if (UIToggle.list.size != size)
					{
						size = UIToggle.list.size;
						i = 0;
					}
					else
					{
						i++;
					}
				}
			}
			this.mIsActive = state;
			if (this.activeSprite != null)
			{
				if (this.instantTween || !NGUITools.GetActive(this))
				{
					this.activeSprite.alpha = (this.invertSpriteState ? (this.mIsActive ? 0f : 1f) : (this.mIsActive ? 1f : 0f));
				}
				else
				{
					TweenAlpha.Begin(this.activeSprite.gameObject, 0.15f, this.invertSpriteState ? (this.mIsActive ? 0f : 1f) : (this.mIsActive ? 1f : 0f), 0f);
				}
			}
			if (notify && UIToggle.current == null)
			{
				UIToggle uitoggle2 = UIToggle.current;
				UIToggle.current = this;
				if (EventDelegate.IsValid(this.onChange))
				{
					EventDelegate.Execute(this.onChange);
				}
				else if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName))
				{
					this.eventReceiver.SendMessage(this.functionName, this.mIsActive, SendMessageOptions.DontRequireReceiver);
				}
				UIToggle.current = uitoggle2;
			}
			if (this.animator != null)
			{
				ActiveAnimation activeAnimation = ActiveAnimation.Play(this.animator, null, state ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse, EnableCondition.IgnoreDisabledState, DisableCondition.DoNotDisable);
				if (activeAnimation != null && (this.instantTween || !NGUITools.GetActive(this)))
				{
					activeAnimation.Finish();
					return;
				}
			}
			else if (this.activeAnimation != null)
			{
				ActiveAnimation activeAnimation2 = ActiveAnimation.Play(this.activeAnimation, null, state ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse, EnableCondition.IgnoreDisabledState, DisableCondition.DoNotDisable);
				if (activeAnimation2 != null && (this.instantTween || !NGUITools.GetActive(this)))
				{
					activeAnimation2.Finish();
					return;
				}
			}
			else if (this.tween != null)
			{
				bool active = NGUITools.GetActive(this);
				if (this.tween.tweenGroup != 0)
				{
					UITweener[] componentsInChildren = this.tween.GetComponentsInChildren<UITweener>(true);
					int j = 0;
					int num = componentsInChildren.Length;
					while (j < num)
					{
						UITweener uitweener = componentsInChildren[j];
						if (uitweener.tweenGroup == this.tween.tweenGroup)
						{
							uitweener.Play(state);
							if (this.instantTween || !active)
							{
								uitweener.tweenFactor = (state ? 1f : 0f);
							}
						}
						j++;
					}
					return;
				}
				this.tween.Play(state);
				if (this.instantTween || !active)
				{
					this.tween.tweenFactor = (state ? 1f : 0f);
				}
			}
		}
	}

	// Token: 0x0400044B RID: 1099
	public static BetterList<UIToggle> list = new BetterList<UIToggle>();

	// Token: 0x0400044C RID: 1100
	public static UIToggle current;

	// Token: 0x0400044D RID: 1101
	public int group;

	// Token: 0x0400044E RID: 1102
	public UIWidget activeSprite;

	// Token: 0x0400044F RID: 1103
	public bool invertSpriteState;

	// Token: 0x04000450 RID: 1104
	public Animation activeAnimation;

	// Token: 0x04000451 RID: 1105
	public Animator animator;

	// Token: 0x04000452 RID: 1106
	public UITweener tween;

	// Token: 0x04000453 RID: 1107
	public bool startsActive;

	// Token: 0x04000454 RID: 1108
	public bool instantTween;

	// Token: 0x04000455 RID: 1109
	public bool optionCanBeNone;

	// Token: 0x04000456 RID: 1110
	public List<EventDelegate> onChange = new List<EventDelegate>();

	// Token: 0x04000457 RID: 1111
	public UIToggle.Validate validator;

	// Token: 0x04000458 RID: 1112
	[HideInInspector]
	[SerializeField]
	private UISprite checkSprite;

	// Token: 0x04000459 RID: 1113
	[HideInInspector]
	[SerializeField]
	private Animation checkAnimation;

	// Token: 0x0400045A RID: 1114
	[HideInInspector]
	[SerializeField]
	private GameObject eventReceiver;

	// Token: 0x0400045B RID: 1115
	[HideInInspector]
	[SerializeField]
	private string functionName = "OnActivate";

	// Token: 0x0400045C RID: 1116
	[HideInInspector]
	[SerializeField]
	private bool startsChecked;

	// Token: 0x0400045D RID: 1117
	private bool mIsActive = true;

	// Token: 0x0400045E RID: 1118
	private bool mStarted;

	// Token: 0x020005E2 RID: 1506
	// (Invoke) Token: 0x06002517 RID: 9495
	public delegate bool Validate(bool choice);
}
