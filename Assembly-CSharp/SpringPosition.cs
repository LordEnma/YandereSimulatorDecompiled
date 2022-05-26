// Decompiled with JetBrains decompiler
// Type: SpringPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : MonoBehaviour
{
  public static SpringPosition current;
  public Vector3 target = Vector3.zero;
  public float strength = 10f;
  public bool worldSpace;
  public bool ignoreTimeScale;
  public bool updateScrollView;
  public SpringPosition.OnFinished onFinished;
  [SerializeField]
  [HideInInspector]
  private GameObject eventReceiver;
  [SerializeField]
  [HideInInspector]
  public string callWhenFinished;
  private Transform mTrans;
  private float mThreshold;
  private UIScrollView mSv;

  private void Start()
  {
    this.mTrans = this.transform;
    if (!this.updateScrollView)
      return;
    this.mSv = NGUITools.FindInParents<UIScrollView>(this.gameObject);
  }

  private void Update()
  {
    float deltaTime = this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime;
    if (this.worldSpace)
    {
      if ((double) this.mThreshold == 0.0)
        this.mThreshold = (this.target - this.mTrans.position).sqrMagnitude * (1f / 1000f);
      this.mTrans.position = NGUIMath.SpringLerp(this.mTrans.position, this.target, this.strength, deltaTime);
      if ((double) this.mThreshold >= (double) (this.target - this.mTrans.position).sqrMagnitude)
      {
        this.mTrans.position = this.target;
        this.NotifyListeners();
        this.enabled = false;
      }
    }
    else
    {
      if ((double) this.mThreshold == 0.0)
        this.mThreshold = (this.target - this.mTrans.localPosition).sqrMagnitude * 1E-05f;
      this.mTrans.localPosition = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
      if ((double) this.mThreshold >= (double) (this.target - this.mTrans.localPosition).sqrMagnitude)
      {
        this.mTrans.localPosition = this.target;
        this.NotifyListeners();
        this.enabled = false;
      }
    }
    if (!((Object) this.mSv != (Object) null))
      return;
    this.mSv.UpdateScrollbars(true);
  }

  private void NotifyListeners()
  {
    SpringPosition.current = this;
    if (this.onFinished != null)
      this.onFinished();
    if ((Object) this.eventReceiver != (Object) null && !string.IsNullOrEmpty(this.callWhenFinished))
      this.eventReceiver.SendMessage(this.callWhenFinished, (object) this, SendMessageOptions.DontRequireReceiver);
    SpringPosition.current = (SpringPosition) null;
  }

  public static SpringPosition Begin(GameObject go, Vector3 pos, float strength)
  {
    SpringPosition springPosition = go.GetComponent<SpringPosition>();
    if ((Object) springPosition == (Object) null)
      springPosition = go.AddComponent<SpringPosition>();
    springPosition.target = pos;
    springPosition.strength = strength;
    springPosition.onFinished = (SpringPosition.OnFinished) null;
    if (!springPosition.enabled)
      springPosition.enabled = true;
    return springPosition;
  }

  public delegate void OnFinished();
}
