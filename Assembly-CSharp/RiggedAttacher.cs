using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x060020F7 RID: 8439 RVA: 0x001E1B2E File Offset: 0x001DFD2E
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E1B44 File Offset: 0x001DFD44
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

	// Token: 0x04004845 RID: 18501
	public Transform BasePelvisRoot;

	// Token: 0x04004846 RID: 18502
	public Transform AttachmentPelvisRoot;
}
