// Decompiled with JetBrains decompiler
// Type: TweenVolume
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
[AddComponentMenu("NGUI/Tween/Tween Volume")]
public class TweenVolume : UITweener
{
  [Range(0.0f, 1f)]
  public float from = 1f;
  [Range(0.0f, 1f)]
  public float to = 1f;
  private AudioSource mSource;

  public AudioSource audioSource
  {
    get
    {
      if ((UnityEngine.Object) this.mSource == (UnityEngine.Object) null)
      {
        this.mSource = this.GetComponent<AudioSource>();
        if ((UnityEngine.Object) this.mSource == (UnityEngine.Object) null)
        {
          this.mSource = this.GetComponent<AudioSource>();
          if ((UnityEngine.Object) this.mSource == (UnityEngine.Object) null)
          {
            Debug.LogError((object) "TweenVolume needs an AudioSource to work with", (UnityEngine.Object) this);
            this.enabled = false;
          }
        }
      }
      return this.mSource;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float volume
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get => !((UnityEngine.Object) this.audioSource != (UnityEngine.Object) null) ? 0.0f : this.mSource.volume;
    set
    {
      if (!((UnityEngine.Object) this.audioSource != (UnityEngine.Object) null))
        return;
      this.mSource.volume = value;
    }
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = (float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor);
    this.mSource.enabled = (double) this.mSource.volume > 0.0099999997764825821;
  }

  public static TweenVolume Begin(GameObject go, float duration, float targetVolume)
  {
    TweenVolume tweenVolume = UITweener.Begin<TweenVolume>(go, duration);
    tweenVolume.from = tweenVolume.value;
    tweenVolume.to = targetVolume;
    if ((double) targetVolume > 0.0)
    {
      AudioSource audioSource = tweenVolume.audioSource;
      audioSource.enabled = true;
      audioSource.Play();
    }
    return tweenVolume;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
