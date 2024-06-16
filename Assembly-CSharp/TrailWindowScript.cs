using UnityEngine;

public class TrailWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform[] Destinations;

	public YandereScript Yandere;

	public Transform Highlight;

	public float DownTimer;

	public float UpTimer;

	public int Selected;

	public bool Eighties;

	private void Start()
	{
		Eighties = GameGlobals.Eighties;
	}

	private void Update()
	{
		if (Input.GetKey("down"))
		{
			DownTimer += Time.deltaTime;
		}
		if (Input.GetKeyUp("down"))
		{
			DownTimer = 0f;
		}
		if (Yandere.PauseScreen.InputManager.TappedDown || DownTimer > 0.5f)
		{
			if (DownTimer > 0.5f)
			{
				DownTimer = 0.4f;
			}
			Selected++;
			if (Selected > 15)
			{
				Selected = 1;
			}
			UpdateHighlight();
		}
		if (Input.GetKey("up"))
		{
			UpTimer += Time.deltaTime;
		}
		if (Input.GetKeyUp("up"))
		{
			UpTimer = 0f;
		}
		if (Yandere.PauseScreen.InputManager.TappedUp || UpTimer > 0.5f)
		{
			if (UpTimer > 0.5f)
			{
				UpTimer = 0.4f;
			}
			Selected--;
			if (Selected < 1)
			{
				Selected = 15;
			}
			UpdateHighlight();
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Yandere.PromptParent.gameObject.SetActive(value: true);
			Yandere.PromptBar.ClearButtons();
			Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	private void UpdateHighlight()
	{
		if (StudentManager.Students[1] != null)
		{
			Destinations[2] = StudentManager.Students[1].transform;
		}
		if (StudentManager.Students[StudentManager.RivalID] != null)
		{
			Destinations[3] = StudentManager.Students[StudentManager.RivalID].transform;
		}
		if (StudentManager.Students[StudentManager.RivalID] != null)
		{
			Destinations[4] = StudentManager.Students[StudentManager.RivalID].Seat;
		}
		Highlight.localPosition = new Vector3(0f, 400 - 50 * Selected, 0f);
	}
}
