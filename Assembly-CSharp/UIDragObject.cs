using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : MonoBehaviour
{
	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000185 RID: 389 RVA: 0x0001602F File Offset: 0x0001422F
	// (set) Token: 0x06000186 RID: 390 RVA: 0x00016037 File Offset: 0x00014237
	public Vector3 dragMovement
	{
		get
		{
			return this.scale;
		}
		set
		{
			this.scale = value;
		}
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00016040 File Offset: 0x00014240
	private void OnEnable()
	{
		if (this.scrollWheelFactor != 0f)
		{
			this.scrollMomentum = this.scale * this.scrollWheelFactor;
			this.scrollWheelFactor = 0f;
		}
		if (this.contentRect == null && this.target != null && Application.isPlaying)
		{
			UIWidget component = this.target.GetComponent<UIWidget>();
			if (component != null)
			{
				this.contentRect = component;
			}
		}
		this.mTargetPos = ((this.target != null) ? this.target.position : Vector3.zero);
	}

	// Token: 0x06000188 RID: 392 RVA: 0x000160E1 File Offset: 0x000142E1
	private void OnDisable()
	{
		this.mStarted = false;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x000160EC File Offset: 0x000142EC
	private void FindPanel()
	{
		this.panelRegion = ((this.target != null) ? UIPanel.Find(this.target.transform.parent) : null);
		if (this.panelRegion == null)
		{
			this.restrictWithinPanel = false;
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0001613C File Offset: 0x0001433C
	private void UpdateBounds()
	{
		if (this.contentRect)
		{
			Matrix4x4 worldToLocalMatrix = this.panelRegion.cachedTransform.worldToLocalMatrix;
			Vector3[] worldCorners = this.contentRect.worldCorners;
			for (int i = 0; i < 4; i++)
			{
				worldCorners[i] = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[i]);
			}
			this.mBounds = new Bounds(worldCorners[0], Vector3.zero);
			for (int j = 1; j < 4; j++)
			{
				this.mBounds.Encapsulate(worldCorners[j]);
			}
			return;
		}
		this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.panelRegion.cachedTransform, this.target);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000161E8 File Offset: 0x000143E8
	private void OnPress(bool pressed)
	{
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		float timeScale = Time.timeScale;
		if (timeScale < 0.01f && timeScale != 0f)
		{
			return;
		}
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			if (pressed)
			{
				if (!this.mPressed)
				{
					this.mTouchID = UICamera.currentTouchID;
					this.mPressed = true;
					this.mStarted = false;
					this.CancelMovement();
					if (this.restrictWithinPanel && this.panelRegion == null)
					{
						this.FindPanel();
					}
					if (this.restrictWithinPanel)
					{
						this.UpdateBounds();
					}
					this.CancelSpring();
					Transform transform = UICamera.currentCamera.transform;
					this.mPlane = new Plane(((this.panelRegion != null) ? this.panelRegion.cachedTransform.rotation : transform.rotation) * Vector3.back, UICamera.lastWorldPosition);
					return;
				}
			}
			else if (this.mPressed && this.mTouchID == UICamera.currentTouchID)
			{
				this.mPressed = false;
				if (this.restrictWithinPanel && this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring && this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, false))
				{
					this.CancelMovement();
				}
			}
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00016344 File Offset: 0x00014544
	private void OnDrag(Vector2 delta)
	{
		if (this.mPressed && this.mTouchID == UICamera.currentTouchID && base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float distance = 0f;
			if (this.mPlane.Raycast(ray, out distance))
			{
				Vector3 point = ray.GetPoint(distance);
				Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (!this.mStarted)
				{
					this.mStarted = true;
					vector = Vector3.zero;
				}
				if (vector.x != 0f || vector.y != 0f)
				{
					vector = this.target.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.target.TransformDirection(vector);
				}
				if (this.dragEffect != UIDragObject.DragEffect.None)
				{
					this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				}
				Vector3 localPosition = this.target.localPosition;
				this.Move(vector);
				if (this.restrictWithinPanel)
				{
					this.mBounds.center = this.mBounds.center + (this.target.localPosition - localPosition);
					if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring && this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, true))
					{
						this.CancelMovement();
					}
				}
			}
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000164F8 File Offset: 0x000146F8
	private void Move(Vector3 worldDelta)
	{
		if (this.panelRegion != null)
		{
			this.mTargetPos += worldDelta;
			Transform parent = this.target.parent;
			Rigidbody component = this.target.GetComponent<Rigidbody>();
			if (parent != null)
			{
				Vector3 vector = parent.worldToLocalMatrix.MultiplyPoint3x4(this.mTargetPos);
				vector.x = Mathf.Round(vector.x);
				vector.y = Mathf.Round(vector.y);
				if (component != null)
				{
					vector = parent.localToWorldMatrix.MultiplyPoint3x4(vector);
					component.position = vector;
				}
				else
				{
					this.target.localPosition = vector;
				}
			}
			else if (component != null)
			{
				component.position = this.mTargetPos;
			}
			else
			{
				this.target.position = this.mTargetPos;
			}
			UIScrollView component2 = this.panelRegion.GetComponent<UIScrollView>();
			if (component2 != null)
			{
				component2.UpdateScrollbars(true);
				return;
			}
		}
		else
		{
			this.target.position += worldDelta;
		}
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00016610 File Offset: 0x00014810
	private void LateUpdate()
	{
		if (this.target == null)
		{
			return;
		}
		float deltaTime = RealTime.deltaTime;
		this.mMomentum -= this.mScroll;
		this.mScroll = NGUIMath.SpringLerp(this.mScroll, Vector3.zero, 20f, deltaTime);
		if (this.mMomentum.magnitude < 0.0001f)
		{
			return;
		}
		if (!this.mPressed)
		{
			if (this.panelRegion == null)
			{
				this.FindPanel();
			}
			this.Move(NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime));
			if (this.restrictWithinPanel && this.panelRegion != null)
			{
				this.UpdateBounds();
				if (this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, this.dragEffect == UIDragObject.DragEffect.None))
				{
					this.CancelMovement();
				}
				else
				{
					this.CancelSpring();
				}
			}
			NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
			if (this.mMomentum.magnitude < 0.0001f)
			{
				this.CancelMovement();
				return;
			}
		}
		else
		{
			NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
		}
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00016738 File Offset: 0x00014938
	public void CancelMovement()
	{
		if (this.target != null)
		{
			Vector3 localPosition = this.target.localPosition;
			localPosition.x = (float)Mathf.RoundToInt(localPosition.x);
			localPosition.y = (float)Mathf.RoundToInt(localPosition.y);
			localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
			this.target.localPosition = localPosition;
		}
		this.mTargetPos = ((this.target != null) ? this.target.position : Vector3.zero);
		this.mMomentum = Vector3.zero;
		this.mScroll = Vector3.zero;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000167E0 File Offset: 0x000149E0
	public void CancelSpring()
	{
		SpringPosition component = this.target.GetComponent<SpringPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00016809 File Offset: 0x00014A09
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			this.mScroll -= this.scrollMomentum * (delta * 0.05f);
		}
	}

	// Token: 0x0400033B RID: 827
	public Transform target;

	// Token: 0x0400033C RID: 828
	public UIPanel panelRegion;

	// Token: 0x0400033D RID: 829
	public Vector3 scrollMomentum = Vector3.zero;

	// Token: 0x0400033E RID: 830
	public bool restrictWithinPanel;

	// Token: 0x0400033F RID: 831
	public UIRect contentRect;

	// Token: 0x04000340 RID: 832
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x04000341 RID: 833
	public float momentumAmount = 35f;

	// Token: 0x04000342 RID: 834
	[SerializeField]
	protected Vector3 scale = new Vector3(1f, 1f, 0f);

	// Token: 0x04000343 RID: 835
	[SerializeField]
	[HideInInspector]
	private float scrollWheelFactor;

	// Token: 0x04000344 RID: 836
	private Plane mPlane;

	// Token: 0x04000345 RID: 837
	private Vector3 mTargetPos;

	// Token: 0x04000346 RID: 838
	private Vector3 mLastPos;

	// Token: 0x04000347 RID: 839
	private Vector3 mMomentum = Vector3.zero;

	// Token: 0x04000348 RID: 840
	private Vector3 mScroll = Vector3.zero;

	// Token: 0x04000349 RID: 841
	private Bounds mBounds;

	// Token: 0x0400034A RID: 842
	private int mTouchID;

	// Token: 0x0400034B RID: 843
	private bool mStarted;

	// Token: 0x0400034C RID: 844
	private bool mPressed;

	// Token: 0x020005CD RID: 1485
	[DoNotObfuscateNGUI]
	public enum DragEffect
	{
		// Token: 0x04004DAA RID: 19882
		None,
		// Token: 0x04004DAB RID: 19883
		Momentum,
		// Token: 0x04004DAC RID: 19884
		MomentumAndSpring
	}
}
