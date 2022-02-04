using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002118 RID: 8472 RVA: 0x001E59CD File Offset: 0x001E3BCD
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x001E59DA File Offset: 0x001E3BDA
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x001E59F1 File Offset: 0x001E3BF1
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

	// Token: 0x040048B6 RID: 18614
	public Transform PelvisRoot;

	// Token: 0x040048B7 RID: 18615
	public GameObject Attachment;
}
