using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Anchor")]
public class UIAnchor : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum Side
	{
		BottomLeft = 0,
		Left = 1,
		TopLeft = 2,
		Top = 3,
		TopRight = 4,
		Right = 5,
		BottomRight = 6,
		Bottom = 7,
		Center = 8
	}

	public Camera uiCamera;

	public GameObject container;

	public Side side = Side.Center;

	public bool runOnlyOnce = true;

	public Vector2 relativeOffset = Vector2.zero;

	public Vector2 pixelOffset = Vector2.zero;

	[HideInInspector]
	[SerializeField]
	private UIWidget widgetContainer;

	private Transform mTrans;

	private Animation mAnim;

	private Rect mRect;

	private UIRoot mRoot;

	private bool mStarted;

	private void OnEnable()
	{
		mTrans = base.transform;
		mAnim = GetComponent<Animation>();
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Combine(UICamera.onScreenResize, new UICamera.OnScreenResize(ScreenSizeChanged));
	}

	private void OnDisable()
	{
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Remove(UICamera.onScreenResize, new UICamera.OnScreenResize(ScreenSizeChanged));
	}

	private void ScreenSizeChanged()
	{
		if (mStarted && runOnlyOnce)
		{
			Update();
		}
	}

	private void Start()
	{
		if (container == null && widgetContainer != null)
		{
			container = widgetContainer.gameObject;
			widgetContainer = null;
		}
		mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		if (uiCamera == null)
		{
			uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		Update();
		mStarted = true;
	}

	private void Update()
	{
		if ((mAnim != null && mAnim.enabled && mAnim.isPlaying) || mTrans == null)
		{
			return;
		}
		bool flag = false;
		UIWidget uIWidget = ((container == null) ? null : container.GetComponent<UIWidget>());
		UIPanel uIPanel = ((container == null && uIWidget == null) ? null : container.GetComponent<UIPanel>());
		if (uIWidget != null)
		{
			Bounds bounds = uIWidget.CalculateBounds(container.transform.parent);
			mRect.x = bounds.min.x;
			mRect.y = bounds.min.y;
			mRect.width = bounds.size.x;
			mRect.height = bounds.size.y;
		}
		else if (uIPanel != null)
		{
			if (uIPanel.clipping == UIDrawCall.Clipping.None)
			{
				float num = ((mRoot != null) ? ((float)mRoot.activeHeight / (float)Screen.height * 0.5f) : 0.5f);
				mRect.xMin = (float)(-Screen.width) * num;
				mRect.yMin = (float)(-Screen.height) * num;
				mRect.xMax = 0f - mRect.xMin;
				mRect.yMax = 0f - mRect.yMin;
			}
			else
			{
				Vector4 finalClipRegion = uIPanel.finalClipRegion;
				mRect.x = finalClipRegion.x - finalClipRegion.z * 0.5f;
				mRect.y = finalClipRegion.y - finalClipRegion.w * 0.5f;
				mRect.width = finalClipRegion.z;
				mRect.height = finalClipRegion.w;
			}
		}
		else if (container != null)
		{
			Transform parent = container.transform.parent;
			Bounds bounds2 = ((parent != null) ? NGUIMath.CalculateRelativeWidgetBounds(parent, container.transform) : NGUIMath.CalculateRelativeWidgetBounds(container.transform));
			mRect.x = bounds2.min.x;
			mRect.y = bounds2.min.y;
			mRect.width = bounds2.size.x;
			mRect.height = bounds2.size.y;
		}
		else
		{
			if (!(uiCamera != null))
			{
				return;
			}
			flag = true;
			mRect = uiCamera.pixelRect;
		}
		float x = (mRect.xMin + mRect.xMax) * 0.5f;
		float y = (mRect.yMin + mRect.yMax) * 0.5f;
		Vector3 vector = new Vector3(x, y, 0f);
		if (side != Side.Center)
		{
			if (side == Side.Right || side == Side.TopRight || side == Side.BottomRight)
			{
				vector.x = mRect.xMax;
			}
			else if (side == Side.Top || side == Side.Center || side == Side.Bottom)
			{
				vector.x = x;
			}
			else
			{
				vector.x = mRect.xMin;
			}
			if (side == Side.Top || side == Side.TopRight || side == Side.TopLeft)
			{
				vector.y = mRect.yMax;
			}
			else if (side == Side.Left || side == Side.Center || side == Side.Right)
			{
				vector.y = y;
			}
			else
			{
				vector.y = mRect.yMin;
			}
		}
		float width = mRect.width;
		float height = mRect.height;
		vector.x += pixelOffset.x + relativeOffset.x * width;
		vector.y += pixelOffset.y + relativeOffset.y * height;
		if (flag)
		{
			if (uiCamera.orthographic)
			{
				vector.x = Mathf.Round(vector.x);
				vector.y = Mathf.Round(vector.y);
			}
			vector.z = uiCamera.WorldToScreenPoint(mTrans.position).z;
			vector = uiCamera.ScreenToWorldPoint(vector);
		}
		else
		{
			vector.x = Mathf.Round(vector.x);
			vector.y = Mathf.Round(vector.y);
			if (uIPanel != null)
			{
				vector = uIPanel.cachedTransform.TransformPoint(vector);
			}
			else if (container != null)
			{
				Transform parent2 = container.transform.parent;
				if (parent2 != null)
				{
					vector = parent2.TransformPoint(vector);
				}
			}
			vector.z = mTrans.position.z;
		}
		if (flag && uiCamera.orthographic && mTrans.parent != null)
		{
			vector = mTrans.parent.InverseTransformPoint(vector);
			vector.x = Mathf.RoundToInt(vector.x);
			vector.y = Mathf.RoundToInt(vector.y);
			if (mTrans.localPosition != vector)
			{
				mTrans.localPosition = vector;
			}
		}
		else if (mTrans.position != vector)
		{
			mTrans.position = vector;
		}
		if (runOnlyOnce && Application.isPlaying)
		{
			base.enabled = false;
		}
	}
}
