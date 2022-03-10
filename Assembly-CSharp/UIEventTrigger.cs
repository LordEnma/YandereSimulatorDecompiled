using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000055 RID: 85
[AddComponentMenu("NGUI/Interaction/Event Trigger")]
public class UIEventTrigger : MonoBehaviour
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x060001AA RID: 426 RVA: 0x00017220 File Offset: 0x00015420
	public bool isColliderEnabled
	{
		get
		{
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
	}

	// Token: 0x060001AB RID: 427 RVA: 0x0001725C File Offset: 0x0001545C
	private void OnHover(bool isOver)
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		if (isOver)
		{
			EventDelegate.Execute(this.onHoverOver);
		}
		else
		{
			EventDelegate.Execute(this.onHoverOut);
		}
		UIEventTrigger.current = null;
	}

	// Token: 0x060001AC RID: 428 RVA: 0x0001729B File Offset: 0x0001549B
	private void OnPress(bool pressed)
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		if (pressed)
		{
			EventDelegate.Execute(this.onPress);
		}
		else
		{
			EventDelegate.Execute(this.onRelease);
		}
		UIEventTrigger.current = null;
	}

	// Token: 0x060001AD RID: 429 RVA: 0x000172DA File Offset: 0x000154DA
	private void OnSelect(bool selected)
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		if (selected)
		{
			EventDelegate.Execute(this.onSelect);
		}
		else
		{
			EventDelegate.Execute(this.onDeselect);
		}
		UIEventTrigger.current = null;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00017319 File Offset: 0x00015519
	private void OnClick()
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onClick);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00017348 File Offset: 0x00015548
	private void OnDoubleClick()
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDoubleClick);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00017377 File Offset: 0x00015577
	private void OnDragStart()
	{
		if (UIEventTrigger.current != null)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDragStart);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0001739E File Offset: 0x0001559E
	private void OnDragEnd()
	{
		if (UIEventTrigger.current != null)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDragEnd);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x000173C5 File Offset: 0x000155C5
	private void OnDragOver(GameObject go)
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDragOver);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x000173F4 File Offset: 0x000155F4
	private void OnDragOut(GameObject go)
	{
		if (UIEventTrigger.current != null || !this.isColliderEnabled)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDragOut);
		UIEventTrigger.current = null;
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00017423 File Offset: 0x00015623
	private void OnDrag(Vector2 delta)
	{
		if (UIEventTrigger.current != null)
		{
			return;
		}
		UIEventTrigger.current = this;
		EventDelegate.Execute(this.onDrag);
		UIEventTrigger.current = null;
	}

	// Token: 0x0400036F RID: 879
	public static UIEventTrigger current;

	// Token: 0x04000370 RID: 880
	public List<EventDelegate> onHoverOver = new List<EventDelegate>();

	// Token: 0x04000371 RID: 881
	public List<EventDelegate> onHoverOut = new List<EventDelegate>();

	// Token: 0x04000372 RID: 882
	public List<EventDelegate> onPress = new List<EventDelegate>();

	// Token: 0x04000373 RID: 883
	public List<EventDelegate> onRelease = new List<EventDelegate>();

	// Token: 0x04000374 RID: 884
	public List<EventDelegate> onSelect = new List<EventDelegate>();

	// Token: 0x04000375 RID: 885
	public List<EventDelegate> onDeselect = new List<EventDelegate>();

	// Token: 0x04000376 RID: 886
	public List<EventDelegate> onClick = new List<EventDelegate>();

	// Token: 0x04000377 RID: 887
	public List<EventDelegate> onDoubleClick = new List<EventDelegate>();

	// Token: 0x04000378 RID: 888
	public List<EventDelegate> onDragStart = new List<EventDelegate>();

	// Token: 0x04000379 RID: 889
	public List<EventDelegate> onDragEnd = new List<EventDelegate>();

	// Token: 0x0400037A RID: 890
	public List<EventDelegate> onDragOver = new List<EventDelegate>();

	// Token: 0x0400037B RID: 891
	public List<EventDelegate> onDragOut = new List<EventDelegate>();

	// Token: 0x0400037C RID: 892
	public List<EventDelegate> onDrag = new List<EventDelegate>();
}
