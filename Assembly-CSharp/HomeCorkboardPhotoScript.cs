using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600187A RID: 6266 RVA: 0x000ED5BC File Offset: 0x000EB7BC
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x040024A2 RID: 9378
	public int ArrayID;

	// Token: 0x040024A3 RID: 9379
	public int ID;
}
