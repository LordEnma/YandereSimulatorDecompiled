using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x0600217D RID: 8573 RVA: 0x001EEEE1 File Offset: 0x001ED0E1
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x0600217E RID: 8574 RVA: 0x001EEEEE File Offset: 0x001ED0EE
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600217F RID: 8575 RVA: 0x001EEF05 File Offset: 0x001ED105
	public IEnumerator Attach_Threat(Transform PelvisRoot, GameObject Attachment, bool Inactives)
	{
		Attachment.transform.SetParent(PelvisRoot);
		PelvisRoot.localEulerAngles = Vector3.zero;
		PelvisRoot.localPosition = Vector3.zero;
		Transform[] componentsInChildren = PelvisRoot.GetComponentsInChildren<Transform>(Inactives);
		foreach (Transform transform in Attachment.GetComponentsInChildren<Transform>(Inactives))
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
		yield return null;
		yield break;
	}

	// Token: 0x040049DC RID: 18908
	public Transform PelvisRoot;

	// Token: 0x040049DD RID: 18909
	public GameObject Attachment;
}
