using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
	// Token: 0x060001B6 RID: 438 RVA: 0x000176E6 File Offset: 0x000158E6
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00017715 File Offset: 0x00015915
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00017744 File Offset: 0x00015944
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0001776D File Offset: 0x0001596D
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00017796 File Offset: 0x00015996
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x000177C5 File Offset: 0x000159C5
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x000177F4 File Offset: 0x000159F4
	private void OnDrop(GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0001781E File Offset: 0x00015A1E
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00017847 File Offset: 0x00015A47
	private void OnScroll(float delta)
	{
		if (this.onScroll && this.target != null)
		{
			this.target.SendMessage("OnScroll", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x0400037F RID: 895
	public GameObject target;

	// Token: 0x04000380 RID: 896
	public bool onHover;

	// Token: 0x04000381 RID: 897
	public bool onPress;

	// Token: 0x04000382 RID: 898
	public bool onClick;

	// Token: 0x04000383 RID: 899
	public bool onDoubleClick;

	// Token: 0x04000384 RID: 900
	public bool onSelect;

	// Token: 0x04000385 RID: 901
	public bool onDrag;

	// Token: 0x04000386 RID: 902
	public bool onDrop;

	// Token: 0x04000387 RID: 903
	public bool onSubmit;

	// Token: 0x04000388 RID: 904
	public bool onScroll;
}
