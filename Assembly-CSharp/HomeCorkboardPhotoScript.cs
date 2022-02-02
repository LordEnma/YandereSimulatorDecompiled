using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600185D RID: 6237 RVA: 0x000EBC18 File Offset: 0x000E9E18
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002451 RID: 9297
	public int ArrayID;

	// Token: 0x04002452 RID: 9298
	public int ID;
}
