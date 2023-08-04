using UnityEngine;

public class LocationScript : MonoBehaviour
{
	public UILabel Label;

	public UISprite BG;

	public bool Show;

	private void Start()
	{
		BG.alpha = 0f;
		Label.alpha = 0f;
	}

	private void Update()
	{
		if (Show)
		{
			if (BG.alpha < 1f)
			{
				BG.alpha = Mathf.MoveTowards(BG.alpha, 1f, Time.deltaTime * 10f);
				Label.alpha = BG.alpha;
			}
		}
		else if (BG.alpha > 0f)
		{
			BG.alpha = Mathf.MoveTowards(BG.alpha, 0f, Time.deltaTime * 10f);
			Label.alpha = BG.alpha;
		}
	}
}
