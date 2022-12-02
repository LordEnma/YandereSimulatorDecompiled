using UnityEngine;

public class CircleFillScript : MonoBehaviour
{
	public UISprite OsanaFill;

	public UITexture OtherFill;

	public UITexture Fill;

	public float Speed;

	public int Phase;

	private void Update()
	{
		Speed += Time.deltaTime;
		Fill.transform.localPosition = Vector3.Lerp(Fill.transform.localPosition, new Vector3(-1024f, 0f, 0f), Time.deltaTime * Speed);
		if (Fill.transform.localPosition.x < -1023f)
		{
			if (Phase == 0)
			{
				Phase++;
				Speed = 0f;
			}
			Fill.fillAmount = Mathf.Lerp(Fill.fillAmount, 1f, Time.deltaTime * Speed);
		}
	}
}
