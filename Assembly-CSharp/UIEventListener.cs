using UnityEngine;

[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
	public delegate void VoidDelegate(GameObject go);

	public delegate void BoolDelegate(GameObject go, bool state);

	public delegate void FloatDelegate(GameObject go, float delta);

	public delegate void VectorDelegate(GameObject go, Vector2 delta);

	public delegate void ObjectDelegate(GameObject go, GameObject obj);

	public delegate void KeyCodeDelegate(GameObject go, KeyCode key);

	public object parameter;

	public VoidDelegate onSubmit;

	public VoidDelegate onClick;

	public VoidDelegate onDoubleClick;

	public BoolDelegate onHover;

	public BoolDelegate onPress;

	public BoolDelegate onSelect;

	public FloatDelegate onScroll;

	public VoidDelegate onDragStart;

	public VectorDelegate onDrag;

	public VoidDelegate onDragOver;

	public VoidDelegate onDragOut;

	public VoidDelegate onDragEnd;

	public ObjectDelegate onDrop;

	public KeyCodeDelegate onKey;

	public BoolDelegate onTooltip;

	public bool needsActiveCollider = true;

	private bool isColliderEnabled
	{
		get
		{
			if (!needsActiveCollider)
			{
				return true;
			}
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = GetComponent<Collider2D>();
			if (component2 != null)
			{
				return component2.enabled;
			}
			return false;
		}
	}

	private void OnSubmit()
	{
		if (isColliderEnabled && onSubmit != null)
		{
			onSubmit(base.gameObject);
		}
	}

	private void OnClick()
	{
		if (isColliderEnabled && onClick != null)
		{
			onClick(base.gameObject);
		}
	}

	private void OnDoubleClick()
	{
		if (isColliderEnabled && onDoubleClick != null)
		{
			onDoubleClick(base.gameObject);
		}
	}

	private void OnHover(bool isOver)
	{
		if (isColliderEnabled && onHover != null)
		{
			onHover(base.gameObject, isOver);
		}
	}

	private void OnPress(bool isPressed)
	{
		if (isColliderEnabled && onPress != null)
		{
			onPress(base.gameObject, isPressed);
		}
	}

	private void OnSelect(bool selected)
	{
		if (isColliderEnabled && onSelect != null)
		{
			onSelect(base.gameObject, selected);
		}
	}

	private void OnScroll(float delta)
	{
		if (isColliderEnabled && onScroll != null)
		{
			onScroll(base.gameObject, delta);
		}
	}

	private void OnDragStart()
	{
		if (onDragStart != null)
		{
			onDragStart(base.gameObject);
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (onDrag != null)
		{
			onDrag(base.gameObject, delta);
		}
	}

	private void OnDragOver()
	{
		if (isColliderEnabled && onDragOver != null)
		{
			onDragOver(base.gameObject);
		}
	}

	private void OnDragOut()
	{
		if (isColliderEnabled && onDragOut != null)
		{
			onDragOut(base.gameObject);
		}
	}

	private void OnDragEnd()
	{
		if (onDragEnd != null)
		{
			onDragEnd(base.gameObject);
		}
	}

	private void OnDrop(GameObject go)
	{
		if (isColliderEnabled && onDrop != null)
		{
			onDrop(base.gameObject, go);
		}
	}

	private void OnKey(KeyCode key)
	{
		if (isColliderEnabled && onKey != null)
		{
			onKey(base.gameObject, key);
		}
	}

	private void OnTooltip(bool show)
	{
		if (isColliderEnabled && onTooltip != null)
		{
			onTooltip(base.gameObject, show);
		}
	}

	public void Clear()
	{
		onSubmit = null;
		onClick = null;
		onDoubleClick = null;
		onHover = null;
		onPress = null;
		onSelect = null;
		onScroll = null;
		onDragStart = null;
		onDrag = null;
		onDragOver = null;
		onDragOut = null;
		onDragEnd = null;
		onDrop = null;
		onKey = null;
		onTooltip = null;
	}

	public static UIEventListener Get(GameObject go)
	{
		UIEventListener uIEventListener = go.GetComponent<UIEventListener>();
		if (uIEventListener == null)
		{
			uIEventListener = go.AddComponent<UIEventListener>();
		}
		return uIEventListener;
	}
}
