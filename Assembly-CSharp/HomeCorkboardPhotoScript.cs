using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001866 RID: 6246 RVA: 0x000EBF30 File Offset: 0x000EA130
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x0400245B RID: 9307
	public int ArrayID;

	// Token: 0x0400245C RID: 9308
	public int ID;
}
