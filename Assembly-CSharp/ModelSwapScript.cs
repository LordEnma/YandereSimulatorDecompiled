using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002159 RID: 8537 RVA: 0x001EAE15 File Offset: 0x001E9015
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x001EAE22 File Offset: 0x001E9022
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x001EAE39 File Offset: 0x001E9039
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

	// Token: 0x04004980 RID: 18816
	public Transform PelvisRoot;

	// Token: 0x04004981 RID: 18817
	public GameObject Attachment;
}
