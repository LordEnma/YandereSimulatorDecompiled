using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C8D RID: 7309 RVA: 0x00150BF4 File Offset: 0x0014EDF4
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x0400332F RID: 13103
	public InventoryItemScript InventoryItem;

	// Token: 0x04003330 RID: 13104
	public Collider MyCollider;

	// Token: 0x04003331 RID: 13105
	public bool Clicked;
}
