using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
[AddComponentMenu("NGUI/UI/Tooltip")]
public class UITooltip : MonoBehaviour
{
	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x060008D7 RID: 2263 RVA: 0x00048489 File Offset: 0x00046689
	public static bool isVisible
	{
		get
		{
			return UITooltip.mInstance != null && UITooltip.mInstance.mTarget == 1f;
		}
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000484AB File Offset: 0x000466AB
	private void Awake()
	{
		UITooltip.mInstance = this;
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000484B3 File Offset: 0x000466B3
	private void OnDestroy()
	{
		UITooltip.mInstance = null;
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000484BC File Offset: 0x000466BC
	protected virtual void Start()
	{
		this.mTrans = base.transform;
		this.mWidgets = base.GetComponentsInChildren<UIWidget>();
		this.mPos = this.mTrans.localPosition;
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.SetAlpha(0f);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x00048524 File Offset: 0x00046724
	protected virtual void Update()
	{
		if (this.mTooltip != UICamera.tooltipObject)
		{
			this.mTooltip = null;
			this.mTarget = 0f;
		}
		if (this.mCurrent != this.mTarget)
		{
			this.mCurrent = Mathf.Lerp(this.mCurrent, this.mTarget, RealTime.deltaTime * this.appearSpeed);
			if (Mathf.Abs(this.mCurrent - this.mTarget) < 0.001f)
			{
				this.mCurrent = this.mTarget;
			}
			this.SetAlpha(this.mCurrent * this.mCurrent);
			if (this.scalingTransitions)
			{
				Vector3 vector = this.mSize * 0.25f;
				vector.y = -vector.y;
				Vector3 localScale = Vector3.one * (1.5f - this.mCurrent * 0.5f);
				Vector3 localPosition = Vector3.Lerp(this.mPos - vector, this.mPos, this.mCurrent);
				this.mTrans.localPosition = localPosition;
				this.mTrans.localScale = localScale;
			}
		}
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x0004863C File Offset: 0x0004683C
	protected virtual void SetAlpha(float val)
	{
		int i = 0;
		int num = this.mWidgets.Length;
		while (i < num)
		{
			UIWidget uiwidget = this.mWidgets[i];
			Color color = uiwidget.color;
			color.a = val;
			uiwidget.color = color;
			i++;
		}
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x0004867C File Offset: 0x0004687C
	protected virtual void SetText(string tooltipText)
	{
		if (!(this.text != null) || string.IsNullOrEmpty(tooltipText))
		{
			this.mTooltip = null;
			this.mTarget = 0f;
			return;
		}
		this.mTarget = 1f;
		this.mTooltip = UICamera.tooltipObject;
		this.text.text = tooltipText;
		this.mPos = UICamera.lastEventPosition;
		Transform transform = this.text.transform;
		Vector3 localPosition = transform.localPosition;
		Vector3 localScale = transform.localScale;
		this.mSize = this.text.printedSize;
		this.mSize.x = this.mSize.x * localScale.x;
		this.mSize.y = this.mSize.y * localScale.y;
		if (this.background != null)
		{
			Vector4 border = this.background.border;
			this.mSize.x = this.mSize.x + (border.x + border.z + (localPosition.x - border.x) * 2f);
			this.mSize.y = this.mSize.y + (border.y + border.w + (-localPosition.y - border.y) * 2f);
			this.background.width = Mathf.RoundToInt(this.mSize.x);
			this.background.height = Mathf.RoundToInt(this.mSize.y);
		}
		if (this.uiCamera != null)
		{
			this.mPos.x = Mathf.Clamp01(this.mPos.x / (float)Screen.width);
			this.mPos.y = Mathf.Clamp01(this.mPos.y / (float)Screen.height);
			float num = this.uiCamera.orthographicSize / this.mTrans.parent.lossyScale.y;
			float num2 = (float)Screen.height * 0.5f / num;
			Vector2 vector = new Vector2(num2 * this.mSize.x / (float)Screen.width, num2 * this.mSize.y / (float)Screen.height);
			this.mPos.x = Mathf.Min(this.mPos.x, 1f - vector.x);
			this.mPos.y = Mathf.Max(this.mPos.y, vector.y);
			this.mTrans.position = this.uiCamera.ViewportToWorldPoint(this.mPos);
			this.mPos = this.mTrans.localPosition;
			this.mPos.x = Mathf.Round(this.mPos.x);
			this.mPos.y = Mathf.Round(this.mPos.y);
		}
		else
		{
			if (this.mPos.x + this.mSize.x > (float)Screen.width)
			{
				this.mPos.x = (float)Screen.width - this.mSize.x;
			}
			if (this.mPos.y - this.mSize.y < 0f)
			{
				this.mPos.y = this.mSize.y;
			}
			this.mPos.x = this.mPos.x - (float)Screen.width * 0.5f;
			this.mPos.y = this.mPos.y - (float)Screen.height * 0.5f;
		}
		this.mTrans.localPosition = this.mPos;
		if (this.tooltipRoot != null)
		{
			this.tooltipRoot.BroadcastMessage("UpdateAnchors");
			return;
		}
		this.text.BroadcastMessage("UpdateAnchors");
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x00048A46 File Offset: 0x00046C46
	[Obsolete("Use UITooltip.Show instead")]
	public static void ShowText(string text)
	{
		if (UITooltip.mInstance != null)
		{
			UITooltip.mInstance.SetText(text);
		}
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00048A60 File Offset: 0x00046C60
	public static void Show(string text)
	{
		if (UITooltip.mInstance != null)
		{
			UITooltip.mInstance.SetText(text);
		}
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00048A7A File Offset: 0x00046C7A
	public static void Hide()
	{
		if (UITooltip.mInstance != null)
		{
			UITooltip.mInstance.mTooltip = null;
			UITooltip.mInstance.mTarget = 0f;
		}
	}

	// Token: 0x0400079A RID: 1946
	protected static UITooltip mInstance;

	// Token: 0x0400079B RID: 1947
	public Camera uiCamera;

	// Token: 0x0400079C RID: 1948
	public UILabel text;

	// Token: 0x0400079D RID: 1949
	public GameObject tooltipRoot;

	// Token: 0x0400079E RID: 1950
	public UISprite background;

	// Token: 0x0400079F RID: 1951
	public float appearSpeed = 10f;

	// Token: 0x040007A0 RID: 1952
	public bool scalingTransitions = true;

	// Token: 0x040007A1 RID: 1953
	protected GameObject mTooltip;

	// Token: 0x040007A2 RID: 1954
	protected Transform mTrans;

	// Token: 0x040007A3 RID: 1955
	protected float mTarget;

	// Token: 0x040007A4 RID: 1956
	protected float mCurrent;

	// Token: 0x040007A5 RID: 1957
	protected Vector3 mPos;

	// Token: 0x040007A6 RID: 1958
	protected Vector3 mSize = Vector3.zero;

	// Token: 0x040007A7 RID: 1959
	protected UIWidget[] mWidgets;
}
