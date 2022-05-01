using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
[AddComponentMenu("NGUI/Examples/Item Attachment Point")]
public class InvAttachmentPoint : MonoBehaviour
{
	// Token: 0x060000A0 RID: 160 RVA: 0x00011B18 File Offset: 0x0000FD18
	public GameObject Attach(GameObject prefab)
	{
		if (this.mPrefab != prefab)
		{
			this.mPrefab = prefab;
			if (this.mChild != null)
			{
				UnityEngine.Object.Destroy(this.mChild);
			}
			if (this.mPrefab != null)
			{
				Transform transform = base.transform;
				this.mChild = UnityEngine.Object.Instantiate<GameObject>(this.mPrefab, transform.position, transform.rotation);
				Transform transform2 = this.mChild.transform;
				transform2.parent = transform;
				transform2.localPosition = Vector3.zero;
				transform2.localRotation = Quaternion.identity;
				transform2.localScale = Vector3.one;
			}
		}
		return this.mChild;
	}

	// Token: 0x0400027C RID: 636
	public InvBaseItem.Slot slot;

	// Token: 0x0400027D RID: 637
	private GameObject mPrefab;

	// Token: 0x0400027E RID: 638
	private GameObject mChild;
}
