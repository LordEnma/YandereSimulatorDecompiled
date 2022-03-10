using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600186F RID: 6255 RVA: 0x000ECB44 File Offset: 0x000EAD44
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x0400247E RID: 9342
	public int ArrayID;

	// Token: 0x0400247F RID: 9343
	public int ID;
}
