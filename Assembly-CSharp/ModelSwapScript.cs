using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002102 RID: 8450 RVA: 0x001E31B5 File Offset: 0x001E13B5
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x001E31C2 File Offset: 0x001E13C2
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x001E31D9 File Offset: 0x001E13D9
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

	// Token: 0x04004881 RID: 18561
	public Transform PelvisRoot;

	// Token: 0x04004882 RID: 18562
	public GameObject Attachment;
}
