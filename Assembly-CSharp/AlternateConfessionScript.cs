using UnityEngine;
using UnityEngine.SceneManagement;

public class AlternateConfessionScript : MonoBehaviour
{
	public StudentScript FemaleSenpaiScript;

	public YandereScript TheYandereScript;

	public StudentScript TheSenpaiScript;

	public JsonScript JSON;

	public Transform ConfessionCamera;

	public Transform SenpaiNeck;

	public Transform AcceptedPOV;

	public Transform OriginalPOV;

	public Transform YanderePOV;

	public Transform SenpaiPOV;

	public Transform IntroPOV;

	public UILabel[] ConfessLabels;

	public float[] ConfessTimes;

	public UILabel[] SenpaiLabels;

	public float[] SenpaiTimes;

	public UILabel[] OutcomeLabels;

	public float[] OutcomeTimes;

	public UISprite SkipButton;

	public UILabel ContinueLabel;

	public UISprite Darkness;

	public Renderer Tears;

	public AudioSource Jukebox;

	public Animation Yandere;

	public Animation Senpai;

	public Light Sun;

	public float RotateSpeed;

	public float TearSpeed;

	public float TearTimer;

	public float Timer;

	public bool ReverseTears;

	public bool MindBroken;

	public bool SlowFade;

	public bool FadeOut;

	public bool Reject;

	public int LovePoints;

	public int TearPhase;

	public int Phase;

	public string[] RivalEliminations;

	public string[] SenpaiFeelings;

	public string[] RivalNames;

	public int[] TimesEliminationMethodsUsed;

	public Animation FemaleSenpaiAnimation;

	public GameObject FemaleSenpai;

	public GameObject MaleSenpai;

	public bool Female;

	public Transform RightHair;

	public Transform LeftHair;

	public Transform Ponytail;

	public float Rotation;

	public float Weight;

	public float X;

	public float Y;

	public float Z;

	public float X2;

	public float Y2;

	public float Z2;

	private void Start()
	{
		if (GameGlobals.CustomMode && GameGlobals.FemaleSenpai)
		{
			FemaleSenpaiScript.Ragdoll.DestroyRigidbodies();
			TheSenpaiScript = FemaleSenpaiScript;
			Senpai = FemaleSenpaiAnimation;
			Senpai.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
			ConfessLabels[3].text = "...and confesses her feelings to her.";
			ConfessLabels[4].text = "She describes how she makes her feel...";
			ConfessLabels[5].text = "...and how she can't live without her.";
			ConfessLabels[7].text = "...she waits eagerly for her response.";
			FemaleSenpai.SetActive(value: true);
			MaleSenpai.SetActive(value: false);
			Female = true;
		}
		else
		{
			FemaleSenpai.SetActive(value: false);
			MaleSenpai.SetActive(value: true);
		}
		TheSenpaiScript.DisableProps();
		TheYandereScript.SetUniform();
		if (GameGlobals.CustomMode)
		{
			TheYandereScript.Customize();
		}
		else
		{
			TheYandereScript.BecomeRyoba();
			TheYandereScript.ClearBlendShapes();
			TheYandereScript.BreastSize = 1.5f;
			TheYandereScript.UpdateBust();
			TheYandereScript.UpdateEyeColor();
			TheYandereScript.Stockings = "ShortBlack";
			TheYandereScript.UpdateStockings();
		}
		Tears.materials[0].SetFloat("_TearReveal", 0f);
		Tears.materials[1].SetFloat("_TearReveal", 0f);
		Darkness.color = new Color(0f, 0f, 0f, 1f);
		Senpai["SenpaiConfession"].speed = 0f;
		Yandere["OsanaConfession"].speed = 0f;
		Senpai.Play("SenpaiConfession");
		Yandere.Play("OsanaConfession");
		SkipButton.alpha = 0f;
		Time.timeScale = 1f;
		ConfessLabels[1].transform.parent.gameObject.SetActive(value: true);
		for (int i = 1; i < ConfessLabels.Length; i++)
		{
			ConfessLabels[i].alpha = 0f;
		}
		SenpaiLabels[1].transform.parent.gameObject.SetActive(value: true);
		for (int i = 1; i < SenpaiLabels.Length; i++)
		{
			SenpaiLabels[i].alpha = 0f;
		}
		OutcomeLabels[1].transform.parent.gameObject.SetActive(value: true);
		for (int i = 1; i < OutcomeLabels.Length; i++)
		{
			OutcomeLabels[i].alpha = 0f;
		}
		for (int j = 1; j < 11; j++)
		{
			RivalNames[j] = JSON.Students[j + 10].Name;
		}
		string text = RivalNames[1] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(1)];
		string text2 = RivalNames[2] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(2)];
		string text3 = RivalNames[3] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(3)];
		string text4 = RivalNames[4] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(4)];
		string text5 = RivalNames[5] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(5)];
		string text6 = RivalNames[6] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(6)];
		string text7 = RivalNames[7] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(7)];
		string text8 = RivalNames[8] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(8)];
		string text9 = RivalNames[9] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(9)];
		string text10 = RivalNames[10] + " " + RivalEliminations[GameGlobals.GetRivalEliminations(10)];
		if (GameGlobals.AlternateTimeline)
		{
			text10 = "";
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		for (int i = 1; i < 11; i++)
		{
			if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 2 || GameGlobals.GetRivalEliminations(i) == 12 || GameGlobals.GetRivalEliminations(i) == 13 || GameGlobals.GetRivalEliminations(i) == 14)
			{
				num++;
				LovePoints -= 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 3)
			{
				num2++;
				LovePoints -= 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 4)
			{
				num3++;
				LovePoints += 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 5)
			{
				num4++;
				LovePoints -= 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 6)
			{
				num5++;
				LovePoints += 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 7)
			{
				num6++;
				LovePoints += 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 8)
			{
				num7++;
				LovePoints += 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 9 || GameGlobals.GetRivalEliminations(i) == 10)
			{
				num8++;
				LovePoints -= 10;
			}
			else if (GameGlobals.GetRivalEliminations(i) == 11)
			{
				num9++;
				LovePoints -= 10;
			}
			Debug.Log("Rival " + i + "'s Elimination ID is: " + GameGlobals.GetRivalEliminations(i));
		}
		TimesEliminationMethodsUsed[1] = num;
		TimesEliminationMethodsUsed[2] = num2;
		TimesEliminationMethodsUsed[3] = num3;
		TimesEliminationMethodsUsed[4] = num4;
		TimesEliminationMethodsUsed[5] = num5;
		TimesEliminationMethodsUsed[6] = num6;
		TimesEliminationMethodsUsed[7] = num7;
		TimesEliminationMethodsUsed[8] = num8;
		TimesEliminationMethodsUsed[9] = num9;
		int num10 = TimesEliminationMethodsUsed[0];
		int num11 = 0;
		for (int k = 1; k < TimesEliminationMethodsUsed.Length; k++)
		{
			if (TimesEliminationMethodsUsed[k] > num10)
			{
				num10 = TimesEliminationMethodsUsed[k];
				num11 = k;
			}
		}
		Debug.Log("The most common elimination method was: " + num11);
		string text11 = SenpaiFeelings[num11];
		SenpaiLabels[2].text = text + "\n\n" + text2 + "\n\n" + text3 + "\n\n" + text4 + "\n\n" + text5 + "\n\n" + text6 + "\n\n" + text7 + "\n\n" + text8 + "\n\n" + text9 + "\n\n" + text10 + "\n\n" + text11;
		if (GameGlobals.SenpaiLove == 100)
		{
			text = (Female ? "She has been fantasizing about the day when she would finally meet her anonymous secret admirer." : "He has been fantasizing about the day when he would finally meet his anonymous secret admirer.");
		}
		else if (GameGlobals.SenpaiLove > 75)
		{
			text = (Female ? "The anonymous love letters and gifts that she left on her desk made a very strong impression on her." : "The anonymous love letters and gifts that she left on his desk made a very strong impression on him.");
		}
		else if (GameGlobals.SenpaiLove > 50)
		{
			text = (Female ? "She felt very flattered by the anonymous love letters and gifts that she left on her desk." : "He felt very flattered by the anonymous love letters and gifts that she left on his desk.");
		}
		else if (GameGlobals.SenpaiLove > 25)
		{
			text = (Female ? "She was pleasantly surprised by the anonymous love letters and gifts that she left on her desk." : "He was pleasantly surprised by the anonymous love letters and gifts that she left on his desk.");
		}
		else if (GameGlobals.SenpaiLove > 0)
		{
			text = (Female ? "She vaguely remembers finding anonymous love letters and gifts on her desk, or something like that." : "He vaguely remembers finding anonymous love letters and gifts on his desk, or something like that.");
		}
		else if (GameGlobals.SenpaiLove == 0)
		{
			text = (Female ? "She never attempted to build a relationship with her by leaving notes or gifts on her desk." : "She never attempted to build a relationship with him by leaving notes or gifts on his desk.");
		}
		if (!Female)
		{
			if (PlayerGlobals.Reputation == 100f)
			{
				text2 = "He knows that she is loved by everyone at school.";
			}
			else if (PlayerGlobals.Reputation > 50f)
			{
				text2 = "He knows that she has a very good reputation at school.";
			}
			else if (PlayerGlobals.Reputation > 0f)
			{
				text2 = "He knows that she has a positive reputation at school.";
			}
			else if (PlayerGlobals.Reputation == 0f)
			{
				text2 = "He doesn't know anything about her. At school, she is a complete ghost.";
			}
			else if (PlayerGlobals.Reputation < -50f)
			{
				text2 = "He has heard a lot of very nasty rumors about her around school.";
			}
			else if (PlayerGlobals.Reputation < 0f)
			{
				text2 = "He has heard some negative things about her around school.";
			}
		}
		else if (PlayerGlobals.Reputation == 100f)
		{
			text2 = "She knows that she is loved by everyone at school.";
		}
		else if (PlayerGlobals.Reputation > 50f)
		{
			text2 = "She knows that she has a very good reputation at school.";
		}
		else if (PlayerGlobals.Reputation > 0f)
		{
			text2 = "She knows that she has a positive reputation at school.";
		}
		else if (PlayerGlobals.Reputation == 0f)
		{
			text2 = "She doesn't know anything about her. At school, she is a complete ghost.";
		}
		else if (PlayerGlobals.Reputation < -50f)
		{
			text2 = "She has heard a lot of very nasty rumors about her around school.";
		}
		else if (PlayerGlobals.Reputation < 0f)
		{
			text2 = "She has heard some negative things about her around school.";
		}
		if (!Female)
		{
			if (GameGlobals.SenpaiSanity <= -100)
			{
				text3 = "He has experienced severe emotional trauma that has turned him into a mind-broken empty husk; a shell of the man that he once was.";
				MindBroken = true;
			}
			else if (GameGlobals.SenpaiSanity < -75)
			{
				text3 = "He has experienced significant emotional trauma that almost prevents him from being able to focus on having a romantic relationship.";
			}
			else if (GameGlobals.SenpaiSanity < -50)
			{
				text3 = "He has experienced emotional trauma that may interfere with his ability to focus on having a romantic relationship.";
			}
			else if (GameGlobals.SenpaiSanity < -25)
			{
				text3 = "He has experienced slight emotional trauma, but nothing that would prevent him from able to focus on having a romantic relationship.";
			}
			else if (GameGlobals.SenpaiSanity == 0)
			{
				text3 = "He has not experienced any emotional trauma that would prevent him from being able to focus on having a romantic relationship.";
			}
		}
		else if (GameGlobals.SenpaiSanity <= -100)
		{
			text3 = "She has experienced severe emotional trauma that has turned her into a mind-broken empty husk; a shell of the woman that she once was.";
			MindBroken = true;
		}
		else if (GameGlobals.SenpaiSanity < -75)
		{
			text3 = "She has experienced significant emotional trauma that almost prevents her from being able to focus on having a romantic relationship.";
		}
		else if (GameGlobals.SenpaiSanity < -50)
		{
			text3 = "She has experienced emotional trauma that may interfere with her ability to focus on having a romantic relationship.";
		}
		else if (GameGlobals.SenpaiSanity < -25)
		{
			text3 = "She has experienced slight emotional trauma, but nothing that would prevent her from able to focus on having a romantic relationship.";
		}
		else if (GameGlobals.SenpaiSanity == 0)
		{
			text3 = "She has not experienced any emotional trauma that would prevent her from being able to focus on having a romantic relationship.";
		}
		SenpaiLabels[3].text = text + "\n\n" + text2 + "\n\n" + text3;
		LovePoints += (int)PlayerGlobals.Reputation;
		LovePoints += GameGlobals.SenpaiLove;
		LovePoints -= GameGlobals.SenpaiSanity;
		if (MindBroken)
		{
			if (!GameGlobals.FemaleSenpai)
			{
				text = "He neither accepts, nor declines.";
				text = "He is empty inside. Broken.";
				text2 = "This presents a unique opportunity.";
				text4 = "She decides to ''adopt'' him...";
				text5 = "...and keep him as a pet.";
			}
			else
			{
				text = "She neither accepts, nor declines.";
				text = "She is empty inside. Broken.";
				text2 = "This presents a unique opportunity.";
				text4 = "She decides to ''adopt'' her...";
				text5 = "...and keep her as a pet.";
			}
		}
		else
		{
			text4 = "Her love confession...";
			if (LovePoints <= 0)
			{
				text5 = "...has been rejected.";
				Reject = true;
			}
			else
			{
				text5 = "...has been accepted!";
			}
			if (LovePoints == 0)
			{
				text = "With indifference...";
				if (!GameGlobals.FemaleSenpai)
				{
					text2 = "...he shrugs his shoulders...";
					text3 = "...and says he is not interested.";
				}
				else
				{
					text2 = "...she shrugs her shoulders...";
					text3 = "...and says she is not interested.";
				}
			}
			else if (LovePoints >= 200)
			{
				text = "With great enthusiasm...";
				if (!GameGlobals.FemaleSenpai)
				{
					text2 = "...he smiles warmly...";
					text3 = "...and says he loves her, too!";
				}
				else
				{
					text2 = "...she smiles warmly...";
					text3 = "...and says she loves her, too!";
				}
			}
			else if (LovePoints >= 100)
			{
				if (!GameGlobals.FemaleSenpai)
				{
					text = "With hope in his heart...";
					text2 = "...he smiles bashfully...";
					text3 = "...and says he will date her!";
				}
				else
				{
					text = "With hope in her heart...";
					text2 = "...she smiles bashfully...";
					text3 = "...and says she will date her!";
				}
			}
			else if (LovePoints > 0)
			{
				text = "With an expression that says...";
				text2 = "''Eh, sure, why not?''";
				text3 = (GameGlobals.FemaleSenpai ? "...she says he will give her a chance!" : "...he says he will give her a chance!");
			}
			else if (LovePoints <= 200)
			{
				text = "With a look of irritation...";
				if (!GameGlobals.FemaleSenpai)
				{
					text2 = "...he shakes his head...";
					text3 = "...and says he would never date her.";
				}
				else
				{
					text2 = "...she shakes her head...";
					text3 = "...and says she would never date her.";
				}
			}
			else if (LovePoints <= 100)
			{
				text = "With a pained expression...";
				if (!GameGlobals.FemaleSenpai)
				{
					text2 = "...he shakes his head...";
					text3 = "...and says she's not his type.";
				}
				else
				{
					text2 = "...she shakes her head...";
					text3 = "...and says she's not her type.";
				}
			}
			else if (LovePoints <= 0)
			{
				text = "With a sad expression...";
				if (!GameGlobals.FemaleSenpai)
				{
					text2 = "...he shakes his head...";
					text3 = "...and says he prefers to be single.";
				}
				else
				{
					text2 = "...she shakes her head...";
					text3 = "...and says she prefers to be single.";
				}
			}
		}
		OutcomeLabels[1].text = text;
		OutcomeLabels[2].text = text2;
		OutcomeLabels[3].text = text3;
		OutcomeLabels[4].text = text4;
		OutcomeLabels[5].text = text5;
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Phase == 0)
		{
			if (Timer > 1f)
			{
				Senpai["SenpaiConfession"].speed = 0.9f;
				Yandere["OsanaConfession"].speed = 1f;
				Jukebox.Play();
				FadeOut = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			if (Darkness.color.a == 0f)
			{
				Senpai["SenpaiConfession"].speed = 0.9f;
				Yandere["OsanaConfession"].speed = 1f;
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Timer = 11.5f;
				}
			}
			if (Timer > 5f)
			{
				RotateSpeed += Time.deltaTime * 0.1f;
				ConfessionCamera.eulerAngles = Vector3.Lerp(ConfessionCamera.eulerAngles, IntroPOV.eulerAngles, Time.deltaTime * RotateSpeed);
				ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, IntroPOV.position, Time.deltaTime * RotateSpeed);
			}
			if (Timer > 11.5f)
			{
				SkipButton.alpha = 0f;
				FadeOut = true;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			RotateSpeed += Time.deltaTime * 0.1f;
			ConfessionCamera.eulerAngles = Vector3.Lerp(ConfessionCamera.eulerAngles, IntroPOV.eulerAngles, Time.deltaTime * RotateSpeed);
			ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, IntroPOV.position, Time.deltaTime * RotateSpeed);
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = SenpaiPOV.eulerAngles;
				ConfessionCamera.position = SenpaiPOV.position;
				Sun.transform.eulerAngles = Vector3.zero;
				Yandere["OsanaConfession"].speed = 0.9f;
				Yandere["OsanaConfession"].time = 11f;
				Senpai.gameObject.SetActive(value: false);
				RotateSpeed = 0f;
				FadeOut = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			RotateSpeed += Time.deltaTime * 0.2f;
			ConfessionCamera.eulerAngles = Vector3.Lerp(ConfessionCamera.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * RotateSpeed);
			ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, new Vector3(0f, 7.2f, 97f), Time.deltaTime * RotateSpeed);
			if (Timer < 41f && Darkness.color.a == 0f)
			{
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					SkipButton.alpha = 0f;
					Timer = 41f;
				}
			}
			if (Timer < 40f)
			{
				for (int i = 1; i < ConfessLabels.Length; i++)
				{
					if (Timer > ConfessTimes[i])
					{
						ConfessLabels[i].alpha = Mathf.MoveTowards(ConfessLabels[i].alpha, 1f, Time.deltaTime);
					}
				}
			}
			else
			{
				for (int j = 1; j < ConfessLabels.Length; j++)
				{
					ConfessLabels[j].alpha = Mathf.MoveTowards(ConfessLabels[j].alpha, 0f, Time.deltaTime);
				}
			}
			if (Timer > 42f)
			{
				SkipButton.alpha = 0f;
				FadeOut = true;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			RotateSpeed += Time.deltaTime * 0.2f;
			ConfessionCamera.eulerAngles = Vector3.Lerp(ConfessionCamera.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * RotateSpeed);
			ConfessionCamera.position = Vector3.Lerp(ConfessionCamera.position, new Vector3(0f, 7.2f, 97f), Time.deltaTime * RotateSpeed);
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = YanderePOV.eulerAngles;
				ConfessionCamera.position = YanderePOV.position;
				Senpai.transform.position = new Vector3(0f, 6f, 97.5f);
				Senpai.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Sun.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				Yandere.gameObject.SetActive(value: false);
				Senpai.gameObject.SetActive(value: true);
				if (!Female)
				{
					Senpai.Play("thinking_00");
				}
				else
				{
					Senpai.Play("f02_thinking_00");
				}
				FadeOut = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			for (int k = 1; k < SenpaiLabels.Length; k++)
			{
				if (Timer > SenpaiTimes[k])
				{
					SenpaiLabels[k].alpha = Mathf.MoveTowards(SenpaiLabels[k].alpha, 1f, Time.deltaTime);
				}
			}
			if (Darkness.color.a == 0f)
			{
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (Timer < 5f)
					{
						Timer = 5f;
					}
					else
					{
						SkipButton.alpha = 0f;
						FadeOut = true;
						Timer = 0f;
						Phase++;
					}
				}
			}
		}
		else if (Phase == 6)
		{
			for (int l = 1; l < SenpaiLabels.Length; l++)
			{
				SenpaiLabels[l].alpha = Mathf.MoveTowards(SenpaiLabels[l].alpha, 0f, Time.deltaTime);
			}
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = new Vector3(0f, 0f, 0f);
				ConfessionCamera.position = new Vector3(0f, 7.2f, 97f);
				Yandere.gameObject.SetActive(value: true);
				if (!Reject)
				{
					Yandere["OsanaConfessionAccepted"].time = 1f;
					Yandere.Play("OsanaConfessionAccepted");
					Phase++;
				}
				else
				{
					Yandere["OsanaConfessionRejected"].time = 1f;
					Yandere.Play("OsanaConfessionRejected");
					Phase = 10;
				}
				Sun.transform.eulerAngles = Vector3.zero;
				Senpai.gameObject.SetActive(value: false);
				RotateSpeed = 0f;
				FadeOut = false;
				Timer = 0f;
			}
		}
		else if (Phase == 7)
		{
			if (Timer < 41f && Darkness.color.a == 0f)
			{
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					SkipButton.alpha = 0f;
					Timer = 41f;
				}
			}
			if (Timer < 40f)
			{
				for (int m = 1; m < OutcomeLabels.Length; m++)
				{
					if (Timer > OutcomeTimes[m])
					{
						OutcomeLabels[m].alpha = Mathf.MoveTowards(OutcomeLabels[m].alpha, 1f, Time.deltaTime);
					}
				}
			}
			else
			{
				for (int n = 1; n < OutcomeLabels.Length; n++)
				{
					OutcomeLabels[n].alpha = Mathf.MoveTowards(OutcomeLabels[n].alpha, 0f, Time.deltaTime);
				}
			}
			if (TearPhase == 0)
			{
				if (Timer > 25f)
				{
					ReverseTears = true;
					TearSpeed = 5f;
					TearPhase++;
				}
			}
			else if (TearPhase == 1)
			{
				if ((double)Timer > 32.33333)
				{
					ReverseTears = true;
					TearSpeed = 5f;
					TearPhase++;
				}
			}
			else if (TearPhase == 2)
			{
				if (Timer > 38f)
				{
					ReverseTears = true;
					TearSpeed = 5f;
					TearPhase++;
				}
			}
			else if (TearPhase == 3 && Timer > 39f)
			{
				TearPhase++;
			}
			if (Timer > 9f)
			{
				if (!ReverseTears)
				{
					TearTimer = Mathf.MoveTowards(TearTimer, 1f, Time.deltaTime * TearSpeed);
				}
				else
				{
					TearTimer = Mathf.MoveTowards(TearTimer, 0f, Time.deltaTime * TearSpeed);
					if (TearTimer == 0f)
					{
						ReverseTears = false;
						TearSpeed = 0.2f;
					}
				}
				if (TearPhase < 4)
				{
					Tears.materials[0].SetFloat("_TearReveal", TearTimer);
				}
				Tears.materials[1].SetFloat("_TearReveal", TearTimer);
			}
			if (Timer >= 42f)
			{
				SkipButton.alpha = 0f;
				TearSpeed = 0.1f;
				FadeOut = true;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			for (int num = 1; num < OutcomeLabels.Length; num++)
			{
				OutcomeLabels[num].alpha = 0f;
			}
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = AcceptedPOV.eulerAngles;
				ConfessionCamera.position = AcceptedPOV.position;
				Yandere.transform.position = new Vector3(-0.8f, 6f, 98.5f);
				Yandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				Senpai.transform.position = new Vector3(-0.8f, 6f, 98.5f);
				Senpai.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				Yandere["OsanaConfessionAccepted"].time = 44f;
				Senpai.gameObject.SetActive(value: true);
				if (!Female)
				{
					Senpai.Play("SenpaiConfessionAccepted");
					Senpai["SenpaiConfessionAccepted"].time = Yandere["OsanaConfessionAccepted"].time;
					Senpai.Play("SenpaiConfessionAccepted");
				}
				else
				{
					Senpai.Play("f02_idle_00");
					Senpai.CrossFade("FemaleSenpaiConfessionAccepted");
					Senpai["FemaleSenpaiConfessionAccepted"].time = Yandere["OsanaConfessionAccepted"].time;
					Senpai.CrossFade("FemaleSenpaiConfessionAccepted");
					Senpai["f02_smile_00"].layer = 1;
					Senpai.Play("f02_smile_00");
					Senpai["f02_smile_00"].weight = 1f;
					Senpai.transform.localPosition = new Vector3(0.85f, -0.02f, 0.033333f);
					Senpai.transform.localScale = new Vector3(1f, 1f, 1f);
				}
				FadeOut = false;
				Timer = 0f;
				Phase++;
				if (GameGlobals.AlternateTimeline)
				{
					OutcomeLabels[1].text = "She did it.";
					OutcomeLabels[2].text = "She finally did it.";
					OutcomeLabels[3].text = "She reached her ''Happy Ending.''";
					OutcomeLabels[4].text = "In this one timeline, at least...";
					OutcomeLabels[5].text = "...she can truly be happy.";
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Happy", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				else
				{
					OutcomeLabels[1].text = "She did it.";
					OutcomeLabels[2].text = "She finally did it.";
					OutcomeLabels[3].text = "She won her Senpai's heart.";
					OutcomeLabels[4].text = "This story...";
					OutcomeLabels[5].text = "...has a happy ending";
				}
			}
		}
		else if (Phase == 9)
		{
			if (!Reject)
			{
				ConfessionCamera.position -= new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			}
			else
			{
				ConfessionCamera.position += new Vector3(Time.deltaTime * 0.1f, 0f, 0f);
				if (Timer > 4f)
				{
					Senpai.transform.position -= new Vector3(0f, Time.deltaTime * 0.1f, 0f);
				}
			}
			if (Timer < 15f && Darkness.color.a == 0f)
			{
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					SkipButton.alpha = 0f;
					Timer = 19f;
				}
			}
			if (Timer < 15f)
			{
				for (int num2 = 1; num2 < OutcomeLabels.Length; num2++)
				{
					if (Timer > OutcomeTimes[num2])
					{
						OutcomeLabels[num2].alpha = Mathf.MoveTowards(OutcomeLabels[num2].alpha, 1f, Time.deltaTime);
					}
				}
			}
			else
			{
				for (int num3 = 1; num3 < OutcomeLabels.Length; num3++)
				{
					OutcomeLabels[num3].alpha = Mathf.MoveTowards(OutcomeLabels[num3].alpha, 0f, Time.deltaTime);
				}
			}
			if (Timer > 20f)
			{
				SlowFade = true;
			}
		}
		else if (Phase == 10)
		{
			if (Timer > 2f)
			{
				Jukebox.pitch = Mathf.MoveTowards(Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
			}
			if (Timer < 49f && Darkness.color.a == 0f)
			{
				SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 1f, Time.deltaTime);
				if (SkipButton.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					SkipButton.alpha = 0f;
					Timer = 50f;
				}
			}
			if (Timer < 48f)
			{
				for (int num4 = 1; num4 < OutcomeLabels.Length; num4++)
				{
					if (Timer > OutcomeTimes[num4])
					{
						OutcomeLabels[num4].alpha = Mathf.MoveTowards(OutcomeLabels[num4].alpha, 1f, Time.deltaTime);
					}
				}
			}
			else
			{
				for (int num5 = 1; num5 < OutcomeLabels.Length; num5++)
				{
					OutcomeLabels[num5].alpha = Mathf.MoveTowards(OutcomeLabels[num5].alpha, 0f, Time.deltaTime);
				}
			}
			if (Timer > 40f)
			{
				TearTimer = Mathf.MoveTowards(TearTimer, 1f, Time.deltaTime * TearSpeed);
				Tears.materials[0].SetFloat("_TearReveal", TearTimer);
				Tears.materials[1].SetFloat("_TearReveal", TearTimer);
			}
			if (Timer > 46f)
			{
				RotateSpeed += Time.deltaTime * 0.01f;
				ConfessionCamera.eulerAngles = new Vector3(ConfessionCamera.eulerAngles.x, ConfessionCamera.eulerAngles.y - RotateSpeed * 2f, ConfessionCamera.eulerAngles.z);
				ConfessionCamera.position = new Vector3(ConfessionCamera.position.x, ConfessionCamera.position.y, ConfessionCamera.position.z - RotateSpeed * 0.05f);
			}
			if (Timer > 50f)
			{
				SkipButton.alpha = 0f;
				FadeOut = true;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 11)
		{
			Jukebox.pitch = Mathf.MoveTowards(Jukebox.pitch, 0f, Time.deltaTime * 0.1f);
			RotateSpeed += Time.deltaTime * 0.01f;
			ConfessionCamera.eulerAngles = new Vector3(ConfessionCamera.eulerAngles.x, ConfessionCamera.eulerAngles.y - RotateSpeed * 2f, ConfessionCamera.eulerAngles.z);
			ConfessionCamera.position = new Vector3(ConfessionCamera.position.x, ConfessionCamera.position.y, ConfessionCamera.position.z - RotateSpeed * 0.05f);
			for (int num6 = 1; num6 < OutcomeLabels.Length; num6++)
			{
				OutcomeLabels[num6].alpha = Mathf.MoveTowards(OutcomeLabels[num6].alpha, 0f, Time.deltaTime);
			}
			if (Timer > 2f)
			{
				ConfessionCamera.eulerAngles = OriginalPOV.eulerAngles;
				ConfessionCamera.position = OriginalPOV.position;
				Senpai.gameObject.SetActive(value: true);
				Senpai.transform.position = new Vector3(0f, 6f, 98.5f);
				Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Senpai.Play("SenpaiConfessionRejected");
				Senpai["SenpaiConfessionRejected"].time = 1f;
				Senpai.Play("SenpaiConfessionRejected");
				Yandere.Play("OsanaConfessionRejected");
				Yandere["OsanaConfessionRejected"].speed = 0.5f;
				Yandere["OsanaConfessionRejected"].time = 47f;
				Yandere.Play("OsanaConfessionRejected");
				FadeOut = false;
				Timer = 0f;
				Phase = 9;
				if (GameGlobals.AlternateTimeline)
				{
					OutcomeLabels[1].text = "She failed.";
					OutcomeLabels[2].text = "She was not able to...";
					OutcomeLabels[3].text = "...reach her ''Happy Ending.''";
					OutcomeLabels[4].text = "This timeline is...";
					OutcomeLabels[5].text = "...a dead end.";
				}
				else
				{
					OutcomeLabels[1].text = "She failed.";
					OutcomeLabels[2].text = "She was not able...";
					if (!Female)
					{
						OutcomeLabels[3].text = "...to win his heart.";
					}
					else
					{
						OutcomeLabels[3].text = "...to win her heart.";
					}
					OutcomeLabels[4].text = "This story does not have...";
					OutcomeLabels[5].text = "...a happy ending.";
				}
			}
		}
		if (SlowFade)
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime * 0.1f));
			SkipButton.alpha = Mathf.MoveTowards(SkipButton.alpha, 0f, Time.deltaTime);
			Jukebox.volume = 1f - Darkness.color.a;
			if (!(Darkness.color.a > 0.999f))
			{
				return;
			}
			DateGlobals.Week = 11;
			if (GameGlobals.CustomMode)
			{
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Custom", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
				if (!Reject)
				{
					GameGlobals.EightiesCutsceneID = 12;
					SceneManager.LoadScene("EightiesCutsceneScene");
				}
				else
				{
					GameGlobals.DarkEnding = true;
					SceneManager.LoadScene("CreditsScene");
				}
			}
			else
			{
				GameGlobals.DarkEnding = false;
				SceneManager.LoadScene("CreditsScene");
			}
		}
		else if (FadeOut)
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime * 0.5f));
		}
		else
		{
			Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime * 0.5f));
		}
	}

	private void LateUpdate()
	{
		if (Phase < 9)
		{
			Ponytail.transform.eulerAngles = new Vector3(X, Y, Z);
			Ponytail.transform.GetChild(0).eulerAngles = new Vector3(0f, 180f, 0f);
			RightHair.transform.eulerAngles = new Vector3(X2, Y2, Z2);
			LeftHair.transform.eulerAngles = new Vector3(X2, Y2, Z2);
		}
	}
}
