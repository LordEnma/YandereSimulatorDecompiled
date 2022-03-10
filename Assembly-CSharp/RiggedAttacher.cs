using System;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002137 RID: 8503 RVA: 0x001E76EA File Offset: 0x001E58EA
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002138 RID: 8504 RVA: 0x001E7700 File Offset: 0x001E5900
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

	// Token: 0x040048F2 RID: 18674
	public Transform BasePelvisRoot;

	// Token: 0x040048F3 RID: 18675
	public Transform AttachmentPelvisRoot;
}
