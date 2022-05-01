using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
	// Token: 0x0600013F RID: 319 RVA: 0x00014874 File Offset: 0x00012A74
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

	// Token: 0x06000140 RID: 320 RVA: 0x000148B0 File Offset: 0x00012AB0
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x000148CC File Offset: 0x00012ACC
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

	// Token: 0x06000142 RID: 322 RVA: 0x00014918 File Offset: 0x00012B18
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

	// Token: 0x06000143 RID: 323 RVA: 0x0001499C File Offset: 0x00012B9C
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

	// Token: 0x06000144 RID: 324 RVA: 0x000149F7 File Offset: 0x00012BF7
	private void OnDragOver()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos + this.hover).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00014A2E File Offset: 0x00012C2E
	private void OnDragOut()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00014A5A File Offset: 0x00012C5A
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0400030D RID: 781
	public Transform tweenTarget;

	// Token: 0x0400030E RID: 782
	public Vector3 hover = Vector3.zero;

	// Token: 0x0400030F RID: 783
	public Vector3 pressed = new Vector3(2f, -2f);

	// Token: 0x04000310 RID: 784
	public float duration = 0.2f;

	// Token: 0x04000311 RID: 785
	[NonSerialized]
	private Vector3 mPos;

	// Token: 0x04000312 RID: 786
	[NonSerialized]
	private bool mStarted;

	// Token: 0x04000313 RID: 787
	[NonSerialized]
	private bool mPressed;
}
