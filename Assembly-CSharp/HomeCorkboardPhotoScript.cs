using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001874 RID: 6260 RVA: 0x000ED004 File Offset: 0x000EB204
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x0400248F RID: 9359
	public int ArrayID;

	// Token: 0x04002490 RID: 9360
	public int ID;
}
