using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002118 RID: 8472 RVA: 0x001E4EC2 File Offset: 0x001E30C2
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x001E4ED8 File Offset: 0x001E30D8
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

	// Token: 0x040048A8 RID: 18600
	public Transform BasePelvisRoot;

	// Token: 0x040048A9 RID: 18601
	public Transform AttachmentPelvisRoot;
}
