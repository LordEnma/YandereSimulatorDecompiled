using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CCD RID: 7373 RVA: 0x001561AC File Offset: 0x001543AC
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033CF RID: 13263
	public InventoryItemScript InventoryItem;

	// Token: 0x040033D0 RID: 13264
	public Collider MyCollider;

	// Token: 0x040033D1 RID: 13265
	public bool Clicked;
}
