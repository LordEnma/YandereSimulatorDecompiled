// Decompiled with JetBrains decompiler
// Type: TweenWidth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween Width")]
public class TweenWidth : UITweener
{
  public int from = 100;
  public int to = 100;
  [Tooltip("If set, 'from' value will be set to match the specified rectangle")]
  public UIWidget fromTarget;
  [Tooltip("If set, 'to' value will be set to match the specified rectangle")]
  public UIWidget toTarget;
  [Tooltip("Whether there is a table that should be updated")]
  public bool updateTable;
  private UIWidget mWidget;
  private UITable mTable;

  public UIWidget cachedWidget
  {
    get
    {
      if ((UnityEngine.Object) this.mWidget == (UnityEngine.Object) null)
        this.mWidget = this.GetComponent<UIWidget>();
      return this.mWidget;
    }
  }

  [Obsolete("Use 'value' instead")]
  public int width
  {
    get => this.value;
    set => this.value = value;
  }

  public int value
  {
    get => this.cachedWidget.width;
    set => this.cachedWidget.width = value;
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    if ((bool) (UnityEngine.Object) this.fromTarget)
      this.from = this.fromTarget.width;
    if ((bool) (UnityEngine.Object) this.toTarget)
      this.to = this.toTarget.width;
    this.value = Mathf.RoundToInt((float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor));
    if (!this.updateTable)
      return;
    if ((UnityEngine.Object) this.mTable == (UnityEngine.Object) null)
    {
      this.mTable = NGUITools.FindInParents<UITable>(this.gameObject);
      if ((UnityEngine.Object) this.mTable == (UnityEngine.Object) null)
      {
        this.updateTable = false;
        return;
      }
    }
    this.mTable.repositionNow = true;
  }

  public static TweenWidth Begin(UIWidget widget, float duration, int width)
  {
    TweenWidth tweenWidth = UITweener.Begin<TweenWidth>(widget.gameObject, duration);
    tweenWidth.from = widget.width;
    tweenWidth.to = width;
    if ((double) duration <= 0.0)
    {
      tweenWidth.Sample(1f, true);
      tweenWidth.enabled = false;
    }
    return tweenWidth;
  }

  [ContextMenu("Set 'From' to current value")]
  public override void SetStartToCurrentValue() => this.from = this.value;

  [ContextMenu("Set 'To' to current value")]
  public override void SetEndToCurrentValue() => this.to = this.value;

  [ContextMenu("Assume value of 'From'")]
  private void SetCurrentValueToStart() => this.value = this.from;

  [ContextMenu("Assume value of 'To'")]
  private void SetCurrentValueToEnd() => this.value = this.to;
}
