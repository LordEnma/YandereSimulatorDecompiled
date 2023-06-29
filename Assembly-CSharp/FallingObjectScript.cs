using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
	public Rigidbody MyRigidbody;

	private void Start()
	{
		MyRigidbody.useGravity = true;
	}

	private void Update()
	{
	}
}
