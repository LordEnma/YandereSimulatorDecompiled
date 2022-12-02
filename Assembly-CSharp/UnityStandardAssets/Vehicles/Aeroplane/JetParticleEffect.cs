using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		public Color minColour;

		private AeroplaneController m_Jet;

		private ParticleSystem m_System;

		private float m_OriginalStartSize;

		private float m_OriginalLifetime;

		private Color m_OriginalStartColor;

		private void Start()
		{
			m_Jet = FindAeroplaneParent();
			m_System = GetComponent<ParticleSystem>();
			m_OriginalLifetime = m_System.main.startLifetime.constant;
			m_OriginalStartSize = m_System.main.startSize.constant;
			m_OriginalStartColor = m_System.main.startColor.color;
		}

		private void Update()
		{
			ParticleSystem.MainModule main = m_System.main;
			main.startLifetime = Mathf.Lerp(0f, m_OriginalLifetime, m_Jet.Throttle);
			main.startSize = Mathf.Lerp(m_OriginalStartSize * 0.3f, m_OriginalStartSize, m_Jet.Throttle);
			main.startColor = Color.Lerp(minColour, m_OriginalStartColor, m_Jet.Throttle);
		}

		private AeroplaneController FindAeroplaneParent()
		{
			Transform parent = base.transform;
			while (parent != null)
			{
				AeroplaneController component = parent.GetComponent<AeroplaneController>();
				if (component == null)
				{
					parent = parent.parent;
					continue;
				}
				return component;
			}
			throw new Exception(" AeroplaneContoller not found in object hierarchy");
		}
	}
}
