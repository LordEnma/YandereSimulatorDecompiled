using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000096 RID: 150
public abstract class UITweener : MonoBehaviour
{
	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00035B5C File Offset: 0x00033D5C
	public float amountPerDelta
	{
		get
		{
			if (this.duration == 0f)
			{
				return 1000f;
			}
			if (this.mDuration != this.duration)
			{
				this.mDuration = this.duration;
				this.mAmountPerDelta = Mathf.Abs(1f / this.duration) * Mathf.Sign(this.mAmountPerDelta);
			}
			return this.mAmountPerDelta;
		}
	}

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00035BBF File Offset: 0x00033DBF
	// (set) Token: 0x060005E8 RID: 1512 RVA: 0x00035BC7 File Offset: 0x00033DC7
	public float tweenFactor
	{
		get
		{
			return this.mFactor;
		}
		set
		{
			this.mFactor = Mathf.Clamp01(value);
		}
	}

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00035BD5 File Offset: 0x00033DD5
	public AnimationOrTween.Direction direction
	{
		get
		{
			if (this.amountPerDelta >= 0f)
			{
				return AnimationOrTween.Direction.Forward;
			}
			return AnimationOrTween.Direction.Reverse;
		}
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x00035BE7 File Offset: 0x00033DE7
	private void Reset()
	{
		if (!this.mStarted)
		{
			this.SetStartToCurrentValue();
			this.SetEndToCurrentValue();
		}
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x00035BFD File Offset: 0x00033DFD
	protected virtual void Start()
	{
		this.DoUpdate();
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00035C05 File Offset: 0x00033E05
	protected void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.DoUpdate();
		}
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00035C15 File Offset: 0x00033E15
	protected void FixedUpdate()
	{
		if (this.useFixedUpdate)
		{
			this.DoUpdate();
		}
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00035C28 File Offset: 0x00033E28
	protected void DoUpdate()
	{
		float num = (this.ignoreTimeScale && !this.useFixedUpdate) ? Time.unscaledDeltaTime : Time.deltaTime;
		float num2 = (this.ignoreTimeScale && !this.useFixedUpdate) ? Time.unscaledTime : Time.time;
		if (!this.mStarted)
		{
			num = 0f;
			this.mStarted = true;
			this.mStartTime = num2 + this.delay;
		}
		if (num2 < this.mStartTime)
		{
			return;
		}
		this.mFactor += ((this.duration == 0f) ? 1f : (this.amountPerDelta * num * this.timeScale));
		if (this.style == UITweener.Style.Loop)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor -= Mathf.Floor(this.mFactor);
			}
		}
		else if (this.style == UITweener.Style.PingPong)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor = 1f - (this.mFactor - Mathf.Floor(this.mFactor));
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
			else if (this.mFactor < 0f)
			{
				this.mFactor = -this.mFactor;
				this.mFactor -= Mathf.Floor(this.mFactor);
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
		}
		if (this.style == UITweener.Style.Once && (this.duration == 0f || this.mFactor > 1f || this.mFactor < 0f))
		{
			this.mFactor = Mathf.Clamp01(this.mFactor);
			this.Sample(this.mFactor, true);
			base.enabled = false;
			if (UITweener.current != this)
			{
				UITweener uitweener = UITweener.current;
				UITweener.current = this;
				if (this.onFinished != null)
				{
					this.mTemp = this.onFinished;
					this.onFinished = new List<EventDelegate>();
					EventDelegate.Execute(this.mTemp);
					for (int i = 0; i < this.mTemp.Count; i++)
					{
						EventDelegate eventDelegate = this.mTemp[i];
						if (eventDelegate != null && !eventDelegate.oneShot)
						{
							EventDelegate.Add(this.onFinished, eventDelegate, eventDelegate.oneShot);
						}
					}
					this.mTemp = null;
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				UITweener.current = uitweener;
				return;
			}
		}
		else
		{
			this.Sample(this.mFactor, false);
		}
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x00035EB2 File Offset: 0x000340B2
	public void SetOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Set(this.onFinished, del);
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00035EC1 File Offset: 0x000340C1
	public void SetOnFinished(EventDelegate del)
	{
		EventDelegate.Set(this.onFinished, del);
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00035ECF File Offset: 0x000340CF
	public void AddOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Add(this.onFinished, del);
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00035EDE File Offset: 0x000340DE
	public void AddOnFinished(EventDelegate del)
	{
		EventDelegate.Add(this.onFinished, del);
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00035EEC File Offset: 0x000340EC
	public void RemoveOnFinished(EventDelegate del)
	{
		if (this.onFinished != null)
		{
			this.onFinished.Remove(del);
		}
		if (this.mTemp != null)
		{
			this.mTemp.Remove(del);
		}
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00035F18 File Offset: 0x00034118
	private void OnDisable()
	{
		this.mStarted = false;
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00035F21 File Offset: 0x00034121
	public void Finish()
	{
		if (base.enabled)
		{
			this.Sample((this.mAmountPerDelta > 0f) ? 1f : 0f, true);
			base.enabled = false;
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00035F54 File Offset: 0x00034154
	public void Sample(float factor, bool isFinished)
	{
		float num = Mathf.Clamp01(factor);
		if (this.method == UITweener.Method.EaseIn)
		{
			num = 1f - Mathf.Sin(1.5707964f * (1f - num));
			if (this.steeperCurves)
			{
				num *= num;
			}
		}
		else if (this.method == UITweener.Method.EaseOut)
		{
			num = Mathf.Sin(1.5707964f * num);
			if (this.steeperCurves)
			{
				num = 1f - num;
				num = 1f - num * num;
			}
		}
		else if (this.method == UITweener.Method.EaseInOut)
		{
			num -= Mathf.Sin(num * 6.2831855f) / 6.2831855f;
			if (this.steeperCurves)
			{
				num = num * 2f - 1f;
				float num2 = Mathf.Sign(num);
				num = 1f - Mathf.Abs(num);
				num = 1f - num * num;
				num = num2 * num * 0.5f + 0.5f;
			}
		}
		else if (this.method == UITweener.Method.BounceIn)
		{
			num = this.BounceLogic(num);
		}
		else if (this.method == UITweener.Method.BounceOut)
		{
			num = 1f - this.BounceLogic(1f - num);
		}
		this.OnUpdate((this.animationCurve != null) ? this.animationCurve.Evaluate(num) : num, isFinished);
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00036088 File Offset: 0x00034288
	private float BounceLogic(float val)
	{
		if (val < 0.363636f)
		{
			val = 7.5685f * val * val;
		}
		else if (val < 0.727272f)
		{
			val = 7.5625f * (val -= 0.545454f) * val + 0.75f;
		}
		else if (val < 0.90909f)
		{
			val = 7.5625f * (val -= 0.818181f) * val + 0.9375f;
		}
		else
		{
			val = 7.5625f * (val -= 0.9545454f) * val + 0.984375f;
		}
		return val;
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x0003610D File Offset: 0x0003430D
	[Obsolete("Use PlayForward() instead")]
	public void Play()
	{
		this.Play(true);
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00036116 File Offset: 0x00034316
	public void PlayForward()
	{
		this.Play(true);
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0003611F File Offset: 0x0003431F
	public void PlayReverse()
	{
		this.Play(false);
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00036128 File Offset: 0x00034328
	public virtual void Play(bool forward)
	{
		this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
		if (!forward)
		{
			this.mAmountPerDelta = -this.mAmountPerDelta;
		}
		if (!base.enabled)
		{
			base.enabled = true;
			this.mStarted = false;
		}
		this.DoUpdate();
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00036167 File Offset: 0x00034367
	public void ResetToBeginning()
	{
		this.mStarted = false;
		this.mFactor = ((this.amountPerDelta < 0f) ? 1f : 0f);
		this.Sample(this.mFactor, false);
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x0003619C File Offset: 0x0003439C
	public void Toggle()
	{
		if (this.mFactor > 0f)
		{
			this.mAmountPerDelta = -this.amountPerDelta;
		}
		else
		{
			this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
		}
		base.enabled = true;
	}

	// Token: 0x060005FE RID: 1534
	protected abstract void OnUpdate(float factor, bool isFinished);

	// Token: 0x060005FF RID: 1535 RVA: 0x000361D4 File Offset: 0x000343D4
	public static T Begin<T>(GameObject go, float duration, float delay = 0f) where T : UITweener
	{
		T t = go.GetComponent<T>();
		if (t != null && t.tweenGroup != 0)
		{
			t = default(T);
			T[] components = go.GetComponents<T>();
			int i = 0;
			int num = components.Length;
			while (i < num)
			{
				t = components[i];
				if (t != null && t.tweenGroup == 0)
				{
					break;
				}
				t = default(T);
				i++;
			}
		}
		if (t == null)
		{
			t = go.AddComponent<T>();
			if (t == null)
			{
				string str = "Unable to add ";
				Type typeFromHandle = typeof(T);
				Debug.LogError(str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null) + " to " + NGUITools.GetHierarchy(go), go);
				return default(T);
			}
		}
		t.mStarted = false;
		t.mFactor = 0f;
		t.duration = duration;
		t.mDuration = duration;
		t.delay = delay;
		t.mAmountPerDelta = ((duration > 0f) ? Mathf.Abs(1f / duration) : 1000f);
		t.style = UITweener.Style.Once;
		t.animationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});
		t.eventReceiver = null;
		t.callWhenFinished = null;
		t.onFinished.Clear();
		if (t.mTemp != null)
		{
			t.mTemp.Clear();
		}
		t.enabled = true;
		return t;
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x000363C6 File Offset: 0x000345C6
	public virtual void SetStartToCurrentValue()
	{
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x000363C8 File Offset: 0x000345C8
	public virtual void SetEndToCurrentValue()
	{
	}

	// Token: 0x040005F5 RID: 1525
	public static UITweener current;

	// Token: 0x040005F6 RID: 1526
	[HideInInspector]
	public UITweener.Method method;

	// Token: 0x040005F7 RID: 1527
	[HideInInspector]
	public UITweener.Style style;

	// Token: 0x040005F8 RID: 1528
	[HideInInspector]
	public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f, 0f, 1f),
		new Keyframe(1f, 1f, 1f, 0f)
	});

	// Token: 0x040005F9 RID: 1529
	[HideInInspector]
	public bool ignoreTimeScale = true;

	// Token: 0x040005FA RID: 1530
	[HideInInspector]
	public float delay;

	// Token: 0x040005FB RID: 1531
	[HideInInspector]
	public float duration = 1f;

	// Token: 0x040005FC RID: 1532
	[HideInInspector]
	public bool steeperCurves;

	// Token: 0x040005FD RID: 1533
	[HideInInspector]
	public int tweenGroup;

	// Token: 0x040005FE RID: 1534
	[Tooltip("By default, Update() will be used for tweening. Setting this to 'true' will make the tween happen in FixedUpdate() insted.")]
	public bool useFixedUpdate;

	// Token: 0x040005FF RID: 1535
	[HideInInspector]
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x04000600 RID: 1536
	[HideInInspector]
	public GameObject eventReceiver;

	// Token: 0x04000601 RID: 1537
	[HideInInspector]
	public string callWhenFinished;

	// Token: 0x04000602 RID: 1538
	[NonSerialized]
	public float timeScale = 1f;

	// Token: 0x04000603 RID: 1539
	private bool mStarted;

	// Token: 0x04000604 RID: 1540
	private float mStartTime;

	// Token: 0x04000605 RID: 1541
	private float mDuration;

	// Token: 0x04000606 RID: 1542
	private float mAmountPerDelta = 1000f;

	// Token: 0x04000607 RID: 1543
	private float mFactor;

	// Token: 0x04000608 RID: 1544
	private List<EventDelegate> mTemp;

	// Token: 0x02000617 RID: 1559
	[DoNotObfuscateNGUI]
	public enum Method
	{
		// Token: 0x04004EFF RID: 20223
		Linear,
		// Token: 0x04004F00 RID: 20224
		EaseIn,
		// Token: 0x04004F01 RID: 20225
		EaseOut,
		// Token: 0x04004F02 RID: 20226
		EaseInOut,
		// Token: 0x04004F03 RID: 20227
		BounceIn,
		// Token: 0x04004F04 RID: 20228
		BounceOut
	}

	// Token: 0x02000618 RID: 1560
	[DoNotObfuscateNGUI]
	public enum Style
	{
		// Token: 0x04004F06 RID: 20230
		Once,
		// Token: 0x04004F07 RID: 20231
		Loop,
		// Token: 0x04004F08 RID: 20232
		PingPong
	}
}
