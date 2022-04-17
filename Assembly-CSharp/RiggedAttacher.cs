using System;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600216E RID: 8558 RVA: 0x001EBE4E File Offset: 0x001EA04E
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x001EBE64 File Offset: 0x001EA064
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

	// Token: 0x04004999 RID: 18841
	public Transform BasePelvisRoot;

	// Token: 0x0400499A RID: 18842
	public Transform AttachmentPelvisRoot;
}
