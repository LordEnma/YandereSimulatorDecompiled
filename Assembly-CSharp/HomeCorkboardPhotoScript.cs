using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001888 RID: 6280 RVA: 0x000EDE58 File Offset: 0x000EC058
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x040024B6 RID: 9398
	public int ArrayID;

	// Token: 0x040024B7 RID: 9399
	public int ID;
}
