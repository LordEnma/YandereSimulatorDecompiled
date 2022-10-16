// Decompiled with JetBrains decompiler
// Type: UITweener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UITweener : MonoBehaviour
{
  public static UITweener current;
  [HideInInspector]
  public UITweener.Method method;
  [HideInInspector]
  public UITweener.Style style;
  [HideInInspector]
  public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[2]
  {
    new Keyframe(0.0f, 0.0f, 0.0f, 1f),
    new Keyframe(1f, 1f, 1f, 0.0f)
  });
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
      if ((double) this.duration == 0.0)
        return 1000f;
      if ((double) this.mDuration != (double) this.duration)
      {
        this.mDuration = this.duration;
        this.mAmountPerDelta = Mathf.Abs(1f / this.duration) * Mathf.Sign(this.mAmountPerDelta);
      }
      return this.mAmountPerDelta;
    }
  }

  public float tweenFactor
  {
    get => this.mFactor;
    set => this.mFactor = Mathf.Clamp01(value);
  }

  public AnimationOrTween.Direction direction => (double) this.amountPerDelta >= 0.0 ? AnimationOrTween.Direction.Forward : AnimationOrTween.Direction.Reverse;

  private void Reset()
  {
    if (this.mStarted)
      return;
    this.SetStartToCurrentValue();
    this.SetEndToCurrentValue();
  }

  protected virtual void Start() => this.DoUpdate();

  protected void Update()
  {
    if (this.useFixedUpdate)
      return;
    this.DoUpdate();
  }

  protected void FixedUpdate()
  {
    if (!this.useFixedUpdate)
      return;
    this.DoUpdate();
  }

  protected void DoUpdate()
  {
    float num1 = !this.ignoreTimeScale || this.useFixedUpdate ? Time.deltaTime : Time.unscaledDeltaTime;
    float num2 = !this.ignoreTimeScale || this.useFixedUpdate ? Time.time : Time.unscaledTime;
    if (!this.mStarted)
    {
      num1 = 0.0f;
      this.mStarted = true;
      this.mStartTime = num2 + this.delay;
    }
    if ((double) num2 < (double) this.mStartTime)
      return;
    this.mFactor += (double) this.duration == 0.0 ? 1f : this.amountPerDelta * num1 * this.timeScale;
    if (this.style == UITweener.Style.Loop)
    {
      if ((double) this.mFactor > 1.0)
        this.mFactor -= Mathf.Floor(this.mFactor);
    }
    else if (this.style == UITweener.Style.PingPong)
    {
      if ((double) this.mFactor > 1.0)
      {
        this.mFactor = (float) (1.0 - ((double) this.mFactor - (double) Mathf.Floor(this.mFactor)));
        this.mAmountPerDelta = -this.mAmountPerDelta;
      }
      else if ((double) this.mFactor < 0.0)
      {
        this.mFactor = -this.mFactor;
        this.mFactor -= Mathf.Floor(this.mFactor);
        this.mAmountPerDelta = -this.mAmountPerDelta;
      }
    }
    if (this.style == UITweener.Style.Once && ((double) this.duration == 0.0 || (double) this.mFactor > 1.0 || (double) this.mFactor < 0.0))
    {
      this.mFactor = Mathf.Clamp01(this.mFactor);
      this.Sample(this.mFactor, true);
      this.enabled = false;
      if (!((UnityEngine.Object) UITweener.current != (UnityEngine.Object) this))
        return;
      UITweener current = UITweener.current;
      UITweener.current = this;
      if (this.onFinished != null)
      {
        this.mTemp = this.onFinished;
        this.onFinished = new List<EventDelegate>();
        EventDelegate.Execute(this.mTemp);
        for (int index = 0; index < this.mTemp.Count; ++index)
        {
          EventDelegate ev = this.mTemp[index];
          if (ev != null && !ev.oneShot)
            EventDelegate.Add(this.onFinished, ev, ev.oneShot);
        }
        this.mTemp = (List<EventDelegate>) null;
      }
      if ((UnityEngine.Object) this.eventReceiver != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.callWhenFinished))
        this.eventReceiver.SendMessage(this.callWhenFinished, (object) this, SendMessageOptions.DontRequireReceiver);
      UITweener.current = current;
    }
    else
      this.Sample(this.mFactor, false);
  }

  public void SetOnFinished(EventDelegate.Callback del) => EventDelegate.Set(this.onFinished, del);

  public void SetOnFinished(EventDelegate del) => EventDelegate.Set(this.onFinished, del);

  public void AddOnFinished(EventDelegate.Callback del) => EventDelegate.Add(this.onFinished, del);

  public void AddOnFinished(EventDelegate del) => EventDelegate.Add(this.onFinished, del);

  public void RemoveOnFinished(EventDelegate del)
  {
    if (this.onFinished != null)
      this.onFinished.Remove(del);
    if (this.mTemp == null)
      return;
    this.mTemp.Remove(del);
  }

  private void OnDisable() => this.mStarted = false;

  public void Finish()
  {
    if (!this.enabled)
      return;
    this.Sample((double) this.mAmountPerDelta > 0.0 ? 1f : 0.0f, true);
    this.enabled = false;
  }

  public void Sample(float factor, bool isFinished)
  {
    float num1 = Mathf.Clamp01(factor);
    if (this.method == UITweener.Method.EaseIn)
    {
      num1 = 1f - Mathf.Sin((float) (1.5707963705062866 * (1.0 - (double) num1)));
      if (this.steeperCurves)
        num1 *= num1;
    }
    else if (this.method == UITweener.Method.EaseOut)
    {
      num1 = Mathf.Sin(1.57079637f * num1);
      if (this.steeperCurves)
      {
        float num2 = 1f - num1;
        num1 = (float) (1.0 - (double) num2 * (double) num2);
      }
    }
    else if (this.method == UITweener.Method.EaseInOut)
    {
      num1 -= Mathf.Sin(num1 * 6.28318548f) / 6.28318548f;
      if (this.steeperCurves)
      {
        float f = (float) ((double) num1 * 2.0 - 1.0);
        double num3 = (double) Mathf.Sign(f);
        float num4 = 1f - Mathf.Abs(f);
        double num5 = 1.0 - (double) num4 * (double) num4;
        num1 = (float) (num3 * num5 * 0.5 + 0.5);
      }
    }
    else if (this.method == UITweener.Method.BounceIn)
      num1 = this.BounceLogic(num1);
    else if (this.method == UITweener.Method.BounceOut)
      num1 = 1f - this.BounceLogic(1f - num1);
    this.OnUpdate(this.animationCurve != null ? this.animationCurve.Evaluate(num1) : num1, isFinished);
  }

  private float BounceLogic(float val)
  {
    val = (double) val >= 0.36363598704338074 ? ((double) val >= 0.72727197408676147 ? ((double) val >= 0.909089982509613 ? (float) (121.0 / 16.0 * (double) (val -= 0.9545454f) * (double) val + 63.0 / 64.0) : (float) (121.0 / 16.0 * (double) (val -= 0.818181f) * (double) val + 15.0 / 16.0)) : (float) (121.0 / 16.0 * (double) (val -= 0.545454f) * (double) val + 0.75)) : 7.5685f * val * val;
    return val;
  }

  [Obsolete("Use PlayForward() instead")]
  public void Play() => this.Play(true);

  public void PlayForward() => this.Play(true);

  public void PlayReverse() => this.Play(false);

  public virtual void Play(bool forward)
  {
    this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
    if (!forward)
      this.mAmountPerDelta = -this.mAmountPerDelta;
    if (!this.enabled)
    {
      this.enabled = true;
      this.mStarted = false;
    }
    this.DoUpdate();
  }

  public void ResetToBeginning()
  {
    this.mStarted = false;
    this.mFactor = (double) this.amountPerDelta < 0.0 ? 1f : 0.0f;
    this.Sample(this.mFactor, false);
  }

  public void Toggle()
  {
    this.mAmountPerDelta = (double) this.mFactor <= 0.0 ? Mathf.Abs(this.amountPerDelta) : -this.amountPerDelta;
    this.enabled = true;
  }

  protected abstract void OnUpdate(float factor, bool isFinished);

  public static T Begin<T>(GameObject go, float duration, float delay = 0.0f) where T : UITweener
  {
    T obj = go.GetComponent<T>();
    if ((UnityEngine.Object) obj != (UnityEngine.Object) null && obj.tweenGroup != 0)
    {
      obj = default (T);
      T[] components = go.GetComponents<T>();
      int index = 0;
      for (int length = components.Length; index < length; ++index)
      {
        obj = components[index];
        if (!((UnityEngine.Object) obj != (UnityEngine.Object) null) || obj.tweenGroup != 0)
          obj = default (T);
        else
          break;
      }
    }
    if ((UnityEngine.Object) obj == (UnityEngine.Object) null)
    {
      obj = go.AddComponent<T>();
      if ((UnityEngine.Object) obj == (UnityEngine.Object) null)
      {
        Debug.LogError((object) ("Unable to add " + typeof (T)?.ToString() + " to " + NGUITools.GetHierarchy(go)), (UnityEngine.Object) go);
        return default (T);
      }
    }
    obj.mStarted = false;
    obj.mFactor = 0.0f;
    obj.duration = duration;
    obj.mDuration = duration;
    obj.delay = delay;
    obj.mAmountPerDelta = (double) duration > 0.0 ? Mathf.Abs(1f / duration) : 1000f;
    obj.style = UITweener.Style.Once;
    obj.animationCurve = new AnimationCurve(new Keyframe[2]
    {
      new Keyframe(0.0f, 0.0f, 0.0f, 1f),
      new Keyframe(1f, 1f, 1f, 0.0f)
    });
    obj.eventReceiver = (GameObject) null;
    obj.callWhenFinished = (string) null;
    obj.onFinished.Clear();
    if (obj.mTemp != null)
      obj.mTemp.Clear();
    obj.enabled = true;
    return obj;
  }

  public virtual void SetStartToCurrentValue()
  {
  }

  public virtual void SetEndToCurrentValue()
  {
  }

  [DoNotObfuscateNGUI]
  public enum Method
  {
    Linear,
    EaseIn,
    EaseOut,
    EaseInOut,
    BounceIn,
    BounceOut,
  }

  [DoNotObfuscateNGUI]
  public enum Style
  {
    Once,
    Loop,
    PingPong,
  }
}
