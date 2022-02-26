using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600186F RID: 6255 RVA: 0x000EC814 File Offset: 0x000EAA14
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x0400246A RID: 9322
	public int ArrayID;

	// Token: 0x0400246B RID: 9323
	public int ID;
}
