using UnityEngine;

public class RetroMinigameScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject GameOverGraphic;

	public GameObject MinigameCamera;

	public GameObject Heart;

	public Texture ModernTexture;

	public UITexture MyRenderer;

	public GameObject[] PipeSet;

	public UILabel ScoreLabel;

	public float GameOverTimer;

	public float Momentum;

	public bool GameOver;

	public float Speed;

	public int Score;

	public bool Show;

	private void Start()
	{
		Heart.transform.localPosition = new Vector3(-3.125f, 0f, 1f);
		PipeSet[1].transform.localPosition = new Vector3(8f, Random.RandomRange(-1.52f, 1.52f), 1f);
		PipeSet[2].transform.localPosition = new Vector3(13f, Random.RandomRange(-1.52f, 1.52f), 1f);
		PipeSet[3].transform.localPosition = new Vector3(18f, Random.RandomRange(-1.52f, 1.52f), 1f);
		PipeSet[4].transform.localPosition = new Vector3(23f, Random.RandomRange(-1.52f, 1.52f), 1f);
		PipeSet[5].transform.localPosition = new Vector3(28f, Random.RandomRange(-1.52f, 1.52f), 1f);
		GameOverGraphic.SetActive(value: false);
		ScoreLabel.text = "0";
		GameOverTimer = 0f;
		GameOver = false;
		Momentum = 2f;
		Score = 0;
		Speed = 2f;
	}

	private void Update()
	{
		if (Show)
		{
			if (base.transform.localPosition.y < -1f)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
				if (base.transform.localPosition.y > -1f)
				{
					base.transform.localPosition = new Vector3(0f, 0f, 0f);
					MinigameCamera.SetActive(value: true);
				}
			}
			else if (!GameOver)
			{
				Speed += Time.unscaledDeltaTime * 0.1f;
				for (int i = 1; i < 6; i++)
				{
					PipeSet[i].transform.localPosition -= new Vector3(Time.unscaledDeltaTime * Speed, 0f, 0f);
					if (PipeSet[i].transform.localPosition.x < -8f)
					{
						PipeSet[i].transform.localPosition = new Vector3(17f, Random.RandomRange(-1.52f, 1.52f), 1f);
						Score++;
						ScoreLabel.text = Score.ToString() ?? "";
					}
				}
				Heart.transform.localPosition += new Vector3(0f, Momentum * Time.unscaledDeltaTime * 5f, 0f);
				Momentum -= Time.unscaledDeltaTime * 5f;
				if (Input.GetButtonDown("A"))
				{
					Momentum = 1f;
				}
				if (Heart.transform.localPosition.y > 4.6f)
				{
					Heart.transform.localPosition = new Vector3(-3.125f, 4.6f, 1f);
					Momentum = 0f;
				}
				if (Heart.transform.localPosition.y <= -4.6f)
				{
					Heart.transform.localPosition = new Vector3(-3.125f, -4.6f, 1f);
					GetGameOver();
				}
			}
			else
			{
				GameOverTimer += Time.unscaledDeltaTime;
				if (GameOverTimer > 1f && Input.GetButtonDown("A"))
				{
					Start();
				}
			}
			if (Yandere.CanMove)
			{
				MinigameCamera.SetActive(value: false);
				Show = false;
			}
		}
		else if (base.transform.localPosition.y > -1154f)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, -1155f, 0f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localPosition.y < -1154f)
			{
				base.transform.localPosition = new Vector3(0f, -1155f, 0f);
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void GetGameOver()
	{
		GameOverGraphic.SetActive(value: true);
		GameOver = true;
	}
}
