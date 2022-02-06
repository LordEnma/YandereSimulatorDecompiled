using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
public abstract class UIRect : MonoBehaviour
{
	// Token: 0x1700008D RID: 141
	// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00030E01 File Offset: 0x0002F001
	public GameObject cachedGameObject
	{
		get
		{
			if (this.mGo == null)
			{
				this.mGo = base.gameObject;
			}
			return this.mGo;
		}
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00030E23 File Offset: 0x0002F023
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00030E45 File Offset: 0x0002F045
	public Camera anchorCamera
	{
		get
		{
			if (!this.mCam || !this.mAnchorsCached)
			{
				this.ResetAnchors();
			}
			return this.mCam;
		}
	}

	// Token: 0x17000090 RID: 144
	// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00030E68 File Offset: 0x0002F068
	public bool isFullyAnchored
	{
		get
		{
			return this.leftAnchor.target && this.rightAnchor.target && this.topAnchor.target && this.bottomAnchor.target;
		}
	}

	// Token: 0x17000091 RID: 145
	// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00030EBD File Offset: 0x0002F0BD
	public virtual bool isAnchoredHorizontally
	{
		get
		{
			return this.leftAnchor.target || this.rightAnchor.target;
		}
	}

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00030EE3 File Offset: 0x0002F0E3
	public virtual bool isAnchoredVertically
	{
		get
		{
			return this.bottomAnchor.target || this.topAnchor.target;
		}
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00030F09 File Offset: 0x0002F109
	public virtual bool canBeAnchored
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x060004DA RID: 1242 RVA: 0x00030F0C File Offset: 0x0002F10C
	public UIRect parent
	{
		get
		{
			if (!this.mParentFound)
			{
				this.mParentFound = true;
				this.mParent = NGUITools.FindInParents<UIRect>(this.cachedTransform.parent);
			}
			return this.mParent;
		}
	}

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x060004DB RID: 1243 RVA: 0x00030F3C File Offset: 0x0002F13C
	public UIRoot root
	{
		get
		{
			if (this.parent != null)
			{
				return this.mParent.root;
			}
			if (!this.mRootSet)
			{
				this.mRootSet = true;
				this.mRoot = NGUITools.FindInParents<UIRoot>(this.cachedTransform);
			}
			return this.mRoot;
		}
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x060004DC RID: 1244 RVA: 0x00030F8C File Offset: 0x0002F18C
	public bool isAnchored
	{
		get
		{
			return (this.leftAnchor.target || this.rightAnchor.target || this.topAnchor.target || this.bottomAnchor.target) && this.canBeAnchored;
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x060004DD RID: 1245
	// (set) Token: 0x060004DE RID: 1246
	public abstract float alpha { get; set; }

	// Token: 0x060004DF RID: 1247
	public abstract float CalculateFinalAlpha(int frameID);

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x060004E0 RID: 1248
	public abstract Vector3[] localCorners { get; }

	// Token: 0x17000099 RID: 153
	// (get) Token: 0x060004E1 RID: 1249
	public abstract Vector3[] worldCorners { get; }

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x060004E2 RID: 1250 RVA: 0x00030FEC File Offset: 0x0002F1EC
	protected float cameraRayDistance
	{
		get
		{
			if (this.anchorCamera == null)
			{
				return 0f;
			}
			if (!this.mCam.orthographic)
			{
				Transform cachedTransform = this.cachedTransform;
				Transform transform = this.mCam.transform;
				Plane plane = new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position);
				Ray ray = new Ray(transform.position, transform.rotation * Vector3.forward);
				float result;
				if (plane.Raycast(ray, out result))
				{
					return result;
				}
			}
			return Mathf.Lerp(this.mCam.nearClipPlane, this.mCam.farClipPlane, 0.5f);
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00031098 File Offset: 0x0002F298
	public virtual void Invalidate(bool includeChildren)
	{
		this.mChanged = true;
		if (includeChildren)
		{
			for (int i = 0; i < this.mChildren.size; i++)
			{
				this.mChildren.buffer[i].Invalidate(true);
			}
		}
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x000310D8 File Offset: 0x0002F2D8
	public virtual Vector3[] GetSides(Transform relativeTo)
	{
		if (this.anchorCamera != null)
		{
			return this.mCam.GetSides(this.cameraRayDistance, relativeTo);
		}
		Vector3 position = this.cachedTransform.position;
		for (int i = 0; i < 4; i++)
		{
			UIRect.mSides[i] = position;
		}
		if (relativeTo != null)
		{
			for (int j = 0; j < 4; j++)
			{
				UIRect.mSides[j] = relativeTo.InverseTransformPoint(UIRect.mSides[j]);
			}
		}
		return UIRect.mSides;
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00031160 File Offset: 0x0002F360
	protected Vector3 GetLocalPos(UIRect.AnchorPoint ac, Transform trans)
	{
		if (ac.targetCam == null)
		{
			this.FindCameraFor(ac);
		}
		if (this.anchorCamera == null || ac.targetCam == null)
		{
			return this.cachedTransform.localPosition;
		}
		Rect rect = ac.targetCam.rect;
		Vector3 vector = ac.targetCam.WorldToViewportPoint(ac.target.position);
		Vector3 vector2 = new Vector3(vector.x * rect.width + rect.x, vector.y * rect.height + rect.y, vector.z);
		vector2 = this.mCam.ViewportToWorldPoint(vector2);
		if (trans != null)
		{
			vector2 = trans.InverseTransformPoint(vector2);
		}
		vector2.x = Mathf.Floor(vector2.x + 0.5f);
		vector2.y = Mathf.Floor(vector2.y + 0.5f);
		return vector2;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00031255 File Offset: 0x0002F455
	protected virtual void OnEnable()
	{
		this.mUpdateFrame = -1;
		if (this.updateAnchors == UIRect.AnchorUpdate.OnEnable)
		{
			this.mAnchorsCached = false;
			this.mUpdateAnchors = true;
		}
		if (this.mStarted)
		{
			this.OnInit();
		}
		this.mUpdateFrame = -1;
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00031289 File Offset: 0x0002F489
	protected virtual void OnInit()
	{
		this.mChanged = true;
		this.mRootSet = false;
		this.mParentFound = false;
		if (this.parent != null)
		{
			this.mParent.mChildren.Add(this);
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x000312BF File Offset: 0x0002F4BF
	protected virtual void OnDisable()
	{
		if (this.mParent)
		{
			this.mParent.mChildren.Remove(this);
		}
		this.mParent = null;
		this.mRoot = null;
		this.mRootSet = false;
		this.mParentFound = false;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x000312FC File Offset: 0x0002F4FC
	protected virtual void Awake()
	{
		NGUITools.CheckForPrefabStage(base.gameObject);
		this.mStarted = false;
		this.mGo = base.gameObject;
		this.mTrans = base.transform;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00031328 File Offset: 0x0002F528
	protected void Start()
	{
		this.mStarted = true;
		this.OnInit();
		this.OnStart();
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00031340 File Offset: 0x0002F540
	public void Update()
	{
		if (!this.mCam)
		{
			this.ResetAndUpdateAnchors();
			this.mUpdateFrame = -1;
		}
		else if (!this.mAnchorsCached)
		{
			this.ResetAnchors();
		}
		int frameCount = Time.frameCount;
		if (this.mUpdateFrame != frameCount)
		{
			if (this.updateAnchors == UIRect.AnchorUpdate.OnUpdate || this.mUpdateAnchors)
			{
				this.UpdateAnchorsInternal(frameCount);
			}
			this.OnUpdate();
		}
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x000313A4 File Offset: 0x0002F5A4
	protected void UpdateAnchorsInternal(int frame)
	{
		this.mUpdateFrame = frame;
		this.mUpdateAnchors = false;
		bool flag = false;
		if (this.leftAnchor.target)
		{
			flag = true;
			if (this.leftAnchor.rect != null && this.leftAnchor.rect.mUpdateFrame != frame)
			{
				this.leftAnchor.rect.Update();
			}
		}
		if (this.bottomAnchor.target)
		{
			flag = true;
			if (this.bottomAnchor.rect != null && this.bottomAnchor.rect.mUpdateFrame != frame)
			{
				this.bottomAnchor.rect.Update();
			}
		}
		if (this.rightAnchor.target)
		{
			flag = true;
			if (this.rightAnchor.rect != null && this.rightAnchor.rect.mUpdateFrame != frame)
			{
				this.rightAnchor.rect.Update();
			}
		}
		if (this.topAnchor.target)
		{
			flag = true;
			if (this.topAnchor.rect != null && this.topAnchor.rect.mUpdateFrame != frame)
			{
				this.topAnchor.rect.Update();
			}
		}
		if (flag)
		{
			this.OnAnchor();
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x000314F2 File Offset: 0x0002F6F2
	public void UpdateAnchors()
	{
		if (this.isAnchored)
		{
			this.mUpdateFrame = -1;
			this.mUpdateAnchors = true;
			this.UpdateAnchorsInternal(Time.frameCount);
		}
	}

	// Token: 0x060004EE RID: 1262
	protected abstract void OnAnchor();

	// Token: 0x060004EF RID: 1263 RVA: 0x00031515 File Offset: 0x0002F715
	public void SetAnchor(Transform t)
	{
		this.leftAnchor.target = t;
		this.rightAnchor.target = t;
		this.topAnchor.target = t;
		this.bottomAnchor.target = t;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00031554 File Offset: 0x0002F754
	public void SetAnchor(GameObject go)
	{
		Transform target = (go != null) ? go.transform : null;
		this.leftAnchor.target = target;
		this.rightAnchor.target = target;
		this.topAnchor.target = target;
		this.bottomAnchor.target = target;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x000315B0 File Offset: 0x0002F7B0
	public void SetAnchor(GameObject go, int left, int bottom, int right, int top)
	{
		Transform target = (go != null) ? go.transform : null;
		this.leftAnchor.target = target;
		this.rightAnchor.target = target;
		this.topAnchor.target = target;
		this.bottomAnchor.target = target;
		this.leftAnchor.relative = 0f;
		this.rightAnchor.relative = 1f;
		this.bottomAnchor.relative = 0f;
		this.topAnchor.relative = 1f;
		this.leftAnchor.absolute = left;
		this.rightAnchor.absolute = right;
		this.bottomAnchor.absolute = bottom;
		this.topAnchor.absolute = top;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00031680 File Offset: 0x0002F880
	public void SetAnchor(GameObject go, float left, float bottom, float right, float top)
	{
		Transform target = (go != null) ? go.transform : null;
		this.leftAnchor.target = target;
		this.rightAnchor.target = target;
		this.topAnchor.target = target;
		this.bottomAnchor.target = target;
		this.leftAnchor.relative = left;
		this.rightAnchor.relative = right;
		this.bottomAnchor.relative = bottom;
		this.topAnchor.relative = top;
		this.leftAnchor.absolute = 0;
		this.rightAnchor.absolute = 0;
		this.bottomAnchor.absolute = 0;
		this.topAnchor.absolute = 0;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00031740 File Offset: 0x0002F940
	public void SetAnchor(GameObject go, float left, int leftOffset, float bottom, int bottomOffset, float right, int rightOffset, float top, int topOffset)
	{
		Transform target = (go != null) ? go.transform : null;
		this.leftAnchor.target = target;
		this.rightAnchor.target = target;
		this.topAnchor.target = target;
		this.bottomAnchor.target = target;
		this.leftAnchor.relative = left;
		this.rightAnchor.relative = right;
		this.bottomAnchor.relative = bottom;
		this.topAnchor.relative = top;
		this.leftAnchor.absolute = leftOffset;
		this.rightAnchor.absolute = rightOffset;
		this.bottomAnchor.absolute = bottomOffset;
		this.topAnchor.absolute = topOffset;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x00031804 File Offset: 0x0002FA04
	public void SetAnchor(float left, int leftOffset, float bottom, int bottomOffset, float right, int rightOffset, float top, int topOffset)
	{
		Transform parent = this.cachedTransform.parent;
		this.leftAnchor.target = parent;
		this.rightAnchor.target = parent;
		this.topAnchor.target = parent;
		this.bottomAnchor.target = parent;
		this.leftAnchor.relative = left;
		this.rightAnchor.relative = right;
		this.bottomAnchor.relative = bottom;
		this.topAnchor.relative = top;
		this.leftAnchor.absolute = leftOffset;
		this.rightAnchor.absolute = rightOffset;
		this.bottomAnchor.absolute = bottomOffset;
		this.topAnchor.absolute = topOffset;
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x000318C0 File Offset: 0x0002FAC0
	public void SetScreenRect(int left, int top, int width, int height)
	{
		this.SetAnchor(0f, left, 1f, -top - height, 0f, left + width, 1f, -top);
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x000318F4 File Offset: 0x0002FAF4
	public void ResetAnchors()
	{
		this.mAnchorsCached = true;
		this.leftAnchor.rect = (this.leftAnchor.target ? this.leftAnchor.target.GetComponent<UIRect>() : null);
		this.bottomAnchor.rect = (this.bottomAnchor.target ? this.bottomAnchor.target.GetComponent<UIRect>() : null);
		this.rightAnchor.rect = (this.rightAnchor.target ? this.rightAnchor.target.GetComponent<UIRect>() : null);
		this.topAnchor.rect = (this.topAnchor.target ? this.topAnchor.target.GetComponent<UIRect>() : null);
		this.mCam = NGUITools.FindCameraForLayer(this.cachedGameObject.layer);
		this.FindCameraFor(this.leftAnchor);
		this.FindCameraFor(this.bottomAnchor);
		this.FindCameraFor(this.rightAnchor);
		this.FindCameraFor(this.topAnchor);
		this.mUpdateAnchors = true;
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00031A15 File Offset: 0x0002FC15
	public void ResetAndUpdateAnchors()
	{
		this.ResetAnchors();
		this.UpdateAnchors();
	}

	// Token: 0x060004F8 RID: 1272
	public abstract void SetRect(float x, float y, float width, float height);

	// Token: 0x060004F9 RID: 1273 RVA: 0x00031A24 File Offset: 0x0002FC24
	private void FindCameraFor(UIRect.AnchorPoint ap)
	{
		if (ap.target == null || ap.rect != null)
		{
			ap.targetCam = null;
			return;
		}
		ap.targetCam = NGUITools.FindCameraForLayer(ap.target.gameObject.layer);
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x00031A70 File Offset: 0x0002FC70
	public virtual void ParentHasChanged()
	{
		this.mParentFound = false;
		UIRect y = NGUITools.FindInParents<UIRect>(this.cachedTransform.parent);
		if (this.mParent != y)
		{
			if (this.mParent)
			{
				this.mParent.mChildren.Remove(this);
			}
			this.mParent = y;
			if (this.mParent)
			{
				this.mParent.mChildren.Add(this);
			}
			this.mRootSet = false;
		}
	}

	// Token: 0x060004FB RID: 1275
	protected abstract void OnStart();

	// Token: 0x060004FC RID: 1276 RVA: 0x00031AEE File Offset: 0x0002FCEE
	protected virtual void OnUpdate()
	{
	}

	// Token: 0x04000554 RID: 1364
	public UIRect.AnchorPoint leftAnchor = new UIRect.AnchorPoint();

	// Token: 0x04000555 RID: 1365
	public UIRect.AnchorPoint rightAnchor = new UIRect.AnchorPoint(1f);

	// Token: 0x04000556 RID: 1366
	public UIRect.AnchorPoint bottomAnchor = new UIRect.AnchorPoint();

	// Token: 0x04000557 RID: 1367
	public UIRect.AnchorPoint topAnchor = new UIRect.AnchorPoint(1f);

	// Token: 0x04000558 RID: 1368
	public UIRect.AnchorUpdate updateAnchors = UIRect.AnchorUpdate.OnUpdate;

	// Token: 0x04000559 RID: 1369
	[NonSerialized]
	protected GameObject mGo;

	// Token: 0x0400055A RID: 1370
	[NonSerialized]
	protected Transform mTrans;

	// Token: 0x0400055B RID: 1371
	[NonSerialized]
	protected BetterList<UIRect> mChildren = new BetterList<UIRect>();

	// Token: 0x0400055C RID: 1372
	[NonSerialized]
	protected bool mChanged = true;

	// Token: 0x0400055D RID: 1373
	[NonSerialized]
	protected bool mParentFound;

	// Token: 0x0400055E RID: 1374
	[NonSerialized]
	private bool mUpdateAnchors = true;

	// Token: 0x0400055F RID: 1375
	[NonSerialized]
	private int mUpdateFrame = -1;

	// Token: 0x04000560 RID: 1376
	[NonSerialized]
	private bool mAnchorsCached;

	// Token: 0x04000561 RID: 1377
	[NonSerialized]
	private UIRoot mRoot;

	// Token: 0x04000562 RID: 1378
	[NonSerialized]
	private UIRect mParent;

	// Token: 0x04000563 RID: 1379
	[NonSerialized]
	private bool mRootSet;

	// Token: 0x04000564 RID: 1380
	[NonSerialized]
	protected Camera mCam;

	// Token: 0x04000565 RID: 1381
	protected bool mStarted;

	// Token: 0x04000566 RID: 1382
	[NonSerialized]
	public float finalAlpha = 1f;

	// Token: 0x04000567 RID: 1383
	protected static Vector3[] mSides = new Vector3[4];

	// Token: 0x020005FD RID: 1533
	[Serializable]
	public class AnchorPoint
	{
		// Token: 0x0600256C RID: 9580 RVA: 0x001FC5FC File Offset: 0x001FA7FC
		public AnchorPoint()
		{
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x001FC604 File Offset: 0x001FA804
		public AnchorPoint(float relative)
		{
			this.relative = relative;
		}

		// Token: 0x0600256E RID: 9582 RVA: 0x001FC613 File Offset: 0x001FA813
		public void Set(float relative, float absolute)
		{
			this.relative = relative;
			this.absolute = Mathf.FloorToInt(absolute + 0.5f);
		}

		// Token: 0x0600256F RID: 9583 RVA: 0x001FC62E File Offset: 0x001FA82E
		public void Set(Transform target, float relative, float absolute)
		{
			this.target = target;
			this.relative = relative;
			this.absolute = Mathf.FloorToInt(absolute + 0.5f);
		}

		// Token: 0x06002570 RID: 9584 RVA: 0x001FC650 File Offset: 0x001FA850
		public void SetToNearest(float abs0, float abs1, float abs2)
		{
			this.SetToNearest(0f, 0.5f, 1f, abs0, abs1, abs2);
		}

		// Token: 0x06002571 RID: 9585 RVA: 0x001FC66C File Offset: 0x001FA86C
		public void SetToNearest(float rel0, float rel1, float rel2, float abs0, float abs1, float abs2)
		{
			float num = Mathf.Abs(abs0);
			float num2 = Mathf.Abs(abs1);
			float num3 = Mathf.Abs(abs2);
			if (num < num2 && num < num3)
			{
				this.Set(rel0, abs0);
				return;
			}
			if (num2 < num && num2 < num3)
			{
				this.Set(rel1, abs1);
				return;
			}
			this.Set(rel2, abs2);
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x001FC6C0 File Offset: 0x001FA8C0
		public void SetHorizontal(Transform parent, float localPos)
		{
			if (this.rect)
			{
				Vector3[] sides = this.rect.GetSides(parent);
				float num = Mathf.Lerp(sides[0].x, sides[2].x, this.relative);
				this.absolute = Mathf.FloorToInt(localPos - num + 0.5f);
				return;
			}
			Vector3 vector = this.target.position;
			if (parent != null)
			{
				vector = parent.InverseTransformPoint(vector);
			}
			this.absolute = Mathf.FloorToInt(localPos - vector.x + 0.5f);
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x001FC758 File Offset: 0x001FA958
		public void SetVertical(Transform parent, float localPos)
		{
			if (this.rect)
			{
				Vector3[] sides = this.rect.GetSides(parent);
				float num = Mathf.Lerp(sides[3].y, sides[1].y, this.relative);
				this.absolute = Mathf.FloorToInt(localPos - num + 0.5f);
				return;
			}
			Vector3 vector = this.target.position;
			if (parent != null)
			{
				vector = parent.InverseTransformPoint(vector);
			}
			this.absolute = Mathf.FloorToInt(localPos - vector.y + 0.5f);
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x001FC7F0 File Offset: 0x001FA9F0
		public Vector3[] GetSides(Transform relativeTo)
		{
			if (this.target != null)
			{
				if (this.rect != null)
				{
					return this.rect.GetSides(relativeTo);
				}
				Camera component = this.target.GetComponent<Camera>();
				if (component != null)
				{
					return component.GetSides(relativeTo);
				}
			}
			return null;
		}

		// Token: 0x04004DB5 RID: 19893
		public Transform target;

		// Token: 0x04004DB6 RID: 19894
		public float relative;

		// Token: 0x04004DB7 RID: 19895
		public int absolute;

		// Token: 0x04004DB8 RID: 19896
		[NonSerialized]
		public UIRect rect;

		// Token: 0x04004DB9 RID: 19897
		[NonSerialized]
		public Camera targetCam;
	}

	// Token: 0x020005FE RID: 1534
	[DoNotObfuscateNGUI]
	public enum AnchorUpdate
	{
		// Token: 0x04004DBB RID: 19899
		OnEnable,
		// Token: 0x04004DBC RID: 19900
		OnUpdate,
		// Token: 0x04004DBD RID: 19901
		OnStart
	}
}
