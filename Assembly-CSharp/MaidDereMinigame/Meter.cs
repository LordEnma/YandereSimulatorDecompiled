using UnityEngine;

namespace MaidDereMinigame
{
	public class Meter : MonoBehaviour
	{
		public SpriteRenderer fillBar;

		public float emptyPos;

		private float startPos;

		private void Awake()
		{
			startPos = fillBar.transform.localPosition.x;
		}

		public void SetFill(float interpolater)
		{
			float num = Mathf.Lerp(emptyPos, startPos, interpolater);
			num = Mathf.Round(num * 50f) / 50f;
			fillBar.transform.localPosition = new Vector3(num, 0f, 0f);
		}
	}
}
