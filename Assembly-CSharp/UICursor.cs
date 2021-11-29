using System;
using UnityEngine;

// Token: 0x02000022 RID: 34
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/Examples/UI Cursor")]
public class UICursor : MonoBehaviour
{
	// Token: 0x06000085 RID: 133 RVA: 0x00010F3F File Offset: 0x0000F13F
	private void Awake()
	{
		UICursor.instance = this;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00010F47 File Offset: 0x0000F147
	private void OnDestroy()
	{
		UICursor.instance = null;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00010F50 File Offset: 0x0000F150
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

	// Token: 0x06000088 RID: 136 RVA: 0x00010FE8 File Offset: 0x0000F1E8
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

	// Token: 0x06000089 RID: 137 RVA: 0x00011100 File Offset: 0x0000F300
	public static void Clear()
	{
		if (UICursor.instance != null && UICursor.instance.mSprite != null)
		{
			UICursor.Set(UICursor.instance.mAtlas, UICursor.instance.mSpriteName);
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0001113C File Offset: 0x0000F33C
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

	// Token: 0x04000254 RID: 596
	public static UICursor instance;

	// Token: 0x04000255 RID: 597
	public Camera uiCamera;

	// Token: 0x04000256 RID: 598
	private Transform mTrans;

	// Token: 0x04000257 RID: 599
	private UISprite mSprite;

	// Token: 0x04000258 RID: 600
	private INGUIAtlas mAtlas;

	// Token: 0x04000259 RID: 601
	private string mSpriteName;
}
