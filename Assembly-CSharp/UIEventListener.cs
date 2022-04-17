using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
	// Token: 0x1700008A RID: 138
	// (get) Token: 0x060004BA RID: 1210 RVA: 0x000309F8 File Offset: 0x0002EBF8
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

	// Token: 0x060004BB RID: 1211 RVA: 0x00030A3E File Offset: 0x0002EC3E
	private void OnSubmit()
	{
		if (this.isColliderEnabled && this.onSubmit != null)
		{
			this.onSubmit(base.gameObject);
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00030A61 File Offset: 0x0002EC61
	private void OnClick()
	{
		if (this.isColliderEnabled && this.onClick != null)
		{
			this.onClick(base.gameObject);
		}
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00030A84 File Offset: 0x0002EC84
	private void OnDoubleClick()
	{
		if (this.isColliderEnabled && this.onDoubleClick != null)
		{
			this.onDoubleClick(base.gameObject);
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00030AA7 File Offset: 0x0002ECA7
	private void OnHover(bool isOver)
	{
		if (this.isColliderEnabled && this.onHover != null)
		{
			this.onHover(base.gameObject, isOver);
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x00030ACB File Offset: 0x0002ECCB
	private void OnPress(bool isPressed)
	{
		if (this.isColliderEnabled && this.onPress != null)
		{
			this.onPress(base.gameObject, isPressed);
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00030AEF File Offset: 0x0002ECEF
	private void OnSelect(bool selected)
	{
		if (this.isColliderEnabled && this.onSelect != null)
		{
			this.onSelect(base.gameObject, selected);
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00030B13 File Offset: 0x0002ED13
	private void OnScroll(float delta)
	{
		if (this.isColliderEnabled && this.onScroll != null)
		{
			this.onScroll(base.gameObject, delta);
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00030B37 File Offset: 0x0002ED37
	private void OnDragStart()
	{
		if (this.onDragStart != null)
		{
			this.onDragStart(base.gameObject);
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00030B52 File Offset: 0x0002ED52
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag != null)
		{
			this.onDrag(base.gameObject, delta);
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x00030B6E File Offset: 0x0002ED6E
	private void OnDragOver()
	{
		if (this.isColliderEnabled && this.onDragOver != null)
		{
			this.onDragOver(base.gameObject);
		}
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x00030B91 File Offset: 0x0002ED91
	private void OnDragOut()
	{
		if (this.isColliderEnabled && this.onDragOut != null)
		{
			this.onDragOut(base.gameObject);
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00030BB4 File Offset: 0x0002EDB4
	private void OnDragEnd()
	{
		if (this.onDragEnd != null)
		{
			this.onDragEnd(base.gameObject);
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00030BCF File Offset: 0x0002EDCF
	private void OnDrop(GameObject go)
	{
		if (this.isColliderEnabled && this.onDrop != null)
		{
			this.onDrop(base.gameObject, go);
		}
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00030BF3 File Offset: 0x0002EDF3
	private void OnKey(KeyCode key)
	{
		if (this.isColliderEnabled && this.onKey != null)
		{
			this.onKey(base.gameObject, key);
		}
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00030C17 File Offset: 0x0002EE17
	private void OnTooltip(bool show)
	{
		if (this.isColliderEnabled && this.onTooltip != null)
		{
			this.onTooltip(base.gameObject, show);
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00030C3C File Offset: 0x0002EE3C
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

	// Token: 0x060004CB RID: 1227 RVA: 0x00030CB4 File Offset: 0x0002EEB4
	public static UIEventListener Get(GameObject go)
	{
		UIEventListener uieventListener = go.GetComponent<UIEventListener>();
		if (uieventListener == null)
		{
			uieventListener = go.AddComponent<UIEventListener>();
		}
		return uieventListener;
	}

	// Token: 0x04000545 RID: 1349
	public object parameter;

	// Token: 0x04000546 RID: 1350
	public UIEventListener.VoidDelegate onSubmit;

	// Token: 0x04000547 RID: 1351
	public UIEventListener.VoidDelegate onClick;

	// Token: 0x04000548 RID: 1352
	public UIEventListener.VoidDelegate onDoubleClick;

	// Token: 0x04000549 RID: 1353
	public UIEventListener.BoolDelegate onHover;

	// Token: 0x0400054A RID: 1354
	public UIEventListener.BoolDelegate onPress;

	// Token: 0x0400054B RID: 1355
	public UIEventListener.BoolDelegate onSelect;

	// Token: 0x0400054C RID: 1356
	public UIEventListener.FloatDelegate onScroll;

	// Token: 0x0400054D RID: 1357
	public UIEventListener.VoidDelegate onDragStart;

	// Token: 0x0400054E RID: 1358
	public UIEventListener.VectorDelegate onDrag;

	// Token: 0x0400054F RID: 1359
	public UIEventListener.VoidDelegate onDragOver;

	// Token: 0x04000550 RID: 1360
	public UIEventListener.VoidDelegate onDragOut;

	// Token: 0x04000551 RID: 1361
	public UIEventListener.VoidDelegate onDragEnd;

	// Token: 0x04000552 RID: 1362
	public UIEventListener.ObjectDelegate onDrop;

	// Token: 0x04000553 RID: 1363
	public UIEventListener.KeyCodeDelegate onKey;

	// Token: 0x04000554 RID: 1364
	public UIEventListener.BoolDelegate onTooltip;

	// Token: 0x04000555 RID: 1365
	public bool needsActiveCollider = true;

	// Token: 0x02000603 RID: 1539
	// (Invoke) Token: 0x0600259E RID: 9630
	public delegate void VoidDelegate(GameObject go);

	// Token: 0x02000604 RID: 1540
	// (Invoke) Token: 0x060025A2 RID: 9634
	public delegate void BoolDelegate(GameObject go, bool state);

	// Token: 0x02000605 RID: 1541
	// (Invoke) Token: 0x060025A6 RID: 9638
	public delegate void FloatDelegate(GameObject go, float delta);

	// Token: 0x02000606 RID: 1542
	// (Invoke) Token: 0x060025AA RID: 9642
	public delegate void VectorDelegate(GameObject go, Vector2 delta);

	// Token: 0x02000607 RID: 1543
	// (Invoke) Token: 0x060025AE RID: 9646
	public delegate void ObjectDelegate(GameObject go, GameObject obj);

	// Token: 0x02000608 RID: 1544
	// (Invoke) Token: 0x060025B2 RID: 9650
	public delegate void KeyCodeDelegate(GameObject go, KeyCode key);
}
