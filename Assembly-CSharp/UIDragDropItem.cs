using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004F RID: 79
[AddComponentMenu("NGUI/Interaction/Drag and Drop Item")]
public class UIDragDropItem : MonoBehaviour
{
	// Token: 0x06000169 RID: 361 RVA: 0x00015528 File Offset: 0x00013728
	public static bool IsDragged(GameObject go)
	{
		using (List<UIDragDropItem>.Enumerator enumerator = UIDragDropItem.draggedItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.gameObject == go)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00015588 File Offset: 0x00013788
	protected virtual void Awake()
	{
		this.mTrans = base.transform;
		this.mCollider = base.gameObject.GetComponent<Collider>();
		this.mCollider2D = base.gameObject.GetComponent<Collider2D>();
	}

	// Token: 0x0600016B RID: 363 RVA: 0x000155B8 File Offset: 0x000137B8
	protected virtual void OnEnable()
	{
	}

	// Token: 0x0600016C RID: 364 RVA: 0x000155BC File Offset: 0x000137BC
	protected virtual void OnDisable()
	{
		if (this.mDragging)
		{
			this.StopDragging(null);
			UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(this.OnGlobalPress));
			UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(this.OnGlobalClick));
			UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(this.OnDrag));
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00015639 File Offset: 0x00013839
	protected virtual void Start()
	{
		this.mButton = base.GetComponent<UIButton>();
		this.mDragScrollView = base.GetComponent<UIDragScrollView>();
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00015654 File Offset: 0x00013854
	protected virtual void OnPress(bool isPressed)
	{
		if (!this.interactable || UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		if (isPressed)
		{
			if (!this.mPressed)
			{
				this.mTouch = UICamera.currentTouch;
				this.mDragStartTime = RealTime.time + this.pressAndHoldDelay;
				this.mPressed = true;
				return;
			}
		}
		else if (this.mPressed && this.mTouch == UICamera.currentTouch)
		{
			this.mPressed = false;
			if (!this.mDragging || !this.clickToDrag)
			{
				this.mTouch = null;
			}
		}
	}

	// Token: 0x0600016F RID: 367 RVA: 0x000156E0 File Offset: 0x000138E0
	protected virtual void OnClick()
	{
		if (UIDragDropItem.mIgnoreClick == Time.frameCount)
		{
			return;
		}
		if (this.clickToDrag && !this.mDragging && UICamera.currentTouchID == -1 && UIDragDropItem.draggedItems.Count == 0)
		{
			this.mTouch = UICamera.currentTouch;
			UIDragDropItem uidragDropItem = this.StartDragging();
			if (this.clickToDrag && uidragDropItem != null)
			{
				UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Combine(UICamera.onMouseMove, new UICamera.MoveDelegate(uidragDropItem.OnDrag));
				UICamera.onPress = (UICamera.BoolDelegate)Delegate.Combine(UICamera.onPress, new UICamera.BoolDelegate(uidragDropItem.OnGlobalPress));
				UICamera.onClick = (UICamera.VoidDelegate)Delegate.Combine(UICamera.onClick, new UICamera.VoidDelegate(uidragDropItem.OnGlobalClick));
			}
		}
	}

	// Token: 0x06000170 RID: 368 RVA: 0x000157B0 File Offset: 0x000139B0
	protected void OnGlobalPress(GameObject go, bool state)
	{
		if (state && UICamera.currentTouchID != -1)
		{
			UIDragDropItem.mIgnoreClick = Time.frameCount;
			this.StopDragging(null);
			UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(this.OnGlobalPress));
			UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(this.OnGlobalClick));
			UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(this.OnDrag));
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x0001583C File Offset: 0x00013A3C
	protected void OnGlobalClick(GameObject go)
	{
		UIDragDropItem.mIgnoreClick = Time.frameCount;
		if (UICamera.currentTouchID == -1)
		{
			this.StopDragging(go);
		}
		else
		{
			this.StopDragging(null);
		}
		UICamera.onPress = (UICamera.BoolDelegate)Delegate.Remove(UICamera.onPress, new UICamera.BoolDelegate(this.OnGlobalPress));
		UICamera.onClick = (UICamera.VoidDelegate)Delegate.Remove(UICamera.onClick, new UICamera.VoidDelegate(this.OnGlobalClick));
		UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(this.OnDrag));
	}

	// Token: 0x06000172 RID: 370 RVA: 0x000158CC File Offset: 0x00013ACC
	protected virtual void Update()
	{
		if (this.restriction == UIDragDropItem.Restriction.PressAndHold && this.mPressed && !this.mDragging && this.mDragStartTime < RealTime.time)
		{
			this.StartDragging();
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x000158FC File Offset: 0x00013AFC
	protected virtual void OnDragStart()
	{
		if (!this.interactable)
		{
			return;
		}
		if (!base.enabled || this.mTouch != UICamera.currentTouch)
		{
			return;
		}
		if (this.restriction != UIDragDropItem.Restriction.None)
		{
			if (this.restriction == UIDragDropItem.Restriction.Horizontal)
			{
				Vector2 totalDelta = this.mTouch.totalDelta;
				if (Mathf.Abs(totalDelta.x) < Mathf.Abs(totalDelta.y))
				{
					return;
				}
			}
			else if (this.restriction == UIDragDropItem.Restriction.Vertical)
			{
				Vector2 totalDelta2 = this.mTouch.totalDelta;
				if (Mathf.Abs(totalDelta2.x) > Mathf.Abs(totalDelta2.y))
				{
					return;
				}
			}
			else if (this.restriction == UIDragDropItem.Restriction.PressAndHold)
			{
				return;
			}
		}
		this.StartDragging();
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000159A0 File Offset: 0x00013BA0
	public virtual UIDragDropItem StartDragging()
	{
		if (!this.interactable || !base.transform || !base.transform.parent)
		{
			return null;
		}
		if (this.mDragging)
		{
			return null;
		}
		if (this.cloneOnDrag)
		{
			this.mPressed = false;
			GameObject gameObject = base.transform.parent.gameObject.AddChild(base.gameObject);
			gameObject.transform.localPosition = base.transform.localPosition;
			gameObject.transform.localRotation = base.transform.localRotation;
			gameObject.transform.localScale = base.transform.localScale;
			UIButtonColor component = gameObject.GetComponent<UIButtonColor>();
			if (component != null)
			{
				component.defaultColor = base.GetComponent<UIButtonColor>().defaultColor;
			}
			if (this.mTouch != null && this.mTouch.pressed == base.gameObject)
			{
				this.mTouch.current = gameObject;
				this.mTouch.pressed = gameObject;
				this.mTouch.dragged = gameObject;
				this.mTouch.last = gameObject;
			}
			UIDragDropItem component2 = gameObject.GetComponent<UIDragDropItem>();
			component2.mTouch = this.mTouch;
			component2.mPressed = true;
			component2.mDragging = true;
			component2.Start();
			component2.OnClone(base.gameObject);
			component2.OnDragDropStart();
			if (UICamera.currentTouch == null)
			{
				UICamera.currentTouch = this.mTouch;
			}
			this.mTouch = null;
			UICamera.Notify(base.gameObject, "OnPress", false);
			UICamera.Notify(base.gameObject, "OnHover", false);
			return component2;
		}
		this.mDragging = true;
		this.OnDragDropStart();
		return this;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00015B50 File Offset: 0x00013D50
	protected virtual void OnClone(GameObject original)
	{
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00015B54 File Offset: 0x00013D54
	protected virtual void OnDrag(Vector2 delta)
	{
		if (!this.interactable)
		{
			return;
		}
		if (!this.mDragging || !base.enabled || this.mTouch != UICamera.currentTouch)
		{
			return;
		}
		if (this.mRoot != null)
		{
			this.OnDragDropMove(delta * this.mRoot.pixelSizeAdjustment);
			return;
		}
		this.OnDragDropMove(delta);
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00015BB8 File Offset: 0x00013DB8
	protected virtual void OnDragEnd()
	{
		if (!this.interactable)
		{
			return;
		}
		if (!base.enabled || this.mTouch != UICamera.currentTouch)
		{
			return;
		}
		this.StopDragging((UICamera.lastHit.collider != null) ? UICamera.lastHit.collider.gameObject : null);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00015C0E File Offset: 0x00013E0E
	public void StopDragging(GameObject go = null)
	{
		if (this.mDragging)
		{
			this.mDragging = false;
			this.OnDragDropRelease(go);
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00015C28 File Offset: 0x00013E28
	protected virtual void OnDragDropStart()
	{
		if (!UIDragDropItem.draggedItems.Contains(this))
		{
			UIDragDropItem.draggedItems.Add(this);
		}
		if (this.mDragScrollView != null)
		{
			this.mDragScrollView.enabled = false;
		}
		if (this.mButton != null)
		{
			this.mButton.isEnabled = false;
		}
		else if (this.mCollider != null)
		{
			this.mCollider.enabled = false;
		}
		else if (this.mCollider2D != null)
		{
			this.mCollider2D.enabled = false;
		}
		this.mParent = this.mTrans.parent;
		this.mRoot = NGUITools.FindInParents<UIRoot>(this.mParent);
		this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
		this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
		if (UIDragDropRoot.root != null)
		{
			this.mTrans.parent = UIDragDropRoot.root;
		}
		Vector3 localPosition = this.mTrans.localPosition;
		localPosition.z = 0f;
		this.mTrans.localPosition = localPosition;
		TweenPosition component = base.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		SpringPosition component2 = base.GetComponent<SpringPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGUITools.MarkParentAsChanged(base.gameObject);
		if (this.mTable != null)
		{
			this.mTable.repositionNow = true;
		}
		if (this.mGrid != null)
		{
			this.mGrid.repositionNow = true;
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00015DAB File Offset: 0x00013FAB
	protected virtual void OnDragDropMove(Vector2 delta)
	{
		if (this.mParent != null)
		{
			this.mTrans.localPosition += this.mTrans.InverseTransformDirection(delta);
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00015DE4 File Offset: 0x00013FE4
	protected virtual void OnDragDropRelease(GameObject surface)
	{
		if (!this.cloneOnDrag)
		{
			UIDragScrollView[] componentsInChildren = base.GetComponentsInChildren<UIDragScrollView>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].scrollView = null;
			}
			if (this.mButton != null)
			{
				this.mButton.isEnabled = true;
			}
			else if (this.mCollider != null)
			{
				this.mCollider.enabled = true;
			}
			else if (this.mCollider2D != null)
			{
				this.mCollider2D.enabled = true;
			}
			UIDragDropContainer uidragDropContainer = surface ? NGUITools.FindInParents<UIDragDropContainer>(surface) : null;
			if (uidragDropContainer != null)
			{
				this.mTrans.parent = ((uidragDropContainer.reparentTarget != null) ? uidragDropContainer.reparentTarget : uidragDropContainer.transform);
				Vector3 localPosition = this.mTrans.localPosition;
				localPosition.z = 0f;
				this.mTrans.localPosition = localPosition;
			}
			else
			{
				this.mTrans.parent = this.mParent;
			}
			this.mParent = this.mTrans.parent;
			this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
			this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
			if (this.mDragScrollView != null)
			{
				base.Invoke("EnableDragScrollView", 0.001f);
			}
			NGUITools.MarkParentAsChanged(base.gameObject);
			if (this.mTable != null)
			{
				this.mTable.repositionNow = true;
			}
			if (this.mGrid != null)
			{
				this.mGrid.repositionNow = true;
			}
		}
		this.OnDragDropEnd(surface);
		if (this.cloneOnDrag)
		{
			this.DestroySelf();
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00015F8A File Offset: 0x0001418A
	protected virtual void DestroySelf()
	{
		NGUITools.Destroy(base.gameObject);
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00015F97 File Offset: 0x00014197
	protected virtual void OnDragDropEnd(GameObject surface)
	{
		UIDragDropItem.draggedItems.Remove(this);
		this.mParent = null;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00015FAC File Offset: 0x000141AC
	protected void EnableDragScrollView()
	{
		if (this.mDragScrollView != null)
		{
			this.mDragScrollView.enabled = true;
		}
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00015FC8 File Offset: 0x000141C8
	protected void OnApplicationFocus(bool focus)
	{
		if (!focus)
		{
			this.StopDragging(null);
		}
	}

	// Token: 0x04000326 RID: 806
	[Tooltip("What kind of restriction is applied to the drag & drop logic before dragging is made possible.")]
	public UIDragDropItem.Restriction restriction;

	// Token: 0x04000327 RID: 807
	[Tooltip("By default, dragging only happens while holding the mouse button / touch. If desired, you can opt to use a click-based approach instead. Note that this only works with a mouse.")]
	public bool clickToDrag;

	// Token: 0x04000328 RID: 808
	[Tooltip("Whether a copy of the item will be dragged instead of the item itself.")]
	public bool cloneOnDrag;

	// Token: 0x04000329 RID: 809
	[Tooltip("Whether this drag and drop item can be interacted with. If not, only tooltips will work.")]
	public bool interactable = true;

	// Token: 0x0400032A RID: 810
	[Tooltip("How long the user has to press on an item before the drag action activates.")]
	[HideInInspector]
	public float pressAndHoldDelay = 1f;

	// Token: 0x0400032B RID: 811
	[NonSerialized]
	protected Transform mTrans;

	// Token: 0x0400032C RID: 812
	[NonSerialized]
	protected Transform mParent;

	// Token: 0x0400032D RID: 813
	[NonSerialized]
	protected Collider mCollider;

	// Token: 0x0400032E RID: 814
	[NonSerialized]
	protected Collider2D mCollider2D;

	// Token: 0x0400032F RID: 815
	[NonSerialized]
	protected UIButton mButton;

	// Token: 0x04000330 RID: 816
	[NonSerialized]
	protected UIRoot mRoot;

	// Token: 0x04000331 RID: 817
	[NonSerialized]
	protected UIGrid mGrid;

	// Token: 0x04000332 RID: 818
	[NonSerialized]
	protected UITable mTable;

	// Token: 0x04000333 RID: 819
	[NonSerialized]
	protected float mDragStartTime;

	// Token: 0x04000334 RID: 820
	[NonSerialized]
	protected UIDragScrollView mDragScrollView;

	// Token: 0x04000335 RID: 821
	[NonSerialized]
	protected bool mPressed;

	// Token: 0x04000336 RID: 822
	[NonSerialized]
	protected bool mDragging;

	// Token: 0x04000337 RID: 823
	[NonSerialized]
	protected UICamera.MouseOrTouch mTouch;

	// Token: 0x04000338 RID: 824
	[NonSerialized]
	public static List<UIDragDropItem> draggedItems = new List<UIDragDropItem>();

	// Token: 0x04000339 RID: 825
	[NonSerialized]
	private static int mIgnoreClick = 0;

	// Token: 0x020005C8 RID: 1480
	[DoNotObfuscateNGUI]
	public enum Restriction
	{
		// Token: 0x04004D46 RID: 19782
		None,
		// Token: 0x04004D47 RID: 19783
		Horizontal,
		// Token: 0x04004D48 RID: 19784
		Vertical,
		// Token: 0x04004D49 RID: 19785
		PressAndHold
	}
}
