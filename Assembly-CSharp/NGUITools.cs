// Decompiled with JetBrains decompiler
// Type: NGUITools
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;

public static class NGUITools
{
  [NonSerialized]
  private static AudioListener mListener;
  [NonSerialized]
  public static AudioSource audioSource;
  private static bool mLoaded = false;
  private static float mGlobalVolume = 1f;
  private static float mLastTimestamp = 0.0f;
  private static AudioClip mLastClip;
  private static Dictionary<System.Type, string> mTypeNames = new Dictionary<System.Type, string>();
  private static Vector3[] mSides = new Vector3[4];
  public static KeyCode[] keys = new KeyCode[145]
  {
    KeyCode.Backspace,
    KeyCode.Tab,
    KeyCode.Clear,
    KeyCode.Return,
    KeyCode.Pause,
    KeyCode.Escape,
    KeyCode.Space,
    KeyCode.Exclaim,
    KeyCode.DoubleQuote,
    KeyCode.Hash,
    KeyCode.Dollar,
    KeyCode.Ampersand,
    KeyCode.Quote,
    KeyCode.LeftParen,
    KeyCode.RightParen,
    KeyCode.Asterisk,
    KeyCode.Plus,
    KeyCode.Comma,
    KeyCode.Minus,
    KeyCode.Period,
    KeyCode.Slash,
    KeyCode.Alpha0,
    KeyCode.Alpha1,
    KeyCode.Alpha2,
    KeyCode.Alpha3,
    KeyCode.Alpha4,
    KeyCode.Alpha5,
    KeyCode.Alpha6,
    KeyCode.Alpha7,
    KeyCode.Alpha8,
    KeyCode.Alpha9,
    KeyCode.Colon,
    KeyCode.Semicolon,
    KeyCode.Less,
    KeyCode.Equals,
    KeyCode.Greater,
    KeyCode.Question,
    KeyCode.At,
    KeyCode.LeftBracket,
    KeyCode.Backslash,
    KeyCode.RightBracket,
    KeyCode.Caret,
    KeyCode.Underscore,
    KeyCode.BackQuote,
    KeyCode.A,
    KeyCode.B,
    KeyCode.C,
    KeyCode.D,
    KeyCode.E,
    KeyCode.F,
    KeyCode.G,
    KeyCode.H,
    KeyCode.I,
    KeyCode.J,
    KeyCode.K,
    KeyCode.L,
    KeyCode.M,
    KeyCode.N,
    KeyCode.O,
    KeyCode.P,
    KeyCode.Q,
    KeyCode.R,
    KeyCode.S,
    KeyCode.T,
    KeyCode.U,
    KeyCode.V,
    KeyCode.W,
    KeyCode.X,
    KeyCode.Y,
    KeyCode.Z,
    KeyCode.Delete,
    KeyCode.Keypad0,
    KeyCode.Keypad1,
    KeyCode.Keypad2,
    KeyCode.Keypad3,
    KeyCode.Keypad4,
    KeyCode.Keypad5,
    KeyCode.Keypad6,
    KeyCode.Keypad7,
    KeyCode.Keypad8,
    KeyCode.Keypad9,
    KeyCode.KeypadPeriod,
    KeyCode.KeypadDivide,
    KeyCode.KeypadMultiply,
    KeyCode.KeypadMinus,
    KeyCode.KeypadPlus,
    KeyCode.KeypadEnter,
    KeyCode.KeypadEquals,
    KeyCode.UpArrow,
    KeyCode.DownArrow,
    KeyCode.RightArrow,
    KeyCode.LeftArrow,
    KeyCode.Insert,
    KeyCode.Home,
    KeyCode.End,
    KeyCode.PageUp,
    KeyCode.PageDown,
    KeyCode.F1,
    KeyCode.F2,
    KeyCode.F3,
    KeyCode.F4,
    KeyCode.F5,
    KeyCode.F6,
    KeyCode.F7,
    KeyCode.F8,
    KeyCode.F9,
    KeyCode.F10,
    KeyCode.F11,
    KeyCode.F12,
    KeyCode.F13,
    KeyCode.F14,
    KeyCode.F15,
    KeyCode.Numlock,
    KeyCode.CapsLock,
    KeyCode.ScrollLock,
    KeyCode.RightShift,
    KeyCode.LeftShift,
    KeyCode.RightControl,
    KeyCode.LeftControl,
    KeyCode.RightAlt,
    KeyCode.LeftAlt,
    KeyCode.Mouse3,
    KeyCode.Mouse4,
    KeyCode.Mouse5,
    KeyCode.Mouse6,
    KeyCode.JoystickButton0,
    KeyCode.JoystickButton1,
    KeyCode.JoystickButton2,
    KeyCode.JoystickButton3,
    KeyCode.JoystickButton4,
    KeyCode.JoystickButton5,
    KeyCode.JoystickButton6,
    KeyCode.JoystickButton7,
    KeyCode.JoystickButton8,
    KeyCode.JoystickButton9,
    KeyCode.JoystickButton10,
    KeyCode.JoystickButton11,
    KeyCode.JoystickButton12,
    KeyCode.JoystickButton13,
    KeyCode.JoystickButton14,
    KeyCode.JoystickButton15,
    KeyCode.JoystickButton16,
    KeyCode.JoystickButton17,
    KeyCode.JoystickButton18,
    KeyCode.JoystickButton19
  };
  private static Dictionary<string, UIWidget> mWidgets = new Dictionary<string, UIWidget>();
  private static UIPanel mRoot;
  private static GameObject mGo;
  private static ColorSpace mColorSpace = ColorSpace.Uninitialized;

  public static float soundVolume
  {
    get
    {
      if (!NGUITools.mLoaded)
      {
        NGUITools.mLoaded = true;
        NGUITools.mGlobalVolume = PlayerPrefs.GetFloat("Sound", 1f);
      }
      return NGUITools.mGlobalVolume;
    }
    set
    {
      if ((double) NGUITools.mGlobalVolume == (double) value)
        return;
      NGUITools.mLoaded = true;
      NGUITools.mGlobalVolume = value;
      PlayerPrefs.SetFloat("Sound", value);
    }
  }

  public static bool fileAccess => Application.platform != RuntimePlatform.WebGLPlayer;

  public static AudioSource PlaySound(AudioClip clip) => NGUITools.PlaySound(clip, 1f, 1f);

  public static AudioSource PlaySound(AudioClip clip, float volume) => NGUITools.PlaySound(clip, volume, 1f);

  public static AudioSource PlaySound(AudioClip clip, float volume, float pitch)
  {
    float time = RealTime.time;
    if ((UnityEngine.Object) NGUITools.mLastClip == (UnityEngine.Object) clip && (double) NGUITools.mLastTimestamp + 0.10000000149011612 > (double) time)
      return (AudioSource) null;
    NGUITools.mLastClip = clip;
    NGUITools.mLastTimestamp = time;
    volume *= NGUITools.soundVolume;
    if ((UnityEngine.Object) clip != (UnityEngine.Object) null && (double) volume > 0.0099999997764825821)
    {
      if ((UnityEngine.Object) NGUITools.mListener == (UnityEngine.Object) null || !NGUITools.GetActive((Behaviour) NGUITools.mListener))
      {
        if (UnityEngine.Object.FindObjectsOfType(typeof (AudioListener)) is AudioListener[] objectsOfType)
        {
          for (int index = 0; index < objectsOfType.Length; ++index)
          {
            if (NGUITools.GetActive((Behaviour) objectsOfType[index]))
            {
              NGUITools.mListener = objectsOfType[index];
              break;
            }
          }
        }
        if ((UnityEngine.Object) NGUITools.mListener == (UnityEngine.Object) null)
        {
          Camera camera = Camera.main;
          if ((UnityEngine.Object) camera == (UnityEngine.Object) null)
            camera = UnityEngine.Object.FindObjectOfType(typeof (Camera)) as Camera;
          if ((UnityEngine.Object) camera != (UnityEngine.Object) null)
            NGUITools.mListener = camera.gameObject.AddComponent<AudioListener>();
        }
      }
      if ((UnityEngine.Object) NGUITools.mListener != (UnityEngine.Object) null && NGUITools.mListener.enabled && NGUITools.GetActive(NGUITools.mListener.gameObject))
      {
        if (!(bool) (UnityEngine.Object) NGUITools.audioSource)
        {
          NGUITools.audioSource = NGUITools.mListener.GetComponent<AudioSource>();
          if ((UnityEngine.Object) NGUITools.audioSource == (UnityEngine.Object) null)
            NGUITools.audioSource = NGUITools.mListener.gameObject.AddComponent<AudioSource>();
        }
        NGUITools.audioSource.priority = 50;
        NGUITools.audioSource.pitch = pitch;
        NGUITools.audioSource.PlayOneShot(clip, volume);
        return NGUITools.audioSource;
      }
    }
    return (AudioSource) null;
  }

  public static int RandomRange(int min, int max) => min == max ? min : UnityEngine.Random.Range(min, max + 1);

  public static string GetHierarchy(GameObject obj)
  {
    if ((UnityEngine.Object) obj == (UnityEngine.Object) null)
      return "";
    string hierarchy = obj.name;
    while ((UnityEngine.Object) obj.transform.parent != (UnityEngine.Object) null)
    {
      obj = obj.transform.parent.gameObject;
      hierarchy = obj.name + "\\" + hierarchy;
    }
    return hierarchy;
  }

  public static T[] FindActive<T>() where T : Component => UnityEngine.Object.FindObjectsOfType(typeof (T)) as T[];

  public static Camera FindCameraForLayer(int layer)
  {
    int num = 1 << layer;
    for (int index = 0; index < UICamera.list.size; ++index)
    {
      Camera cachedCamera = UICamera.list.buffer[index].cachedCamera;
      if ((bool) (UnityEngine.Object) cachedCamera && (cachedCamera.cullingMask & num) != 0)
        return cachedCamera;
    }
    Camera main = Camera.main;
    if ((bool) (UnityEngine.Object) main && (main.cullingMask & num) != 0)
      return main;
    Camera[] cameras = new Camera[Camera.allCamerasCount];
    int allCameras = Camera.GetAllCameras(cameras);
    for (int index = 0; index < allCameras; ++index)
    {
      Camera cameraForLayer = cameras[index];
      if ((bool) (UnityEngine.Object) cameraForLayer && cameraForLayer.enabled && (cameraForLayer.cullingMask & num) != 0)
        return cameraForLayer;
    }
    return (Camera) null;
  }

  public static void AddWidgetCollider(GameObject go) => NGUITools.AddWidgetCollider(go, false);

  public static void AddWidgetCollider(GameObject go, bool considerInactive)
  {
    if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
      return;
    Collider component1 = go.GetComponent<Collider>();
    BoxCollider box1 = component1 as BoxCollider;
    if ((UnityEngine.Object) box1 != (UnityEngine.Object) null)
    {
      NGUITools.UpdateWidgetCollider(box1, considerInactive);
    }
    else
    {
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        return;
      BoxCollider2D component2 = go.GetComponent<BoxCollider2D>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        NGUITools.UpdateWidgetCollider(component2, considerInactive);
      }
      else
      {
        UICamera cameraForLayer = UICamera.FindCameraForLayer(go.layer);
        if ((UnityEngine.Object) cameraForLayer != (UnityEngine.Object) null && (cameraForLayer.eventType == UICamera.EventType.World_2D || cameraForLayer.eventType == UICamera.EventType.UI_2D))
        {
          BoxCollider2D box2 = go.AddComponent<BoxCollider2D>();
          box2.isTrigger = true;
          UIWidget component3 = go.GetComponent<UIWidget>();
          if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
            component3.autoResizeBoxCollider = true;
          NGUITools.UpdateWidgetCollider(box2, considerInactive);
        }
        else
        {
          BoxCollider box3 = go.AddComponent<BoxCollider>();
          box3.isTrigger = true;
          UIWidget component4 = go.GetComponent<UIWidget>();
          if ((UnityEngine.Object) component4 != (UnityEngine.Object) null)
            component4.autoResizeBoxCollider = true;
          NGUITools.UpdateWidgetCollider(box3, considerInactive);
        }
      }
    }
  }

  public static void UpdateWidgetCollider(GameObject go) => NGUITools.UpdateWidgetCollider(go, false);

  public static void UpdateWidgetCollider(GameObject go, bool considerInactive)
  {
    if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
      return;
    BoxCollider component1 = go.GetComponent<BoxCollider>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
    {
      NGUITools.UpdateWidgetCollider(component1, considerInactive);
    }
    else
    {
      BoxCollider2D component2 = go.GetComponent<BoxCollider2D>();
      if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
        return;
      NGUITools.UpdateWidgetCollider(component2, considerInactive);
    }
  }

  public static void UpdateWidgetCollider(BoxCollider box, bool considerInactive)
  {
    if (!((UnityEngine.Object) box != (UnityEngine.Object) null))
      return;
    GameObject gameObject = box.gameObject;
    UIWidget component = gameObject.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      Vector4 drawRegion = component.drawRegion;
      if ((double) drawRegion.x != 0.0 || (double) drawRegion.y != 0.0 || (double) drawRegion.z != 1.0 || (double) drawRegion.w != 1.0)
      {
        Vector4 drawingDimensions = component.drawingDimensions;
        box.center = new Vector3((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
        box.size = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
      }
      else
      {
        Vector3[] localCorners = component.localCorners;
        box.center = Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
        box.size = localCorners[2] - localCorners[0];
      }
    }
    else
    {
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
      box.center = relativeWidgetBounds.center;
      box.size = new Vector3(relativeWidgetBounds.size.x, relativeWidgetBounds.size.y, 0.0f);
    }
  }

  public static void UpdateWidgetCollider(UIWidget w)
  {
    if ((UnityEngine.Object) w == (UnityEngine.Object) null)
      return;
    BoxCollider component = w.GetComponent<BoxCollider>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      NGUITools.UpdateWidgetCollider(w, component);
    else
      NGUITools.UpdateWidgetCollider(w, w.GetComponent<BoxCollider2D>());
  }

  public static void UpdateWidgetCollider(UIWidget w, BoxCollider box)
  {
    if (!((UnityEngine.Object) box != (UnityEngine.Object) null) || !((UnityEngine.Object) w != (UnityEngine.Object) null))
      return;
    Vector4 drawRegion = w.drawRegion;
    if ((double) drawRegion.x != 0.0 || (double) drawRegion.y != 0.0 || (double) drawRegion.z != 1.0 || (double) drawRegion.w != 1.0)
    {
      Vector4 drawingDimensions = w.drawingDimensions;
      Vector3 vector3_1 = new Vector3((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
      Vector3 vector3_2 = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
      if (!(vector3_1 != box.center) && !(vector3_2 != box.size))
        return;
      box.center = vector3_1;
      box.size = vector3_2;
      NGUITools.SetDirty((UnityEngine.Object) box);
    }
    else
    {
      Vector3[] localCorners = w.localCorners;
      Vector3 vector3_3 = Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
      Vector3 vector3_4 = localCorners[2] - localCorners[0];
      if (!(vector3_3 != box.center) && !(vector3_4 != box.size))
        return;
      box.center = vector3_3;
      box.size = vector3_4;
      NGUITools.SetDirty((UnityEngine.Object) box);
    }
  }

  public static void UpdateWidgetCollider(UIWidget w, BoxCollider2D box)
  {
    if (!((UnityEngine.Object) box != (UnityEngine.Object) null) || !((UnityEngine.Object) w != (UnityEngine.Object) null))
      return;
    Vector4 drawRegion = w.drawRegion;
    if ((double) drawRegion.x != 0.0 || (double) drawRegion.y != 0.0 || (double) drawRegion.z != 1.0 || (double) drawRegion.w != 1.0)
    {
      Vector4 drawingDimensions = w.drawingDimensions;
      Vector2 vector2_1 = new Vector2((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
      Vector2 vector2_2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
      if (!(vector2_1 != box.offset) && !(vector2_2 != box.size))
        return;
      box.offset = vector2_1;
      box.size = vector2_2;
      NGUITools.SetDirty((UnityEngine.Object) box);
    }
    else
    {
      Vector3[] localCorners = w.localCorners;
      Vector2 vector2_3 = Vector2.Lerp((Vector2) localCorners[0], (Vector2) localCorners[2], 0.5f);
      Vector2 vector2_4 = (Vector2) (localCorners[2] - localCorners[0]);
      if (!(vector2_3 != box.offset) && !(vector2_4 != box.size))
        return;
      box.offset = vector2_3;
      box.size = vector2_4;
      NGUITools.SetDirty((UnityEngine.Object) box);
    }
  }

  public static void UpdateWidgetCollider(BoxCollider2D box, bool considerInactive)
  {
    if (!((UnityEngine.Object) box != (UnityEngine.Object) null))
      return;
    GameObject gameObject = box.gameObject;
    UIWidget component = gameObject.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      Vector4 drawRegion = component.drawRegion;
      if ((double) drawRegion.x != 0.0 || (double) drawRegion.y != 0.0 || (double) drawRegion.z != 1.0 || (double) drawRegion.w != 1.0)
      {
        Vector4 drawingDimensions = component.drawingDimensions;
        Vector2 vector2_1 = new Vector2((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
        Vector2 vector2_2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
        if (!(vector2_1 != box.offset) && !(vector2_2 != box.size))
          return;
        box.offset = vector2_1;
        box.size = vector2_2;
        NGUITools.SetDirty((UnityEngine.Object) box);
      }
      else
      {
        Vector3[] localCorners = component.localCorners;
        Vector2 vector2_3 = Vector2.Lerp((Vector2) localCorners[0], (Vector2) localCorners[2], 0.5f);
        Vector2 vector2_4 = (Vector2) (localCorners[2] - localCorners[0]);
        if (!(vector2_3 != box.offset) && !(vector2_4 != box.size))
          return;
        box.offset = vector2_3;
        box.size = vector2_4;
        NGUITools.SetDirty((UnityEngine.Object) box);
      }
    }
    else
    {
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
      box.offset = (Vector2) relativeWidgetBounds.center;
      box.size = new Vector2(relativeWidgetBounds.size.x, relativeWidgetBounds.size.y);
    }
  }

  public static string GetTypeName<T>()
  {
    string typeName = typeof (T).ToString();
    if (typeName.StartsWith("UI"))
      typeName = typeName.Substring(2);
    else if (typeName.StartsWith("UnityEngine."))
      typeName = typeName.Substring(12);
    return typeName;
  }

  public static string GetTypeName(UnityEngine.Object obj)
  {
    if (obj == (UnityEngine.Object) null)
      return "Null";
    string typeName = ((object) obj).GetType().ToString();
    if (typeName.StartsWith("UI"))
      typeName = typeName.Substring(2);
    else if (typeName.StartsWith("UnityEngine."))
      typeName = typeName.Substring(12);
    return typeName;
  }

  public static void RegisterUndo(UnityEngine.Object obj, string name)
  {
  }

  public static void SetDirty(UnityEngine.Object obj, string undoName = "last change")
  {
  }

  public static void CheckForPrefabStage(GameObject gameObject)
  {
  }

  public static GameObject AddChild(GameObject parent) => parent.AddChild(true, -1);

  public static GameObject AddChild(this GameObject parent, int layer) => parent.AddChild(true, layer);

  public static GameObject AddChild(this GameObject parent, bool undo) => parent.AddChild(undo, -1);

  public static GameObject AddChild(this GameObject parent, bool undo, int layer)
  {
    GameObject gameObject = new GameObject();
    if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
    {
      Transform transform = gameObject.transform;
      transform.parent = parent.transform;
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.identity;
      transform.localScale = Vector3.one;
      if (layer == -1)
        gameObject.layer = parent.layer;
      else if (layer > -1 && layer < 32)
        gameObject.layer = layer;
    }
    return gameObject;
  }

  public static GameObject AddChild(this Transform parent, GameObject prefab)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, parent.transform);
    Transform transform = gameObject.transform;
    transform.parent = parent;
    transform.localPosition = Vector3.zero;
    transform.localRotation = Quaternion.identity;
    transform.localScale = Vector3.one;
    gameObject.SetActive(true);
    return gameObject;
  }

  public static GameObject AddChild(this GameObject parent, GameObject prefab) => parent.AddChild(prefab, -1);

  public static GameObject AddChild(this GameObject parent, GameObject prefab, int layer)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, parent.transform);
    if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
    {
      Transform transform = gameObject.transform;
      gameObject.name = prefab.name;
      if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
      {
        if (layer == -1)
          gameObject.layer = parent.layer;
        else if (layer > -1 && layer < 32)
          gameObject.layer = layer;
      }
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.identity;
      transform.localScale = Vector3.one;
      gameObject.SetActive(true);
    }
    return gameObject;
  }

  public static int CalculateRaycastDepth(GameObject go)
  {
    UIWidget component = go.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      return component.raycastDepth;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    if (componentsInChildren.Length == 0)
      return 0;
    int a = int.MaxValue;
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      if (componentsInChildren[index].enabled)
        a = Mathf.Min(a, componentsInChildren[index].raycastDepth);
    }
    return a;
  }

  public static int CalculateNextDepth(GameObject go)
  {
    if (!(bool) (UnityEngine.Object) go)
      return 0;
    int a = -1;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
      a = Mathf.Max(a, componentsInChildren[index].depth);
    return a + 1;
  }

  public static int CalculateNextDepth(GameObject go, bool ignoreChildrenWithColliders)
  {
    if (!((bool) (UnityEngine.Object) go & ignoreChildrenWithColliders))
      return NGUITools.CalculateNextDepth(go);
    int a = -1;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      UIWidget uiWidget = componentsInChildren[index];
      if (!((UnityEngine.Object) uiWidget.cachedGameObject != (UnityEngine.Object) go) || !((UnityEngine.Object) uiWidget.GetComponent<Collider>() != (UnityEngine.Object) null) && !((UnityEngine.Object) uiWidget.GetComponent<Collider2D>() != (UnityEngine.Object) null))
        a = Mathf.Max(a, uiWidget.depth);
    }
    return a + 1;
  }

  public static int AdjustDepth(GameObject go, int adjustment)
  {
    if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
      return 0;
    if ((UnityEngine.Object) go.GetComponent<UIPanel>() != (UnityEngine.Object) null)
    {
      foreach (UIPanel componentsInChild in go.GetComponentsInChildren<UIPanel>(true))
        componentsInChild.depth += adjustment;
      return 1;
    }
    UIPanel inParents = NGUITools.FindInParents<UIPanel>(go);
    if ((UnityEngine.Object) inParents == (UnityEngine.Object) null)
      return 0;
    UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>(true);
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      UIWidget uiWidget = componentsInChildren[index];
      if (!((UnityEngine.Object) uiWidget.panel != (UnityEngine.Object) inParents))
        uiWidget.depth += adjustment;
    }
    return 2;
  }

  public static void BringForward(GameObject go)
  {
    switch (NGUITools.AdjustDepth(go, 1000))
    {
      case 1:
        NGUITools.NormalizePanelDepths();
        break;
      case 2:
        NGUITools.NormalizeWidgetDepths();
        break;
    }
  }

  public static void PushBack(GameObject go)
  {
    switch (NGUITools.AdjustDepth(go, -1000))
    {
      case 1:
        NGUITools.NormalizePanelDepths();
        break;
      case 2:
        NGUITools.NormalizeWidgetDepths();
        break;
    }
  }

  public static void NormalizeDepths()
  {
    NGUITools.NormalizeWidgetDepths();
    NGUITools.NormalizePanelDepths();
  }

  public static void NormalizeWidgetDepths() => NGUITools.NormalizeWidgetDepths(NGUITools.FindActive<UIWidget>());

  public static void NormalizeWidgetDepths(GameObject go) => NGUITools.NormalizeWidgetDepths(go.GetComponentsInChildren<UIWidget>());

  public static void NormalizeWidgetDepths(UIWidget[] list)
  {
    int length = list.Length;
    if (length <= 0)
      return;
    Array.Sort<UIWidget>(list, new Comparison<UIWidget>(UIWidget.FullCompareFunc));
    int num = 0;
    int depth = list[0].depth;
    for (int index = 0; index < length; ++index)
    {
      UIWidget uiWidget = list[index];
      if (uiWidget.depth == depth)
      {
        uiWidget.depth = num;
      }
      else
      {
        depth = uiWidget.depth;
        uiWidget.depth = ++num;
      }
    }
  }

  public static void NormalizePanelDepths()
  {
    UIPanel[] active = NGUITools.FindActive<UIPanel>();
    int length = active.Length;
    if (length <= 0)
      return;
    Array.Sort<UIPanel>(active, new Comparison<UIPanel>(UIPanel.CompareFunc));
    int num = 0;
    int depth = active[0].depth;
    for (int index = 0; index < length; ++index)
    {
      UIPanel uiPanel = active[index];
      if (uiPanel.depth == depth)
      {
        uiPanel.depth = num;
      }
      else
      {
        depth = uiPanel.depth;
        uiPanel.depth = ++num;
      }
    }
  }

  public static UIPanel CreateUI(bool advanced3D) => NGUITools.CreateUI((Transform) null, advanced3D, -1);

  public static UIPanel CreateUI(bool advanced3D, int layer) => NGUITools.CreateUI((Transform) null, advanced3D, layer);

  public static UIPanel CreateUI(Transform trans, bool advanced3D, int layer)
  {
    UIRoot uiRoot1 = (UnityEngine.Object) trans != (UnityEngine.Object) null ? NGUITools.FindInParents<UIRoot>(trans.gameObject) : (UIRoot) null;
    if ((UnityEngine.Object) uiRoot1 == (UnityEngine.Object) null && UIRoot.list.Count > 0)
    {
      foreach (UIRoot uiRoot2 in UIRoot.list)
      {
        if (uiRoot2.gameObject.layer == layer)
        {
          uiRoot1 = uiRoot2;
          break;
        }
      }
    }
    if ((UnityEngine.Object) uiRoot1 == (UnityEngine.Object) null)
    {
      int index = 0;
      for (int count = UIPanel.list.Count; index < count; ++index)
      {
        UIPanel ui = UIPanel.list[index];
        GameObject gameObject = ui.gameObject;
        if (gameObject.hideFlags == HideFlags.None && gameObject.layer == layer)
        {
          trans.parent = ui.transform;
          trans.localScale = Vector3.one;
          return ui;
        }
      }
    }
    if ((UnityEngine.Object) uiRoot1 != (UnityEngine.Object) null)
    {
      UICamera componentInChildren = uiRoot1.GetComponentInChildren<UICamera>();
      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && componentInChildren.GetComponent<Camera>().orthographic == advanced3D)
      {
        trans = (Transform) null;
        uiRoot1 = (UIRoot) null;
      }
    }
    if ((UnityEngine.Object) uiRoot1 == (UnityEngine.Object) null)
    {
      GameObject gameObject = ((GameObject) null).AddChild(false);
      uiRoot1 = gameObject.AddComponent<UIRoot>();
      if (layer == -1)
        layer = LayerMask.NameToLayer("UI");
      if (layer == -1)
        layer = LayerMask.NameToLayer("2D UI");
      gameObject.layer = layer;
      if (advanced3D)
      {
        gameObject.name = "UI Root (3D)";
        uiRoot1.scalingStyle = UIRoot.Scaling.Constrained;
      }
      else
      {
        gameObject.name = "UI Root";
        uiRoot1.scalingStyle = UIRoot.Scaling.Flexible;
      }
      uiRoot1.UpdateScale();
    }
    UIPanel ui1 = uiRoot1.GetComponentInChildren<UIPanel>();
    if ((UnityEngine.Object) ui1 == (UnityEngine.Object) null)
    {
      Camera[] active1 = NGUITools.FindActive<Camera>();
      float a = -1f;
      bool flag = false;
      int num = 1 << uiRoot1.gameObject.layer;
      for (int index = 0; index < active1.Length; ++index)
      {
        Camera camera = active1[index];
        if (camera.clearFlags == CameraClearFlags.Color || camera.clearFlags == CameraClearFlags.Skybox)
          flag = true;
        a = Mathf.Max(a, camera.depth);
        camera.cullingMask &= ~num;
      }
      Camera camera1 = uiRoot1.gameObject.AddChild<Camera>(false);
      camera1.gameObject.AddComponent<UICamera>();
      camera1.clearFlags = flag ? CameraClearFlags.Depth : CameraClearFlags.Color;
      camera1.backgroundColor = Color.grey;
      camera1.cullingMask = num;
      camera1.depth = a + 1f;
      if (advanced3D)
      {
        camera1.nearClipPlane = 0.1f;
        camera1.farClipPlane = 4f;
        camera1.transform.localPosition = new Vector3(0.0f, 0.0f, -700f);
      }
      else
      {
        camera1.orthographic = true;
        camera1.orthographicSize = 1f;
        camera1.nearClipPlane = -10f;
        camera1.farClipPlane = 10f;
      }
      AudioListener[] active2 = NGUITools.FindActive<AudioListener>();
      if (active2 == null || active2.Length == 0)
        camera1.gameObject.AddComponent<AudioListener>();
      ui1 = uiRoot1.gameObject.AddComponent<UIPanel>();
    }
    if ((UnityEngine.Object) trans != (UnityEngine.Object) null)
    {
      while ((UnityEngine.Object) trans.parent != (UnityEngine.Object) null)
        trans = trans.parent;
      if (NGUITools.IsChild(trans, ui1.transform))
      {
        ui1 = trans.gameObject.AddComponent<UIPanel>();
      }
      else
      {
        trans.parent = ui1.transform;
        trans.localScale = Vector3.one;
        trans.localPosition = Vector3.zero;
        ui1.cachedTransform.SetChildLayer(ui1.cachedGameObject.layer);
      }
    }
    return ui1;
  }

  public static void SetChildLayer(this Transform t, int layer)
  {
    for (int index = 0; index < t.childCount; ++index)
    {
      Transform child = t.GetChild(index);
      child.gameObject.layer = layer;
      child.SetChildLayer(layer);
    }
  }

  public static T AddChild<T>(this GameObject parent) where T : Component
  {
    GameObject gameObject = NGUITools.AddChild(parent);
    string typeName;
    if (!NGUITools.mTypeNames.TryGetValue(typeof (T), out typeName) || typeName == null)
    {
      typeName = NGUITools.GetTypeName<T>();
      NGUITools.mTypeNames[typeof (T)] = typeName;
    }
    gameObject.name = typeName;
    return gameObject.AddComponent<T>();
  }

  public static T AddChild<T>(this GameObject parent, bool undo) where T : Component
  {
    GameObject gameObject = parent.AddChild(undo);
    string typeName;
    if (!NGUITools.mTypeNames.TryGetValue(typeof (T), out typeName) || typeName == null)
    {
      typeName = NGUITools.GetTypeName<T>();
      NGUITools.mTypeNames[typeof (T)] = typeName;
    }
    gameObject.name = typeName;
    return gameObject.AddComponent<T>();
  }

  public static T AddWidget<T>(this GameObject go, int depth = 2147483647) where T : UIWidget
  {
    if (depth == int.MaxValue)
      depth = NGUITools.CalculateNextDepth(go);
    T obj = go.AddChild<T>();
    obj.width = 100;
    obj.height = 100;
    obj.depth = depth;
    return obj;
  }

  public static UISprite AddSprite(
    this GameObject go,
    INGUIAtlas atlas,
    string spriteName,
    int depth = 2147483647)
  {
    UISpriteData sprite = atlas?.GetSprite(spriteName);
    UISprite uiSprite = go.AddWidget<UISprite>(depth);
    uiSprite.type = sprite == null || !sprite.hasBorder ? UIBasicSprite.Type.Simple : UIBasicSprite.Type.Sliced;
    uiSprite.atlas = atlas;
    uiSprite.spriteName = spriteName;
    return uiSprite;
  }

  public static GameObject GetRoot(GameObject go)
  {
    Transform transform = go.transform;
    while (true)
    {
      Transform parent = transform.parent;
      if (!((UnityEngine.Object) parent == (UnityEngine.Object) null))
        transform = parent;
      else
        break;
    }
    return transform.gameObject;
  }

  public static T FindInParents<T>(GameObject go) where T : Component => (UnityEngine.Object) go == (UnityEngine.Object) null ? default (T) : go.GetComponentInParent<T>();

  public static T FindInParents<T>(Transform trans) where T : Component => (UnityEngine.Object) trans == (UnityEngine.Object) null ? default (T) : trans.GetComponentInParent<T>();

  public static void Destroy(UnityEngine.Object obj)
  {
    if (!(bool) obj)
      return;
    if (obj is Transform)
    {
      Transform transform = obj as Transform;
      GameObject gameObject = transform.gameObject;
      if (Application.isPlaying)
      {
        gameObject.SetActive(false);
        transform.parent = (Transform) null;
        UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
      }
      else
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) gameObject);
    }
    else if (obj is GameObject)
    {
      GameObject gameObject = obj as GameObject;
      Transform transform = gameObject.transform;
      if (Application.isPlaying)
      {
        gameObject.SetActive(false);
        transform.parent = (Transform) null;
        UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
      }
      else
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) gameObject);
    }
    else if (Application.isPlaying)
      UnityEngine.Object.Destroy(obj);
    else
      UnityEngine.Object.DestroyImmediate(obj);
  }

  public static void DestroyChildren(this Transform t)
  {
    bool isPlaying = Application.isPlaying;
    while (t.childCount != 0)
    {
      Transform child = t.GetChild(0);
      if (isPlaying)
      {
        child.parent = (Transform) null;
        UnityEngine.Object.Destroy((UnityEngine.Object) child.gameObject);
      }
      else
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) child.gameObject);
    }
  }

  public static void DestroyImmediate(UnityEngine.Object obj)
  {
    if (!(obj != (UnityEngine.Object) null))
      return;
    if (Application.isEditor)
      UnityEngine.Object.DestroyImmediate(obj);
    else
      UnityEngine.Object.Destroy(obj);
  }

  public static void Broadcast(string funcName)
  {
    GameObject[] objectsOfType = UnityEngine.Object.FindObjectsOfType(typeof (GameObject)) as GameObject[];
    int index = 0;
    for (int length = objectsOfType.Length; index < length; ++index)
      objectsOfType[index].SendMessage(funcName, SendMessageOptions.DontRequireReceiver);
  }

  public static void Broadcast(string funcName, object param)
  {
    GameObject[] objectsOfType = UnityEngine.Object.FindObjectsOfType(typeof (GameObject)) as GameObject[];
    int index = 0;
    for (int length = objectsOfType.Length; index < length; ++index)
      objectsOfType[index].SendMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
  }

  public static bool IsChild(Transform parent, Transform child) => child.IsChildOf(parent);

  private static void Activate(Transform t) => NGUITools.Activate(t, false);

  private static void Activate(Transform t, bool compatibilityMode)
  {
    NGUITools.SetActiveSelf(t.gameObject, true);
    if (!compatibilityMode)
      return;
    int index1 = 0;
    for (int childCount = t.childCount; index1 < childCount; ++index1)
    {
      if (t.GetChild(index1).gameObject.activeSelf)
        return;
    }
    int index2 = 0;
    for (int childCount = t.childCount; index2 < childCount; ++index2)
      NGUITools.Activate(t.GetChild(index2), true);
  }

  private static void Deactivate(Transform t) => NGUITools.SetActiveSelf(t.gameObject, false);

  public static void SetActive(GameObject go, bool state) => NGUITools.SetActive(go, state, true);

  public static void SetActive(GameObject go, bool state, bool compatibilityMode)
  {
    if (!(bool) (UnityEngine.Object) go)
      return;
    if (state)
    {
      NGUITools.Activate(go.transform, compatibilityMode);
      NGUITools.CallCreatePanel(go.transform);
    }
    else
      NGUITools.Deactivate(go.transform);
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  private static void CallCreatePanel(Transform t)
  {
    UIWidget component = t.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      component.CreatePanel();
    int index = 0;
    for (int childCount = t.childCount; index < childCount; ++index)
      NGUITools.CallCreatePanel(t.GetChild(index));
  }

  public static void SetActiveChildren(GameObject go, bool state)
  {
    Transform transform = go.transform;
    if (state)
    {
      int index = 0;
      for (int childCount = transform.childCount; index < childCount; ++index)
        NGUITools.Activate(transform.GetChild(index));
    }
    else
    {
      int index = 0;
      for (int childCount = transform.childCount; index < childCount; ++index)
        NGUITools.Deactivate(transform.GetChild(index));
    }
  }

  [Obsolete("Use NGUITools.GetActive instead")]
  public static bool IsActive(Behaviour mb) => (UnityEngine.Object) mb != (UnityEngine.Object) null && mb.enabled && mb.gameObject.activeInHierarchy;

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static bool GetActive(Behaviour mb) => (bool) (UnityEngine.Object) mb && mb.enabled && mb.gameObject.activeInHierarchy;

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static bool GetActive(GameObject go) => (bool) (UnityEngine.Object) go && go.activeInHierarchy;

  [DebuggerHidden]
  [DebuggerStepThrough]
  public static void SetActiveSelf(GameObject go, bool state) => go.SetActive(state);

  public static void SetLayer(GameObject go, int layer)
  {
    go.layer = layer;
    Transform transform = go.transform;
    int index = 0;
    for (int childCount = transform.childCount; index < childCount; ++index)
      NGUITools.SetLayer(transform.GetChild(index).gameObject, layer);
  }

  public static Vector3 Round(Vector3 v)
  {
    v.x = Mathf.Round(v.x);
    v.y = Mathf.Round(v.y);
    v.z = Mathf.Round(v.z);
    return v;
  }

  public static void MakePixelPerfect(Transform t)
  {
    UIWidget component = t.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      component.MakePixelPerfect();
    if ((UnityEngine.Object) t.GetComponent<UIAnchor>() == (UnityEngine.Object) null && (UnityEngine.Object) t.GetComponent<UIRoot>() == (UnityEngine.Object) null)
    {
      t.localPosition = NGUITools.Round(t.localPosition);
      t.localScale = NGUITools.Round(t.localScale);
    }
    int index = 0;
    for (int childCount = t.childCount; index < childCount; ++index)
      NGUITools.MakePixelPerfect(t.GetChild(index));
  }

  public static void FitOnScreen(
    this Camera cam,
    Transform t,
    bool considerInactive = false,
    bool considerChildren = true)
  {
    Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(t, t, considerInactive, considerChildren);
    Vector3 screenPoint = cam.WorldToScreenPoint(t.position);
    Vector3 vector3_1 = screenPoint + relativeWidgetBounds.min;
    Vector3 vector3_2 = screenPoint + relativeWidgetBounds.max;
    int width = Screen.width;
    int height = Screen.height;
    Vector2 zero = Vector2.zero;
    if ((double) vector3_1.x < 0.0)
      zero.x = -vector3_1.x;
    else if ((double) vector3_2.x > (double) width)
      zero.x = (float) width - vector3_2.x;
    if ((double) vector3_1.y < 0.0)
      zero.y = -vector3_1.y;
    else if ((double) vector3_2.y > (double) height)
      zero.y = (float) height - vector3_2.y;
    if ((double) zero.sqrMagnitude <= 0.0)
      return;
    t.localPosition += new Vector3(zero.x, zero.y, 0.0f);
  }

  public static void FitOnScreen(this Camera cam, Transform transform, Vector3 pos) => cam.FitOnScreen(transform, transform, pos);

  public static void FitOnScreen(
    this Camera cam,
    Transform transform,
    Transform content,
    Vector3 pos,
    bool considerInactive = false)
  {
    cam.FitOnScreen(transform, content, pos, out Bounds _, considerInactive);
  }

  public static void FitOnScreen(
    this Camera cam,
    Transform transform,
    Transform content,
    Vector3 pos,
    out Bounds bounds,
    bool considerInactive = false)
  {
    bounds = NGUIMath.CalculateRelativeWidgetBounds(transform, content, considerInactive);
    Vector3 min = bounds.min;
    Vector3 max = bounds.max;
    Vector3 size = bounds.size;
    size.x += min.x;
    size.y -= max.y;
    if ((UnityEngine.Object) cam != (UnityEngine.Object) null)
    {
      pos.x = Mathf.Clamp01(pos.x / (float) Screen.width);
      pos.y = Mathf.Clamp01(pos.y / (float) Screen.height);
      float num = (float) Screen.height * 0.5f / (cam.orthographicSize / transform.parent.lossyScale.y);
      Vector3 vector3 = (Vector3) new Vector2(num * size.x / (float) Screen.width, num * size.y / (float) Screen.height);
      pos.x = Mathf.Min(pos.x, 1f - vector3.x);
      pos.y = Mathf.Max(pos.y, vector3.y);
      transform.position = cam.ViewportToWorldPoint(pos);
      pos = transform.localPosition;
      pos.x = Mathf.Round(pos.x);
      pos.y = Mathf.Round(pos.y);
    }
    else
    {
      if ((double) pos.x + (double) size.x > (double) Screen.width)
        pos.x = (float) Screen.width - size.x;
      if ((double) pos.y - (double) size.y < 0.0)
        pos.y = size.y;
      pos.x -= (float) Screen.width * 0.5f;
      pos.y -= (float) Screen.height * 0.5f;
    }
    transform.localPosition = pos;
  }

  public static bool Save(string fileName, byte[] bytes)
  {
    if (!NGUITools.fileAccess)
      return false;
    string path = Application.persistentDataPath + "/" + fileName;
    if (bytes == null)
    {
      if (File.Exists(path))
        File.Delete(path);
      return true;
    }
    FileStream fileStream;
    try
    {
      fileStream = File.Create(path);
    }
    catch (Exception ex)
    {
      UnityEngine.Debug.LogError((object) ex.Message);
      return false;
    }
    fileStream.Write(bytes, 0, bytes.Length);
    fileStream.Close();
    return true;
  }

  public static byte[] Load(string fileName)
  {
    if (!NGUITools.fileAccess)
      return (byte[]) null;
    string path = Application.persistentDataPath + "/" + fileName;
    return File.Exists(path) ? File.ReadAllBytes(path) : (byte[]) null;
  }

  public static Color ApplyPMA(Color c)
  {
    if ((double) c.a != 1.0)
    {
      c.r *= c.a;
      c.g *= c.a;
      c.b *= c.a;
    }
    return c;
  }

  public static void MarkParentAsChanged(GameObject go)
  {
    UIRect[] componentsInChildren = go.GetComponentsInChildren<UIRect>();
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
      componentsInChildren[index].ParentHasChanged();
  }

  public static string clipboard
  {
    get
    {
      TextEditor textEditor = new TextEditor();
      textEditor.Paste();
      return textEditor.text;
    }
    set
    {
      TextEditor textEditor = new TextEditor();
      textEditor.text = value;
      textEditor.OnFocus();
      textEditor.Copy();
    }
  }

  [Obsolete("Use NGUIText.EncodeColor instead")]
  public static string EncodeColor(Color c) => NGUIText.EncodeColor24(c);

  [Obsolete("Use NGUIText.ParseColor instead")]
  public static Color ParseColor(string text, int offset) => NGUIText.ParseColor24(text, offset);

  [Obsolete("Use NGUIText.StripSymbols instead")]
  public static string StripSymbols(string text) => NGUIText.StripSymbols(text);

  public static T AddMissingComponent<T>(this GameObject go) where T : Component
  {
    T obj = go.GetComponent<T>();
    if ((UnityEngine.Object) obj == (UnityEngine.Object) null)
      obj = go.AddComponent<T>();
    return obj;
  }

  public static Vector3[] GetSides(this Camera cam) => cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), (Transform) null);

  public static Vector3[] GetSides(this Camera cam, float depth) => cam.GetSides(depth, (Transform) null);

  public static Vector3[] GetSides(this Camera cam, Transform relativeTo) => cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);

  public static Vector3[] GetSides(this Camera cam, float depth, Transform relativeTo)
  {
    if (cam.orthographic)
    {
      double orthographicSize = (double) cam.orthographicSize;
      float num1 = (float) -orthographicSize;
      float num2 = (float) orthographicSize;
      float y1 = (float) -orthographicSize;
      float y2 = (float) orthographicSize;
      Rect rect = cam.rect;
      Vector2 screenSize = NGUITools.screenSize;
      float num3 = screenSize.x / screenSize.y * (rect.width / rect.height);
      float x1 = num1 * num3;
      float x2 = num2 * num3;
      Transform transform = cam.transform;
      Quaternion rotation = transform.rotation;
      Vector3 position = transform.position;
      int num4 = Mathf.RoundToInt(screenSize.x);
      int num5 = Mathf.RoundToInt(screenSize.y);
      if ((num4 & 1) == 1)
        position.x -= 1f / screenSize.x;
      if ((num5 & 1) == 1)
        position.y += 1f / screenSize.y;
      NGUITools.mSides[0] = rotation * new Vector3(x1, 0.0f, depth) + position;
      NGUITools.mSides[1] = rotation * new Vector3(0.0f, y2, depth) + position;
      NGUITools.mSides[2] = rotation * new Vector3(x2, 0.0f, depth) + position;
      NGUITools.mSides[3] = rotation * new Vector3(0.0f, y1, depth) + position;
    }
    else
    {
      NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0.0f, 0.5f, depth));
      NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, depth));
      NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, depth));
      NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, depth));
    }
    if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 4; ++index)
        NGUITools.mSides[index] = relativeTo.InverseTransformPoint(NGUITools.mSides[index]);
    }
    return NGUITools.mSides;
  }

  public static Vector3[] GetWorldCorners(this Camera cam)
  {
    float depth = Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f);
    return cam.GetWorldCorners(depth, (Transform) null);
  }

  public static Vector3[] GetWorldCorners(this Camera cam, float depth) => cam.GetWorldCorners(depth, (Transform) null);

  public static Vector3[] GetWorldCorners(this Camera cam, Transform relativeTo) => cam.GetWorldCorners(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);

  public static Vector3[] GetWorldCorners(
    this Camera cam,
    float depth,
    Transform relativeTo)
  {
    if (cam.orthographic)
    {
      double orthographicSize = (double) cam.orthographicSize;
      float num1 = (float) -orthographicSize;
      float num2 = (float) orthographicSize;
      float y1 = (float) -orthographicSize;
      float y2 = (float) orthographicSize;
      Rect rect = cam.rect;
      Vector2 screenSize = NGUITools.screenSize;
      float num3 = screenSize.x / screenSize.y * (rect.width / rect.height);
      float x1 = num1 * num3;
      float x2 = num2 * num3;
      Transform transform = cam.transform;
      Quaternion rotation = transform.rotation;
      Vector3 position = transform.position;
      NGUITools.mSides[0] = rotation * new Vector3(x1, y1, depth) + position;
      NGUITools.mSides[1] = rotation * new Vector3(x1, y2, depth) + position;
      NGUITools.mSides[2] = rotation * new Vector3(x2, y2, depth) + position;
      NGUITools.mSides[3] = rotation * new Vector3(x2, y1, depth) + position;
    }
    else
    {
      NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, depth));
      NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.0f, 1f, depth));
      NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 1f, depth));
      NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(1f, 0.0f, depth));
    }
    if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 4; ++index)
        NGUITools.mSides[index] = relativeTo.InverseTransformPoint(NGUITools.mSides[index]);
    }
    return NGUITools.mSides;
  }

  public static string GetFuncName(object obj, string method)
  {
    if (obj == null)
      return "<null>";
    string str = obj.GetType().ToString();
    int num = str.LastIndexOf('/');
    if (num > 0)
      str = str.Substring(num + 1);
    return !string.IsNullOrEmpty(method) ? str + "/" + method : str;
  }

  public static void Execute<T>(GameObject go, string funcName) where T : Component
  {
    foreach (T component in go.GetComponents<T>())
    {
      MethodInfo method = ((object) component).GetType().GetMethod(funcName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      if (method != (MethodInfo) null)
        method.Invoke((object) component, (object[]) null);
    }
  }

  public static void ExecuteAll<T>(GameObject root, string funcName) where T : Component
  {
    NGUITools.Execute<T>(root, funcName);
    Transform transform = root.transform;
    int index = 0;
    for (int childCount = transform.childCount; index < childCount; ++index)
      NGUITools.ExecuteAll<T>(transform.GetChild(index).gameObject, funcName);
  }

  public static void ImmediatelyCreateDrawCalls(GameObject root)
  {
    NGUITools.ExecuteAll<UIWidget>(root, "Start");
    NGUITools.ExecuteAll<UIPanel>(root, "Start");
    NGUITools.ExecuteAll<UIWidget>(root, "Update");
    NGUITools.ExecuteAll<UIPanel>(root, "Update");
    NGUITools.ExecuteAll<UIPanel>(root, "LateUpdate");
  }

  public static Vector2 screenSize => new Vector2((float) Screen.width, (float) Screen.height);

  public static string KeyToCaption(KeyCode key)
  {
    switch (key)
    {
      case KeyCode.None:
        return (string) null;
      case KeyCode.Backspace:
        return "Backspace";
      case KeyCode.Tab:
        return "Tab";
      case KeyCode.Clear:
        return "Clear";
      case KeyCode.Return:
        return "Return";
      case KeyCode.Pause:
        return "PS";
      case KeyCode.Escape:
        return "Esc";
      case KeyCode.Space:
        return "Space";
      case KeyCode.Exclaim:
        return "!";
      case KeyCode.DoubleQuote:
        return "''";
      case KeyCode.Hash:
        return "#";
      case KeyCode.Dollar:
        return "$";
      case KeyCode.Ampersand:
        return "&";
      case KeyCode.Quote:
        return "'";
      case KeyCode.LeftParen:
        return "(";
      case KeyCode.RightParen:
        return ")";
      case KeyCode.Asterisk:
        return "*";
      case KeyCode.Plus:
        return "+";
      case KeyCode.Comma:
        return ",";
      case KeyCode.Minus:
        return "-";
      case KeyCode.Period:
        return ".";
      case KeyCode.Slash:
        return "/";
      case KeyCode.Alpha0:
        return "0";
      case KeyCode.Alpha1:
        return "1";
      case KeyCode.Alpha2:
        return "2";
      case KeyCode.Alpha3:
        return "3";
      case KeyCode.Alpha4:
        return "4";
      case KeyCode.Alpha5:
        return "5";
      case KeyCode.Alpha6:
        return "6";
      case KeyCode.Alpha7:
        return "7";
      case KeyCode.Alpha8:
        return "8";
      case KeyCode.Alpha9:
        return "9";
      case KeyCode.Colon:
        return ":";
      case KeyCode.Semicolon:
        return ";";
      case KeyCode.Less:
        return "<";
      case KeyCode.Equals:
        return "=";
      case KeyCode.Greater:
        return ">";
      case KeyCode.Question:
        return "?";
      case KeyCode.At:
        return "@";
      case KeyCode.LeftBracket:
        return "[";
      case KeyCode.Backslash:
        return "\\";
      case KeyCode.RightBracket:
        return "]";
      case KeyCode.Caret:
        return "^";
      case KeyCode.Underscore:
        return "_";
      case KeyCode.BackQuote:
        return "`";
      case KeyCode.A:
        return "A";
      case KeyCode.B:
        return "B";
      case KeyCode.C:
        return "C";
      case KeyCode.D:
        return "D";
      case KeyCode.E:
        return "E";
      case KeyCode.F:
        return "F";
      case KeyCode.G:
        return "G";
      case KeyCode.H:
        return "H";
      case KeyCode.I:
        return "I";
      case KeyCode.J:
        return "J";
      case KeyCode.K:
        return "K";
      case KeyCode.L:
        return "L";
      case KeyCode.M:
        return "M";
      case KeyCode.N:
        return "N";
      case KeyCode.O:
        return "O";
      case KeyCode.P:
        return "P";
      case KeyCode.Q:
        return "Q";
      case KeyCode.R:
        return "R";
      case KeyCode.S:
        return "S";
      case KeyCode.T:
        return "T";
      case KeyCode.U:
        return "U";
      case KeyCode.V:
        return "V";
      case KeyCode.W:
        return "W";
      case KeyCode.X:
        return "X";
      case KeyCode.Y:
        return "Y";
      case KeyCode.Z:
        return "Z";
      case KeyCode.Delete:
        return "Del";
      case KeyCode.Keypad0:
        return "K0";
      case KeyCode.Keypad1:
        return "K1";
      case KeyCode.Keypad2:
        return "K2";
      case KeyCode.Keypad3:
        return "K3";
      case KeyCode.Keypad4:
        return "K4";
      case KeyCode.Keypad5:
        return "K5";
      case KeyCode.Keypad6:
        return "K6";
      case KeyCode.Keypad7:
        return "K7";
      case KeyCode.Keypad8:
        return "K8";
      case KeyCode.Keypad9:
        return "K9";
      case KeyCode.KeypadPeriod:
        return "K.";
      case KeyCode.KeypadDivide:
        return "K/";
      case KeyCode.KeypadMultiply:
        return "K*";
      case KeyCode.KeypadMinus:
        return "K-";
      case KeyCode.KeypadPlus:
        return "K+";
      case KeyCode.KeypadEnter:
        return "KE";
      case KeyCode.KeypadEquals:
        return "KQ";
      case KeyCode.UpArrow:
        return "UP";
      case KeyCode.DownArrow:
        return "DN";
      case KeyCode.RightArrow:
        return "LT";
      case KeyCode.LeftArrow:
        return "RT";
      case KeyCode.Insert:
        return "Ins";
      case KeyCode.Home:
        return "Home";
      case KeyCode.End:
        return "End";
      case KeyCode.PageUp:
        return "PU";
      case KeyCode.PageDown:
        return "PD";
      case KeyCode.F1:
        return "F1";
      case KeyCode.F2:
        return "F2";
      case KeyCode.F3:
        return "F3";
      case KeyCode.F4:
        return "F4";
      case KeyCode.F5:
        return "F5";
      case KeyCode.F6:
        return "F6";
      case KeyCode.F7:
        return "F7";
      case KeyCode.F8:
        return "F8";
      case KeyCode.F9:
        return "F9";
      case KeyCode.F10:
        return "F10";
      case KeyCode.F11:
        return "F11";
      case KeyCode.F12:
        return "F12";
      case KeyCode.F13:
        return "F13";
      case KeyCode.F14:
        return "F14";
      case KeyCode.F15:
        return "F15";
      case KeyCode.Numlock:
        return "Num";
      case KeyCode.CapsLock:
        return "Cap";
      case KeyCode.ScrollLock:
        return "Scr";
      case KeyCode.RightShift:
        return "RS";
      case KeyCode.LeftShift:
        return "LS";
      case KeyCode.RightControl:
        return "RC";
      case KeyCode.LeftControl:
        return "LC";
      case KeyCode.RightAlt:
        return "RA";
      case KeyCode.LeftAlt:
        return "LA";
      case KeyCode.Mouse0:
        return "M0";
      case KeyCode.Mouse1:
        return "M1";
      case KeyCode.Mouse2:
        return "M2";
      case KeyCode.Mouse3:
        return "M3";
      case KeyCode.Mouse4:
        return "M4";
      case KeyCode.Mouse5:
        return "M5";
      case KeyCode.Mouse6:
        return "M6";
      case KeyCode.JoystickButton0:
        return "(A)";
      case KeyCode.JoystickButton1:
        return "(B)";
      case KeyCode.JoystickButton2:
        return "(X)";
      case KeyCode.JoystickButton3:
        return "(Y)";
      case KeyCode.JoystickButton4:
        return "(RB)";
      case KeyCode.JoystickButton5:
        return "(LB)";
      case KeyCode.JoystickButton6:
        return "(Back)";
      case KeyCode.JoystickButton7:
        return "(Start)";
      case KeyCode.JoystickButton8:
        return "(LS)";
      case KeyCode.JoystickButton9:
        return "(RS)";
      case KeyCode.JoystickButton10:
        return "J10";
      case KeyCode.JoystickButton11:
        return "J11";
      case KeyCode.JoystickButton12:
        return "J12";
      case KeyCode.JoystickButton13:
        return "J13";
      case KeyCode.JoystickButton14:
        return "J14";
      case KeyCode.JoystickButton15:
        return "J15";
      case KeyCode.JoystickButton16:
        return "J16";
      case KeyCode.JoystickButton17:
        return "J17";
      case KeyCode.JoystickButton18:
        return "J18";
      case KeyCode.JoystickButton19:
        return "J19";
      default:
        return (string) null;
    }
  }

  public static KeyCode CaptionToKey(string caption)
  {
    if (string.IsNullOrEmpty(caption))
      return KeyCode.None;
    if (caption == "Backspace")
      return KeyCode.Backspace;
    if (caption == "Tab")
      return KeyCode.Tab;
    if (caption == "Clear")
      return KeyCode.Clear;
    if (caption == "Return")
      return KeyCode.Return;
    if (caption == "Pause")
      return KeyCode.Pause;
    if (caption == "Esc")
      return KeyCode.Escape;
    if (caption == "Space")
      return KeyCode.Space;
    if (caption == "!")
      return KeyCode.Exclaim;
    if (caption == "''")
      return KeyCode.DoubleQuote;
    if (caption == "#")
      return KeyCode.Hash;
    if (caption == "$")
      return KeyCode.Dollar;
    if (caption == "&")
      return KeyCode.Ampersand;
    if (caption == "'")
      return KeyCode.Quote;
    if (caption == "(")
      return KeyCode.LeftParen;
    if (caption == ")")
      return KeyCode.RightParen;
    if (caption == "*")
      return KeyCode.Asterisk;
    if (caption == "+")
      return KeyCode.Plus;
    if (caption == ",")
      return KeyCode.Comma;
    if (caption == "-")
      return KeyCode.Minus;
    if (caption == ".")
      return KeyCode.Period;
    if (caption == "/")
      return KeyCode.Slash;
    if (caption == "0")
      return KeyCode.Alpha0;
    if (caption == "1")
      return KeyCode.Alpha1;
    if (caption == "2")
      return KeyCode.Alpha2;
    if (caption == "3")
      return KeyCode.Alpha3;
    if (caption == "4")
      return KeyCode.Alpha4;
    if (caption == "5")
      return KeyCode.Alpha5;
    if (caption == "6")
      return KeyCode.Alpha6;
    if (caption == "7")
      return KeyCode.Alpha7;
    if (caption == "8")
      return KeyCode.Alpha8;
    if (caption == "9")
      return KeyCode.Alpha9;
    if (caption == ";//")
      return KeyCode.Colon;
    if (caption == ";")
      return KeyCode.Semicolon;
    if (caption == "<")
      return KeyCode.Less;
    if (caption == "=")
      return KeyCode.Equals;
    if (caption == ">")
      return KeyCode.Greater;
    if (caption == "?")
      return KeyCode.Question;
    if (caption == "@")
      return KeyCode.At;
    if (caption == "[")
      return KeyCode.LeftBracket;
    if (caption == "\\")
      return KeyCode.Backslash;
    if (caption == "]")
      return KeyCode.RightBracket;
    if (caption == "^")
      return KeyCode.Caret;
    if (caption == "_")
      return KeyCode.Underscore;
    if (caption == "`")
      return KeyCode.BackQuote;
    if (caption == "A")
      return KeyCode.A;
    if (caption == "B")
      return KeyCode.B;
    if (caption == "C")
      return KeyCode.C;
    if (caption == "D")
      return KeyCode.D;
    if (caption == "E")
      return KeyCode.E;
    if (caption == "F")
      return KeyCode.F;
    if (caption == "G")
      return KeyCode.G;
    if (caption == "H")
      return KeyCode.H;
    if (caption == "I")
      return KeyCode.I;
    if (caption == "J")
      return KeyCode.J;
    if (caption == "K")
      return KeyCode.K;
    if (caption == "L")
      return KeyCode.L;
    if (caption == "M")
      return KeyCode.M;
    if (caption == "N")
      return KeyCode.N;
    if (caption == "O")
      return KeyCode.O;
    if (caption == "P")
      return KeyCode.P;
    if (caption == "Q")
      return KeyCode.Q;
    if (caption == "R")
      return KeyCode.R;
    if (caption == "S")
      return KeyCode.S;
    if (caption == "T")
      return KeyCode.T;
    if (caption == "U")
      return KeyCode.U;
    if (caption == "V")
      return KeyCode.V;
    if (caption == "W")
      return KeyCode.W;
    if (caption == "X")
      return KeyCode.X;
    if (caption == "Y")
      return KeyCode.Y;
    if (caption == "Z")
      return KeyCode.Z;
    if (caption == "Del")
      return KeyCode.Delete;
    if (caption == "K0")
      return KeyCode.Keypad0;
    if (caption == "K1")
      return KeyCode.Keypad1;
    if (caption == "K2")
      return KeyCode.Keypad2;
    if (caption == "K3")
      return KeyCode.Keypad3;
    if (caption == "K4")
      return KeyCode.Keypad4;
    if (caption == "K5")
      return KeyCode.Keypad5;
    if (caption == "K6")
      return KeyCode.Keypad6;
    if (caption == "K7")
      return KeyCode.Keypad7;
    if (caption == "K8")
      return KeyCode.Keypad8;
    if (caption == "K9")
      return KeyCode.Keypad9;
    if (caption == "K.")
      return KeyCode.KeypadPeriod;
    if (caption == "K/")
      return KeyCode.KeypadDivide;
    if (caption == "K*")
      return KeyCode.KeypadMultiply;
    if (caption == "K-")
      return KeyCode.KeypadMinus;
    if (caption == "K+")
      return KeyCode.KeypadPlus;
    if (caption == "KE")
      return KeyCode.KeypadEnter;
    if (caption == "KQ")
      return KeyCode.KeypadEquals;
    if (caption == "UP")
      return KeyCode.UpArrow;
    if (caption == "DN")
      return KeyCode.DownArrow;
    if (caption == "LT")
      return KeyCode.RightArrow;
    if (caption == "RT")
      return KeyCode.LeftArrow;
    if (caption == "Ins")
      return KeyCode.Insert;
    if (caption == "Home")
      return KeyCode.Home;
    if (caption == "End")
      return KeyCode.End;
    if (caption == "PU")
      return KeyCode.PageUp;
    if (caption == "PD")
      return KeyCode.PageDown;
    if (caption == "F1")
      return KeyCode.F1;
    if (caption == "F2")
      return KeyCode.F2;
    if (caption == "F3")
      return KeyCode.F3;
    if (caption == "F4")
      return KeyCode.F4;
    if (caption == "F5")
      return KeyCode.F5;
    if (caption == "F6")
      return KeyCode.F6;
    if (caption == "F7")
      return KeyCode.F7;
    if (caption == "F8")
      return KeyCode.F8;
    if (caption == "F9")
      return KeyCode.F9;
    if (caption == "F10")
      return KeyCode.F10;
    if (caption == "F11")
      return KeyCode.F11;
    if (caption == "F12")
      return KeyCode.F12;
    if (caption == "F13")
      return KeyCode.F13;
    if (caption == "F14")
      return KeyCode.F14;
    if (caption == "F15")
      return KeyCode.F15;
    if (caption == "Num")
      return KeyCode.Numlock;
    if (caption == "Cap")
      return KeyCode.CapsLock;
    if (caption == "Scr")
      return KeyCode.ScrollLock;
    if (caption == "RS")
      return KeyCode.RightShift;
    if (caption == "LS")
      return KeyCode.LeftShift;
    if (caption == "RC")
      return KeyCode.RightControl;
    if (caption == "LC")
      return KeyCode.LeftControl;
    if (caption == "RA")
      return KeyCode.RightAlt;
    if (caption == "LA")
      return KeyCode.LeftAlt;
    if (caption == "M0")
      return KeyCode.Mouse0;
    if (caption == "M1")
      return KeyCode.Mouse1;
    if (caption == "M2")
      return KeyCode.Mouse2;
    if (caption == "M3")
      return KeyCode.Mouse3;
    if (caption == "M4")
      return KeyCode.Mouse4;
    if (caption == "M5")
      return KeyCode.Mouse5;
    if (caption == "M6")
      return KeyCode.Mouse6;
    if (caption == "(A)")
      return KeyCode.JoystickButton0;
    if (caption == "(B)")
      return KeyCode.JoystickButton1;
    if (caption == "(X)")
      return KeyCode.JoystickButton2;
    if (caption == "(Y)")
      return KeyCode.JoystickButton3;
    if (caption == "(RB)")
      return KeyCode.JoystickButton4;
    if (caption == "(LB)")
      return KeyCode.JoystickButton5;
    if (caption == "(Back)")
      return KeyCode.JoystickButton6;
    if (caption == "(Start)")
      return KeyCode.JoystickButton7;
    if (caption == "(LS)")
      return KeyCode.JoystickButton8;
    if (caption == "(RS)")
      return KeyCode.JoystickButton9;
    if (caption == "J10")
      return KeyCode.JoystickButton10;
    if (caption == "J11")
      return KeyCode.JoystickButton11;
    if (caption == "J12")
      return KeyCode.JoystickButton12;
    if (caption == "J13")
      return KeyCode.JoystickButton13;
    if (caption == "J14")
      return KeyCode.JoystickButton14;
    if (caption == "J15")
      return KeyCode.JoystickButton15;
    if (caption == "J16")
      return KeyCode.JoystickButton16;
    if (caption == "J17")
      return KeyCode.JoystickButton17;
    if (caption == "J18")
      return KeyCode.JoystickButton18;
    return caption == "J19" ? KeyCode.JoystickButton19 : KeyCode.None;
  }

  public static T Draw<T>(string id, NGUITools.OnInitFunc<T> onInit = null) where T : UIWidget
  {
    UIWidget uiWidget;
    if (NGUITools.mWidgets.TryGetValue(id, out uiWidget) && (bool) (UnityEngine.Object) uiWidget)
      return (T) uiWidget;
    if ((UnityEngine.Object) NGUITools.mRoot == (UnityEngine.Object) null)
    {
      UICamera uiCamera = (UICamera) null;
      UIRoot uiRoot1 = (UIRoot) null;
      for (int index = 0; index < UIRoot.list.Count; ++index)
      {
        UIRoot uiRoot2 = UIRoot.list[index];
        if ((bool) (UnityEngine.Object) uiRoot2)
        {
          UICamera cameraForLayer = UICamera.FindCameraForLayer(uiRoot2.gameObject.layer);
          if ((bool) (UnityEngine.Object) cameraForLayer && cameraForLayer.cachedCamera.orthographic)
          {
            uiCamera = cameraForLayer;
            uiRoot1 = uiRoot2;
            break;
          }
        }
      }
      NGUITools.mRoot = !((UnityEngine.Object) uiCamera == (UnityEngine.Object) null) ? uiRoot1.gameObject.AddChild<UIPanel>() : NGUITools.CreateUI(false, LayerMask.NameToLayer("UI"));
      NGUITools.mRoot.depth = 100000;
      NGUITools.mGo = NGUITools.mRoot.gameObject;
      NGUITools.mGo.name = "Immediate Mode GUI";
    }
    UIWidget w = (UIWidget) NGUITools.mGo.AddWidget<T>();
    w.name = id;
    NGUITools.mWidgets[id] = w;
    if (onInit != null)
      onInit((T) w);
    return (T) w;
  }

  public static Color GammaToLinearSpace(this Color c)
  {
    if (NGUITools.mColorSpace == ColorSpace.Uninitialized)
      NGUITools.mColorSpace = QualitySettings.activeColorSpace;
    return NGUITools.mColorSpace == ColorSpace.Linear ? new Color(Mathf.GammaToLinearSpace(c.r), Mathf.GammaToLinearSpace(c.g), Mathf.GammaToLinearSpace(c.b), Mathf.GammaToLinearSpace(c.a)) : c;
  }

  public static Color LinearToGammaSpace(this Color c)
  {
    if (NGUITools.mColorSpace == ColorSpace.Uninitialized)
      NGUITools.mColorSpace = QualitySettings.activeColorSpace;
    return NGUITools.mColorSpace == ColorSpace.Linear ? new Color(Mathf.LinearToGammaSpace(c.r), Mathf.LinearToGammaSpace(c.g), Mathf.LinearToGammaSpace(c.b), Mathf.LinearToGammaSpace(c.a)) : c;
  }

  public static bool CheckIfRelated(INGUIAtlas a, INGUIAtlas b)
  {
    if (a == null || b == null)
      return false;
    return a == b || a.References(b) || b.References(a);
  }

  public static void Replace(INGUIAtlas before, INGUIAtlas after)
  {
    UISprite[] active1 = NGUITools.FindActive<UISprite>();
    int index1 = 0;
    for (int length = active1.Length; index1 < length; ++index1)
    {
      UISprite uiSprite = active1[index1];
      if (uiSprite.atlas == before)
        uiSprite.atlas = after;
    }
    UIFont[] objectsOfTypeAll1 = Resources.FindObjectsOfTypeAll<UIFont>();
    int index2 = 0;
    for (int length = objectsOfTypeAll1.Length; index2 < length; ++index2)
    {
      UIFont uiFont = objectsOfTypeAll1[index2];
      if (uiFont.atlas == before)
        uiFont.atlas = after;
    }
    NGUIFont[] objectsOfTypeAll2 = Resources.FindObjectsOfTypeAll<NGUIFont>();
    int index3 = 0;
    for (int length = objectsOfTypeAll2.Length; index3 < length; ++index3)
    {
      NGUIFont nguiFont = objectsOfTypeAll2[index3];
      if (nguiFont.atlas == before)
        nguiFont.atlas = after;
    }
    UILabel[] active2 = NGUITools.FindActive<UILabel>();
    int index4 = 0;
    for (int length = active2.Length; index4 < length; ++index4)
    {
      UILabel uiLabel = active2[index4];
      if (uiLabel.bitmapFont != null && uiLabel.atlas == before)
        uiLabel.atlas = after;
    }
  }

  public static bool CheckIfRelated(INGUIFont a, INGUIFont b)
  {
    if (a == null || b == null)
      return false;
    return a.isDynamic && b.isDynamic && a.dynamicFont.fontNames[0] == b.dynamicFont.fontNames[0] || a == b || a.References(b) || b.References(a);
  }

  public delegate void OnInitFunc<T>(T w) where T : UIWidget;
}
