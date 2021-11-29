using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000214 RID: 532 RVA: 0x00018EC0 File Offset: 0x000170C0
	private bool canPlay
	{
		get
		{
			if (!base.enabled)
			{
				return false;
			}
			UIButton component = base.GetComponent<UIButton>();
			return component == null || component.isEnabled;
		}
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00018EEF File Offset: 0x000170EF
	private void OnEnable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnEnable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00018F12 File Offset: 0x00017112
	private void OnDisable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnDisable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00018F38 File Offset: 0x00017138
	private void OnHover(bool isOver)
	{
		if (this.trigger == UIPlaySound.Trigger.OnMouseOver)
		{
			if (this.mIsOver == isOver)
			{
				return;
			}
			this.mIsOver = isOver;
		}
		if (this.canPlay && ((isOver && this.trigger == UIPlaySound.Trigger.OnMouseOver) || (!isOver && this.trigger == UIPlaySound.Trigger.OnMouseOut)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00018F98 File Offset: 0x00017198
	private void OnPress(bool isPressed)
	{
		if (this.trigger == UIPlaySound.Trigger.OnPress)
		{
			if (this.mIsOver == isPressed)
			{
				return;
			}
			this.mIsOver = isPressed;
		}
		if (this.canPlay && ((isPressed && this.trigger == UIPlaySound.Trigger.OnPress) || (!isPressed && this.trigger == UIPlaySound.Trigger.OnRelease)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00018FF7 File Offset: 0x000171F7
	private void OnClick()
	{
		if (this.canPlay && this.trigger == UIPlaySound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00019021 File Offset: 0x00017221
	private void OnSelect(bool isSelected)
	{
		if (this.canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0001903D File Offset: 0x0001723D
	public void Play()
	{
		NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
	}

	// Token: 0x040003B3 RID: 947
	public AudioClip audioClip;

	// Token: 0x040003B4 RID: 948
	public UIPlaySound.Trigger trigger;

	// Token: 0x040003B5 RID: 949
	[Range(0f, 1f)]
	public float volume = 1f;

	// Token: 0x040003B6 RID: 950
	[Range(0f, 2f)]
	public float pitch = 1f;

	// Token: 0x040003B7 RID: 951
	private bool mIsOver;

	// Token: 0x020005CE RID: 1486
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004CE9 RID: 19689
		OnClick,
		// Token: 0x04004CEA RID: 19690
		OnMouseOver,
		// Token: 0x04004CEB RID: 19691
		OnMouseOut,
		// Token: 0x04004CEC RID: 19692
		OnPress,
		// Token: 0x04004CED RID: 19693
		OnRelease,
		// Token: 0x04004CEE RID: 19694
		Custom,
		// Token: 0x04004CEF RID: 19695
		OnEnable,
		// Token: 0x04004CF0 RID: 19696
		OnDisable
	}
}
