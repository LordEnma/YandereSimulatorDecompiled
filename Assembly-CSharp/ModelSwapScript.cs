using System.Collections;
using UnityEngine;

public class ModelSwapScript : MonoBehaviour
{
	public Transform PelvisRoot;

	public GameObject Attachment;

	public void Update()
	{
		Input.GetKeyDown("z");
	}

	public void Attach(GameObject Attachment, bool Inactives)
	{
		StartCoroutine(Attach_Threat(PelvisRoot, Attachment, Inactives));
	}

	public IEnumerator Attach_Threat(Transform PelvisRoot, GameObject Attachment, bool Inactives)
	{
		Attachment.transform.SetParent(PelvisRoot);
		PelvisRoot.localEulerAngles = Vector3.zero;
		PelvisRoot.localPosition = Vector3.zero;
		Transform[] componentsInChildren = PelvisRoot.GetComponentsInChildren<Transform>(Inactives);
		Transform[] componentsInChildren2 = Attachment.GetComponentsInChildren<Transform>(Inactives);
		foreach (Transform transform in componentsInChildren2)
		{
			Transform[] array = componentsInChildren;
			foreach (Transform transform2 in array)
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
	}
}
