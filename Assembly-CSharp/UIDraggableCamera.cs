using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Interaction/Draggable Camera")]
public class UIDraggableCamera : MonoBehaviour
{
	// Token: 0x17000015 RID: 21
	// (get) Token: 0x060001A0 RID: 416 RVA: 0x00016BF4 File Offset: 0x00014DF4
	// (set) Token: 0x060001A1 RID: 417 RVA: 0x00016BFC File Offset: 0x00014DFC
	public Vector2 currentMomentum
	{
		get
		{
			return this.mMomentum;
		}
		set
		{
			this.mMomentum = value;
		}
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00016C08 File Offset: 0x00014E08
	private void Start()
	{
		this.mCam = base.GetComponent<Camera>();
		this.mTrans = base.transform;
		this.mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		if (this.rootForBounds == null)
		{
			Debug.LogError(NGUITools.GetHierarchy(base.gameObject) + " needs the 'Root For Bounds' parameter to be set", this);
			base.enabled = false;
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00016C70 File Offset: 0x00014E70
	private Vector3 CalculateConstrainOffset()
	{
		if (this.rootForBounds == null || this.rootForBounds.childCount == 0)
		{
			return Vector3.zero;
		}
		Vector3 vector = new Vector3(this.mCam.rect.xMin * (float)Screen.width, this.mCam.rect.yMin * (float)Screen.height, 0f);
		Vector3 vector2 = new Vector3(this.mCam.rect.xMax * (float)Screen.width, this.mCam.rect.yMax * (float)Screen.height, 0f);
		vector = this.mCam.ScreenToWorldPoint(vector);
		vector2 = this.mCam.ScreenToWorldPoint(vector2);
		Vector2 minRect = new Vector2(this.mBounds.min.x, this.mBounds.min.y);
		Vector2 maxRect = new Vector2(this.mBounds.max.x, this.mBounds.max.y);
		return NGUIMath.ConstrainRect(minRect, maxRect, vector, vector2);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00016D9C File Offset: 0x00014F9C
	public bool ConstrainToBounds(bool immediate)
	{
		if (this.mTrans != null && this.rootForBounds != null)
		{
			Vector3 b = this.CalculateConstrainOffset();
			if (b.sqrMagnitude > 0f)
			{
				if (immediate)
				{
					this.mTrans.position -= b;
				}
				else
				{
					SpringPosition springPosition = SpringPosition.Begin(base.gameObject, this.mTrans.position - b, 13f);
					springPosition.ignoreTimeScale = true;
					springPosition.worldSpace = true;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00016E28 File Offset: 0x00015028
	public void Press(bool isPressed)
	{
		if (isPressed)
		{
			this.mDragStarted = false;
		}
		if (this.rootForBounds != null)
		{
			this.mPressed = isPressed;
			if (isPressed)
			{
				this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				this.mMomentum = Vector2.zero;
				this.mScroll = 0f;
				SpringPosition component = base.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
					return;
				}
			}
			else if (this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring)
			{
				this.ConstrainToBounds(false);
			}
		}
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00016EA8 File Offset: 0x000150A8
	public void Drag(Vector2 delta)
	{
		if (this.smoothDragStart && !this.mDragStarted)
		{
			this.mDragStarted = true;
			return;
		}
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
		if (this.mRoot != null)
		{
			delta *= this.mRoot.pixelSizeAdjustment;
		}
		Vector2 vector = Vector2.Scale(delta, -this.scale);
		this.mTrans.localPosition += vector;
		this.mMomentum = Vector2.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
		if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring && this.ConstrainToBounds(true))
		{
			this.mMomentum = Vector2.zero;
			this.mScroll = 0f;
		}
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00016F84 File Offset: 0x00015184
	public void Scroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (Mathf.Sign(this.mScroll) != Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00016FDC File Offset: 0x000151DC
	private void Update()
	{
		float deltaTime = RealTime.deltaTime;
		if (this.mPressed)
		{
			SpringPosition component = base.GetComponent<SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mMomentum += this.scale * (this.mScroll * 20f);
			this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
			if (this.mMomentum.magnitude > 0.01f)
			{
				this.mTrans.localPosition += NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
				this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				if (!this.ConstrainToBounds(this.dragEffect == UIDragObject.DragEffect.None))
				{
					SpringPosition component2 = base.GetComponent<SpringPosition>();
					if (component2 != null)
					{
						component2.enabled = false;
					}
				}
				return;
			}
			this.mScroll = 0f;
		}
		NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
	}

	// Token: 0x04000356 RID: 854
	public Transform rootForBounds;

	// Token: 0x04000357 RID: 855
	public Vector2 scale = Vector2.one;

	// Token: 0x04000358 RID: 856
	public float scrollWheelFactor;

	// Token: 0x04000359 RID: 857
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x0400035A RID: 858
	public bool smoothDragStart = true;

	// Token: 0x0400035B RID: 859
	public float momentumAmount = 35f;

	// Token: 0x0400035C RID: 860
	private Camera mCam;

	// Token: 0x0400035D RID: 861
	private Transform mTrans;

	// Token: 0x0400035E RID: 862
	private bool mPressed;

	// Token: 0x0400035F RID: 863
	private Vector2 mMomentum = Vector2.zero;

	// Token: 0x04000360 RID: 864
	private Bounds mBounds;

	// Token: 0x04000361 RID: 865
	private float mScroll;

	// Token: 0x04000362 RID: 866
	private UIRoot mRoot;

	// Token: 0x04000363 RID: 867
	private bool mDragStarted;
}
