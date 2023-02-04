using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
	[Range(0f, 1f)]
	public float from = 1f;

	[Range(0f, 1f)]
	public float to = 1f;

	[Tooltip("If used on a renderer, the material should probably be cleaned up after this script gets destroyed...")]
	public bool autoCleanup;

	[Tooltip("Color to adjust")]
	public string colorProperty;

	[NonSerialized]
	private bool mCached;

	[NonSerialized]
	private UIRect mRect;

	[NonSerialized]
	private Material mShared;

	[NonSerialized]
	private Material mMat;

	[NonSerialized]
	private Light mLight;

	[NonSerialized]
	private SpriteRenderer mSr;

	[NonSerialized]
	private float mBaseIntensity = 1f;

	[Obsolete("Use 'value' instead")]
	public float alpha
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

	public float value
	{
		get
		{
			if (!mCached)
			{
				Cache();
			}
			if (mRect != null)
			{
				return mRect.alpha;
			}
			if (mSr != null)
			{
				return mSr.color.a;
			}
			if (mMat == null)
			{
				return 1f;
			}
			if (string.IsNullOrEmpty(colorProperty))
			{
				return mMat.color.a;
			}
			return mMat.GetColor(colorProperty).a;
		}
		set
		{
			if (!mCached)
			{
				Cache();
			}
			if (mRect != null)
			{
				mRect.alpha = value;
			}
			else if (mSr != null)
			{
				Color color = mSr.color;
				color.a = value;
				mSr.color = color;
			}
			else if (mMat != null)
			{
				if (string.IsNullOrEmpty(colorProperty))
				{
					Color color2 = mMat.color;
					color2.a = value;
					mMat.color = color2;
				}
				else
				{
					Color color3 = mMat.GetColor(colorProperty);
					color3.a = value;
					mMat.SetColor(colorProperty, color3);
				}
			}
			else if (mLight != null)
			{
				mLight.intensity = mBaseIntensity * value;
			}
		}
	}

	private void OnDestroy()
	{
		if (autoCleanup && mMat != null && mShared != mMat)
		{
			UnityEngine.Object.Destroy(mMat);
			mMat = null;
		}
	}

	private void Cache()
	{
		mCached = true;
		mRect = GetComponent<UIRect>();
		mSr = GetComponent<SpriteRenderer>();
		if (!(mRect == null) || !(mSr == null))
		{
			return;
		}
		mLight = GetComponent<Light>();
		if (mLight == null)
		{
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				mShared = component.sharedMaterial;
				mMat = component.material;
			}
			if (mMat == null)
			{
				mRect = GetComponentInChildren<UIRect>();
			}
		}
		else
		{
			mBaseIntensity = mLight.intensity;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		value = Mathf.Lerp(from, to, factor);
	}

	public static TweenAlpha Begin(GameObject go, float duration, float alpha, float delay = 0f)
	{
		TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration, delay);
		tweenAlpha.from = tweenAlpha.value;
		tweenAlpha.to = alpha;
		if (duration <= 0f)
		{
			tweenAlpha.Sample(1f, isFinished: true);
			tweenAlpha.enabled = false;
		}
		return tweenAlpha;
	}

	public override void SetStartToCurrentValue()
	{
		from = value;
	}

	public override void SetEndToCurrentValue()
	{
		to = value;
	}
}
