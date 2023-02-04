using UnityEngine;
using UnityEngine.SceneManagement;

public class SponsorScript : MonoBehaviour
{
	public GameObject[] Set;

	public UISprite Darkness;

	public float Timer;

	public int ID;

	private void Start()
	{
		Time.timeScale = 1f;
		Set[1].SetActive(value: true);
		Set[2].SetActive(value: false);
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer < 3.2f)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
		if (Darkness.color.a > 0.99f)
		{
			Darkness.color = new Color(1f, 1f, 1f, 1f);
			SceneManager.LoadScene("NewTitleScene");
		}
	}
}
