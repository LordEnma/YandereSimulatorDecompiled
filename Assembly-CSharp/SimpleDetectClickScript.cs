using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00155D9C File Offset: 0x00153F9C
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033C4 RID: 13252
	public InventoryItemScript InventoryItem;

	// Token: 0x040033C5 RID: 13253
	public Collider MyCollider;

	// Token: 0x040033C6 RID: 13254
	public bool Clicked;
}
