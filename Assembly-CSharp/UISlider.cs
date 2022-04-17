using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Slider")]
public class UISlider : UIProgressBar
{
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060002B4 RID: 692 RVA: 0x0001DE20 File Offset: 0x0001C020
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
	// (get) Token: 0x060002B5 RID: 693 RVA: 0x0001DE5C File Offset: 0x0001C05C
	// (set) Token: 0x060002B6 RID: 694 RVA: 0x0001DE64 File Offset: 0x0001C064
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
	// (get) Token: 0x060002B7 RID: 695 RVA: 0x0001DE6D File Offset: 0x0001C06D
	// (set) Token: 0x060002B8 RID: 696 RVA: 0x0001DE75 File Offset: 0x0001C075
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

	// Token: 0x060002B9 RID: 697 RVA: 0x0001DE78 File Offset: 0x0001C078
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

	// Token: 0x060002BA RID: 698 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
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

	// Token: 0x060002BB RID: 699 RVA: 0x0001E03C File Offset: 0x0001C23C
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

	// Token: 0x060002BC RID: 700 RVA: 0x0001E079 File Offset: 0x0001C279
	protected void OnDragBackground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0001E0A0 File Offset: 0x0001C2A0
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

	// Token: 0x060002BE RID: 702 RVA: 0x0001E105 File Offset: 0x0001C305
	protected void OnDragForeground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = this.mOffset + base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001E133 File Offset: 0x0001C333
	public override void OnPan(Vector2 delta)
	{
		if (base.enabled && this.isColliderEnabled)
		{
			base.OnPan(delta);
		}
	}

	// Token: 0x04000445 RID: 1093
	[HideInInspector]
	[SerializeField]
	private Transform foreground;

	// Token: 0x04000446 RID: 1094
	[HideInInspector]
	[SerializeField]
	private float rawValue = 1f;

	// Token: 0x04000447 RID: 1095
	[HideInInspector]
	[SerializeField]
	private UISlider.Direction direction = UISlider.Direction.Upgraded;

	// Token: 0x04000448 RID: 1096
	[HideInInspector]
	[SerializeField]
	protected bool mInverted;

	// Token: 0x020005E8 RID: 1512
	private enum Direction
	{
		// Token: 0x04004E41 RID: 20033
		Horizontal,
		// Token: 0x04004E42 RID: 20034
		Vertical,
		// Token: 0x04004E43 RID: 20035
		Upgraded
	}
}
