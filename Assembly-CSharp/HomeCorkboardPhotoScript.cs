using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x06001858 RID: 6232 RVA: 0x000EB3D8 File Offset: 0x000E95D8
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002445 RID: 9285
	public int ArrayID;

	// Token: 0x04002446 RID: 9286
	public int ID;
}
