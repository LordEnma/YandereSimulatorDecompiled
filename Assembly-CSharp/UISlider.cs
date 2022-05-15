using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Slider")]
public class UISlider : UIProgressBar
{
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060002B4 RID: 692 RVA: 0x0001DF60 File Offset: 0x0001C160
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
	// (get) Token: 0x060002B5 RID: 693 RVA: 0x0001DF9C File Offset: 0x0001C19C
	// (set) Token: 0x060002B6 RID: 694 RVA: 0x0001DFA4 File Offset: 0x0001C1A4
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
	// (get) Token: 0x060002B7 RID: 695 RVA: 0x0001DFAD File Offset: 0x0001C1AD
	// (set) Token: 0x060002B8 RID: 696 RVA: 0x0001DFB5 File Offset: 0x0001C1B5
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

	// Token: 0x060002B9 RID: 697 RVA: 0x0001DFB8 File Offset: 0x0001C1B8
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

	// Token: 0x060002BA RID: 698 RVA: 0x0001E030 File Offset: 0x0001C230
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

	// Token: 0x060002BB RID: 699 RVA: 0x0001E17C File Offset: 0x0001C37C
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

	// Token: 0x060002BC RID: 700 RVA: 0x0001E1B9 File Offset: 0x0001C3B9
	protected void OnDragBackground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0001E1E0 File Offset: 0x0001C3E0
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

	// Token: 0x060002BE RID: 702 RVA: 0x0001E245 File Offset: 0x0001C445
	protected void OnDragForeground(GameObject go, Vector2 delta)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
		{
			return;
		}
		this.mCam = UICamera.currentCamera;
		base.value = this.mOffset + base.ScreenToValue(UICamera.lastEventPosition);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001E273 File Offset: 0x0001C473
	public override void OnPan(Vector2 delta)
	{
		if (base.enabled && this.isColliderEnabled)
		{
			base.OnPan(delta);
		}
	}

	// Token: 0x04000447 RID: 1095
	[HideInInspector]
	[SerializeField]
	private Transform foreground;

	// Token: 0x04000448 RID: 1096
	[HideInInspector]
	[SerializeField]
	private float rawValue = 1f;

	// Token: 0x04000449 RID: 1097
	[HideInInspector]
	[SerializeField]
	private UISlider.Direction direction = UISlider.Direction.Upgraded;

	// Token: 0x0400044A RID: 1098
	[HideInInspector]
	[SerializeField]
	protected bool mInverted;

	// Token: 0x020005EA RID: 1514
	private enum Direction
	{
		// Token: 0x04004E86 RID: 20102
		Horizontal,
		// Token: 0x04004E87 RID: 20103
		Vertical,
		// Token: 0x04004E88 RID: 20104
		Upgraded
	}
}
