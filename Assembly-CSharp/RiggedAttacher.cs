using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600211E RID: 8478 RVA: 0x001E5A7A File Offset: 0x001E3C7A
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x001E5A90 File Offset: 0x001E3C90
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

	// Token: 0x040048B9 RID: 18617
	public Transform BasePelvisRoot;

	// Token: 0x040048BA RID: 18618
	public Transform AttachmentPelvisRoot;
}
