using System;
using UnityEngine;

// Token: 0x02000426 RID: 1062
public class SimpleDetectClickScript : MonoBehaviour
{
	// Token: 0x06001CA0 RID: 7328 RVA: 0x00152FE4 File Offset: 0x001511E4
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}

	// Token: 0x0400334A RID: 13130
	public InventoryItemScript InventoryItem;

	// Token: 0x0400334B RID: 13131
	public Collider MyCollider;

	// Token: 0x0400334C RID: 13132
	public bool Clicked;
}
