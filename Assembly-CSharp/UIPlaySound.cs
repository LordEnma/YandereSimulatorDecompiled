using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000214 RID: 532 RVA: 0x00019068 File Offset: 0x00017268
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

	// Token: 0x06000215 RID: 533 RVA: 0x00019097 File Offset: 0x00017297
	private void OnEnable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnEnable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x000190BA File Offset: 0x000172BA
	private void OnDisable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnDisable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x000190E0 File Offset: 0x000172E0
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

	// Token: 0x06000218 RID: 536 RVA: 0x00019140 File Offset: 0x00017340
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

	// Token: 0x06000219 RID: 537 RVA: 0x0001919F File Offset: 0x0001739F
	private void OnClick()
	{
		if (this.canPlay && this.trigger == UIPlaySound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x000191C9 File Offset: 0x000173C9
	private void OnSelect(bool isSelected)
	{
		if (this.canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x000191E5 File Offset: 0x000173E5
	public void Play()
	{
		NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
	}

	// Token: 0x040003BE RID: 958
	public AudioClip audioClip;

	// Token: 0x040003BF RID: 959
	public UIPlaySound.Trigger trigger;

	// Token: 0x040003C0 RID: 960
	[Range(0f, 1f)]
	public float volume = 1f;

	// Token: 0x040003C1 RID: 961
	[Range(0f, 2f)]
	public float pitch = 1f;

	// Token: 0x040003C2 RID: 962
	private bool mIsOver;

	// Token: 0x020005DA RID: 1498
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004E0F RID: 19983
		OnClick,
		// Token: 0x04004E10 RID: 19984
		OnMouseOver,
		// Token: 0x04004E11 RID: 19985
		OnMouseOut,
		// Token: 0x04004E12 RID: 19986
		OnPress,
		// Token: 0x04004E13 RID: 19987
		OnRelease,
		// Token: 0x04004E14 RID: 19988
		Custom,
		// Token: 0x04004E15 RID: 19989
		OnEnable,
		// Token: 0x04004E16 RID: 19990
		OnDisable
	}
}
