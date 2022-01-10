using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C94 RID: 7316 RVA: 0x00150EF8 File Offset: 0x0014F0F8
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x04003335 RID: 13109
	public InventoryItemScript InventoryItem;

	// Token: 0x04003336 RID: 13110
	public Collider MyCollider;

	// Token: 0x04003337 RID: 13111
	public bool Clicked;
}
