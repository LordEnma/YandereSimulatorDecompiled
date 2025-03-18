using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class CameraFollow : MonoBehaviour
	{
		public float xMargin = 1f;

		public float yMargin = 1f;

		public float xSmooth = 8f;

		public float ySmooth = 8f;

		public Vector2 maxXAndY;

		public Vector2 minXAndY;

		private Transform m_Player;

		private void Awake()
		{
			m_Player = GameObject.FindGameObjectWithTag("Player").transform;
		}

		private bool CheckXMargin()
		{
			return Mathf.Abs(base.transform.position.x - m_Player.position.x) > xMargin;
		}

		private bool CheckYMargin()
		{
			return Mathf.Abs(base.transform.position.y - m_Player.position.y) > yMargin;
		}

		private void Update()
		{
			TrackPlayer();
		}

		private void TrackPlayer()
		{
			float value = base.transform.position.x;
			float value2 = base.transform.position.y;
			if (CheckXMargin())
			{
				value = Mathf.Lerp(base.transform.position.x, m_Player.position.x, xSmooth * Time.deltaTime);
			}
			if (CheckYMargin())
			{
				value2 = Mathf.Lerp(base.transform.position.y, m_Player.position.y, ySmooth * Time.deltaTime);
			}
			value = Mathf.Clamp(value, minXAndY.x, maxXAndY.x);
			value2 = Mathf.Clamp(value2, minXAndY.y, maxXAndY.y);
			base.transform.position = new Vector3(value, value2, base.transform.position.z);
		}
	}
}
