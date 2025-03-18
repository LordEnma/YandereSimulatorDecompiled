using System.Collections;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Effects
{
	public class Explosive : MonoBehaviour
	{
		public Transform explosionPrefab;

		public float detonationImpactVelocity = 10f;

		public float sizeMultiplier = 1f;

		public bool reset = true;

		public float resetTimeDelay = 10f;

		private bool m_Exploded;

		private ObjectResetter m_ObjectResetter;

		private void Start()
		{
			m_ObjectResetter = GetComponent<ObjectResetter>();
		}

		private IEnumerator OnCollisionEnter(Collision col)
		{
			if (base.enabled && col.contacts.Length != 0 && (Vector3.Project(col.relativeVelocity, col.contacts[0].normal).magnitude > detonationImpactVelocity || m_Exploded) && !m_Exploded)
			{
				Object.Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.LookRotation(col.contacts[0].normal));
				m_Exploded = true;
				SendMessage("Immobilize");
				if (reset)
				{
					m_ObjectResetter.DelayedReset(resetTimeDelay);
				}
			}
			yield return null;
		}

		public void Reset()
		{
			m_Exploded = false;
		}
	}
}
