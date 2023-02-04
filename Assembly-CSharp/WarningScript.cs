using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningScript : MonoBehaviour
{
	public float[] Triggers;

	public string[] Text;

	public UILabel WarningLabel;

	public UISprite Darkness;

	public UILabel Label;

	public bool FadeOut;

	public float Timer;

	public int ID;

	private void Start()
	{
		WarningLabel.gameObject.SetActive(value: false);
		Label.text = string.Empty;
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
	}

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (!FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a == 0f)
			{
				if (Timer == 0f)
				{
					WarningLabel.gameObject.SetActive(value: true);
					component.Play();
				}
				Timer += Time.deltaTime;
				if (ID < Triggers.Length && Timer > Triggers[ID])
				{
					Label.text = Text[ID];
					ID++;
				}
			}
		}
		else
		{
			component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime);
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a == 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
		if (Input.anyKey)
		{
			FadeOut = true;
		}
	}
}
