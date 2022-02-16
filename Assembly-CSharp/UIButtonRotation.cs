using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
	// Token: 0x06000148 RID: 328 RVA: 0x000147B9 File Offset: 0x000129B9
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

	// Token: 0x06000149 RID: 329 RVA: 0x000147F5 File Offset: 0x000129F5
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00014810 File Offset: 0x00012A10
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

	// Token: 0x0600014B RID: 331 RVA: 0x0001485C File Offset: 0x00012A5C
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

	// Token: 0x0600014C RID: 332 RVA: 0x000148E4 File Offset: 0x00012AE4
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

	// Token: 0x0600014D RID: 333 RVA: 0x00014944 File Offset: 0x00012B44
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000309 RID: 777
	public Transform tweenTarget;

	// Token: 0x0400030A RID: 778
	public Vector3 hover = Vector3.zero;

	// Token: 0x0400030B RID: 779
	public Vector3 pressed = Vector3.zero;

	// Token: 0x0400030C RID: 780
	public float duration = 0.2f;

	// Token: 0x0400030D RID: 781
	private Quaternion mRot;

	// Token: 0x0400030E RID: 782
	private bool mStarted;
}
