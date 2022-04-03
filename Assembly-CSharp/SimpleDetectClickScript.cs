using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CC2 RID: 7362 RVA: 0x00155A7C File Offset: 0x00153C7C
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033C1 RID: 13249
	public InventoryItemScript InventoryItem;

	// Token: 0x040033C2 RID: 13250
	public Collider MyCollider;

	// Token: 0x040033C3 RID: 13251
	public bool Clicked;
}
