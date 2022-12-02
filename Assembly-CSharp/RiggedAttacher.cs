using UnityEngine;

public class RiggedAttacher : MonoBehaviour
{
	public Transform BasePelvisRoot;

	public Transform AttachmentPelvisRoot;

	private void Start()
	{
		Attaching(BasePelvisRoot, AttachmentPelvisRoot);
	}

	private void Attaching(Transform Base, Transform Attachment)
	{
		Attachment.transform.SetParent(Base);
		Base.localEulerAngles = Vector3.zero;
		Base.localPosition = Vector3.zero;
		Transform[] componentsInChildren = Base.GetComponentsInChildren<Transform>();
		Transform[] componentsInChildren2 = Attachment.GetComponentsInChildren<Transform>();
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
	}
}
