// Decompiled with JetBrains decompiler
// Type: UIKeyNavigation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Key Navigation")]
public class UIKeyNavigation : MonoBehaviour
{
  public static BetterList<UIKeyNavigation> list = new BetterList<UIKeyNavigation>();
  public UIKeyNavigation.Constraint constraint;
  public GameObject onUp;
  public GameObject onDown;
  public GameObject onLeft;
  public GameObject onRight;
  public GameObject onClick;
  public GameObject onTab;
  public bool startsSelected;
  [NonSerialized]
  private bool mStarted;
  public static int mLastFrame = 0;

  public static UIKeyNavigation current
  {
    get
    {
      GameObject hoveredObject = UICamera.hoveredObject;
      return (UnityEngine.Object) hoveredObject == (UnityEngine.Object) null ? (UIKeyNavigation) null : hoveredObject.GetComponent<UIKeyNavigation>();
    }
  }

  public bool isColliderEnabled
  {
    get
    {
      if (!this.enabled || !this.gameObject.activeInHierarchy)
        return false;
      Collider component1 = this.GetComponent<Collider>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        return component1.enabled;
      Collider2D component2 = this.GetComponent<Collider2D>();
      return (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.enabled;
    }
  }

  protected virtual void OnEnable()
  {
    UIKeyNavigation.list.Add(this);
    if (!this.mStarted)
      return;
    this.Invoke("Start", 1f / 1000f);
  }

  private void Start()
  {
    this.mStarted = true;
    if (!this.startsSelected || !this.isColliderEnabled)
      return;
    UICamera.selectedObject = this.gameObject;
  }

  protected virtual void OnDisable() => UIKeyNavigation.list.Remove(this);

  private static bool IsActive(GameObject go)
  {
    if (!(bool) (UnityEngine.Object) go || !go.activeInHierarchy)
      return false;
    Collider component1 = go.GetComponent<Collider>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      return component1.enabled;
    Collider2D component2 = go.GetComponent<Collider2D>();
    return (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.enabled;
  }

  public GameObject GetLeft()
  {
    if (UIKeyNavigation.IsActive(this.onLeft))
      return this.onLeft;
    return this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.left, y: 2f);
  }

  public GameObject GetRight()
  {
    if (UIKeyNavigation.IsActive(this.onRight))
      return this.onRight;
    return this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.right, y: 2f);
  }

  public GameObject GetUp()
  {
    if (UIKeyNavigation.IsActive(this.onUp))
      return this.onUp;
    return this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.up, 2f);
  }

  public GameObject GetDown()
  {
    if (UIKeyNavigation.IsActive(this.onDown))
      return this.onDown;
    return this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.down, 2f);
  }

  public GameObject Get(Vector3 myDir, float x = 1f, float y = 1f)
  {
    Transform transform = this.transform;
    myDir = transform.TransformDirection(myDir);
    Vector3 center = UIKeyNavigation.GetCenter(this.gameObject);
    float num = float.MaxValue;
    GameObject gameObject = (GameObject) null;
    for (int index = 0; index < UIKeyNavigation.list.size; ++index)
    {
      UIKeyNavigation uiKeyNavigation = UIKeyNavigation.list.buffer[index];
      if (!((UnityEngine.Object) uiKeyNavigation == (UnityEngine.Object) this) && uiKeyNavigation.constraint != UIKeyNavigation.Constraint.Explicit && uiKeyNavigation.isColliderEnabled)
      {
        UIWidget component = uiKeyNavigation.GetComponent<UIWidget>();
        if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || (double) component.alpha != 0.0)
        {
          Vector3 direction = UIKeyNavigation.GetCenter(uiKeyNavigation.gameObject) - center;
          if ((double) Vector3.Dot(myDir, direction.normalized) >= 0.7070000171661377)
          {
            Vector3 vector3 = transform.InverseTransformDirection(direction);
            vector3.x *= x;
            vector3.y *= y;
            float sqrMagnitude = vector3.sqrMagnitude;
            if ((double) sqrMagnitude <= (double) num)
            {
              gameObject = uiKeyNavigation.gameObject;
              num = sqrMagnitude;
            }
          }
        }
      }
    }
    return gameObject;
  }

  protected static Vector3 GetCenter(GameObject go)
  {
    UIWidget component = go.GetComponent<UIWidget>();
    UICamera cameraForLayer = UICamera.FindCameraForLayer(go.layer);
    if ((UnityEngine.Object) cameraForLayer != (UnityEngine.Object) null)
    {
      Vector3 position = go.transform.position;
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        Vector3[] worldCorners = component.worldCorners;
        position = (worldCorners[0] + worldCorners[2]) * 0.5f;
      }
      return cameraForLayer.cachedCamera.WorldToScreenPoint(position) with
      {
        z = 0.0f
      };
    }
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return go.transform.position;
    Vector3[] worldCorners1 = component.worldCorners;
    return (worldCorners1[0] + worldCorners1[2]) * 0.5f;
  }

  public virtual void OnNavigate(KeyCode key)
  {
    if (UIPopupList.isOpen || UIKeyNavigation.mLastFrame == Time.frameCount)
      return;
    UIKeyNavigation.mLastFrame = Time.frameCount;
    GameObject gameObject = (GameObject) null;
    switch (key)
    {
      case KeyCode.UpArrow:
        gameObject = this.GetUp();
        break;
      case KeyCode.DownArrow:
        gameObject = this.GetDown();
        break;
      case KeyCode.RightArrow:
        gameObject = this.GetRight();
        break;
      case KeyCode.LeftArrow:
        gameObject = this.GetLeft();
        break;
    }
    if (!((UnityEngine.Object) gameObject != (UnityEngine.Object) null))
      return;
    UICamera.hoveredObject = gameObject;
  }

  public virtual void OnKey(KeyCode key)
  {
    if (UIPopupList.isOpen || UIKeyNavigation.mLastFrame == Time.frameCount)
      return;
    UIKeyNavigation.mLastFrame = Time.frameCount;
    if (key != KeyCode.Tab)
      return;
    GameObject gameObject = this.onTab;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
      {
        gameObject = this.GetLeft();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetUp();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetDown();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetRight();
      }
      else
      {
        gameObject = this.GetRight();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetDown();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetUp();
        if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
          gameObject = this.GetLeft();
      }
    }
    if (!((UnityEngine.Object) gameObject != (UnityEngine.Object) null))
      return;
    UICamera.currentScheme = UICamera.ControlScheme.Controller;
    UICamera.hoveredObject = gameObject;
    UIInput component = gameObject.GetComponent<UIInput>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.isSelected = true;
  }

  protected virtual void OnClick()
  {
    if (!NGUITools.GetActive(this.onClick))
      return;
    UICamera.hoveredObject = this.onClick;
  }

  [DoNotObfuscateNGUI]
  public enum Constraint
  {
    None,
    Vertical,
    Horizontal,
    Explicit,
  }
}
