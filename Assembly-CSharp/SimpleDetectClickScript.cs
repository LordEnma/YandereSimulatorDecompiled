using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CDB RID: 7387 RVA: 0x00157924 File Offset: 0x00155B24
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033FB RID: 13307
	public InventoryItemScript InventoryItem;

	// Token: 0x040033FC RID: 13308
	public Collider MyCollider;

	// Token: 0x040033FD RID: 13309
	public bool Clicked;
}
