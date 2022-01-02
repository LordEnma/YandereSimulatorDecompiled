using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000096 RID: 150
public abstract class UITweener : MonoBehaviour
{
	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00035874 File Offset: 0x00033A74
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
	// (get) Token: 0x060005E7 RID: 1511 RVA: 0x000358D7 File Offset: 0x00033AD7
	// (set) Token: 0x060005E8 RID: 1512 RVA: 0x000358DF File Offset: 0x00033ADF
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
	// (get) Token: 0x060005E9 RID: 1513 RVA: 0x000358ED File Offset: 0x00033AED
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

	// Token: 0x060005EA RID: 1514 RVA: 0x000358FF File Offset: 0x00033AFF
	private void Reset()
	{
		if (!this.mStarted)
		{
			this.SetStartToCurrentValue();
			this.SetEndToCurrentValue();
		}
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x00035915 File Offset: 0x00033B15
	protected virtual void Start()
	{
		this.DoUpdate();
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x0003591D File Offset: 0x00033B1D
	protected void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.DoUpdate();
		}
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x0003592D File Offset: 0x00033B2D
	protected void FixedUpdate()
	{
		if (this.useFixedUpdate)
		{
			this.DoUpdate();
		}
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00035940 File Offset: 0x00033B40
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

	// Token: 0x060005EF RID: 1519 RVA: 0x00035BCA File Offset: 0x00033DCA
	public void SetOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Set(this.onFinished, del);
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00035BD9 File Offset: 0x00033DD9
	public void SetOnFinished(EventDelegate del)
	{
		EventDelegate.Set(this.onFinished, del);
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00035BE7 File Offset: 0x00033DE7
	public void AddOnFinished(EventDelegate.Callback del)
	{
		EventDelegate.Add(this.onFinished, del);
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00035BF6 File Offset: 0x00033DF6
	public void AddOnFinished(EventDelegate del)
	{
		EventDelegate.Add(this.onFinished, del);
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00035C04 File Offset: 0x00033E04
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

	// Token: 0x060005F4 RID: 1524 RVA: 0x00035C30 File Offset: 0x00033E30
	private void OnDisable()
	{
		this.mStarted = false;
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00035C39 File Offset: 0x00033E39
	public void Finish()
	{
		if (base.enabled)
		{
			this.Sample((this.mAmountPerDelta > 0f) ? 1f : 0f, true);
			base.enabled = false;
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00035C6C File Offset: 0x00033E6C
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

	// Token: 0x060005F7 RID: 1527 RVA: 0x00035DA0 File Offset: 0x00033FA0
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

	// Token: 0x060005F8 RID: 1528 RVA: 0x00035E25 File Offset: 0x00034025
	[Obsolete("Use PlayForward() instead")]
	public void Play()
	{
		this.Play(true);
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00035E2E File Offset: 0x0003402E
	public void PlayForward()
	{
		this.Play(true);
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00035E37 File Offset: 0x00034037
	public void PlayReverse()
	{
		this.Play(false);
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00035E40 File Offset: 0x00034040
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

	// Token: 0x060005FC RID: 1532 RVA: 0x00035E7F File Offset: 0x0003407F
	public void ResetToBeginning()
	{
		this.mStarted = false;
		this.mFactor = ((this.amountPerDelta < 0f) ? 1f : 0f);
		this.Sample(this.mFactor, false);
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x00035EB4 File Offset: 0x000340B4
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

	// Token: 0x060005FF RID: 1535 RVA: 0x00035EEC File Offset: 0x000340EC
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

	// Token: 0x06000600 RID: 1536 RVA: 0x000360DE File Offset: 0x000342DE
	public virtual void SetStartToCurrentValue()
	{
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x000360E0 File Offset: 0x000342E0
	public virtual void SetEndToCurrentValue()
	{
	}

	// Token: 0x040005E8 RID: 1512
	public static UITweener current;

	// Token: 0x040005E9 RID: 1513
	[HideInInspector]
	public UITweener.Method method;

	// Token: 0x040005EA RID: 1514
	[HideInInspector]
	public UITweener.Style style;

	// Token: 0x040005EB RID: 1515
	[HideInInspector]
	public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f, 0f, 1f),
		new Keyframe(1f, 1f, 1f, 0f)
	});

	// Token: 0x040005EC RID: 1516
	[HideInInspector]
	public bool ignoreTimeScale = true;

	// Token: 0x040005ED RID: 1517
	[HideInInspector]
	public float delay;

	// Token: 0x040005EE RID: 1518
	[HideInInspector]
	public float duration = 1f;

	// Token: 0x040005EF RID: 1519
	[HideInInspector]
	public bool steeperCurves;

	// Token: 0x040005F0 RID: 1520
	[HideInInspector]
	public int tweenGroup;

	// Token: 0x040005F1 RID: 1521
	[Tooltip("By default, Update() will be used for tweening. Setting this to 'true' will make the tween happen in FixedUpdate() insted.")]
	public bool useFixedUpdate;

	// Token: 0x040005F2 RID: 1522
	[HideInInspector]
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x040005F3 RID: 1523
	[HideInInspector]
	public GameObject eventReceiver;

	// Token: 0x040005F4 RID: 1524
	[HideInInspector]
	public string callWhenFinished;

	// Token: 0x040005F5 RID: 1525
	[NonSerialized]
	public float timeScale = 1f;

	// Token: 0x040005F6 RID: 1526
	private bool mStarted;

	// Token: 0x040005F7 RID: 1527
	private float mStartTime;

	// Token: 0x040005F8 RID: 1528
	private float mDuration;

	// Token: 0x040005F9 RID: 1529
	private float mAmountPerDelta = 1000f;

	// Token: 0x040005FA RID: 1530
	private float mFactor;

	// Token: 0x040005FB RID: 1531
	private List<EventDelegate> mTemp;

	// Token: 0x0200060B RID: 1547
	[DoNotObfuscateNGUI]
	public enum Method
	{
		// Token: 0x04004DDC RID: 19932
		Linear,
		// Token: 0x04004DDD RID: 19933
		EaseIn,
		// Token: 0x04004DDE RID: 19934
		EaseOut,
		// Token: 0x04004DDF RID: 19935
		EaseInOut,
		// Token: 0x04004DE0 RID: 19936
		BounceIn,
		// Token: 0x04004DE1 RID: 19937
		BounceOut
	}

	// Token: 0x0200060C RID: 1548
	[DoNotObfuscateNGUI]
	public enum Style
	{
		// Token: 0x04004DE3 RID: 19939
		Once,
		// Token: 0x04004DE4 RID: 19940
		Loop,
		// Token: 0x04004DE5 RID: 19941
		PingPong
	}
}
