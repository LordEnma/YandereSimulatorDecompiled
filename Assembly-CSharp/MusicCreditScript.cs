using UnityEngine;

public class MusicCreditScript : MonoBehaviour
{
	public UILabel SongLabel;

	public UILabel BandLabel;

	public UISprite Sprite;

	public bool Slide;

	public float Timer;

	private void Start()
	{
		base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
		Sprite.enabled = false;
	}

	private void Update()
	{
		if (!Slide)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer < 5f)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime, base.transform.localPosition.y, base.transform.localPosition.z);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x + Mathf.Abs(base.transform.localPosition.x * 0.01f) * (Time.deltaTime * 1000f), base.transform.localPosition.y, base.transform.localPosition.z);
		if (base.transform.localPosition.x > 400f)
		{
			base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
			Sprite.enabled = false;
			Slide = false;
			Timer = 0f;
		}
	}
}
