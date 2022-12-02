using UnityEngine;

public class LocationScript : MonoBehaviour
{
	public UILabel Label;

	public UISprite BG;

	public bool Show;

	private void Start()
	{
		Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, 0f);
		BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 0f);
	}

	private void Update()
	{
		if (Show)
		{
			BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, BG.color.a + Time.deltaTime * 10f);
			if (BG.color.a > 1f)
			{
				BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 1f);
			}
			Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, BG.color.a);
		}
		else
		{
			BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, BG.color.a - Time.deltaTime * 10f);
			if (BG.color.a < 0f)
			{
				BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 0f);
			}
			Label.color = new Color(Label.color.r, Label.color.g, Label.color.b, BG.color.a);
		}
	}
}
