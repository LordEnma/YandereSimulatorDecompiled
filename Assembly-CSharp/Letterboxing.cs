using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	private const float KEEP_ASPECT = 1.7777778f;

	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}
}
