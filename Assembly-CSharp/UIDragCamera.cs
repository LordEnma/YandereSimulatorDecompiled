using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Camera")]
public class UIDragCamera : MonoBehaviour
{
	// Token: 0x06000162 RID: 354 RVA: 0x00015330 File Offset: 0x00013530
	private void Awake()
	{
		if (this.draggableCamera == null)
		{
			this.draggableCamera = NGUITools.FindInParents<UIDraggableCamera>(base.gameObject);
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00015351 File Offset: 0x00013551
	private void OnPress(bool isPressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Press(isPressed);
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0001538F File Offset: 0x0001358F
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Drag(delta);
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x000153CD File Offset: 0x000135CD
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Scroll(delta);
		}
	}

	// Token: 0x04000319 RID: 793
	public UIDraggableCamera draggableCamera;
}
