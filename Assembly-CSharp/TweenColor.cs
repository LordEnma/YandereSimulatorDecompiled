using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Color")]
public class TweenColor : UITweener
{
	public Color from = Color.white;

	public Color to = Color.white;

	private bool mCached;

	private UIWidget mWidget;

	private Material mMat;

	private Light mLight;

	private SpriteRenderer mSr;

	[Obsolete("Use 'value' instead")]
	public Color color
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public Color value
	{
		get
		{
			if (!mCached)
			{
				Cache();
			}
			if (mWidget != null)
			{
				return mWidget.color;
			}
			if (mMat != null)
			{
				return mMat.color;
			}
			if (mSr != null)
			{
				return mSr.color;
			}
			if (mLight != null)
			{
				return mLight.color;
			}
			return Color.black;
		}
		set
		{
			if (!mCached)
			{
				Cache();
			}
			if (mWidget != null)
			{
				mWidget.color = value;
			}
			else if (mMat != null)
			{
				mMat.color = value;
			}
			else if (mSr != null)
			{
				mSr.color = value;
			}
			else if (mLight != null)
			{
				mLight.color = value;
				mLight.enabled = value.r + value.g + value.b > 0.01f;
			}
		}
	}

	private void Cache()
	{
		mCached = true;
		mWidget = GetComponent<UIWidget>();
		if (mWidget != null)
		{
			return;
		}
		mSr = GetComponent<SpriteRenderer>();
		if (mSr != null)
		{
			return;
		}
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			mMat = component.material;
			return;
		}
		mLight = GetComponent<Light>();
		if (mLight == null)
		{
			mWidget = GetComponentInChildren<UIWidget>();
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		value = Color.Lerp(from, to, factor);
	}

	public static TweenColor Begin(GameObject go, float duration, Color color)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
		tweenColor.from = tweenColor.value;
		tweenColor.to = color;
		if (duration <= 0f)
		{
			tweenColor.Sample(1f, isFinished: true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		from = value;
	}

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		to = value;
	}

	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		value = from;
	}

	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		value = to;
	}
}
