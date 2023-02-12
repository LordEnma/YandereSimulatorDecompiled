using UnityEngine;
using UnityEngine.Video;

public class TriviaCardScript : MonoBehaviour
{
	public TriviaManagerScript TriviaManager;

	public Transform VideoParent;

	public VideoPlayer Video;

	public UILabel Label;

	public UISprite BG;

	public float Timer;

	public int Phase;

	private void Start()
	{
		VideoParent.localPosition = new Vector3(0f, 7.5f, 0f);
		VideoParent.localScale = new Vector3(1f, 0.633333f, 1f);
		VideoParent.gameObject.SetActive(value: false);
		Label.alpha = 0f;
		BG.alpha = 0f;
	}

	private void Update()
	{
		if (Phase == 0)
		{
			BG.alpha = Mathf.MoveTowards(BG.alpha, 1f, Time.deltaTime);
			if (BG.alpha == 1f)
			{
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			VideoParent.gameObject.SetActive(value: true);
			VideoParent.localPosition = Vector3.Lerp(VideoParent.localPosition, new Vector3(0f, 485f, 0f), Time.deltaTime * 10f);
			VideoParent.localScale = Vector3.Lerp(VideoParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (VideoParent.localPosition.y > 484f)
			{
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Label.alpha = Mathf.MoveTowards(Label.alpha, 1f, Time.deltaTime);
			if (Label.alpha == 1f)
			{
				TriviaManager.CanSpawn = true;
				Timer = 0f;
				Phase++;
			}
		}
	}
}
