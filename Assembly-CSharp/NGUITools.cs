using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;

public static class NGUITools
{
	public delegate void OnInitFunc<T>(T w) where T : UIWidget;

	[NonSerialized]
	private static AudioListener mListener;

	[NonSerialized]
	public static AudioSource audioSource;

	private static bool mLoaded = false;

	private static float mGlobalVolume = 1f;

	private static float mLastTimestamp = 0f;

	private static AudioClip mLastClip;

	private static Dictionary<Type, string> mTypeNames = new Dictionary<Type, string>();

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
			if (!mLoaded)
			{
				mLoaded = true;
				mGlobalVolume = PlayerPrefs.GetFloat("Sound", 1f);
			}
			return mGlobalVolume;
		}
		set
		{
			if (mGlobalVolume != value)
			{
				mLoaded = true;
				mGlobalVolume = value;
				PlayerPrefs.SetFloat("Sound", value);
			}
		}
	}

	public static bool fileAccess
	{
		get
		{
			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				return false;
			}
			return true;
		}
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

	public static Vector2 screenSize => new Vector2(Screen.width, Screen.height);

	public static AudioSource PlaySound(AudioClip clip)
	{
		return PlaySound(clip, 1f, 1f);
	}

	public static AudioSource PlaySound(AudioClip clip, float volume)
	{
		return PlaySound(clip, volume, 1f);
	}

	public static AudioSource PlaySound(AudioClip clip, float volume, float pitch)
	{
		float time = RealTime.time;
		if (mLastClip == clip && mLastTimestamp + 0.1f > time)
		{
			return null;
		}
		mLastClip = clip;
		mLastTimestamp = time;
		volume *= soundVolume;
		if (clip != null && volume > 0.01f)
		{
			if (mListener == null || !GetActive(mListener))
			{
				if (UnityEngine.Object.FindObjectsOfType(typeof(AudioListener)) is AudioListener[] array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (GetActive(array[i]))
						{
							mListener = array[i];
							break;
						}
					}
				}
				if (mListener == null)
				{
					Camera camera = Camera.main;
					if (camera == null)
					{
						camera = UnityEngine.Object.FindObjectOfType(typeof(Camera)) as Camera;
					}
					if (camera != null)
					{
						mListener = camera.gameObject.AddComponent<AudioListener>();
					}
				}
			}
			if (mListener != null && mListener.enabled && GetActive(mListener.gameObject))
			{
				if (!audioSource)
				{
					audioSource = mListener.GetComponent<AudioSource>();
					if (audioSource == null)
					{
						audioSource = mListener.gameObject.AddComponent<AudioSource>();
					}
				}
				audioSource.priority = 50;
				audioSource.pitch = pitch;
				audioSource.PlayOneShot(clip, volume);
				return audioSource;
			}
		}
		return null;
	}

	public static int RandomRange(int min, int max)
	{
		if (min == max)
		{
			return min;
		}
		return UnityEngine.Random.Range(min, max + 1);
	}

	public static string GetHierarchy(GameObject obj)
	{
		if (obj == null)
		{
			return "";
		}
		string text = obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = obj.name + "\\" + text;
		}
		return text;
	}

	public static T[] FindActive<T>() where T : Component
	{
		return UnityEngine.Object.FindObjectsOfType(typeof(T)) as T[];
	}

	public static Camera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		Camera cachedCamera;
		for (int i = 0; i < UICamera.list.size; i++)
		{
			cachedCamera = UICamera.list.buffer[i].cachedCamera;
			if ((bool)cachedCamera && (cachedCamera.cullingMask & num) != 0)
			{
				return cachedCamera;
			}
		}
		cachedCamera = Camera.main;
		if ((bool)cachedCamera && (cachedCamera.cullingMask & num) != 0)
		{
			return cachedCamera;
		}
		Camera[] array = new Camera[Camera.allCamerasCount];
		int allCameras = Camera.GetAllCameras(array);
		for (int j = 0; j < allCameras; j++)
		{
			cachedCamera = array[j];
			if ((bool)cachedCamera && cachedCamera.enabled && (cachedCamera.cullingMask & num) != 0)
			{
				return cachedCamera;
			}
		}
		return null;
	}

	public static void AddWidgetCollider(GameObject go)
	{
		AddWidgetCollider(go, considerInactive: false);
	}

	public static void AddWidgetCollider(GameObject go, bool considerInactive)
	{
		if (!(go != null))
		{
			return;
		}
		Collider component = go.GetComponent<Collider>();
		BoxCollider boxCollider = component as BoxCollider;
		if (boxCollider != null)
		{
			UpdateWidgetCollider(boxCollider, considerInactive);
		}
		else
		{
			if (component != null)
			{
				return;
			}
			BoxCollider2D component2 = go.GetComponent<BoxCollider2D>();
			if (component2 != null)
			{
				UpdateWidgetCollider(component2, considerInactive);
				return;
			}
			UICamera uICamera = UICamera.FindCameraForLayer(go.layer);
			if (uICamera != null && (uICamera.eventType == UICamera.EventType.World_2D || uICamera.eventType == UICamera.EventType.UI_2D))
			{
				component2 = go.AddComponent<BoxCollider2D>();
				component2.isTrigger = true;
				UIWidget component3 = go.GetComponent<UIWidget>();
				if (component3 != null)
				{
					component3.autoResizeBoxCollider = true;
				}
				UpdateWidgetCollider(component2, considerInactive);
			}
			else
			{
				boxCollider = go.AddComponent<BoxCollider>();
				boxCollider.isTrigger = true;
				UIWidget component4 = go.GetComponent<UIWidget>();
				if (component4 != null)
				{
					component4.autoResizeBoxCollider = true;
				}
				UpdateWidgetCollider(boxCollider, considerInactive);
			}
		}
	}

	public static void UpdateWidgetCollider(GameObject go)
	{
		UpdateWidgetCollider(go, considerInactive: false);
	}

	public static void UpdateWidgetCollider(GameObject go, bool considerInactive)
	{
		if (!(go != null))
		{
			return;
		}
		BoxCollider component = go.GetComponent<BoxCollider>();
		if (component != null)
		{
			UpdateWidgetCollider(component, considerInactive);
			return;
		}
		BoxCollider2D component2 = go.GetComponent<BoxCollider2D>();
		if (component2 != null)
		{
			UpdateWidgetCollider(component2, considerInactive);
		}
	}

	public static void UpdateWidgetCollider(BoxCollider box, bool considerInactive)
	{
		if (!(box != null))
		{
			return;
		}
		GameObject gameObject = box.gameObject;
		UIWidget component = gameObject.GetComponent<UIWidget>();
		if (component != null)
		{
			Vector4 drawRegion = component.drawRegion;
			if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
			{
				Vector4 drawingDimensions = component.drawingDimensions;
				box.center = new Vector3((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
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
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
			box.center = bounds.center;
			box.size = new Vector3(bounds.size.x, bounds.size.y, 0f);
		}
	}

	public static void UpdateWidgetCollider(UIWidget w)
	{
		if (!(w == null))
		{
			BoxCollider component = w.GetComponent<BoxCollider>();
			if (component != null)
			{
				UpdateWidgetCollider(w, component);
			}
			else
			{
				UpdateWidgetCollider(w, w.GetComponent<BoxCollider2D>());
			}
		}
	}

	public static void UpdateWidgetCollider(UIWidget w, BoxCollider box)
	{
		if (!(box != null) || !(w != null))
		{
			return;
		}
		Vector4 drawRegion = w.drawRegion;
		if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
		{
			Vector4 drawingDimensions = w.drawingDimensions;
			Vector3 vector = new Vector3((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
			Vector3 vector2 = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
			if (vector != box.center || vector2 != box.size)
			{
				box.center = vector;
				box.size = vector2;
				SetDirty(box);
			}
		}
		else
		{
			Vector3[] localCorners = w.localCorners;
			Vector3 vector3 = Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
			Vector3 vector4 = localCorners[2] - localCorners[0];
			if (vector3 != box.center || vector4 != box.size)
			{
				box.center = vector3;
				box.size = vector4;
				SetDirty(box);
			}
		}
	}

	public static void UpdateWidgetCollider(UIWidget w, BoxCollider2D box)
	{
		if (!(box != null) || !(w != null))
		{
			return;
		}
		Vector4 drawRegion = w.drawRegion;
		if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
		{
			Vector4 drawingDimensions = w.drawingDimensions;
			Vector2 vector = new Vector2((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
			Vector2 vector2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
			if (vector != box.offset || vector2 != box.size)
			{
				box.offset = vector;
				box.size = vector2;
				SetDirty(box);
			}
		}
		else
		{
			Vector3[] localCorners = w.localCorners;
			Vector2 vector3 = Vector2.Lerp(localCorners[0], localCorners[2], 0.5f);
			Vector2 vector4 = localCorners[2] - localCorners[0];
			if (vector3 != box.offset || vector4 != box.size)
			{
				box.offset = vector3;
				box.size = vector4;
				SetDirty(box);
			}
		}
	}

	public static void UpdateWidgetCollider(BoxCollider2D box, bool considerInactive)
	{
		if (!(box != null))
		{
			return;
		}
		GameObject gameObject = box.gameObject;
		UIWidget component = gameObject.GetComponent<UIWidget>();
		if (component != null)
		{
			Vector4 drawRegion = component.drawRegion;
			if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
			{
				Vector4 drawingDimensions = component.drawingDimensions;
				Vector2 vector = new Vector2((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
				Vector2 vector2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
				if (vector != box.offset || vector2 != box.size)
				{
					box.offset = vector;
					box.size = vector2;
					SetDirty(box);
				}
			}
			else
			{
				Vector3[] localCorners = component.localCorners;
				Vector2 vector3 = Vector2.Lerp(localCorners[0], localCorners[2], 0.5f);
				Vector2 vector4 = localCorners[2] - localCorners[0];
				if (vector3 != box.offset || vector4 != box.size)
				{
					box.offset = vector3;
					box.size = vector4;
					SetDirty(box);
				}
			}
		}
		else
		{
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
			box.offset = bounds.center;
			box.size = new Vector2(bounds.size.x, bounds.size.y);
		}
	}

	public static string GetTypeName<T>()
	{
		string text = typeof(T).ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(12);
		}
		return text;
	}

	public static string GetTypeName(UnityEngine.Object obj)
	{
		if (obj == null)
		{
			return "Null";
		}
		string text = obj.GetType().ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(12);
		}
		return text;
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

	public static GameObject AddChild(GameObject parent)
	{
		return parent.AddChild(undo: true, -1);
	}

	public static GameObject AddChild(this GameObject parent, int layer)
	{
		return parent.AddChild(undo: true, layer);
	}

	public static GameObject AddChild(this GameObject parent, bool undo)
	{
		return parent.AddChild(undo, -1);
	}

	public static GameObject AddChild(this GameObject parent, bool undo, int layer)
	{
		GameObject gameObject = new GameObject();
		if (parent != null)
		{
			Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			switch (layer)
			{
			case -1:
				gameObject.layer = parent.layer;
				break;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
				gameObject.layer = layer;
				break;
			}
		}
		return gameObject;
	}

	public static GameObject AddChild(this Transform parent, GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent.transform);
		Transform transform = gameObject.transform;
		transform.parent = parent;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		transform.localScale = Vector3.one;
		gameObject.SetActive(value: true);
		return gameObject;
	}

	public static GameObject AddChild(this GameObject parent, GameObject prefab)
	{
		return parent.AddChild(prefab, -1);
	}

	public static GameObject AddChild(this GameObject parent, GameObject prefab, int layer)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent.transform);
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			gameObject.name = prefab.name;
			if (parent != null)
			{
				switch (layer)
				{
				case -1:
					gameObject.layer = parent.layer;
					break;
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
				case 26:
				case 27:
				case 28:
				case 29:
				case 30:
				case 31:
					gameObject.layer = layer;
					break;
				}
			}
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			gameObject.SetActive(value: true);
		}
		return gameObject;
	}

	public static int CalculateRaycastDepth(GameObject go)
	{
		UIWidget component = go.GetComponent<UIWidget>();
		if (component != null)
		{
			return component.raycastDepth;
		}
		UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
		if (componentsInChildren.Length == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		int i = 0;
		for (int num2 = componentsInChildren.Length; i < num2; i++)
		{
			if (componentsInChildren[i].enabled)
			{
				num = Mathf.Min(num, componentsInChildren[i].raycastDepth);
			}
		}
		return num;
	}

	public static int CalculateNextDepth(GameObject go)
	{
		if ((bool)go)
		{
			int num = -1;
			UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
			int i = 0;
			for (int num2 = componentsInChildren.Length; i < num2; i++)
			{
				num = Mathf.Max(num, componentsInChildren[i].depth);
			}
			return num + 1;
		}
		return 0;
	}

	public static int CalculateNextDepth(GameObject go, bool ignoreChildrenWithColliders)
	{
		if ((bool)go && ignoreChildrenWithColliders)
		{
			int num = -1;
			UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
			int i = 0;
			for (int num2 = componentsInChildren.Length; i < num2; i++)
			{
				UIWidget uIWidget = componentsInChildren[i];
				if (!(uIWidget.cachedGameObject != go) || (!(uIWidget.GetComponent<Collider>() != null) && !(uIWidget.GetComponent<Collider2D>() != null)))
				{
					num = Mathf.Max(num, uIWidget.depth);
				}
			}
			return num + 1;
		}
		return CalculateNextDepth(go);
	}

	public static int AdjustDepth(GameObject go, int adjustment)
	{
		if (go != null)
		{
			UIPanel component = go.GetComponent<UIPanel>();
			if (component != null)
			{
				UIPanel[] componentsInChildren = go.GetComponentsInChildren<UIPanel>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].depth += adjustment;
				}
				return 1;
			}
			component = FindInParents<UIPanel>(go);
			if (component == null)
			{
				return 0;
			}
			UIWidget[] componentsInChildren2 = go.GetComponentsInChildren<UIWidget>(includeInactive: true);
			int j = 0;
			for (int num = componentsInChildren2.Length; j < num; j++)
			{
				UIWidget uIWidget = componentsInChildren2[j];
				if (!(uIWidget.panel != component))
				{
					uIWidget.depth += adjustment;
				}
			}
			return 2;
		}
		return 0;
	}

	public static void BringForward(GameObject go)
	{
		switch (AdjustDepth(go, 1000))
		{
		case 1:
			NormalizePanelDepths();
			break;
		case 2:
			NormalizeWidgetDepths();
			break;
		}
	}

	public static void PushBack(GameObject go)
	{
		switch (AdjustDepth(go, -1000))
		{
		case 1:
			NormalizePanelDepths();
			break;
		case 2:
			NormalizeWidgetDepths();
			break;
		}
	}

	public static void NormalizeDepths()
	{
		NormalizeWidgetDepths();
		NormalizePanelDepths();
	}

	public static void NormalizeWidgetDepths()
	{
		NormalizeWidgetDepths(FindActive<UIWidget>());
	}

	public static void NormalizeWidgetDepths(GameObject go)
	{
		NormalizeWidgetDepths(go.GetComponentsInChildren<UIWidget>());
	}

	public static void NormalizeWidgetDepths(UIWidget[] list)
	{
		int num = list.Length;
		if (num <= 0)
		{
			return;
		}
		Array.Sort(list, UIWidget.FullCompareFunc);
		int num2 = 0;
		int depth = list[0].depth;
		for (int i = 0; i < num; i++)
		{
			UIWidget uIWidget = list[i];
			if (uIWidget.depth == depth)
			{
				uIWidget.depth = num2;
				continue;
			}
			depth = uIWidget.depth;
			num2 = (uIWidget.depth = num2 + 1);
		}
	}

	public static void NormalizePanelDepths()
	{
		UIPanel[] array = FindActive<UIPanel>();
		int num = array.Length;
		if (num <= 0)
		{
			return;
		}
		Array.Sort(array, UIPanel.CompareFunc);
		int num2 = 0;
		int depth = array[0].depth;
		for (int i = 0; i < num; i++)
		{
			UIPanel uIPanel = array[i];
			if (uIPanel.depth == depth)
			{
				uIPanel.depth = num2;
				continue;
			}
			depth = uIPanel.depth;
			num2 = (uIPanel.depth = num2 + 1);
		}
	}

	public static UIPanel CreateUI(bool advanced3D)
	{
		return CreateUI(null, advanced3D, -1);
	}

	public static UIPanel CreateUI(bool advanced3D, int layer)
	{
		return CreateUI(null, advanced3D, layer);
	}

	public static UIPanel CreateUI(Transform trans, bool advanced3D, int layer)
	{
		UIRoot uIRoot = ((trans != null) ? FindInParents<UIRoot>(trans.gameObject) : null);
		if (uIRoot == null && UIRoot.list.Count > 0)
		{
			foreach (UIRoot item in UIRoot.list)
			{
				if (item.gameObject.layer == layer)
				{
					uIRoot = item;
					break;
				}
			}
		}
		if (uIRoot == null)
		{
			int i = 0;
			for (int count = UIPanel.list.Count; i < count; i++)
			{
				UIPanel uIPanel = UIPanel.list[i];
				GameObject gameObject = uIPanel.gameObject;
				if (gameObject.hideFlags == HideFlags.None && gameObject.layer == layer)
				{
					trans.parent = uIPanel.transform;
					trans.localScale = Vector3.one;
					return uIPanel;
				}
			}
		}
		if (uIRoot != null)
		{
			UICamera componentInChildren = uIRoot.GetComponentInChildren<UICamera>();
			if (componentInChildren != null && componentInChildren.GetComponent<Camera>().orthographic == advanced3D)
			{
				trans = null;
				uIRoot = null;
			}
		}
		if (uIRoot == null)
		{
			GameObject gameObject2 = ((GameObject)null).AddChild(undo: false);
			uIRoot = gameObject2.AddComponent<UIRoot>();
			if (layer == -1)
			{
				layer = LayerMask.NameToLayer("UI");
			}
			if (layer == -1)
			{
				layer = LayerMask.NameToLayer("2D UI");
			}
			gameObject2.layer = layer;
			if (advanced3D)
			{
				gameObject2.name = "UI Root (3D)";
				uIRoot.scalingStyle = UIRoot.Scaling.Constrained;
			}
			else
			{
				gameObject2.name = "UI Root";
				uIRoot.scalingStyle = UIRoot.Scaling.Flexible;
			}
			uIRoot.UpdateScale();
		}
		UIPanel uIPanel2 = uIRoot.GetComponentInChildren<UIPanel>();
		if (uIPanel2 == null)
		{
			Camera[] array = FindActive<Camera>();
			float num = -1f;
			bool flag = false;
			int num2 = 1 << uIRoot.gameObject.layer;
			foreach (Camera camera in array)
			{
				if (camera.clearFlags == CameraClearFlags.Color || camera.clearFlags == CameraClearFlags.Skybox)
				{
					flag = true;
				}
				num = Mathf.Max(num, camera.depth);
				camera.cullingMask &= ~num2;
			}
			Camera camera2 = uIRoot.gameObject.AddChild<Camera>(undo: false);
			camera2.gameObject.AddComponent<UICamera>();
			camera2.clearFlags = (flag ? CameraClearFlags.Depth : CameraClearFlags.Color);
			camera2.backgroundColor = Color.grey;
			camera2.cullingMask = num2;
			camera2.depth = num + 1f;
			if (advanced3D)
			{
				camera2.nearClipPlane = 0.1f;
				camera2.farClipPlane = 4f;
				camera2.transform.localPosition = new Vector3(0f, 0f, -700f);
			}
			else
			{
				camera2.orthographic = true;
				camera2.orthographicSize = 1f;
				camera2.nearClipPlane = -10f;
				camera2.farClipPlane = 10f;
			}
			AudioListener[] array2 = FindActive<AudioListener>();
			if (array2 == null || array2.Length == 0)
			{
				camera2.gameObject.AddComponent<AudioListener>();
			}
			uIPanel2 = uIRoot.gameObject.AddComponent<UIPanel>();
		}
		if (trans != null)
		{
			while (trans.parent != null)
			{
				trans = trans.parent;
			}
			if (IsChild(trans, uIPanel2.transform))
			{
				uIPanel2 = trans.gameObject.AddComponent<UIPanel>();
			}
			else
			{
				trans.parent = uIPanel2.transform;
				trans.localScale = Vector3.one;
				trans.localPosition = Vector3.zero;
				uIPanel2.cachedTransform.SetChildLayer(uIPanel2.cachedGameObject.layer);
			}
		}
		return uIPanel2;
	}

	public static void SetChildLayer(this Transform t, int layer)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			child.gameObject.layer = layer;
			child.SetChildLayer(layer);
		}
	}

	public static T AddChild<T>(this GameObject parent) where T : Component
	{
		GameObject gameObject = AddChild(parent);
		if (!mTypeNames.TryGetValue(typeof(T), out var value) || value == null)
		{
			value = GetTypeName<T>();
			mTypeNames[typeof(T)] = value;
		}
		gameObject.name = value;
		return gameObject.AddComponent<T>();
	}

	public static T AddChild<T>(this GameObject parent, bool undo) where T : Component
	{
		GameObject gameObject = parent.AddChild(undo);
		if (!mTypeNames.TryGetValue(typeof(T), out var value) || value == null)
		{
			value = GetTypeName<T>();
			mTypeNames[typeof(T)] = value;
		}
		gameObject.name = value;
		return gameObject.AddComponent<T>();
	}

	public static T AddWidget<T>(this GameObject go, int depth = int.MaxValue) where T : UIWidget
	{
		if (depth == int.MaxValue)
		{
			depth = CalculateNextDepth(go);
		}
		T val = go.AddChild<T>();
		val.width = 100;
		val.height = 100;
		val.depth = depth;
		return val;
	}

	public static UISprite AddSprite(this GameObject go, INGUIAtlas atlas, string spriteName, int depth = int.MaxValue)
	{
		UISpriteData uISpriteData = atlas?.GetSprite(spriteName);
		UISprite uISprite = go.AddWidget<UISprite>(depth);
		uISprite.type = ((uISpriteData != null && uISpriteData.hasBorder) ? UIBasicSprite.Type.Sliced : UIBasicSprite.Type.Simple);
		uISprite.atlas = atlas;
		uISprite.spriteName = spriteName;
		return uISprite;
	}

	public static GameObject GetRoot(GameObject go)
	{
		Transform transform = go.transform;
		while (true)
		{
			Transform parent = transform.parent;
			if (parent == null)
			{
				break;
			}
			transform = parent;
		}
		return transform.gameObject;
	}

	public static T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null)
		{
			return null;
		}
		return go.GetComponentInParent<T>();
	}

	public static T FindInParents<T>(Transform trans) where T : Component
	{
		if (trans == null)
		{
			return null;
		}
		return trans.GetComponentInParent<T>();
	}

	public static void Destroy(UnityEngine.Object obj)
	{
		if (!obj)
		{
			return;
		}
		if (obj is Transform)
		{
			Transform transform = obj as Transform;
			GameObject gameObject = transform.gameObject;
			if (Application.isPlaying)
			{
				gameObject.SetActive(value: false);
				transform.parent = null;
				UnityEngine.Object.Destroy(gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
		}
		else if (obj is GameObject)
		{
			GameObject gameObject2 = obj as GameObject;
			Transform transform2 = gameObject2.transform;
			if (Application.isPlaying)
			{
				gameObject2.SetActive(value: false);
				transform2.parent = null;
				UnityEngine.Object.Destroy(gameObject2);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(gameObject2);
			}
		}
		else if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(obj);
		}
	}

	public static void DestroyChildren(this Transform t)
	{
		bool isPlaying = Application.isPlaying;
		while (t.childCount != 0)
		{
			Transform child = t.GetChild(0);
			if (isPlaying)
			{
				child.parent = null;
				UnityEngine.Object.Destroy(child.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(child.gameObject);
			}
		}
	}

	public static void DestroyImmediate(UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			else
			{
				UnityEngine.Object.Destroy(obj);
			}
		}
	}

	public static void Broadcast(string funcName)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i].SendMessage(funcName, SendMessageOptions.DontRequireReceiver);
		}
	}

	public static void Broadcast(string funcName, object param)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i].SendMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
		}
	}

	public static bool IsChild(Transform parent, Transform child)
	{
		return child.IsChildOf(parent);
	}

	private static void Activate(Transform t)
	{
		Activate(t, compatibilityMode: false);
	}

	private static void Activate(Transform t, bool compatibilityMode)
	{
		SetActiveSelf(t.gameObject, state: true);
		if (!compatibilityMode)
		{
			return;
		}
		int i = 0;
		for (int childCount = t.childCount; i < childCount; i++)
		{
			if (t.GetChild(i).gameObject.activeSelf)
			{
				return;
			}
		}
		int j = 0;
		for (int childCount2 = t.childCount; j < childCount2; j++)
		{
			Activate(t.GetChild(j), compatibilityMode: true);
		}
	}

	private static void Deactivate(Transform t)
	{
		SetActiveSelf(t.gameObject, state: false);
	}

	public static void SetActive(GameObject go, bool state)
	{
		SetActive(go, state, compatibilityMode: true);
	}

	public static void SetActive(GameObject go, bool state, bool compatibilityMode)
	{
		if ((bool)go)
		{
			if (state)
			{
				Activate(go.transform, compatibilityMode);
				CallCreatePanel(go.transform);
			}
			else
			{
				Deactivate(go.transform);
			}
		}
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	private static void CallCreatePanel(Transform t)
	{
		UIWidget component = t.GetComponent<UIWidget>();
		if (component != null)
		{
			component.CreatePanel();
		}
		int i = 0;
		for (int childCount = t.childCount; i < childCount; i++)
		{
			CallCreatePanel(t.GetChild(i));
		}
	}

	public static void SetActiveChildren(GameObject go, bool state)
	{
		Transform transform = go.transform;
		if (state)
		{
			int i = 0;
			for (int childCount = transform.childCount; i < childCount; i++)
			{
				Activate(transform.GetChild(i));
			}
		}
		else
		{
			int j = 0;
			for (int childCount2 = transform.childCount; j < childCount2; j++)
			{
				Deactivate(transform.GetChild(j));
			}
		}
	}

	[Obsolete("Use NGUITools.GetActive instead")]
	public static bool IsActive(Behaviour mb)
	{
		if (mb != null && mb.enabled)
		{
			return mb.gameObject.activeInHierarchy;
		}
		return false;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool GetActive(Behaviour mb)
	{
		if ((bool)mb && mb.enabled)
		{
			return mb.gameObject.activeInHierarchy;
		}
		return false;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool GetActive(GameObject go)
	{
		if ((bool)go)
		{
			return go.activeInHierarchy;
		}
		return false;
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	public static void SetActiveSelf(GameObject go, bool state)
	{
		go.SetActive(state);
	}

	public static void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			SetLayer(transform.GetChild(i).gameObject, layer);
		}
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
		if (component != null)
		{
			component.MakePixelPerfect();
		}
		if (t.GetComponent<UIAnchor>() == null && t.GetComponent<UIRoot>() == null)
		{
			t.localPosition = Round(t.localPosition);
			t.localScale = Round(t.localScale);
		}
		int i = 0;
		for (int childCount = t.childCount; i < childCount; i++)
		{
			MakePixelPerfect(t.GetChild(i));
		}
	}

	public static void FitOnScreen(this Camera cam, Transform t, bool considerInactive = false, bool considerChildren = true)
	{
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(t, t, considerInactive, considerChildren);
		Vector3 vector = cam.WorldToScreenPoint(t.position);
		Vector3 vector2 = vector + bounds.min;
		Vector3 vector3 = vector + bounds.max;
		int width = Screen.width;
		int height = Screen.height;
		Vector2 zero = Vector2.zero;
		if (vector2.x < 0f)
		{
			zero.x = 0f - vector2.x;
		}
		else if (vector3.x > (float)width)
		{
			zero.x = (float)width - vector3.x;
		}
		if (vector2.y < 0f)
		{
			zero.y = 0f - vector2.y;
		}
		else if (vector3.y > (float)height)
		{
			zero.y = (float)height - vector3.y;
		}
		if (zero.sqrMagnitude > 0f)
		{
			t.localPosition += new Vector3(zero.x, zero.y, 0f);
		}
	}

	public static void FitOnScreen(this Camera cam, Transform transform, Vector3 pos)
	{
		cam.FitOnScreen(transform, transform, pos);
	}

	public static void FitOnScreen(this Camera cam, Transform transform, Transform content, Vector3 pos, bool considerInactive = false)
	{
		cam.FitOnScreen(transform, content, pos, out var _, considerInactive);
	}

	public static void FitOnScreen(this Camera cam, Transform transform, Transform content, Vector3 pos, out Bounds bounds, bool considerInactive = false)
	{
		bounds = NGUIMath.CalculateRelativeWidgetBounds(transform, content, considerInactive);
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		Vector3 size = bounds.size;
		size.x += min.x;
		size.y -= max.y;
		if (cam != null)
		{
			pos.x = Mathf.Clamp01(pos.x / (float)Screen.width);
			pos.y = Mathf.Clamp01(pos.y / (float)Screen.height);
			float num = cam.orthographicSize / transform.parent.lossyScale.y;
			float num2 = (float)Screen.height * 0.5f / num;
			max = new Vector2(num2 * size.x / (float)Screen.width, num2 * size.y / (float)Screen.height);
			pos.x = Mathf.Min(pos.x, 1f - max.x);
			pos.y = Mathf.Max(pos.y, max.y);
			transform.position = cam.ViewportToWorldPoint(pos);
			pos = transform.localPosition;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);
		}
		else
		{
			if (pos.x + size.x > (float)Screen.width)
			{
				pos.x = (float)Screen.width - size.x;
			}
			if (pos.y - size.y < 0f)
			{
				pos.y = size.y;
			}
			pos.x -= (float)Screen.width * 0.5f;
			pos.y -= (float)Screen.height * 0.5f;
		}
		transform.localPosition = pos;
	}

	public static bool Save(string fileName, byte[] bytes)
	{
		if (!fileAccess)
		{
			return false;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (bytes == null)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			return true;
		}
		FileStream fileStream = null;
		try
		{
			fileStream = File.Create(path);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message);
			return false;
		}
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
		return true;
	}

	public static byte[] Load(string fileName)
	{
		if (!fileAccess)
		{
			return null;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (File.Exists(path))
		{
			return File.ReadAllBytes(path);
		}
		return null;
	}

	public static Color ApplyPMA(Color c)
	{
		if (c.a != 1f)
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
		int i = 0;
		for (int num = componentsInChildren.Length; i < num; i++)
		{
			componentsInChildren[i].ParentHasChanged();
		}
	}

	[Obsolete("Use NGUIText.EncodeColor instead")]
	public static string EncodeColor(Color c)
	{
		return NGUIText.EncodeColor24(c);
	}

	[Obsolete("Use NGUIText.ParseColor instead")]
	public static Color ParseColor(string text, int offset)
	{
		return NGUIText.ParseColor24(text, offset);
	}

	[Obsolete("Use NGUIText.StripSymbols instead")]
	public static string StripSymbols(string text)
	{
		return NGUIText.StripSymbols(text);
	}

	public static T AddMissingComponent<T>(this GameObject go) where T : Component
	{
		T val = go.GetComponent<T>();
		if ((UnityEngine.Object)val == (UnityEngine.Object)null)
		{
			val = go.AddComponent<T>();
		}
		return val;
	}

	public static Vector3[] GetSides(this Camera cam)
	{
		return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), null);
	}

	public static Vector3[] GetSides(this Camera cam, float depth)
	{
		return cam.GetSides(depth, null);
	}

	public static Vector3[] GetSides(this Camera cam, Transform relativeTo)
	{
		return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
	}

	public static Vector3[] GetSides(this Camera cam, float depth, Transform relativeTo)
	{
		if (cam.orthographic)
		{
			float orthographicSize = cam.orthographicSize;
			float num = 0f - orthographicSize;
			float num2 = orthographicSize;
			float y = 0f - orthographicSize;
			float y2 = orthographicSize;
			Rect rect = cam.rect;
			Vector2 vector = screenSize;
			float num3 = vector.x / vector.y;
			num3 *= rect.width / rect.height;
			num *= num3;
			num2 *= num3;
			Transform transform = cam.transform;
			Quaternion rotation = transform.rotation;
			Vector3 position = transform.position;
			int num4 = Mathf.RoundToInt(vector.x);
			int num5 = Mathf.RoundToInt(vector.y);
			if ((num4 & 1) == 1)
			{
				position.x -= 1f / vector.x;
			}
			if ((num5 & 1) == 1)
			{
				position.y += 1f / vector.y;
			}
			mSides[0] = rotation * new Vector3(num, 0f, depth) + position;
			mSides[1] = rotation * new Vector3(0f, y2, depth) + position;
			mSides[2] = rotation * new Vector3(num2, 0f, depth) + position;
			mSides[3] = rotation * new Vector3(0f, y, depth) + position;
		}
		else
		{
			mSides[0] = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, depth));
			mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, depth));
			mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, depth));
			mSides[3] = cam.ViewportToWorldPoint(new Vector3(0.5f, 0f, depth));
		}
		if (relativeTo != null)
		{
			for (int i = 0; i < 4; i++)
			{
				mSides[i] = relativeTo.InverseTransformPoint(mSides[i]);
			}
		}
		return mSides;
	}

	public static Vector3[] GetWorldCorners(this Camera cam)
	{
		float depth = Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f);
		return cam.GetWorldCorners(depth, null);
	}

	public static Vector3[] GetWorldCorners(this Camera cam, float depth)
	{
		return cam.GetWorldCorners(depth, null);
	}

	public static Vector3[] GetWorldCorners(this Camera cam, Transform relativeTo)
	{
		return cam.GetWorldCorners(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
	}

	public static Vector3[] GetWorldCorners(this Camera cam, float depth, Transform relativeTo)
	{
		if (cam.orthographic)
		{
			float orthographicSize = cam.orthographicSize;
			float num = 0f - orthographicSize;
			float num2 = orthographicSize;
			float y = 0f - orthographicSize;
			float y2 = orthographicSize;
			Rect rect = cam.rect;
			Vector2 vector = screenSize;
			float num3 = vector.x / vector.y;
			num3 *= rect.width / rect.height;
			num *= num3;
			num2 *= num3;
			Transform transform = cam.transform;
			Quaternion rotation = transform.rotation;
			Vector3 position = transform.position;
			mSides[0] = rotation * new Vector3(num, y, depth) + position;
			mSides[1] = rotation * new Vector3(num, y2, depth) + position;
			mSides[2] = rotation * new Vector3(num2, y2, depth) + position;
			mSides[3] = rotation * new Vector3(num2, y, depth) + position;
		}
		else
		{
			mSides[0] = cam.ViewportToWorldPoint(new Vector3(0f, 0f, depth));
			mSides[1] = cam.ViewportToWorldPoint(new Vector3(0f, 1f, depth));
			mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 1f, depth));
			mSides[3] = cam.ViewportToWorldPoint(new Vector3(1f, 0f, depth));
		}
		if (relativeTo != null)
		{
			for (int i = 0; i < 4; i++)
			{
				mSides[i] = relativeTo.InverseTransformPoint(mSides[i]);
			}
		}
		return mSides;
	}

	public static string GetFuncName(object obj, string method)
	{
		if (obj == null)
		{
			return "<null>";
		}
		string text = obj.GetType().ToString();
		int num = text.LastIndexOf('/');
		if (num > 0)
		{
			text = text.Substring(num + 1);
		}
		if (!string.IsNullOrEmpty(method))
		{
			return text + "/" + method;
		}
		return text;
	}

	public static void Execute<T>(GameObject go, string funcName) where T : Component
	{
		T[] components = go.GetComponents<T>();
		foreach (T val in components)
		{
			MethodInfo method = val.GetType().GetMethod(funcName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (method != null)
			{
				method.Invoke(val, null);
			}
		}
	}

	public static void ExecuteAll<T>(GameObject root, string funcName) where T : Component
	{
		Execute<T>(root, funcName);
		Transform transform = root.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			ExecuteAll<T>(transform.GetChild(i).gameObject, funcName);
		}
	}

	public static void ImmediatelyCreateDrawCalls(GameObject root)
	{
		ExecuteAll<UIWidget>(root, "Start");
		ExecuteAll<UIPanel>(root, "Start");
		ExecuteAll<UIWidget>(root, "Update");
		ExecuteAll<UIPanel>(root, "Update");
		ExecuteAll<UIPanel>(root, "LateUpdate");
	}

	public static string KeyToCaption(KeyCode key)
	{
		return key switch
		{
			KeyCode.None => null, 
			KeyCode.Backspace => "Backspace", 
			KeyCode.Tab => "Tab", 
			KeyCode.Clear => "Clear", 
			KeyCode.Return => "Return", 
			KeyCode.Pause => "PS", 
			KeyCode.Escape => "Esc", 
			KeyCode.Space => "Space", 
			KeyCode.Exclaim => "!", 
			KeyCode.DoubleQuote => "''", 
			KeyCode.Hash => "#", 
			KeyCode.Dollar => "$", 
			KeyCode.Ampersand => "&", 
			KeyCode.Quote => "'", 
			KeyCode.LeftParen => "(", 
			KeyCode.RightParen => ")", 
			KeyCode.Asterisk => "*", 
			KeyCode.Plus => "+", 
			KeyCode.Comma => ",", 
			KeyCode.Minus => "-", 
			KeyCode.Period => ".", 
			KeyCode.Slash => "/", 
			KeyCode.Alpha0 => "0", 
			KeyCode.Alpha1 => "1", 
			KeyCode.Alpha2 => "2", 
			KeyCode.Alpha3 => "3", 
			KeyCode.Alpha4 => "4", 
			KeyCode.Alpha5 => "5", 
			KeyCode.Alpha6 => "6", 
			KeyCode.Alpha7 => "7", 
			KeyCode.Alpha8 => "8", 
			KeyCode.Alpha9 => "9", 
			KeyCode.Colon => ":", 
			KeyCode.Semicolon => ";", 
			KeyCode.Less => "<", 
			KeyCode.Equals => "=", 
			KeyCode.Greater => ">", 
			KeyCode.Question => "?", 
			KeyCode.At => "@", 
			KeyCode.LeftBracket => "[", 
			KeyCode.Backslash => "\\", 
			KeyCode.RightBracket => "]", 
			KeyCode.Caret => "^", 
			KeyCode.Underscore => "_", 
			KeyCode.BackQuote => "`", 
			KeyCode.A => "A", 
			KeyCode.B => "B", 
			KeyCode.C => "C", 
			KeyCode.D => "D", 
			KeyCode.E => "E", 
			KeyCode.F => "F", 
			KeyCode.G => "G", 
			KeyCode.H => "H", 
			KeyCode.I => "I", 
			KeyCode.J => "J", 
			KeyCode.K => "K", 
			KeyCode.L => "L", 
			KeyCode.M => "M", 
			KeyCode.N => "N", 
			KeyCode.O => "O", 
			KeyCode.P => "P", 
			KeyCode.Q => "Q", 
			KeyCode.R => "R", 
			KeyCode.S => "S", 
			KeyCode.T => "T", 
			KeyCode.U => "U", 
			KeyCode.V => "V", 
			KeyCode.W => "W", 
			KeyCode.X => "X", 
			KeyCode.Y => "Y", 
			KeyCode.Z => "Z", 
			KeyCode.Delete => "Del", 
			KeyCode.Keypad0 => "K0", 
			KeyCode.Keypad1 => "K1", 
			KeyCode.Keypad2 => "K2", 
			KeyCode.Keypad3 => "K3", 
			KeyCode.Keypad4 => "K4", 
			KeyCode.Keypad5 => "K5", 
			KeyCode.Keypad6 => "K6", 
			KeyCode.Keypad7 => "K7", 
			KeyCode.Keypad8 => "K8", 
			KeyCode.Keypad9 => "K9", 
			KeyCode.KeypadPeriod => "K.", 
			KeyCode.KeypadDivide => "K/", 
			KeyCode.KeypadMultiply => "K*", 
			KeyCode.KeypadMinus => "K-", 
			KeyCode.KeypadPlus => "K+", 
			KeyCode.KeypadEnter => "KE", 
			KeyCode.KeypadEquals => "KQ", 
			KeyCode.UpArrow => "UP", 
			KeyCode.DownArrow => "DN", 
			KeyCode.RightArrow => "LT", 
			KeyCode.LeftArrow => "RT", 
			KeyCode.Insert => "Ins", 
			KeyCode.Home => "Home", 
			KeyCode.End => "End", 
			KeyCode.PageUp => "PU", 
			KeyCode.PageDown => "PD", 
			KeyCode.F1 => "F1", 
			KeyCode.F2 => "F2", 
			KeyCode.F3 => "F3", 
			KeyCode.F4 => "F4", 
			KeyCode.F5 => "F5", 
			KeyCode.F6 => "F6", 
			KeyCode.F7 => "F7", 
			KeyCode.F8 => "F8", 
			KeyCode.F9 => "F9", 
			KeyCode.F10 => "F10", 
			KeyCode.F11 => "F11", 
			KeyCode.F12 => "F12", 
			KeyCode.F13 => "F13", 
			KeyCode.F14 => "F14", 
			KeyCode.F15 => "F15", 
			KeyCode.Numlock => "Num", 
			KeyCode.CapsLock => "Cap", 
			KeyCode.ScrollLock => "Scr", 
			KeyCode.RightShift => "RS", 
			KeyCode.LeftShift => "LS", 
			KeyCode.RightControl => "RC", 
			KeyCode.LeftControl => "LC", 
			KeyCode.RightAlt => "RA", 
			KeyCode.LeftAlt => "LA", 
			KeyCode.Mouse0 => "M0", 
			KeyCode.Mouse1 => "M1", 
			KeyCode.Mouse2 => "M2", 
			KeyCode.Mouse3 => "M3", 
			KeyCode.Mouse4 => "M4", 
			KeyCode.Mouse5 => "M5", 
			KeyCode.Mouse6 => "M6", 
			KeyCode.JoystickButton0 => "(A)", 
			KeyCode.JoystickButton1 => "(B)", 
			KeyCode.JoystickButton2 => "(X)", 
			KeyCode.JoystickButton3 => "(Y)", 
			KeyCode.JoystickButton4 => "(RB)", 
			KeyCode.JoystickButton5 => "(LB)", 
			KeyCode.JoystickButton6 => "(Back)", 
			KeyCode.JoystickButton7 => "(Start)", 
			KeyCode.JoystickButton8 => "(LS)", 
			KeyCode.JoystickButton9 => "(RS)", 
			KeyCode.JoystickButton10 => "J10", 
			KeyCode.JoystickButton11 => "J11", 
			KeyCode.JoystickButton12 => "J12", 
			KeyCode.JoystickButton13 => "J13", 
			KeyCode.JoystickButton14 => "J14", 
			KeyCode.JoystickButton15 => "J15", 
			KeyCode.JoystickButton16 => "J16", 
			KeyCode.JoystickButton17 => "J17", 
			KeyCode.JoystickButton18 => "J18", 
			KeyCode.JoystickButton19 => "J19", 
			_ => null, 
		};
	}

	public static KeyCode CaptionToKey(string caption)
	{
		if (string.IsNullOrEmpty(caption))
		{
			return KeyCode.None;
		}
		return caption switch
		{
			"Backspace" => KeyCode.Backspace, 
			"Tab" => KeyCode.Tab, 
			"Clear" => KeyCode.Clear, 
			"Return" => KeyCode.Return, 
			"Pause" => KeyCode.Pause, 
			"Esc" => KeyCode.Escape, 
			"Space" => KeyCode.Space, 
			"!" => KeyCode.Exclaim, 
			"''" => KeyCode.DoubleQuote, 
			"#" => KeyCode.Hash, 
			"$" => KeyCode.Dollar, 
			"&" => KeyCode.Ampersand, 
			"'" => KeyCode.Quote, 
			"(" => KeyCode.LeftParen, 
			")" => KeyCode.RightParen, 
			"*" => KeyCode.Asterisk, 
			"+" => KeyCode.Plus, 
			"," => KeyCode.Comma, 
			"-" => KeyCode.Minus, 
			"." => KeyCode.Period, 
			"/" => KeyCode.Slash, 
			"0" => KeyCode.Alpha0, 
			"1" => KeyCode.Alpha1, 
			"2" => KeyCode.Alpha2, 
			"3" => KeyCode.Alpha3, 
			"4" => KeyCode.Alpha4, 
			"5" => KeyCode.Alpha5, 
			"6" => KeyCode.Alpha6, 
			"7" => KeyCode.Alpha7, 
			"8" => KeyCode.Alpha8, 
			"9" => KeyCode.Alpha9, 
			";//" => KeyCode.Colon, 
			";" => KeyCode.Semicolon, 
			"<" => KeyCode.Less, 
			"=" => KeyCode.Equals, 
			">" => KeyCode.Greater, 
			"?" => KeyCode.Question, 
			"@" => KeyCode.At, 
			"[" => KeyCode.LeftBracket, 
			"\\" => KeyCode.Backslash, 
			"]" => KeyCode.RightBracket, 
			"^" => KeyCode.Caret, 
			"_" => KeyCode.Underscore, 
			"`" => KeyCode.BackQuote, 
			"A" => KeyCode.A, 
			"B" => KeyCode.B, 
			"C" => KeyCode.C, 
			"D" => KeyCode.D, 
			"E" => KeyCode.E, 
			"F" => KeyCode.F, 
			"G" => KeyCode.G, 
			"H" => KeyCode.H, 
			"I" => KeyCode.I, 
			"J" => KeyCode.J, 
			"K" => KeyCode.K, 
			"L" => KeyCode.L, 
			"M" => KeyCode.M, 
			"N" => KeyCode.N, 
			"O" => KeyCode.O, 
			"P" => KeyCode.P, 
			"Q" => KeyCode.Q, 
			"R" => KeyCode.R, 
			"S" => KeyCode.S, 
			"T" => KeyCode.T, 
			"U" => KeyCode.U, 
			"V" => KeyCode.V, 
			"W" => KeyCode.W, 
			"X" => KeyCode.X, 
			"Y" => KeyCode.Y, 
			"Z" => KeyCode.Z, 
			"Del" => KeyCode.Delete, 
			"K0" => KeyCode.Keypad0, 
			"K1" => KeyCode.Keypad1, 
			"K2" => KeyCode.Keypad2, 
			"K3" => KeyCode.Keypad3, 
			"K4" => KeyCode.Keypad4, 
			"K5" => KeyCode.Keypad5, 
			"K6" => KeyCode.Keypad6, 
			"K7" => KeyCode.Keypad7, 
			"K8" => KeyCode.Keypad8, 
			"K9" => KeyCode.Keypad9, 
			"K." => KeyCode.KeypadPeriod, 
			"K/" => KeyCode.KeypadDivide, 
			"K*" => KeyCode.KeypadMultiply, 
			"K-" => KeyCode.KeypadMinus, 
			"K+" => KeyCode.KeypadPlus, 
			"KE" => KeyCode.KeypadEnter, 
			"KQ" => KeyCode.KeypadEquals, 
			"UP" => KeyCode.UpArrow, 
			"DN" => KeyCode.DownArrow, 
			"LT" => KeyCode.RightArrow, 
			"RT" => KeyCode.LeftArrow, 
			"Ins" => KeyCode.Insert, 
			"Home" => KeyCode.Home, 
			"End" => KeyCode.End, 
			"PU" => KeyCode.PageUp, 
			"PD" => KeyCode.PageDown, 
			"F1" => KeyCode.F1, 
			"F2" => KeyCode.F2, 
			"F3" => KeyCode.F3, 
			"F4" => KeyCode.F4, 
			"F5" => KeyCode.F5, 
			"F6" => KeyCode.F6, 
			"F7" => KeyCode.F7, 
			"F8" => KeyCode.F8, 
			"F9" => KeyCode.F9, 
			"F10" => KeyCode.F10, 
			"F11" => KeyCode.F11, 
			"F12" => KeyCode.F12, 
			"F13" => KeyCode.F13, 
			"F14" => KeyCode.F14, 
			"F15" => KeyCode.F15, 
			"Num" => KeyCode.Numlock, 
			"Cap" => KeyCode.CapsLock, 
			"Scr" => KeyCode.ScrollLock, 
			"RS" => KeyCode.RightShift, 
			"LS" => KeyCode.LeftShift, 
			"RC" => KeyCode.RightControl, 
			"LC" => KeyCode.LeftControl, 
			"RA" => KeyCode.RightAlt, 
			"LA" => KeyCode.LeftAlt, 
			"M0" => KeyCode.Mouse0, 
			"M1" => KeyCode.Mouse1, 
			"M2" => KeyCode.Mouse2, 
			"M3" => KeyCode.Mouse3, 
			"M4" => KeyCode.Mouse4, 
			"M5" => KeyCode.Mouse5, 
			"M6" => KeyCode.Mouse6, 
			"(A)" => KeyCode.JoystickButton0, 
			"(B)" => KeyCode.JoystickButton1, 
			"(X)" => KeyCode.JoystickButton2, 
			"(Y)" => KeyCode.JoystickButton3, 
			"(RB)" => KeyCode.JoystickButton4, 
			"(LB)" => KeyCode.JoystickButton5, 
			"(Back)" => KeyCode.JoystickButton6, 
			"(Start)" => KeyCode.JoystickButton7, 
			"(LS)" => KeyCode.JoystickButton8, 
			"(RS)" => KeyCode.JoystickButton9, 
			"J10" => KeyCode.JoystickButton10, 
			"J11" => KeyCode.JoystickButton11, 
			"J12" => KeyCode.JoystickButton12, 
			"J13" => KeyCode.JoystickButton13, 
			"J14" => KeyCode.JoystickButton14, 
			"J15" => KeyCode.JoystickButton15, 
			"J16" => KeyCode.JoystickButton16, 
			"J17" => KeyCode.JoystickButton17, 
			"J18" => KeyCode.JoystickButton18, 
			"J19" => KeyCode.JoystickButton19, 
			_ => KeyCode.None, 
		};
	}

	public static T Draw<T>(string id, OnInitFunc<T> onInit = null) where T : UIWidget
	{
		if (mWidgets.TryGetValue(id, out var value) && (bool)value)
		{
			return (T)value;
		}
		if (mRoot == null)
		{
			UICamera uICamera = null;
			UIRoot uIRoot = null;
			for (int i = 0; i < UIRoot.list.Count; i++)
			{
				UIRoot uIRoot2 = UIRoot.list[i];
				if ((bool)uIRoot2)
				{
					UICamera uICamera2 = UICamera.FindCameraForLayer(uIRoot2.gameObject.layer);
					if ((bool)uICamera2 && uICamera2.cachedCamera.orthographic)
					{
						uICamera = uICamera2;
						uIRoot = uIRoot2;
						break;
					}
				}
			}
			if (uICamera == null)
			{
				mRoot = CreateUI(advanced3D: false, LayerMask.NameToLayer("UI"));
			}
			else
			{
				mRoot = uIRoot.gameObject.AddChild<UIPanel>();
			}
			mRoot.depth = 100000;
			mGo = mRoot.gameObject;
			mGo.name = "Immediate Mode GUI";
		}
		value = mGo.AddWidget<T>();
		value.name = id;
		mWidgets[id] = value;
		onInit?.Invoke((T)value);
		return (T)value;
	}

	public static Color GammaToLinearSpace(this Color c)
	{
		if (mColorSpace == ColorSpace.Uninitialized)
		{
			mColorSpace = QualitySettings.activeColorSpace;
		}
		if (mColorSpace == ColorSpace.Linear)
		{
			return new Color(Mathf.GammaToLinearSpace(c.r), Mathf.GammaToLinearSpace(c.g), Mathf.GammaToLinearSpace(c.b), Mathf.GammaToLinearSpace(c.a));
		}
		return c;
	}

	public static Color LinearToGammaSpace(this Color c)
	{
		if (mColorSpace == ColorSpace.Uninitialized)
		{
			mColorSpace = QualitySettings.activeColorSpace;
		}
		if (mColorSpace == ColorSpace.Linear)
		{
			return new Color(Mathf.LinearToGammaSpace(c.r), Mathf.LinearToGammaSpace(c.g), Mathf.LinearToGammaSpace(c.b), Mathf.LinearToGammaSpace(c.a));
		}
		return c;
	}

	public static bool CheckIfRelated(INGUIAtlas a, INGUIAtlas b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a != b && !a.References(b))
		{
			return b.References(a);
		}
		return true;
	}

	public static void Replace(INGUIAtlas before, INGUIAtlas after)
	{
		UISprite[] array = FindActive<UISprite>();
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			UISprite uISprite = array[i];
			if (uISprite.atlas == before)
			{
				uISprite.atlas = after;
			}
		}
		UIFont[] array2 = Resources.FindObjectsOfTypeAll<UIFont>();
		int j = 0;
		for (int num2 = array2.Length; j < num2; j++)
		{
			UIFont uIFont = array2[j];
			if (uIFont.atlas == before)
			{
				uIFont.atlas = after;
			}
		}
		NGUIFont[] array3 = Resources.FindObjectsOfTypeAll<NGUIFont>();
		int k = 0;
		for (int num3 = array3.Length; k < num3; k++)
		{
			NGUIFont nGUIFont = array3[k];
			if (nGUIFont.atlas == before)
			{
				nGUIFont.atlas = after;
			}
		}
		UILabel[] array4 = FindActive<UILabel>();
		int l = 0;
		for (int num4 = array4.Length; l < num4; l++)
		{
			UILabel uILabel = array4[l];
			if (uILabel.bitmapFont != null && uILabel.atlas == before)
			{
				uILabel.atlas = after;
			}
		}
	}

	public static bool CheckIfRelated(INGUIFont a, INGUIFont b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.isDynamic && b.isDynamic && a.dynamicFont.fontNames[0] == b.dynamicFont.fontNames[0])
		{
			return true;
		}
		if (a != b && !a.References(b))
		{
			return b.References(a);
		}
		return true;
	}
}
