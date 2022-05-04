using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002172 RID: 8562 RVA: 0x001ED329 File Offset: 0x001EB529
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002173 RID: 8563 RVA: 0x001ED336 File Offset: 0x001EB536
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002174 RID: 8564 RVA: 0x001ED34D File Offset: 0x001EB54D
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

	// Token: 0x040049AC RID: 18860
	public Transform PelvisRoot;

	// Token: 0x040049AD RID: 18861
	public GameObject Attachment;
}
