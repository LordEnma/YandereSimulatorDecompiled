using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaTitleScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GameObject ButtonEffect;

	public GameObject ErrorWindow;

	public GameObject SkipButton;

	public Transform Highlight;

	public Transform Prologue;

	public UIPanel Controls;

	public UIPanel Credits;

	public UIPanel Buttons;

	public UISprite Darkness;

	public UITexture Midori;

	public UITexture Logo;

	public AudioClip SelectSound;

	public AudioClip ExitSound;

	public AudioClip BGM;

	public Transform[] BackButtons;

	public Texture SadMidori;

	public bool FadeButtons;

	public bool ErrorLeave;

	public bool FadeOut;

	public float ScrollSpeed;

	public int Selected = 1;

	private void Start()
	{
		Midori.transform.localPosition = new Vector3(1540f, 0f, 0f);
		Midori.transform.localEulerAngles = Vector3.zero;
		Midori.gameObject.SetActive(false);
		if (YanvaniaGlobals.DraculaDefeated)
		{
			TaskGlobals.SetTaskStatus(38, 2);
			SkipButton.SetActive(true);
			Logo.gameObject.SetActive(false);
		}
		else
		{
			SkipButton.SetActive(false);
		}
		Prologue.gameObject.SetActive(false);
		Prologue.localPosition = new Vector3(Prologue.localPosition.x, -2665f, Prologue.localPosition.z);
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		Buttons.alpha = 0f;
		Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, 0f);
	}

	private void Update()
	{
		if (!Logo.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.M))
		{
			YanvaniaGlobals.DraculaDefeated = true;
			YanvaniaGlobals.MidoriEasterEgg = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown(KeyCode.End))
		{
			YanvaniaGlobals.DraculaDefeated = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			YanvaniaGlobals.DraculaDefeated = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		AudioSource component = GetComponent<AudioSource>();
		if (!FadeOut)
		{
			if (Darkness.color.a > 0f)
			{
				if (Input.GetButtonDown("A"))
				{
					Skip();
				}
				if (!ErrorWindow.activeInHierarchy)
				{
					Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a - Time.deltaTime);
				}
			}
			else
			{
				if (!(Darkness.color.a <= 0f))
				{
					return;
				}
				if (!YanvaniaGlobals.MidoriEasterEgg)
				{
					if (YanvaniaGlobals.DraculaDefeated)
					{
						if (!Prologue.gameObject.activeInHierarchy)
						{
							Prologue.gameObject.SetActive(true);
							component.volume = 0.5f;
							component.loop = true;
							component.clip = BGM;
							component.Play();
						}
						if (Input.GetButtonDown("B"))
						{
							Prologue.localPosition = new Vector3(Prologue.localPosition.x, 2501f, Prologue.localPosition.z);
							Prologue.GetComponent<AudioSource>().Stop();
						}
						if (Prologue.localPosition.y > 2500f)
						{
							if (component.isPlaying)
							{
								Midori.mainTexture = SadMidori;
								Time.timeScale = 1f;
								Midori.gameObject.GetComponent<AudioSource>().Stop();
								component.Stop();
							}
							if (!ErrorLeave)
							{
								ErrorWindow.SetActive(true);
								ErrorWindow.transform.localScale = Vector3.Lerp(ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
								if (ErrorWindow.transform.localScale.x > 0.9f && Input.anyKeyDown)
								{
									AudioSource component2 = ErrorWindow.GetComponent<AudioSource>();
									component2.clip = ExitSound;
									component2.Play();
									ErrorLeave = true;
								}
							}
							else
							{
								FadeOut = true;
							}
						}
						else
						{
							Prologue.localPosition = new Vector3(Prologue.localPosition.x, Prologue.localPosition.y + Time.deltaTime * ScrollSpeed, Prologue.localPosition.z);
							if (Input.GetKeyDown(KeyCode.Equals))
							{
								Time.timeScale = 100f;
							}
							if (Input.GetKeyDown(KeyCode.Minus))
							{
								Time.timeScale = 1f;
							}
						}
						return;
					}
					if (!component.isPlaying)
					{
						if (Logo.color.a == 0f)
						{
							component.Play();
							return;
						}
						component.loop = true;
						component.clip = BGM;
						component.Play();
						return;
					}
					if (component.clip != BGM)
					{
						Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, Logo.color.a + Time.deltaTime);
						if (Input.GetButtonDown("A"))
						{
							Skip();
						}
						return;
					}
					if (!FadeButtons)
					{
						Controls.alpha = Mathf.MoveTowards(Controls.alpha, 0f, Time.deltaTime);
						Credits.alpha = Mathf.MoveTowards(Credits.alpha, 0f, Time.deltaTime);
						if (Controls.alpha != 0f || Credits.alpha != 0f)
						{
							return;
						}
						Highlight.localPosition = new Vector3(Highlight.localPosition.x, -100f - 100f * (float)Selected, Highlight.localPosition.z);
						Buttons.alpha += Time.deltaTime;
						if (!(Buttons.alpha >= 1f))
						{
							return;
						}
						if (Input.GetButtonDown("A"))
						{
							Object.Instantiate(ButtonEffect, Highlight.position, Quaternion.identity);
							if (Selected == 1 || Selected == 4)
							{
								FadeOut = true;
							}
							if (Selected == 2 || Selected == 3)
							{
								FadeButtons = true;
							}
						}
						AudioSource component3 = Highlight.gameObject.GetComponent<AudioSource>();
						if (InputManager.TappedUp)
						{
							component3.Play();
							Selected--;
							if (Selected < 1)
							{
								Selected = 4;
							}
						}
						if (InputManager.TappedDown)
						{
							component3.Play();
							Selected++;
							if (Selected > 4)
							{
								Selected = 1;
							}
						}
						return;
					}
					Buttons.alpha -= Time.deltaTime;
					if (Buttons.alpha == 0f)
					{
						if (Selected == 2)
						{
							Controls.alpha = Mathf.MoveTowards(Controls.alpha, 1f, Time.deltaTime);
						}
						else
						{
							Credits.alpha = Mathf.MoveTowards(Credits.alpha, 1f, Time.deltaTime);
						}
					}
					if ((Controls.alpha == 1f || Credits.alpha == 1f) && Input.GetButtonDown("B"))
					{
						Object.Instantiate(ButtonEffect, BackButtons[Selected].position, Quaternion.identity);
						FadeButtons = false;
					}
				}
				else
				{
					Prologue.GetComponent<AudioSource>().enabled = false;
					Midori.gameObject.SetActive(true);
					ScrollSpeed = 60f;
					Midori.transform.localPosition = new Vector3(Mathf.Lerp(Midori.transform.localPosition.x, 875f, Time.deltaTime * 2f), Midori.transform.localPosition.y, Midori.transform.localPosition.z);
					Midori.transform.localEulerAngles = new Vector3(Midori.transform.localEulerAngles.x, Midori.transform.localEulerAngles.y, Mathf.Lerp(Midori.transform.localEulerAngles.z, 45f, Time.deltaTime * 2f));
					if (Midori.gameObject.GetComponent<AudioSource>().time > 3f)
					{
						YanvaniaGlobals.MidoriEasterEgg = false;
					}
				}
			}
			return;
		}
		ErrorWindow.transform.localScale = Vector3.Lerp(ErrorWindow.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
		component.volume -= Time.deltaTime;
		if (Darkness.color.a >= 1f)
		{
			if (YanvaniaGlobals.DraculaDefeated)
			{
				SceneManager.LoadScene("HomeScene");
			}
			else if (Selected == 1)
			{
				SceneManager.LoadScene("YanvaniaScene");
			}
			else
			{
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	private void Skip()
	{
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
		Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, 1f);
		AudioSource component = GetComponent<AudioSource>();
		component.loop = true;
		component.clip = BGM;
		component.Play();
	}
}
