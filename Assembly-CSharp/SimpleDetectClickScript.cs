using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CAB RID: 7339 RVA: 0x00154014 File Offset: 0x00152214
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x04003370 RID: 13168
	public InventoryItemScript InventoryItem;

	// Token: 0x04003371 RID: 13169
	public Collider MyCollider;

	// Token: 0x04003372 RID: 13170
	public bool Clicked;
}
