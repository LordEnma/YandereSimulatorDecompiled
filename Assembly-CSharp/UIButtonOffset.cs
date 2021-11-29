using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
	// Token: 0x0600013F RID: 319 RVA: 0x0001458C File Offset: 0x0001278C
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

	// Token: 0x06000140 RID: 320 RVA: 0x000145C8 File Offset: 0x000127C8
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x000145E4 File Offset: 0x000127E4
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

	// Token: 0x06000142 RID: 322 RVA: 0x00014630 File Offset: 0x00012830
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

	// Token: 0x06000143 RID: 323 RVA: 0x000146B4 File Offset: 0x000128B4
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

	// Token: 0x06000144 RID: 324 RVA: 0x0001470F File Offset: 0x0001290F
	private void OnDragOver()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos + this.hover).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00014746 File Offset: 0x00012946
	private void OnDragOut()
	{
		if (this.mPressed)
		{
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, this.mPos).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00014772 File Offset: 0x00012972
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x04000300 RID: 768
	public Transform tweenTarget;

	// Token: 0x04000301 RID: 769
	public Vector3 hover = Vector3.zero;

	// Token: 0x04000302 RID: 770
	public Vector3 pressed = new Vector3(2f, -2f);

	// Token: 0x04000303 RID: 771
	public float duration = 0.2f;

	// Token: 0x04000304 RID: 772
	[NonSerialized]
	private Vector3 mPos;

	// Token: 0x04000305 RID: 773
	[NonSerialized]
	private bool mStarted;

	// Token: 0x04000306 RID: 774
	[NonSerialized]
	private bool mPressed;
}
