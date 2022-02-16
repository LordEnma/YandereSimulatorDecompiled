using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002122 RID: 8482 RVA: 0x001E6085 File Offset: 0x001E4285
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x001E6092 File Offset: 0x001E4292
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x001E60A9 File Offset: 0x001E42A9
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

	// Token: 0x040048C2 RID: 18626
	public Transform PelvisRoot;

	// Token: 0x040048C3 RID: 18627
	public GameObject Attachment;
}
