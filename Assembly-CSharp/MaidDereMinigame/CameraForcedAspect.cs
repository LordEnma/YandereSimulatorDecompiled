using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		public Vector2 targetAspect = new Vector2(16f, 9f);

		private Camera cam;

		private void Awake()
		{
			cam = GetComponent<Camera>();
		}

		private void Start()
		{
			float num = targetAspect.x / targetAspect.y;
			float num2 = (float)Screen.width / (float)Screen.height / num;
			if (num2 < 1f)
			{
				Rect rect = cam.rect;
				rect.width = 1f;
				rect.height = num2;
				rect.x = 0f;
				rect.y = (1f - num2) / 2f;
				cam.rect = rect;
			}
			else
			{
				Rect rect2 = cam.rect;
				float num3 = (rect2.width = 1f / num2);
				rect2.height = 1f;
				rect2.x = (1f - num3) / 2f;
				rect2.y = 0f;
				cam.rect = rect2;
			}
		}
	}
}
