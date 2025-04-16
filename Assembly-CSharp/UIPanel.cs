using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Panel")]
public class UIPanel : UIRect
{
	[DoNotObfuscateNGUI]
	public enum RenderQueue
	{
		Automatic = 0,
		StartAt = 1,
		Explicit = 2
	}

	public delegate void OnGeometryUpdated();

	public delegate void OnClippingMoved(UIPanel panel);

	public delegate Material OnCreateMaterial(UIWidget widget, Material mat);

	public static List<UIPanel> list = new List<UIPanel>();

	public OnGeometryUpdated onGeometryUpdated;

	public bool showInPanelTool = true;

	public bool generateNormals;

	public bool generateUV2;

	public UIDrawCall.ShadowMode shadowMode;

	public bool widgetsAreStatic;

	public bool cullWhileDragging = true;

	public bool alwaysOnScreen;

	public bool anchorOffset;

	public bool softBorderPadding = true;

	public RenderQueue renderQueue;

	public int startingRenderQueue = 3000;

	[NonSerialized]
	public List<UIWidget> widgets = new List<UIWidget>();

	[NonSerialized]
	public List<UIDrawCall> drawCalls = new List<UIDrawCall>();

	[NonSerialized]
	public Matrix4x4 worldToLocal = Matrix4x4.identity;

	[NonSerialized]
	public Vector4 drawCallClipRange = new Vector4(0f, 0f, 1f, 1f);

	public OnClippingMoved onClipMove;

	public OnCreateMaterial onCreateMaterial;

	public UIDrawCall.OnCreateDrawCall onCreateDrawCall;

	[HideInInspector]
	[SerializeField]
	private Texture2D mClipTexture;

	[HideInInspector]
	[SerializeField]
	private float mAlpha = 1f;

	[HideInInspector]
	[SerializeField]
	private UIDrawCall.Clipping mClipping;

	[HideInInspector]
	[SerializeField]
	private Vector4 mClipRange = new Vector4(0f, 0f, 300f, 200f);

	[HideInInspector]
	[SerializeField]
	private Vector2 mClipSoftness = new Vector2(4f, 4f);

	[HideInInspector]
	[SerializeField]
	private int mDepth;

	[HideInInspector]
	[SerializeField]
	private int mSortingOrder;

	[HideInInspector]
	[SerializeField]
	private string mSortingLayerName;

	private bool mRebuild;

	private bool mResized;

	[SerializeField]
	private Vector2 mClipOffset = Vector2.zero;

	private int mMatrixFrame = -1;

	private int mAlphaFrameID;

	private int mLayer = -1;

	private static float[] mTemp = new float[4];

	private Vector2 mMin = Vector2.zero;

	private Vector2 mMax = Vector2.zero;

	private bool mSortWidgets;

	private bool mUpdateScroll;

	public bool useSortingOrder;

	private UIPanel mParentPanel;

	private static Vector3[] mCorners = new Vector3[4];

	private static int mUpdateFrame = -1;

	[NonSerialized]
	private bool mHasMoved;

	private UIDrawCall.OnRenderCallback mOnRender;

	private bool mForced;

	public string sortingLayerName
	{
		get
		{
			return mSortingLayerName;
		}
		set
		{
			if (mSortingLayerName != value)
			{
				mSortingLayerName = value;
				UpdateDrawCalls(list.IndexOf(this));
			}
		}
	}

	public static int nextUnusedDepth
	{
		get
		{
			int num = int.MinValue;
			int i = 0;
			for (int count = list.Count; i < count; i++)
			{
				num = Mathf.Max(num, list[i].depth);
			}
			if (num != int.MinValue)
			{
				return num + 1;
			}
			return 0;
		}
	}

	public override bool canBeAnchored => mClipping != UIDrawCall.Clipping.None;

	public override float alpha
	{
		get
		{
			return mAlpha;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (mAlpha != num)
			{
				bool flag = mAlpha > 0.001f;
				mAlphaFrameID = -1;
				mResized = true;
				mAlpha = num;
				int i = 0;
				for (int count = drawCalls.Count; i < count; i++)
				{
					drawCalls[i].isDirty = true;
				}
				Invalidate(!flag && mAlpha > 0.001f);
			}
		}
	}

	public int depth
	{
		get
		{
			return mDepth;
		}
		set
		{
			if (mDepth != value)
			{
				mDepth = value;
				list.Sort(CompareFunc);
			}
		}
	}

	public int sortingOrder
	{
		get
		{
			return mSortingOrder;
		}
		set
		{
			if (mSortingOrder != value)
			{
				mSortingOrder = value;
				UpdateDrawCalls(list.IndexOf(this));
			}
		}
	}

	public float width => GetViewSize().x;

	public float height => GetViewSize().y;

	public bool halfPixelOffset => false;

	public bool usedForUI
	{
		get
		{
			if (base.anchorCamera != null)
			{
				return mCam.orthographic;
			}
			return false;
		}
	}

	public Vector3 drawCallOffset
	{
		get
		{
			if (base.anchorCamera != null && mCam.orthographic)
			{
				Vector2 windowSize = GetWindowSize();
				float num = ((base.root != null) ? base.root.pixelSizeAdjustment : 1f) / windowSize.y / mCam.orthographicSize;
				bool flag = false;
				bool flag2 = false;
				if ((Mathf.RoundToInt(windowSize.x) & 1) == 1)
				{
					flag = !flag;
				}
				if ((Mathf.RoundToInt(windowSize.y) & 1) == 1)
				{
					flag2 = !flag2;
				}
				return new Vector3(flag ? (0f - num) : 0f, flag2 ? num : 0f);
			}
			return Vector3.zero;
		}
	}

	public UIDrawCall.Clipping clipping
	{
		get
		{
			return mClipping;
		}
		set
		{
			if (mClipping != value)
			{
				mResized = true;
				mClipping = value;
				mMatrixFrame = -1;
			}
		}
	}

	public UIPanel parentPanel => mParentPanel;

	public int clipCount
	{
		get
		{
			int num = 0;
			UIPanel uIPanel = this;
			while (uIPanel != null)
			{
				if (uIPanel.mClipping == UIDrawCall.Clipping.SoftClip || uIPanel.mClipping == UIDrawCall.Clipping.TextureMask)
				{
					num++;
				}
				uIPanel = uIPanel.mParentPanel;
			}
			return num;
		}
	}

	public bool hasClipping
	{
		get
		{
			if (mClipping != UIDrawCall.Clipping.SoftClip)
			{
				return mClipping == UIDrawCall.Clipping.TextureMask;
			}
			return true;
		}
	}

	public bool hasCumulativeClipping => clipCount != 0;

	[Obsolete("Use 'hasClipping' or 'hasCumulativeClipping' instead")]
	public bool clipsChildren => hasCumulativeClipping;

	public Vector2 clipOffset
	{
		get
		{
			return mClipOffset;
		}
		set
		{
			if (Mathf.Abs(mClipOffset.x - value.x) > 0.001f || Mathf.Abs(mClipOffset.y - value.y) > 0.001f)
			{
				mClipOffset = value;
				InvalidateClipping();
				if (onClipMove != null)
				{
					onClipMove(this);
				}
			}
		}
	}

	public Texture2D clipTexture
	{
		get
		{
			return mClipTexture;
		}
		set
		{
			if (mClipTexture != value)
			{
				mClipTexture = value;
			}
		}
	}

	[Obsolete("Use 'finalClipRegion' or 'baseClipRegion' instead")]
	public Vector4 clipRange
	{
		get
		{
			return baseClipRegion;
		}
		set
		{
			baseClipRegion = value;
		}
	}

	public Vector4 baseClipRegion
	{
		get
		{
			return mClipRange;
		}
		set
		{
			if (Mathf.Abs(mClipRange.x - value.x) > 0.001f || Mathf.Abs(mClipRange.y - value.y) > 0.001f || Mathf.Abs(mClipRange.z - value.z) > 0.001f || Mathf.Abs(mClipRange.w - value.w) > 0.001f)
			{
				mResized = true;
				mClipRange = value;
				mMatrixFrame = -1;
				UIScrollView component = GetComponent<UIScrollView>();
				if (component != null)
				{
					component.UpdatePosition();
				}
				if (onClipMove != null)
				{
					onClipMove(this);
				}
			}
		}
	}

	public Vector4 finalClipRegion
	{
		get
		{
			Vector2 viewSize = GetViewSize();
			if (mClipping != UIDrawCall.Clipping.None)
			{
				return new Vector4(mClipRange.x + mClipOffset.x, mClipRange.y + mClipOffset.y, viewSize.x, viewSize.y);
			}
			Vector4 result = new Vector4(0f, 0f, viewSize.x, viewSize.y);
			Vector3 vector = base.anchorCamera.WorldToScreenPoint(base.cachedTransform.position);
			vector.x -= viewSize.x * 0.5f;
			vector.y -= viewSize.y * 0.5f;
			result.x -= vector.x;
			result.y -= vector.y;
			return result;
		}
	}

	public Vector2 clipSoftness
	{
		get
		{
			return mClipSoftness;
		}
		set
		{
			if (mClipSoftness != value)
			{
				mClipSoftness = value;
			}
		}
	}

	public override Vector3[] localCorners
	{
		get
		{
			if (mClipping == UIDrawCall.Clipping.None)
			{
				Vector3[] array = worldCorners;
				Transform transform = base.cachedTransform;
				for (int i = 0; i < 4; i++)
				{
					array[i] = transform.InverseTransformPoint(array[i]);
				}
				return array;
			}
			float num = mClipOffset.x + mClipRange.x - 0.5f * mClipRange.z;
			float num2 = mClipOffset.y + mClipRange.y - 0.5f * mClipRange.w;
			float x = num + mClipRange.z;
			float y = num2 + mClipRange.w;
			mCorners[0] = new Vector3(num, num2);
			mCorners[1] = new Vector3(num, y);
			mCorners[2] = new Vector3(x, y);
			mCorners[3] = new Vector3(x, num2);
			return mCorners;
		}
	}

	public override Vector3[] worldCorners
	{
		get
		{
			if (mClipping != UIDrawCall.Clipping.None)
			{
				float num = mClipOffset.x + mClipRange.x - 0.5f * mClipRange.z;
				float num2 = mClipOffset.y + mClipRange.y - 0.5f * mClipRange.w;
				float x = num + mClipRange.z;
				float y = num2 + mClipRange.w;
				Transform transform = base.cachedTransform;
				mCorners[0] = transform.TransformPoint(num, num2, 0f);
				mCorners[1] = transform.TransformPoint(num, y, 0f);
				mCorners[2] = transform.TransformPoint(x, y, 0f);
				mCorners[3] = transform.TransformPoint(x, num2, 0f);
			}
			else
			{
				if (base.anchorCamera != null)
				{
					return mCam.GetWorldCorners(base.cameraRayDistance);
				}
				Vector2 viewSize = GetViewSize();
				float num3 = -0.5f * viewSize.x;
				float num4 = -0.5f * viewSize.y;
				float x2 = num3 + viewSize.x;
				float y2 = num4 + viewSize.y;
				mCorners[0] = new Vector3(num3, num4);
				mCorners[1] = new Vector3(num3, y2);
				mCorners[2] = new Vector3(x2, y2);
				mCorners[3] = new Vector3(x2, num4);
				if (anchorOffset && (mCam == null || mCam.transform.parent != base.cachedTransform))
				{
					Vector3 position = base.cachedTransform.position;
					for (int i = 0; i < 4; i++)
					{
						mCorners[i] += position;
					}
				}
			}
			return mCorners;
		}
	}

	public static int CompareFunc(UIPanel a, UIPanel b)
	{
		if (a != b && a != null && b != null)
		{
			if (a.mDepth < b.mDepth)
			{
				return -1;
			}
			if (a.mDepth > b.mDepth)
			{
				return 1;
			}
			if (a.GetInstanceID() >= b.GetInstanceID())
			{
				return 1;
			}
			return -1;
		}
		return 0;
	}

	private void InvalidateClipping()
	{
		mResized = true;
		mMatrixFrame = -1;
		int i = 0;
		for (int count = list.Count; i < count; i++)
		{
			UIPanel uIPanel = list[i];
			if (uIPanel != this && uIPanel.parentPanel == this)
			{
				uIPanel.InvalidateClipping();
			}
		}
	}

	public override Vector3[] GetSides(Transform relativeTo)
	{
		if (mClipping != UIDrawCall.Clipping.None)
		{
			float num = mClipOffset.x + mClipRange.x - 0.5f * mClipRange.z;
			float num2 = mClipOffset.y + mClipRange.y - 0.5f * mClipRange.w;
			float num3 = num + mClipRange.z;
			float num4 = num2 + mClipRange.w;
			float x = (num + num3) * 0.5f;
			float y = (num2 + num4) * 0.5f;
			Transform transform = base.cachedTransform;
			UIRect.mSides[0] = transform.TransformPoint(num, y, 0f);
			UIRect.mSides[1] = transform.TransformPoint(x, num4, 0f);
			UIRect.mSides[2] = transform.TransformPoint(num3, y, 0f);
			UIRect.mSides[3] = transform.TransformPoint(x, num2, 0f);
			if (relativeTo != null)
			{
				for (int i = 0; i < 4; i++)
				{
					UIRect.mSides[i] = relativeTo.InverseTransformPoint(UIRect.mSides[i]);
				}
			}
			return UIRect.mSides;
		}
		if (base.anchorCamera != null && anchorOffset)
		{
			Vector3[] sides = mCam.GetSides(base.cameraRayDistance);
			Vector3 position = base.cachedTransform.position;
			for (int j = 0; j < 4; j++)
			{
				sides[j] += position;
			}
			if (relativeTo != null)
			{
				for (int k = 0; k < 4; k++)
				{
					sides[k] = relativeTo.InverseTransformPoint(sides[k]);
				}
			}
			return sides;
		}
		return base.GetSides(relativeTo);
	}

	public override void Invalidate(bool includeChildren)
	{
		mAlphaFrameID = -1;
		base.Invalidate(includeChildren);
	}

	public override float CalculateFinalAlpha(int frameID)
	{
		if (mAlphaFrameID != frameID)
		{
			mAlphaFrameID = frameID;
			UIRect uIRect = base.parent;
			finalAlpha = ((base.parent != null) ? (uIRect.CalculateFinalAlpha(frameID) * mAlpha) : mAlpha);
		}
		return finalAlpha;
	}

	public override void SetRect(float x, float y, float width, float height)
	{
		int num = Mathf.FloorToInt(width + 0.5f);
		int num2 = Mathf.FloorToInt(height + 0.5f);
		num = num >> 1 << 1;
		num2 = num2 >> 1 << 1;
		Transform transform = base.cachedTransform;
		Vector3 localPosition = transform.localPosition;
		localPosition.x = Mathf.Floor(x + 0.5f);
		localPosition.y = Mathf.Floor(y + 0.5f);
		if (num < 2)
		{
			num = 2;
		}
		if (num2 < 2)
		{
			num2 = 2;
		}
		baseClipRegion = new Vector4(localPosition.x, localPosition.y, num, num2);
		if (base.isAnchored)
		{
			transform = transform.parent;
			if ((bool)leftAnchor.target)
			{
				leftAnchor.SetHorizontal(transform, x);
			}
			if ((bool)rightAnchor.target)
			{
				rightAnchor.SetHorizontal(transform, x + width);
			}
			if ((bool)bottomAnchor.target)
			{
				bottomAnchor.SetVertical(transform, y);
			}
			if ((bool)topAnchor.target)
			{
				topAnchor.SetVertical(transform, y + height);
			}
		}
	}

	public bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		UpdateTransformMatrix();
		a = worldToLocal.MultiplyPoint3x4(a);
		b = worldToLocal.MultiplyPoint3x4(b);
		c = worldToLocal.MultiplyPoint3x4(c);
		d = worldToLocal.MultiplyPoint3x4(d);
		mTemp[0] = a.x;
		mTemp[1] = b.x;
		mTemp[2] = c.x;
		mTemp[3] = d.x;
		float num = Mathf.Min(mTemp);
		float num2 = Mathf.Max(mTemp);
		mTemp[0] = a.y;
		mTemp[1] = b.y;
		mTemp[2] = c.y;
		mTemp[3] = d.y;
		float num3 = Mathf.Min(mTemp);
		float num4 = Mathf.Max(mTemp);
		if (num2 < mMin.x)
		{
			return false;
		}
		if (num4 < mMin.y)
		{
			return false;
		}
		if (num > mMax.x)
		{
			return false;
		}
		if (num3 > mMax.y)
		{
			return false;
		}
		return true;
	}

	public bool IsVisible(Vector3 worldPos)
	{
		if (mAlpha < 0.001f)
		{
			return false;
		}
		if (mClipping == UIDrawCall.Clipping.None || mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
		{
			return true;
		}
		UpdateTransformMatrix();
		Vector3 vector = worldToLocal.MultiplyPoint3x4(worldPos);
		if (vector.x < mMin.x)
		{
			return false;
		}
		if (vector.y < mMin.y)
		{
			return false;
		}
		if (vector.x > mMax.x)
		{
			return false;
		}
		if (vector.y > mMax.y)
		{
			return false;
		}
		return true;
	}

	public bool IsVisible(UIWidget w)
	{
		UIPanel uIPanel = this;
		Vector3[] array = null;
		while (uIPanel != null)
		{
			if ((uIPanel.mClipping == UIDrawCall.Clipping.None || uIPanel.mClipping == UIDrawCall.Clipping.ConstrainButDontClip) && !w.hideIfOffScreen)
			{
				uIPanel = uIPanel.mParentPanel;
				continue;
			}
			if (array == null)
			{
				array = w.worldCorners;
			}
			if (!uIPanel.IsVisible(array[0], array[1], array[2], array[3]))
			{
				return false;
			}
			uIPanel = uIPanel.mParentPanel;
		}
		return true;
	}

	public bool Affects(UIWidget w)
	{
		if (w == null)
		{
			return false;
		}
		UIPanel panel = w.panel;
		if (panel == null)
		{
			return false;
		}
		UIPanel uIPanel = this;
		while (uIPanel != null)
		{
			if (uIPanel == panel)
			{
				return true;
			}
			if (!uIPanel.hasCumulativeClipping)
			{
				return false;
			}
			uIPanel = uIPanel.mParentPanel;
		}
		return false;
	}

	[ContextMenu("Force Refresh")]
	public void RebuildAllDrawCalls()
	{
		mRebuild = true;
	}

	public void SetDirty()
	{
		int i = 0;
		for (int count = drawCalls.Count; i < count; i++)
		{
			drawCalls[i].isDirty = true;
		}
		Invalidate(includeChildren: true);
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private void FindParent()
	{
		Transform transform = base.cachedTransform.parent;
		mParentPanel = ((transform != null) ? NGUITools.FindInParents<UIPanel>(transform.gameObject) : null);
	}

	public override void ParentHasChanged()
	{
		base.ParentHasChanged();
		FindParent();
	}

	protected override void OnStart()
	{
		mLayer = base.cachedGameObject.layer;
	}

	protected override void OnEnable()
	{
		mRebuild = true;
		mAlphaFrameID = -1;
		mMatrixFrame = -1;
		OnStart();
		base.OnEnable();
		mMatrixFrame = -1;
	}

	protected override void OnInit()
	{
		if (list.Contains(this))
		{
			return;
		}
		base.OnInit();
		FindParent();
		if (GetComponent<Rigidbody>() == null && mParentPanel == null)
		{
			UICamera uICamera = ((base.anchorCamera != null) ? mCam.GetComponent<UICamera>() : null);
			if (uICamera != null && (uICamera.eventType == UICamera.EventType.UI_3D || uICamera.eventType == UICamera.EventType.World_3D))
			{
				Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
				rigidbody.isKinematic = true;
				rigidbody.useGravity = false;
			}
		}
		mRebuild = true;
		mAlphaFrameID = -1;
		mMatrixFrame = -1;
		list.Add(this);
		list.Sort(CompareFunc);
	}

	protected override void OnDisable()
	{
		int i = 0;
		for (int count = drawCalls.Count; i < count; i++)
		{
			UIDrawCall uIDrawCall = drawCalls[i];
			if (uIDrawCall != null)
			{
				UIDrawCall.Destroy(uIDrawCall);
			}
		}
		drawCalls.Clear();
		list.Remove(this);
		mAlphaFrameID = -1;
		mMatrixFrame = -1;
		if (list.Count == 0)
		{
			UIDrawCall.ReleaseAll();
			mUpdateFrame = -1;
		}
		base.OnDisable();
	}

	private void UpdateTransformMatrix()
	{
		int frameCount = Time.frameCount;
		if (mHasMoved || mMatrixFrame != frameCount)
		{
			mMatrixFrame = frameCount;
			worldToLocal = base.cachedTransform.worldToLocalMatrix;
			Vector2 vector = GetViewSize() * 0.5f;
			float num = mClipOffset.x + mClipRange.x;
			float num2 = mClipOffset.y + mClipRange.y;
			mMin.x = num - vector.x;
			mMin.y = num2 - vector.y;
			mMax.x = num + vector.x;
			mMax.y = num2 + vector.y;
		}
	}

	protected override void OnAnchor()
	{
		if (mClipping == UIDrawCall.Clipping.None)
		{
			return;
		}
		Transform obj = base.cachedTransform;
		Transform transform = obj.parent;
		Vector2 viewSize = GetViewSize();
		Vector2 vector = obj.localPosition;
		float num;
		float num2;
		float num3;
		float num4;
		if (leftAnchor.target == bottomAnchor.target && leftAnchor.target == rightAnchor.target && leftAnchor.target == topAnchor.target)
		{
			Vector3[] sides = leftAnchor.GetSides(transform);
			if (sides != null)
			{
				num = NGUIMath.Lerp(sides[0].x, sides[2].x, leftAnchor.relative) + (float)leftAnchor.absolute;
				num2 = NGUIMath.Lerp(sides[0].x, sides[2].x, rightAnchor.relative) + (float)rightAnchor.absolute;
				num3 = NGUIMath.Lerp(sides[3].y, sides[1].y, bottomAnchor.relative) + (float)bottomAnchor.absolute;
				num4 = NGUIMath.Lerp(sides[3].y, sides[1].y, topAnchor.relative) + (float)topAnchor.absolute;
			}
			else
			{
				Vector2 vector2 = GetLocalPos(leftAnchor, transform);
				num = vector2.x + (float)leftAnchor.absolute;
				num3 = vector2.y + (float)bottomAnchor.absolute;
				num2 = vector2.x + (float)rightAnchor.absolute;
				num4 = vector2.y + (float)topAnchor.absolute;
			}
		}
		else
		{
			if ((bool)leftAnchor.target)
			{
				Vector3[] sides2 = leftAnchor.GetSides(transform);
				num = ((sides2 == null) ? (GetLocalPos(leftAnchor, transform).x + (float)leftAnchor.absolute) : (NGUIMath.Lerp(sides2[0].x, sides2[2].x, leftAnchor.relative) + (float)leftAnchor.absolute));
			}
			else
			{
				num = mClipRange.x - 0.5f * viewSize.x;
			}
			if ((bool)rightAnchor.target)
			{
				Vector3[] sides3 = rightAnchor.GetSides(transform);
				num2 = ((sides3 == null) ? (GetLocalPos(rightAnchor, transform).x + (float)rightAnchor.absolute) : (NGUIMath.Lerp(sides3[0].x, sides3[2].x, rightAnchor.relative) + (float)rightAnchor.absolute));
			}
			else
			{
				num2 = mClipRange.x + 0.5f * viewSize.x;
			}
			if ((bool)bottomAnchor.target)
			{
				Vector3[] sides4 = bottomAnchor.GetSides(transform);
				num3 = ((sides4 == null) ? (GetLocalPos(bottomAnchor, transform).y + (float)bottomAnchor.absolute) : (NGUIMath.Lerp(sides4[3].y, sides4[1].y, bottomAnchor.relative) + (float)bottomAnchor.absolute));
			}
			else
			{
				num3 = mClipRange.y - 0.5f * viewSize.y;
			}
			if ((bool)topAnchor.target)
			{
				Vector3[] sides5 = topAnchor.GetSides(transform);
				num4 = ((sides5 == null) ? (GetLocalPos(topAnchor, transform).y + (float)topAnchor.absolute) : (NGUIMath.Lerp(sides5[3].y, sides5[1].y, topAnchor.relative) + (float)topAnchor.absolute));
			}
			else
			{
				num4 = mClipRange.y + 0.5f * viewSize.y;
			}
		}
		num -= vector.x + mClipOffset.x;
		num2 -= vector.x + mClipOffset.x;
		num3 -= vector.y + mClipOffset.y;
		num4 -= vector.y + mClipOffset.y;
		float x = Mathf.Lerp(num, num2, 0.5f);
		float y = Mathf.Lerp(num3, num4, 0.5f);
		float num5 = num2 - num;
		float num6 = num4 - num3;
		float num7 = Mathf.Max(2f, mClipSoftness.x);
		float num8 = Mathf.Max(2f, mClipSoftness.y);
		if (num5 < num7)
		{
			num5 = num7;
		}
		if (num6 < num8)
		{
			num6 = num8;
		}
		baseClipRegion = new Vector4(x, y, num5, num6);
	}

	private void LateUpdate()
	{
		if (mUpdateFrame == Time.frameCount)
		{
			return;
		}
		mUpdateFrame = Time.frameCount;
		int i = 0;
		for (int count = list.Count; i < count; i++)
		{
			list[i].UpdateSelf();
		}
		int num = 3000;
		int j = 0;
		for (int count2 = list.Count; j < count2; j++)
		{
			UIPanel uIPanel = list[j];
			if (uIPanel.renderQueue == RenderQueue.Automatic)
			{
				uIPanel.startingRenderQueue = num;
				uIPanel.UpdateDrawCalls(j);
				num += uIPanel.drawCalls.Count;
			}
			else if (uIPanel.renderQueue == RenderQueue.StartAt)
			{
				uIPanel.UpdateDrawCalls(j);
				if (uIPanel.drawCalls.Count != 0)
				{
					num = Mathf.Max(num, uIPanel.startingRenderQueue + uIPanel.drawCalls.Count);
				}
			}
			else
			{
				uIPanel.UpdateDrawCalls(j);
				if (uIPanel.drawCalls.Count != 0)
				{
					num = Mathf.Max(num, uIPanel.startingRenderQueue + 1);
				}
			}
		}
	}

	private void UpdateSelf()
	{
		mHasMoved = base.cachedTransform.hasChanged;
		UpdateTransformMatrix();
		UpdateLayers();
		UpdateWidgets();
		if (mRebuild)
		{
			mRebuild = false;
			FillAllDrawCalls();
		}
		else
		{
			bool needsCulling = mCam == null || mCam.useOcclusionCulling;
			int num = 0;
			while (num < drawCalls.Count)
			{
				UIDrawCall uIDrawCall = drawCalls[num];
				if (uIDrawCall.isDirty && !FillDrawCall(uIDrawCall, needsCulling))
				{
					UIDrawCall.Destroy(uIDrawCall);
					drawCalls.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}
		if (mUpdateScroll)
		{
			mUpdateScroll = false;
			UIScrollView component = GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars();
			}
		}
		if (mHasMoved)
		{
			mHasMoved = false;
			mTrans.hasChanged = false;
		}
	}

	public void SortWidgets()
	{
		mSortWidgets = false;
		widgets.Sort(UIWidget.PanelCompareFunc);
	}

	private void FillAllDrawCalls()
	{
		for (int i = 0; i < drawCalls.Count; i++)
		{
			UIDrawCall.Destroy(drawCalls[i]);
		}
		drawCalls.Clear();
		Material material = null;
		Texture texture = null;
		Shader shader = null;
		UIDrawCall uIDrawCall = null;
		int num = 0;
		bool needsBounds = mCam == null || mCam.useOcclusionCulling;
		if (mSortWidgets)
		{
			SortWidgets();
		}
		for (int j = 0; j < widgets.Count; j++)
		{
			UIWidget uIWidget = widgets[j];
			if (uIWidget.isVisible && uIWidget.hasVertices)
			{
				Material material2 = uIWidget.material;
				if (onCreateMaterial != null)
				{
					material2 = onCreateMaterial(uIWidget, material2);
				}
				Texture mainTexture = uIWidget.mainTexture;
				Shader shader2 = uIWidget.shader;
				if (material != material2 || texture != mainTexture || shader != shader2)
				{
					if (uIDrawCall != null && uIDrawCall.verts.Count != 0)
					{
						drawCalls.Add(uIDrawCall);
						uIDrawCall.UpdateGeometry(num, needsBounds);
						uIDrawCall.onRender = mOnRender;
						mOnRender = null;
						num = 0;
						uIDrawCall = null;
					}
					material = material2;
					texture = mainTexture;
					shader = shader2;
				}
				if (!(material != null) && !(shader != null) && !(texture != null))
				{
					continue;
				}
				if (uIDrawCall == null)
				{
					if (true)
					{
						uIDrawCall = UIDrawCall.Create(this, material, texture, shader);
						uIDrawCall.depthStart = uIWidget.depth;
						uIDrawCall.depthEnd = uIDrawCall.depthStart;
						uIDrawCall.panel = this;
						uIDrawCall.onCreateDrawCall = onCreateDrawCall;
					}
				}
				else
				{
					int num2 = uIWidget.depth;
					if (num2 < uIDrawCall.depthStart)
					{
						uIDrawCall.depthStart = num2;
					}
					if (num2 > uIDrawCall.depthEnd)
					{
						uIDrawCall.depthEnd = num2;
					}
				}
				uIWidget.drawCall = uIDrawCall;
				if (!(uIDrawCall != null))
				{
					continue;
				}
				num++;
				if (generateNormals)
				{
					uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, uIDrawCall.norms, uIDrawCall.tans, generateUV2 ? uIDrawCall.uv2 : null);
				}
				else
				{
					uIWidget.WriteToBuffers(uIDrawCall.verts, uIDrawCall.uvs, uIDrawCall.cols, null, null, generateUV2 ? uIDrawCall.uv2 : null);
				}
				if (uIWidget.mOnRender != null)
				{
					if (mOnRender == null)
					{
						mOnRender = uIWidget.mOnRender;
					}
					else
					{
						mOnRender = (UIDrawCall.OnRenderCallback)Delegate.Combine(mOnRender, uIWidget.mOnRender);
					}
				}
			}
			else
			{
				uIWidget.drawCall = null;
			}
		}
		if (uIDrawCall != null && uIDrawCall.verts.Count != 0)
		{
			drawCalls.Add(uIDrawCall);
			uIDrawCall.UpdateGeometry(num, needsBounds);
			uIDrawCall.onRender = mOnRender;
			mOnRender = null;
		}
	}

	public bool FillDrawCall(UIDrawCall dc)
	{
		bool needsCulling = mCam == null || mCam.useOcclusionCulling;
		return FillDrawCall(dc, needsCulling);
	}

	public bool FillDrawCall(UIDrawCall dc, bool needsCulling)
	{
		if (dc != null)
		{
			dc.isDirty = false;
			int num = 0;
			int num2 = 0;
			while (num2 < widgets.Count)
			{
				UIWidget uIWidget = widgets[num2];
				if (uIWidget == null)
				{
					widgets.RemoveAt(num2);
					continue;
				}
				if (uIWidget.drawCall == dc)
				{
					if (uIWidget.isVisible && uIWidget.hasVertices)
					{
						num++;
						if (generateNormals)
						{
							uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans, generateUV2 ? dc.uv2 : null);
						}
						else
						{
							uIWidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, null, null, generateUV2 ? dc.uv2 : null);
						}
						if (uIWidget.mOnRender != null)
						{
							if (mOnRender == null)
							{
								mOnRender = uIWidget.mOnRender;
							}
							else
							{
								mOnRender = (UIDrawCall.OnRenderCallback)Delegate.Combine(mOnRender, uIWidget.mOnRender);
							}
						}
					}
					else
					{
						uIWidget.drawCall = null;
					}
				}
				num2++;
			}
			if (dc.verts.Count != 0)
			{
				dc.UpdateGeometry(num, needsCulling);
				dc.onRender = mOnRender;
				mOnRender = null;
				return true;
			}
		}
		return false;
	}

	private void UpdateDrawCalls(int sortOrder)
	{
		Transform transform = base.cachedTransform;
		bool num = usedForUI;
		if (clipping != UIDrawCall.Clipping.None)
		{
			drawCallClipRange = finalClipRegion;
			drawCallClipRange.z *= 0.5f;
			drawCallClipRange.w *= 0.5f;
		}
		else
		{
			drawCallClipRange = Vector4.zero;
		}
		int num2 = Screen.width;
		int num3 = Screen.height;
		if (drawCallClipRange.z == 0f)
		{
			drawCallClipRange.z = (float)num2 * 0.5f;
		}
		if (drawCallClipRange.w == 0f)
		{
			drawCallClipRange.w = (float)num3 * 0.5f;
		}
		if (halfPixelOffset)
		{
			drawCallClipRange.x -= 0.5f;
			drawCallClipRange.y += 0.5f;
		}
		Vector3 position;
		if (num)
		{
			Transform transform2 = base.cachedTransform.parent;
			position = base.cachedTransform.localPosition;
			if (clipping != UIDrawCall.Clipping.None)
			{
				position.x = Mathf.RoundToInt(position.x);
				position.y = Mathf.RoundToInt(position.y);
			}
			if (transform2 != null)
			{
				position = transform2.TransformPoint(position);
			}
			position += drawCallOffset;
		}
		else
		{
			position = transform.position;
		}
		Quaternion rotation = transform.rotation;
		Vector3 lossyScale = transform.lossyScale;
		for (int i = 0; i < drawCalls.Count; i++)
		{
			UIDrawCall uIDrawCall = drawCalls[i];
			Transform obj = uIDrawCall.cachedTransform;
			obj.position = position;
			obj.rotation = rotation;
			obj.localScale = lossyScale;
			uIDrawCall.renderQueue = ((renderQueue == RenderQueue.Explicit) ? startingRenderQueue : (startingRenderQueue + i));
			uIDrawCall.alwaysOnScreen = alwaysOnScreen && (mClipping == UIDrawCall.Clipping.None || mClipping == UIDrawCall.Clipping.ConstrainButDontClip);
			uIDrawCall.sortingOrder = (useSortingOrder ? ((mSortingOrder == 0 && renderQueue == RenderQueue.Automatic) ? sortOrder : mSortingOrder) : 0);
			uIDrawCall.sortingLayerName = (useSortingOrder ? mSortingLayerName : null);
			uIDrawCall.clipTexture = mClipTexture;
			uIDrawCall.shadowMode = shadowMode;
		}
	}

	private void UpdateLayers()
	{
		if (mLayer == base.cachedGameObject.layer)
		{
			return;
		}
		mLayer = mGo.layer;
		int i = 0;
		for (int count = widgets.Count; i < count; i++)
		{
			UIWidget uIWidget = widgets[i];
			if ((bool)uIWidget && uIWidget.parent == this)
			{
				uIWidget.gameObject.layer = mLayer;
			}
		}
		ResetAnchors();
		for (int j = 0; j < drawCalls.Count; j++)
		{
			drawCalls[j].gameObject.layer = mLayer;
		}
	}

	private void UpdateWidgets()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = hasCumulativeClipping;
		if (!cullWhileDragging)
		{
			for (int i = 0; i < UIScrollView.list.size; i++)
			{
				UIScrollView uIScrollView = UIScrollView.list.buffer[i];
				if (uIScrollView.panel == this && uIScrollView.isDragging)
				{
					flag2 = true;
				}
			}
		}
		if (mForced != flag2)
		{
			mForced = flag2;
			mResized = true;
		}
		int frameCount = Time.frameCount;
		int j = 0;
		for (int count = widgets.Count; j < count; j++)
		{
			UIWidget uIWidget = widgets[j];
			if (!(uIWidget.panel == this) || !uIWidget.enabled)
			{
				continue;
			}
			if (uIWidget.UpdateTransform(frameCount) || mResized || (mHasMoved && !alwaysOnScreen))
			{
				bool visibleByAlpha = flag2 || uIWidget.CalculateCumulativeAlpha(frameCount) > 0.001f;
				uIWidget.UpdateVisibility(visibleByAlpha, flag2 || alwaysOnScreen || (!flag3 && !uIWidget.hideIfOffScreen) || IsVisible(uIWidget));
			}
			if (!uIWidget.UpdateGeometry(frameCount))
			{
				continue;
			}
			flag = true;
			if (!mRebuild)
			{
				if (uIWidget.drawCall != null)
				{
					uIWidget.drawCall.isDirty = true;
				}
				else
				{
					FindDrawCall(uIWidget);
				}
			}
		}
		if (flag && onGeometryUpdated != null)
		{
			onGeometryUpdated();
		}
		mResized = false;
	}

	public UIDrawCall FindDrawCall(UIWidget w)
	{
		Material material = w.material;
		Texture mainTexture = w.mainTexture;
		Shader shader = w.shader;
		int num = w.depth;
		for (int i = 0; i < drawCalls.Count; i++)
		{
			UIDrawCall uIDrawCall = drawCalls[i];
			int num2 = ((i == 0) ? int.MinValue : (drawCalls[i - 1].depthEnd + 1));
			int num3 = ((i + 1 == drawCalls.Count) ? int.MaxValue : (drawCalls[i + 1].depthStart - 1));
			if (num2 > num || num3 < num)
			{
				continue;
			}
			if (uIDrawCall.baseMaterial == material && uIDrawCall.shader == shader && uIDrawCall.mainTexture == mainTexture)
			{
				if (w.isVisible)
				{
					w.drawCall = uIDrawCall;
					if (w.hasVertices)
					{
						uIDrawCall.isDirty = true;
					}
					return uIDrawCall;
				}
			}
			else
			{
				mRebuild = true;
			}
			return null;
		}
		mRebuild = true;
		return null;
	}

	public void AddWidget(UIWidget w)
	{
		mUpdateScroll = true;
		if (widgets.Count == 0)
		{
			widgets.Add(w);
		}
		else if (mSortWidgets)
		{
			widgets.Add(w);
			SortWidgets();
		}
		else if (UIWidget.PanelCompareFunc(w, widgets[0]) == -1)
		{
			widgets.Insert(0, w);
		}
		else
		{
			int num = widgets.Count;
			while (num > 0)
			{
				if (UIWidget.PanelCompareFunc(w, widgets[--num]) != -1)
				{
					widgets.Insert(num + 1, w);
					break;
				}
			}
		}
		FindDrawCall(w);
	}

	public void RemoveWidget(UIWidget w)
	{
		if (widgets.Remove(w) && w.drawCall != null)
		{
			int num = w.depth;
			if (num == w.drawCall.depthStart || num == w.drawCall.depthEnd)
			{
				mRebuild = true;
			}
			w.drawCall.isDirty = true;
			w.drawCall = null;
		}
	}

	public void Refresh()
	{
		mRebuild = true;
		mUpdateFrame = -1;
		if (list.Count > 0)
		{
			list[0].LateUpdate();
		}
	}

	public virtual Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
	{
		Vector4 vector = finalClipRegion;
		float num = vector.z * 0.5f;
		float num2 = vector.w * 0.5f;
		Vector2 minRect = new Vector2(min.x, min.y);
		Vector2 maxRect = new Vector2(max.x, max.y);
		Vector2 minArea = new Vector2(vector.x - num, vector.y - num2);
		Vector2 maxArea = new Vector2(vector.x + num, vector.y + num2);
		if (softBorderPadding && clipping == UIDrawCall.Clipping.SoftClip)
		{
			minArea.x += mClipSoftness.x;
			minArea.y += mClipSoftness.y;
			maxArea.x -= mClipSoftness.x;
			maxArea.y -= mClipSoftness.y;
		}
		return NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
	}

	public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
	{
		Vector3 min = targetBounds.min;
		Vector3 max = targetBounds.max;
		float num = 1f;
		if (mClipping == UIDrawCall.Clipping.None)
		{
			UIRoot uIRoot = base.root;
			if (uIRoot != null)
			{
				num = uIRoot.pixelSizeAdjustment;
			}
		}
		if (num != 1f)
		{
			min /= num;
			max /= num;
		}
		Vector3 vector = CalculateConstrainOffset(min, max) * num;
		if (vector.sqrMagnitude > 0f)
		{
			if (immediate)
			{
				target.localPosition += vector;
				targetBounds.center += vector;
				SpringPosition component = target.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else
			{
				SpringPosition springPosition = SpringPosition.Begin(target.gameObject, target.localPosition + vector, 13f);
				springPosition.ignoreTimeScale = true;
				springPosition.worldSpace = false;
			}
			return true;
		}
		return false;
	}

	public bool ConstrainTargetToBounds(Transform target, bool immediate)
	{
		Bounds targetBounds = NGUIMath.CalculateRelativeWidgetBounds(base.cachedTransform, target);
		return ConstrainTargetToBounds(target, ref targetBounds, immediate);
	}

	public static UIPanel Find(Transform trans)
	{
		return Find(trans, createIfMissing: false, -1);
	}

	public static UIPanel Find(Transform trans, bool createIfMissing)
	{
		return Find(trans, createIfMissing, -1);
	}

	public static UIPanel Find(Transform trans, bool createIfMissing, int layer)
	{
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(trans);
		if (uIPanel != null)
		{
			return uIPanel;
		}
		while (trans.parent != null)
		{
			trans = trans.parent;
		}
		if (!createIfMissing)
		{
			return null;
		}
		return NGUITools.CreateUI(trans, advanced3D: false, layer);
	}

	public Vector2 GetWindowSize()
	{
		UIRoot uIRoot = base.root;
		Vector2 screenSize = NGUITools.screenSize;
		if (uIRoot != null)
		{
			screenSize *= uIRoot.GetPixelSizeAdjustment(Mathf.RoundToInt(screenSize.y));
		}
		return screenSize;
	}

	public Vector2 GetViewSize()
	{
		if (mClipping != UIDrawCall.Clipping.None)
		{
			return new Vector2(mClipRange.z, mClipRange.w);
		}
		return NGUITools.screenSize;
	}
}
