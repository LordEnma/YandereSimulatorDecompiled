using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001E41F2 File Offset: 0x001E23F2
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x001E4208 File Offset: 0x001E2408
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

	// Token: 0x040048A1 RID: 18593
	public Transform BasePelvisRoot;

	// Token: 0x040048A2 RID: 18594
	public Transform AttachmentPelvisRoot;
}
