using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Scroll View")]
public class UIScrollView : MonoBehaviour
{
	// Token: 0x17000036 RID: 54
	// (get) Token: 0x0600028D RID: 653 RVA: 0x0001C28F File Offset: 0x0001A48F
	public UIPanel panel
	{
		get
		{
			return this.mPanel;
		}
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x0600028E RID: 654 RVA: 0x0001C297 File Offset: 0x0001A497
	public bool isDragging
	{
		get
		{
			return this.mPressed && this.mDragStarted;
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x0600028F RID: 655 RVA: 0x0001C2A9 File Offset: 0x0001A4A9
	public virtual Bounds bounds
	{
		get
		{
			if (!this.mCalculatedBounds)
			{
				this.mCalculatedBounds = true;
				this.mTrans = base.transform;
				this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mTrans, this.mTrans);
			}
			return this.mBounds;
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x06000290 RID: 656 RVA: 0x0001C2E3 File Offset: 0x0001A4E3
	public bool canMoveHorizontally
	{
		get
		{
			return this.movement == UIScrollView.Movement.Horizontal || this.movement == UIScrollView.Movement.Unrestricted || (this.movement == UIScrollView.Movement.Custom && this.customMovement.x != 0f);
		}
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x06000291 RID: 657 RVA: 0x0001C318 File Offset: 0x0001A518
	public bool canMoveVertically
	{
		get
		{
			return this.movement == UIScrollView.Movement.Vertical || this.movement == UIScrollView.Movement.Unrestricted || (this.movement == UIScrollView.Movement.Custom && this.customMovement.y != 0f);
		}
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000292 RID: 658 RVA: 0x0001C350 File Offset: 0x0001A550
	public virtual bool shouldMoveHorizontally
	{
		get
		{
			float num = this.bounds.size.x;
			if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.x * 2f;
			}
			return Mathf.RoundToInt(num - this.mPanel.width) > 0;
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000293 RID: 659 RVA: 0x0001C3B0 File Offset: 0x0001A5B0
	public virtual bool shouldMoveVertically
	{
		get
		{
			float num = this.bounds.size.y;
			if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.y * 2f;
			}
			return Mathf.RoundToInt(num - this.mPanel.height) > 0;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000294 RID: 660 RVA: 0x0001C410 File Offset: 0x0001A610
	protected virtual bool shouldMove
	{
		get
		{
			if (!this.disableDragIfFits)
			{
				return true;
			}
			if (this.mPanel == null)
			{
				this.mPanel = base.GetComponent<UIPanel>();
			}
			Vector4 finalClipRegion = this.mPanel.finalClipRegion;
			Bounds bounds = this.bounds;
			float num = (finalClipRegion.z == 0f) ? ((float)Screen.width) : (finalClipRegion.z * 0.5f);
			float num2 = (finalClipRegion.w == 0f) ? ((float)Screen.height) : (finalClipRegion.w * 0.5f);
			if (this.canMoveHorizontally)
			{
				if (bounds.min.x + 0.001f < finalClipRegion.x - num)
				{
					return true;
				}
				if (bounds.max.x - 0.001f > finalClipRegion.x + num)
				{
					return true;
				}
			}
			if (this.canMoveVertically)
			{
				if (bounds.min.y + 0.001f < finalClipRegion.y - num2)
				{
					return true;
				}
				if (bounds.max.y - 0.001f > finalClipRegion.y + num2)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x06000295 RID: 661 RVA: 0x0001C521 File Offset: 0x0001A721
	// (set) Token: 0x06000296 RID: 662 RVA: 0x0001C529 File Offset: 0x0001A729
	public Vector3 currentMomentum
	{
		get
		{
			return this.mMomentum;
		}
		set
		{
			this.mMomentum = value;
			this.mShouldMove = true;
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0001C53C File Offset: 0x0001A73C
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mPanel = base.GetComponent<UIPanel>();
		if (this.mPanel.clipping == UIDrawCall.Clipping.None)
		{
			this.mPanel.clipping = UIDrawCall.Clipping.ConstrainButDontClip;
		}
		if (this.movement != UIScrollView.Movement.Custom && this.scale.sqrMagnitude > 0.001f)
		{
			if (this.scale.x == 1f && this.scale.y == 0f)
			{
				this.movement = UIScrollView.Movement.Horizontal;
			}
			else if (this.scale.x == 0f && this.scale.y == 1f)
			{
				this.movement = UIScrollView.Movement.Vertical;
			}
			else if (this.scale.x == 1f && this.scale.y == 1f)
			{
				this.movement = UIScrollView.Movement.Unrestricted;
			}
			else
			{
				this.movement = UIScrollView.Movement.Custom;
				this.customMovement.x = this.scale.x;
				this.customMovement.y = this.scale.y;
			}
			this.scale = Vector3.zero;
		}
		if (this.contentPivot == UIWidget.Pivot.TopLeft && this.relativePositionOnReset != Vector2.zero)
		{
			this.contentPivot = NGUIMath.GetPivot(new Vector2(this.relativePositionOnReset.x, 1f - this.relativePositionOnReset.y));
			this.relativePositionOnReset = Vector2.zero;
		}
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0001C6B4 File Offset: 0x0001A8B4
	private void OnEnable()
	{
		UIScrollView.list.Add(this);
		if (this.mStarted && Application.isPlaying)
		{
			this.CheckScrollbars();
		}
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0001C6D6 File Offset: 0x0001A8D6
	private void Start()
	{
		this.mStarted = true;
		if (Application.isPlaying)
		{
			this.CheckScrollbars();
		}
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0001C6EC File Offset: 0x0001A8EC
	private void CheckScrollbars()
	{
		if (this.horizontalScrollBar != null)
		{
			EventDelegate.Add(this.horizontalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
			this.horizontalScrollBar.BroadcastMessage("CacheDefaultColor", SendMessageOptions.DontRequireReceiver);
			this.horizontalScrollBar.alpha = ((this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveHorizontally) ? 1f : 0f);
		}
		if (this.verticalScrollBar != null)
		{
			EventDelegate.Add(this.verticalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
			this.verticalScrollBar.BroadcastMessage("CacheDefaultColor", SendMessageOptions.DontRequireReceiver);
			this.verticalScrollBar.alpha = ((this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveVertically) ? 1f : 0f);
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x0001C7BF File Offset: 0x0001A9BF
	private void OnDisable()
	{
		UIScrollView.list.Remove(this);
		this.mPressed = false;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0001C7D4 File Offset: 0x0001A9D4
	public bool RestrictWithinBounds(bool instant)
	{
		return this.RestrictWithinBounds(instant, true, true);
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0001C7E0 File Offset: 0x0001A9E0
	public bool RestrictWithinBounds(bool instant, bool horizontal, bool vertical)
	{
		if (this.mPanel == null)
		{
			return false;
		}
		Bounds bounds = this.bounds;
		Vector3 vector = this.mPanel.CalculateConstrainOffset(bounds.min, bounds.max);
		if (!horizontal)
		{
			vector.x = 0f;
		}
		if (!vertical)
		{
			vector.y = 0f;
		}
		if (vector.sqrMagnitude > 0.1f)
		{
			if (!instant && this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
			{
				Vector3 vector2 = this.mTrans.localPosition + vector;
				vector2.x = Mathf.Round(vector2.x);
				vector2.y = Mathf.Round(vector2.y);
				SpringPanel.Begin(this.mPanel.gameObject, vector2, 8f);
			}
			else
			{
				this.MoveRelative(vector);
				if (Mathf.Abs(vector.x) > 0.01f)
				{
					this.mMomentum.x = 0f;
				}
				if (Mathf.Abs(vector.y) > 0.01f)
				{
					this.mMomentum.y = 0f;
				}
				if (Mathf.Abs(vector.z) > 0.01f)
				{
					this.mMomentum.z = 0f;
				}
				this.mScroll = 0f;
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0001C930 File Offset: 0x0001AB30
	public void DisableSpring()
	{
		SpringPanel component = base.GetComponent<SpringPanel>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0001C954 File Offset: 0x0001AB54
	public void UpdateScrollbars()
	{
		this.UpdateScrollbars(true);
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0001C960 File Offset: 0x0001AB60
	public virtual void UpdateScrollbars(bool recalculateBounds)
	{
		if (this.mPanel == null)
		{
			return;
		}
		if (this.horizontalScrollBar != null || this.verticalScrollBar != null)
		{
			if (recalculateBounds)
			{
				this.mCalculatedBounds = false;
				this.mShouldMove = this.shouldMove;
			}
			Bounds bounds = this.bounds;
			Vector2 vector = bounds.min;
			Vector2 vector2 = bounds.max;
			if (this.horizontalScrollBar != null && vector2.x > vector.x)
			{
				Vector4 finalClipRegion = this.mPanel.finalClipRegion;
				int num = Mathf.RoundToInt(finalClipRegion.z);
				if ((num & 1) != 0)
				{
					num--;
				}
				float num2 = (float)num * 0.5f;
				num2 = Mathf.Round(num2);
				if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
				{
					num2 -= this.mPanel.clipSoftness.x;
				}
				float contentSize = vector2.x - vector.x;
				float viewSize = num2 * 2f;
				float num3 = vector.x;
				float num4 = vector2.x;
				float num5 = finalClipRegion.x - num2;
				float num6 = finalClipRegion.x + num2;
				num3 = num5 - num3;
				num4 -= num6;
				this.UpdateScrollbars(this.horizontalScrollBar, num3, num4, contentSize, viewSize, false);
			}
			if (this.verticalScrollBar != null && vector2.y > vector.y)
			{
				Vector4 finalClipRegion2 = this.mPanel.finalClipRegion;
				int num7 = Mathf.RoundToInt(finalClipRegion2.w);
				if ((num7 & 1) != 0)
				{
					num7--;
				}
				float num8 = (float)num7 * 0.5f;
				num8 = Mathf.Round(num8);
				if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
				{
					num8 -= this.mPanel.clipSoftness.y;
				}
				float contentSize2 = vector2.y - vector.y;
				float viewSize2 = num8 * 2f;
				float num9 = vector.y;
				float num10 = vector2.y;
				float num11 = finalClipRegion2.y - num8;
				float num12 = finalClipRegion2.y + num8;
				num9 = num11 - num9;
				num10 -= num12;
				this.UpdateScrollbars(this.verticalScrollBar, num9, num10, contentSize2, viewSize2, true);
				return;
			}
		}
		else if (recalculateBounds)
		{
			this.mCalculatedBounds = false;
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x0001CB94 File Offset: 0x0001AD94
	protected void UpdateScrollbars(UIProgressBar slider, float contentMin, float contentMax, float contentSize, float viewSize, bool inverted)
	{
		if (slider == null)
		{
			return;
		}
		this.mIgnoreCallbacks = true;
		float num;
		if (viewSize < contentSize)
		{
			contentMin = Mathf.Clamp01(contentMin / contentSize);
			contentMax = Mathf.Clamp01(contentMax / contentSize);
			num = contentMin + contentMax;
			slider.value = (inverted ? ((num > 0.001f) ? (1f - contentMin / num) : 0f) : ((num > 0.001f) ? (contentMin / num) : 1f));
		}
		else
		{
			contentMin = Mathf.Clamp01(-contentMin / contentSize);
			contentMax = Mathf.Clamp01(-contentMax / contentSize);
			num = contentMin + contentMax;
			slider.value = (inverted ? ((num > 0.001f) ? (1f - contentMin / num) : 0f) : ((num > 0.001f) ? (contentMin / num) : 1f));
			if (contentSize > 0f)
			{
				contentMin = Mathf.Clamp01(contentMin / contentSize);
				contentMax = Mathf.Clamp01(contentMax / contentSize);
				num = contentMin + contentMax;
			}
		}
		UIScrollBar uiscrollBar = slider as UIScrollBar;
		if (uiscrollBar != null)
		{
			uiscrollBar.barSize = 1f - num;
		}
		this.mIgnoreCallbacks = false;
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
	public virtual void SetDragAmount(float x, float y, bool updateScrollbars)
	{
		if (this.mPanel == null)
		{
			this.mPanel = base.GetComponent<UIPanel>();
		}
		this.DisableSpring();
		Bounds bounds = this.bounds;
		if (bounds.min.x == bounds.max.x || bounds.min.y == bounds.max.y)
		{
			return;
		}
		Vector4 finalClipRegion = this.mPanel.finalClipRegion;
		float num = finalClipRegion.z * 0.5f;
		float num2 = finalClipRegion.w * 0.5f;
		float num3 = bounds.min.x + num;
		float num4 = bounds.max.x - num;
		float num5 = bounds.min.y + num2;
		float num6 = bounds.max.y - num2;
		if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
		{
			num3 -= this.mPanel.clipSoftness.x;
			num4 += this.mPanel.clipSoftness.x;
			num5 -= this.mPanel.clipSoftness.y;
			num6 += this.mPanel.clipSoftness.y;
		}
		float num7 = Mathf.Lerp(num3, num4, x);
		float num8 = Mathf.Lerp(num6, num5, y);
		if (!updateScrollbars)
		{
			Vector3 localPosition = this.mTrans.localPosition;
			if (this.canMoveHorizontally)
			{
				localPosition.x += finalClipRegion.x - num7;
			}
			if (this.canMoveVertically)
			{
				localPosition.y += finalClipRegion.y - num8;
			}
			this.mTrans.localPosition = localPosition;
		}
		if (this.canMoveHorizontally)
		{
			finalClipRegion.x = num7;
		}
		if (this.canMoveVertically)
		{
			finalClipRegion.y = num8;
		}
		Vector4 baseClipRegion = this.mPanel.baseClipRegion;
		this.mPanel.clipOffset = new Vector2(finalClipRegion.x - baseClipRegion.x, finalClipRegion.y - baseClipRegion.y);
		if (updateScrollbars)
		{
			this.UpdateScrollbars(this.mDragID == -10);
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x0001CEB0 File Offset: 0x0001B0B0
	public void InvalidateBounds()
	{
		this.mCalculatedBounds = false;
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x0001CEBC File Offset: 0x0001B0BC
	[ContextMenu("Reset Clipping Position")]
	public void ResetPosition()
	{
		if (NGUITools.GetActive(this))
		{
			this.mCalculatedBounds = false;
			Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
			this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, false);
			this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, true);
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x0001CF18 File Offset: 0x0001B118
	public void UpdatePosition()
	{
		if (!this.mIgnoreCallbacks && (this.horizontalScrollBar != null || this.verticalScrollBar != null))
		{
			this.mIgnoreCallbacks = true;
			this.mCalculatedBounds = false;
			Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
			float x = (this.horizontalScrollBar != null) ? this.horizontalScrollBar.value : pivotOffset.x;
			float y = (this.verticalScrollBar != null) ? this.verticalScrollBar.value : (1f - pivotOffset.y);
			this.SetDragAmount(x, y, false);
			this.UpdateScrollbars(true);
			this.mIgnoreCallbacks = false;
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x0001CFC8 File Offset: 0x0001B1C8
	public void OnScrollBar()
	{
		if (!this.mIgnoreCallbacks)
		{
			this.mIgnoreCallbacks = true;
			float x = (this.horizontalScrollBar != null) ? this.horizontalScrollBar.value : 0f;
			float y = (this.verticalScrollBar != null) ? this.verticalScrollBar.value : 0f;
			this.SetDragAmount(x, y, false);
			this.mIgnoreCallbacks = false;
		}
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x0001D038 File Offset: 0x0001B238
	public virtual void MoveRelative(Vector3 relative)
	{
		this.mTrans.localPosition += relative;
		Vector2 clipOffset = this.mPanel.clipOffset;
		clipOffset.x -= relative.x;
		clipOffset.y -= relative.y;
		this.mPanel.clipOffset = clipOffset;
		this.UpdateScrollbars(false);
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0001D0A0 File Offset: 0x0001B2A0
	public void MoveAbsolute(Vector3 absolute)
	{
		Vector3 a = this.mTrans.InverseTransformPoint(absolute);
		Vector3 b = this.mTrans.InverseTransformPoint(Vector3.zero);
		this.MoveRelative(a - b);
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x0001D0D8 File Offset: 0x0001B2D8
	public void Press(bool pressed)
	{
		if (this.mPressed == pressed || UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		if (this.smoothDragStart && pressed)
		{
			this.mDragStarted = false;
			this.mDragStartOffset = Vector2.zero;
		}
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (!pressed && this.mDragID == UICamera.currentTouchID)
			{
				this.mDragID = -10;
			}
			this.mCalculatedBounds = false;
			this.mShouldMove = this.shouldMove;
			if (!this.mShouldMove)
			{
				return;
			}
			this.mPressed = pressed;
			if (pressed)
			{
				this.mMomentum = Vector3.zero;
				this.mScroll = 0f;
				this.DisableSpring();
				this.mLastPos = UICamera.lastWorldPosition;
				this.mPlane = new Plane(this.mTrans.rotation * Vector3.back, this.mLastPos);
				Vector2 clipOffset = this.mPanel.clipOffset;
				clipOffset.x = Mathf.Round(clipOffset.x);
				clipOffset.y = Mathf.Round(clipOffset.y);
				this.mPanel.clipOffset = clipOffset;
				Vector3 localPosition = this.mTrans.localPosition;
				localPosition.x = Mathf.Round(localPosition.x);
				localPosition.y = Mathf.Round(localPosition.y);
				this.mTrans.localPosition = localPosition;
				if (!this.smoothDragStart)
				{
					this.mDragStarted = true;
					this.mDragStartOffset = Vector2.zero;
					if (this.onDragStarted != null)
					{
						this.onDragStarted();
						return;
					}
				}
			}
			else
			{
				if (this.centerOnChild)
				{
					if (this.mDragStarted && this.onDragFinished != null)
					{
						this.onDragFinished();
					}
					this.centerOnChild.Recenter();
					return;
				}
				if (this.mDragStarted && this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
				{
					this.RestrictWithinBounds(this.dragEffect == UIScrollView.DragEffect.None, this.canMoveHorizontally, this.canMoveVertically);
				}
				if (this.mDragStarted && this.onDragFinished != null)
				{
					this.onDragFinished();
				}
				if (!this.mShouldMove && this.onStoppedMoving != null)
				{
					this.onStoppedMoving();
				}
			}
		}
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0001D30C File Offset: 0x0001B50C
	public void Drag()
	{
		if (!this.mPressed || UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.mShouldMove)
		{
			if (this.mDragID == -10)
			{
				this.mDragID = UICamera.currentTouchID;
			}
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			if (this.smoothDragStart && !this.mDragStarted)
			{
				this.mDragStarted = true;
				this.mDragStartOffset = UICamera.currentTouch.totalDelta;
				if (this.onDragStarted != null)
				{
					this.onDragStarted();
				}
			}
			Ray ray = this.smoothDragStart ? UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos - this.mDragStartOffset) : UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float distance = 0f;
			if (this.mPlane.Raycast(ray, out distance))
			{
				Vector3 point = ray.GetPoint(distance);
				Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (vector.x != 0f || vector.y != 0f || vector.z != 0f)
				{
					vector = this.mTrans.InverseTransformDirection(vector);
					if (this.movement == UIScrollView.Movement.Horizontal)
					{
						vector.y = 0f;
						vector.z = 0f;
					}
					else if (this.movement == UIScrollView.Movement.Vertical)
					{
						vector.x = 0f;
						vector.z = 0f;
					}
					else if (this.movement == UIScrollView.Movement.Unrestricted)
					{
						vector.z = 0f;
					}
					else
					{
						vector.Scale(this.customMovement);
					}
					vector = this.mTrans.TransformDirection(vector);
				}
				if (this.dragEffect == UIScrollView.DragEffect.None)
				{
					this.mMomentum = Vector3.zero;
				}
				else
				{
					this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				}
				if (!this.iOSDragEmulation || this.dragEffect != UIScrollView.DragEffect.MomentumAndSpring)
				{
					this.MoveAbsolute(vector);
				}
				else
				{
					Vector3 vector2 = this.mPanel.CalculateConstrainOffset(this.bounds.min, this.bounds.max);
					if (this.movement == UIScrollView.Movement.Horizontal)
					{
						vector2.y = 0f;
					}
					else if (this.movement == UIScrollView.Movement.Vertical)
					{
						vector2.x = 0f;
					}
					else if (this.movement == UIScrollView.Movement.Custom)
					{
						vector2.x *= this.customMovement.x;
						vector2.y *= this.customMovement.y;
					}
					if (vector2.magnitude > 1f)
					{
						this.MoveAbsolute(vector * 0.5f);
						this.mMomentum *= 0.5f;
					}
					else
					{
						this.MoveAbsolute(vector);
					}
				}
				if (this.constrainOnDrag && this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None && this.dragEffect != UIScrollView.DragEffect.MomentumAndSpring)
				{
					this.RestrictWithinBounds(true, this.canMoveHorizontally, this.canMoveVertically);
				}
			}
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0001D650 File Offset: 0x0001B850
	public void Scroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.scrollWheelFactor != 0f)
		{
			this.DisableSpring();
			this.mShouldMove |= this.shouldMove;
			if (Mathf.Sign(this.mScroll) != Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0001D6CC File Offset: 0x0001B8CC
	private void LateUpdate()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		float deltaTime = RealTime.deltaTime;
		if (this.showScrollBars != UIScrollView.ShowCondition.Always && (this.verticalScrollBar || this.horizontalScrollBar))
		{
			bool flag = false;
			bool flag2 = false;
			if (this.showScrollBars != UIScrollView.ShowCondition.WhenDragging || this.mDragID != -10 || this.mMomentum.magnitude > 0.01f)
			{
				flag = this.shouldMoveVertically;
				flag2 = this.shouldMoveHorizontally;
			}
			if (this.verticalScrollBar)
			{
				float num = this.verticalScrollBar.alpha;
				num += (flag ? (deltaTime * 6f) : (-deltaTime * 3f));
				num = Mathf.Clamp01(num);
				if (this.verticalScrollBar.alpha != num)
				{
					this.verticalScrollBar.alpha = num;
				}
			}
			if (this.horizontalScrollBar)
			{
				float num2 = this.horizontalScrollBar.alpha;
				num2 += (flag2 ? (deltaTime * 6f) : (-deltaTime * 3f));
				num2 = Mathf.Clamp01(num2);
				if (this.horizontalScrollBar.alpha != num2)
				{
					this.horizontalScrollBar.alpha = num2;
				}
			}
		}
		if (!this.mShouldMove)
		{
			return;
		}
		if (!this.mPressed)
		{
			if (this.mMomentum.magnitude > 0.0001f || Mathf.Abs(this.mScroll) > 0.0001f)
			{
				if (this.movement == UIScrollView.Movement.Horizontal)
				{
					this.mMomentum -= this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, 0f, 0f));
				}
				else if (this.movement == UIScrollView.Movement.Vertical)
				{
					this.mMomentum -= this.mTrans.TransformDirection(new Vector3(0f, this.mScroll * 0.05f, 0f));
				}
				else if (this.movement == UIScrollView.Movement.Unrestricted)
				{
					this.mMomentum -= this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, this.mScroll * 0.05f, 0f));
				}
				else
				{
					this.mMomentum -= this.mTrans.TransformDirection(new Vector3(this.mScroll * this.customMovement.x * 0.05f, this.mScroll * this.customMovement.y * 0.05f, 0f));
				}
				this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
				Vector3 absolute = NGUIMath.SpringDampen(ref this.mMomentum, this.dampenStrength, deltaTime);
				this.MoveAbsolute(absolute);
				if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
				{
					if (NGUITools.GetActive(this.centerOnChild))
					{
						if (this.centerOnChild.nextPageThreshold != 0f)
						{
							this.mMomentum = Vector3.zero;
							this.mScroll = 0f;
						}
						else
						{
							this.centerOnChild.Recenter();
						}
					}
					else
					{
						this.RestrictWithinBounds(false, this.canMoveHorizontally, this.canMoveVertically);
					}
				}
				if (this.onMomentumMove != null)
				{
					this.onMomentumMove();
					return;
				}
			}
			else
			{
				this.mScroll = 0f;
				this.mMomentum = Vector3.zero;
				SpringPanel component = base.GetComponent<SpringPanel>();
				if (component != null && component.enabled)
				{
					return;
				}
				this.mShouldMove = false;
				if (this.onStoppedMoving != null)
				{
					this.onStoppedMoving();
					return;
				}
			}
		}
		else
		{
			this.mScroll = 0f;
			NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
		}
	}

	// Token: 0x060002AD RID: 685 RVA: 0x0001DA78 File Offset: 0x0001BC78
	public void OnPan(Vector2 delta)
	{
		if (this.horizontalScrollBar != null)
		{
			this.horizontalScrollBar.OnPan(delta);
		}
		if (this.verticalScrollBar != null)
		{
			this.verticalScrollBar.OnPan(delta);
		}
		if (this.horizontalScrollBar == null && this.verticalScrollBar == null)
		{
			if (this.canMoveHorizontally)
			{
				this.Scroll(delta.x);
				return;
			}
			if (this.canMoveVertically)
			{
				this.Scroll(delta.y);
			}
		}
	}

	// Token: 0x04000410 RID: 1040
	public static BetterList<UIScrollView> list = new BetterList<UIScrollView>();

	// Token: 0x04000411 RID: 1041
	public UIScrollView.Movement movement;

	// Token: 0x04000412 RID: 1042
	public UIScrollView.DragEffect dragEffect = UIScrollView.DragEffect.MomentumAndSpring;

	// Token: 0x04000413 RID: 1043
	public bool restrictWithinPanel = true;

	// Token: 0x04000414 RID: 1044
	[Tooltip("Whether the scroll view will execute its constrain within bounds logic on every drag operation")]
	public bool constrainOnDrag;

	// Token: 0x04000415 RID: 1045
	public bool disableDragIfFits;

	// Token: 0x04000416 RID: 1046
	public bool smoothDragStart = true;

	// Token: 0x04000417 RID: 1047
	public bool iOSDragEmulation = true;

	// Token: 0x04000418 RID: 1048
	public float scrollWheelFactor = 0.25f;

	// Token: 0x04000419 RID: 1049
	public float momentumAmount = 35f;

	// Token: 0x0400041A RID: 1050
	public float dampenStrength = 9f;

	// Token: 0x0400041B RID: 1051
	public UIProgressBar horizontalScrollBar;

	// Token: 0x0400041C RID: 1052
	public UIProgressBar verticalScrollBar;

	// Token: 0x0400041D RID: 1053
	public UIScrollView.ShowCondition showScrollBars = UIScrollView.ShowCondition.OnlyIfNeeded;

	// Token: 0x0400041E RID: 1054
	public Vector2 customMovement = new Vector2(1f, 0f);

	// Token: 0x0400041F RID: 1055
	public UIWidget.Pivot contentPivot;

	// Token: 0x04000420 RID: 1056
	public UIScrollView.OnDragNotification onDragStarted;

	// Token: 0x04000421 RID: 1057
	public UIScrollView.OnDragNotification onDragFinished;

	// Token: 0x04000422 RID: 1058
	public UIScrollView.OnDragNotification onMomentumMove;

	// Token: 0x04000423 RID: 1059
	public UIScrollView.OnDragNotification onStoppedMoving;

	// Token: 0x04000424 RID: 1060
	[HideInInspector]
	[SerializeField]
	private Vector3 scale = new Vector3(1f, 0f, 0f);

	// Token: 0x04000425 RID: 1061
	[SerializeField]
	[HideInInspector]
	private Vector2 relativePositionOnReset = Vector2.zero;

	// Token: 0x04000426 RID: 1062
	protected Transform mTrans;

	// Token: 0x04000427 RID: 1063
	protected UIPanel mPanel;

	// Token: 0x04000428 RID: 1064
	protected Plane mPlane;

	// Token: 0x04000429 RID: 1065
	protected Vector3 mLastPos;

	// Token: 0x0400042A RID: 1066
	protected bool mPressed;

	// Token: 0x0400042B RID: 1067
	protected Vector3 mMomentum = Vector3.zero;

	// Token: 0x0400042C RID: 1068
	protected float mScroll;

	// Token: 0x0400042D RID: 1069
	protected Bounds mBounds;

	// Token: 0x0400042E RID: 1070
	protected bool mCalculatedBounds;

	// Token: 0x0400042F RID: 1071
	protected bool mShouldMove;

	// Token: 0x04000430 RID: 1072
	protected bool mIgnoreCallbacks;

	// Token: 0x04000431 RID: 1073
	protected int mDragID = -10;

	// Token: 0x04000432 RID: 1074
	protected Vector2 mDragStartOffset = Vector2.zero;

	// Token: 0x04000433 RID: 1075
	protected bool mDragStarted;

	// Token: 0x04000434 RID: 1076
	[NonSerialized]
	private bool mStarted;

	// Token: 0x04000435 RID: 1077
	[HideInInspector]
	public UICenterOnChild centerOnChild;

	// Token: 0x020005DA RID: 1498
	[DoNotObfuscateNGUI]
	public enum Movement
	{
		// Token: 0x04004D4D RID: 19789
		Horizontal,
		// Token: 0x04004D4E RID: 19790
		Vertical,
		// Token: 0x04004D4F RID: 19791
		Unrestricted,
		// Token: 0x04004D50 RID: 19792
		Custom
	}

	// Token: 0x020005DB RID: 1499
	[DoNotObfuscateNGUI]
	public enum DragEffect
	{
		// Token: 0x04004D52 RID: 19794
		None,
		// Token: 0x04004D53 RID: 19795
		Momentum,
		// Token: 0x04004D54 RID: 19796
		MomentumAndSpring
	}

	// Token: 0x020005DC RID: 1500
	[DoNotObfuscateNGUI]
	public enum ShowCondition
	{
		// Token: 0x04004D56 RID: 19798
		Always,
		// Token: 0x04004D57 RID: 19799
		OnlyIfNeeded,
		// Token: 0x04004D58 RID: 19800
		WhenDragging
	}

	// Token: 0x020005DD RID: 1501
	// (Invoke) Token: 0x0600250F RID: 9487
	public delegate void OnDragNotification();
}
