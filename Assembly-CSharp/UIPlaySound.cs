using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000214 RID: 532 RVA: 0x00018FB0 File Offset: 0x000171B0
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

	// Token: 0x06000215 RID: 533 RVA: 0x00018FDF File Offset: 0x000171DF
	private void OnEnable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnEnable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00019002 File Offset: 0x00017202
	private void OnDisable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnDisable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00019028 File Offset: 0x00017228
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

	// Token: 0x06000218 RID: 536 RVA: 0x00019088 File Offset: 0x00017288
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

	// Token: 0x06000219 RID: 537 RVA: 0x000190E7 File Offset: 0x000172E7
	private void OnClick()
	{
		if (this.canPlay && this.trigger == UIPlaySound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00019111 File Offset: 0x00017311
	private void OnSelect(bool isSelected)
	{
		if (this.canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0001912D File Offset: 0x0001732D
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
		// Token: 0x04004DFD RID: 19965
		OnClick,
		// Token: 0x04004DFE RID: 19966
		OnMouseOver,
		// Token: 0x04004DFF RID: 19967
		OnMouseOut,
		// Token: 0x04004E00 RID: 19968
		OnPress,
		// Token: 0x04004E01 RID: 19969
		OnRelease,
		// Token: 0x04004E02 RID: 19970
		Custom,
		// Token: 0x04004E03 RID: 19971
		OnEnable,
		// Token: 0x04004E04 RID: 19972
		OnDisable
	}
}
