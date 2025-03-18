using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private float distance = 10f;

		[SerializeField]
		private float height = 5f;

		[SerializeField]
		private float rotationDamping;

		[SerializeField]
		private float heightDamping;

		private void Start()
		{
		}

		private void LateUpdate()
		{
			if ((bool)target)
			{
				float y = target.eulerAngles.y;
				float b = target.position.y + height;
				float y2 = base.transform.eulerAngles.y;
				float y3 = base.transform.position.y;
				y2 = Mathf.LerpAngle(y2, y, rotationDamping * Time.deltaTime);
				y3 = Mathf.Lerp(y3, b, heightDamping * Time.deltaTime);
				Quaternion quaternion = Quaternion.Euler(0f, y2, 0f);
				base.transform.position = target.position;
				base.transform.position -= quaternion * Vector3.forward * distance;
				base.transform.position = new Vector3(base.transform.position.x, y3, base.transform.position.z);
				base.transform.LookAt(target);
			}
		}
	}
}
