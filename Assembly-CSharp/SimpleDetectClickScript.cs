using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x0014FEC4 File Offset: 0x0014E0C4
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040032FD RID: 13053
	public InventoryItemScript InventoryItem;

	// Token: 0x040032FE RID: 13054
	public Collider MyCollider;

	// Token: 0x040032FF RID: 13055
	public bool Clicked;
}
