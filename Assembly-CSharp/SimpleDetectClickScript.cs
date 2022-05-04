using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CD4 RID: 7380 RVA: 0x001569B4 File Offset: 0x00154BB4
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033DE RID: 13278
	public InventoryItemScript InventoryItem;

	// Token: 0x040033DF RID: 13279
	public Collider MyCollider;

	// Token: 0x040033E0 RID: 13280
	public bool Clicked;
}
