using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Keys (Legacy)")]
public class UIButtonKeys : UIKeyNavigation
{
	// Token: 0x06000133 RID: 307 RVA: 0x000143C3 File Offset: 0x000125C3
	protected override void OnEnable()
	{
		this.Upgrade();
		base.OnEnable();
	}

	// Token: 0x06000134 RID: 308 RVA: 0x000143D4 File Offset: 0x000125D4
	public void Upgrade()
	{
		if (this.onClick == null && this.selectOnClick != null)
		{
			this.onClick = this.selectOnClick.gameObject;
			this.selectOnClick = null;
			NGUITools.SetDirty(this, "last change");
		}
		if (this.onLeft == null && this.selectOnLeft != null)
		{
			this.onLeft = this.selectOnLeft.gameObject;
			this.selectOnLeft = null;
			NGUITools.SetDirty(this, "last change");
		}
		if (this.onRight == null && this.selectOnRight != null)
		{
			this.onRight = this.selectOnRight.gameObject;
			this.selectOnRight = null;
			NGUITools.SetDirty(this, "last change");
		}
		if (this.onUp == null && this.selectOnUp != null)
		{
			this.onUp = this.selectOnUp.gameObject;
			this.selectOnUp = null;
			NGUITools.SetDirty(this, "last change");
		}
		if (this.onDown == null && this.selectOnDown != null)
		{
			this.onDown = this.selectOnDown.gameObject;
			this.selectOnDown = null;
			NGUITools.SetDirty(this, "last change");
		}
	}

	// Token: 0x04000301 RID: 769
	public UIButtonKeys selectOnClick;

	// Token: 0x04000302 RID: 770
	public UIButtonKeys selectOnUp;

	// Token: 0x04000303 RID: 771
	public UIButtonKeys selectOnDown;

	// Token: 0x04000304 RID: 772
	public UIButtonKeys selectOnLeft;

	// Token: 0x04000305 RID: 773
	public UIButtonKeys selectOnRight;
}
