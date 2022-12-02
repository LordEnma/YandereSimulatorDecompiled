using UnityEngine;

public class CreditsLabelScript : MonoBehaviour
{
	public float RotationSpeed;

	public float MovementSpeed;

	public float Rotation;

	private void Start()
	{
		Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Rotation, base.transform.localEulerAngles.z);
	}

	private void Update()
	{
		Rotation += Time.deltaTime * RotationSpeed;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Rotation, base.transform.localEulerAngles.z);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + Time.deltaTime * MovementSpeed, base.transform.localPosition.z);
		if (Rotation > 90f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
