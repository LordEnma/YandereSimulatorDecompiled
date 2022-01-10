using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600185C RID: 6236 RVA: 0x000EB710 File Offset: 0x000E9910
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002449 RID: 9289
	public int ArrayID;

	// Token: 0x0400244A RID: 9290
	public int ID;
}
