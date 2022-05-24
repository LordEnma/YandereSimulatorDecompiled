using System;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002183 RID: 8579 RVA: 0x001EEF8E File Offset: 0x001ED18E
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002184 RID: 8580 RVA: 0x001EEFA4 File Offset: 0x001ED1A4
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

	// Token: 0x040049DF RID: 18911
	public Transform BasePelvisRoot;

	// Token: 0x040049E0 RID: 18912
	public Transform AttachmentPelvisRoot;
}
