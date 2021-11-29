using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x060020F1 RID: 8433 RVA: 0x001E1A81 File Offset: 0x001DFC81
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E1A8E File Offset: 0x001DFC8E
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E1AA5 File Offset: 0x001DFCA5
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

	// Token: 0x04004842 RID: 18498
	public Transform PelvisRoot;

	// Token: 0x04004843 RID: 18499
	public GameObject Attachment;
}
