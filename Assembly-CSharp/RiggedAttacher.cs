using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002128 RID: 8488 RVA: 0x001E6132 File Offset: 0x001E4332
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x001E6148 File Offset: 0x001E4348
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

	// Token: 0x040048C5 RID: 18629
	public Transform BasePelvisRoot;

	// Token: 0x040048C6 RID: 18630
	public Transform AttachmentPelvisRoot;
}
