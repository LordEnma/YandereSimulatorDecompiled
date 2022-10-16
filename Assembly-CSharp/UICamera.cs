// Decompiled with JetBrains decompiler
// Type: UICamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Event System (UICamera)")]
[RequireComponent(typeof (Camera))]
public class UICamera : MonoBehaviour
{
  public static BetterList<UICamera> list = new BetterList<UICamera>();
  public static UICamera.GetKeyStateFunc GetKeyDown = (UICamera.GetKeyStateFunc) (key => (key < KeyCode.JoystickButton0 || !UICamera.ignoreControllerInput) && Input.GetKeyDown(key));
  public static UICamera.GetKeyStateFunc GetKeyUp = (UICamera.GetKeyStateFunc) (key => (key < KeyCode.JoystickButton0 || !UICamera.ignoreControllerInput) && Input.GetKeyUp(key));
  public static UICamera.GetKeyStateFunc GetKey = (UICamera.GetKeyStateFunc) (key => (key < KeyCode.JoystickButton0 || !UICamera.ignoreControllerInput) && Input.GetKey(key));
  public static UICamera.GetAxisFunc GetAxis = (UICamera.GetAxisFunc) (axis => UICamera.ignoreControllerInput ? 0.0f : Input.GetAxis(axis));
  public static UICamera.GetAnyKeyFunc GetAnyKeyDown;
  public static UICamera.GetMouseDelegate GetMouse = (UICamera.GetMouseDelegate) (button => UICamera.mMouse[button]);
  public static UICamera.GetTouchDelegate GetTouch = (UICamera.GetTouchDelegate) ((id, createIfMissing) =>
  {
    if (id < 0)
      return UICamera.GetMouse(-id - 1);
    int index = 0;
    for (int count = UICamera.mTouchIDs.Count; index < count; ++index)
    {
      if (UICamera.mTouchIDs[index] == id)
        return UICamera.activeTouches[index];
    }
    if (!createIfMissing)
      return (UICamera.MouseOrTouch) null;
    UICamera.MouseOrTouch mouseOrTouch = new UICamera.MouseOrTouch();
    mouseOrTouch.pressTime = RealTime.time;
    mouseOrTouch.touchBegan = true;
    UICamera.activeTouches.Add(mouseOrTouch);
    UICamera.mTouchIDs.Add(id);
    return mouseOrTouch;
  });
  public static UICamera.RemoveTouchDelegate RemoveTouch = (UICamera.RemoveTouchDelegate) (id =>
  {
    int index = 0;
    for (int count = UICamera.mTouchIDs.Count; index < count; ++index)
    {
      if (UICamera.mTouchIDs[index] == id)
      {
        UICamera.mTouchIDs.RemoveAt(index);
        UICamera.activeTouches.RemoveAt(index);
        break;
      }
    }
  });
  public static UICamera.OnScreenResize onScreenResize;
  public UICamera.EventType eventType = UICamera.EventType.UI_3D;
  public bool eventsGoToColliders;
  public LayerMask eventReceiverMask = (LayerMask) -1;
  public UICamera.ProcessEventsIn processEventsIn;
  public bool debug;
  public bool useMouse = true;
  public bool useTouch = true;
  public bool allowMultiTouch = true;
  public bool useKeyboard = true;
  public bool useController = true;
  public bool stickyTooltip = true;
  public float tooltipDelay = 1f;
  public bool longPressTooltip;
  public float mouseDragThreshold = 4f;
  public float mouseClickThreshold = 10f;
  public float touchDragThreshold = 40f;
  public float touchClickThreshold = 40f;
  public float rangeDistance = -1f;
  public string horizontalAxisName = "Horizontal";
  public string verticalAxisName = "Vertical";
  public string horizontalPanAxisName;
  public string verticalPanAxisName;
  public string scrollAxisName = "Mouse ScrollWheel";
  [Tooltip("If enabled, command-click will result in a right-click event on OSX")]
  public bool commandClick = true;
  public KeyCode submitKey0 = KeyCode.Return;
  public KeyCode submitKey1 = KeyCode.JoystickButton0;
  public KeyCode cancelKey0 = KeyCode.Escape;
  public KeyCode cancelKey1 = KeyCode.JoystickButton1;
  public bool autoHideCursor = true;
  public static UICamera.OnCustomInput onCustomInput;
  public static bool showTooltips = true;
  public static bool ignoreAllEvents = false;
  public static bool ignoreControllerInput = false;
  private static bool mDisableController = false;
  private static Vector2 mLastPos = Vector2.zero;
  public static Vector3 lastWorldPosition = Vector3.zero;
  public static Ray lastWorldRay = new Ray();
  public static RaycastHit lastHit;
  public static UICamera current = (UICamera) null;
  public static Camera currentCamera = (Camera) null;
  public static UICamera.OnSchemeChange onSchemeChange;
  private static UICamera.ControlScheme mLastScheme = UICamera.ControlScheme.Mouse;
  public static int currentTouchID = -100;
  private static KeyCode mCurrentKey = KeyCode.Alpha0;
  [NonSerialized]
  public static UICamera.MouseOrTouch currentTouch = (UICamera.MouseOrTouch) null;
  [NonSerialized]
  private static bool mInputFocus = false;
  [NonSerialized]
  private static GameObject mGenericHandler;
  [NonSerialized]
  public static GameObject fallThrough;
  [NonSerialized]
  public static UICamera.VoidDelegate onClick;
  [NonSerialized]
  public static UICamera.VoidDelegate onDoubleClick;
  [NonSerialized]
  public static UICamera.BoolDelegate onHover;
  [NonSerialized]
  public static UICamera.BoolDelegate onPress;
  [NonSerialized]
  public static UICamera.BoolDelegate onSelect;
  [NonSerialized]
  public static UICamera.FloatDelegate onScroll;
  [NonSerialized]
  public static UICamera.VectorDelegate onDrag;
  [NonSerialized]
  public static UICamera.VoidDelegate onDragStart;
  [NonSerialized]
  public static UICamera.ObjectDelegate onDragOver;
  [NonSerialized]
  public static UICamera.ObjectDelegate onDragOut;
  [NonSerialized]
  public static UICamera.VoidDelegate onDragEnd;
  [NonSerialized]
  public static UICamera.ObjectDelegate onDrop;
  [NonSerialized]
  public static UICamera.KeyCodeDelegate onKey;
  [NonSerialized]
  public static UICamera.KeyCodeDelegate onNavigate;
  [NonSerialized]
  public static UICamera.VectorDelegate onPan;
  [NonSerialized]
  public static UICamera.BoolDelegate onTooltip;
  [NonSerialized]
  public static UICamera.MoveDelegate onMouseMove;
  private static UICamera.MouseOrTouch[] mMouse = new UICamera.MouseOrTouch[3]
  {
    new UICamera.MouseOrTouch(),
    new UICamera.MouseOrTouch(),
    new UICamera.MouseOrTouch()
  };
  [NonSerialized]
  public static UICamera.MouseOrTouch controller = new UICamera.MouseOrTouch();
  [NonSerialized]
  public static List<UICamera.MouseOrTouch> activeTouches = new List<UICamera.MouseOrTouch>();
  [NonSerialized]
  private static List<int> mTouchIDs = new List<int>();
  [NonSerialized]
  private static int mWidth = 0;
  [NonSerialized]
  private static int mHeight = 0;
  [NonSerialized]
  private static GameObject mTooltip = (GameObject) null;
  [NonSerialized]
  private Camera mCam;
  [NonSerialized]
  private static float mTooltipTime = 0.0f;
  [NonSerialized]
  private float mNextRaycast;
  [NonSerialized]
  public static bool isDragging = false;
  private static int mLastInteractionCheck = -1;
  private static bool mLastInteractionResult = false;
  private static int mLastFocusCheck = -1;
  private static bool mLastFocusResult = false;
  private static int mLastOverCheck = -1;
  private static bool mLastOverResult = false;
  private static GameObject mRayHitObject;
  private static GameObject mHover;
  private static GameObject mSelected;
  private static UICamera.DepthEntry mHit = new UICamera.DepthEntry();
  private static BetterList<UICamera.DepthEntry> mHits = new BetterList<UICamera.DepthEntry>();
  private static RaycastHit[] mRayHits;
  private static Collider2D[] mOverlap;
  private static Plane m2DPlane = new Plane(Vector3.back, 0.0f);
  private static float mNextEvent = 0.0f;
  private static int mNotifying = 0;
  private static bool disableControllerCheck = true;
  private static bool mUsingTouchEvents = true;
  public static UICamera.GetTouchCountCallback GetInputTouchCount;
  public static UICamera.GetTouchCallback GetInputTouch;

  [Obsolete("Use new OnDragStart / OnDragOver / OnDragOut / OnDragEnd events instead")]
  public bool stickyPress => true;

  public static bool disableController
  {
    get => UICamera.mDisableController && !UIPopupList.isOpen;
    set => UICamera.mDisableController = value;
  }

  [Obsolete("Use lastEventPosition instead. It handles controller input properly.")]
  public static Vector2 lastTouchPosition
  {
    get => UICamera.mLastPos;
    set => UICamera.mLastPos = value;
  }

  public static Vector2 lastEventPosition
  {
    get
    {
      if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      {
        GameObject hoveredObject = UICamera.hoveredObject;
        if ((UnityEngine.Object) hoveredObject != (UnityEngine.Object) null)
        {
          Bounds absoluteWidgetBounds = NGUIMath.CalculateAbsoluteWidgetBounds(hoveredObject.transform);
          return (Vector2) NGUITools.FindCameraForLayer(hoveredObject.layer).WorldToScreenPoint(absoluteWidgetBounds.center);
        }
      }
      return UICamera.mLastPos;
    }
    set => UICamera.mLastPos = value;
  }

  public static UICamera first => UICamera.list == null || UICamera.list.size == 0 ? (UICamera) null : UICamera.list.buffer[0];

  public static UICamera.ControlScheme currentScheme
  {
    get
    {
      if (UICamera.mCurrentKey == KeyCode.None)
        return UICamera.ControlScheme.Touch;
      if (UICamera.mCurrentKey >= KeyCode.JoystickButton0)
        return UICamera.ControlScheme.Controller;
      if (!((UnityEngine.Object) UICamera.current != (UnityEngine.Object) null))
        return UICamera.ControlScheme.Mouse;
      if (UICamera.mLastScheme == UICamera.ControlScheme.Controller && (UICamera.mCurrentKey == UICamera.current.submitKey0 || UICamera.mCurrentKey == UICamera.current.submitKey1))
        return UICamera.ControlScheme.Controller;
      if (UICamera.current.useMouse)
        return UICamera.ControlScheme.Mouse;
      return UICamera.current.useTouch ? UICamera.ControlScheme.Touch : UICamera.ControlScheme.Controller;
    }
    set
    {
      if (UICamera.mLastScheme == value)
        return;
      switch (value)
      {
        case UICamera.ControlScheme.Mouse:
          UICamera.currentKey = KeyCode.Mouse0;
          break;
        case UICamera.ControlScheme.Touch:
          UICamera.currentKey = KeyCode.None;
          break;
        case UICamera.ControlScheme.Controller:
          UICamera.currentKey = KeyCode.JoystickButton0;
          break;
        default:
          UICamera.currentKey = KeyCode.Alpha0;
          break;
      }
      UICamera.mLastScheme = value;
    }
  }

  public static KeyCode currentKey
  {
    get => UICamera.mCurrentKey;
    set
    {
      if (UICamera.mCurrentKey == value)
        return;
      int mLastScheme1 = (int) UICamera.mLastScheme;
      UICamera.mCurrentKey = value;
      UICamera.mLastScheme = UICamera.currentScheme;
      int mLastScheme2 = (int) UICamera.mLastScheme;
      if (mLastScheme1 == mLastScheme2)
        return;
      UICamera.HideTooltip();
      if (UICamera.mLastScheme == UICamera.ControlScheme.Mouse)
      {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      }
      else if ((UnityEngine.Object) UICamera.current != (UnityEngine.Object) null && UICamera.current.autoHideCursor)
      {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UICamera.mMouse[0].ignoreDelta = 2;
      }
      if (UICamera.onSchemeChange == null)
        return;
      UICamera.onSchemeChange();
    }
  }

  public static Ray currentRay => !((UnityEngine.Object) UICamera.currentCamera != (UnityEngine.Object) null) || UICamera.currentTouch == null ? new Ray() : UICamera.currentCamera.ScreenPointToRay((Vector3) UICamera.currentTouch.pos);

  public static bool inputHasFocus => UICamera.mInputFocus && (bool) (UnityEngine.Object) UICamera.mSelected && UICamera.mSelected.activeInHierarchy;

  [Obsolete("Use delegates instead such as UICamera.onClick, UICamera.onHover, etc.")]
  public static GameObject genericEventHandler
  {
    get => UICamera.mGenericHandler;
    set => UICamera.mGenericHandler = value;
  }

  public static UICamera.MouseOrTouch mouse0 => UICamera.mMouse[0];

  public static UICamera.MouseOrTouch mouse1 => UICamera.mMouse[1];

  public static UICamera.MouseOrTouch mouse2 => UICamera.mMouse[2];

  private bool handlesEvents => (UnityEngine.Object) UICamera.eventHandler == (UnityEngine.Object) this;

  public Camera cachedCamera
  {
    get
    {
      if ((UnityEngine.Object) this.mCam == (UnityEngine.Object) null)
        this.mCam = this.GetComponent<Camera>();
      return this.mCam;
    }
  }

  public static GameObject tooltipObject
  {
    get => UICamera.mTooltip;
    set => UICamera.ShowTooltip(value);
  }

  public static bool IsPartOfUI(GameObject go) => !((UnityEngine.Object) go == (UnityEngine.Object) null) && !((UnityEngine.Object) go == (UnityEngine.Object) UICamera.fallThrough) && (UnityEngine.Object) NGUITools.FindInParents<UIRoot>(go) != (UnityEngine.Object) null;

  public static bool isOverUI
  {
    get
    {
      int frameCount = Time.frameCount;
      if (UICamera.mLastOverCheck != frameCount)
      {
        UICamera.mLastOverCheck = frameCount;
        if (UICamera.currentTouch != null)
        {
          if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
          {
            UICamera.mLastOverResult = UICamera.IsPartOfUI(UICamera.currentTouch.pressed);
            return UICamera.mLastOverResult;
          }
          UICamera.mLastOverResult = UICamera.IsPartOfUI(UICamera.currentTouch.current);
          return UICamera.mLastOverResult;
        }
        int index1 = 0;
        for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
        {
          if (UICamera.IsPartOfUI(UICamera.activeTouches[index1].pressed))
          {
            UICamera.mLastOverResult = true;
            return UICamera.mLastOverResult;
          }
        }
        for (int index2 = 0; index2 < 3; ++index2)
        {
          UICamera.MouseOrTouch mouseOrTouch = UICamera.mMouse[index2];
          if (UICamera.IsPartOfUI((UnityEngine.Object) mouseOrTouch.pressed != (UnityEngine.Object) null ? mouseOrTouch.pressed : (index2 == 0 ? mouseOrTouch.current : (GameObject) null)))
          {
            UICamera.mLastOverResult = true;
            return UICamera.mLastOverResult;
          }
        }
        UICamera.mLastOverResult = UICamera.IsPartOfUI(UICamera.controller.pressed);
      }
      return UICamera.mLastOverResult;
    }
  }

  public static bool uiHasFocus
  {
    get
    {
      int frameCount = Time.frameCount;
      if (UICamera.mLastFocusCheck != frameCount)
      {
        UICamera.mLastFocusCheck = frameCount;
        if (UICamera.inputHasFocus)
        {
          UICamera.mLastFocusResult = true;
          return UICamera.mLastFocusResult;
        }
        if (UICamera.currentTouch != null)
        {
          UICamera.mLastFocusResult = UICamera.currentTouch.isOverUI;
          return UICamera.mLastFocusResult;
        }
        int index1 = 0;
        for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
        {
          if (UICamera.IsPartOfUI(UICamera.activeTouches[index1].pressed))
          {
            UICamera.mLastFocusResult = true;
            return UICamera.mLastFocusResult;
          }
        }
        UICamera.MouseOrTouch mouseOrTouch = UICamera.mMouse[0];
        if (UICamera.IsPartOfUI(mouseOrTouch.pressed) || UICamera.IsPartOfUI(mouseOrTouch.current))
        {
          UICamera.mLastFocusResult = true;
          return UICamera.mLastFocusResult;
        }
        for (int index2 = 1; index2 < 3; ++index2)
        {
          if (UICamera.IsPartOfUI(UICamera.mMouse[index2].pressed))
          {
            UICamera.mLastFocusResult = true;
            return UICamera.mLastFocusResult;
          }
        }
        UICamera.mLastFocusResult = UICamera.IsPartOfUI(UICamera.controller.pressed);
      }
      return UICamera.mLastFocusResult;
    }
  }

  public static bool interactingWithUI
  {
    get
    {
      int frameCount = Time.frameCount;
      if (UICamera.mLastInteractionCheck != frameCount)
      {
        UICamera.mLastInteractionCheck = frameCount;
        if (UICamera.inputHasFocus)
        {
          UICamera.mLastInteractionResult = true;
          return UICamera.mLastInteractionResult;
        }
        int index1 = 0;
        for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
        {
          if (UICamera.IsPartOfUI(UICamera.activeTouches[index1].pressed))
          {
            UICamera.mLastInteractionResult = true;
            return UICamera.mLastInteractionResult;
          }
        }
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (UICamera.IsPartOfUI(UICamera.mMouse[index2].pressed))
          {
            UICamera.mLastInteractionResult = true;
            return UICamera.mLastInteractionResult;
          }
        }
        UICamera.mLastInteractionResult = UICamera.IsPartOfUI(UICamera.controller.pressed);
      }
      return UICamera.mLastInteractionResult;
    }
  }

  public static GameObject hoveredObject
  {
    get
    {
      if (UICamera.currentTouch != null && (UICamera.currentScheme != UICamera.ControlScheme.Mouse || UICamera.currentTouch.dragStarted))
        return UICamera.currentTouch.current;
      if ((bool) (UnityEngine.Object) UICamera.mHover && UICamera.mHover.activeInHierarchy)
        return UICamera.mHover;
      UICamera.mHover = (GameObject) null;
      return (GameObject) null;
    }
    set
    {
      if ((UnityEngine.Object) UICamera.mHover == (UnityEngine.Object) value)
        return;
      bool flag = false;
      UICamera current = UICamera.current;
      if (UICamera.currentTouch == null)
      {
        flag = true;
        UICamera.currentTouchID = -100;
        UICamera.currentTouch = UICamera.controller;
      }
      UICamera.ShowTooltip((GameObject) null);
      if ((bool) (UnityEngine.Object) UICamera.mSelected && UICamera.currentScheme == UICamera.ControlScheme.Controller)
      {
        UICamera.Notify(UICamera.mSelected, "OnSelect", (object) false);
        if (UICamera.onSelect != null)
          UICamera.onSelect(UICamera.mSelected, false);
        UICamera.mSelected = (GameObject) null;
      }
      if ((bool) (UnityEngine.Object) UICamera.mHover)
      {
        UICamera.Notify(UICamera.mHover, "OnHover", (object) false);
        if (UICamera.onHover != null)
          UICamera.onHover(UICamera.mHover, false);
      }
      UICamera.mHover = value;
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      if ((bool) (UnityEngine.Object) UICamera.mHover)
      {
        if ((UnityEngine.Object) UICamera.mHover != (UnityEngine.Object) UICamera.controller.current && (UnityEngine.Object) UICamera.mHover.GetComponent<UIKeyNavigation>() != (UnityEngine.Object) null)
          UICamera.controller.current = UICamera.mHover;
        if (flag)
        {
          UICamera uiCamera = (UnityEngine.Object) UICamera.mHover != (UnityEngine.Object) null ? UICamera.FindCameraForLayer(UICamera.mHover.layer) : UICamera.list.buffer[0];
          if ((UnityEngine.Object) uiCamera != (UnityEngine.Object) null)
          {
            UICamera.current = uiCamera;
            UICamera.currentCamera = uiCamera.cachedCamera;
          }
        }
        if (UICamera.onHover != null)
          UICamera.onHover(UICamera.mHover, true);
        UICamera.Notify(UICamera.mHover, "OnHover", (object) true);
      }
      if (!flag)
        return;
      UICamera.current = current;
      UICamera.currentCamera = (UnityEngine.Object) current != (UnityEngine.Object) null ? current.cachedCamera : (Camera) null;
      UICamera.currentTouch = (UICamera.MouseOrTouch) null;
      UICamera.currentTouchID = -100;
    }
  }

  public static GameObject controllerNavigationObject
  {
    get
    {
      if ((bool) (UnityEngine.Object) UICamera.controller.current && UICamera.controller.current.activeInHierarchy)
        return UICamera.controller.current;
      if (UICamera.currentScheme == UICamera.ControlScheme.Controller && (UnityEngine.Object) UICamera.current != (UnityEngine.Object) null && UICamera.current.useController && !UICamera.ignoreControllerInput && UIKeyNavigation.list.size > 0)
      {
        for (int index = 0; index < UIKeyNavigation.list.size; ++index)
        {
          UIKeyNavigation uiKeyNavigation = UIKeyNavigation.list.buffer[index];
          if ((bool) (UnityEngine.Object) uiKeyNavigation && uiKeyNavigation.constraint != UIKeyNavigation.Constraint.Explicit && uiKeyNavigation.startsSelected)
          {
            UICamera.hoveredObject = uiKeyNavigation.gameObject;
            UICamera.controller.current = UICamera.mHover;
            return UICamera.mHover;
          }
        }
        if ((UnityEngine.Object) UICamera.mHover == (UnityEngine.Object) null)
        {
          for (int index = 0; index < UIKeyNavigation.list.size; ++index)
          {
            UIKeyNavigation uiKeyNavigation = UIKeyNavigation.list.buffer[index];
            if ((bool) (UnityEngine.Object) uiKeyNavigation && uiKeyNavigation.constraint != UIKeyNavigation.Constraint.Explicit)
            {
              UICamera.hoveredObject = uiKeyNavigation.gameObject;
              UICamera.controller.current = UICamera.mHover;
              return UICamera.mHover;
            }
          }
        }
      }
      UICamera.controller.current = (GameObject) null;
      return (GameObject) null;
    }
    set
    {
      if ((UnityEngine.Object) UICamera.controller.current != (UnityEngine.Object) value && (bool) (UnityEngine.Object) UICamera.controller.current)
      {
        UICamera.Notify(UICamera.controller.current, "OnHover", (object) false);
        if (UICamera.onHover != null)
          UICamera.onHover(UICamera.controller.current, false);
        UICamera.controller.current = (GameObject) null;
      }
      UICamera.hoveredObject = value;
    }
  }

  public static GameObject selectedObject
  {
    get
    {
      if ((bool) (UnityEngine.Object) UICamera.mSelected && UICamera.mSelected.activeInHierarchy)
        return UICamera.mSelected;
      UICamera.mSelected = (GameObject) null;
      return (GameObject) null;
    }
    set
    {
      if ((UnityEngine.Object) UICamera.mSelected == (UnityEngine.Object) value)
      {
        UICamera.hoveredObject = value;
        UICamera.controller.current = value;
      }
      else
      {
        UICamera.ShowTooltip((GameObject) null);
        bool flag = false;
        UICamera current = UICamera.current;
        if (UICamera.currentTouch == null)
        {
          flag = true;
          UICamera.currentTouchID = -100;
          UICamera.currentTouch = UICamera.controller;
        }
        UICamera.mInputFocus = false;
        if ((bool) (UnityEngine.Object) UICamera.mSelected)
        {
          UICamera.Notify(UICamera.mSelected, "OnSelect", (object) false);
          if (UICamera.onSelect != null)
            UICamera.onSelect(UICamera.mSelected, false);
        }
        UICamera.mSelected = value;
        UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
        if ((UnityEngine.Object) value != (UnityEngine.Object) null && (UnityEngine.Object) value.GetComponent<UIKeyNavigation>() != (UnityEngine.Object) null)
          UICamera.controller.current = value;
        if ((bool) (UnityEngine.Object) UICamera.mSelected & flag)
        {
          UICamera uiCamera = (UnityEngine.Object) UICamera.mSelected != (UnityEngine.Object) null ? UICamera.FindCameraForLayer(UICamera.mSelected.layer) : UICamera.list.buffer[0];
          if ((UnityEngine.Object) uiCamera != (UnityEngine.Object) null)
          {
            UICamera.current = uiCamera;
            UICamera.currentCamera = uiCamera.cachedCamera;
          }
        }
        if ((bool) (UnityEngine.Object) UICamera.mSelected)
        {
          UICamera.mInputFocus = UICamera.mSelected.activeInHierarchy && (UnityEngine.Object) UICamera.mSelected.GetComponent<UIInput>() != (UnityEngine.Object) null;
          if (UICamera.onSelect != null)
            UICamera.onSelect(UICamera.mSelected, true);
          UICamera.Notify(UICamera.mSelected, "OnSelect", (object) true);
        }
        if (!flag)
          return;
        UICamera.current = current;
        UICamera.currentCamera = (UnityEngine.Object) current != (UnityEngine.Object) null ? current.cachedCamera : (Camera) null;
        UICamera.currentTouch = (UICamera.MouseOrTouch) null;
        UICamera.currentTouchID = -100;
      }
    }
  }

  public static bool IsPressed(GameObject go)
  {
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) UICamera.mMouse[index].pressed == (UnityEngine.Object) go)
        return true;
    }
    int index1 = 0;
    for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
    {
      if ((UnityEngine.Object) UICamera.activeTouches[index1].pressed == (UnityEngine.Object) go)
        return true;
    }
    return (UnityEngine.Object) UICamera.controller.pressed == (UnityEngine.Object) go;
  }

  [Obsolete("Use either 'CountInputSources()' or 'activeTouches.Count'")]
  public static int touchCount => UICamera.CountInputSources();

  public static int CountInputSources()
  {
    int num = 0;
    int index1 = 0;
    for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
    {
      if ((UnityEngine.Object) UICamera.activeTouches[index1].pressed != (UnityEngine.Object) null)
        ++num;
    }
    for (int index2 = 0; index2 < UICamera.mMouse.Length; ++index2)
    {
      if ((UnityEngine.Object) UICamera.mMouse[index2].pressed != (UnityEngine.Object) null)
        ++num;
    }
    if ((UnityEngine.Object) UICamera.controller.pressed != (UnityEngine.Object) null)
      ++num;
    return num;
  }

  public static int dragCount
  {
    get
    {
      int dragCount = 0;
      int index1 = 0;
      for (int count = UICamera.activeTouches.Count; index1 < count; ++index1)
      {
        if ((UnityEngine.Object) UICamera.activeTouches[index1].dragged != (UnityEngine.Object) null)
          ++dragCount;
      }
      for (int index2 = 0; index2 < UICamera.mMouse.Length; ++index2)
      {
        if ((UnityEngine.Object) UICamera.mMouse[index2].dragged != (UnityEngine.Object) null)
          ++dragCount;
      }
      if ((UnityEngine.Object) UICamera.controller.dragged != (UnityEngine.Object) null)
        ++dragCount;
      return dragCount;
    }
  }

  public static Camera mainCamera
  {
    get
    {
      UICamera eventHandler = UICamera.eventHandler;
      return !((UnityEngine.Object) eventHandler != (UnityEngine.Object) null) ? (Camera) null : eventHandler.cachedCamera;
    }
  }

  public static UICamera eventHandler
  {
    get
    {
      for (int index = 0; index < UICamera.list.size; ++index)
      {
        UICamera eventHandler = UICamera.list.buffer[index];
        if (!((UnityEngine.Object) eventHandler == (UnityEngine.Object) null) && eventHandler.enabled && NGUITools.GetActive(eventHandler.gameObject))
          return eventHandler;
      }
      return (UICamera) null;
    }
  }

  private static int CompareFunc(UICamera a, UICamera b)
  {
    if ((double) a.cachedCamera.depth < (double) b.cachedCamera.depth)
      return 1;
    return (double) a.cachedCamera.depth > (double) b.cachedCamera.depth ? -1 : 0;
  }

  private static Rigidbody FindRootRigidbody(Transform trans)
  {
    for (; (UnityEngine.Object) trans != (UnityEngine.Object) null && !((UnityEngine.Object) trans.GetComponent<UIPanel>() != (UnityEngine.Object) null); trans = trans.parent)
    {
      Rigidbody component = trans.GetComponent<Rigidbody>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        return component;
    }
    return (Rigidbody) null;
  }

  private static Rigidbody2D FindRootRigidbody2D(Transform trans)
  {
    for (; (UnityEngine.Object) trans != (UnityEngine.Object) null && !((UnityEngine.Object) trans.GetComponent<UIPanel>() != (UnityEngine.Object) null); trans = trans.parent)
    {
      Rigidbody2D component = trans.GetComponent<Rigidbody2D>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        return component;
    }
    return (Rigidbody2D) null;
  }

  public static void Raycast(UICamera.MouseOrTouch touch)
  {
    if (!UICamera.Raycast((Vector3) touch.pos))
      UICamera.mRayHitObject = UICamera.fallThrough;
    if ((UnityEngine.Object) UICamera.mRayHitObject == (UnityEngine.Object) null)
      UICamera.mRayHitObject = UICamera.mGenericHandler;
    touch.last = touch.current;
    touch.current = UICamera.mRayHitObject;
    UICamera.mLastPos = touch.pos;
  }

  public static bool Raycast(Vector3 inPos)
  {
    for (int index1 = 0; index1 < UICamera.list.size; ++index1)
    {
      UICamera uiCamera = UICamera.list.buffer[index1];
      if (uiCamera.enabled && NGUITools.GetActive(uiCamera.gameObject))
      {
        UICamera.currentCamera = uiCamera.cachedCamera;
        if (UICamera.currentCamera.targetDisplay == 0)
        {
          Vector3 viewportPoint = UICamera.currentCamera.ScreenToViewportPoint(inPos);
          if (!float.IsNaN(viewportPoint.x) && !float.IsNaN(viewportPoint.y) && (double) viewportPoint.x >= 0.0 && (double) viewportPoint.x <= 1.0 && (double) viewportPoint.y >= 0.0 && (double) viewportPoint.y <= 1.0)
          {
            Ray ray = UICamera.currentCamera.ScreenPointToRay(inPos);
            int layerMask = UICamera.currentCamera.cullingMask & (int) uiCamera.eventReceiverMask;
            float enter = (double) uiCamera.rangeDistance > 0.0 ? uiCamera.rangeDistance : UICamera.currentCamera.farClipPlane - UICamera.currentCamera.nearClipPlane;
            if (uiCamera.eventType == UICamera.EventType.World_3D)
            {
              UICamera.lastWorldRay = ray;
              if (Physics.Raycast(ray, out UICamera.lastHit, enter, layerMask, QueryTriggerInteraction.Ignore))
              {
                UICamera.lastWorldPosition = UICamera.lastHit.point;
                UICamera.mRayHitObject = UICamera.lastHit.collider.gameObject;
                if (!uiCamera.eventsGoToColliders)
                {
                  Rigidbody componentInParent = UICamera.mRayHitObject.gameObject.GetComponentInParent<Rigidbody>();
                  if ((UnityEngine.Object) componentInParent != (UnityEngine.Object) null)
                    UICamera.mRayHitObject = componentInParent.gameObject;
                }
                return true;
              }
            }
            else if (uiCamera.eventType == UICamera.EventType.UI_3D)
            {
              if (UICamera.mRayHits == null)
                UICamera.mRayHits = new RaycastHit[50];
              int num = Physics.RaycastNonAlloc(ray, UICamera.mRayHits, enter, layerMask, QueryTriggerInteraction.Collide);
              if (num > 1)
              {
                for (int index2 = 0; index2 < num; ++index2)
                {
                  GameObject gameObject = UICamera.mRayHits[index2].collider.gameObject;
                  UIWidget component = gameObject.GetComponent<UIWidget>();
                  if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                  {
                    if (!component.isVisible || component is UISpriteCollection && !(component as UISpriteCollection).GetCurrentSprite().HasValue || component.hitCheck != null && !component.hitCheck(UICamera.mRayHits[index2].point))
                      continue;
                  }
                  else
                  {
                    UIRect inParents = NGUITools.FindInParents<UIRect>(gameObject);
                    if ((UnityEngine.Object) inParents != (UnityEngine.Object) null && (double) inParents.finalAlpha < 1.0 / 1000.0)
                      continue;
                  }
                  UICamera.mHit.depth = NGUITools.CalculateRaycastDepth(gameObject);
                  if (UICamera.mHit.depth != int.MaxValue)
                  {
                    UICamera.mHit.hit = UICamera.mRayHits[index2];
                    UICamera.mHit.point = UICamera.mRayHits[index2].point;
                    UICamera.mHit.go = UICamera.mRayHits[index2].collider.gameObject;
                    UICamera.mHits.Add(UICamera.mHit);
                  }
                }
                UICamera.mHits.Sort((BetterList<UICamera.DepthEntry>.CompareFunc) ((r1, r2) => r2.depth.CompareTo(r1.depth)));
                for (int index3 = 0; index3 < UICamera.mHits.size; ++index3)
                {
                  if (UICamera.IsVisible(ref UICamera.mHits.buffer[index3]))
                  {
                    UICamera.lastHit = UICamera.mHits.buffer[index3].hit;
                    UICamera.mRayHitObject = UICamera.mHits.buffer[index3].go;
                    UICamera.lastWorldRay = ray;
                    UICamera.lastWorldPosition = UICamera.mHits.buffer[index3].point;
                    UICamera.mHits.Clear();
                    return true;
                  }
                }
                UICamera.mHits.Clear();
              }
              else if (num == 1)
              {
                GameObject gameObject = UICamera.mRayHits[0].collider.gameObject;
                UIWidget component = gameObject.GetComponent<UIWidget>();
                if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                {
                  if (!component.isVisible || component.hitCheck != null && !component.hitCheck(UICamera.mRayHits[0].point))
                    continue;
                }
                else
                {
                  UIRect inParents = NGUITools.FindInParents<UIRect>(gameObject);
                  if ((UnityEngine.Object) inParents != (UnityEngine.Object) null && (double) inParents.finalAlpha < 1.0 / 1000.0)
                    continue;
                }
                if (UICamera.IsVisible(UICamera.mRayHits[0].point, UICamera.mRayHits[0].collider.gameObject))
                {
                  UICamera.lastHit = UICamera.mRayHits[0];
                  UICamera.lastWorldRay = ray;
                  UICamera.lastWorldPosition = UICamera.mRayHits[0].point;
                  UICamera.mRayHitObject = UICamera.lastHit.collider.gameObject;
                  return true;
                }
              }
            }
            else if (uiCamera.eventType == UICamera.EventType.World_2D)
            {
              if (UICamera.m2DPlane.Raycast(ray, out enter))
              {
                Vector3 point = ray.GetPoint(enter);
                Collider2D collider2D = Physics2D.OverlapPoint((Vector2) point, layerMask);
                if ((bool) (UnityEngine.Object) collider2D)
                {
                  UICamera.lastWorldPosition = point;
                  UICamera.mRayHitObject = collider2D.gameObject;
                  if (!uiCamera.eventsGoToColliders)
                  {
                    Rigidbody2D rootRigidbody2D = UICamera.FindRootRigidbody2D(UICamera.mRayHitObject.transform);
                    if ((UnityEngine.Object) rootRigidbody2D != (UnityEngine.Object) null)
                      UICamera.mRayHitObject = rootRigidbody2D.gameObject;
                  }
                  return true;
                }
              }
            }
            else if (uiCamera.eventType == UICamera.EventType.UI_2D && UICamera.m2DPlane.Raycast(ray, out enter))
            {
              UICamera.lastWorldPosition = ray.GetPoint(enter);
              if (UICamera.mOverlap == null)
                UICamera.mOverlap = new Collider2D[50];
              int num = Physics2D.OverlapPointNonAlloc((Vector2) UICamera.lastWorldPosition, UICamera.mOverlap, layerMask);
              if (num > 1)
              {
                for (int index4 = 0; index4 < num; ++index4)
                {
                  GameObject gameObject = UICamera.mOverlap[index4].gameObject;
                  UIWidget component = gameObject.GetComponent<UIWidget>();
                  if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                  {
                    if (!component.isVisible || component.hitCheck != null && !component.hitCheck(UICamera.lastWorldPosition))
                      continue;
                  }
                  else
                  {
                    UIRect inParents = NGUITools.FindInParents<UIRect>(gameObject);
                    if ((UnityEngine.Object) inParents != (UnityEngine.Object) null && (double) inParents.finalAlpha < 1.0 / 1000.0)
                      continue;
                  }
                  UICamera.mHit.depth = NGUITools.CalculateRaycastDepth(gameObject);
                  if (UICamera.mHit.depth != int.MaxValue)
                  {
                    UICamera.mHit.go = gameObject;
                    UICamera.mHit.point = UICamera.lastWorldPosition;
                    UICamera.mHits.Add(UICamera.mHit);
                  }
                }
                UICamera.mHits.Sort((BetterList<UICamera.DepthEntry>.CompareFunc) ((r1, r2) => r2.depth.CompareTo(r1.depth)));
                for (int index5 = 0; index5 < UICamera.mHits.size; ++index5)
                {
                  if (UICamera.IsVisible(ref UICamera.mHits.buffer[index5]))
                  {
                    UICamera.mRayHitObject = UICamera.mHits.buffer[index5].go;
                    UICamera.mHits.Clear();
                    return true;
                  }
                }
                UICamera.mHits.Clear();
              }
              else if (num == 1)
              {
                GameObject gameObject = UICamera.mOverlap[0].gameObject;
                UIWidget component = gameObject.GetComponent<UIWidget>();
                if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                {
                  if (!component.isVisible || component.hitCheck != null && !component.hitCheck(UICamera.lastWorldPosition))
                    continue;
                }
                else
                {
                  UIRect inParents = NGUITools.FindInParents<UIRect>(gameObject);
                  if ((UnityEngine.Object) inParents != (UnityEngine.Object) null && (double) inParents.finalAlpha < 1.0 / 1000.0)
                    continue;
                }
                if (UICamera.IsVisible(UICamera.lastWorldPosition, gameObject))
                {
                  UICamera.mRayHitObject = gameObject;
                  return true;
                }
              }
            }
          }
        }
      }
    }
    return false;
  }

  private static bool IsVisible(Vector3 worldPoint, GameObject go)
  {
    for (UIPanel uiPanel = NGUITools.FindInParents<UIPanel>(go); (UnityEngine.Object) uiPanel != (UnityEngine.Object) null; uiPanel = uiPanel.parentPanel)
    {
      if (!uiPanel.IsVisible(worldPoint))
        return false;
    }
    return true;
  }

  private static bool IsVisible(ref UICamera.DepthEntry de)
  {
    for (UIPanel uiPanel = NGUITools.FindInParents<UIPanel>(de.go); (UnityEngine.Object) uiPanel != (UnityEngine.Object) null; uiPanel = uiPanel.parentPanel)
    {
      if (!uiPanel.IsVisible(de.point))
        return false;
    }
    return true;
  }

  public static bool IsHighlighted(GameObject go) => (UnityEngine.Object) UICamera.hoveredObject == (UnityEngine.Object) go;

  public static UICamera FindCameraForLayer(int layer)
  {
    int num = 1 << layer;
    for (int index = 0; index < UICamera.list.size; ++index)
    {
      UICamera cameraForLayer = UICamera.list.buffer[index];
      Camera cachedCamera = cameraForLayer.cachedCamera;
      if ((UnityEngine.Object) cachedCamera != (UnityEngine.Object) null && (cachedCamera.cullingMask & num) != 0)
        return cameraForLayer;
    }
    return (UICamera) null;
  }

  private static int GetDirection(KeyCode up, KeyCode down)
  {
    if (UICamera.GetKeyDown(up))
    {
      UICamera.currentKey = up;
      return 1;
    }
    if (!UICamera.GetKeyDown(down))
      return 0;
    UICamera.currentKey = down;
    return -1;
  }

  private static int GetDirection(KeyCode up0, KeyCode up1, KeyCode down0, KeyCode down1)
  {
    if (UICamera.GetKeyDown(up0))
    {
      UICamera.currentKey = up0;
      return 1;
    }
    if (UICamera.GetKeyDown(up1))
    {
      UICamera.currentKey = up1;
      return 1;
    }
    if (UICamera.GetKeyDown(down0))
    {
      UICamera.currentKey = down0;
      return -1;
    }
    if (!UICamera.GetKeyDown(down1))
      return 0;
    UICamera.currentKey = down1;
    return -1;
  }

  private static int GetDirection(string axis)
  {
    float time = RealTime.time;
    if ((double) UICamera.mNextEvent < (double) time && !string.IsNullOrEmpty(axis))
    {
      float num = UICamera.GetAxis(axis);
      if ((double) num > 0.75)
      {
        UICamera.currentKey = KeyCode.JoystickButton0;
        UICamera.mNextEvent = time + 0.25f;
        return 1;
      }
      if ((double) num < -0.75)
      {
        UICamera.currentKey = KeyCode.JoystickButton0;
        UICamera.mNextEvent = time + 0.25f;
        return -1;
      }
    }
    return 0;
  }

  public static void Notify(GameObject go, string funcName, object obj)
  {
    if (UICamera.mNotifying > 10)
      return;
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller && UIPopupList.isOpen && (UnityEngine.Object) UIPopupList.current.source == (UnityEngine.Object) go && UIPopupList.isOpen)
      go = UIPopupList.current.gameObject;
    if (!(bool) (UnityEngine.Object) go || !go.activeInHierarchy)
      return;
    ++UICamera.mNotifying;
    go.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
    if ((UnityEngine.Object) UICamera.mGenericHandler != (UnityEngine.Object) null && (UnityEngine.Object) UICamera.mGenericHandler != (UnityEngine.Object) go)
      UICamera.mGenericHandler.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
    --UICamera.mNotifying;
  }

  private void Awake()
  {
    UICamera.mWidth = Screen.width;
    UICamera.mHeight = Screen.height;
    if (Application.platform == RuntimePlatform.PS4 || Application.platform == RuntimePlatform.XboxOne)
      UICamera.currentScheme = UICamera.ControlScheme.Controller;
    UICamera.mMouse[0].pos = (Vector2) Input.mousePosition;
    for (int index = 1; index < 3; ++index)
    {
      UICamera.mMouse[index].pos = UICamera.mMouse[0].pos;
      UICamera.mMouse[index].lastPos = UICamera.mMouse[0].pos;
    }
    UICamera.mLastPos = UICamera.mMouse[0].pos;
    string[] commandLineArgs = Environment.GetCommandLineArgs();
    if (commandLineArgs == null)
      return;
    for (int index = 0; index < commandLineArgs.Length; ++index)
    {
      string str = commandLineArgs[index];
      if (str == "-noMouse")
        this.useMouse = false;
      else if (str == "-noTouch")
        this.useTouch = false;
      else if (str == "-noController")
      {
        this.useController = false;
        UICamera.ignoreControllerInput = true;
      }
      else if (str == "-noJoystick")
      {
        this.useController = false;
        UICamera.ignoreControllerInput = true;
      }
      else if (str == "-useMouse")
        this.useMouse = true;
      else if (str == "-useTouch")
        this.useTouch = true;
      else if (str == "-useController")
        this.useController = true;
      else if (str == "-useJoystick")
        this.useController = true;
    }
  }

  private void OnEnable()
  {
    UICamera.list.Add(this);
    UICamera.list.Sort(new BetterList<UICamera>.CompareFunc(UICamera.CompareFunc));
  }

  private void OnDisable() => UICamera.list.Remove(this);

  private void Start()
  {
    UICamera.list.Sort(new BetterList<UICamera>.CompareFunc(UICamera.CompareFunc));
    if (this.eventType != UICamera.EventType.World_3D && this.cachedCamera.transparencySortMode != TransparencySortMode.Orthographic)
      this.cachedCamera.transparencySortMode = TransparencySortMode.Orthographic;
    if (!Application.isPlaying)
      return;
    if ((UnityEngine.Object) UICamera.fallThrough == (UnityEngine.Object) null)
    {
      UIRoot inParents = NGUITools.FindInParents<UIRoot>(this.gameObject);
      UICamera.fallThrough = (UnityEngine.Object) inParents != (UnityEngine.Object) null ? inParents.gameObject : this.gameObject;
    }
    this.cachedCamera.eventMask = 0;
    if (UICamera.ignoreControllerInput || !UICamera.disableControllerCheck || !this.useController || !this.handlesEvents)
      return;
    UICamera.disableControllerCheck = false;
    if (!string.IsNullOrEmpty(this.horizontalAxisName) && (double) Mathf.Abs(UICamera.GetAxis(this.horizontalAxisName)) > 0.10000000149011612)
      UICamera.ignoreControllerInput = true;
    else if (!string.IsNullOrEmpty(this.verticalAxisName) && (double) Mathf.Abs(UICamera.GetAxis(this.verticalAxisName)) > 0.10000000149011612)
      UICamera.ignoreControllerInput = true;
    else if (!string.IsNullOrEmpty(this.horizontalPanAxisName) && (double) Mathf.Abs(UICamera.GetAxis(this.horizontalPanAxisName)) > 0.10000000149011612)
    {
      UICamera.ignoreControllerInput = true;
    }
    else
    {
      if (string.IsNullOrEmpty(this.verticalPanAxisName) || (double) Mathf.Abs(UICamera.GetAxis(this.verticalPanAxisName)) <= 0.10000000149011612)
        return;
      UICamera.ignoreControllerInput = true;
    }
  }

  [ContextMenu("Start ignoring events")]
  private void StartIgnoring() => UICamera.ignoreAllEvents = true;

  [ContextMenu("Stop ignoring events")]
  private void StopIgnoring() => UICamera.ignoreAllEvents = false;

  private void Update()
  {
    if (UICamera.ignoreAllEvents || !this.handlesEvents || this.processEventsIn != UICamera.ProcessEventsIn.Update)
      return;
    this.ProcessEvents();
  }

  private void LateUpdate()
  {
    if (!this.handlesEvents)
      return;
    if (this.processEventsIn == UICamera.ProcessEventsIn.LateUpdate)
      this.ProcessEvents();
    int width = Screen.width;
    int height = Screen.height;
    if (width == UICamera.mWidth && height == UICamera.mHeight)
      return;
    UICamera.mWidth = width;
    UICamera.mHeight = height;
    UIRoot.Broadcast("UpdateAnchors");
    if (UICamera.onScreenResize == null)
      return;
    UICamera.onScreenResize();
  }

  private void ProcessEvents()
  {
    UICamera.current = this;
    NGUIDebug.debugRaycast = this.debug;
    if (this.useTouch)
      this.ProcessTouches();
    else if (this.useMouse)
      this.ProcessMouse();
    if (UICamera.onCustomInput != null)
      UICamera.onCustomInput();
    if ((this.useKeyboard || this.useController) && !UICamera.disableController && !UICamera.ignoreControllerInput)
      this.ProcessOthers();
    if (this.useMouse && (UnityEngine.Object) UICamera.mHover != (UnityEngine.Object) null)
    {
      float delta = !string.IsNullOrEmpty(this.scrollAxisName) ? UICamera.GetAxis(this.scrollAxisName) : 0.0f;
      if ((double) delta != 0.0)
      {
        if (UICamera.onScroll != null)
          UICamera.onScroll(UICamera.mHover, delta);
        UICamera.Notify(UICamera.mHover, "OnScroll", (object) delta);
      }
      if (UICamera.currentScheme == UICamera.ControlScheme.Mouse && UICamera.showTooltips && (double) UICamera.mTooltipTime != 0.0 && !UIPopupList.isOpen && (UnityEngine.Object) UICamera.mMouse[0].dragged == (UnityEngine.Object) null && ((double) UICamera.mTooltipTime < (double) Time.unscaledTime || UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift)))
      {
        UICamera.currentTouch = UICamera.mMouse[0];
        UICamera.currentTouchID = -1;
        UICamera.ShowTooltip(UICamera.mHover);
      }
    }
    if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null && !NGUITools.GetActive(UICamera.mTooltip))
      UICamera.ShowTooltip((GameObject) null);
    UICamera.current = (UICamera) null;
    UICamera.currentTouchID = -100;
  }

  public void ProcessMouse()
  {
    bool flag1 = false;
    bool flag2 = false;
    for (int button = 0; button < 3; ++button)
    {
      if (Input.GetMouseButtonDown(button))
      {
        UICamera.currentKey = (KeyCode) (323 + button);
        flag2 = true;
        flag1 = true;
      }
      else if (Input.GetMouseButton(button))
      {
        UICamera.currentKey = (KeyCode) (323 + button);
        flag1 = true;
      }
    }
    if (UICamera.currentScheme == UICamera.ControlScheme.Touch && UICamera.activeTouches.Count > 0)
      return;
    UICamera.currentTouch = UICamera.mMouse[0];
    Vector2 mousePosition = (Vector2) Input.mousePosition;
    if (UICamera.currentTouch.ignoreDelta == 0)
    {
      UICamera.currentTouch.delta = mousePosition - UICamera.currentTouch.pos;
    }
    else
    {
      --UICamera.currentTouch.ignoreDelta;
      UICamera.currentTouch.delta.x = 0.0f;
      UICamera.currentTouch.delta.y = 0.0f;
    }
    float sqrMagnitude = UICamera.currentTouch.delta.sqrMagnitude;
    UICamera.currentTouch.pos = mousePosition;
    UICamera.mLastPos = mousePosition;
    bool flag3 = false;
    if (UICamera.currentScheme != UICamera.ControlScheme.Mouse)
    {
      if ((double) sqrMagnitude < 1.0 / 1000.0)
        return;
      UICamera.currentKey = KeyCode.Mouse0;
      flag3 = true;
    }
    else if ((double) sqrMagnitude > 1.0 / 1000.0)
      flag3 = true;
    for (int index = 1; index < 3; ++index)
    {
      UICamera.mMouse[index].pos = UICamera.currentTouch.pos;
      UICamera.mMouse[index].delta = UICamera.currentTouch.delta;
    }
    if (flag1 | flag3 || (double) this.mNextRaycast < (double) RealTime.time)
    {
      this.mNextRaycast = RealTime.time + 0.02f;
      UICamera.Raycast(UICamera.currentTouch);
      if (flag1)
      {
        flag3 = true;
        for (int index = 1; index < 3; ++index)
          UICamera.mMouse[index].current = UICamera.currentTouch.current;
      }
      else if ((UnityEngine.Object) UICamera.mMouse[0].current != (UnityEngine.Object) UICamera.currentTouch.current)
      {
        UICamera.currentKey = KeyCode.Mouse0;
        flag3 = true;
        for (int index = 1; index < 3; ++index)
          UICamera.mMouse[index].current = UICamera.currentTouch.current;
      }
    }
    bool flag4 = (UnityEngine.Object) UICamera.currentTouch.last != (UnityEngine.Object) UICamera.currentTouch.current;
    bool flag5 = (UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null;
    if (!flag5 & flag3)
      UICamera.hoveredObject = UICamera.currentTouch.current;
    UICamera.currentTouchID = -1;
    if (flag4)
      UICamera.currentKey = KeyCode.Mouse0;
    if (!flag1 & flag3)
    {
      if ((double) UICamera.mTooltipTime != 0.0)
        UICamera.mTooltipTime = Time.unscaledTime + this.tooltipDelay;
      else if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null && !this.stickyTooltip | flag4)
        UICamera.ShowTooltip((GameObject) null);
    }
    if (flag3 && UICamera.onMouseMove != null)
    {
      UICamera.onMouseMove(UICamera.currentTouch.delta);
      UICamera.currentTouch = (UICamera.MouseOrTouch) null;
    }
    if (flag4 && (flag2 || flag5 && !flag1))
      UICamera.hoveredObject = (GameObject) null;
    for (int button = 0; button < 3; ++button)
    {
      bool mouseButtonDown = Input.GetMouseButtonDown(button);
      bool mouseButtonUp = Input.GetMouseButtonUp(button);
      if (mouseButtonDown | mouseButtonUp)
        UICamera.currentKey = (KeyCode) (323 + button);
      UICamera.currentTouch = UICamera.mMouse[button];
      UICamera.currentTouchID = -1 - button;
      UICamera.currentKey = (KeyCode) (323 + button);
      if (mouseButtonDown)
      {
        UICamera.currentTouch.pressedCam = UICamera.currentCamera;
        UICamera.currentTouch.pressTime = RealTime.time;
      }
      else if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
        UICamera.currentCamera = UICamera.currentTouch.pressedCam;
      this.ProcessTouch(mouseButtonDown, mouseButtonUp);
    }
    if (!flag1 & flag4)
    {
      UICamera.currentTouch = UICamera.mMouse[0];
      UICamera.mTooltipTime = Time.unscaledTime + this.tooltipDelay;
      UICamera.currentTouchID = -1;
      UICamera.currentKey = KeyCode.Mouse0;
      UICamera.hoveredObject = UICamera.currentTouch.current;
    }
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
    UICamera.mMouse[0].last = UICamera.mMouse[0].current;
    for (int index = 1; index < 3; ++index)
      UICamera.mMouse[index].last = UICamera.mMouse[0].last;
  }

  public void ProcessTouches()
  {
    int num = UICamera.GetInputTouchCount == null ? Input.touchCount : UICamera.GetInputTouchCount();
    for (int index = 0; index < num; ++index)
    {
      TouchPhase phase;
      int fingerId;
      Vector2 position;
      int tapCount;
      if (UICamera.GetInputTouch == null)
      {
        UnityEngine.Touch touch = Input.GetTouch(index);
        phase = touch.phase;
        fingerId = touch.fingerId;
        position = touch.position;
        tapCount = touch.tapCount;
      }
      else
      {
        UICamera.Touch touch = UICamera.GetInputTouch(index);
        phase = touch.phase;
        fingerId = touch.fingerId;
        position = touch.position;
        tapCount = touch.tapCount;
      }
      UICamera.currentTouchID = this.allowMultiTouch ? fingerId : 1;
      UICamera.currentTouch = UICamera.GetTouch(UICamera.currentTouchID, true);
      bool pressed = phase == TouchPhase.Began || UICamera.currentTouch.touchBegan;
      bool released = phase == TouchPhase.Canceled || phase == TouchPhase.Ended;
      UICamera.currentTouch.delta = position - UICamera.currentTouch.pos;
      UICamera.currentTouch.pos = position;
      UICamera.currentKey = KeyCode.None;
      UICamera.Raycast(UICamera.currentTouch);
      if (pressed)
        UICamera.currentTouch.pressedCam = UICamera.currentCamera;
      else if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
        UICamera.currentCamera = UICamera.currentTouch.pressedCam;
      if (tapCount > 1)
        UICamera.currentTouch.clickTime = RealTime.time;
      this.ProcessTouch(pressed, released);
      if (released)
        UICamera.RemoveTouch(UICamera.currentTouchID);
      UICamera.currentTouch.touchBegan = false;
      UICamera.currentTouch.last = (GameObject) null;
      UICamera.currentTouch = (UICamera.MouseOrTouch) null;
      if (!this.allowMultiTouch)
        break;
    }
    if (num == 0)
    {
      if (UICamera.mUsingTouchEvents)
      {
        UICamera.mUsingTouchEvents = false;
      }
      else
      {
        if (!this.useMouse)
          return;
        this.ProcessMouse();
      }
    }
    else
      UICamera.mUsingTouchEvents = true;
  }

  private void ProcessFakeTouches()
  {
    bool mouseButtonDown = Input.GetMouseButtonDown(0);
    bool mouseButtonUp = Input.GetMouseButtonUp(0);
    bool mouseButton = Input.GetMouseButton(0);
    if (!(mouseButtonDown | mouseButtonUp | mouseButton))
      return;
    UICamera.currentTouchID = 1;
    UICamera.currentTouch = UICamera.mMouse[0];
    UICamera.currentTouch.touchBegan = mouseButtonDown;
    if (mouseButtonDown)
    {
      UICamera.currentTouch.pressTime = RealTime.time;
      UICamera.activeTouches.Add(UICamera.currentTouch);
    }
    Vector2 mousePosition = (Vector2) Input.mousePosition;
    UICamera.currentTouch.delta = mousePosition - UICamera.currentTouch.pos;
    UICamera.currentTouch.pos = mousePosition;
    UICamera.Raycast(UICamera.currentTouch);
    if (mouseButtonDown)
      UICamera.currentTouch.pressedCam = UICamera.currentCamera;
    else if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
      UICamera.currentCamera = UICamera.currentTouch.pressedCam;
    UICamera.currentKey = KeyCode.None;
    this.ProcessTouch(mouseButtonDown, mouseButtonUp);
    if (mouseButtonUp)
      UICamera.activeTouches.Remove(UICamera.currentTouch);
    UICamera.currentTouch.last = (GameObject) null;
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
  }

  public void ProcessOthers()
  {
    UICamera.currentTouchID = -100;
    UICamera.currentTouch = UICamera.controller;
    bool pressed = false;
    bool released = false;
    if (this.submitKey0 != KeyCode.None && UICamera.GetKeyDown(this.submitKey0))
    {
      UICamera.currentKey = this.submitKey0;
      pressed = true;
    }
    else if (this.submitKey1 != KeyCode.None && UICamera.GetKeyDown(this.submitKey1))
    {
      UICamera.currentKey = this.submitKey1;
      pressed = true;
    }
    else if ((this.submitKey0 == KeyCode.Return || this.submitKey1 == KeyCode.Return) && UICamera.GetKeyDown(KeyCode.KeypadEnter))
    {
      UICamera.currentKey = this.submitKey0;
      pressed = true;
    }
    if (this.submitKey0 != KeyCode.None && UICamera.GetKeyUp(this.submitKey0))
    {
      UICamera.currentKey = this.submitKey0;
      released = true;
    }
    else if (this.submitKey1 != KeyCode.None && UICamera.GetKeyUp(this.submitKey1))
    {
      UICamera.currentKey = this.submitKey1;
      released = true;
    }
    else if ((this.submitKey0 == KeyCode.Return || this.submitKey1 == KeyCode.Return) && UICamera.GetKeyUp(KeyCode.KeypadEnter))
    {
      UICamera.currentKey = this.submitKey0;
      released = true;
    }
    if (pressed)
      UICamera.currentTouch.pressTime = RealTime.time;
    if (pressed | released && UICamera.currentScheme == UICamera.ControlScheme.Controller)
    {
      UICamera.currentTouch.current = UICamera.controllerNavigationObject;
      this.ProcessTouch(pressed, released);
      UICamera.currentTouch.last = UICamera.currentTouch.current;
    }
    KeyCode key1 = KeyCode.None;
    if (this.useController && !UICamera.ignoreControllerInput)
    {
      if (!UICamera.disableController && UICamera.currentScheme == UICamera.ControlScheme.Controller && ((UnityEngine.Object) UICamera.currentTouch.current == (UnityEngine.Object) null || !UICamera.currentTouch.current.activeInHierarchy))
        UICamera.currentTouch.current = UICamera.controllerNavigationObject;
      if (!string.IsNullOrEmpty(this.verticalAxisName))
      {
        int direction = UICamera.GetDirection(this.verticalAxisName);
        if (direction != 0)
        {
          UICamera.ShowTooltip((GameObject) null);
          UICamera.currentScheme = UICamera.ControlScheme.Controller;
          UICamera.currentTouch.current = UICamera.controllerNavigationObject;
          if ((UnityEngine.Object) UICamera.currentTouch.current != (UnityEngine.Object) null)
          {
            key1 = direction > 0 ? KeyCode.UpArrow : KeyCode.DownArrow;
            if (UICamera.onNavigate != null)
              UICamera.onNavigate(UICamera.currentTouch.current, key1);
            UICamera.Notify(UICamera.currentTouch.current, "OnNavigate", (object) key1);
          }
        }
      }
      if (!string.IsNullOrEmpty(this.horizontalAxisName))
      {
        int direction = UICamera.GetDirection(this.horizontalAxisName);
        if (direction != 0)
        {
          UICamera.ShowTooltip((GameObject) null);
          UICamera.currentScheme = UICamera.ControlScheme.Controller;
          UICamera.currentTouch.current = UICamera.controllerNavigationObject;
          if ((UnityEngine.Object) UICamera.currentTouch.current != (UnityEngine.Object) null)
          {
            key1 = direction > 0 ? KeyCode.RightArrow : KeyCode.LeftArrow;
            if (UICamera.onNavigate != null)
              UICamera.onNavigate(UICamera.currentTouch.current, key1);
            UICamera.Notify(UICamera.currentTouch.current, "OnNavigate", (object) key1);
          }
        }
      }
      float x = !string.IsNullOrEmpty(this.horizontalPanAxisName) ? UICamera.GetAxis(this.horizontalPanAxisName) : 0.0f;
      float y = !string.IsNullOrEmpty(this.verticalPanAxisName) ? UICamera.GetAxis(this.verticalPanAxisName) : 0.0f;
      if ((double) x != 0.0 || (double) y != 0.0)
      {
        UICamera.ShowTooltip((GameObject) null);
        UICamera.currentScheme = UICamera.ControlScheme.Controller;
        UICamera.currentTouch.current = UICamera.controllerNavigationObject;
        if ((UnityEngine.Object) UICamera.currentTouch.current != (UnityEngine.Object) null)
        {
          Vector2 delta = new Vector2(x, y) * Time.unscaledDeltaTime;
          if (UICamera.onPan != null)
            UICamera.onPan(UICamera.currentTouch.current, delta);
          UICamera.Notify(UICamera.currentTouch.current, "OnPan", (object) delta);
        }
      }
    }
    if ((UICamera.GetAnyKeyDown != null ? (UICamera.GetAnyKeyDown() ? 1 : 0) : (Input.anyKeyDown ? 1 : 0)) != 0)
    {
      int index = 0;
      for (int length = NGUITools.keys.Length; index < length; ++index)
      {
        KeyCode key2 = NGUITools.keys[index];
        if (key1 != key2 && UICamera.GetKeyDown(key2) && (this.useKeyboard || key2 >= KeyCode.Mouse0) && (this.useController && !UICamera.ignoreControllerInput || key2 < KeyCode.JoystickButton0) && (this.useMouse || key2 < KeyCode.Mouse0 || key2 > KeyCode.Mouse6))
        {
          UICamera.currentKey = key2;
          if (UICamera.onKey != null)
            UICamera.onKey(UICamera.currentTouch.current, key2);
          UICamera.Notify(UICamera.currentTouch.current, "OnKey", (object) key2);
        }
      }
    }
    UICamera.currentTouch = (UICamera.MouseOrTouch) null;
  }

  private void ProcessPress(bool pressed, float click, float drag)
  {
    if (pressed)
    {
      if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null)
        UICamera.ShowTooltip((GameObject) null);
      UICamera.mTooltipTime = Time.unscaledTime + this.tooltipDelay;
      UICamera.currentTouch.pressStarted = true;
      if (UICamera.onPress != null && (bool) (UnityEngine.Object) UICamera.currentTouch.pressed)
        UICamera.onPress(UICamera.currentTouch.pressed, false);
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) false);
      if (UICamera.currentScheme == UICamera.ControlScheme.Mouse && (UnityEngine.Object) UICamera.hoveredObject == (UnityEngine.Object) null && (UnityEngine.Object) UICamera.currentTouch.current != (UnityEngine.Object) null)
        UICamera.hoveredObject = UICamera.currentTouch.current;
      UICamera.currentTouch.pressed = UICamera.currentTouch.current;
      UICamera.currentTouch.dragged = UICamera.currentTouch.current;
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
      UICamera.currentTouch.totalDelta = Vector2.zero;
      UICamera.currentTouch.dragStarted = false;
      if (UICamera.onPress != null && (bool) (UnityEngine.Object) UICamera.currentTouch.pressed)
        UICamera.onPress(UICamera.currentTouch.pressed, true);
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) true);
      if (!((UnityEngine.Object) UICamera.mSelected != (UnityEngine.Object) UICamera.currentTouch.pressed))
        return;
      UICamera.mInputFocus = false;
      if ((bool) (UnityEngine.Object) UICamera.mSelected)
      {
        UICamera.Notify(UICamera.mSelected, "OnSelect", (object) false);
        if (UICamera.onSelect != null)
          UICamera.onSelect(UICamera.mSelected, false);
      }
      UICamera.mSelected = UICamera.currentTouch.pressed;
      if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null && (UnityEngine.Object) UICamera.currentTouch.pressed.GetComponent<UIKeyNavigation>() != (UnityEngine.Object) null)
        UICamera.controller.current = UICamera.currentTouch.pressed;
      if (!(bool) (UnityEngine.Object) UICamera.mSelected)
        return;
      UICamera.mInputFocus = UICamera.mSelected.activeInHierarchy && (UnityEngine.Object) UICamera.mSelected.GetComponent<UIInput>() != (UnityEngine.Object) null;
      if (UICamera.onSelect != null)
        UICamera.onSelect(UICamera.mSelected, true);
      UICamera.Notify(UICamera.mSelected, "OnSelect", (object) true);
    }
    else
    {
      if (!((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null) || (double) UICamera.currentTouch.delta.sqrMagnitude == 0.0 && !((UnityEngine.Object) UICamera.currentTouch.current != (UnityEngine.Object) UICamera.currentTouch.last))
        return;
      UICamera.currentTouch.totalDelta += UICamera.currentTouch.delta;
      float sqrMagnitude = UICamera.currentTouch.totalDelta.sqrMagnitude;
      bool flag = false;
      if (!UICamera.currentTouch.dragStarted && (UnityEngine.Object) UICamera.currentTouch.last != (UnityEngine.Object) UICamera.currentTouch.current)
      {
        UICamera.currentTouch.dragStarted = true;
        UICamera.currentTouch.delta = UICamera.currentTouch.totalDelta;
        UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
        UICamera.isDragging = true;
        if (UICamera.onDragStart != null)
          UICamera.onDragStart(UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDragStart", (object) null);
        if (UICamera.onDragOver != null)
          UICamera.onDragOver(UICamera.currentTouch.last, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.last, "OnDragOver", (object) UICamera.currentTouch.dragged);
        UICamera.isDragging = false;
      }
      else if (!UICamera.currentTouch.dragStarted && (double) drag < (double) sqrMagnitude)
      {
        flag = true;
        UICamera.currentTouch.dragStarted = true;
        UICamera.currentTouch.delta = UICamera.currentTouch.totalDelta;
      }
      if (!UICamera.currentTouch.dragStarted)
        return;
      if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null)
        UICamera.ShowTooltip((GameObject) null);
      UICamera.isDragging = true;
      int num = UICamera.currentTouch.clickNotification == UICamera.ClickNotification.None ? 1 : 0;
      if (flag)
      {
        if (UICamera.onDragStart != null)
          UICamera.onDragStart(UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDragStart", (object) null);
        if (UICamera.onDragOver != null)
          UICamera.onDragOver(UICamera.currentTouch.last, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.current, "OnDragOver", (object) UICamera.currentTouch.dragged);
      }
      else if ((UnityEngine.Object) UICamera.currentTouch.last != (UnityEngine.Object) UICamera.currentTouch.current)
      {
        if (UICamera.onDragOut != null)
          UICamera.onDragOut(UICamera.currentTouch.last, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.last, "OnDragOut", (object) UICamera.currentTouch.dragged);
        if (UICamera.onDragOver != null)
          UICamera.onDragOver(UICamera.currentTouch.last, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.current, "OnDragOver", (object) UICamera.currentTouch.dragged);
      }
      if (UICamera.onDrag != null)
        UICamera.onDrag(UICamera.currentTouch.dragged, UICamera.currentTouch.delta);
      UICamera.Notify(UICamera.currentTouch.dragged, "OnDrag", (object) UICamera.currentTouch.delta);
      UICamera.currentTouch.last = UICamera.currentTouch.current;
      UICamera.isDragging = false;
      if (num != 0)
      {
        UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      }
      else
      {
        if (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.BasedOnDelta || (double) click >= (double) sqrMagnitude)
          return;
        UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      }
    }
  }

  private void ProcessRelease(bool isMouse, float drag)
  {
    if (UICamera.currentTouch == null)
      return;
    UICamera.currentTouch.pressStarted = false;
    if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
    {
      if (UICamera.currentTouch.dragStarted)
      {
        if (UICamera.onDragOut != null)
          UICamera.onDragOut(UICamera.currentTouch.last, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.last, "OnDragOut", (object) UICamera.currentTouch.dragged);
        if (UICamera.onDragEnd != null)
          UICamera.onDragEnd(UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.dragged, "OnDragEnd", (object) null);
      }
      if (UICamera.onPress != null)
        UICamera.onPress(UICamera.currentTouch.pressed, false);
      UICamera.Notify(UICamera.currentTouch.pressed, "OnPress", (object) false);
      if (isMouse && this.HasCollider(UICamera.currentTouch.pressed))
      {
        if ((UnityEngine.Object) UICamera.mHover == (UnityEngine.Object) UICamera.currentTouch.current)
        {
          if (UICamera.onHover != null)
            UICamera.onHover(UICamera.currentTouch.current, true);
          UICamera.Notify(UICamera.currentTouch.current, "OnHover", (object) true);
        }
        else
          UICamera.hoveredObject = UICamera.currentTouch.current;
      }
      if ((UnityEngine.Object) UICamera.currentTouch.dragged == (UnityEngine.Object) UICamera.currentTouch.current || UICamera.currentScheme != UICamera.ControlScheme.Controller && UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && (double) UICamera.currentTouch.totalDelta.sqrMagnitude < (double) drag)
      {
        if (UICamera.currentTouch.clickNotification != UICamera.ClickNotification.None && (UnityEngine.Object) UICamera.currentTouch.pressed == (UnityEngine.Object) UICamera.currentTouch.current)
        {
          UICamera.ShowTooltip((GameObject) null);
          float time = RealTime.time;
          if (UICamera.onClick != null)
            UICamera.onClick(UICamera.currentTouch.pressed);
          UICamera.Notify(UICamera.currentTouch.pressed, "OnClick", (object) null);
          if ((double) UICamera.currentTouch.clickTime + 0.34999999403953552 > (double) time && (UnityEngine.Object) UICamera.currentTouch.lastClickGO == (UnityEngine.Object) UICamera.currentTouch.pressed)
          {
            if (UICamera.onDoubleClick != null)
              UICamera.onDoubleClick(UICamera.currentTouch.pressed);
            UICamera.Notify(UICamera.currentTouch.pressed, "OnDoubleClick", (object) null);
          }
          UICamera.currentTouch.lastClickGO = UICamera.currentTouch.pressed;
          UICamera.currentTouch.clickTime = time;
        }
      }
      else if (UICamera.currentTouch.dragStarted)
      {
        if (UICamera.onDrop != null)
          UICamera.onDrop(UICamera.currentTouch.current, UICamera.currentTouch.dragged);
        UICamera.Notify(UICamera.currentTouch.current, "OnDrop", (object) UICamera.currentTouch.dragged);
      }
    }
    UICamera.currentTouch.dragStarted = false;
    UICamera.currentTouch.pressed = (GameObject) null;
    UICamera.currentTouch.dragged = (GameObject) null;
  }

  private bool HasCollider(GameObject go)
  {
    if ((UnityEngine.Object) go == (UnityEngine.Object) null)
      return false;
    Collider component1 = go.GetComponent<Collider>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      return component1.enabled;
    Collider2D component2 = go.GetComponent<Collider2D>();
    return (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.enabled;
  }

  public void ProcessTouch(bool pressed, bool released)
  {
    if (released)
      UICamera.mTooltipTime = 0.0f;
    bool isMouse = UICamera.currentScheme == UICamera.ControlScheme.Mouse;
    float num1 = isMouse ? this.mouseDragThreshold : this.touchDragThreshold;
    float num2 = isMouse ? this.mouseClickThreshold : this.touchClickThreshold;
    float drag = num1 * num1;
    float click = num2 * num2;
    if ((UnityEngine.Object) UICamera.currentTouch.pressed != (UnityEngine.Object) null)
    {
      if (released)
        this.ProcessRelease(isMouse, drag);
      this.ProcessPress(pressed, click, drag);
      if ((double) this.tooltipDelay == 0.0 || (double) UICamera.currentTouch.deltaTime <= (double) this.tooltipDelay || !((UnityEngine.Object) UICamera.currentTouch.pressed == (UnityEngine.Object) UICamera.currentTouch.current) || (double) UICamera.mTooltipTime == 0.0 || UICamera.currentTouch.dragStarted)
        return;
      UICamera.mTooltipTime = 0.0f;
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
      if (this.longPressTooltip)
        UICamera.ShowTooltip(UICamera.currentTouch.pressed);
      UICamera.Notify(UICamera.currentTouch.current, "OnLongPress", (object) null);
    }
    else
    {
      if (!(isMouse | pressed | released))
        return;
      this.ProcessPress(pressed, click, drag);
      if (!released)
        return;
      this.ProcessRelease(isMouse, drag);
    }
  }

  public static void CancelNextTooltip() => UICamera.mTooltipTime = 0.0f;

  public static bool ShowTooltip(GameObject go)
  {
    if (!((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) go))
      return false;
    if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null)
    {
      if (UICamera.onTooltip != null)
        UICamera.onTooltip(UICamera.mTooltip, false);
      UICamera.Notify(UICamera.mTooltip, "OnTooltip", (object) false);
    }
    UICamera.mTooltip = go;
    UICamera.mTooltipTime = 0.0f;
    if ((UnityEngine.Object) UICamera.mTooltip != (UnityEngine.Object) null)
    {
      if (UICamera.onTooltip != null)
        UICamera.onTooltip(UICamera.mTooltip, true);
      UICamera.Notify(UICamera.mTooltip, "OnTooltip", (object) true);
    }
    return true;
  }

  public static bool HideTooltip() => UICamera.ShowTooltip((GameObject) null);

  public static void ResetTooltip(float delay = 0.5f)
  {
    UICamera.ShowTooltip((GameObject) null);
    UICamera.mTooltipTime = Time.unscaledTime + delay;
  }

  [DoNotObfuscateNGUI]
  public enum ControlScheme
  {
    Mouse,
    Touch,
    Controller,
  }

  [DoNotObfuscateNGUI]
  public enum ClickNotification
  {
    None,
    Always,
    BasedOnDelta,
  }

  public class MouseOrTouch
  {
    public KeyCode key;
    public Vector2 pos;
    public Vector2 lastPos;
    public Vector2 delta;
    public Vector2 totalDelta;
    public Camera pressedCam;
    public GameObject last;
    public GameObject current;
    public GameObject pressed;
    public GameObject dragged;
    public GameObject lastClickGO;
    public float pressTime;
    public float clickTime;
    public UICamera.ClickNotification clickNotification = UICamera.ClickNotification.Always;
    public bool touchBegan = true;
    public bool pressStarted;
    public bool dragStarted;
    public int ignoreDelta;

    public float deltaTime => RealTime.time - this.pressTime;

    public bool isOverUI => (UnityEngine.Object) this.current != (UnityEngine.Object) null && (UnityEngine.Object) this.current != (UnityEngine.Object) UICamera.fallThrough && (UnityEngine.Object) NGUITools.FindInParents<UIRoot>(this.current) != (UnityEngine.Object) null;
  }

  [DoNotObfuscateNGUI]
  public enum EventType
  {
    World_3D,
    UI_3D,
    World_2D,
    UI_2D,
  }

  public delegate bool GetKeyStateFunc(KeyCode key);

  public delegate float GetAxisFunc(string name);

  public delegate bool GetAnyKeyFunc();

  public delegate UICamera.MouseOrTouch GetMouseDelegate(int button);

  public delegate UICamera.MouseOrTouch GetTouchDelegate(int id, bool createIfMissing);

  public delegate void RemoveTouchDelegate(int id);

  public delegate void OnScreenResize();

  [DoNotObfuscateNGUI]
  public enum ProcessEventsIn
  {
    Update,
    LateUpdate,
  }

  public delegate void OnCustomInput();

  public delegate void OnSchemeChange();

  public delegate void MoveDelegate(Vector2 delta);

  public delegate void VoidDelegate(GameObject go);

  public delegate void BoolDelegate(GameObject go, bool state);

  public delegate void FloatDelegate(GameObject go, float delta);

  public delegate void VectorDelegate(GameObject go, Vector2 delta);

  public delegate void ObjectDelegate(GameObject go, GameObject obj);

  public delegate void KeyCodeDelegate(GameObject go, KeyCode key);

  private struct DepthEntry
  {
    public int depth;
    public RaycastHit hit;
    public Vector3 point;
    public GameObject go;
  }

  public class Touch
  {
    public int fingerId;
    public TouchPhase phase;
    public Vector2 position;
    public int tapCount;
  }

  public delegate int GetTouchCountCallback();

  public delegate UICamera.Touch GetTouchCallback(int index);
}
