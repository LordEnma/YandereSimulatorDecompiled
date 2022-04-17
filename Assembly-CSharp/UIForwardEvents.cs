using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
	// Token: 0x060001B6 RID: 438 RVA: 0x000175A6 File Offset: 0x000157A6
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x000175D5 File Offset: 0x000157D5
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00017604 File Offset: 0x00015804
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0001762D File Offset: 0x0001582D
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00017656 File Offset: 0x00015856
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00017685 File Offset: 0x00015885
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x000176B4 File Offset: 0x000158B4
	private void OnDrop(GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x000176DE File Offset: 0x000158DE
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00017707 File Offset: 0x00015907
	private void OnScroll(float delta)
	{
		if (this.onScroll && this.target != null)
		{
			this.target.SendMessage("OnScroll", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x0400037D RID: 893
	public GameObject target;

	// Token: 0x0400037E RID: 894
	public bool onHover;

	// Token: 0x0400037F RID: 895
	public bool onPress;

	// Token: 0x04000380 RID: 896
	public bool onClick;

	// Token: 0x04000381 RID: 897
	public bool onDoubleClick;

	// Token: 0x04000382 RID: 898
	public bool onSelect;

	// Token: 0x04000383 RID: 899
	public bool onDrag;

	// Token: 0x04000384 RID: 900
	public bool onDrop;

	// Token: 0x04000385 RID: 901
	public bool onSubmit;

	// Token: 0x04000386 RID: 902
	public bool onScroll;
}
