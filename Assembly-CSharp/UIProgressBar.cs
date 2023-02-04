using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Progress Bar")]
public class UIProgressBar : UIWidgetContainer
{
	[DoNotObfuscateNGUI]
	public enum FillDirection
	{
		LeftToRight = 0,
		RightToLeft = 1,
		BottomToTop = 2,
		TopToBottom = 3
	}

	public delegate void OnDragFinished();

	public static UIProgressBar current;

	public OnDragFinished onDragFinished;

	public Transform thumb;

	[HideInInspector]
	[SerializeField]
	protected UIWidget mBG;

	[HideInInspector]
	[SerializeField]
	protected UIWidget mFG;

	[HideInInspector]
	[SerializeField]
	protected float mValue = 1f;

	[HideInInspector]
	[SerializeField]
	protected FillDirection mFill;

	[NonSerialized]
	protected bool mStarted;

	[NonSerialized]
	protected Transform mTrans;

	[NonSerialized]
	protected bool mIsDirty;

	[NonSerialized]
	protected Camera mCam;

	[NonSerialized]
	protected float mOffset;

	public int numberOfSteps;

	public List<EventDelegate> onChange = new List<EventDelegate>();

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

	public Camera cachedCamera
	{
		get
		{
			if (mCam == null)
			{
				mCam = NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
			return mCam;
		}
	}

	public UIWidget foregroundWidget
	{
		get
		{
			return mFG;
		}
		set
		{
			if (mFG != value)
			{
				mFG = value;
				mIsDirty = true;
			}
		}
	}

	public UIWidget backgroundWidget
	{
		get
		{
			return mBG;
		}
		set
		{
			if (mBG != value)
			{
				mBG = value;
				mIsDirty = true;
			}
		}
	}

	public FillDirection fillDirection
	{
		get
		{
			return mFill;
		}
		set
		{
			if (mFill != value)
			{
				mFill = value;
				if (mStarted)
				{
					ForceUpdate();
				}
			}
		}
	}

	public float value
	{
		get
		{
			if (numberOfSteps > 1)
			{
				return Mathf.Round(mValue * (float)(numberOfSteps - 1)) / (float)(numberOfSteps - 1);
			}
			return mValue;
		}
		set
		{
			Set(value);
		}
	}

	public float alpha
	{
		get
		{
			if (mFG != null)
			{
				return mFG.alpha;
			}
			if (mBG != null)
			{
				return mBG.alpha;
			}
			return 1f;
		}
		set
		{
			if (mFG != null)
			{
				mFG.alpha = value;
				if (mFG.GetComponent<Collider>() != null)
				{
					mFG.GetComponent<Collider>().enabled = mFG.alpha > 0.001f;
				}
				else if (mFG.GetComponent<Collider2D>() != null)
				{
					mFG.GetComponent<Collider2D>().enabled = mFG.alpha > 0.001f;
				}
			}
			if (mBG != null)
			{
				mBG.alpha = value;
				if (mBG.GetComponent<Collider>() != null)
				{
					mBG.GetComponent<Collider>().enabled = mBG.alpha > 0.001f;
				}
				else if (mBG.GetComponent<Collider2D>() != null)
				{
					mBG.GetComponent<Collider2D>().enabled = mBG.alpha > 0.001f;
				}
			}
			if (!(thumb != null))
			{
				return;
			}
			UIWidget component = thumb.GetComponent<UIWidget>();
			if (component != null)
			{
				component.alpha = value;
				if (component.GetComponent<Collider>() != null)
				{
					component.GetComponent<Collider>().enabled = component.alpha > 0.001f;
				}
				else if (component.GetComponent<Collider2D>() != null)
				{
					component.GetComponent<Collider2D>().enabled = component.alpha > 0.001f;
				}
			}
		}
	}

	protected bool isHorizontal
	{
		get
		{
			if (mFill != 0)
			{
				return mFill == FillDirection.RightToLeft;
			}
			return true;
		}
	}

	protected bool isInverted
	{
		get
		{
			if (mFill != FillDirection.RightToLeft)
			{
				return mFill == FillDirection.TopToBottom;
			}
			return true;
		}
	}

	public void Set(float val, bool notify = true)
	{
		val = Mathf.Clamp01(val);
		if (mValue == val)
		{
			return;
		}
		float num = value;
		mValue = val;
		if (mStarted && num != value)
		{
			if (notify && NGUITools.GetActive(this) && EventDelegate.IsValid(onChange))
			{
				current = this;
				EventDelegate.Execute(onChange);
				current = null;
			}
			ForceUpdate();
		}
	}

	public void Start()
	{
		if (mStarted)
		{
			return;
		}
		mStarted = true;
		Upgrade();
		if (Application.isPlaying)
		{
			if (mBG != null)
			{
				mBG.autoResizeBoxCollider = true;
			}
			OnStart();
			if (current == null && onChange != null)
			{
				current = this;
				EventDelegate.Execute(onChange);
				current = null;
			}
		}
		ForceUpdate();
	}

	protected virtual void Upgrade()
	{
	}

	protected virtual void OnStart()
	{
	}

	protected void Update()
	{
		if (mIsDirty)
		{
			ForceUpdate();
		}
	}

	protected void OnValidate()
	{
		if (NGUITools.GetActive(this))
		{
			Upgrade();
			mIsDirty = true;
			float num = Mathf.Clamp01(mValue);
			if (mValue != num)
			{
				mValue = num;
			}
			if (numberOfSteps < 0)
			{
				numberOfSteps = 0;
			}
			else if (numberOfSteps > 21)
			{
				numberOfSteps = 21;
			}
			ForceUpdate();
		}
		else
		{
			float num2 = Mathf.Clamp01(mValue);
			if (mValue != num2)
			{
				mValue = num2;
			}
			if (numberOfSteps < 0)
			{
				numberOfSteps = 0;
			}
			else if (numberOfSteps > 21)
			{
				numberOfSteps = 21;
			}
		}
	}

	protected float ScreenToValue(Vector2 screenPos)
	{
		Transform transform = cachedTransform;
		Plane plane = new Plane(transform.rotation * Vector3.back, transform.position);
		Ray ray = cachedCamera.ScreenPointToRay(screenPos);
		if (!plane.Raycast(ray, out var enter))
		{
			return value;
		}
		return LocalToValue(transform.InverseTransformPoint(ray.GetPoint(enter)));
	}

	protected virtual float LocalToValue(Vector2 localPos)
	{
		if (mFG != null)
		{
			Vector3[] localCorners = mFG.localCorners;
			Vector3 vector = localCorners[2] - localCorners[0];
			if (isHorizontal)
			{
				float num = (localPos.x - localCorners[0].x) / vector.x;
				if (!isInverted)
				{
					return num;
				}
				return 1f - num;
			}
			float num2 = (localPos.y - localCorners[0].y) / vector.y;
			if (!isInverted)
			{
				return num2;
			}
			return 1f - num2;
		}
		return value;
	}

	public virtual void ForceUpdate()
	{
		mIsDirty = false;
		bool flag = false;
		if (mFG != null)
		{
			UIBasicSprite uIBasicSprite = mFG as UIBasicSprite;
			if (isHorizontal)
			{
				if (uIBasicSprite != null && uIBasicSprite.type == UIBasicSprite.Type.Filled)
				{
					if (uIBasicSprite.fillDirection == UIBasicSprite.FillDirection.Horizontal || uIBasicSprite.fillDirection == UIBasicSprite.FillDirection.Vertical)
					{
						uIBasicSprite.fillDirection = UIBasicSprite.FillDirection.Horizontal;
						uIBasicSprite.invert = isInverted;
					}
					uIBasicSprite.fillAmount = value;
				}
				else
				{
					mFG.drawRegion = (isInverted ? new Vector4(1f - value, 0f, 1f, 1f) : new Vector4(0f, 0f, value, 1f));
					mFG.enabled = true;
					flag = value < 0.001f;
				}
			}
			else if (uIBasicSprite != null && uIBasicSprite.type == UIBasicSprite.Type.Filled)
			{
				if (uIBasicSprite.fillDirection == UIBasicSprite.FillDirection.Horizontal || uIBasicSprite.fillDirection == UIBasicSprite.FillDirection.Vertical)
				{
					uIBasicSprite.fillDirection = UIBasicSprite.FillDirection.Vertical;
					uIBasicSprite.invert = isInverted;
				}
				uIBasicSprite.fillAmount = value;
			}
			else
			{
				mFG.drawRegion = (isInverted ? new Vector4(0f, 1f - value, 1f, 1f) : new Vector4(0f, 0f, 1f, value));
				mFG.enabled = true;
				flag = value < 0.001f;
			}
		}
		if (thumb != null && (mFG != null || mBG != null))
		{
			Vector3[] array = ((mFG != null) ? mFG.localCorners : mBG.localCorners);
			Vector4 vector = ((mFG != null) ? mFG.border : mBG.border);
			array[0].x += vector.x;
			array[1].x += vector.x;
			array[2].x -= vector.z;
			array[3].x -= vector.z;
			array[0].y += vector.y;
			array[1].y -= vector.w;
			array[2].y -= vector.w;
			array[3].y += vector.y;
			Transform transform = ((mFG != null) ? mFG.cachedTransform : mBG.cachedTransform);
			for (int i = 0; i < 4; i++)
			{
				array[i] = transform.TransformPoint(array[i]);
			}
			if (isHorizontal)
			{
				Vector3 a = Vector3.Lerp(array[0], array[1], 0.5f);
				Vector3 b = Vector3.Lerp(array[2], array[3], 0.5f);
				SetThumbPosition(Vector3.Lerp(a, b, isInverted ? (1f - value) : value));
			}
			else
			{
				Vector3 a2 = Vector3.Lerp(array[0], array[3], 0.5f);
				Vector3 b2 = Vector3.Lerp(array[1], array[2], 0.5f);
				SetThumbPosition(Vector3.Lerp(a2, b2, isInverted ? (1f - value) : value));
			}
		}
		if (flag)
		{
			mFG.enabled = false;
		}
	}

	protected void SetThumbPosition(Vector3 worldPos)
	{
		Transform parent = thumb.parent;
		if (parent != null)
		{
			worldPos = parent.InverseTransformPoint(worldPos);
			worldPos.x = Mathf.Round(worldPos.x);
			worldPos.y = Mathf.Round(worldPos.y);
			worldPos.z = 0f;
			if (Vector3.Distance(thumb.localPosition, worldPos) > 0.001f)
			{
				thumb.localPosition = worldPos;
			}
		}
		else if (Vector3.Distance(thumb.position, worldPos) > 1E-05f)
		{
			thumb.position = worldPos;
		}
	}

	public virtual void OnPan(Vector2 delta)
	{
		if (base.enabled)
		{
			switch (mFill)
			{
			case FillDirection.LeftToRight:
			{
				float num8 = (value = Mathf.Clamp01(mValue + delta.x));
				mValue = num8;
				break;
			}
			case FillDirection.RightToLeft:
			{
				float num6 = (value = Mathf.Clamp01(mValue - delta.x));
				mValue = num6;
				break;
			}
			case FillDirection.BottomToTop:
			{
				float num4 = (value = Mathf.Clamp01(mValue + delta.y));
				mValue = num4;
				break;
			}
			case FillDirection.TopToBottom:
			{
				float num2 = (value = Mathf.Clamp01(mValue - delta.y));
				mValue = num2;
				break;
			}
			}
		}
	}
}
