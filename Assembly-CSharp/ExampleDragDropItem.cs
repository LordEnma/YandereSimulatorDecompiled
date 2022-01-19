using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class ExampleDragDropItem : UIDragDropItem
{
	// Token: 0x060000C9 RID: 201 RVA: 0x000123A0 File Offset: 0x000105A0
	protected override void OnDragDropRelease(GameObject surface)
	{
		if (surface != null)
		{
			ExampleDragDropSurface component = surface.GetComponent<ExampleDragDropSurface>();
			if (component != null)
			{
				GameObject gameObject = component.gameObject.AddChild(this.prefab);
				gameObject.transform.localScale = component.transform.localScale;
				Transform transform = gameObject.transform;
				transform.position = UICamera.lastWorldPosition;
				if (component.rotatePlacedObject)
				{
					transform.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
				}
				NGUITools.Destroy(base.gameObject);
				return;
			}
		}
		base.OnDragDropRelease(surface);
	}

	// Token: 0x04000292 RID: 658
	public GameObject prefab;
}
