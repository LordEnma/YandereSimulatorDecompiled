using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
	// Token: 0x06000148 RID: 328 RVA: 0x00014AA9 File Offset: 0x00012CA9
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

	// Token: 0x06000149 RID: 329 RVA: 0x00014AE5 File Offset: 0x00012CE5
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00014B00 File Offset: 0x00012D00
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

	// Token: 0x0600014B RID: 331 RVA: 0x00014B4C File Offset: 0x00012D4C
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

	// Token: 0x0600014C RID: 332 RVA: 0x00014BD4 File Offset: 0x00012DD4
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

	// Token: 0x0600014D RID: 333 RVA: 0x00014C34 File Offset: 0x00012E34
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000314 RID: 788
	public Transform tweenTarget;

	// Token: 0x04000315 RID: 789
	public Vector3 hover = Vector3.zero;

	// Token: 0x04000316 RID: 790
	public Vector3 pressed = Vector3.zero;

	// Token: 0x04000317 RID: 791
	public float duration = 0.2f;

	// Token: 0x04000318 RID: 792
	private Quaternion mRot;

	// Token: 0x04000319 RID: 793
	private bool mStarted;
}
