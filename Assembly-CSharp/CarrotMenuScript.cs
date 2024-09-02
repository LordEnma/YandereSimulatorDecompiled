using UnityEngine;

public class CarrotMenuScript : MonoBehaviour
{
	public HomeDarknessScript HomeDarkness;

	public bool Show;

	public UISprite Sprite;

	private void Update()
	{
		if (Show)
		{
			Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 1f, Time.deltaTime * 10f);
			if (Sprite.alpha == 1f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					PlayerGlobals.BroughtCarrotsToSchool = true;
					HomeDarkness.HomeExit.ID = 1;
					HomeDarkness.FadeOut = true;
					Show = false;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					HomeDarkness.HomeYandere.CanMove = true;
					Show = false;
				}
			}
		}
		else
		{
			Sprite.alpha = Mathf.MoveTowards(Sprite.alpha, 0f, Time.deltaTime * 10f);
		}
	}
}
