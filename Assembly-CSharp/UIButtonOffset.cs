using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
	// Token: 0x0600013F RID: 319 RVA: 0x0001467C File Offset: 0x0001287C
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mPos = this.tweenTarget.localPosition;
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x000146B8 File Offset: 0x000128B8
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x000146D4 File Offset: 0x000128D4
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenPosition component = this.tweenTarget.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.value = this.mPos;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00014720 File Offset: 0x00012920
	private void OnPress(bool isPressed)
	{
		this.mPressed = isPressed;
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, isPressed ? (this.mPos + this.pressed) : (UICamera.IsHighlighted(base.gameObject) ? (this.mPos + this.hover) : this.mPos)).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x000147A4 File Offset: 0x000129A4
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, isOver ? (this.mPos + this.hover) : this.mPos).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000144 RID: 324 RVA: 0x000147FF File Offset: 0x000129FF
	private void OnDragOver()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos + this.hover).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00014836 File Offset: 0x00012A36
	private void OnDragOut()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00014862 File Offset: 0x00012A62
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0400030B RID: 779
	public Transform tweenTarget;

	// Token: 0x0400030C RID: 780
	public Vector3 hover = Vector3.zero;

	// Token: 0x0400030D RID: 781
	public Vector3 pressed = new Vector3(2f, -2f);

	// Token: 0x0400030E RID: 782
	public float duration = 0.2f;

	// Token: 0x0400030F RID: 783
	[NonSerialized]
	private Vector3 mPos;

	// Token: 0x04000310 RID: 784
	[NonSerialized]
	private bool mStarted;

	// Token: 0x04000311 RID: 785
	[NonSerialized]
	private bool mPressed;
}
