using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002110 RID: 8464 RVA: 0x001E4145 File Offset: 0x001E2345
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x001E4152 File Offset: 0x001E2352
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002112 RID: 8466 RVA: 0x001E4169 File Offset: 0x001E2369
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

	// Token: 0x0400489E RID: 18590
	public Transform PelvisRoot;

	// Token: 0x0400489F RID: 18591
	public GameObject Attachment;
}
