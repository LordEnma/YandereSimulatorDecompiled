using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001880 RID: 6272 RVA: 0x000ED6BC File Offset: 0x000EB8BC
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x040024A5 RID: 9381
	public int ArrayID;

	// Token: 0x040024A6 RID: 9382
	public int ID;
}
