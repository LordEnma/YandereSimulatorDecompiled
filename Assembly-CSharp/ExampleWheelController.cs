using UnityEngine;

public class ExampleWheelController : MonoBehaviour
{
	private static class Uniforms
	{
		internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
	}

	public float acceleration;

	public Renderer motionVectorRenderer;

	private Rigidbody m_Rigidbody;

	private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Rigidbody.maxAngularVelocity = 100f;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			m_Rigidbody.AddRelativeTorque(new Vector3(-1f * acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			m_Rigidbody.AddRelativeTorque(new Vector3(1f * acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		float value = (0f - m_Rigidbody.angularVelocity.x) / 100f;
		if ((bool)motionVectorRenderer)
		{
			motionVectorRenderer.material.SetFloat(Uniforms._MotionAmount, Mathf.Clamp(value, -0.25f, 0.25f));
		}
	}
}
