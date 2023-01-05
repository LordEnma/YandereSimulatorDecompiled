using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Event System (UICamera)")]
[RequireComponent(typeof(Camera))]
public class UICamera : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum ControlScheme
	{
		Mouse = 0,
		Touch = 1,
		Controller = 2
	}

	[DoNotObfuscateNGUI]
	public enum ClickNotification
	{
		None = 0,
		Always = 1,
		BasedOnDelta = 2
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

		public ClickNotification clickNotification = ClickNotification.Always;

		public bool touchBegan = true;

		public bool pressStarted;

		public bool dragStarted;

		public int ignoreDelta;

		public float deltaTime
		{
			get
			{
				return RealTime.time - pressTime;
			}
		}

		public bool isOverUI
		{
			get
			{
				if (current != null && current != fallThrough)
				{
					return NGUITools.FindInParents<UIRoot>(current) != null;
				}
				return false;
			}
		}
	}

	[DoNotObfuscateNGUI]
	public enum EventType
	{
		World_3D = 0,
		UI_3D = 1,
		World_2D = 2,
		UI_2D = 3
	}

	public delegate bool GetKeyStateFunc(KeyCode key);

	public delegate float GetAxisFunc(string name);

	public delegate bool GetAnyKeyFunc();

	public delegate MouseOrTouch GetMouseDelegate(int button);

	public delegate MouseOrTouch GetTouchDelegate(int id, bool createIfMissing);

	public delegate void RemoveTouchDelegate(int id);

	public delegate void OnScreenResize();

	[DoNotObfuscateNGUI]
	public enum ProcessEventsIn
	{
		Update = 0,
		LateUpdate = 1
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

	public delegate Touch GetTouchCallback(int index);

	public static BetterList<UICamera> list = new BetterList<UICamera>();

	public static GetKeyStateFunc GetKeyDown = (KeyCode key) => (key < KeyCode.JoystickButton0 || !ignoreControllerInput) && Input.GetKeyDown(key);

	public static GetKeyStateFunc GetKeyUp = (KeyCode key) => (key < KeyCode.JoystickButton0 || !ignoreControllerInput) && Input.GetKeyUp(key);

	public static GetKeyStateFunc GetKey = (KeyCode key) => (key < KeyCode.JoystickButton0 || !ignoreControllerInput) && Input.GetKey(key);

	public static GetAxisFunc GetAxis = (string axis) => ignoreControllerInput ? 0f : Input.GetAxis(axis);

	public static GetAnyKeyFunc GetAnyKeyDown;

	public static GetMouseDelegate GetMouse = (int button) => mMouse[button];

	public static GetTouchDelegate GetTouch = delegate(int id, bool createIfMissing)
	{
		if (id < 0)
		{
			return GetMouse(-id - 1);
		}
		int j = 0;
		for (int count2 = mTouchIDs.Count; j < count2; j++)
		{
			if (mTouchIDs[j] == id)
			{
				return activeTouches[j];
			}
		}
		if (createIfMissing)
		{
			MouseOrTouch mouseOrTouch = new MouseOrTouch
			{
				pressTime = RealTime.time,
				touchBegan = true
			};
			activeTouches.Add(mouseOrTouch);
			mTouchIDs.Add(id);
			return mouseOrTouch;
		}
		return null;
	};

	public static RemoveTouchDelegate RemoveTouch = delegate(int id)
	{
		int i = 0;
		for (int count = mTouchIDs.Count; i < count; i++)
		{
			if (mTouchIDs[i] == id)
			{
				mTouchIDs.RemoveAt(i);
				activeTouches.RemoveAt(i);
				break;
			}
		}
	};

	public static OnScreenResize onScreenResize;

	public EventType eventType = EventType.UI_3D;

	public bool eventsGoToColliders;

	public LayerMask eventReceiverMask = -1;

	public ProcessEventsIn processEventsIn;

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

	public static OnCustomInput onCustomInput;

	public static bool showTooltips = true;

	public static bool ignoreAllEvents = false;

	public static bool ignoreControllerInput = false;

	private static bool mDisableController = false;

	private static Vector2 mLastPos = Vector2.zero;

	public static Vector3 lastWorldPosition = Vector3.zero;

	public static Ray lastWorldRay = default(Ray);

	public static RaycastHit lastHit;

	public static UICamera current = null;

	public static Camera currentCamera = null;

	public static OnSchemeChange onSchemeChange;

	private static ControlScheme mLastScheme = ControlScheme.Mouse;

	public static int currentTouchID = -100;

	private static KeyCode mCurrentKey = KeyCode.Alpha0;

	[NonSerialized]
	public static MouseOrTouch currentTouch = null;

	[NonSerialized]
	private static bool mInputFocus = false;

	[NonSerialized]
	private static GameObject mGenericHandler;

	[NonSerialized]
	public static GameObject fallThrough;

	[NonSerialized]
	public static VoidDelegate onClick;

	[NonSerialized]
	public static VoidDelegate onDoubleClick;

	[NonSerialized]
	public static BoolDelegate onHover;

	[NonSerialized]
	public static BoolDelegate onPress;

	[NonSerialized]
	public static BoolDelegate onSelect;

	[NonSerialized]
	public static FloatDelegate onScroll;

	[NonSerialized]
	public static VectorDelegate onDrag;

	[NonSerialized]
	public static VoidDelegate onDragStart;

	[NonSerialized]
	public static ObjectDelegate onDragOver;

	[NonSerialized]
	public static ObjectDelegate onDragOut;

	[NonSerialized]
	public static VoidDelegate onDragEnd;

	[NonSerialized]
	public static ObjectDelegate onDrop;

	[NonSerialized]
	public static KeyCodeDelegate onKey;

	[NonSerialized]
	public static KeyCodeDelegate onNavigate;

	[NonSerialized]
	public static VectorDelegate onPan;

	[NonSerialized]
	public static BoolDelegate onTooltip;

	[NonSerialized]
	public static MoveDelegate onMouseMove;

	private static MouseOrTouch[] mMouse = new MouseOrTouch[3]
	{
		new MouseOrTouch(),
		new MouseOrTouch(),
		new MouseOrTouch()
	};

	[NonSerialized]
	public static MouseOrTouch controller = new MouseOrTouch();

	[NonSerialized]
	public static List<MouseOrTouch> activeTouches = new List<MouseOrTouch>();

	[NonSerialized]
	private static List<int> mTouchIDs = new List<int>();

	[NonSerialized]
	private static int mWidth = 0;

	[NonSerialized]
	private static int mHeight = 0;

	[NonSerialized]
	private static GameObject mTooltip = null;

	[NonSerialized]
	private Camera mCam;

	[NonSerialized]
	private static float mTooltipTime = 0f;

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

	private static DepthEntry mHit = default(DepthEntry);

	private static BetterList<DepthEntry> mHits = new BetterList<DepthEntry>();

	private static RaycastHit[] mRayHits;

	private static Collider2D[] mOverlap;

	private static Plane m2DPlane = new Plane(Vector3.back, 0f);

	private static float mNextEvent = 0f;

	private static int mNotifying = 0;

	private static bool disableControllerCheck = true;

	private static bool mUsingTouchEvents = true;

	public static GetTouchCountCallback GetInputTouchCount;

	public static GetTouchCallback GetInputTouch;

	[Obsolete("Use new OnDragStart / OnDragOver / OnDragOut / OnDragEnd events instead")]
	public bool stickyPress
	{
		get
		{
			return true;
		}
	}

	public static bool disableController
	{
		get
		{
			if (mDisableController)
			{
				return !UIPopupList.isOpen;
			}
			return false;
		}
		set
		{
			mDisableController = value;
		}
	}

	[Obsolete("Use lastEventPosition instead. It handles controller input properly.")]
	public static Vector2 lastTouchPosition
	{
		get
		{
			return mLastPos;
		}
		set
		{
			mLastPos = value;
		}
	}

	public static Vector2 lastEventPosition
	{
		get
		{
			if (currentScheme == ControlScheme.Controller)
			{
				GameObject gameObject = hoveredObject;
				if (gameObject != null)
				{
					Bounds bounds = NGUIMath.CalculateAbsoluteWidgetBounds(gameObject.transform);
					return NGUITools.FindCameraForLayer(gameObject.layer).WorldToScreenPoint(bounds.center);
				}
			}
			return mLastPos;
		}
		set
		{
			mLastPos = value;
		}
	}

	public static UICamera first
	{
		get
		{
			if (list == null || list.size == 0)
			{
				return null;
			}
			return list.buffer[0];
		}
	}

	public static ControlScheme currentScheme
	{
		get
		{
			if (mCurrentKey == KeyCode.None)
			{
				return ControlScheme.Touch;
			}
			if (mCurrentKey >= KeyCode.JoystickButton0)
			{
				return ControlScheme.Controller;
			}
			if (current != null)
			{
				if (mLastScheme == ControlScheme.Controller && (mCurrentKey == current.submitKey0 || mCurrentKey == current.submitKey1))
				{
					return ControlScheme.Controller;
				}
				if (current.useMouse)
				{
					return ControlScheme.Mouse;
				}
				if (current.useTouch)
				{
					return ControlScheme.Touch;
				}
				return ControlScheme.Controller;
			}
			return ControlScheme.Mouse;
		}
		set
		{
			if (mLastScheme != value)
			{
				switch (value)
				{
				case ControlScheme.Mouse:
					currentKey = KeyCode.Mouse0;
					break;
				case ControlScheme.Controller:
					currentKey = KeyCode.JoystickButton0;
					break;
				case ControlScheme.Touch:
					currentKey = KeyCode.None;
					break;
				default:
					currentKey = KeyCode.Alpha0;
					break;
				}
				mLastScheme = value;
			}
		}
	}

	public static KeyCode currentKey
	{
		get
		{
			return mCurrentKey;
		}
		set
		{
			if (mCurrentKey == value)
			{
				return;
			}
			ControlScheme num = mLastScheme;
			mCurrentKey = value;
			mLastScheme = currentScheme;
			if (num != mLastScheme)
			{
				HideTooltip();
				if (mLastScheme == ControlScheme.Mouse)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
				else if (current != null && current.autoHideCursor)
				{
					Cursor.visible = false;
					Cursor.lockState = CursorLockMode.Locked;
					mMouse[0].ignoreDelta = 2;
				}
				if (onSchemeChange != null)
				{
					onSchemeChange();
				}
			}
		}
	}

	public static Ray currentRay
	{
		get
		{
			if (!(currentCamera != null) || currentTouch == null)
			{
				return default(Ray);
			}
			return currentCamera.ScreenPointToRay(currentTouch.pos);
		}
	}

	public static bool inputHasFocus
	{
		get
		{
			if (mInputFocus && (bool)mSelected && mSelected.activeInHierarchy)
			{
				return true;
			}
			return false;
		}
	}

	[Obsolete("Use delegates instead such as UICamera.onClick, UICamera.onHover, etc.")]
	public static GameObject genericEventHandler
	{
		get
		{
			return mGenericHandler;
		}
		set
		{
			mGenericHandler = value;
		}
	}

	public static MouseOrTouch mouse0
	{
		get
		{
			return mMouse[0];
		}
	}

	public static MouseOrTouch mouse1
	{
		get
		{
			return mMouse[1];
		}
	}

	public static MouseOrTouch mouse2
	{
		get
		{
			return mMouse[2];
		}
	}

	private bool handlesEvents
	{
		get
		{
			return eventHandler == this;
		}
	}

	public Camera cachedCamera
	{
		get
		{
			if (mCam == null)
			{
				mCam = GetComponent<Camera>();
			}
			return mCam;
		}
	}

	public static GameObject tooltipObject
	{
		get
		{
			return mTooltip;
		}
		set
		{
			ShowTooltip(value);
		}
	}

	public static bool isOverUI
	{
		get
		{
			int frameCount = Time.frameCount;
			if (mLastOverCheck != frameCount)
			{
				mLastOverCheck = frameCount;
				if (currentTouch != null)
				{
					if (currentTouch.pressed != null)
					{
						mLastOverResult = IsPartOfUI(currentTouch.pressed);
						return mLastOverResult;
					}
					mLastOverResult = IsPartOfUI(currentTouch.current);
					return mLastOverResult;
				}
				int i = 0;
				for (int count = activeTouches.Count; i < count; i++)
				{
					if (IsPartOfUI(activeTouches[i].pressed))
					{
						mLastOverResult = true;
						return mLastOverResult;
					}
				}
				for (int j = 0; j < 3; j++)
				{
					MouseOrTouch mouseOrTouch = mMouse[j];
					if (IsPartOfUI((mouseOrTouch.pressed != null) ? mouseOrTouch.pressed : ((j == 0) ? mouseOrTouch.current : null)))
					{
						mLastOverResult = true;
						return mLastOverResult;
					}
				}
				mLastOverResult = IsPartOfUI(controller.pressed);
			}
			return mLastOverResult;
		}
	}

	public static bool uiHasFocus
	{
		get
		{
			int frameCount = Time.frameCount;
			if (mLastFocusCheck != frameCount)
			{
				mLastFocusCheck = frameCount;
				if (inputHasFocus)
				{
					mLastFocusResult = true;
					return mLastFocusResult;
				}
				if (currentTouch != null)
				{
					mLastFocusResult = currentTouch.isOverUI;
					return mLastFocusResult;
				}
				int i = 0;
				for (int count = activeTouches.Count; i < count; i++)
				{
					if (IsPartOfUI(activeTouches[i].pressed))
					{
						mLastFocusResult = true;
						return mLastFocusResult;
					}
				}
				MouseOrTouch mouseOrTouch = mMouse[0];
				if (IsPartOfUI(mouseOrTouch.pressed) || IsPartOfUI(mouseOrTouch.current))
				{
					mLastFocusResult = true;
					return mLastFocusResult;
				}
				for (int j = 1; j < 3; j++)
				{
					mouseOrTouch = mMouse[j];
					if (IsPartOfUI(mouseOrTouch.pressed))
					{
						mLastFocusResult = true;
						return mLastFocusResult;
					}
				}
				mLastFocusResult = IsPartOfUI(controller.pressed);
			}
			return mLastFocusResult;
		}
	}

	public static bool interactingWithUI
	{
		get
		{
			int frameCount = Time.frameCount;
			if (mLastInteractionCheck != frameCount)
			{
				mLastInteractionCheck = frameCount;
				if (inputHasFocus)
				{
					mLastInteractionResult = true;
					return mLastInteractionResult;
				}
				int i = 0;
				for (int count = activeTouches.Count; i < count; i++)
				{
					if (IsPartOfUI(activeTouches[i].pressed))
					{
						mLastInteractionResult = true;
						return mLastInteractionResult;
					}
				}
				for (int j = 0; j < 3; j++)
				{
					if (IsPartOfUI(mMouse[j].pressed))
					{
						mLastInteractionResult = true;
						return mLastInteractionResult;
					}
				}
				mLastInteractionResult = IsPartOfUI(controller.pressed);
			}
			return mLastInteractionResult;
		}
	}

	public static GameObject hoveredObject
	{
		get
		{
			if (currentTouch != null && (currentScheme != 0 || currentTouch.dragStarted))
			{
				return currentTouch.current;
			}
			if ((bool)mHover && mHover.activeInHierarchy)
			{
				return mHover;
			}
			mHover = null;
			return null;
		}
		set
		{
			if (mHover == value)
			{
				return;
			}
			bool flag = false;
			UICamera uICamera = current;
			if (currentTouch == null)
			{
				flag = true;
				currentTouchID = -100;
				currentTouch = controller;
			}
			ShowTooltip(null);
			if ((bool)mSelected && currentScheme == ControlScheme.Controller)
			{
				Notify(mSelected, "OnSelect", false);
				if (onSelect != null)
				{
					onSelect(mSelected, false);
				}
				mSelected = null;
			}
			if ((bool)mHover)
			{
				Notify(mHover, "OnHover", false);
				if (onHover != null)
				{
					onHover(mHover, false);
				}
			}
			mHover = value;
			currentTouch.clickNotification = ClickNotification.None;
			if ((bool)mHover)
			{
				if (mHover != controller.current && mHover.GetComponent<UIKeyNavigation>() != null)
				{
					controller.current = mHover;
				}
				if (flag)
				{
					UICamera uICamera2 = ((mHover != null) ? FindCameraForLayer(mHover.layer) : list.buffer[0]);
					if (uICamera2 != null)
					{
						current = uICamera2;
						currentCamera = uICamera2.cachedCamera;
					}
				}
				if (onHover != null)
				{
					onHover(mHover, true);
				}
				Notify(mHover, "OnHover", true);
			}
			if (flag)
			{
				current = uICamera;
				currentCamera = ((uICamera != null) ? uICamera.cachedCamera : null);
				currentTouch = null;
				currentTouchID = -100;
			}
		}
	}

	public static GameObject controllerNavigationObject
	{
		get
		{
			if ((bool)controller.current && controller.current.activeInHierarchy)
			{
				return controller.current;
			}
			if (currentScheme == ControlScheme.Controller && current != null && current.useController && !ignoreControllerInput && UIKeyNavigation.list.size > 0)
			{
				for (int i = 0; i < UIKeyNavigation.list.size; i++)
				{
					UIKeyNavigation uIKeyNavigation = UIKeyNavigation.list.buffer[i];
					if ((bool)uIKeyNavigation && uIKeyNavigation.constraint != UIKeyNavigation.Constraint.Explicit && uIKeyNavigation.startsSelected)
					{
						hoveredObject = uIKeyNavigation.gameObject;
						controller.current = mHover;
						return mHover;
					}
				}
				if (mHover == null)
				{
					for (int j = 0; j < UIKeyNavigation.list.size; j++)
					{
						UIKeyNavigation uIKeyNavigation2 = UIKeyNavigation.list.buffer[j];
						if ((bool)uIKeyNavigation2 && uIKeyNavigation2.constraint != UIKeyNavigation.Constraint.Explicit)
						{
							hoveredObject = uIKeyNavigation2.gameObject;
							controller.current = mHover;
							return mHover;
						}
					}
				}
			}
			controller.current = null;
			return null;
		}
		set
		{
			if (controller.current != value && (bool)controller.current)
			{
				Notify(controller.current, "OnHover", false);
				if (onHover != null)
				{
					onHover(controller.current, false);
				}
				controller.current = null;
			}
			hoveredObject = value;
		}
	}

	public static GameObject selectedObject
	{
		get
		{
			if ((bool)mSelected && mSelected.activeInHierarchy)
			{
				return mSelected;
			}
			mSelected = null;
			return null;
		}
		set
		{
			if (mSelected == value)
			{
				hoveredObject = value;
				controller.current = value;
				return;
			}
			ShowTooltip(null);
			bool flag = false;
			UICamera uICamera = current;
			if (currentTouch == null)
			{
				flag = true;
				currentTouchID = -100;
				currentTouch = controller;
			}
			mInputFocus = false;
			if ((bool)mSelected)
			{
				Notify(mSelected, "OnSelect", false);
				if (onSelect != null)
				{
					onSelect(mSelected, false);
				}
			}
			mSelected = value;
			currentTouch.clickNotification = ClickNotification.None;
			if (value != null && value.GetComponent<UIKeyNavigation>() != null)
			{
				controller.current = value;
			}
			if ((bool)mSelected && flag)
			{
				UICamera uICamera2 = ((mSelected != null) ? FindCameraForLayer(mSelected.layer) : list.buffer[0]);
				if (uICamera2 != null)
				{
					current = uICamera2;
					currentCamera = uICamera2.cachedCamera;
				}
			}
			if ((bool)mSelected)
			{
				mInputFocus = mSelected.activeInHierarchy && mSelected.GetComponent<UIInput>() != null;
				if (onSelect != null)
				{
					onSelect(mSelected, true);
				}
				Notify(mSelected, "OnSelect", true);
			}
			if (flag)
			{
				current = uICamera;
				currentCamera = ((uICamera != null) ? uICamera.cachedCamera : null);
				currentTouch = null;
				currentTouchID = -100;
			}
		}
	}

	[Obsolete("Use either 'CountInputSources()' or 'activeTouches.Count'")]
	public static int touchCount
	{
		get
		{
			return CountInputSources();
		}
	}

	public static int dragCount
	{
		get
		{
			int num = 0;
			int i = 0;
			for (int count = activeTouches.Count; i < count; i++)
			{
				if (activeTouches[i].dragged != null)
				{
					num++;
				}
			}
			for (int j = 0; j < mMouse.Length; j++)
			{
				if (mMouse[j].dragged != null)
				{
					num++;
				}
			}
			if (controller.dragged != null)
			{
				num++;
			}
			return num;
		}
	}

	public static Camera mainCamera
	{
		get
		{
			UICamera uICamera = eventHandler;
			if (!(uICamera != null))
			{
				return null;
			}
			return uICamera.cachedCamera;
		}
	}

	public static UICamera eventHandler
	{
		get
		{
			for (int i = 0; i < list.size; i++)
			{
				UICamera uICamera = list.buffer[i];
				if (!(uICamera == null) && uICamera.enabled && NGUITools.GetActive(uICamera.gameObject))
				{
					return uICamera;
				}
			}
			return null;
		}
	}

	public static bool IsPartOfUI(GameObject go)
	{
		if (go == null || go == fallThrough)
		{
			return false;
		}
		return NGUITools.FindInParents<UIRoot>(go) != null;
	}

	public static bool IsPressed(GameObject go)
	{
		for (int i = 0; i < 3; i++)
		{
			if (mMouse[i].pressed == go)
			{
				return true;
			}
		}
		int j = 0;
		for (int count = activeTouches.Count; j < count; j++)
		{
			if (activeTouches[j].pressed == go)
			{
				return true;
			}
		}
		if (controller.pressed == go)
		{
			return true;
		}
		return false;
	}

	public static int CountInputSources()
	{
		int num = 0;
		int i = 0;
		for (int count = activeTouches.Count; i < count; i++)
		{
			if (activeTouches[i].pressed != null)
			{
				num++;
			}
		}
		for (int j = 0; j < mMouse.Length; j++)
		{
			if (mMouse[j].pressed != null)
			{
				num++;
			}
		}
		if (controller.pressed != null)
		{
			num++;
		}
		return num;
	}

	private static int CompareFunc(UICamera a, UICamera b)
	{
		if (a.cachedCamera.depth < b.cachedCamera.depth)
		{
			return 1;
		}
		if (a.cachedCamera.depth > b.cachedCamera.depth)
		{
			return -1;
		}
		return 0;
	}

	private static Rigidbody FindRootRigidbody(Transform trans)
	{
		while (trans != null && !(trans.GetComponent<UIPanel>() != null))
		{
			Rigidbody component = trans.GetComponent<Rigidbody>();
			if (component != null)
			{
				return component;
			}
			trans = trans.parent;
		}
		return null;
	}

	private static Rigidbody2D FindRootRigidbody2D(Transform trans)
	{
		while (trans != null && !(trans.GetComponent<UIPanel>() != null))
		{
			Rigidbody2D component = trans.GetComponent<Rigidbody2D>();
			if (component != null)
			{
				return component;
			}
			trans = trans.parent;
		}
		return null;
	}

	public static void Raycast(MouseOrTouch touch)
	{
		if (!Raycast(touch.pos))
		{
			mRayHitObject = fallThrough;
		}
		if (mRayHitObject == null)
		{
			mRayHitObject = mGenericHandler;
		}
		touch.last = touch.current;
		touch.current = mRayHitObject;
		mLastPos = touch.pos;
	}

	public static bool Raycast(Vector3 inPos)
	{
		for (int i = 0; i < list.size; i++)
		{
			UICamera uICamera = list.buffer[i];
			if (!uICamera.enabled || !NGUITools.GetActive(uICamera.gameObject))
			{
				continue;
			}
			currentCamera = uICamera.cachedCamera;
			if (currentCamera.targetDisplay != 0)
			{
				continue;
			}
			Vector3 vector = currentCamera.ScreenToViewportPoint(inPos);
			if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || vector.x < 0f || vector.x > 1f || vector.y < 0f || vector.y > 1f)
			{
				continue;
			}
			Ray ray = currentCamera.ScreenPointToRay(inPos);
			int layerMask = currentCamera.cullingMask & (int)uICamera.eventReceiverMask;
			float enter = ((uICamera.rangeDistance > 0f) ? uICamera.rangeDistance : (currentCamera.farClipPlane - currentCamera.nearClipPlane));
			if (uICamera.eventType == EventType.World_3D)
			{
				lastWorldRay = ray;
				if (!Physics.Raycast(ray, out lastHit, enter, layerMask, QueryTriggerInteraction.Ignore))
				{
					continue;
				}
				lastWorldPosition = lastHit.point;
				mRayHitObject = lastHit.collider.gameObject;
				if (!uICamera.eventsGoToColliders)
				{
					Rigidbody componentInParent = mRayHitObject.gameObject.GetComponentInParent<Rigidbody>();
					if (componentInParent != null)
					{
						mRayHitObject = componentInParent.gameObject;
					}
				}
				return true;
			}
			if (uICamera.eventType == EventType.UI_3D)
			{
				if (mRayHits == null)
				{
					mRayHits = new RaycastHit[50];
				}
				int num = Physics.RaycastNonAlloc(ray, mRayHits, enter, layerMask, QueryTriggerInteraction.Collide);
				if (num > 1)
				{
					for (int j = 0; j < num; j++)
					{
						GameObject gameObject = mRayHits[j].collider.gameObject;
						UIWidget component = gameObject.GetComponent<UIWidget>();
						if (component != null)
						{
							if (!component.isVisible || (component is UISpriteCollection && !(component as UISpriteCollection).GetCurrentSprite().HasValue) || (component.hitCheck != null && !component.hitCheck(mRayHits[j].point)))
							{
								continue;
							}
						}
						else
						{
							UIRect uIRect = NGUITools.FindInParents<UIRect>(gameObject);
							if (uIRect != null && uIRect.finalAlpha < 0.001f)
							{
								continue;
							}
						}
						mHit.depth = NGUITools.CalculateRaycastDepth(gameObject);
						if (mHit.depth != int.MaxValue)
						{
							mHit.hit = mRayHits[j];
							mHit.point = mRayHits[j].point;
							mHit.go = mRayHits[j].collider.gameObject;
							mHits.Add(mHit);
						}
					}
					mHits.Sort((DepthEntry r1, DepthEntry r2) => r2.depth.CompareTo(r1.depth));
					for (int k = 0; k < mHits.size; k++)
					{
						if (IsVisible(ref mHits.buffer[k]))
						{
							lastHit = mHits.buffer[k].hit;
							mRayHitObject = mHits.buffer[k].go;
							lastWorldRay = ray;
							lastWorldPosition = mHits.buffer[k].point;
							mHits.Clear();
							return true;
						}
					}
					mHits.Clear();
				}
				else
				{
					if (num != 1)
					{
						continue;
					}
					GameObject gameObject2 = mRayHits[0].collider.gameObject;
					UIWidget component2 = gameObject2.GetComponent<UIWidget>();
					if (component2 != null)
					{
						if (!component2.isVisible || (component2.hitCheck != null && !component2.hitCheck(mRayHits[0].point)))
						{
							continue;
						}
					}
					else
					{
						UIRect uIRect2 = NGUITools.FindInParents<UIRect>(gameObject2);
						if (uIRect2 != null && uIRect2.finalAlpha < 0.001f)
						{
							continue;
						}
					}
					if (IsVisible(mRayHits[0].point, mRayHits[0].collider.gameObject))
					{
						lastHit = mRayHits[0];
						lastWorldRay = ray;
						lastWorldPosition = mRayHits[0].point;
						mRayHitObject = lastHit.collider.gameObject;
						return true;
					}
				}
			}
			else
			{
				if (uICamera.eventType == EventType.World_2D)
				{
					if (!m2DPlane.Raycast(ray, out enter))
					{
						continue;
					}
					Vector3 point = ray.GetPoint(enter);
					Collider2D collider2D = Physics2D.OverlapPoint(point, layerMask);
					if (!collider2D)
					{
						continue;
					}
					lastWorldPosition = point;
					mRayHitObject = collider2D.gameObject;
					if (!uICamera.eventsGoToColliders)
					{
						Rigidbody2D rigidbody2D = FindRootRigidbody2D(mRayHitObject.transform);
						if (rigidbody2D != null)
						{
							mRayHitObject = rigidbody2D.gameObject;
						}
					}
					return true;
				}
				if (uICamera.eventType != EventType.UI_2D || !m2DPlane.Raycast(ray, out enter))
				{
					continue;
				}
				lastWorldPosition = ray.GetPoint(enter);
				if (mOverlap == null)
				{
					mOverlap = new Collider2D[50];
				}
				int num2 = Physics2D.OverlapPointNonAlloc(lastWorldPosition, mOverlap, layerMask);
				if (num2 > 1)
				{
					for (int l = 0; l < num2; l++)
					{
						GameObject gameObject3 = mOverlap[l].gameObject;
						UIWidget component3 = gameObject3.GetComponent<UIWidget>();
						if (component3 != null)
						{
							if (!component3.isVisible || (component3.hitCheck != null && !component3.hitCheck(lastWorldPosition)))
							{
								continue;
							}
						}
						else
						{
							UIRect uIRect3 = NGUITools.FindInParents<UIRect>(gameObject3);
							if (uIRect3 != null && uIRect3.finalAlpha < 0.001f)
							{
								continue;
							}
						}
						mHit.depth = NGUITools.CalculateRaycastDepth(gameObject3);
						if (mHit.depth != int.MaxValue)
						{
							mHit.go = gameObject3;
							mHit.point = lastWorldPosition;
							mHits.Add(mHit);
						}
					}
					mHits.Sort((DepthEntry r1, DepthEntry r2) => r2.depth.CompareTo(r1.depth));
					for (int m = 0; m < mHits.size; m++)
					{
						if (IsVisible(ref mHits.buffer[m]))
						{
							mRayHitObject = mHits.buffer[m].go;
							mHits.Clear();
							return true;
						}
					}
					mHits.Clear();
				}
				else
				{
					if (num2 != 1)
					{
						continue;
					}
					GameObject gameObject4 = mOverlap[0].gameObject;
					UIWidget component4 = gameObject4.GetComponent<UIWidget>();
					if (component4 != null)
					{
						if (!component4.isVisible || (component4.hitCheck != null && !component4.hitCheck(lastWorldPosition)))
						{
							continue;
						}
					}
					else
					{
						UIRect uIRect4 = NGUITools.FindInParents<UIRect>(gameObject4);
						if (uIRect4 != null && uIRect4.finalAlpha < 0.001f)
						{
							continue;
						}
					}
					if (IsVisible(lastWorldPosition, gameObject4))
					{
						mRayHitObject = gameObject4;
						return true;
					}
				}
			}
		}
		return false;
	}

	private static bool IsVisible(Vector3 worldPoint, GameObject go)
	{
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(go);
		while (uIPanel != null)
		{
			if (!uIPanel.IsVisible(worldPoint))
			{
				return false;
			}
			uIPanel = uIPanel.parentPanel;
		}
		return true;
	}

	private static bool IsVisible(ref DepthEntry de)
	{
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(de.go);
		while (uIPanel != null)
		{
			if (!uIPanel.IsVisible(de.point))
			{
				return false;
			}
			uIPanel = uIPanel.parentPanel;
		}
		return true;
	}

	public static bool IsHighlighted(GameObject go)
	{
		return hoveredObject == go;
	}

	public static UICamera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		for (int i = 0; i < list.size; i++)
		{
			UICamera uICamera = list.buffer[i];
			Camera camera = uICamera.cachedCamera;
			if (camera != null && (camera.cullingMask & num) != 0)
			{
				return uICamera;
			}
		}
		return null;
	}

	private static int GetDirection(KeyCode up, KeyCode down)
	{
		if (GetKeyDown(up))
		{
			currentKey = up;
			return 1;
		}
		if (GetKeyDown(down))
		{
			currentKey = down;
			return -1;
		}
		return 0;
	}

	private static int GetDirection(KeyCode up0, KeyCode up1, KeyCode down0, KeyCode down1)
	{
		if (GetKeyDown(up0))
		{
			currentKey = up0;
			return 1;
		}
		if (GetKeyDown(up1))
		{
			currentKey = up1;
			return 1;
		}
		if (GetKeyDown(down0))
		{
			currentKey = down0;
			return -1;
		}
		if (GetKeyDown(down1))
		{
			currentKey = down1;
			return -1;
		}
		return 0;
	}

	private static int GetDirection(string axis)
	{
		float time = RealTime.time;
		if (mNextEvent < time && !string.IsNullOrEmpty(axis))
		{
			float num = GetAxis(axis);
			if (num > 0.75f)
			{
				currentKey = KeyCode.JoystickButton0;
				mNextEvent = time + 0.25f;
				return 1;
			}
			if (num < -0.75f)
			{
				currentKey = KeyCode.JoystickButton0;
				mNextEvent = time + 0.25f;
				return -1;
			}
		}
		return 0;
	}

	public static void Notify(GameObject go, string funcName, object obj)
	{
		if (mNotifying > 10)
		{
			return;
		}
		if (currentScheme == ControlScheme.Controller && UIPopupList.isOpen && UIPopupList.current.source == go && UIPopupList.isOpen)
		{
			go = UIPopupList.current.gameObject;
		}
		if ((bool)go && go.activeInHierarchy)
		{
			mNotifying++;
			go.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			if (mGenericHandler != null && mGenericHandler != go)
			{
				mGenericHandler.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			}
			mNotifying--;
		}
	}

	private void Awake()
	{
		mWidth = Screen.width;
		mHeight = Screen.height;
		if (Application.platform == RuntimePlatform.PS4 || Application.platform == RuntimePlatform.XboxOne)
		{
			currentScheme = ControlScheme.Controller;
		}
		mMouse[0].pos = Input.mousePosition;
		for (int i = 1; i < 3; i++)
		{
			mMouse[i].pos = mMouse[0].pos;
			mMouse[i].lastPos = mMouse[0].pos;
		}
		mLastPos = mMouse[0].pos;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs == null)
		{
			return;
		}
		for (int j = 0; j < commandLineArgs.Length; j++)
		{
			switch (commandLineArgs[j])
			{
			case "-noMouse":
				useMouse = false;
				break;
			case "-noTouch":
				useTouch = false;
				break;
			case "-noController":
				useController = false;
				ignoreControllerInput = true;
				break;
			case "-noJoystick":
				useController = false;
				ignoreControllerInput = true;
				break;
			case "-useMouse":
				useMouse = true;
				break;
			case "-useTouch":
				useTouch = true;
				break;
			case "-useController":
				useController = true;
				break;
			case "-useJoystick":
				useController = true;
				break;
			}
		}
	}

	private void OnEnable()
	{
		list.Add(this);
		list.Sort(CompareFunc);
	}

	private void OnDisable()
	{
		list.Remove(this);
	}

	private void Start()
	{
		list.Sort(CompareFunc);
		if (eventType != 0 && cachedCamera.transparencySortMode != TransparencySortMode.Orthographic)
		{
			cachedCamera.transparencySortMode = TransparencySortMode.Orthographic;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		if (fallThrough == null)
		{
			UIRoot uIRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
			fallThrough = ((uIRoot != null) ? uIRoot.gameObject : base.gameObject);
		}
		cachedCamera.eventMask = 0;
		if (!ignoreControllerInput && disableControllerCheck && useController && handlesEvents)
		{
			disableControllerCheck = false;
			if (!string.IsNullOrEmpty(horizontalAxisName) && Mathf.Abs(GetAxis(horizontalAxisName)) > 0.1f)
			{
				ignoreControllerInput = true;
			}
			else if (!string.IsNullOrEmpty(verticalAxisName) && Mathf.Abs(GetAxis(verticalAxisName)) > 0.1f)
			{
				ignoreControllerInput = true;
			}
			else if (!string.IsNullOrEmpty(horizontalPanAxisName) && Mathf.Abs(GetAxis(horizontalPanAxisName)) > 0.1f)
			{
				ignoreControllerInput = true;
			}
			else if (!string.IsNullOrEmpty(verticalPanAxisName) && Mathf.Abs(GetAxis(verticalPanAxisName)) > 0.1f)
			{
				ignoreControllerInput = true;
			}
		}
	}

	[ContextMenu("Start ignoring events")]
	private void StartIgnoring()
	{
		ignoreAllEvents = true;
	}

	[ContextMenu("Stop ignoring events")]
	private void StopIgnoring()
	{
		ignoreAllEvents = false;
	}

	private void Update()
	{
		if (!ignoreAllEvents && handlesEvents && processEventsIn == ProcessEventsIn.Update)
		{
			ProcessEvents();
		}
	}

	private void LateUpdate()
	{
		if (!handlesEvents)
		{
			return;
		}
		if (processEventsIn == ProcessEventsIn.LateUpdate)
		{
			ProcessEvents();
		}
		int width = Screen.width;
		int height = Screen.height;
		if (width != mWidth || height != mHeight)
		{
			mWidth = width;
			mHeight = height;
			UIRoot.Broadcast("UpdateAnchors");
			if (onScreenResize != null)
			{
				onScreenResize();
			}
		}
	}

	private void ProcessEvents()
	{
		current = this;
		NGUIDebug.debugRaycast = debug;
		if (useTouch)
		{
			ProcessTouches();
		}
		else if (useMouse)
		{
			ProcessMouse();
		}
		if (onCustomInput != null)
		{
			onCustomInput();
		}
		if ((useKeyboard || useController) && !disableController && !ignoreControllerInput)
		{
			ProcessOthers();
		}
		if (useMouse && mHover != null)
		{
			float num = ((!string.IsNullOrEmpty(scrollAxisName)) ? GetAxis(scrollAxisName) : 0f);
			if (num != 0f)
			{
				if (onScroll != null)
				{
					onScroll(mHover, num);
				}
				Notify(mHover, "OnScroll", num);
			}
			if (currentScheme == ControlScheme.Mouse && showTooltips && mTooltipTime != 0f && !UIPopupList.isOpen && mMouse[0].dragged == null && (mTooltipTime < Time.unscaledTime || GetKey(KeyCode.LeftShift) || GetKey(KeyCode.RightShift)))
			{
				currentTouch = mMouse[0];
				currentTouchID = -1;
				ShowTooltip(mHover);
			}
		}
		if (mTooltip != null && !NGUITools.GetActive(mTooltip))
		{
			ShowTooltip(null);
		}
		current = null;
		currentTouchID = -100;
	}

	public void ProcessMouse()
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < 3; i++)
		{
			if (Input.GetMouseButtonDown(i))
			{
				currentKey = (KeyCode)(323 + i);
				flag2 = true;
				flag = true;
			}
			else if (Input.GetMouseButton(i))
			{
				currentKey = (KeyCode)(323 + i);
				flag = true;
			}
		}
		if (currentScheme == ControlScheme.Touch && activeTouches.Count > 0)
		{
			return;
		}
		currentTouch = mMouse[0];
		Vector2 vector = Input.mousePosition;
		if (currentTouch.ignoreDelta == 0)
		{
			currentTouch.delta = vector - currentTouch.pos;
		}
		else
		{
			currentTouch.ignoreDelta--;
			currentTouch.delta.x = 0f;
			currentTouch.delta.y = 0f;
		}
		float sqrMagnitude = currentTouch.delta.sqrMagnitude;
		currentTouch.pos = vector;
		mLastPos = vector;
		bool flag3 = false;
		if (currentScheme != 0)
		{
			if (sqrMagnitude < 0.001f)
			{
				return;
			}
			currentKey = KeyCode.Mouse0;
			flag3 = true;
		}
		else if (sqrMagnitude > 0.001f)
		{
			flag3 = true;
		}
		for (int j = 1; j < 3; j++)
		{
			mMouse[j].pos = currentTouch.pos;
			mMouse[j].delta = currentTouch.delta;
		}
		if (flag || flag3 || mNextRaycast < RealTime.time)
		{
			mNextRaycast = RealTime.time + 0.02f;
			Raycast(currentTouch);
			if (flag)
			{
				flag3 = true;
				for (int k = 1; k < 3; k++)
				{
					mMouse[k].current = currentTouch.current;
				}
			}
			else if (mMouse[0].current != currentTouch.current)
			{
				currentKey = KeyCode.Mouse0;
				flag3 = true;
				for (int l = 1; l < 3; l++)
				{
					mMouse[l].current = currentTouch.current;
				}
			}
		}
		bool flag4 = currentTouch.last != currentTouch.current;
		bool flag5 = currentTouch.pressed != null;
		if (!flag5 && flag3)
		{
			hoveredObject = currentTouch.current;
		}
		currentTouchID = -1;
		if (flag4)
		{
			currentKey = KeyCode.Mouse0;
		}
		if (!flag && flag3)
		{
			if (mTooltipTime != 0f)
			{
				mTooltipTime = Time.unscaledTime + tooltipDelay;
			}
			else if (mTooltip != null && (!stickyTooltip || flag4))
			{
				ShowTooltip(null);
			}
		}
		if (flag3 && onMouseMove != null)
		{
			onMouseMove(currentTouch.delta);
			currentTouch = null;
		}
		if (flag4 && (flag2 || (flag5 && !flag)))
		{
			hoveredObject = null;
		}
		for (int m = 0; m < 3; m++)
		{
			bool mouseButtonDown = Input.GetMouseButtonDown(m);
			bool mouseButtonUp = Input.GetMouseButtonUp(m);
			if (mouseButtonDown || mouseButtonUp)
			{
				currentKey = (KeyCode)(323 + m);
			}
			currentTouch = mMouse[m];
			currentTouchID = -1 - m;
			currentKey = (KeyCode)(323 + m);
			if (mouseButtonDown)
			{
				currentTouch.pressedCam = currentCamera;
				currentTouch.pressTime = RealTime.time;
			}
			else if (currentTouch.pressed != null)
			{
				currentCamera = currentTouch.pressedCam;
			}
			ProcessTouch(mouseButtonDown, mouseButtonUp);
		}
		if (!flag && flag4)
		{
			currentTouch = mMouse[0];
			mTooltipTime = Time.unscaledTime + tooltipDelay;
			currentTouchID = -1;
			currentKey = KeyCode.Mouse0;
			hoveredObject = currentTouch.current;
		}
		currentTouch = null;
		mMouse[0].last = mMouse[0].current;
		for (int n = 1; n < 3; n++)
		{
			mMouse[n].last = mMouse[0].last;
		}
	}

	public void ProcessTouches()
	{
		int num = ((GetInputTouchCount == null) ? Input.touchCount : GetInputTouchCount());
		for (int i = 0; i < num; i++)
		{
			TouchPhase phase;
			int fingerId;
			Vector2 position;
			int tapCount;
			if (GetInputTouch == null)
			{
				UnityEngine.Touch touch = Input.GetTouch(i);
				phase = touch.phase;
				fingerId = touch.fingerId;
				position = touch.position;
				tapCount = touch.tapCount;
			}
			else
			{
				Touch touch2 = GetInputTouch(i);
				phase = touch2.phase;
				fingerId = touch2.fingerId;
				position = touch2.position;
				tapCount = touch2.tapCount;
			}
			currentTouchID = ((!allowMultiTouch) ? 1 : fingerId);
			currentTouch = GetTouch(currentTouchID, true);
			bool flag = phase == TouchPhase.Began || currentTouch.touchBegan;
			bool flag2 = phase == TouchPhase.Canceled || phase == TouchPhase.Ended;
			currentTouch.delta = position - currentTouch.pos;
			currentTouch.pos = position;
			currentKey = KeyCode.None;
			Raycast(currentTouch);
			if (flag)
			{
				currentTouch.pressedCam = currentCamera;
			}
			else if (currentTouch.pressed != null)
			{
				currentCamera = currentTouch.pressedCam;
			}
			if (tapCount > 1)
			{
				currentTouch.clickTime = RealTime.time;
			}
			ProcessTouch(flag, flag2);
			if (flag2)
			{
				RemoveTouch(currentTouchID);
			}
			currentTouch.touchBegan = false;
			currentTouch.last = null;
			currentTouch = null;
			if (!allowMultiTouch)
			{
				break;
			}
		}
		if (num == 0)
		{
			if (mUsingTouchEvents)
			{
				mUsingTouchEvents = false;
			}
			else if (useMouse)
			{
				ProcessMouse();
			}
		}
		else
		{
			mUsingTouchEvents = true;
		}
	}

	private void ProcessFakeTouches()
	{
		bool mouseButtonDown = Input.GetMouseButtonDown(0);
		bool mouseButtonUp = Input.GetMouseButtonUp(0);
		bool mouseButton = Input.GetMouseButton(0);
		if (mouseButtonDown || mouseButtonUp || mouseButton)
		{
			currentTouchID = 1;
			currentTouch = mMouse[0];
			currentTouch.touchBegan = mouseButtonDown;
			if (mouseButtonDown)
			{
				currentTouch.pressTime = RealTime.time;
				activeTouches.Add(currentTouch);
			}
			Vector2 vector = Input.mousePosition;
			currentTouch.delta = vector - currentTouch.pos;
			currentTouch.pos = vector;
			Raycast(currentTouch);
			if (mouseButtonDown)
			{
				currentTouch.pressedCam = currentCamera;
			}
			else if (currentTouch.pressed != null)
			{
				currentCamera = currentTouch.pressedCam;
			}
			currentKey = KeyCode.None;
			ProcessTouch(mouseButtonDown, mouseButtonUp);
			if (mouseButtonUp)
			{
				activeTouches.Remove(currentTouch);
			}
			currentTouch.last = null;
			currentTouch = null;
		}
	}

	public void ProcessOthers()
	{
		currentTouchID = -100;
		currentTouch = controller;
		bool flag = false;
		bool flag2 = false;
		if (submitKey0 != 0 && GetKeyDown(submitKey0))
		{
			currentKey = submitKey0;
			flag = true;
		}
		else if (submitKey1 != 0 && GetKeyDown(submitKey1))
		{
			currentKey = submitKey1;
			flag = true;
		}
		else if ((submitKey0 == KeyCode.Return || submitKey1 == KeyCode.Return) && GetKeyDown(KeyCode.KeypadEnter))
		{
			currentKey = submitKey0;
			flag = true;
		}
		if (submitKey0 != 0 && GetKeyUp(submitKey0))
		{
			currentKey = submitKey0;
			flag2 = true;
		}
		else if (submitKey1 != 0 && GetKeyUp(submitKey1))
		{
			currentKey = submitKey1;
			flag2 = true;
		}
		else if ((submitKey0 == KeyCode.Return || submitKey1 == KeyCode.Return) && GetKeyUp(KeyCode.KeypadEnter))
		{
			currentKey = submitKey0;
			flag2 = true;
		}
		if (flag)
		{
			currentTouch.pressTime = RealTime.time;
		}
		if ((flag || flag2) && currentScheme == ControlScheme.Controller)
		{
			currentTouch.current = controllerNavigationObject;
			ProcessTouch(flag, flag2);
			currentTouch.last = currentTouch.current;
		}
		KeyCode keyCode = KeyCode.None;
		if (useController && !ignoreControllerInput)
		{
			if (!disableController && currentScheme == ControlScheme.Controller && (currentTouch.current == null || !currentTouch.current.activeInHierarchy))
			{
				currentTouch.current = controllerNavigationObject;
			}
			if (!string.IsNullOrEmpty(verticalAxisName))
			{
				int direction = GetDirection(verticalAxisName);
				if (direction != 0)
				{
					ShowTooltip(null);
					currentScheme = ControlScheme.Controller;
					currentTouch.current = controllerNavigationObject;
					if (currentTouch.current != null)
					{
						keyCode = ((direction > 0) ? KeyCode.UpArrow : KeyCode.DownArrow);
						if (onNavigate != null)
						{
							onNavigate(currentTouch.current, keyCode);
						}
						Notify(currentTouch.current, "OnNavigate", keyCode);
					}
				}
			}
			if (!string.IsNullOrEmpty(horizontalAxisName))
			{
				int direction2 = GetDirection(horizontalAxisName);
				if (direction2 != 0)
				{
					ShowTooltip(null);
					currentScheme = ControlScheme.Controller;
					currentTouch.current = controllerNavigationObject;
					if (currentTouch.current != null)
					{
						keyCode = ((direction2 > 0) ? KeyCode.RightArrow : KeyCode.LeftArrow);
						if (onNavigate != null)
						{
							onNavigate(currentTouch.current, keyCode);
						}
						Notify(currentTouch.current, "OnNavigate", keyCode);
					}
				}
			}
			float num = ((!string.IsNullOrEmpty(horizontalPanAxisName)) ? GetAxis(horizontalPanAxisName) : 0f);
			float num2 = ((!string.IsNullOrEmpty(verticalPanAxisName)) ? GetAxis(verticalPanAxisName) : 0f);
			if (num != 0f || num2 != 0f)
			{
				ShowTooltip(null);
				currentScheme = ControlScheme.Controller;
				currentTouch.current = controllerNavigationObject;
				if (currentTouch.current != null)
				{
					Vector2 vector = new Vector2(num, num2);
					vector *= Time.unscaledDeltaTime;
					if (onPan != null)
					{
						onPan(currentTouch.current, vector);
					}
					Notify(currentTouch.current, "OnPan", vector);
				}
			}
		}
		if ((GetAnyKeyDown != null) ? GetAnyKeyDown() : Input.anyKeyDown)
		{
			int i = 0;
			for (int num3 = NGUITools.keys.Length; i < num3; i++)
			{
				KeyCode keyCode2 = NGUITools.keys[i];
				if (keyCode != keyCode2 && GetKeyDown(keyCode2) && (useKeyboard || keyCode2 >= KeyCode.Mouse0) && ((useController && !ignoreControllerInput) || keyCode2 < KeyCode.JoystickButton0) && (useMouse || keyCode2 < KeyCode.Mouse0 || keyCode2 > KeyCode.Mouse6))
				{
					currentKey = keyCode2;
					if (onKey != null)
					{
						onKey(currentTouch.current, keyCode2);
					}
					Notify(currentTouch.current, "OnKey", keyCode2);
				}
			}
		}
		currentTouch = null;
	}

	private void ProcessPress(bool pressed, float click, float drag)
	{
		if (pressed)
		{
			if (mTooltip != null)
			{
				ShowTooltip(null);
			}
			mTooltipTime = Time.unscaledTime + tooltipDelay;
			currentTouch.pressStarted = true;
			if (onPress != null && (bool)currentTouch.pressed)
			{
				onPress(currentTouch.pressed, false);
			}
			Notify(currentTouch.pressed, "OnPress", false);
			if (currentScheme == ControlScheme.Mouse && hoveredObject == null && currentTouch.current != null)
			{
				hoveredObject = currentTouch.current;
			}
			currentTouch.pressed = currentTouch.current;
			currentTouch.dragged = currentTouch.current;
			currentTouch.clickNotification = ClickNotification.BasedOnDelta;
			currentTouch.totalDelta = Vector2.zero;
			currentTouch.dragStarted = false;
			if (onPress != null && (bool)currentTouch.pressed)
			{
				onPress(currentTouch.pressed, true);
			}
			Notify(currentTouch.pressed, "OnPress", true);
			if (!(mSelected != currentTouch.pressed))
			{
				return;
			}
			mInputFocus = false;
			if ((bool)mSelected)
			{
				Notify(mSelected, "OnSelect", false);
				if (onSelect != null)
				{
					onSelect(mSelected, false);
				}
			}
			mSelected = currentTouch.pressed;
			if (currentTouch.pressed != null && currentTouch.pressed.GetComponent<UIKeyNavigation>() != null)
			{
				controller.current = currentTouch.pressed;
			}
			if ((bool)mSelected)
			{
				mInputFocus = mSelected.activeInHierarchy && mSelected.GetComponent<UIInput>() != null;
				if (onSelect != null)
				{
					onSelect(mSelected, true);
				}
				Notify(mSelected, "OnSelect", true);
			}
		}
		else
		{
			if (!(currentTouch.pressed != null) || (currentTouch.delta.sqrMagnitude == 0f && !(currentTouch.current != currentTouch.last)))
			{
				return;
			}
			currentTouch.totalDelta += currentTouch.delta;
			float sqrMagnitude = currentTouch.totalDelta.sqrMagnitude;
			bool flag = false;
			if (!currentTouch.dragStarted && currentTouch.last != currentTouch.current)
			{
				currentTouch.dragStarted = true;
				currentTouch.delta = currentTouch.totalDelta;
				currentTouch.clickNotification = ClickNotification.None;
				isDragging = true;
				if (onDragStart != null)
				{
					onDragStart(currentTouch.dragged);
				}
				Notify(currentTouch.dragged, "OnDragStart", null);
				if (onDragOver != null)
				{
					onDragOver(currentTouch.last, currentTouch.dragged);
				}
				Notify(currentTouch.last, "OnDragOver", currentTouch.dragged);
				isDragging = false;
			}
			else if (!currentTouch.dragStarted && drag < sqrMagnitude)
			{
				flag = true;
				currentTouch.dragStarted = true;
				currentTouch.delta = currentTouch.totalDelta;
			}
			if (!currentTouch.dragStarted)
			{
				return;
			}
			if (mTooltip != null)
			{
				ShowTooltip(null);
			}
			isDragging = true;
			bool num = currentTouch.clickNotification == ClickNotification.None;
			if (flag)
			{
				if (onDragStart != null)
				{
					onDragStart(currentTouch.dragged);
				}
				Notify(currentTouch.dragged, "OnDragStart", null);
				if (onDragOver != null)
				{
					onDragOver(currentTouch.last, currentTouch.dragged);
				}
				Notify(currentTouch.current, "OnDragOver", currentTouch.dragged);
			}
			else if (currentTouch.last != currentTouch.current)
			{
				if (onDragOut != null)
				{
					onDragOut(currentTouch.last, currentTouch.dragged);
				}
				Notify(currentTouch.last, "OnDragOut", currentTouch.dragged);
				if (onDragOver != null)
				{
					onDragOver(currentTouch.last, currentTouch.dragged);
				}
				Notify(currentTouch.current, "OnDragOver", currentTouch.dragged);
			}
			if (onDrag != null)
			{
				onDrag(currentTouch.dragged, currentTouch.delta);
			}
			Notify(currentTouch.dragged, "OnDrag", currentTouch.delta);
			currentTouch.last = currentTouch.current;
			isDragging = false;
			if (num)
			{
				currentTouch.clickNotification = ClickNotification.None;
			}
			else if (currentTouch.clickNotification == ClickNotification.BasedOnDelta && click < sqrMagnitude)
			{
				currentTouch.clickNotification = ClickNotification.None;
			}
		}
	}

	private void ProcessRelease(bool isMouse, float drag)
	{
		if (currentTouch == null)
		{
			return;
		}
		currentTouch.pressStarted = false;
		if (currentTouch.pressed != null)
		{
			if (currentTouch.dragStarted)
			{
				if (onDragOut != null)
				{
					onDragOut(currentTouch.last, currentTouch.dragged);
				}
				Notify(currentTouch.last, "OnDragOut", currentTouch.dragged);
				if (onDragEnd != null)
				{
					onDragEnd(currentTouch.dragged);
				}
				Notify(currentTouch.dragged, "OnDragEnd", null);
			}
			if (onPress != null)
			{
				onPress(currentTouch.pressed, false);
			}
			Notify(currentTouch.pressed, "OnPress", false);
			if (isMouse && HasCollider(currentTouch.pressed))
			{
				if (mHover == currentTouch.current)
				{
					if (onHover != null)
					{
						onHover(currentTouch.current, true);
					}
					Notify(currentTouch.current, "OnHover", true);
				}
				else
				{
					hoveredObject = currentTouch.current;
				}
			}
			if (currentTouch.dragged == currentTouch.current || (currentScheme != ControlScheme.Controller && currentTouch.clickNotification != 0 && currentTouch.totalDelta.sqrMagnitude < drag))
			{
				if (currentTouch.clickNotification != 0 && currentTouch.pressed == currentTouch.current)
				{
					ShowTooltip(null);
					float time = RealTime.time;
					if (onClick != null)
					{
						onClick(currentTouch.pressed);
					}
					Notify(currentTouch.pressed, "OnClick", null);
					if (currentTouch.clickTime + 0.35f > time && currentTouch.lastClickGO == currentTouch.pressed)
					{
						if (onDoubleClick != null)
						{
							onDoubleClick(currentTouch.pressed);
						}
						Notify(currentTouch.pressed, "OnDoubleClick", null);
					}
					currentTouch.lastClickGO = currentTouch.pressed;
					currentTouch.clickTime = time;
				}
			}
			else if (currentTouch.dragStarted)
			{
				if (onDrop != null)
				{
					onDrop(currentTouch.current, currentTouch.dragged);
				}
				Notify(currentTouch.current, "OnDrop", currentTouch.dragged);
			}
		}
		currentTouch.dragStarted = false;
		currentTouch.pressed = null;
		currentTouch.dragged = null;
	}

	private bool HasCollider(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		Collider component = go.GetComponent<Collider>();
		if (component != null)
		{
			return component.enabled;
		}
		Collider2D component2 = go.GetComponent<Collider2D>();
		if (component2 != null)
		{
			return component2.enabled;
		}
		return false;
	}

	public void ProcessTouch(bool pressed, bool released)
	{
		if (released)
		{
			mTooltipTime = 0f;
		}
		bool flag = currentScheme == ControlScheme.Mouse;
		float num = (flag ? mouseDragThreshold : touchDragThreshold);
		float num2 = (flag ? mouseClickThreshold : touchClickThreshold);
		num *= num;
		num2 *= num2;
		if (currentTouch.pressed != null)
		{
			if (released)
			{
				ProcessRelease(flag, num);
			}
			ProcessPress(pressed, num2, num);
			if (tooltipDelay != 0f && currentTouch.deltaTime > tooltipDelay && currentTouch.pressed == currentTouch.current && mTooltipTime != 0f && !currentTouch.dragStarted)
			{
				mTooltipTime = 0f;
				currentTouch.clickNotification = ClickNotification.None;
				if (longPressTooltip)
				{
					ShowTooltip(currentTouch.pressed);
				}
				Notify(currentTouch.current, "OnLongPress", null);
			}
		}
		else if (flag || pressed || released)
		{
			ProcessPress(pressed, num2, num);
			if (released)
			{
				ProcessRelease(flag, num);
			}
		}
	}

	public static void CancelNextTooltip()
	{
		mTooltipTime = 0f;
	}

	public static bool ShowTooltip(GameObject go)
	{
		if (mTooltip != go)
		{
			if (mTooltip != null)
			{
				if (onTooltip != null)
				{
					onTooltip(mTooltip, false);
				}
				Notify(mTooltip, "OnTooltip", false);
			}
			mTooltip = go;
			mTooltipTime = 0f;
			if (mTooltip != null)
			{
				if (onTooltip != null)
				{
					onTooltip(mTooltip, true);
				}
				Notify(mTooltip, "OnTooltip", true);
			}
			return true;
		}
		return false;
	}

	public static bool HideTooltip()
	{
		return ShowTooltip(null);
	}

	public static void ResetTooltip(float delay = 0.5f)
	{
		ShowTooltip(null);
		mTooltipTime = Time.unscaledTime + delay;
	}
}
