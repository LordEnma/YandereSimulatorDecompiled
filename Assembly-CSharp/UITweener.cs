using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

public abstract class UITweener : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum Method
	{
		Linear = 0,
		EaseIn = 1,
		EaseOut = 2,
		EaseInOut = 3,
		BounceIn = 4,
		BounceOut = 5
	}

	[DoNotObfuscateNGUI]
	public enum Style
	{
		Once = 0,
		Loop = 1,
		PingPong = 2
	}

	public static UITweener current;

	[HideInInspector]
	public Method method;

	[HideInInspector]
	public Style style;

	[HideInInspector]
	public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

	[HideInInspector]
	public bool ignoreTimeScale = true;

	[HideInInspector]
	public float delay;

	[HideInInspector]
	public float duration = 1f;

	[HideInInspector]
	public bool steeperCurves;

	[HideInInspector]
	public int tweenGroup;

	[Tooltip("By default, Update() will be used for tweening. Setting this to 'true' will make the tween happen in FixedUpdate() insted.")]
	public bool useFixedUpdate;

	[HideInInspector]
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	[HideInInspector]
	public GameObject eventReceiver;

	[HideInInspector]
	public string callWhenFinished;

	[NonSerialized]
	public float timeScale = 1f;

	private bool mStarted;

	private float mStartTime;

	private float mDuration;

	private float mAmountPerDelta = 1000f;

	private float mFactor;

	private List<EventDelegate> mTemp;

	public float amountPerDelta
	{
		get
		{
			if (duration == 0f)
			{
				return 1000f;
			}
			if (mDuration != duration)
			{
				mDuration = duration;
				mAmountPerDelta = Mathf.Abs(1f / duration) * Mathf.Sign(mAmountPerDelta);
			}
			return mAmountPerDelta;
		}
	}

	public float tweenFactor
	{
		get
		{
			return mFactor;
		}
		set
		{
			mFactor = Mathf.Clamp01(value);
		}
	}

	public AnimationOrTween.Direction direction
	{
		get
		{
			if (!(amountPerDelta < 0f))
			{
				return AnimationOrTween.Direction.Forward;
			}
			return AnimationOrTween.Direction.Reverse;
		}
	}

	private void Reset()
	{
		if (!mStarted)
		{
			SetStartToCurrentValue();
			SetEndToCurrentValue();
		}
	}

	protected virtual void Start()
	{
		DoUpdate();
	}

	protected void Update()
	{
		if (!useFixedUpdate)
		{
			DoUpdate();
		}
	}

	protected void FixedUpdate()
	{
		if (useFixedUpdate)
		{
			DoUpdate();
		}
	}

	protected void DoUpdate()
	{
		float num = ((ignoreTimeScale && !useFixedUpdate) ? Time.unscaledDeltaTime : Time.deltaTime);
		float num2 = ((ignoreTimeScale && !useFixedUpdate) ? Time.unscaledTime : Time.time);
		if (!mStarted)
		{
			num = 0f;
			mStarted = true;
			mStartTime = num2 + delay;
		}
		if (num2 < mStartTime)
		{
			return;
		}
		mFactor += ((duration == 0f) ? 1f : (amountPerDelta * num * timeScale));
		if (style == Style.Loop)
		{
			if (mFactor > 1f)
			{
				mFactor -= Mathf.Floor(mFactor);
			}
		}
		else if (style == Style.PingPong)
		{
			if (mFactor > 1f)
			{
				mFactor = 1f - (mFactor - Mathf.Floor(mFactor));
				mAmountPerDelta = 0f - mAmountPerDelta;
			}
			else if (mFactor < 0f)
			{
				mFactor = 0f - mFactor;
				mFactor -= Mathf.Floor(mFactor);
				mAmountPerDelta = 0f - mAmountPerDelta;
			}
		}
		if (style == Style.Once && (duration == 0f || mFactor > 1f || mFactor < 0f))
		{
			mFactor = Mathf.Clamp01(mFactor);
			Sample(mFactor, isFinished: true);
			base.enabled = false;
			if (!(current != this))
			{
				return;
			}
			UITweener uITweener = current;
			current = this;
			if (onFinished != null)
			{
				mTemp = onFinished;
				onFinished = new List<EventDelegate>();
				EventDelegate.Execute(mTemp);
				for (int i = 0; i < mTemp.Count; i++)
				{
					EventDelegate eventDelegate = mTemp[i];
					if (eventDelegate != null && !eventDelegate.oneShot)
					{
						EventDelegate.Add(onFinished, eventDelegate, eventDelegate.oneShot);
					}
				}
				mTemp = null;
			}
			if (eventReceiver != null && !string.IsNullOrEmpty(callWhenFinished))
			{
				eventReceiver.SendMessage(callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
			}
			current = uITweener;
		}
		else
		{
			Sample(mFactor, isFinished: false);
		}
	}

	public void SetOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Set(onFinished, del);
	}

	public void SetOnFinished(EventDelegate del)
	{
		EventDelegate.Set(onFinished, del);
	}

	public void AddOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Add(onFinished, del);
	}

	public void AddOnFinished(EventDelegate del)
	{
		EventDelegate.Add(onFinished, del);
	}

	public void RemoveOnFinished(EventDelegate del)
	{
		if (onFinished != null)
		{
			onFinished.Remove(del);
		}
		if (mTemp != null)
		{
			mTemp.Remove(del);
		}
	}

	private void OnDisable()
	{
		mStarted = false;
	}

	public void Finish()
	{
		if (base.enabled)
		{
			Sample((mAmountPerDelta > 0f) ? 1f : 0f, isFinished: true);
			base.enabled = false;
		}
	}

	public void Sample(float factor, bool isFinished)
	{
		float num = Mathf.Clamp01(factor);
		if (method == Method.EaseIn)
		{
			num = 1f - Mathf.Sin((float)Math.PI / 2f * (1f - num));
			if (steeperCurves)
			{
				num *= num;
			}
		}
		else if (method == Method.EaseOut)
		{
			num = Mathf.Sin((float)Math.PI / 2f * num);
			if (steeperCurves)
			{
				num = 1f - num;
				num = 1f - num * num;
			}
		}
		else if (method == Method.EaseInOut)
		{
			num -= Mathf.Sin(num * ((float)Math.PI * 2f)) / ((float)Math.PI * 2f);
			if (steeperCurves)
			{
				num = num * 2f - 1f;
				float num2 = Mathf.Sign(num);
				num = 1f - Mathf.Abs(num);
				num = 1f - num * num;
				num = num2 * num * 0.5f + 0.5f;
			}
		}
		else if (method == Method.BounceIn)
		{
			num = BounceLogic(num);
		}
		else if (method == Method.BounceOut)
		{
			num = 1f - BounceLogic(1f - num);
		}
		OnUpdate((animationCurve != null) ? animationCurve.Evaluate(num) : num, isFinished);
	}

	private float BounceLogic(float val)
	{
		val = ((val < 0.363636f) ? (7.5685f * val * val) : ((val < 0.727272f) ? (7.5625f * (val -= 0.545454f) * val + 0.75f) : ((!(val < 0.90909f)) ? (7.5625f * (val -= 0.9545454f) * val + 63f / 64f) : (7.5625f * (val -= 0.818181f) * val + 0.9375f))));
		return val;
	}

	[Obsolete("Use PlayForward() instead")]
	public void Play()
	{
		Play(forward: true);
	}

	public void PlayForward()
	{
		Play(forward: true);
	}

	public void PlayReverse()
	{
		Play(forward: false);
	}

	public virtual void Play(bool forward)
	{
		mAmountPerDelta = Mathf.Abs(amountPerDelta);
		if (!forward)
		{
			mAmountPerDelta = 0f - mAmountPerDelta;
		}
		if (!base.enabled)
		{
			base.enabled = true;
			mStarted = false;
		}
		DoUpdate();
	}

	public void ResetToBeginning()
	{
		mStarted = false;
		mFactor = ((amountPerDelta < 0f) ? 1f : 0f);
		Sample(mFactor, isFinished: false);
	}

	public void Toggle()
	{
		if (mFactor > 0f)
		{
			mAmountPerDelta = 0f - amountPerDelta;
		}
		else
		{
			mAmountPerDelta = Mathf.Abs(amountPerDelta);
		}
		base.enabled = true;
	}

	protected abstract void OnUpdate(float factor, bool isFinished);

	public static T Begin<T>(GameObject go, float duration, float delay = 0f) where T : UITweener
	{
		T val = go.GetComponent<T>();
		if ((UnityEngine.Object)val != (UnityEngine.Object)null && val.tweenGroup != 0)
		{
			val = null;
			T[] components = go.GetComponents<T>();
			int i = 0;
			for (int num = components.Length; i < num; i++)
			{
				val = components[i];
				if ((UnityEngine.Object)val != (UnityEngine.Object)null && val.tweenGroup == 0)
				{
					break;
				}
				val = null;
			}
		}
		if ((UnityEngine.Object)val == (UnityEngine.Object)null)
		{
			val = go.AddComponent<T>();
			if ((UnityEngine.Object)val == (UnityEngine.Object)null)
			{
				Debug.LogError("Unable to add " + typeof(T)?.ToString() + " to " + NGUITools.GetHierarchy(go), go);
				return null;
			}
		}
		val.mStarted = false;
		val.mFactor = 0f;
		val.duration = duration;
		val.mDuration = duration;
		val.delay = delay;
		val.mAmountPerDelta = ((duration > 0f) ? Mathf.Abs(1f / duration) : 1000f);
		val.style = Style.Once;
		val.animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
		val.eventReceiver = null;
		val.callWhenFinished = null;
		val.onFinished.Clear();
		if (val.mTemp != null)
		{
			val.mTemp.Clear();
		}
		val.enabled = true;
		return val;
	}

	public virtual void SetStartToCurrentValue()
	{
	}

	public virtual void SetEndToCurrentValue()
	{
	}
}
