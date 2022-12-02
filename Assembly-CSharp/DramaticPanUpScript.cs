using UnityEngine;

public class DramaticPanUpScript : MonoBehaviour
{
	public bool Pan;

	public float Height;

	public float Power;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Pan = true;
		}
		if (Pan)
		{
			Power += Time.deltaTime * 0.5f;
			Height = Mathf.Lerp(Height, 1.4f, Power * Time.deltaTime);
			base.transform.localPosition = new Vector3(0f, Height, 1f);
		}
	}
}
