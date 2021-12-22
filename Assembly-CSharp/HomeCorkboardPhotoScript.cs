using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001856 RID: 6230 RVA: 0x000EB0F4 File Offset: 0x000E92F4
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002441 RID: 9281
	public int ArrayID;

	// Token: 0x04002442 RID: 9282
	public int ID;
}
