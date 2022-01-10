using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
	// Token: 0x06000136 RID: 310 RVA: 0x00014434 File Offset: 0x00012634
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x0001443D File Offset: 0x0001263D
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00014458 File Offset: 0x00012658
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOut)))
		{
			this.Send();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00014480 File Offset: 0x00012680
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x000144A8 File Offset: 0x000126A8
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x000144C4 File Offset: 0x000126C4
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000144DC File Offset: 0x000126DC
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000144F8 File Offset: 0x000126F8
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

	// Token: 0x040002FB RID: 763
	public GameObject target;

	// Token: 0x040002FC RID: 764
	public string functionName;

	// Token: 0x040002FD RID: 765
	public UIButtonMessage.Trigger trigger;

	// Token: 0x040002FE RID: 766
	public bool includeChildren;

	// Token: 0x040002FF RID: 767
	private bool mStarted;

	// Token: 0x020005C8 RID: 1480
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004D1C RID: 19740
		OnClick,
		// Token: 0x04004D1D RID: 19741
		OnMouseOver,
		// Token: 0x04004D1E RID: 19742
		OnMouseOut,
		// Token: 0x04004D1F RID: 19743
		OnPress,
		// Token: 0x04004D20 RID: 19744
		OnRelease,
		// Token: 0x04004D21 RID: 19745
		OnDoubleClick
	}
}
