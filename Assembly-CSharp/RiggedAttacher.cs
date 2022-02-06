using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002121 RID: 8481 RVA: 0x001E5C7E File Offset: 0x001E3E7E
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x001E5C94 File Offset: 0x001E3E94
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

	// Token: 0x040048BC RID: 18620
	public Transform BasePelvisRoot;

	// Token: 0x040048BD RID: 18621
	public Transform AttachmentPelvisRoot;
}
