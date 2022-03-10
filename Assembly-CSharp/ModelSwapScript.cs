using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002131 RID: 8497 RVA: 0x001E763D File Offset: 0x001E583D
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001E764A File Offset: 0x001E584A
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x001E7661 File Offset: 0x001E5861
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

	// Token: 0x040048EF RID: 18671
	public Transform PelvisRoot;

	// Token: 0x040048F0 RID: 18672
	public GameObject Attachment;
}
