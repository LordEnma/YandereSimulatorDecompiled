using UnityEngine;

public class NurseScript : MonoBehaviour
{
	public GameObject Character;

	public Transform SkirtCenter;

	private void Awake()
	{
		Animation component = Character.GetComponent<Animation>();
		component["f02_noBlink_00"].layer = 1;
		component.Blend("f02_noBlink_00");
	}

	private void LateUpdate()
	{
		SkirtCenter.localEulerAngles = new Vector3(-15f, SkirtCenter.localEulerAngles.y, SkirtCenter.localEulerAngles.z);
	}
}
