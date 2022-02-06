using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
	// Token: 0x060001B6 RID: 438 RVA: 0x000173F6 File Offset: 0x000155F6
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00017425 File Offset: 0x00015625
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00017454 File Offset: 0x00015654
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0001747D File Offset: 0x0001567D
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x000174A6 File Offset: 0x000156A6
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x000174D5 File Offset: 0x000156D5
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00017504 File Offset: 0x00015704
	private void OnDrop(GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0001752E File Offset: 0x0001572E
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00017557 File Offset: 0x00015757
	private void OnScroll(float delta)
	{
		if (this.onScroll && this.target != null)
		{
			this.target.SendMessage("OnScroll", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x04000374 RID: 884
	public GameObject target;

	// Token: 0x04000375 RID: 885
	public bool onHover;

	// Token: 0x04000376 RID: 886
	public bool onPress;

	// Token: 0x04000377 RID: 887
	public bool onClick;

	// Token: 0x04000378 RID: 888
	public bool onDoubleClick;

	// Token: 0x04000379 RID: 889
	public bool onSelect;

	// Token: 0x0400037A RID: 890
	public bool onDrag;

	// Token: 0x0400037B RID: 891
	public bool onDrop;

	// Token: 0x0400037C RID: 892
	public bool onSubmit;

	// Token: 0x0400037D RID: 893
	public bool onScroll;
}
