using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A0 RID: 160
[RequireComponent(typeof(UITexture))]
public class UIColorPicker : MonoBehaviour
{
	// Token: 0x060006FD RID: 1789 RVA: 0x0003CE00 File Offset: 0x0003B000
	private void Start()
	{
		this.mTrans = base.transform;
		this.mUITex = base.GetComponent<UITexture>();
		this.mCam = UICamera.FindCameraForLayer(base.gameObject.layer);
		this.mWidth = this.mUITex.width;
		this.mHeight = this.mUITex.height;
		Color[] array = new Color[this.mWidth * this.mHeight];
		for (int i = 0; i < this.mHeight; i++)
		{
			float y = ((float)i - 1f) / (float)this.mHeight;
			for (int j = 0; j < this.mWidth; j++)
			{
				float x = ((float)j - 1f) / (float)this.mWidth;
				int num = j + i * this.mWidth;
				array[num] = UIColorPicker.Sample(x, y);
			}
		}
		this.mTex = new Texture2D(this.mWidth, this.mHeight, TextureFormat.RGB24, false);
		this.mTex.SetPixels(array);
		this.mTex.filterMode = FilterMode.Trilinear;
		this.mTex.wrapMode = TextureWrapMode.Clamp;
		this.mTex.Apply();
		this.mUITex.mainTexture = this.mTex;
		this.Select(this.value);
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0003CF37 File Offset: 0x0003B137
	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(this.mTex);
		this.mTex = null;
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0003CF4B File Offset: 0x0003B14B
	private void OnPress(bool pressed)
	{
		if (base.enabled && pressed && UICamera.currentScheme != UICamera.ControlScheme.Controller)
		{
			this.Sample();
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0003CF65 File Offset: 0x0003B165
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled)
		{
			this.Sample();
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0003CF78 File Offset: 0x0003B178
	private void OnPan(Vector2 delta)
	{
		if (base.enabled)
		{
			this.mPos.x = Mathf.Clamp01(this.mPos.x + delta.x);
			this.mPos.y = Mathf.Clamp01(this.mPos.y + delta.y);
			this.Select(this.mPos);
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0003CFE0 File Offset: 0x0003B1E0
	private void Sample()
	{
		Vector3 vector = this.mTrans.InverseTransformPoint(UICamera.lastWorldPosition);
		Vector3[] localCorners = this.mUITex.localCorners;
		this.mPos.x = Mathf.Clamp01((vector.x - localCorners[0].x) / (localCorners[2].x - localCorners[0].x));
		this.mPos.y = Mathf.Clamp01((vector.y - localCorners[0].y) / (localCorners[2].y - localCorners[0].y));
		if (this.selectionWidget != null)
		{
			vector.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
			vector.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
			vector = this.mTrans.TransformPoint(vector);
			this.selectionWidget.transform.OverlayPosition(vector, this.mCam.cachedCamera);
		}
		this.value = UIColorPicker.Sample(this.mPos.x, this.mPos.y);
		UIColorPicker.current = this;
		EventDelegate.Execute(this.onChange);
		UIColorPicker.current = null;
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0003D154 File Offset: 0x0003B354
	public void Select(Vector2 v)
	{
		v.x = Mathf.Clamp01(v.x);
		v.y = Mathf.Clamp01(v.y);
		this.mPos = v;
		if (this.selectionWidget != null)
		{
			Vector3[] localCorners = this.mUITex.localCorners;
			v.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
			v.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
			v = this.mTrans.TransformPoint(v);
			this.selectionWidget.transform.OverlayPosition(v, this.mCam.cachedCamera);
		}
		this.value = UIColorPicker.Sample(this.mPos.x, this.mPos.y);
		UIColorPicker.current = this;
		EventDelegate.Execute(this.onChange);
		UIColorPicker.current = null;
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0003D278 File Offset: 0x0003B478
	public Vector2 Select(Color c)
	{
		if (this.mUITex == null)
		{
			this.value = c;
			return this.mPos;
		}
		float num = float.MaxValue;
		for (int i = 0; i < this.mHeight; i++)
		{
			float y = ((float)i - 1f) / (float)this.mHeight;
			for (int j = 0; j < this.mWidth; j++)
			{
				float x = ((float)j - 1f) / (float)this.mWidth;
				Color color = UIColorPicker.Sample(x, y);
				color.r -= c.r;
				color.g -= c.g;
				color.b -= c.b;
				float num2 = color.r * color.r + color.g * color.g + color.b * color.b;
				if (num2 < num)
				{
					num = num2;
					this.mPos.x = x;
					this.mPos.y = y;
				}
			}
		}
		if (this.selectionWidget != null)
		{
			Vector3[] localCorners = this.mUITex.localCorners;
			Vector3 vector;
			vector.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
			vector.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
			vector.z = 0f;
			vector = this.mTrans.TransformPoint(vector);
			this.selectionWidget.transform.OverlayPosition(vector, this.mCam.cachedCamera);
		}
		this.value = c;
		UIColorPicker.current = this;
		EventDelegate.Execute(this.onChange);
		UIColorPicker.current = null;
		return this.mPos;
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0003D464 File Offset: 0x0003B664
	public static Color Sample(float x, float y)
	{
		if (UIColorPicker.mRed == null)
		{
			UIColorPicker.mRed = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 1f),
				new Keyframe(0.14285715f, 1f),
				new Keyframe(0.2857143f, 0f),
				new Keyframe(0.42857143f, 0f),
				new Keyframe(0.5714286f, 0f),
				new Keyframe(0.71428573f, 1f),
				new Keyframe(0.85714287f, 1f),
				new Keyframe(1f, 0.5f)
			});
			UIColorPicker.mGreen = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f),
				new Keyframe(0.14285715f, 1f),
				new Keyframe(0.2857143f, 1f),
				new Keyframe(0.42857143f, 1f),
				new Keyframe(0.5714286f, 0f),
				new Keyframe(0.71428573f, 0f),
				new Keyframe(0.85714287f, 0f),
				new Keyframe(1f, 0.5f)
			});
			UIColorPicker.mBlue = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f),
				new Keyframe(0.14285715f, 0f),
				new Keyframe(0.2857143f, 0f),
				new Keyframe(0.42857143f, 1f),
				new Keyframe(0.5714286f, 1f),
				new Keyframe(0.71428573f, 1f),
				new Keyframe(0.85714287f, 0f),
				new Keyframe(1f, 0.5f)
			});
		}
		Vector3 vector = new Vector3(UIColorPicker.mRed.Evaluate(x), UIColorPicker.mGreen.Evaluate(x), UIColorPicker.mBlue.Evaluate(x));
		if (y < 0.5f)
		{
			y *= 2f;
			vector.x *= y;
			vector.y *= y;
			vector.z *= y;
		}
		else
		{
			vector = Vector3.Lerp(vector, Vector3.one, y * 2f - 1f);
		}
		return new Color(vector.x, vector.y, vector.z, 1f);
	}

	// Token: 0x040006A8 RID: 1704
	public static UIColorPicker current;

	// Token: 0x040006A9 RID: 1705
	public Color value = Color.white;

	// Token: 0x040006AA RID: 1706
	public UIWidget selectionWidget;

	// Token: 0x040006AB RID: 1707
	public List<EventDelegate> onChange = new List<EventDelegate>();

	// Token: 0x040006AC RID: 1708
	[NonSerialized]
	private Transform mTrans;

	// Token: 0x040006AD RID: 1709
	[NonSerialized]
	private UITexture mUITex;

	// Token: 0x040006AE RID: 1710
	[NonSerialized]
	private Texture2D mTex;

	// Token: 0x040006AF RID: 1711
	[NonSerialized]
	private UICamera mCam;

	// Token: 0x040006B0 RID: 1712
	[NonSerialized]
	private Vector2 mPos;

	// Token: 0x040006B1 RID: 1713
	[NonSerialized]
	private int mWidth;

	// Token: 0x040006B2 RID: 1714
	[NonSerialized]
	private int mHeight;

	// Token: 0x040006B3 RID: 1715
	private static AnimationCurve mRed;

	// Token: 0x040006B4 RID: 1716
	private static AnimationCurve mGreen;

	// Token: 0x040006B5 RID: 1717
	private static AnimationCurve mBlue;
}
