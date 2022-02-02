using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001E56B5 File Offset: 0x001E38B5
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x001E56C2 File Offset: 0x001E38C2
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001E56D9 File Offset: 0x001E38D9
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

	// Token: 0x040048B0 RID: 18608
	public Transform PelvisRoot;

	// Token: 0x040048B1 RID: 18609
	public GameObject Attachment;
}
