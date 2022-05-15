using System;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x06002182 RID: 8578 RVA: 0x001EEA26 File Offset: 0x001ECC26
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002183 RID: 8579 RVA: 0x001EEA3C File Offset: 0x001ECC3C
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

	// Token: 0x040049D6 RID: 18902
	public Transform BasePelvisRoot;

	// Token: 0x040049D7 RID: 18903
	public Transform AttachmentPelvisRoot;
}
