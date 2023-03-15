using UnityEngine;

public class IntroCorpseScript : MonoBehaviour
{
	public Animation MyAnim;

	private void Start()
	{
		RemoveCharacterJoints(base.transform);
		RemoveRigidbodies(base.transform);
		MyAnim = base.transform.GetChild(0).GetComponent<Animation>();
		MyAnim["f02_knifeHighSanityB_00"].time = MyAnim["f02_knifeHighSanityB_00"].length;
	}

	private void Update()
	{
	}

	private void RemoveCharacterJoints(Transform transform)
	{
		foreach (Transform item in transform)
		{
			CharacterJoint component = transform.gameObject.GetComponent<CharacterJoint>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			RemoveCharacterJoints(item);
		}
	}

	private void RemoveRigidbodies(Transform transform)
	{
		foreach (Transform item in transform)
		{
			Rigidbody component = transform.gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			RemoveRigidbodies(item);
		}
	}
}
