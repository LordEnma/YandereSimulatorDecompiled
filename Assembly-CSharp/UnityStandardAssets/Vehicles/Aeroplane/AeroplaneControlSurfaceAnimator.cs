using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		[Serializable]
		public class ControlSurface
		{
			public enum Type
			{
				Aileron = 0,
				Elevator = 1,
				Rudder = 2,
				RuddervatorNegative = 3,
				RuddervatorPositive = 4
			}

			public Transform transform;

			public float amount;

			public Type type;

			[HideInInspector]
			public Quaternion originalLocalRotation;
		}

		[SerializeField]
		private float m_Smoothing = 5f;

		[SerializeField]
		private ControlSurface[] m_ControlSurfaces;

		private AeroplaneController m_Plane;

		private void Start()
		{
			m_Plane = GetComponent<AeroplaneController>();
			ControlSurface[] controlSurfaces = m_ControlSurfaces;
			foreach (ControlSurface obj in controlSurfaces)
			{
				obj.originalLocalRotation = obj.transform.localRotation;
			}
		}

		private void Update()
		{
			ControlSurface[] controlSurfaces = m_ControlSurfaces;
			foreach (ControlSurface controlSurface in controlSurfaces)
			{
				switch (controlSurface.type)
				{
				case ControlSurface.Type.Aileron:
				{
					Quaternion rotation5 = Quaternion.Euler(controlSurface.amount * m_Plane.RollInput, 0f, 0f);
					RotateSurface(controlSurface, rotation5);
					break;
				}
				case ControlSurface.Type.Elevator:
				{
					Quaternion rotation4 = Quaternion.Euler(controlSurface.amount * (0f - m_Plane.PitchInput), 0f, 0f);
					RotateSurface(controlSurface, rotation4);
					break;
				}
				case ControlSurface.Type.Rudder:
				{
					Quaternion rotation3 = Quaternion.Euler(0f, controlSurface.amount * m_Plane.YawInput, 0f);
					RotateSurface(controlSurface, rotation3);
					break;
				}
				case ControlSurface.Type.RuddervatorPositive:
				{
					float num2 = m_Plane.YawInput + m_Plane.PitchInput;
					Quaternion rotation2 = Quaternion.Euler(0f, 0f, controlSurface.amount * num2);
					RotateSurface(controlSurface, rotation2);
					break;
				}
				case ControlSurface.Type.RuddervatorNegative:
				{
					float num = m_Plane.YawInput - m_Plane.PitchInput;
					Quaternion rotation = Quaternion.Euler(0f, 0f, controlSurface.amount * num);
					RotateSurface(controlSurface, rotation);
					break;
				}
				}
			}
		}

		private void RotateSurface(ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, m_Smoothing * Time.deltaTime);
		}
	}
}
