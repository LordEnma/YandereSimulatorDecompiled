using System;
using UnityEngine;

// Token: 0x02000058 RID: 88
[AddComponentMenu("NGUI/UI/Image Button")]
public class UIImageButton : MonoBehaviour
{
	// Token: 0x17000018 RID: 24
	// (get) Token: 0x060001D3 RID: 467 RVA: 0x00017BF0 File Offset: 0x00015DF0
	// (set) Token: 0x060001D4 RID: 468 RVA: 0x00017C1C File Offset: 0x00015E1C
	public bool isEnabled
	{
		get
		{
			Collider component = base.gameObject.GetComponent<Collider>();
			return component && component.enabled;
		}
		set
		{
			Collider component = base.gameObject.GetComponent<Collider>();
			if (!component)
			{
				return;
			}
			if (component.enabled != value)
			{
				component.enabled = value;
				this.UpdateImage();
			}
		}
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00017C54 File Offset: 0x00015E54
	private void OnEnable()
	{
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<UISprite>();
		}
		this.UpdateImage();
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00017C78 File Offset: 0x00015E78
	private void OnValidate()
	{
		if (this.target != null)
		{
			if (string.IsNullOrEmpty(this.normalSprite))
			{
				this.normalSprite = this.target.spriteName;
			}
			if (string.IsNullOrEmpty(this.hoverSprite))
			{
				this.hoverSprite = this.target.spriteName;
			}
			if (string.IsNullOrEmpty(this.pressedSprite))
			{
				this.pressedSprite = this.target.spriteName;
			}
			if (string.IsNullOrEmpty(this.disabledSprite))
			{
				this.disabledSprite = this.target.spriteName;
			}
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00017D0C File Offset: 0x00015F0C
	private void UpdateImage()
	{
		if (this.target != null)
		{
			if (this.isEnabled)
			{
				this.SetSprite(UICamera.IsHighlighted(base.gameObject) ? this.hoverSprite : this.normalSprite);
				return;
			}
			this.SetSprite(this.disabledSprite);
		}
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00017D5D File Offset: 0x00015F5D
	private void OnHover(bool isOver)
	{
		if (this.isEnabled && this.target != null)
		{
			this.SetSprite(isOver ? this.hoverSprite : this.normalSprite);
		}
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00017D8C File Offset: 0x00015F8C
	private void OnPress(bool pressed)
	{
		if (pressed)
		{
			this.SetSprite(this.pressedSprite);
			return;
		}
		this.UpdateImage();
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00017DA4 File Offset: 0x00015FA4
	private void SetSprite(string sprite)
	{
		if (string.IsNullOrEmpty(sprite))
		{
			return;
		}
		INGUIAtlas atlas = this.target.atlas;
		if (atlas == null)
		{
			return;
		}
		INGUIAtlas inguiatlas = atlas;
		if (inguiatlas == null || inguiatlas.GetSprite(sprite) == null)
		{
			return;
		}
		this.target.spriteName = sprite;
		if (this.pixelSnap)
		{
			this.target.MakePixelPerfect();
		}
	}

	// Token: 0x0400038B RID: 907
	public UISprite target;

	// Token: 0x0400038C RID: 908
	public string normalSprite;

	// Token: 0x0400038D RID: 909
	public string hoverSprite;

	// Token: 0x0400038E RID: 910
	public string pressedSprite;

	// Token: 0x0400038F RID: 911
	public string disabledSprite;

	// Token: 0x04000390 RID: 912
	public bool pixelSnap = true;
}
