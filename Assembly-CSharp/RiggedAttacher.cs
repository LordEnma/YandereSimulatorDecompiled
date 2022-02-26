using System;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002131 RID: 8497 RVA: 0x001E6D12 File Offset: 0x001E4F12
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001E6D28 File Offset: 0x001E4F28
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

	// Token: 0x040048D5 RID: 18645
	public Transform BasePelvisRoot;

	// Token: 0x040048D6 RID: 18646
	public Transform AttachmentPelvisRoot;
}
