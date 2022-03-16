using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CB8 RID: 7352 RVA: 0x00154F20 File Offset: 0x00153120
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x040033A5 RID: 13221
	public InventoryItemScript InventoryItem;

	// Token: 0x040033A6 RID: 13222
	public Collider MyCollider;

	// Token: 0x040033A7 RID: 13223
	public bool Clicked;
}
