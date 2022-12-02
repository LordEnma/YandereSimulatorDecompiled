using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		[SerializeField]
		private float m_Lift = 0.002f;

		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		[SerializeField]
		private float m_RollEffect = 1f;

		[SerializeField]
		private float m_PitchEffect = 1f;

		[SerializeField]
		private float m_YawEffect = 0.2f;

		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		private float m_OriginalDrag;

		private float m_OriginalAngularDrag;

		private float m_AeroFactor;

		private bool m_Immobilized;

		private float m_BankedTurnAmount;

		private Rigidbody m_Rigidbody;

		private WheelCollider[] m_WheelColliders;

		public float Altitude { get; private set; }

		public float Throttle { get; private set; }

		public bool AirBrakes { get; private set; }

		public float ForwardSpeed { get; private set; }

		public float EnginePower { get; private set; }

		public float MaxEnginePower
		{
			get
			{
				return m_MaxEnginePower;
			}
		}

		public float RollAngle { get; private set; }

		public float PitchAngle { get; private set; }

		public float RollInput { get; private set; }

		public float PitchInput { get; private set; }

		public float YawInput { get; private set; }

		public float ThrottleInput { get; private set; }

		private void Start()
		{
			m_Rigidbody = GetComponent<Rigidbody>();
			m_OriginalDrag = m_Rigidbody.drag;
			m_OriginalAngularDrag = m_Rigidbody.angularDrag;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				WheelCollider[] componentsInChildren = base.transform.GetChild(i).GetComponentsInChildren<WheelCollider>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].motorTorque = 0.18f;
				}
			}
		}

		public void Move(float rollInput, float pitchInput, float yawInput, float throttleInput, bool airBrakes)
		{
			RollInput = rollInput;
			PitchInput = pitchInput;
			YawInput = yawInput;
			ThrottleInput = throttleInput;
			AirBrakes = airBrakes;
			ClampInputs();
			CalculateRollAndPitchAngles();
			AutoLevel();
			CalculateForwardSpeed();
			ControlThrottle();
			CalculateDrag();
			CaluclateAerodynamicEffect();
			CalculateLinearForces();
			CalculateTorque();
			CalculateAltitude();
		}

		private void ClampInputs()
		{
			RollInput = Mathf.Clamp(RollInput, -1f, 1f);
			PitchInput = Mathf.Clamp(PitchInput, -1f, 1f);
			YawInput = Mathf.Clamp(YawInput, -1f, 1f);
			ThrottleInput = Mathf.Clamp(ThrottleInput, -1f, 1f);
		}

		private void CalculateRollAndPitchAngles()
		{
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			if (forward.sqrMagnitude > 0f)
			{
				forward.Normalize();
				Vector3 vector = base.transform.InverseTransformDirection(forward);
				PitchAngle = Mathf.Atan2(vector.y, vector.z);
				Vector3 direction = Vector3.Cross(Vector3.up, forward);
				Vector3 vector2 = base.transform.InverseTransformDirection(direction);
				RollAngle = Mathf.Atan2(vector2.y, vector2.x);
			}
		}

		private void AutoLevel()
		{
			m_BankedTurnAmount = Mathf.Sin(RollAngle);
			if (RollInput == 0f)
			{
				RollInput = (0f - RollAngle) * m_AutoRollLevel;
			}
			if (PitchInput == 0f)
			{
				PitchInput = (0f - PitchAngle) * m_AutoPitchLevel;
				PitchInput -= Mathf.Abs(m_BankedTurnAmount * m_BankedTurnAmount * m_AutoTurnPitch);
			}
		}

		private void CalculateForwardSpeed()
		{
			ForwardSpeed = Mathf.Max(0f, base.transform.InverseTransformDirection(m_Rigidbody.velocity).z);
		}

		private void ControlThrottle()
		{
			if (m_Immobilized)
			{
				ThrottleInput = -0.5f;
			}
			Throttle = Mathf.Clamp01(Throttle + ThrottleInput * Time.deltaTime * m_ThrottleChangeSpeed);
			EnginePower = Throttle * m_MaxEnginePower;
		}

		private void CalculateDrag()
		{
			float num = m_Rigidbody.velocity.magnitude * m_DragIncreaseFactor;
			m_Rigidbody.drag = (AirBrakes ? ((m_OriginalDrag + num) * m_AirBrakesEffect) : (m_OriginalDrag + num));
			m_Rigidbody.angularDrag = m_OriginalAngularDrag * ForwardSpeed;
		}

		private void CaluclateAerodynamicEffect()
		{
			if (m_Rigidbody.velocity.magnitude > 0f)
			{
				m_AeroFactor = Vector3.Dot(base.transform.forward, m_Rigidbody.velocity.normalized);
				m_AeroFactor *= m_AeroFactor;
				Vector3 velocity = Vector3.Lerp(m_Rigidbody.velocity, base.transform.forward * ForwardSpeed, m_AeroFactor * ForwardSpeed * m_AerodynamicEffect * Time.deltaTime);
				m_Rigidbody.velocity = velocity;
				m_Rigidbody.rotation = Quaternion.Slerp(m_Rigidbody.rotation, Quaternion.LookRotation(m_Rigidbody.velocity, base.transform.up), m_AerodynamicEffect * Time.deltaTime);
			}
		}

		private void CalculateLinearForces()
		{
			Vector3 zero = Vector3.zero;
			zero += EnginePower * base.transform.forward;
			Vector3 normalized = Vector3.Cross(m_Rigidbody.velocity, base.transform.right).normalized;
			float num = Mathf.InverseLerp(m_ZeroLiftSpeed, 0f, ForwardSpeed);
			float num2 = ForwardSpeed * ForwardSpeed * m_Lift * num * m_AeroFactor;
			zero += num2 * normalized;
			m_Rigidbody.AddForce(zero);
		}

		private void CalculateTorque()
		{
			Vector3 zero = Vector3.zero;
			zero += PitchInput * m_PitchEffect * base.transform.right;
			zero += YawInput * m_YawEffect * base.transform.up;
			zero += (0f - RollInput) * m_RollEffect * base.transform.forward;
			zero += m_BankedTurnAmount * m_BankedTurnEffect * base.transform.up;
			m_Rigidbody.AddTorque(zero * ForwardSpeed * m_AeroFactor);
		}

		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit hitInfo;
			Altitude = (Physics.Raycast(ray, out hitInfo) ? (hitInfo.distance + 10f) : base.transform.position.y);
		}

		public void Immobilize()
		{
			m_Immobilized = true;
		}

		public void Reset()
		{
			m_Immobilized = false;
		}
	}
}
