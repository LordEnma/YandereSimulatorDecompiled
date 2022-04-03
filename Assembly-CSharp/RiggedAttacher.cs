using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600215F RID: 8543 RVA: 0x001EAEC2 File Offset: 0x001E90C2
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x001EAED8 File Offset: 0x001E90D8
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

	// Token: 0x04004983 RID: 18819
	public Transform BasePelvisRoot;

	// Token: 0x04004984 RID: 18820
	public Transform AttachmentPelvisRoot;
}
