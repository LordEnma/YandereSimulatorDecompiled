using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C8B RID: 7307 RVA: 0x001507E8 File Offset: 0x0014E9E8
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x04003328 RID: 13096
	public InventoryItemScript InventoryItem;

	// Token: 0x04003329 RID: 13097
	public Collider MyCollider;

	// Token: 0x0400332A RID: 13098
	public bool Clicked;
}
