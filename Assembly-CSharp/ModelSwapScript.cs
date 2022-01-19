using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002112 RID: 8466 RVA: 0x001E4E15 File Offset: 0x001E3015
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x001E4E22 File Offset: 0x001E3022
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E4E39 File Offset: 0x001E3039
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

	// Token: 0x040048A5 RID: 18597
	public Transform PelvisRoot;

	// Token: 0x040048A6 RID: 18598
	public GameObject Attachment;
}
