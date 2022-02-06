using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Slider")]
public class UISlider : UIProgressBar
{
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060002B4 RID: 692 RVA: 0x0001DC70 File Offset: 0x0001BE70
	public bool isColliderEnabled
	{
		get
		{
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060002B5 RID: 693 RVA: 0x0001DCAC File Offset: 0x0001BEAC
	// (set) Token: 0x060002B6 RID: 694 RVA: 0x0001DCB4 File Offset: 0x0001BEB4
	[Obsolete("Use 'value' instead")]
	public float sliderValue
	{
		get
		{
			return base.value;
		}
		set
		{
			base.value = value;
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060002B7 RID: 695 RVA: 0x0001DCBD File Offset: 0x0001BEBD
	// (set) Token: 0x060002B8 RID: 696 RVA: 0x0001DCC5 File Offset: 0x0001BEC5
	[Obsolete("Use 'fillDirection' instead")]
	public bool inverted
	{
		get
		{
			return base.isInverted;
		}
		set
		{
		}
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0001DCC8 File Offset: 0x0001BEC8
	protected override void Upgrade()
	{
		if (this.direction != UISlider.Direction.Upgraded)
		{
			this.mValue = this.rawValue;
			if (this.foreground != null)
			{
				this.mFG = this.foreground.GetComponent<UIWidget>();
			}
			if (this.direction == UISlider.Direction.Horizontal)
			{
				this.mFill = (this.mInverted ? UIProgressBar.FillDirection.RightToLeft : UIProgressBar.FillDirection.LeftToRight);
			}
			else
			{
				this.mFill = (this.mInverted ? UIProgressBar.FillDirection.TopToBottom : UIProgressBar.FillDirection.BottomToTop);
			}
			this.direction = UISlider.Direction.Upgraded;
		}
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0001DD40 File Offset: 0x0001BF40
	protected override void OnStart()
	{
		UIEventListener uieventListener = UIEventListener.Get((this.mBG != null && (this.mBG.GetComponent<Collider>() != null || this.mBG.GetComponent<Collider2D>() != null)) ? this.mBG.gameObject : base.gameObject);
		uieventListener.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener.onPress, new UIEventListener.BoolDelegate(this.OnPressBackground));
		uieventListener.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(uieventListener.onDrag, new UIEventListener.VectorDelegate(this.OnDragBackground));
		if (this.thumb != null && (this.thumb.GetComponent<Collider>() != null || this.thumb.GetComponent<Collider2D>() != null) && (this.mFG == null || this.thumb != this.mFG.cachedTransform))
		{
			UIEventListener uieventListener2 = UIEventListener.Get(this.thumb.gameObject);
			uieventListener2.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener2.onPress, new UIEventListener.BoolDelegate(this.OnPressForeground));
			uieventListener2.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(uieventListener2.onDrag, new UIEventListener.VectorDelegate(this.OnDragForeground));
		}
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0001DE8C File Offset: 0x0001C08C
	protected void OnPressBackground(GameObject go, bool isPressed)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastEventPosition);
		if (!isPressed && this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0001DEC9 File Offset: 0x0001C0C9
	protected void OnDragBackground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
	protected void OnPressForeground(GameObject go, bool isPressed)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		if (isPressed)
		{
			this.mOffset = ((this.mFG == null) ? 0f : (base.value - base.ScreenToValue(UICamera.lastEventPosition)));
			return;
		}
		if (this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0001DF55 File Offset: 0x0001C155
	protected void OnDragForeground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = this.mOffset + base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001DF83 File Offset: 0x0001C183
	public override void OnPan(Vector2 delta)
	{
		if (base.enabled && this.isColliderEnabled)
		{
			base.OnPan(delta);
		}
	}

	// Token: 0x0400043C RID: 1084
	[HideInInspector]
	[SerializeField]
	private Transform foreground;

	// Token: 0x0400043D RID: 1085
	[HideInInspector]
	[SerializeField]
	private float rawValue = 1f;

	// Token: 0x0400043E RID: 1086
	[HideInInspector]
	[SerializeField]
	private UISlider.Direction direction = UISlider.Direction.Upgraded;

	// Token: 0x0400043F RID: 1087
	[HideInInspector]
	[SerializeField]
	protected bool mInverted;

	// Token: 0x020005DB RID: 1499
	private enum Direction
	{
		// Token: 0x04004D64 RID: 19812
		Horizontal,
		// Token: 0x04004D65 RID: 19813
		Vertical,
		// Token: 0x04004D66 RID: 19814
		Upgraded
	}
}
