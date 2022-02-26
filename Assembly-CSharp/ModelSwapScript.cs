using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x0600212B RID: 8491 RVA: 0x001E6C65 File Offset: 0x001E4E65
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x001E6C72 File Offset: 0x001E4E72
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001E6C89 File Offset: 0x001E4E89
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

	// Token: 0x040048D2 RID: 18642
	public Transform PelvisRoot;

	// Token: 0x040048D3 RID: 18643
	public GameObject Attachment;
}
