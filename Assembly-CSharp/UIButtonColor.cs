using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : UIWidgetContainer
{
	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000120 RID: 288 RVA: 0x00013DB1 File Offset: 0x00011FB1
	// (set) Token: 0x06000121 RID: 289 RVA: 0x00013DB9 File Offset: 0x00011FB9
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
	// (get) Token: 0x06000122 RID: 290 RVA: 0x00013DC3 File Offset: 0x00011FC3
	// (set) Token: 0x06000123 RID: 291 RVA: 0x00013DDC File Offset: 0x00011FDC
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
	// (get) Token: 0x06000124 RID: 292 RVA: 0x00013E14 File Offset: 0x00012014
	// (set) Token: 0x06000125 RID: 293 RVA: 0x00013E1C File Offset: 0x0001201C
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

	// Token: 0x06000126 RID: 294 RVA: 0x00013E25 File Offset: 0x00012025
	public void ResetDefaultColor()
	{
		this.defaultColor = this.mStartingColor;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00013E33 File Offset: 0x00012033
	public void CacheDefaultColor()
	{
		if (!this.mInitDone)
		{
			this.OnInit();
		}
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00013E43 File Offset: 0x00012043
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

	// Token: 0x06000129 RID: 297 RVA: 0x00013E64 File Offset: 0x00012064
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

	// Token: 0x0600012A RID: 298 RVA: 0x00013F78 File Offset: 0x00012178
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

	// Token: 0x0600012B RID: 299 RVA: 0x00013FE4 File Offset: 0x000121E4
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

	// Token: 0x0600012C RID: 300 RVA: 0x0001403F File Offset: 0x0001223F
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

	// Token: 0x0600012D RID: 301 RVA: 0x00014074 File Offset: 0x00012274
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

	// Token: 0x0600012E RID: 302 RVA: 0x00014116 File Offset: 0x00012316
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

	// Token: 0x0600012F RID: 303 RVA: 0x00014144 File Offset: 0x00012344
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

	// Token: 0x06000130 RID: 304 RVA: 0x00014172 File Offset: 0x00012372
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

	// Token: 0x06000131 RID: 305 RVA: 0x000141A0 File Offset: 0x000123A0
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

	// Token: 0x040002EC RID: 748
	public GameObject tweenTarget;

	// Token: 0x040002ED RID: 749
	public Color hover = new Color(0.88235295f, 0.78431374f, 0.5882353f, 1f);

	// Token: 0x040002EE RID: 750
	public Color pressed = new Color(0.7176471f, 0.6392157f, 0.48235294f, 1f);

	// Token: 0x040002EF RID: 751
	public Color disabledColor = Color.grey;

	// Token: 0x040002F0 RID: 752
	public float duration = 0.2f;

	// Token: 0x040002F1 RID: 753
	[NonSerialized]
	protected Color mStartingColor;

	// Token: 0x040002F2 RID: 754
	[NonSerialized]
	protected Color mDefaultColor;

	// Token: 0x040002F3 RID: 755
	[NonSerialized]
	protected bool mInitDone;

	// Token: 0x040002F4 RID: 756
	[NonSerialized]
	protected UIWidget mWidget;

	// Token: 0x040002F5 RID: 757
	[NonSerialized]
	protected UIButtonColor.State mState;

	// Token: 0x020005C3 RID: 1475
	[DoNotObfuscateNGUI]
	public enum State
	{
		// Token: 0x04004CBB RID: 19643
		Normal,
		// Token: 0x04004CBC RID: 19644
		Hover,
		// Token: 0x04004CBD RID: 19645
		Pressed,
		// Token: 0x04004CBE RID: 19646
		Disabled
	}
}
