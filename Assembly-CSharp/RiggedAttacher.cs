using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E3852 File Offset: 0x001E1A52
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E3868 File Offset: 0x001E1A68
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

	// Token: 0x0400488D RID: 18573
	public Transform BasePelvisRoot;

	// Token: 0x0400488E RID: 18574
	public Transform AttachmentPelvisRoot;
}
