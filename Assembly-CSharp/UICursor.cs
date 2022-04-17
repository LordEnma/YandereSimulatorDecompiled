using System;
using UnityEngine;

// Token: 0x02000022 RID: 34
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/Examples/UI Cursor")]
public class UICursor : MonoBehaviour
{
	// Token: 0x06000085 RID: 133 RVA: 0x000110E7 File Offset: 0x0000F2E7
	private void Awake()
	{
		UICursor.instance = this;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x000110EF File Offset: 0x0000F2EF
	private void OnDestroy()
	{
		UICursor.instance = null;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000110F8 File Offset: 0x0000F2F8
	private void Start()
	{
		this.mTrans = base.transform;
		this.mSprite = base.GetComponentInChildren<UISprite>();
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		if (this.mSprite != null)
		{
			this.mAtlas = this.mSprite.atlas;
			this.mSpriteName = this.mSprite.spriteName;
			if (this.mSprite.depth < 100)
			{
				this.mSprite.depth = 100;
			}
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00011190 File Offset: 0x0000F390
	private void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		if (this.uiCamera != null)
		{
			mousePosition.x = Mathf.Clamp01(mousePosition.x / (float)Screen.width);
			mousePosition.y = Mathf.Clamp01(mousePosition.y / (float)Screen.height);
			this.mTrans.position = this.uiCamera.ViewportToWorldPoint(mousePosition);
			if (this.uiCamera.orthographic)
			{
				Vector3 localPosition = this.mTrans.localPosition;
				localPosition.x = Mathf.Round(localPosition.x);
				localPosition.y = Mathf.Round(localPosition.y);
				this.mTrans.localPosition = localPosition;
				return;
			}
		}
		else
		{
			mousePosition.x -= (float)Screen.width * 0.5f;
			mousePosition.y -= (float)Screen.height * 0.5f;
			mousePosition.x = Mathf.Round(mousePosition.x);
			mousePosition.y = Mathf.Round(mousePosition.y);
			this.mTrans.localPosition = mousePosition;
		}
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000112A8 File Offset: 0x0000F4A8
	public static void Clear()
	{
		if (UICursor.instance != null && UICursor.instance.mSprite != null)
		{
			UICursor.Set(UICursor.instance.mAtlas, UICursor.instance.mSpriteName);
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000112E4 File Offset: 0x0000F4E4
	public static void Set(INGUIAtlas atlas, string sprite)
	{
		if (UICursor.instance != null && UICursor.instance.mSprite)
		{
			UICursor.instance.mSprite.atlas = atlas;
			UICursor.instance.mSprite.spriteName = sprite;
			UICursor.instance.mSprite.MakePixelPerfect();
			UICursor.instance.Update();
		}
	}

	// Token: 0x0400025F RID: 607
	public static UICursor instance;

	// Token: 0x04000260 RID: 608
	public Camera uiCamera;

	// Token: 0x04000261 RID: 609
	private Transform mTrans;

	// Token: 0x04000262 RID: 610
	private UISprite mSprite;

	// Token: 0x04000263 RID: 611
	private INGUIAtlas mAtlas;

	// Token: 0x04000264 RID: 612
	private string mSpriteName;
}
