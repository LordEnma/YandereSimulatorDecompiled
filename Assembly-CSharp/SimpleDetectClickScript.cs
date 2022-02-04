using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C97 RID: 7319 RVA: 0x00152B44 File Offset: 0x00150D44
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x04003341 RID: 13121
	public InventoryItemScript InventoryItem;

	// Token: 0x04003342 RID: 13122
	public Collider MyCollider;

	// Token: 0x04003343 RID: 13123
	public bool Clicked;
}
