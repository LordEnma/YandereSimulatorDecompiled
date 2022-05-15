using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CDA RID: 7386 RVA: 0x00157668 File Offset: 0x00155868
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033F3 RID: 13299
	public InventoryItemScript InventoryItem;

	// Token: 0x040033F4 RID: 13300
	public Collider MyCollider;

	// Token: 0x040033F5 RID: 13301
	public bool Clicked;
}
