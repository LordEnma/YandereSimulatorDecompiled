using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E3262 File Offset: 0x001E1462
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E3278 File Offset: 0x001E1478
	private void Attaching(Transform Base, Transform Attachment)
	{
		Attachment.transform.SetParent(Base);
		Base.localEulerAngles = Vector3.zero;
		Base.localPosition = Vector3.zero;
		Transform[] componentsInChildren = Base.GetComponentsInChildren<Transform>();
		foreach (Transform transform in Attachment.GetComponentsInChildren<Transform>())
		{
			foreach (Transform transform2 in componentsInChildren)
			{
				if (transform.name == transform2.name)
				{
					transform.SetParent(transform2);
					transform.localEulerAngles = Vector3.zero;
					transform.localPosition = Vector3.zero;
				}
			}
		}
	}

	// Token: 0x04004884 RID: 18564
	public Transform BasePelvisRoot;

	// Token: 0x04004885 RID: 18565
	public Transform AttachmentPelvisRoot;
}
