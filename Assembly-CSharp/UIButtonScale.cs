using System;
using UnityEngine;

// Token: 0x0200004A RID: 74
[AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonScale : MonoBehaviour
{
	// Token: 0x0600014F RID: 335 RVA: 0x00014C79 File Offset: 0x00012E79
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

	// Token: 0x06000150 RID: 336 RVA: 0x00014CB5 File Offset: 0x00012EB5
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00014CD0 File Offset: 0x00012ED0
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

	// Token: 0x06000152 RID: 338 RVA: 0x00014D1C File Offset: 0x00012F1C
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

	// Token: 0x06000153 RID: 339 RVA: 0x00014D98 File Offset: 0x00012F98
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

	// Token: 0x06000154 RID: 340 RVA: 0x00014DF3 File Offset: 0x00012FF3
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0400031A RID: 794
	public Transform tweenTarget;

	// Token: 0x0400031B RID: 795
	public Vector3 hover = new Vector3(1.1f, 1.1f, 1.1f);

	// Token: 0x0400031C RID: 796
	public Vector3 pressed = new Vector3(1.05f, 1.05f, 1.05f);

	// Token: 0x0400031D RID: 797
	public float duration = 0.2f;

	// Token: 0x0400031E RID: 798
	private Vector3 mScale;

	// Token: 0x0400031F RID: 799
	private bool mStarted;
}
