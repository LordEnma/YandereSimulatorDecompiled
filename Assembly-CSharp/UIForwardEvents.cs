using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
	// Token: 0x060001B6 RID: 438 RVA: 0x000173FE File Offset: 0x000155FE
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0001742D File Offset: 0x0001562D
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0001745C File Offset: 0x0001565C
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00017485 File Offset: 0x00015685
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x000174AE File Offset: 0x000156AE
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x000174DD File Offset: 0x000156DD
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0001750C File Offset: 0x0001570C
	private void OnDrop(GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00017536 File Offset: 0x00015736
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0001755F File Offset: 0x0001575F
	private void OnScroll(float delta)
	{
		if (this.onScroll && this.target != null)
		{
			this.target.SendMessage("OnScroll", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x04000372 RID: 882
	public GameObject target;

	// Token: 0x04000373 RID: 883
	public bool onHover;

	// Token: 0x04000374 RID: 884
	public bool onPress;

	// Token: 0x04000375 RID: 885
	public bool onClick;

	// Token: 0x04000376 RID: 886
	public bool onDoubleClick;

	// Token: 0x04000377 RID: 887
	public bool onSelect;

	// Token: 0x04000378 RID: 888
	public bool onDrag;

	// Token: 0x04000379 RID: 889
	public bool onDrop;

	// Token: 0x0400037A RID: 890
	public bool onSubmit;

	// Token: 0x0400037B RID: 891
	public bool onScroll;
}
