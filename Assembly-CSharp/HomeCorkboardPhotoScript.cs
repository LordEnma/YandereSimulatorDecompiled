using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600188D RID: 6285 RVA: 0x000EE124 File Offset: 0x000EC324
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x040024C1 RID: 9409
	public int ArrayID;

	// Token: 0x040024C2 RID: 9410
	public int ID;
}
