using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002178 RID: 8568 RVA: 0x001ED3D6 File Offset: 0x001EB5D6
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002179 RID: 8569 RVA: 0x001ED3EC File Offset: 0x001EB5EC
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

	// Token: 0x040049AF RID: 18863
	public Transform BasePelvisRoot;

	// Token: 0x040049B0 RID: 18864
	public Transform AttachmentPelvisRoot;
}
