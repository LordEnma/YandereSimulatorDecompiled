using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x0600211B RID: 8475 RVA: 0x001E5BD1 File Offset: 0x001E3DD1
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x001E5BDE File Offset: 0x001E3DDE
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E5BF5 File Offset: 0x001E3DF5
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

	// Token: 0x040048B9 RID: 18617
	public Transform PelvisRoot;

	// Token: 0x040048BA RID: 18618
	public GameObject Attachment;
}
