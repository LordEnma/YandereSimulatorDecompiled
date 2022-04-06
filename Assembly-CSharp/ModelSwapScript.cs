using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002161 RID: 8545 RVA: 0x001EB345 File Offset: 0x001E9545
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x001EB352 File Offset: 0x001E9552
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x001EB369 File Offset: 0x001E9569
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

	// Token: 0x04004984 RID: 18820
	public Transform PelvisRoot;

	// Token: 0x04004985 RID: 18821
	public GameObject Attachment;
}
