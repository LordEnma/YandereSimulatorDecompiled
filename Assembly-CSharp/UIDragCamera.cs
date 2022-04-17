using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Camera")]
public class UIDragCamera : MonoBehaviour
{
	// Token: 0x06000162 RID: 354 RVA: 0x000154D8 File Offset: 0x000136D8
	private void Awake()
	{
		if (this.draggableCamera == null)
		{
			this.draggableCamera = NGUITools.FindInParents<UIDraggableCamera>(base.gameObject);
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x000154F9 File Offset: 0x000136F9
	private void OnPress(bool isPressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Press(isPressed);
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00015537 File Offset: 0x00013737
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Drag(delta);
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00015575 File Offset: 0x00013775
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Scroll(delta);
		}
	}

	// Token: 0x04000324 RID: 804
	public UIDraggableCamera draggableCamera;
}
