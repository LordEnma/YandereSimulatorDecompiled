using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : UIWidgetContainer
{
	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000120 RID: 288 RVA: 0x00014099 File Offset: 0x00012299
	// (set) Token: 0x06000121 RID: 289 RVA: 0x000140A1 File Offset: 0x000122A1
	public UIButtonColor.State state
	{
		get
		{
			return this.mState;
		}
		set
		{
			this.SetState(value, false);
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000122 RID: 290 RVA: 0x000140AB File Offset: 0x000122AB
	// (set) Token: 0x06000123 RID: 291 RVA: 0x000140C4 File Offset: 0x000122C4
	public Color defaultColor
	{
		get
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			return this.mDefaultColor;
		}
		set
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			this.mDefaultColor = value;
			UIButtonColor.State state = this.mState;
			this.mState = UIButtonColor.State.Disabled;
			this.SetState(state, false);
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000124 RID: 292 RVA: 0x000140FC File Offset: 0x000122FC
	// (set) Token: 0x06000125 RID: 293 RVA: 0x00014104 File Offset: 0x00012304
	public virtual bool isEnabled
	{
		get
		{
			return base.enabled;
		}
		set
		{
			base.enabled = value;
		}
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0001410D File Offset: 0x0001230D
	public void ResetDefaultColor()
	{
		this.defaultColor = this.mStartingColor;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0001411B File Offset: 0x0001231B
	public void CacheDefaultColor()
	{
		if (!this.mInitDone)
		{
			this.OnInit();
		}
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0001412B File Offset: 0x0001232B
	private void Start()
	{
		if (!this.mInitDone)
		{
			this.OnInit();
		}
		if (!this.isEnabled)
		{
			this.SetState(UIButtonColor.State.Disabled, true);
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0001414C File Offset: 0x0001234C
	protected virtual void OnInit()
	{
		this.mInitDone = true;
		if (this.tweenTarget == null && !Application.isPlaying)
		{
			this.tweenTarget = base.gameObject;
		}
		if (this.tweenTarget != null)
		{
			this.mWidget = this.tweenTarget.GetComponent<UIWidget>();
		}
		if (this.mWidget != null)
		{
			this.mDefaultColor = this.mWidget.color;
			this.mStartingColor = this.mDefaultColor;
			return;
		}
		if (this.tweenTarget != null)
		{
			Renderer component = this.tweenTarget.GetComponent<Renderer>();
			if (component != null)
			{
				this.mDefaultColor = (Application.isPlaying ? component.material.color : component.sharedMaterial.color);
				this.mStartingColor = this.mDefaultColor;
				return;
			}
			Light component2 = this.tweenTarget.GetComponent<Light>();
			if (component2 != null)
			{
				this.mDefaultColor = component2.color;
				this.mStartingColor = this.mDefaultColor;
				return;
			}
			this.tweenTarget = null;
			this.mInitDone = false;
		}
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00014260 File Offset: 0x00012460
	protected virtual void OnEnable()
	{
		if (this.mInitDone)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
		if (UICamera.currentTouch != null)
		{
			if (UICamera.currentTouch.pressed == base.gameObject)
			{
				this.OnPress(true);
				return;
			}
			if (UICamera.currentTouch.current == base.gameObject)
			{
				this.OnHover(true);
			}
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x000142CC File Offset: 0x000124CC
	protected virtual void OnDisable()
	{
		if (this.mInitDone && this.mState != UIButtonColor.State.Normal)
		{
			this.SetState(UIButtonColor.State.Normal, true);
			if (this.tweenTarget != null)
			{
				TweenColor component = this.tweenTarget.GetComponent<TweenColor>();
				if (component != null)
				{
					component.value = this.mDefaultColor;
					component.enabled = false;
				}
			}
		}
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00014327 File Offset: 0x00012527
	protected virtual void OnHover(bool isOver)
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState(isOver ? UIButtonColor.State.Hover : UIButtonColor.State.Normal, false);
			}
		}
	}

	// Token: 0x0600012D RID: 301 RVA: 0x0001435C File Offset: 0x0001255C
	protected virtual void OnPress(bool isPressed)
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				if (isPressed)
				{
					this.SetState(UIButtonColor.State.Pressed, false);
					return;
				}
				if (UICamera.currentTouch != null && UICamera.currentTouch.current == base.gameObject)
				{
					if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
					{
						this.SetState(UIButtonColor.State.Hover, false);
						return;
					}
					if (UICamera.currentScheme == UICamera.ControlScheme.Mouse && UICamera.hoveredObject == base.gameObject)
					{
						this.SetState(UIButtonColor.State.Hover, false);
						return;
					}
					this.SetState(UIButtonColor.State.Normal, false);
					return;
				}
				else
				{
					this.SetState(UIButtonColor.State.Normal, false);
				}
			}
		}
	}

	// Token: 0x0600012E RID: 302 RVA: 0x000143FE File Offset: 0x000125FE
	protected virtual void OnDragOver()
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState(UIButtonColor.State.Pressed, false);
			}
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0001442C File Offset: 0x0001262C
	protected virtual void OnDragOut()
	{
		if (this.isEnabled)
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.tweenTarget != null)
			{
				this.SetState(UIButtonColor.State.Normal, false);
			}
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0001445A File Offset: 0x0001265A
	public virtual void SetState(UIButtonColor.State state, bool instant)
	{
		if (!this.mInitDone)
		{
			this.mInitDone = true;
			this.OnInit();
		}
		if (this.mState != state)
		{
			this.mState = state;
			this.UpdateColor(instant);
		}
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00014488 File Offset: 0x00012688
	public void UpdateColor(bool instant)
	{
		if (!this.mInitDone)
		{
			return;
		}
		if (this.tweenTarget != null)
		{
			TweenColor tweenColor;
			switch (this.mState)
			{
			case UIButtonColor.State.Hover:
				tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.hover);
				break;
			case UIButtonColor.State.Pressed:
				tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.pressed);
				break;
			case UIButtonColor.State.Disabled:
				tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.disabledColor);
				break;
			default:
				tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.mDefaultColor);
				break;
			}
			if (instant && tweenColor != null)
			{
				tweenColor.value = tweenColor.to;
				tweenColor.enabled = false;
			}
		}
	}

	// Token: 0x040002F9 RID: 761
	public GameObject tweenTarget;

	// Token: 0x040002FA RID: 762
	public Color hover = new Color(0.88235295f, 0.78431374f, 0.5882353f, 1f);

	// Token: 0x040002FB RID: 763
	public Color pressed = new Color(0.7176471f, 0.6392157f, 0.48235294f, 1f);

	// Token: 0x040002FC RID: 764
	public Color disabledColor = Color.grey;

	// Token: 0x040002FD RID: 765
	public float duration = 0.2f;

	// Token: 0x040002FE RID: 766
	[NonSerialized]
	protected Color mStartingColor;

	// Token: 0x040002FF RID: 767
	[NonSerialized]
	protected Color mDefaultColor;

	// Token: 0x04000300 RID: 768
	[NonSerialized]
	protected bool mInitDone;

	// Token: 0x04000301 RID: 769
	[NonSerialized]
	protected UIWidget mWidget;

	// Token: 0x04000302 RID: 770
	[NonSerialized]
	protected UIButtonColor.State mState;

	// Token: 0x020005D0 RID: 1488
	[DoNotObfuscateNGUI]
	public enum State
	{
		// Token: 0x04004DFF RID: 19967
		Normal,
		// Token: 0x04004E00 RID: 19968
		Hover,
		// Token: 0x04004E01 RID: 19969
		Pressed,
		// Token: 0x04004E02 RID: 19970
		Disabled
	}
}
