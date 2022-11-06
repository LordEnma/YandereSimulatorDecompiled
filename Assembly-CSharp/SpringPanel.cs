// Decompiled with JetBrains decompiler
// Type: SpringPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : MonoBehaviour
{
  public static SpringPanel current;
  public Vector3 target = Vector3.zero;
  public float strength = 10f;
  public SpringPanel.OnFinished onFinished;
  [NonSerialized]
  private UIPanel mPanel;
  [NonSerialized]
  private Transform mTrans;
  [NonSerialized]
  private UIScrollView mDrag;
  [NonSerialized]
  private float mDelta;

  private void Start()
  {
    this.mPanel = this.GetComponent<UIPanel>();
    this.mDrag = this.GetComponent<UIScrollView>();
    this.mTrans = this.transform;
  }

  private void Update() => this.AdvanceTowardsPosition();

  protected virtual void AdvanceTowardsPosition()
  {
    this.mDelta += RealTime.deltaTime;
    bool flag = false;
    Vector3 localPosition = this.mTrans.localPosition;
    Vector3 vector3_1 = NGUIMath.SpringLerp(localPosition, this.target, this.strength, this.mDelta);
    if ((double) (localPosition - this.target).sqrMagnitude < 0.0099999997764825821)
    {
      vector3_1 = this.target;
      this.enabled = false;
      flag = true;
      this.mDelta = 0.0f;
    }
    else
    {
      vector3_1.x = Mathf.Round(vector3_1.x);
      vector3_1.y = Mathf.Round(vector3_1.y);
      vector3_1.z = Mathf.Round(vector3_1.z);
      if ((double) (vector3_1 - localPosition).sqrMagnitude < 0.0099999997764825821)
        return;
      this.mDelta = 0.0f;
    }
    this.mTrans.localPosition = vector3_1;
    Vector3 vector3_2 = vector3_1 - localPosition;
    Vector2 clipOffset = this.mPanel.clipOffset;
    clipOffset.x -= vector3_2.x;
    clipOffset.y -= vector3_2.y;
    this.mPanel.clipOffset = clipOffset;
    if ((UnityEngine.Object) this.mDrag != (UnityEngine.Object) null)
      this.mDrag.UpdateScrollbars(false);
    if (!flag || this.onFinished == null)
      return;
    SpringPanel.current = this;
    this.onFinished();
    SpringPanel.current = (SpringPanel) null;
  }

  public static SpringPanel Begin(GameObject go, Vector3 pos, float strength)
  {
    SpringPanel springPanel = go.GetComponent<SpringPanel>();
    if ((UnityEngine.Object) springPanel == (UnityEngine.Object) null)
      springPanel = go.AddComponent<SpringPanel>();
    springPanel.target = pos;
    springPanel.strength = strength;
    springPanel.onFinished = (SpringPanel.OnFinished) null;
    springPanel.enabled = true;
    return springPanel;
  }

  public static SpringPanel Stop(GameObject go)
  {
    SpringPanel component = go.GetComponent<SpringPanel>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.enabled)
    {
      if (component.onFinished != null)
        component.onFinished();
      component.enabled = false;
    }
    return component;
  }

  public delegate void OnFinished();
}
