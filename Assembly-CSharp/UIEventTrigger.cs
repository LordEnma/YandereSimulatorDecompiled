using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000055 RID: 85
[AddComponentMenu("NGUI/Interaction/Event Trigger")]
public class UIEventTrigger : MonoBehaviour
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x060001AA RID: 426 RVA: 0x00017128 File Offset: 0x00015328
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

	// Token: 0x060001AB RID: 427 RVA: 0x00017164 File Offset: 0x00015364
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

	// Token: 0x060001AC RID: 428 RVA: 0x000171A3 File Offset: 0x000153A3
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

	// Token: 0x060001AD RID: 429 RVA: 0x000171E2 File Offset: 0x000153E2
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

	// Token: 0x060001AE RID: 430 RVA: 0x00017221 File Offset: 0x00015421
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

	// Token: 0x060001AF RID: 431 RVA: 0x00017250 File Offset: 0x00015450
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

	// Token: 0x060001B0 RID: 432 RVA: 0x0001727F File Offset: 0x0001547F
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

	// Token: 0x060001B1 RID: 433 RVA: 0x000172A6 File Offset: 0x000154A6
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

	// Token: 0x060001B2 RID: 434 RVA: 0x000172CD File Offset: 0x000154CD
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

	// Token: 0x060001B3 RID: 435 RVA: 0x000172FC File Offset: 0x000154FC
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

	// Token: 0x060001B4 RID: 436 RVA: 0x0001732B File Offset: 0x0001552B
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

	// Token: 0x04000365 RID: 869
	public static UIEventTrigger current;

	// Token: 0x04000366 RID: 870
	public List<EventDelegate> onHoverOver = new List<EventDelegate>();

	// Token: 0x04000367 RID: 871
	public List<EventDelegate> onHoverOut = new List<EventDelegate>();

	// Token: 0x04000368 RID: 872
	public List<EventDelegate> onPress = new List<EventDelegate>();

	// Token: 0x04000369 RID: 873
	public List<EventDelegate> onRelease = new List<EventDelegate>();

	// Token: 0x0400036A RID: 874
	public List<EventDelegate> onSelect = new List<EventDelegate>();

	// Token: 0x0400036B RID: 875
	public List<EventDelegate> onDeselect = new List<EventDelegate>();

	// Token: 0x0400036C RID: 876
	public List<EventDelegate> onClick = new List<EventDelegate>();

	// Token: 0x0400036D RID: 877
	public List<EventDelegate> onDoubleClick = new List<EventDelegate>();

	// Token: 0x0400036E RID: 878
	public List<EventDelegate> onDragStart = new List<EventDelegate>();

	// Token: 0x0400036F RID: 879
	public List<EventDelegate> onDragEnd = new List<EventDelegate>();

	// Token: 0x04000370 RID: 880
	public List<EventDelegate> onDragOver = new List<EventDelegate>();

	// Token: 0x04000371 RID: 881
	public List<EventDelegate> onDragOut = new List<EventDelegate>();

	// Token: 0x04000372 RID: 882
	public List<EventDelegate> onDrag = new List<EventDelegate>();
}
