using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GameObject LongTextObject;

	public GameObject TextObject;

	public GameObject YearObject;

	public AudioSource Ambience;

	public AudioSource MyAudio;

	public UISprite Darkness;

	public UILabel FinalLabel;

	public float MaxHeight;

	public float Speed = 0.05f;

	public float Timer;

	public bool Hide;

	public bool Long;

	public int Height;

	private void Start()
	{
		base.transform.localPosition = new Vector3(0f, -0.6f, 1f);
		MaxHeight = base.transform.localPosition.y;
		Darkness.alpha = 0f;
		SpawnYear(1778);
		SpawnAishiData("The Aishi Precursor is born.");
		Height -= 100;
		SpawnYear(1797);
		SpawnAishiData("The Aishi Precursor arrives in Japan.");
		Height -= 100;
		SpawnYear(1800);
		SpawnAishiData("The First Aishi is born.");
		Height -= 100;
		SpawnYear(1928);
		SpawnSaikouData("Saisho Saikou is born.");
		Height -= 100;
		SpawnYear(1930);
		SpawnAishiData("Ryoba's grandmother is born.");
		Height -= 100;
		SpawnYear(1939);
		SpawnMiscData("World War 2 begins.");
		Height -= 100;
		SpawnYear(1945);
		SpawnMiscData("The United States of America invades the Japanese island of Okinawa.");
		SpawnSaikouData("Saisho Saikou is present at the Battle of Okinawa.");
		Height -= 200;
		SpawnMiscData("World War 2 ends.");
		SpawnSaikouData("Saisho Saikou becomes very active in helping to rebuild post-war Japan.");
		Height -= 150;
		SpawnYear(1946);
		SpawnSaikouData("Saisho Saikou decides that the best way to help his country is with his engineering knowledge.");
		Height -= 200;
		SpawnSaikouData("Saisho Saikou starts an electronics repair shop.");
		Height -= 150;
		SpawnSaikouData("Saisho Saikou starts a company named Saikou Corp.");
		Height -= 150;
		SpawnSaikouData("Saisho Saikou invents Japan's first tape recorder.");
		Height -= 150;
		SpawnYear(1948);
		SpawnAishiData("Ryoba's grandmother finds her Senpai.");
		Height -= 150;
		SpawnYear(1950);
		SpawnAishiData("Ryoba's grandmother buys a house in Buraza, a small town near Tokyo.");
		Height -= 150;
		SpawnAishiData("Ryoba's mother is born.");
		Height -= 100;
		SpawnYear(1954);
		SpawnSaikouData("Saikou Corp releases the world's first transistor radio.");
		Height -= 150;
		SpawnYear(1960);
		SpawnMiscData("Kocho Shuyona is born.");
		Height -= 100;
		SpawnYear(1961);
		SpawnSaikouData("Saikou Corp releases the world's first compact video tape recorder.");
		Height -= 150;
		SpawnYear(1967);
		SpawnSaikouData("Saikou Corp releases the world's first integrated circuit radio.");
		Height -= 150;
		SpawnYear(1968);
		SpawnAishiData("Ryoba's grandmother adds a basement to her house.");
		SpawnSaikouData("Saikou Corp releases the world's first color television set.");
		Height -= 150;
		SpawnAishiData("Ryoba's mother finds her Senpai, kidnaps him, and keeps him prisoner in her basement.");
		Height -= 200;
		SpawnYear(1969);
		SpawnMiscData("A man is born who would later become an investigative journalist.");
		SpawnSaikouData("Saikou Corp releases the world's first compact cassette recorder.");
		Height -= 150;
		SpawnYear(1970);
		SpawnSaikouData("Saisho Saikou's daughter is born. She is named Ichiko.");
		Height -= 150;
		SpawnYear(1971);
		SpawnAishiData("Ryoba is born.");
		Height -= 100;
		SpawnYear(1976);
		SpawnAishiData("Ryoba's sister is born.");
		Height -= 100;
		SpawnYear(1979);
		SpawnSaikouData("Saikou Corp releases the world's first portable cassette tape player.");
		Height -= 150;
		SpawnYear(1981);
		SpawnSaikouData("Saikou Corp releases the world's first compact disc player.");
		Height -= 150;
		SpawnYear(1983);
		SpawnSaikouData("Saisho Saikou's son is born. He is named Ichirou.");
		Height -= 150;
		SpawnYear(1984);
		SpawnSaikouData("Saisho Saikou orders the construction of a post-highschool academy near Buraza Town.");
		Height -= 200;
		SpawnSaikouData("The academy is named Akademi.");
		Height -= 100;
		SpawnSaikouData("Saikou Corp renovates numerous houses in Buraza Town for free, including Ryoba's home.");
		Height -= 200;
		SpawnYear(1985);
		SpawnMiscData("Kocho Shuyona is interviewed by Saisho Saikou and is selected to become the headmaster of Akademi.");
		Height -= 200;
		SpawnYear(1986);
		SpawnMiscData("Akademi officially opens.");
		SpawnSaikouData("Ichiko Saikou enrolls in Akademi.");
		Height -= 100;
		SpawnYear(1988);
		SpawnAishiData("Ryoba enrolls in Akademi.");
		SpawnSaikouData("Ichiko Saikou graduates from Akademi.");
		Height -= 150;
		SpawnAishiData("Ryoba finds her Senpai.");
		Height -= 100;
		SpawnYear(1989);
		SpawnAishiData("Ryoba eliminates every girl who seeks to enter a relationship with her Senpai.");
		SpawnSaikouData("Saikou Corp begins manufacturing handheld electronic gaming devices.");
		Height -= 150;
		SpawnMiscData("An investigative journalist accuses Ryoba of murder.");
		Height -= 150;
		SpawnAishiData("Ryoba stands trial in a highly televised court case.");
		Height -= 150;
		SpawnAishiData("Ryoba is declared innocent.");
		SpawnMiscData("The investigative journalist loses all credibility.");
		Height -= 150;
		SpawnAishiData("Ryoba kidnaps her Senpai and keeps him prisoner in her basement.");
		Height -= 150;
		SpawnMiscData("Ryoba's Senpai is abducted by Saikou Corp.");
		Height -= 150;
		SpawnMiscData("?????");
		SpawnAishiData("?????");
		SpawnSaikouData("?????");
		Height -= 100;
		SpawnAishiData("Ryoba marries her Senpai.");
		Height -= 100;
		SpawnYear(1990);
		SpawnSaikouData("Ichiko Saikou mysteriously disappears.");
		Height -= 150;
		SpawnYear(1994);
		SpawnAishiData("Ryoba's sister finds her Senpai.");
		SpawnSaikouData("Saikou Corp begins manufacturing video game consoles.");
		Height -= 150;
		SpawnAishiData("Ryoba's sister eliminates every girl who seeks to enter a relationship with her Senpai.");
		Height -= 200;
		SpawnAishiData("Ryoba's sister marries her Senpai.");
		Height -= 100;
		SpawnYear(1999);
		SpawnMiscData("Kocho Shuyona observes Ryoba entering the office of Saisho Saikou.");
		SpawnSaikouData("Ichirou Saikou enrolls in Akademi.");
		Height -= 150;
		SpawnYear(2001);
		SpawnSaikouData("Ichirou Saikou graduates from Akademi.");
		Height -= 150;
		SpawnYear(2007);
		SpawnMiscData("A woman falls in love with the investigative journalist who accused Ryoba of murder.");
		Height -= 200;
		SpawnMiscData("Taro Yamada is born.");
		Height -= 100;
		SpawnYear(2008);
		SpawnSaikouData("Ichirou Saikou's daughter is born. She is named Megami.");
		SpawnMiscData("The investigative journalist's daughter is born.");
		SpawnAishiData("Ryoba gives birth to a daughter. She is named Ayano.");
		Height -= 150;
		SpawnAishiData("Ryoba's sister gives birth to a daughter.");
		Height -= 150;
		SpawnYear(2010);
		SpawnSaikouData("Ichirou Saikou's son is born. He is named Kencho.");
		Height -= 150;
		SpawnYear(2023);
		SpawnSaikouData("Saisho Saikou steps down as CEO of Saikou Corp and appoints his son Ichirou as the new CEO.");
		Height -= 200;
		SpawnYear(2024);
		SpawnMiscData("An urban legend is born about a mysterious hacker and information broker named ''Info-chan.''");
		Height -= 200;
		SpawnYear(2025);
		SpawnAishiData("Ayano Aishi enrolls in Akademi.");
		Height -= 100;
		SpawnYear(2026);
		Long = true;
		Height -= 100;
		SpawnMiscData("The Saikou family announces to the world that Saisho Saikou has passed away at the age of 98.");
		Height -= 150;
		Hide = true;
		SpawnMiscData("Ayano Aishi finds her Senpai.");
	}

	private void Update()
	{
		if (base.transform.localPosition.y > 10f)
		{
			Speed = Mathf.MoveTowards(Speed, 0f, Time.deltaTime * 0.01f);
			Ambience.volume = Mathf.MoveTowards(Ambience.volume, 0f, Time.deltaTime * 0.1f);
			if (Speed == 0f)
			{
				Timer += Time.deltaTime;
				if (Timer > 6f)
				{
					Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.2f);
					if (Darkness.alpha == 1f)
					{
						OptionGlobals.Fog = false;
						GameGlobals.TrueEnding = false;
						SceneManager.LoadScene("NewTitleScene");
					}
				}
				else if (Timer > 1f)
				{
					if (FinalLabel.alpha == 0f)
					{
						MyAudio.Play();
					}
					FinalLabel.alpha = Mathf.MoveTowards(FinalLabel.alpha, 1f, Time.deltaTime);
				}
			}
		}
		else
		{
			if (base.transform.localPosition.y > 9.5f && base.transform.localPosition.y < 10f)
			{
				Speed = Mathf.Lerp(Speed, 0.05f, Time.deltaTime * 10f);
			}
			else if (base.transform.localPosition.y < 9.5f)
			{
				if (Input.GetKey("down") || Input.GetKey("s") || InputManager.DPadDown || InputManager.StickDown)
				{
					Speed += Time.deltaTime;
				}
				else if (Input.GetKey("up") || Input.GetKey("w") || InputManager.DPadUp || InputManager.StickUp)
				{
					Speed -= Time.deltaTime;
				}
			}
			Ambience.volume = Mathf.MoveTowards(Ambience.volume, 0.5f, Time.deltaTime);
		}
		base.transform.localPosition += new Vector3(0f, Speed * Time.deltaTime, 0f);
		if (base.transform.localPosition.y < MaxHeight)
		{
			base.transform.localPosition = new Vector3(0f, MaxHeight, 1f);
			Speed = 0f;
		}
		else if (base.transform.localPosition.y < 0.5f)
		{
			MaxHeight = base.transform.localPosition.y;
		}
	}

	private void SpawnYear(int Year)
	{
		GameObject obj = Object.Instantiate(YearObject);
		obj.transform.parent = base.transform;
		obj.transform.localPosition = new Vector3(0f, Height, 0f);
		obj.transform.localScale = new Vector3(1f, 1f, 1f);
		obj.GetComponent<UILabel>().text = Year.ToString() ?? "";
		Height -= 50;
	}

	private void SpawnAishiData(string Data)
	{
		GameObject obj = Object.Instantiate(TextObject);
		obj.transform.parent = base.transform;
		obj.transform.localPosition = new Vector3(-600f, Height, 0f);
		obj.transform.localScale = new Vector3(1f, 1f, 1f);
		obj.GetComponent<UILabel>().text = Data ?? "";
	}

	private void SpawnSaikouData(string Data)
	{
		GameObject obj = Object.Instantiate(TextObject);
		obj.transform.parent = base.transform;
		obj.transform.localPosition = new Vector3(600f, Height, 0f);
		obj.transform.localScale = new Vector3(1f, 1f, 1f);
		obj.GetComponent<UILabel>().text = Data ?? "";
	}

	private void SpawnMiscData(string Data)
	{
		GameObject gameObject = (Long ? Object.Instantiate(LongTextObject) : Object.Instantiate(TextObject));
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(0f, Height, 0f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = Data ?? "";
		if (Hide)
		{
			FinalLabel = gameObject.GetComponent<UILabel>();
			FinalLabel.color = new Color(1f, 0f, 0f, 0f);
			Darkness.transform.position = FinalLabel.transform.position;
		}
	}
}
