using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HomeCorkboardPhotoScript : MonoBehaviour
{
	// Token: 0x0600184F RID: 6223 RVA: 0x000EA934 File Offset: 0x000E8B34
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			base.transform.localScale = new Vector3(Mathf.MoveTowards(base.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(base.transform.localScale.z, 1f, Time.deltaTime * 10f));
		}
	}

	// Token: 0x04002421 RID: 9249
	public int ArrayID;

	// Token: 0x04002422 RID: 9250
	public int ID;
}
