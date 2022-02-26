using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CA9 RID: 7337 RVA: 0x00153A90 File Offset: 0x00151C90
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x0400335A RID: 13146
	public InventoryItemScript InventoryItem;

	// Token: 0x0400335B RID: 13147
	public Collider MyCollider;

	// Token: 0x0400335C RID: 13148
	public bool Clicked;
}
