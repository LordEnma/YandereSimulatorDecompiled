using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000043 RID: 67
[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600010F RID: 271 RVA: 0x00013870 File Offset: 0x00011A70
	// (set) Token: 0x06000110 RID: 272 RVA: 0x000138BC File Offset: 0x00011ABC
	public override bool isEnabled
	{
		get
		{
			if (!base.enabled)
			{
				return false;
			}
			Collider component = base.gameObject.GetComponent<Collider>();
			if (component && component.enabled)
			{
				return true;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 && component2.enabled;
		}
		set
		{
			if (this.isEnabled != value)
			{
				Collider component = base.gameObject.GetComponent<Collider>();
				if (component != null)
				{
					component.enabled = value;
					UIButton[] components = base.GetComponents<UIButton>();
					for (int i = 0; i < components.Length; i++)
					{
						components[i].SetState(value ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled, false);
					}
					return;
				}
				Collider2D component2 = base.GetComponent<Collider2D>();
				if (component2 != null)
				{
					component2.enabled = value;
					UIButton[] components = base.GetComponents<UIButton>();
					for (int i = 0; i < components.Length; i++)
					{
						components[i].SetState(value ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled, false);
					}
					return;
				}
				base.enabled = value;
			}
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000111 RID: 273 RVA: 0x0001395B File Offset: 0x00011B5B
	// (set) Token: 0x06000112 RID: 274 RVA: 0x00013974 File Offset: 0x00011B74
	public string normalSprite
	{
		get
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			return this.mNormalSprite;
		}
		set
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.mSprite != null && !string.IsNullOrEmpty(this.mNormalSprite) && this.mNormalSprite == this.mSprite.spriteName)
			{
				this.mNormalSprite = value;
				this.SetSprite(value);
				NGUITools.SetDirty(this.mSprite, "last change");
				return;
			}
			this.mNormalSprite = value;
			if (this.mState == UIButtonColor.State.Normal)
			{
				this.SetSprite(value);
			}
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000113 RID: 275 RVA: 0x000139F7 File Offset: 0x00011BF7
	// (set) Token: 0x06000114 RID: 276 RVA: 0x00013A10 File Offset: 0x00011C10
	public Sprite normalSprite2D
	{
		get
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			return this.mNormalSprite2D;
		}
		set
		{
			if (!this.mInitDone)
			{
				this.OnInit();
			}
			if (this.mSprite2D != null && this.mNormalSprite2D == this.mSprite2D.sprite2D)
			{
				this.mNormalSprite2D = value;
				this.SetSprite(value);
				NGUITools.SetDirty(this.mSprite, "last change");
				return;
			}
			this.mNormalSprite2D = value;
			if (this.mState == UIButtonColor.State.Normal)
			{
				this.SetSprite(value);
			}
		}
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00013A88 File Offset: 0x00011C88
	protected override void OnInit()
	{
		base.OnInit();
		this.mSprite = (this.mWidget as UISprite);
		this.mSprite2D = (this.mWidget as UI2DSprite);
		if (this.mSprite != null)
		{
			this.mNormalSprite = this.mSprite.spriteName;
		}
		if (this.mSprite2D != null)
		{
			this.mNormalSprite2D = this.mSprite2D.sprite2D;
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00013AFB File Offset: 0x00011CFB
	protected override void OnEnable()
	{
		if (this.isEnabled)
		{
			if (this.mInitDone)
			{
				this.OnHover(UICamera.hoveredObject == base.gameObject);
				return;
			}
		}
		else
		{
			this.SetState(UIButtonColor.State.Disabled, true);
		}
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00013B2C File Offset: 0x00011D2C
	protected override void OnDragOver()
	{
		if (this.isEnabled && (this.dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOver();
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00013B5B File Offset: 0x00011D5B
	protected override void OnDragOut()
	{
		if (this.isEnabled && (this.dragHighlight || UICamera.currentTouch.pressed == base.gameObject))
		{
			base.OnDragOut();
		}
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00013B8A File Offset: 0x00011D8A
	protected virtual void OnClick()
	{
		if (UIButton.current == null && this.isEnabled && UICamera.currentTouchID != -2 && UICamera.currentTouchID != -3)
		{
			UIButton.current = this;
			EventDelegate.Execute(this.onClick);
			UIButton.current = null;
		}
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00013BCC File Offset: 0x00011DCC
	public override void SetState(UIButtonColor.State state, bool immediate)
	{
		base.SetState(state, immediate);
		if (!(this.mSprite != null))
		{
			if (this.mSprite2D != null)
			{
				switch (state)
				{
				case UIButtonColor.State.Normal:
					this.SetSprite(this.mNormalSprite2D);
					return;
				case UIButtonColor.State.Hover:
					this.SetSprite((this.hoverSprite2D == null) ? this.mNormalSprite2D : this.hoverSprite2D);
					return;
				case UIButtonColor.State.Pressed:
					this.SetSprite(this.pressedSprite2D);
					return;
				case UIButtonColor.State.Disabled:
					this.SetSprite(this.disabledSprite2D);
					break;
				default:
					return;
				}
			}
			return;
		}
		switch (state)
		{
		case UIButtonColor.State.Normal:
			this.SetSprite(this.mNormalSprite);
			return;
		case UIButtonColor.State.Hover:
			this.SetSprite(string.IsNullOrEmpty(this.hoverSprite) ? this.mNormalSprite : this.hoverSprite);
			return;
		case UIButtonColor.State.Pressed:
			this.SetSprite(this.pressedSprite);
			return;
		case UIButtonColor.State.Disabled:
			this.SetSprite(this.disabledSprite);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00013CC0 File Offset: 0x00011EC0
	protected void SetSprite(string sp)
	{
		if (this.mSprite != null && !string.IsNullOrEmpty(sp) && this.mSprite.spriteName != sp)
		{
			this.mSprite.spriteName = sp;
			if (this.pixelSnap)
			{
				this.mSprite.MakePixelPerfect();
			}
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00013D18 File Offset: 0x00011F18
	protected void SetSprite(Sprite sp)
	{
		if (sp != null && this.mSprite2D != null && this.mSprite2D.sprite2D != sp)
		{
			this.mSprite2D.sprite2D = sp;
			if (this.pixelSnap)
			{
				this.mSprite2D.MakePixelPerfect();
			}
		}
	}

	// Token: 0x040002DC RID: 732
	public static UIButton current;

	// Token: 0x040002DD RID: 733
	public bool dragHighlight;

	// Token: 0x040002DE RID: 734
	public string hoverSprite;

	// Token: 0x040002DF RID: 735
	public string pressedSprite;

	// Token: 0x040002E0 RID: 736
	public string disabledSprite;

	// Token: 0x040002E1 RID: 737
	public Sprite hoverSprite2D;

	// Token: 0x040002E2 RID: 738
	public Sprite pressedSprite2D;

	// Token: 0x040002E3 RID: 739
	public Sprite disabledSprite2D;

	// Token: 0x040002E4 RID: 740
	public bool pixelSnap;

	// Token: 0x040002E5 RID: 741
	public List<EventDelegate> onClick = new List<EventDelegate>();

	// Token: 0x040002E6 RID: 742
	[NonSerialized]
	private UISprite mSprite;

	// Token: 0x040002E7 RID: 743
	[NonSerialized]
	private UI2DSprite mSprite2D;

	// Token: 0x040002E8 RID: 744
	[NonSerialized]
	private string mNormalSprite;

	// Token: 0x040002E9 RID: 745
	[NonSerialized]
	private Sprite mNormalSprite2D;
}
