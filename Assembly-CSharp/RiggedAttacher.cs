using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600211C RID: 8476 RVA: 0x001E5762 File Offset: 0x001E3962
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E5778 File Offset: 0x001E3978
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

	// Token: 0x040048B3 RID: 18611
	public Transform BasePelvisRoot;

	// Token: 0x040048B4 RID: 18612
	public Transform AttachmentPelvisRoot;
}
