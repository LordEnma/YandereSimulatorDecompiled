using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class RiggedAttacher : MonoBehaviour
{
	// Token: 0x0600214F RID: 8527 RVA: 0x001E9652 File Offset: 0x001E7852
	private void Start()
	{
		this.Attaching(this.BasePelvisRoot, this.AttachmentPelvisRoot);
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x001E9668 File Offset: 0x001E7868
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

	// Token: 0x04004951 RID: 18769
	public Transform BasePelvisRoot;

	// Token: 0x04004952 RID: 18770
	public Transform AttachmentPelvisRoot;
}
