using System;
using UnityEngine;

// Token: 0x0200004A RID: 74
[AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonScale : MonoBehaviour
{
	// Token: 0x0600014F RID: 335 RVA: 0x00014B39 File Offset: 0x00012D39
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mScale = this.tweenTarget.localScale;
		}
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00014B75 File Offset: 0x00012D75
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00014B90 File Offset: 0x00012D90
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenScale component = this.tweenTarget.GetComponent<TweenScale>();
			if (component != null)
			{
				component.value = this.mScale;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06000152 RID: 338 RVA: 0x00014BDC File Offset: 0x00012DDC
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenScale.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? Vector3.Scale(this.mScale, this.pressed) : (UICamera.IsHighlighted(base.gameObject) ? Vector3.Scale(this.mScale, this.hover) : this.mScale)).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00014C58 File Offset: 0x00012E58
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenScale.Begin(this.tweenTarget.gameObject, this.duration, isOver ? Vector3.Scale(this.mScale, this.hover) : this.mScale).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00014CB3 File Offset: 0x00012EB3
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000318 RID: 792
	public Transform tweenTarget;

	// Token: 0x04000319 RID: 793
	public Vector3 hover = new Vector3(1.1f, 1.1f, 1.1f);

	// Token: 0x0400031A RID: 794
	public Vector3 pressed = new Vector3(1.05f, 1.05f, 1.05f);

	// Token: 0x0400031B RID: 795
	public float duration = 0.2f;

	// Token: 0x0400031C RID: 796
	private Vector3 mScale;

	// Token: 0x0400031D RID: 797
	private bool mStarted;
}
