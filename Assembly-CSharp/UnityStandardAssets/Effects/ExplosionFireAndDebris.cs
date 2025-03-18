using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExplosionFireAndDebris : MonoBehaviour
	{
		public Transform[] debrisPrefabs;

		public Transform firePrefab;

		public int numDebrisPieces;

		public int numFires;

		private IEnumerator Start()
		{
			float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;
			for (int i = 0; (float)i < (float)numDebrisPieces * multiplier; i++)
			{
				Transform original = debrisPrefabs[Random.Range(0, debrisPrefabs.Length)];
				Vector3 position = base.transform.position + Random.insideUnitSphere * 3f * multiplier;
				Quaternion rotation = Random.rotation;
				Object.Instantiate(original, position, rotation);
			}
			yield return null;
			float num = 10f * multiplier;
			Collider[] array = Physics.OverlapSphere(base.transform.position, num);
			foreach (Collider collider in array)
			{
				if (numFires > 0)
				{
					Ray ray = new Ray(base.transform.position, collider.transform.position - base.transform.position);
					if (collider.Raycast(ray, out var hitInfo, num))
					{
						AddFire(collider.transform, hitInfo.point, hitInfo.normal);
						numFires--;
					}
				}
			}
			float num2 = 0f;
			while (numFires > 0 && num2 < num)
			{
				if (Physics.Raycast(new Ray(base.transform.position + Vector3.up, Random.onUnitSphere), out var hitInfo2, num2))
				{
					AddFire(null, hitInfo2.point, hitInfo2.normal);
					numFires--;
				}
				num2 += num * 0.1f;
			}
		}

		private void AddFire(Transform t, Vector3 pos, Vector3 normal)
		{
			pos += normal * 0.5f;
			Object.Instantiate(firePrefab, pos, Quaternion.identity).parent = t;
		}
	}
}
