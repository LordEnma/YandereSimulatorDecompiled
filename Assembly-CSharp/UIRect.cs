using System;
using UnityEngine;

public abstract class UIRect : MonoBehaviour
{
	[Serializable]
	public class AnchorPoint
	{
		public Transform target;

		public float relative;

		public int absolute;

		[NonSerialized]
		public UIRect rect;

		[NonSerialized]
		public Camera targetCam;

		public AnchorPoint()
		{
		}

		public AnchorPoint(float relative)
		{
			this.relative = relative;
		}

		public void Set(float relative, float absolute)
		{
			this.relative = relative;
			this.absolute = Mathf.FloorToInt(absolute + 0.5f);
		}

		public void Set(Transform target, float relative, float absolute)
		{
			this.target = target;
			this.relative = relative;
			this.absolute = Mathf.FloorToInt(absolute + 0.5f);
		}

		public void SetToNearest(float abs0, float abs1, float abs2)
		{
			SetToNearest(0f, 0.5f, 1f, abs0, abs1, abs2);
		}

		public void SetToNearest(float rel0, float rel1, float rel2, float abs0, float abs1, float abs2)
		{
			float num = Mathf.Abs(abs0);
			float num2 = Mathf.Abs(abs1);
			float num3 = Mathf.Abs(abs2);
			if (num < num2 && num < num3)
			{
				Set(rel0, abs0);
			}
			else if (num2 < num && num2 < num3)
			{
				Set(rel1, abs1);
			}
			else
			{
				Set(rel2, abs2);
			}
		}

		public void SetHorizontal(Transform parent, float localPos)
		{
			if ((bool)rect)
			{
				Vector3[] sides = rect.GetSides(parent);
				float num = Mathf.Lerp(sides[0].x, sides[2].x, relative);
				absolute = Mathf.FloorToInt(localPos - num + 0.5f);
				return;
			}
			Vector3 position = target.position;
			if (parent != null)
			{
				position = parent.InverseTransformPoint(position);
			}
			absolute = Mathf.FloorToInt(localPos - position.x + 0.5f);
		}

		public void SetVertical(Transform parent, float localPos)
		{
			if ((bool)rect)
			{
				Vector3[] sides = rect.GetSides(parent);
				float num = Mathf.Lerp(sides[3].y, sides[1].y, relative);
				absolute = Mathf.FloorToInt(localPos - num + 0.5f);
				return;
			}
			Vector3 position = target.position;
			if (parent != null)
			{
				position = parent.InverseTransformPoint(position);
			}
			absolute = Mathf.FloorToInt(localPos - position.y + 0.5f);
		}

		public Vector3[] GetSides(Transform relativeTo)
		{
			if (target != null)
			{
				if (rect != null)
				{
					return rect.GetSides(relativeTo);
				}
				Camera component = target.GetComponent<Camera>();
				if (component != null)
				{
					return component.GetSides(relativeTo);
				}
			}
			return null;
		}
	}

	[DoNotObfuscateNGUI]
	public enum AnchorUpdate
	{
		OnEnable = 0,
		OnUpdate = 1,
		OnStart = 2
	}

	public AnchorPoint leftAnchor = new AnchorPoint();

	public AnchorPoint rightAnchor = new AnchorPoint(1f);

	public AnchorPoint bottomAnchor = new AnchorPoint();

	public AnchorPoint topAnchor = new AnchorPoint(1f);

	public AnchorUpdate updateAnchors = AnchorUpdate.OnUpdate;

	[NonSerialized]
	protected GameObject mGo;

	[NonSerialized]
	protected Transform mTrans;

	[NonSerialized]
	protected BetterList<UIRect> mChildren = new BetterList<UIRect>();

	[NonSerialized]
	protected bool mChanged = true;

	[NonSerialized]
	protected bool mParentFound;

	[NonSerialized]
	private bool mUpdateAnchors = true;

	[NonSerialized]
	private int mUpdateFrame = -1;

	[NonSerialized]
	private bool mAnchorsCached;

	[NonSerialized]
	private UIRoot mRoot;

	[NonSerialized]
	private UIRect mParent;

	[NonSerialized]
	private bool mRootSet;

	[NonSerialized]
	protected Camera mCam;

	protected bool mStarted;

	[NonSerialized]
	public float finalAlpha = 1f;

	protected static Vector3[] mSides = new Vector3[4];

	public GameObject cachedGameObject
	{
		get
		{
			if (mGo == null)
			{
				mGo = base.gameObject;
			}
			return mGo;
		}
	}

	public Transform cachedTransform
	{
		get
		{
			if (mTrans == null)
			{
				mTrans = base.transform;
			}
			return mTrans;
		}
	}

	public Camera anchorCamera
	{
		get
		{
			if (!mCam || !mAnchorsCached)
			{
				ResetAnchors();
			}
			return mCam;
		}
	}

	public bool isFullyAnchored
	{
		get
		{
			if ((bool)leftAnchor.target && (bool)rightAnchor.target && (bool)topAnchor.target)
			{
				return bottomAnchor.target;
			}
			return false;
		}
	}

	public virtual bool isAnchoredHorizontally
	{
		get
		{
			if (!leftAnchor.target)
			{
				return rightAnchor.target;
			}
			return true;
		}
	}

	public virtual bool isAnchoredVertically
	{
		get
		{
			if (!bottomAnchor.target)
			{
				return topAnchor.target;
			}
			return true;
		}
	}

	public virtual bool canBeAnchored => true;

	public UIRect parent
	{
		get
		{
			if (!mParentFound)
			{
				mParentFound = true;
				mParent = NGUITools.FindInParents<UIRect>(cachedTransform.parent);
			}
			return mParent;
		}
	}

	public UIRoot root
	{
		get
		{
			if (parent != null)
			{
				return mParent.root;
			}
			if (!mRootSet)
			{
				mRootSet = true;
				mRoot = NGUITools.FindInParents<UIRoot>(cachedTransform);
			}
			return mRoot;
		}
	}

	public bool isAnchored
	{
		get
		{
			if ((bool)leftAnchor.target || (bool)rightAnchor.target || (bool)topAnchor.target || (bool)bottomAnchor.target)
			{
				return canBeAnchored;
			}
			return false;
		}
	}

	public abstract float alpha { get; set; }

	public abstract Vector3[] localCorners { get; }

	public abstract Vector3[] worldCorners { get; }

	protected float cameraRayDistance
	{
		get
		{
			if (anchorCamera == null)
			{
				return 0f;
			}
			if (!mCam.orthographic)
			{
				Transform transform = cachedTransform;
				Transform transform2 = mCam.transform;
				Plane plane = new Plane(transform.rotation * Vector3.back, transform.position);
				Ray ray = new Ray(transform2.position, transform2.rotation * Vector3.forward);
				if (plane.Raycast(ray, out var enter))
				{
					return enter;
				}
			}
			return Mathf.Lerp(mCam.nearClipPlane, mCam.farClipPlane, 0.5f);
		}
	}

	public abstract float CalculateFinalAlpha(int frameID);

	public virtual void Invalidate(bool includeChildren)
	{
		mChanged = true;
		if (includeChildren)
		{
			for (int i = 0; i < mChildren.size; i++)
			{
				mChildren.buffer[i].Invalidate(includeChildren: true);
			}
		}
	}

	public virtual Vector3[] GetSides(Transform relativeTo)
	{
		if (anchorCamera != null)
		{
			return mCam.GetSides(cameraRayDistance, relativeTo);
		}
		Vector3 position = cachedTransform.position;
		for (int i = 0; i < 4; i++)
		{
			mSides[i] = position;
		}
		if (relativeTo != null)
		{
			for (int j = 0; j < 4; j++)
			{
				mSides[j] = relativeTo.InverseTransformPoint(mSides[j]);
			}
		}
		return mSides;
	}

	protected Vector3 GetLocalPos(AnchorPoint ac, Transform trans)
	{
		if (ac.targetCam == null)
		{
			FindCameraFor(ac);
		}
		if (anchorCamera == null || ac.targetCam == null)
		{
			return cachedTransform.localPosition;
		}
		Rect rect = ac.targetCam.rect;
		Vector3 vector = ac.targetCam.WorldToViewportPoint(ac.target.position);
		Vector3 position = new Vector3(vector.x * rect.width + rect.x, vector.y * rect.height + rect.y, vector.z);
		position = mCam.ViewportToWorldPoint(position);
		if (trans != null)
		{
			position = trans.InverseTransformPoint(position);
		}
		position.x = Mathf.Floor(position.x + 0.5f);
		position.y = Mathf.Floor(position.y + 0.5f);
		return position;
	}

	protected virtual void OnEnable()
	{
		mUpdateFrame = -1;
		if (updateAnchors == AnchorUpdate.OnEnable)
		{
			mAnchorsCached = false;
			mUpdateAnchors = true;
		}
		if (mStarted)
		{
			OnInit();
		}
		mUpdateFrame = -1;
	}

	protected virtual void OnInit()
	{
		mChanged = true;
		mRootSet = false;
		mParentFound = false;
		if (parent != null)
		{
			mParent.mChildren.Add(this);
		}
	}

	protected virtual void OnDisable()
	{
		if ((bool)mParent)
		{
			mParent.mChildren.Remove(this);
		}
		mParent = null;
		mRoot = null;
		mRootSet = false;
		mParentFound = false;
	}

	protected virtual void Awake()
	{
		NGUITools.CheckForPrefabStage(base.gameObject);
		mStarted = false;
		mGo = base.gameObject;
		mTrans = base.transform;
	}

	protected void Start()
	{
		mStarted = true;
		OnInit();
		OnStart();
	}

	public void Update()
	{
		if (!mCam)
		{
			ResetAndUpdateAnchors();
			mUpdateFrame = -1;
		}
		else if (!mAnchorsCached)
		{
			ResetAnchors();
		}
		int frameCount = Time.frameCount;
		if (mUpdateFrame != frameCount)
		{
			if (updateAnchors == AnchorUpdate.OnUpdate || mUpdateAnchors)
			{
				UpdateAnchorsInternal(frameCount);
			}
			OnUpdate();
		}
	}

	protected void UpdateAnchorsInternal(int frame)
	{
		mUpdateFrame = frame;
		mUpdateAnchors = false;
		bool flag = false;
		if ((bool)leftAnchor.target)
		{
			flag = true;
			if (leftAnchor.rect != null && leftAnchor.rect.mUpdateFrame != frame)
			{
				leftAnchor.rect.Update();
			}
		}
		if ((bool)bottomAnchor.target)
		{
			flag = true;
			if (bottomAnchor.rect != null && bottomAnchor.rect.mUpdateFrame != frame)
			{
				bottomAnchor.rect.Update();
			}
		}
		if ((bool)rightAnchor.target)
		{
			flag = true;
			if (rightAnchor.rect != null && rightAnchor.rect.mUpdateFrame != frame)
			{
				rightAnchor.rect.Update();
			}
		}
		if ((bool)topAnchor.target)
		{
			flag = true;
			if (topAnchor.rect != null && topAnchor.rect.mUpdateFrame != frame)
			{
				topAnchor.rect.Update();
			}
		}
		if (flag)
		{
			OnAnchor();
		}
	}

	public void UpdateAnchors()
	{
		if (isAnchored)
		{
			mUpdateFrame = -1;
			mUpdateAnchors = true;
			UpdateAnchorsInternal(Time.frameCount);
		}
	}

	protected abstract void OnAnchor();

	public void SetAnchor(Transform t)
	{
		leftAnchor.target = t;
		rightAnchor.target = t;
		topAnchor.target = t;
		bottomAnchor.target = t;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetAnchor(GameObject go)
	{
		Transform target = ((go != null) ? go.transform : null);
		leftAnchor.target = target;
		rightAnchor.target = target;
		topAnchor.target = target;
		bottomAnchor.target = target;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetAnchor(GameObject go, int left, int bottom, int right, int top)
	{
		Transform target = ((go != null) ? go.transform : null);
		leftAnchor.target = target;
		rightAnchor.target = target;
		topAnchor.target = target;
		bottomAnchor.target = target;
		leftAnchor.relative = 0f;
		rightAnchor.relative = 1f;
		bottomAnchor.relative = 0f;
		topAnchor.relative = 1f;
		leftAnchor.absolute = left;
		rightAnchor.absolute = right;
		bottomAnchor.absolute = bottom;
		topAnchor.absolute = top;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetAnchor(GameObject go, float left, float bottom, float right, float top)
	{
		Transform target = ((go != null) ? go.transform : null);
		leftAnchor.target = target;
		rightAnchor.target = target;
		topAnchor.target = target;
		bottomAnchor.target = target;
		leftAnchor.relative = left;
		rightAnchor.relative = right;
		bottomAnchor.relative = bottom;
		topAnchor.relative = top;
		leftAnchor.absolute = 0;
		rightAnchor.absolute = 0;
		bottomAnchor.absolute = 0;
		topAnchor.absolute = 0;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetAnchor(GameObject go, float left, int leftOffset, float bottom, int bottomOffset, float right, int rightOffset, float top, int topOffset)
	{
		Transform target = ((go != null) ? go.transform : null);
		leftAnchor.target = target;
		rightAnchor.target = target;
		topAnchor.target = target;
		bottomAnchor.target = target;
		leftAnchor.relative = left;
		rightAnchor.relative = right;
		bottomAnchor.relative = bottom;
		topAnchor.relative = top;
		leftAnchor.absolute = leftOffset;
		rightAnchor.absolute = rightOffset;
		bottomAnchor.absolute = bottomOffset;
		topAnchor.absolute = topOffset;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetAnchor(float left, int leftOffset, float bottom, int bottomOffset, float right, int rightOffset, float top, int topOffset)
	{
		Transform target = cachedTransform.parent;
		leftAnchor.target = target;
		rightAnchor.target = target;
		topAnchor.target = target;
		bottomAnchor.target = target;
		leftAnchor.relative = left;
		rightAnchor.relative = right;
		bottomAnchor.relative = bottom;
		topAnchor.relative = top;
		leftAnchor.absolute = leftOffset;
		rightAnchor.absolute = rightOffset;
		bottomAnchor.absolute = bottomOffset;
		topAnchor.absolute = topOffset;
		ResetAnchors();
		UpdateAnchors();
	}

	public void SetScreenRect(int left, int top, int width, int height)
	{
		SetAnchor(0f, left, 1f, -top - height, 0f, left + width, 1f, -top);
	}

	public void ResetAnchors()
	{
		mAnchorsCached = true;
		leftAnchor.rect = (leftAnchor.target ? leftAnchor.target.GetComponent<UIRect>() : null);
		bottomAnchor.rect = (bottomAnchor.target ? bottomAnchor.target.GetComponent<UIRect>() : null);
		rightAnchor.rect = (rightAnchor.target ? rightAnchor.target.GetComponent<UIRect>() : null);
		topAnchor.rect = (topAnchor.target ? topAnchor.target.GetComponent<UIRect>() : null);
		mCam = NGUITools.FindCameraForLayer(cachedGameObject.layer);
		FindCameraFor(leftAnchor);
		FindCameraFor(bottomAnchor);
		FindCameraFor(rightAnchor);
		FindCameraFor(topAnchor);
		mUpdateAnchors = true;
	}

	public void ResetAndUpdateAnchors()
	{
		ResetAnchors();
		UpdateAnchors();
	}

	public abstract void SetRect(float x, float y, float width, float height);

	private void FindCameraFor(AnchorPoint ap)
	{
		if (ap.target == null || ap.rect != null)
		{
			ap.targetCam = null;
		}
		else
		{
			ap.targetCam = NGUITools.FindCameraForLayer(ap.target.gameObject.layer);
		}
	}

	public virtual void ParentHasChanged()
	{
		mParentFound = false;
		UIRect uIRect = NGUITools.FindInParents<UIRect>(cachedTransform.parent);
		if (mParent != uIRect)
		{
			if ((bool)mParent)
			{
				mParent.mChildren.Remove(this);
			}
			mParent = uIRect;
			if ((bool)mParent)
			{
				mParent.mChildren.Add(this);
			}
			mRootSet = false;
		}
	}

	protected abstract void OnStart();

	protected virtual void OnUpdate()
	{
	}
}
