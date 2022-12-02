using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum DragEffect
	{
		None = 0,
		Momentum = 1,
		MomentumAndSpring = 2
	}

	public Transform target;

	public UIPanel panelRegion;

	public Vector3 scrollMomentum = Vector3.zero;

	public bool restrictWithinPanel;

	public UIRect contentRect;

	public DragEffect dragEffect = DragEffect.MomentumAndSpring;

	public float momentumAmount = 35f;

	[SerializeField]
	protected Vector3 scale = new Vector3(1f, 1f, 0f);

	[SerializeField]
	[HideInInspector]
	private float scrollWheelFactor;

	private Plane mPlane;

	private Vector3 mTargetPos;

	private Vector3 mLastPos;

	private Vector3 mMomentum = Vector3.zero;

	private Vector3 mScroll = Vector3.zero;

	private Bounds mBounds;

	private int mTouchID;

	private bool mStarted;

	private bool mPressed;

	public Vector3 dragMovement
	{
		get
		{
			return scale;
		}
		set
		{
			scale = value;
		}
	}

	private void OnEnable()
	{
		if (scrollWheelFactor != 0f)
		{
			scrollMomentum = scale * scrollWheelFactor;
			scrollWheelFactor = 0f;
		}
		if (contentRect == null && target != null && Application.isPlaying)
		{
			UIWidget component = target.GetComponent<UIWidget>();
			if (component != null)
			{
				contentRect = component;
			}
		}
		mTargetPos = ((target != null) ? target.position : Vector3.zero);
	}

	private void OnDisable()
	{
		mStarted = false;
	}

	private void FindPanel()
	{
		panelRegion = ((target != null) ? UIPanel.Find(target.transform.parent) : null);
		if (panelRegion == null)
		{
			restrictWithinPanel = false;
		}
	}

	private void UpdateBounds()
	{
		if ((bool)contentRect)
		{
			Matrix4x4 worldToLocalMatrix = panelRegion.cachedTransform.worldToLocalMatrix;
			Vector3[] worldCorners = contentRect.worldCorners;
			for (int i = 0; i < 4; i++)
			{
				worldCorners[i] = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[i]);
			}
			mBounds = new Bounds(worldCorners[0], Vector3.zero);
			for (int j = 1; j < 4; j++)
			{
				mBounds.Encapsulate(worldCorners[j]);
			}
		}
		else
		{
			mBounds = NGUIMath.CalculateRelativeWidgetBounds(panelRegion.cachedTransform, target);
		}
	}

	private void OnPress(bool pressed)
	{
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		float timeScale = Time.timeScale;
		if ((timeScale < 0.01f && timeScale != 0f) || !base.enabled || !NGUITools.GetActive(base.gameObject) || !(target != null))
		{
			return;
		}
		if (pressed)
		{
			if (!mPressed)
			{
				mTouchID = UICamera.currentTouchID;
				mPressed = true;
				mStarted = false;
				CancelMovement();
				if (restrictWithinPanel && panelRegion == null)
				{
					FindPanel();
				}
				if (restrictWithinPanel)
				{
					UpdateBounds();
				}
				CancelSpring();
				Transform transform = UICamera.currentCamera.transform;
				mPlane = new Plane(((panelRegion != null) ? panelRegion.cachedTransform.rotation : transform.rotation) * Vector3.back, UICamera.lastWorldPosition);
			}
		}
		else if (mPressed && mTouchID == UICamera.currentTouchID)
		{
			mPressed = false;
			if (restrictWithinPanel && dragEffect == DragEffect.MomentumAndSpring && panelRegion.ConstrainTargetToBounds(target, ref mBounds, false))
			{
				CancelMovement();
			}
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (!mPressed || mTouchID != UICamera.currentTouchID || !base.enabled || !NGUITools.GetActive(base.gameObject) || !(target != null))
		{
			return;
		}
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
		Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
		float enter = 0f;
		if (!mPlane.Raycast(ray, out enter))
		{
			return;
		}
		Vector3 point = ray.GetPoint(enter);
		Vector3 vector = point - mLastPos;
		mLastPos = point;
		if (!mStarted)
		{
			mStarted = true;
			vector = Vector3.zero;
		}
		if (vector.x != 0f || vector.y != 0f)
		{
			vector = target.InverseTransformDirection(vector);
			vector.Scale(scale);
			vector = target.TransformDirection(vector);
		}
		if (dragEffect != 0)
		{
			mMomentum = Vector3.Lerp(mMomentum, mMomentum + vector * (0.01f * momentumAmount), 0.67f);
		}
		Vector3 localPosition = target.localPosition;
		Move(vector);
		if (restrictWithinPanel)
		{
			mBounds.center += target.localPosition - localPosition;
			if (dragEffect != DragEffect.MomentumAndSpring && panelRegion.ConstrainTargetToBounds(target, ref mBounds, true))
			{
				CancelMovement();
			}
		}
	}

	private void Move(Vector3 worldDelta)
	{
		if (panelRegion != null)
		{
			mTargetPos += worldDelta;
			Transform parent = target.parent;
			Rigidbody component = target.GetComponent<Rigidbody>();
			if (parent != null)
			{
				Vector3 vector = parent.worldToLocalMatrix.MultiplyPoint3x4(mTargetPos);
				vector.x = Mathf.Round(vector.x);
				vector.y = Mathf.Round(vector.y);
				if (component != null)
				{
					vector = parent.localToWorldMatrix.MultiplyPoint3x4(vector);
					component.position = vector;
				}
				else
				{
					target.localPosition = vector;
				}
			}
			else if (component != null)
			{
				component.position = mTargetPos;
			}
			else
			{
				target.position = mTargetPos;
			}
			UIScrollView component2 = panelRegion.GetComponent<UIScrollView>();
			if (component2 != null)
			{
				component2.UpdateScrollbars(true);
			}
		}
		else
		{
			target.position += worldDelta;
		}
	}

	private void LateUpdate()
	{
		if (target == null)
		{
			return;
		}
		float deltaTime = RealTime.deltaTime;
		mMomentum -= mScroll;
		mScroll = NGUIMath.SpringLerp(mScroll, Vector3.zero, 20f, deltaTime);
		if (mMomentum.magnitude < 0.0001f)
		{
			return;
		}
		if (!mPressed)
		{
			if (panelRegion == null)
			{
				FindPanel();
			}
			Move(NGUIMath.SpringDampen(ref mMomentum, 9f, deltaTime));
			if (restrictWithinPanel && panelRegion != null)
			{
				UpdateBounds();
				if (panelRegion.ConstrainTargetToBounds(target, ref mBounds, dragEffect == DragEffect.None))
				{
					CancelMovement();
				}
				else
				{
					CancelSpring();
				}
			}
			NGUIMath.SpringDampen(ref mMomentum, 9f, deltaTime);
			if (mMomentum.magnitude < 0.0001f)
			{
				CancelMovement();
			}
		}
		else
		{
			NGUIMath.SpringDampen(ref mMomentum, 9f, deltaTime);
		}
	}

	public void CancelMovement()
	{
		if (target != null)
		{
			Vector3 localPosition = target.localPosition;
			localPosition.x = Mathf.RoundToInt(localPosition.x);
			localPosition.y = Mathf.RoundToInt(localPosition.y);
			localPosition.z = Mathf.RoundToInt(localPosition.z);
			target.localPosition = localPosition;
		}
		mTargetPos = ((target != null) ? target.position : Vector3.zero);
		mMomentum = Vector3.zero;
		mScroll = Vector3.zero;
	}

	public void CancelSpring()
	{
		SpringPosition component = target.GetComponent<SpringPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			mScroll -= scrollMomentum * (delta * 0.05f);
		}
	}
}
