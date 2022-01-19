using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600185C RID: 6236 RVA: 0x000EB7FC File Offset: 0x000E99FC
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x0400244C RID: 9292
	public int ArrayID;

	// Token: 0x0400244D RID: 9293
	public int ID;
}
