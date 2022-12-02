using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Item")]
public class UIDragDropItem : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum Restriction
	{
		None = 0,
		Horizontal = 1,
		Vertical = 2,
		PressAndHold = 3
	}

	[Tooltip("What kind of restriction is applied to the drag & drop logic before dragging is made possible.")]
	public Restriction restriction;

	[Tooltip("By default, dragging only happens while holding the mouse button / touch. If desired, you can opt to use a click-based approach instead. Note that this only works with a mouse.")]
	public bool clickToDrag;

	[Tooltip("Whether a copy of the item will be dragged instead of the item itself.")]
	public bool cloneOnDrag;

	[Tooltip("Whether this drag and drop item can be interacted with. If not, only tooltips will work.")]
	public bool interactable = true;

	[Tooltip("How long the user has to press on an item before the drag action activates.")]
	[HideInInspector]
	public float pressAndHoldDelay = 1f;

	[NonSerialized]
	protected Transform mTrans;

	[NonSerialized]
	protected Transform mParent;

	[NonSerialized]
	protected Collider mCollider;

	[NonSerialized]
	protected Collider2D mCollider2D;

	[NonSerialized]
	protected UIButton mButton;

	[NonSerialized]
	protected UIRoot mRoot;

	[NonSerialized]
	protected UIGrid mGrid;

	[NonSerialized]
	protected UITable mTable;

	[NonSerialized]
	protected float mDragStartTime;

	[NonSerialized]
	protected UIDragScrollView mDragScrollView;

	[NonSerialized]
	protected bool mPressed;

	[NonSerialized]
	protected bool mDragging;

	[NonSerialized]
	protected UICamera.MouseOrTouch mTouch;

	[NonSerialized]
	public static List<UIDragDropItem> draggedItems = new List<UIDragDropItem>();

	[NonSerialized]
	private static int mIgnoreClick = 0;

	public static bool IsDragged(GameObject go)
	{
		foreach (UIDragDropItem draggedItem in draggedItems)
		{
			if (draggedItem.gameObject == go)
			{
				return true;
			}
		}
		return false;
	}

	protected virtual void Awake()
	{
		mTrans = base.transform;
		mCollider = base.gameObject.GetComponent<Collider>();
		mCollider2D = base.gameObject.GetComponent<Collider2D>();
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
		if (mDragging)
		{
			StopDragging();
			UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(OnGlobalPress));
			UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(OnGlobalClick));
			UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(OnDrag));
		}
	}

	protected virtual void Start()
	{
		mButton = GetComponent<UIButton>();
		mDragScrollView = GetComponent<UIDragScrollView>();
	}

	protected virtual void OnPress(bool isPressed)
	{
		if (!interactable || UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		if (isPressed)
		{
			if (!mPressed)
			{
				mTouch = UICamera.currentTouch;
				mDragStartTime = RealTime.time + pressAndHoldDelay;
				mPressed = true;
			}
		}
		else if (mPressed && mTouch == UICamera.currentTouch)
		{
			mPressed = false;
			if (!mDragging || !clickToDrag)
			{
				mTouch = null;
			}
		}
	}

	protected virtual void OnClick()
	{
		if (mIgnoreClick != Time.frameCount && clickToDrag && !mDragging && UICamera.currentTouchID == -1 && draggedItems.Count == 0)
		{
			mTouch = UICamera.currentTouch;
			UIDragDropItem uIDragDropItem = StartDragging();
			if (clickToDrag && uIDragDropItem != null)
			{
				UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Combine(UICamera.onMouseMove, new UICamera.MoveDelegate(uIDragDropItem.OnDrag));
				UICamera.onPress = (UICamera.BoolDelegate)Delegate.Combine(UICamera.onPress, new UICamera.BoolDelegate(uIDragDropItem.OnGlobalPress));
				UICamera.onClick = (UICamera.VoidDelegate)Delegate.Combine(UICamera.onClick, new UICamera.VoidDelegate(uIDragDropItem.OnGlobalClick));
			}
		}
	}

	protected void OnGlobalPress(GameObject go, bool state)
	{
		if (state && UICamera.currentTouchID != -1)
		{
			mIgnoreClick = Time.frameCount;
			StopDragging();
			UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(OnGlobalPress));
			UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(OnGlobalClick));
			UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(OnDrag));
		}
	}

	protected void OnGlobalClick(GameObject go)
	{
		mIgnoreClick = Time.frameCount;
		if (UICamera.currentTouchID == -1)
		{
			StopDragging(go);
		}
		else
		{
			StopDragging();
		}
		UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(OnGlobalPress));
		UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(OnGlobalClick));
		UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(OnDrag));
	}

	protected virtual void Update()
	{
		if (restriction == Restriction.PressAndHold && mPressed && !mDragging && mDragStartTime < RealTime.time)
		{
			StartDragging();
		}
	}

	protected virtual void OnDragStart()
	{
		if (!interactable || !base.enabled || mTouch != UICamera.currentTouch)
		{
			return;
		}
		if (restriction != 0)
		{
			if (restriction == Restriction.Horizontal)
			{
				Vector2 totalDelta = mTouch.totalDelta;
				if (Mathf.Abs(totalDelta.x) < Mathf.Abs(totalDelta.y))
				{
					return;
				}
			}
			else if (restriction == Restriction.Vertical)
			{
				Vector2 totalDelta2 = mTouch.totalDelta;
				if (Mathf.Abs(totalDelta2.x) > Mathf.Abs(totalDelta2.y))
				{
					return;
				}
			}
			else if (restriction == Restriction.PressAndHold)
			{
				return;
			}
		}
		StartDragging();
	}

	public virtual UIDragDropItem StartDragging()
	{
		if (!interactable || !base.transform || !base.transform.parent)
		{
			return null;
		}
		if (!mDragging)
		{
			if (cloneOnDrag)
			{
				mPressed = false;
				GameObject gameObject = base.transform.parent.gameObject.AddChild(base.gameObject);
				gameObject.transform.localPosition = base.transform.localPosition;
				gameObject.transform.localRotation = base.transform.localRotation;
				gameObject.transform.localScale = base.transform.localScale;
				UIButtonColor component = gameObject.GetComponent<UIButtonColor>();
				if (component != null)
				{
					component.defaultColor = GetComponent<UIButtonColor>().defaultColor;
				}
				if (mTouch != null && mTouch.pressed == base.gameObject)
				{
					mTouch.current = gameObject;
					mTouch.pressed = gameObject;
					mTouch.dragged = gameObject;
					mTouch.last = gameObject;
				}
				UIDragDropItem component2 = gameObject.GetComponent<UIDragDropItem>();
				component2.mTouch = mTouch;
				component2.mPressed = true;
				component2.mDragging = true;
				component2.Start();
				component2.OnClone(base.gameObject);
				component2.OnDragDropStart();
				if (UICamera.currentTouch == null)
				{
					UICamera.currentTouch = mTouch;
				}
				mTouch = null;
				UICamera.Notify(base.gameObject, "OnPress", false);
				UICamera.Notify(base.gameObject, "OnHover", false);
				return component2;
			}
			mDragging = true;
			OnDragDropStart();
			return this;
		}
		return null;
	}

	protected virtual void OnClone(GameObject original)
	{
	}

	protected virtual void OnDrag(Vector2 delta)
	{
		if (interactable && mDragging && base.enabled && mTouch == UICamera.currentTouch)
		{
			if (mRoot != null)
			{
				OnDragDropMove(delta * mRoot.pixelSizeAdjustment);
			}
			else
			{
				OnDragDropMove(delta);
			}
		}
	}

	protected virtual void OnDragEnd()
	{
		if (interactable && base.enabled && mTouch == UICamera.currentTouch)
		{
			StopDragging((UICamera.lastHit.collider != null) ? UICamera.lastHit.collider.gameObject : null);
		}
	}

	public void StopDragging(GameObject go = null)
	{
		if (mDragging)
		{
			mDragging = false;
			OnDragDropRelease(go);
		}
	}

	protected virtual void OnDragDropStart()
	{
		if (!draggedItems.Contains(this))
		{
			draggedItems.Add(this);
		}
		if (mDragScrollView != null)
		{
			mDragScrollView.enabled = false;
		}
		if (mButton != null)
		{
			mButton.isEnabled = false;
		}
		else if (mCollider != null)
		{
			mCollider.enabled = false;
		}
		else if (mCollider2D != null)
		{
			mCollider2D.enabled = false;
		}
		mParent = mTrans.parent;
		mRoot = NGUITools.FindInParents<UIRoot>(mParent);
		mGrid = NGUITools.FindInParents<UIGrid>(mParent);
		mTable = NGUITools.FindInParents<UITable>(mParent);
		if (UIDragDropRoot.root != null)
		{
			mTrans.parent = UIDragDropRoot.root;
		}
		Vector3 localPosition = mTrans.localPosition;
		localPosition.z = 0f;
		mTrans.localPosition = localPosition;
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		SpringPosition component2 = GetComponent<SpringPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGUITools.MarkParentAsChanged(base.gameObject);
		if (mTable != null)
		{
			mTable.repositionNow = true;
		}
		if (mGrid != null)
		{
			mGrid.repositionNow = true;
		}
	}

	protected virtual void OnDragDropMove(Vector2 delta)
	{
		if (mParent != null)
		{
			mTrans.localPosition += mTrans.InverseTransformDirection(delta);
		}
	}

	protected virtual void OnDragDropRelease(GameObject surface)
	{
		if (!cloneOnDrag)
		{
			UIDragScrollView[] componentsInChildren = GetComponentsInChildren<UIDragScrollView>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].scrollView = null;
			}
			if (mButton != null)
			{
				mButton.isEnabled = true;
			}
			else if (mCollider != null)
			{
				mCollider.enabled = true;
			}
			else if (mCollider2D != null)
			{
				mCollider2D.enabled = true;
			}
			UIDragDropContainer uIDragDropContainer = (surface ? NGUITools.FindInParents<UIDragDropContainer>(surface) : null);
			if (uIDragDropContainer != null)
			{
				mTrans.parent = ((uIDragDropContainer.reparentTarget != null) ? uIDragDropContainer.reparentTarget : uIDragDropContainer.transform);
				Vector3 localPosition = mTrans.localPosition;
				localPosition.z = 0f;
				mTrans.localPosition = localPosition;
			}
			else
			{
				mTrans.parent = mParent;
			}
			mParent = mTrans.parent;
			mGrid = NGUITools.FindInParents<UIGrid>(mParent);
			mTable = NGUITools.FindInParents<UITable>(mParent);
			if (mDragScrollView != null)
			{
				Invoke("EnableDragScrollView", 0.001f);
			}
			NGUITools.MarkParentAsChanged(base.gameObject);
			if (mTable != null)
			{
				mTable.repositionNow = true;
			}
			if (mGrid != null)
			{
				mGrid.repositionNow = true;
			}
		}
		OnDragDropEnd(surface);
		if (cloneOnDrag)
		{
			DestroySelf();
		}
	}

	protected virtual void DestroySelf()
	{
		NGUITools.Destroy(base.gameObject);
	}

	protected virtual void OnDragDropEnd(GameObject surface)
	{
		draggedItems.Remove(this);
		mParent = null;
	}

	protected void EnableDragScrollView()
	{
		if (mDragScrollView != null)
		{
			mDragScrollView.enabled = true;
		}
	}

	protected void OnApplicationFocus(bool focus)
	{
		if (!focus)
		{
			StopDragging();
		}
	}
}
