using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class ModelSwapScript : MonoBehaviour
{
	// Token: 0x06002105 RID: 8453 RVA: 0x001E37A5 File Offset: 0x001E19A5
	public void Update()
	{
		Input.GetKeyDown("z");
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E37B2 File Offset: 0x001E19B2
	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x001E37C9 File Offset: 0x001E19C9
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

	// Token: 0x0400488A RID: 18570
	public Transform PelvisRoot;

	// Token: 0x0400488B RID: 18571
	public GameObject Attachment;
}
