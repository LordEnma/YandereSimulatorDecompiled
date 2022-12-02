using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed = 20f;

	public float rotationSpeed = 30f;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Translate(Vector3.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
		base.transform.Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
}
