using UnityEngine;
using UnityEngine.SceneManagement;

public class SponsorScript : MonoBehaviour
{
	public UISprite Darkness;

	public UIPanel[] Set;

	public float Timer;

	public float Speed = 1f;

	public int ID;

	private void Start()
	{
		Time.timeScale = 1f;
		Darkness.alpha = 1f;
		Set[1].alpha = 1f;
		Set[2].alpha = 0f;
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (ID == 0)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * Speed);
			if (Darkness.alpha < 0.0001f)
			{
				ID++;
			}
		}
		else if (ID == 1)
		{
			if (Input.anyKeyDown)
			{
				Timer = 5f;
			}
			if (Timer >= 5f)
			{
				Set[1].alpha = Mathf.MoveTowards(Set[1].alpha, 0f, Time.deltaTime * Speed);
				if (Set[1].alpha < 0.0001f)
				{
					Timer = 0f;
					ID = 4;
				}
			}
		}
		else if (ID == 4)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * Speed);
			if (Darkness.alpha > 0.999f)
			{
				Darkness.color = new Color(1f, 1f, 1f, 1f);
				SceneManager.LoadScene("NewTitleScene");
			}
		}
	}
}
