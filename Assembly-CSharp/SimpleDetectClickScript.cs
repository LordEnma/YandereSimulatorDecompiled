using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C99 RID: 7321 RVA: 0x00152CDC File Offset: 0x00150EDC
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x04003344 RID: 13124
	public InventoryItemScript InventoryItem;

	// Token: 0x04003345 RID: 13125
	public Collider MyCollider;

	// Token: 0x04003346 RID: 13126
	public bool Clicked;
}
