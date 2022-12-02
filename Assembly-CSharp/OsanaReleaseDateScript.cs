using UnityEngine;

public class OsanaReleaseDateScript : MonoBehaviour
{
	public UISprite[] BlackRectangles;

	public bool ChooseRectangle = true;

	public int LettersRevealed;

	public int RandomID;

	private void Start()
	{
		Time.timeScale = 1f;
		UISprite[] blackRectangles = BlackRectangles;
		foreach (UISprite uISprite in blackRectangles)
		{
			if (uISprite != null)
			{
				uISprite.alpha = 1f;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (ChooseRectangle)
		{
			if (LettersRevealed < 33)
			{
				RandomID = Random.Range(1, BlackRectangles.Length);
				while (BlackRectangles[RandomID].alpha == 0f || (RandomID > 28 && RandomID < 34))
				{
					RandomID = Random.Range(1, BlackRectangles.Length);
				}
			}
			else
			{
				RandomID = Random.Range(28, 34);
				while (BlackRectangles[RandomID].alpha == 0f)
				{
					RandomID = Random.Range(1, BlackRectangles.Length);
				}
			}
			ChooseRectangle = false;
			return;
		}
		BlackRectangles[RandomID].alpha = Mathf.MoveTowards(BlackRectangles[RandomID].alpha, 0f, Time.deltaTime * (19f / 30f));
		if (BlackRectangles[RandomID].alpha == 0f)
		{
			LettersRevealed++;
			if (LettersRevealed < 38)
			{
				ChooseRectangle = true;
			}
			else
			{
				base.enabled = false;
			}
		}
	}
}
