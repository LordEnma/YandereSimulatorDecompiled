using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600185F RID: 6239 RVA: 0x000EBDBC File Offset: 0x000E9FBC
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002455 RID: 9301
	public int ArrayID;

	// Token: 0x04002456 RID: 9302
	public int ID;
}
