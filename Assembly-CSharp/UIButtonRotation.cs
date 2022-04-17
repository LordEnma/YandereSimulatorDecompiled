using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
	// Token: 0x06000148 RID: 328 RVA: 0x00014969 File Offset: 0x00012B69
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

	// Token: 0x06000149 RID: 329 RVA: 0x000149A5 File Offset: 0x00012BA5
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000149C0 File Offset: 0x00012BC0
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

	// Token: 0x0600014B RID: 331 RVA: 0x00014A0C File Offset: 0x00012C0C
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

	// Token: 0x0600014C RID: 332 RVA: 0x00014A94 File Offset: 0x00012C94
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

	// Token: 0x0600014D RID: 333 RVA: 0x00014AF4 File Offset: 0x00012CF4
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000312 RID: 786
	public Transform tweenTarget;

	// Token: 0x04000313 RID: 787
	public Vector3 hover = Vector3.zero;

	// Token: 0x04000314 RID: 788
	public Vector3 pressed = Vector3.zero;

	// Token: 0x04000315 RID: 789
	public float duration = 0.2f;

	// Token: 0x04000316 RID: 790
	private Quaternion mRot;

	// Token: 0x04000317 RID: 791
	private bool mStarted;
}
