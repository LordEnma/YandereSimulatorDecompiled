using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : UIWidgetContainer
{
	[DoNotObfuscateNGUI]
	public enum State
	{
		Normal = 0,
		Hover = 1,
		Pressed = 2,
		Disabled = 3
	}

	public GameObject tweenTarget;

	public Color hover = new Color(0.88235295f, 40f / 51f, 0.5882353f, 1f);

	public Color pressed = new Color(61f / 85f, 0.6392157f, 41f / 85f, 1f);

	public Color disabledColor = Color.grey;

	public float duration = 0.2f;

	[NonSerialized]
	protected Color mStartingColor;

	[NonSerialized]
	protected Color mDefaultColor;

	[NonSerialized]
	protected bool mInitDone;

	[NonSerialized]
	protected UIWidget mWidget;

	[NonSerialized]
	protected State mState;

	public State state
	{
		get
		{
			return mState;
		}
		set
		{
			SetState(value, instant: false);
		}
	}

	public Color defaultColor
	{
		get
		{
			if (!mInitDone)
			{
				OnInit();
			}
			return mDefaultColor;
		}
		set
		{
			if (!mInitDone)
			{
				OnInit();
			}
			mDefaultColor = value;
			State state = mState;
			mState = State.Disabled;
			SetState(state, instant: false);
		}
	}

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

	public void ResetDefaultColor()
	{
		defaultColor = mStartingColor;
	}

	public void CacheDefaultColor()
	{
		if (!mInitDone)
		{
			OnInit();
		}
	}

	private void Start()
	{
		if (!mInitDone)
		{
			OnInit();
		}
		if (!isEnabled)
		{
			SetState(State.Disabled, instant: true);
		}
	}

	protected virtual void OnInit()
	{
		mInitDone = true;
		if (tweenTarget == null && !Application.isPlaying)
		{
			tweenTarget = base.gameObject;
		}
		if (tweenTarget != null)
		{
			mWidget = tweenTarget.GetComponent<UIWidget>();
		}
		if (mWidget != null)
		{
			mDefaultColor = mWidget.color;
			mStartingColor = mDefaultColor;
		}
		else
		{
			if (!(tweenTarget != null))
			{
				return;
			}
			Renderer component = tweenTarget.GetComponent<Renderer>();
			if (component != null)
			{
				mDefaultColor = (Application.isPlaying ? component.material.color : component.sharedMaterial.color);
				mStartingColor = mDefaultColor;
				return;
			}
			Light component2 = tweenTarget.GetComponent<Light>();
			if (component2 != null)
			{
				mDefaultColor = component2.color;
				mStartingColor = mDefaultColor;
			}
			else
			{
				tweenTarget = null;
				mInitDone = false;
			}
		}
	}

	protected virtual void OnEnable()
	{
		if (mInitDone)
		{
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
		if (UICamera.currentTouch != null)
		{
			if (UICamera.currentTouch.pressed == base.gameObject)
			{
				OnPress(isPressed: true);
			}
			else if (UICamera.currentTouch.current == base.gameObject)
			{
				OnHover(isOver: true);
			}
		}
	}

	protected virtual void OnDisable()
	{
		if (!mInitDone || mState == State.Normal)
		{
			return;
		}
		SetState(State.Normal, instant: true);
		if (tweenTarget != null)
		{
			TweenColor component = tweenTarget.GetComponent<TweenColor>();
			if (component != null)
			{
				component.value = mDefaultColor;
				component.enabled = false;
			}
		}
	}

	protected virtual void OnHover(bool isOver)
	{
		if (isEnabled)
		{
			if (!mInitDone)
			{
				OnInit();
			}
			if (tweenTarget != null)
			{
				SetState(isOver ? State.Hover : State.Normal, instant: false);
			}
		}
	}

	protected virtual void OnPress(bool isPressed)
	{
		if (!isEnabled)
		{
			return;
		}
		if (!mInitDone)
		{
			OnInit();
		}
		if (!(tweenTarget != null))
		{
			return;
		}
		if (isPressed)
		{
			SetState(State.Pressed, instant: false);
		}
		else if (UICamera.currentTouch != null && UICamera.currentTouch.current == base.gameObject)
		{
			if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
			{
				SetState(State.Hover, instant: false);
			}
			else if (UICamera.currentScheme == UICamera.ControlScheme.Mouse && UICamera.hoveredObject == base.gameObject)
			{
				SetState(State.Hover, instant: false);
			}
			else
			{
				SetState(State.Normal, instant: false);
			}
		}
		else
		{
			SetState(State.Normal, instant: false);
		}
	}

	protected virtual void OnDragOver()
	{
		if (isEnabled)
		{
			if (!mInitDone)
			{
				OnInit();
			}
			if (tweenTarget != null)
			{
				SetState(State.Pressed, instant: false);
			}
		}
	}

	protected virtual void OnDragOut()
	{
		if (isEnabled)
		{
			if (!mInitDone)
			{
				OnInit();
			}
			if (tweenTarget != null)
			{
				SetState(State.Normal, instant: false);
			}
		}
	}

	public virtual void SetState(State state, bool instant)
	{
		if (!mInitDone)
		{
			mInitDone = true;
			OnInit();
		}
		if (mState != state)
		{
			mState = state;
			UpdateColor(instant);
		}
	}

	public void UpdateColor(bool instant)
	{
		if (mInitDone && tweenTarget != null)
		{
			TweenColor tweenColor = mState switch
			{
				State.Hover => TweenColor.Begin(tweenTarget, duration, hover), 
				State.Pressed => TweenColor.Begin(tweenTarget, duration, pressed), 
				State.Disabled => TweenColor.Begin(tweenTarget, duration, disabledColor), 
				_ => TweenColor.Begin(tweenTarget, duration, mDefaultColor), 
			};
			if (instant && tweenColor != null)
			{
				tweenColor.value = tweenColor.to;
				tweenColor.enabled = false;
			}
		}
	}
}
