using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002149 RID: 8521 RVA: 0x001E95A5 File Offset: 0x001E77A5
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x001E95B2 File Offset: 0x001E77B2
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x001E95C9 File Offset: 0x001E77C9
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

	// Token: 0x0400494E RID: 18766
	public Transform PelvisRoot;

	// Token: 0x0400494F RID: 18767
	public GameObject Attachment;
}
