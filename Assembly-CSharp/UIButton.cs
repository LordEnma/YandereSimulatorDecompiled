using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
	public static UIButton current;

	public bool dragHighlight;

	public string hoverSprite;

	public string pressedSprite;

	public string disabledSprite;

	public Sprite hoverSprite2D;

	public Sprite pressedSprite2D;

	public Sprite disabledSprite2D;

	public bool pixelSnap;

	public List<EventDelegate> onClick = new List<EventDelegate>();

	[NonSerialized]
	private UISprite mSprite;

	[NonSerialized]
	private UI2DSprite mSprite2D;

	[NonSerialized]
	private string mNormalSprite;

	[NonSerialized]
	private Sprite mNormalSprite2D;

	public override bool isEnabled
	{
		get
		{
			if (!base.enabled)
			{
				return false;
			}
			Collider component = base.gameObject.GetComponent<Collider>();
			if ((bool)component && component.enabled)
			{
				return true;
			}
			Collider2D component2 = GetComponent<Collider2D>();
			if ((bool)component2)
			{
				return component2.enabled;
			}
			return false;
		}
		set
		{
			if (isEnabled == value)
			{
				return;
			}
			Collider component = base.gameObject.GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = value;
				UIButton[] components = GetComponents<UIButton>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].SetState((!value) ? State.Disabled : State.Normal, immediate: false);
				}
				return;
			}
			Collider2D component2 = GetComponent<Collider2D>();
			if (component2 != null)
			{
				component2.enabled = value;
				UIButton[] components = GetComponents<UIButton>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].SetState((!value) ? State.Disabled : State.Normal, immediate: false);
				}
			}
			else
			{
				base.enabled = value;
			}
		}
	}

	public string normalSprite
	{
		get
		{
			if (!mInitDone)
			{
				OnInit();
			}
			return mNormalSprite;
		}
		set
		{
			if (!mInitDone)
			{
				OnInit();
			}
			if (mSprite != null && !string.IsNullOrEmpty(mNormalSprite) && mNormalSprite == mSprite.spriteName)
			{
				mNormalSprite = value;
				SetSprite(value);
				NGUITools.SetDirty(mSprite);
				return;
			}
			mNormalSprite = value;
			if (mState == State.Normal)
			{
				SetSprite(value);
			}
		}
	}

	public Sprite normalSprite2D
	{
		get
		{
			if (!mInitDone)
			{
				OnInit();
			}
			return mNormalSprite2D;
		}
		set
		{
			if (!mInitDone)
			{
				OnInit();
			}
			if (mSprite2D != null && mNormalSprite2D == mSprite2D.sprite2D)
			{
				mNormalSprite2D = value;
				SetSprite(value);
				NGUITools.SetDirty(mSprite);
				return;
			}
			mNormalSprite2D = value;
			if (mState == State.Normal)
			{
				SetSprite(value);
			}
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		mSprite = mWidget as UISprite;
		mSprite2D = mWidget as UI2DSprite;
		if (mSprite != null)
		{
			mNormalSprite = mSprite.spriteName;
		}
		if (mSprite2D != null)
		{
			mNormalSprite2D = mSprite2D.sprite2D;
		}
	}

	protected override void OnEnable()
	{
		if (isEnabled)
		{
			if (mInitDone)
			{
				OnHover(UICamera.hoveredObject == base.gameObject);
			}
		}
		else
		{
			SetState(State.Disabled, immediate: true);
		}
	}

	protected override void OnDragOver()
	{
		if (isEnabled && (dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOver();
		}
	}

	protected override void OnDragOut()
	{
		if (isEnabled && (dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOut();
		}
	}

	protected virtual void OnClick()
	{
		if (current == null && isEnabled && UICamera.currentTouchID != -2 && UICamera.currentTouchID != -3)
		{
			current = this;
			EventDelegate.Execute(onClick);
			current = null;
		}
	}

	public override void SetState(State state, bool immediate)
	{
		base.SetState(state, immediate);
		if (mSprite != null)
		{
			switch (state)
			{
			case State.Normal:
				SetSprite(mNormalSprite);
				break;
			case State.Hover:
				SetSprite(string.IsNullOrEmpty(hoverSprite) ? mNormalSprite : hoverSprite);
				break;
			case State.Pressed:
				SetSprite(pressedSprite);
				break;
			case State.Disabled:
				SetSprite(disabledSprite);
				break;
			}
		}
		else if (mSprite2D != null)
		{
			switch (state)
			{
			case State.Normal:
				SetSprite(mNormalSprite2D);
				break;
			case State.Hover:
				SetSprite((hoverSprite2D == null) ? mNormalSprite2D : hoverSprite2D);
				break;
			case State.Pressed:
				SetSprite(pressedSprite2D);
				break;
			case State.Disabled:
				SetSprite(disabledSprite2D);
				break;
			}
		}
	}

	protected void SetSprite(string sp)
	{
		if (mSprite != null && !string.IsNullOrEmpty(sp) && mSprite.spriteName != sp)
		{
			mSprite.spriteName = sp;
			if (pixelSnap)
			{
				mSprite.MakePixelPerfect();
			}
		}
	}

	protected void SetSprite(Sprite sp)
	{
		if (sp != null && mSprite2D != null && mSprite2D.sprite2D != sp)
		{
			mSprite2D.sprite2D = sp;
			if (pixelSnap)
			{
				mSprite2D.MakePixelPerfect();
			}
		}
	}
}
