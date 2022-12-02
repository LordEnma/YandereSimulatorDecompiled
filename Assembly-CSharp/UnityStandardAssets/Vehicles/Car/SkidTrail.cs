using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class SkidTrail : MonoBehaviour
	{
		[SerializeField]
		private float m_PersistTime;

		private IEnumerator Start()
		{
			while (true)
			{
				yield return null;
				if (base.transform.parent.parent == null)
				{
					Object.Destroy(base.gameObject, m_PersistTime);
				}
			}
		}
	}
}
