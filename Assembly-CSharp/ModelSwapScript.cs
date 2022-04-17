using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002168 RID: 8552 RVA: 0x001EBDA1 File Offset: 0x001E9FA1
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x001EBDAE File Offset: 0x001E9FAE
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600216A RID: 8554 RVA: 0x001EBDC5 File Offset: 0x001E9FC5
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

	// Token: 0x04004996 RID: 18838
	public Transform PelvisRoot;

	// Token: 0x04004997 RID: 18839
	public GameObject Attachment;
}
