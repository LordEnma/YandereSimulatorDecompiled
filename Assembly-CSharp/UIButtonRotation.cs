using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
	// Token: 0x06000148 RID: 328 RVA: 0x000147C1 File Offset: 0x000129C1
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mRot = this.tweenTarget.localRotation;
		}
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000147FD File Offset: 0x000129FD
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00014818 File Offset: 0x00012A18
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenRotation component = this.tweenTarget.GetComponent<TweenRotation>();
			if (component != null)
			{
				component.value = this.mRot;
				component.enabled = false;
			}
		}
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00014864 File Offset: 0x00012A64
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? (this.mRot * Quaternion.Euler(this.pressed)) : (UICamera.IsHighlighted(base.gameObject) ? (this.mRot * Quaternion.Euler(this.hover)) : this.mRot)).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x000148EC File Offset: 0x00012AEC
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, isOver ? (this.mRot * Quaternion.Euler(this.hover)) : this.mRot).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0001494C File Offset: 0x00012B4C
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000307 RID: 775
	public Transform tweenTarget;

	// Token: 0x04000308 RID: 776
	public Vector3 hover = Vector3.zero;

	// Token: 0x04000309 RID: 777
	public Vector3 pressed = Vector3.zero;

	// Token: 0x0400030A RID: 778
	public float duration = 0.2f;

	// Token: 0x0400030B RID: 779
	private Quaternion mRot;

	// Token: 0x0400030C RID: 780
	private bool mStarted;
}
