using System;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002167 RID: 8551 RVA: 0x001EB3F2 File Offset: 0x001E95F2
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x001EB408 File Offset: 0x001E9608
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

	// Token: 0x04004987 RID: 18823
	public Transform BasePelvisRoot;

	// Token: 0x04004988 RID: 18824
	public Transform AttachmentPelvisRoot;
}
