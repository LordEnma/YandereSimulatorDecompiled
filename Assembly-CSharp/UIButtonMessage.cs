using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
	// Token: 0x06000136 RID: 310 RVA: 0x0001471C File Offset: 0x0001291C
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00014725 File Offset: 0x00012925
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00014740 File Offset: 0x00012940
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOut)))
		{
			this.Send();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00014768 File Offset: 0x00012968
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00014790 File Offset: 0x00012990
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x000147AC File Offset: 0x000129AC
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000147C4 File Offset: 0x000129C4
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000147E0 File Offset: 0x000129E0
	private void Send()
	{
		if (string.IsNullOrEmpty(this.functionName))
		{
			return;
		}
		if (this.target == null)
		{
			this.target = base.gameObject;
		}
		if (this.includeChildren)
		{
			Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].gameObject.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
				i++;
			}
			return;
		}
		this.target.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x04000308 RID: 776
	public GameObject target;

	// Token: 0x04000309 RID: 777
	public string functionName;

	// Token: 0x0400030A RID: 778
	public UIButtonMessage.Trigger trigger;

	// Token: 0x0400030B RID: 779
	public bool includeChildren;

	// Token: 0x0400030C RID: 780
	private bool mStarted;

	// Token: 0x020005D2 RID: 1490
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004E2B RID: 20011
		OnClick,
		// Token: 0x04004E2C RID: 20012
		OnMouseOver,
		// Token: 0x04004E2D RID: 20013
		OnMouseOut,
		// Token: 0x04004E2E RID: 20014
		OnPress,
		// Token: 0x04004E2F RID: 20015
		OnRelease,
		// Token: 0x04004E30 RID: 20016
		OnDoubleClick
	}
}
