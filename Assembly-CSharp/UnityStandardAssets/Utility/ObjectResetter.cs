using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ObjectResetter : MonoBehaviour
	{
		private Vector3 originalPosition;

		private Quaternion originalRotation;

		private List<Transform> originalStructure;

		private Rigidbody Rigidbody;

		private void Start()
		{
			originalStructure = new List<Transform>(GetComponentsInChildren<Transform>());
			originalPosition = base.transform.position;
			originalRotation = base.transform.rotation;
			Rigidbody = GetComponent<Rigidbody>();
		}

		public void DelayedReset(float delay)
		{
			StartCoroutine(ResetCoroutine(delay));
		}

		public IEnumerator ResetCoroutine(float delay)
		{
			yield return new WaitForSeconds(delay);
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (!originalStructure.Contains(transform))
				{
					transform.parent = null;
				}
			}
			base.transform.position = originalPosition;
			base.transform.rotation = originalRotation;
			if ((bool)Rigidbody)
			{
				Rigidbody.linearVelocity = Vector3.zero;
				Rigidbody.angularVelocity = Vector3.zero;
			}
			SendMessage("Reset");
		}
	}
}
