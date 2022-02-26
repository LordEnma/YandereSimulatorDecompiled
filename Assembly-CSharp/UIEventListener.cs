using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
	// Token: 0x1700008A RID: 138
	// (get) Token: 0x060004BA RID: 1210 RVA: 0x00030848 File Offset: 0x0002EA48
	private bool isColliderEnabled
	{
		get
		{
			if (!this.needsActiveCollider)
			{
				return true;
			}
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x0003088E File Offset: 0x0002EA8E
	private void OnSubmit()
	{
		if (this.isColliderEnabled && this.onSubmit != null)
		{
			this.onSubmit(base.gameObject);
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x000308B1 File Offset: 0x0002EAB1
	private void OnClick()
	{
		if (this.isColliderEnabled && this.onClick != null)
		{
			this.onClick(base.gameObject);
		}
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000308D4 File Offset: 0x0002EAD4
	private void OnDoubleClick()
	{
		if (this.isColliderEnabled && this.onDoubleClick != null)
		{
			this.onDoubleClick(base.gameObject);
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x000308F7 File Offset: 0x0002EAF7
	private void OnHover(bool isOver)
	{
		if (this.isColliderEnabled && this.onHover != null)
		{
			this.onHover(base.gameObject, isOver);
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0003091B File Offset: 0x0002EB1B
	private void OnPress(bool isPressed)
	{
		if (this.isColliderEnabled && this.onPress != null)
		{
			this.onPress(base.gameObject, isPressed);
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x0003093F File Offset: 0x0002EB3F
	private void OnSelect(bool selected)
	{
		if (this.isColliderEnabled && this.onSelect != null)
		{
			this.onSelect(base.gameObject, selected);
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00030963 File Offset: 0x0002EB63
	private void OnScroll(float delta)
	{
		if (this.isColliderEnabled && this.onScroll != null)
		{
			this.onScroll(base.gameObject, delta);
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00030987 File Offset: 0x0002EB87
	private void OnDragStart()
	{
		if (this.onDragStart != null)
		{
			this.onDragStart(base.gameObject);
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x000309A2 File Offset: 0x0002EBA2
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag != null)
		{
			this.onDrag(base.gameObject, delta);
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x000309BE File Offset: 0x0002EBBE
	private void OnDragOver()
	{
		if (this.isColliderEnabled && this.onDragOver != null)
		{
			this.onDragOver(base.gameObject);
		}
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x000309E1 File Offset: 0x0002EBE1
	private void OnDragOut()
	{
		if (this.isColliderEnabled && this.onDragOut != null)
		{
			this.onDragOut(base.gameObject);
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00030A04 File Offset: 0x0002EC04
	private void OnDragEnd()
	{
		if (this.onDragEnd != null)
		{
			this.onDragEnd(base.gameObject);
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00030A1F File Offset: 0x0002EC1F
	private void OnDrop(GameObject go)
	{
		if (this.isColliderEnabled && this.onDrop != null)
		{
			this.onDrop(base.gameObject, go);
		}
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00030A43 File Offset: 0x0002EC43
	private void OnKey(KeyCode key)
	{
		if (this.isColliderEnabled && this.onKey != null)
		{
			this.onKey(base.gameObject, key);
		}
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00030A67 File Offset: 0x0002EC67
	private void OnTooltip(bool show)
	{
		if (this.isColliderEnabled && this.onTooltip != null)
		{
			this.onTooltip(base.gameObject, show);
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00030A8C File Offset: 0x0002EC8C
	public void Clear()
	{
		this.onSubmit = null;
		this.onClick = null;
		this.onDoubleClick = null;
		this.onHover = null;
		this.onPress = null;
		this.onSelect = null;
		this.onScroll = null;
		this.onDragStart = null;
		this.onDrag = null;
		this.onDragOver = null;
		this.onDragOut = null;
		this.onDragEnd = null;
		this.onDrop = null;
		this.onKey = null;
		this.onTooltip = null;
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x00030B04 File Offset: 0x0002ED04
	public static UIEventListener Get(GameObject go)
	{
		UIEventListener uieventListener = go.GetComponent<UIEventListener>();
		if (uieventListener == null)
		{
			uieventListener = go.AddComponent<UIEventListener>();
		}
		return uieventListener;
	}

	// Token: 0x0400053C RID: 1340
	public object parameter;

	// Token: 0x0400053D RID: 1341
	public UIEventListener.VoidDelegate onSubmit;

	// Token: 0x0400053E RID: 1342
	public UIEventListener.VoidDelegate onClick;

	// Token: 0x0400053F RID: 1343
	public UIEventListener.VoidDelegate onDoubleClick;

	// Token: 0x04000540 RID: 1344
	public UIEventListener.BoolDelegate onHover;

	// Token: 0x04000541 RID: 1345
	public UIEventListener.BoolDelegate onPress;

	// Token: 0x04000542 RID: 1346
	public UIEventListener.BoolDelegate onSelect;

	// Token: 0x04000543 RID: 1347
	public UIEventListener.FloatDelegate onScroll;

	// Token: 0x04000544 RID: 1348
	public UIEventListener.VoidDelegate onDragStart;

	// Token: 0x04000545 RID: 1349
	public UIEventListener.VectorDelegate onDrag;

	// Token: 0x04000546 RID: 1350
	public UIEventListener.VoidDelegate onDragOver;

	// Token: 0x04000547 RID: 1351
	public UIEventListener.VoidDelegate onDragOut;

	// Token: 0x04000548 RID: 1352
	public UIEventListener.VoidDelegate onDragEnd;

	// Token: 0x04000549 RID: 1353
	public UIEventListener.ObjectDelegate onDrop;

	// Token: 0x0400054A RID: 1354
	public UIEventListener.KeyCodeDelegate onKey;

	// Token: 0x0400054B RID: 1355
	public UIEventListener.BoolDelegate onTooltip;

	// Token: 0x0400054C RID: 1356
	public bool needsActiveCollider = true;

	// Token: 0x020005F8 RID: 1528
	// (Invoke) Token: 0x06002561 RID: 9569
	public delegate void VoidDelegate(GameObject go);

	// Token: 0x020005F9 RID: 1529
	// (Invoke) Token: 0x06002565 RID: 9573
	public delegate void BoolDelegate(GameObject go, bool state);

	// Token: 0x020005FA RID: 1530
	// (Invoke) Token: 0x06002569 RID: 9577
	public delegate void FloatDelegate(GameObject go, float delta);

	// Token: 0x020005FB RID: 1531
	// (Invoke) Token: 0x0600256D RID: 9581
	public delegate void VectorDelegate(GameObject go, Vector2 delta);

	// Token: 0x020005FC RID: 1532
	// (Invoke) Token: 0x06002571 RID: 9585
	public delegate void ObjectDelegate(GameObject go, GameObject obj);

	// Token: 0x020005FD RID: 1533
	// (Invoke) Token: 0x06002575 RID: 9589
	public delegate void KeyCodeDelegate(GameObject go, KeyCode key);
}
