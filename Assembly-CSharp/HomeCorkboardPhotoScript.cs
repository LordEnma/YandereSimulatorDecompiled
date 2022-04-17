using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001884 RID: 6276 RVA: 0x000ED95C File Offset: 0x000EBB5C
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x040024AD RID: 9389
	public int ArrayID;

	// Token: 0x040024AE RID: 9390
	public int ID;
}
