using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
	public JsonScript JSON;

	public GameObject WelcomePanel;

	public UILabel[] FlashingLabels;

	public UILabel AltBeginLabel;

	public UILabel BeginLabel;

	public UILabel[] Labels;

	public string[] Jokes;

	public UISprite Darkness;

	public bool Continue;

	public bool FlashRed;

	public bool AprilFools;

	public float VersionNumber;

	public float Timer;

	public float Speed = 1f;

	public string Text;

	public int CurrentLabel = 1;

	public int ID;

	private void Start()
	{
		if (AprilFools)
		{
			Labels[1].text = Jokes[1];
			Labels[2].text = Jokes[2];
			Labels[3].text = Jokes[3];
			Labels[4].text = Jokes[4];
			Labels[5].text = Jokes[5];
			Labels[6].text = Jokes[6];
			Labels[7].text = Jokes[7];
		}
		Time.timeScale = 1f;
		for (ID = 0; ID < Labels.Length; ID++)
		{
			Labels[ID].color = new Color(Labels[ID].color.r, Labels[ID].color.g, Labels[ID].color.b, 0f);
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (ApplicationGlobals.VersionNumber != VersionNumber)
		{
			ApplicationGlobals.VersionNumber = VersionNumber;
		}
		if (!Application.CanStreamedLevelBeLoaded("FunScene"))
		{
			Application.Quit();
		}
		if (File.Exists(Application.streamingAssetsPath + "/Fun.txt"))
		{
			Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
		}
		if (Text != "")
		{
			if (Text == "0" || Text == "1" || Text == "2" || Text == "3" || Text == "4" || Text == "5" || Text == "6" || Text == "7" || Text == "8" || Text == "9" || Text == "10" || Text == "69" || Text == "666")
			{
				SceneManager.LoadScene("VeryFunScene");
			}
			else
			{
				SceneManager.LoadScene("FunScene");
			}
		}
		Darkness.color = Color.white;
	}

	private void Update()
	{
		Input.GetKeyDown(KeyCode.S);
		Input.GetKeyDown(KeyCode.Y);
		if (!Continue)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a - Time.deltaTime);
			if (!(Darkness.color.a <= 0f))
			{
				return;
			}
			Input.GetKeyDown(KeyCode.W);
			if (Input.anyKeyDown)
			{
				Speed += 1f;
			}
			if (CurrentLabel < Labels.Length)
			{
				Labels[CurrentLabel].color = new Color(Labels[CurrentLabel].color.r, Labels[CurrentLabel].color.g, Labels[CurrentLabel].color.b, Labels[CurrentLabel].color.a + Time.deltaTime * Speed);
				if (Labels[CurrentLabel].color.a >= 1f)
				{
					CurrentLabel++;
				}
			}
			else if (Input.anyKeyDown)
			{
				Darkness.color = new Color(1f, 1f, 1f, 0f);
				Continue = true;
			}
		}
		else
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
			if (Darkness.color.a >= 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
	}
}
