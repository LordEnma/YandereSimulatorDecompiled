using UnityEngine;

public class AspectRatioAdjusterScript : MonoBehaviour
{
	private float tolerance = 0.01f;

	private float width = 1f;

	private void Start()
	{
		width = base.transform.localScale.x;
		AdjustAspectRatio();
	}

	private void AdjustAspectRatio()
	{
		float num = (float)Screen.width / (float)Screen.height;
		Vector3 localScale = base.transform.localScale;
		if (Mathf.Abs(num - 1.6f) < tolerance)
		{
			Debug.Log("We are 16:10 instead of 16:9");
			localScale.x = width * 0.9f;
			base.transform.localScale = localScale;
		}
	}
}
