using UnityEngine;

public class AspectRatioAdjusterScript : MonoBehaviour
{
	private float tolerance = 0.01f;

	private void Start()
	{
		AdjustAspectRatio();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			AdjustAspectRatio();
		}
	}

	public void AdjustAspectRatio()
	{
		float num = (float)Screen.width / (float)Screen.height;
		Vector3 localScale = base.transform.localScale;
		if (Mathf.Abs(num - 1.6f) < tolerance)
		{
			Debug.Log("We are 16:10 instead of 16:9");
			localScale.x = 0.9f;
		}
		else
		{
			localScale.x = 1f;
		}
		base.transform.localScale = localScale;
	}
}
