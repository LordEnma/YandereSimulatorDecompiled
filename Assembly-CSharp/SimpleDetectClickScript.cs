using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001C96 RID: 7318 RVA: 0x0015260C File Offset: 0x0015080C
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x0400333A RID: 13114
	public InventoryItemScript InventoryItem;

	// Token: 0x0400333B RID: 13115
	public Collider MyCollider;

	// Token: 0x0400333C RID: 13116
	public bool Clicked;
}
