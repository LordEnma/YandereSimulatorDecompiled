using UnityEngine;
using XInputDotNetPure;

public class HeartbrokenScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public HeartbrokenCursorScript Cursor;

	public CounselorScript Counselor;

	public YandereScript Yandere;

	public ClockScript Clock;

	public RadioScript Radio;

	public AudioListener Listener;

	public AudioClip[] NoticedClips;

	public string[] NoticedLines;

	public UILabel[] Letters;

	public UILabel[] Options;

	public Vector3[] Origins;

	public UISprite Background;

	public UISprite Ground;

	public Camera ConfessionUICamera;

	public Camera MainCamera;

	public UILabel Subtitle;

	public GameObject Failed;

	public GameObject SNAP;

	public AudioClip EightiesGameOver;

	public AudioClip Slam;

	public bool ChallengeFailed;

	public bool Headmaster;

	public bool Confessed;

	public bool Arrested;

	public bool Exposed;

	public bool Noticed = true;

	public bool Freeze;

	public bool NoSnap;

	public bool Caught;

	public bool Dead;

	public float VibrationTimer;

	public float AudioTimer;

	public float Timer;

	public int Phase = 1;

	public int Week;

	public int LetterID;

	public int ShakeID;

	public int GrowID;

	public int StopID;

	public int ID;

	public float[] TargetAlpha;

	public Font Arial;

	private void Start()
	{
		if (Yandere != null)
		{
			Yandere.CameraEffects.UpdateDOF(1.5f);
		}
		Week = DateGlobals.Week;
		if (GameGlobals.MostRecentSlot == 0)
		{
			TargetAlpha[2] = 0.5f;
		}
		if (!Caught && !Noticed && Yandere.Bloodiness > 0f && !Yandere.RedPaint && !Yandere.Unmasked)
		{
			Arrested = true;
		}
		if (Dead)
		{
			Letters[0].text = "";
			Letters[1].text = "D";
			Letters[2].text = "E";
			Letters[3].text = "C";
			Letters[4].text = "E";
			Letters[5].text = "A";
			Letters[6].text = "S";
			Letters[7].text = "E";
			Letters[8].text = "D";
			Letters[9].text = "";
			Letters[10].text = "";
			UILabel[] letters = Letters;
			foreach (UILabel uILabel in letters)
			{
				uILabel.transform.localPosition = new Vector3(uILabel.transform.localPosition.x + 100f, uILabel.transform.localPosition.y, uILabel.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 10;
			SNAP.SetActive(value: false);
			Cursor.Options = 4;
			NoSnap = true;
		}
		else if (ChallengeFailed)
		{
			Letters[0].text = "";
			Letters[1].text = "C";
			Letters[2].text = "H";
			Letters[3].text = "A";
			Letters[4].text = "L";
			Letters[5].text = "L";
			Letters[6].text = "E";
			Letters[7].text = "N";
			Letters[8].text = "G";
			Letters[9].text = "E";
			Letters[10].text = "";
			UILabel[] letters = Letters;
			foreach (UILabel uILabel2 in letters)
			{
				uILabel2.transform.localPosition = new Vector3(uILabel2.transform.localPosition.x + 25f, uILabel2.transform.localPosition.y, uILabel2.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 10;
			SNAP.SetActive(value: false);
			Cursor.Options = 4;
			NoSnap = true;
		}
		else if (Caught)
		{
			Letters[0].text = "";
			Letters[1].text = "";
			Letters[2].text = "C";
			Letters[3].text = "A";
			Letters[4].text = "U";
			Letters[5].text = "G";
			Letters[6].text = "H";
			Letters[7].text = "T";
			Letters[8].text = "";
			Letters[9].text = "";
			Letters[10].text = "";
			UILabel[] letters = Letters;
			foreach (UILabel uILabel3 in letters)
			{
				uILabel3.transform.localPosition = new Vector3(uILabel3.transform.localPosition.x + 125f, uILabel3.transform.localPosition.y, uILabel3.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 8;
			NoSnap = true;
			SNAP.SetActive(value: false);
			Cursor.Options = 3;
		}
		else if (Confessed)
		{
			Letters[0].text = "S";
			Letters[1].text = "E";
			Letters[2].text = "N";
			Letters[3].text = "P";
			Letters[4].text = "A";
			Letters[5].text = "I";
			Letters[6].text = string.Empty;
			Letters[7].text = "L";
			Letters[8].text = "O";
			Letters[9].text = "S";
			Letters[10].text = "T";
			LetterID = 0;
			StopID = 11;
			NoSnap = true;
		}
		else if (Yandere.Attacked)
		{
			if (!Headmaster)
			{
				Letters[0].text = string.Empty;
				Letters[1].text = "C";
				Letters[2].text = "O";
				Letters[3].text = "M";
				Letters[4].text = "A";
				Letters[5].text = "T";
				Letters[6].text = "O";
				Letters[7].text = "S";
				Letters[8].text = "E";
				Letters[9].text = string.Empty;
				Letters[10].text = string.Empty;
				Letters[3].fontSize = 250;
				LetterID = 1;
				StopID = 9;
			}
			else
			{
				Letters[0].text = "?";
				Letters[1].text = "?";
				Letters[2].text = "?";
				Letters[3].text = "?";
				Letters[4].text = "?";
				Letters[5].text = "?";
				Letters[6].text = "?";
				Letters[7].text = "?";
				Letters[8].text = "?";
				Letters[9].text = "?";
				Letters[10].text = string.Empty;
				LetterID = 0;
				StopID = 10;
			}
			UILabel[] letters = Letters;
			foreach (UILabel uILabel4 in letters)
			{
				uILabel4.transform.localPosition = new Vector3(uILabel4.transform.localPosition.x + 100f, uILabel4.transform.localPosition.y, uILabel4.transform.localPosition.z);
			}
			SNAP.SetActive(value: false);
			Cursor.Options = 4;
			NoSnap = true;
		}
		else if (Yandere.Lost || ShoulderCamera.LookDown || ShoulderCamera.Counter || ShoulderCamera.ObstacleCounter)
		{
			Letters[0].text = "A";
			Letters[1].text = "P";
			Letters[2].text = "P";
			Letters[3].text = "R";
			Letters[4].text = "E";
			Letters[5].text = "H";
			Letters[6].text = "E";
			Letters[7].text = "N";
			Letters[8].text = "D";
			Letters[9].text = "E";
			Letters[10].text = "D";
			LetterID = 0;
			StopID = 11;
			NoSnap = true;
		}
		else if (Exposed)
		{
			Letters[0].text = string.Empty;
			Letters[1].text = string.Empty;
			Letters[2].text = "E";
			Letters[3].text = "X";
			Letters[4].text = "P";
			Letters[5].text = "O";
			Letters[6].text = "S";
			Letters[7].text = "E";
			Letters[8].text = "D";
			Letters[9].text = string.Empty;
			Letters[10].text = string.Empty;
			UILabel[] letters = Letters;
			foreach (UILabel uILabel5 in letters)
			{
				uILabel5.transform.localPosition = new Vector3(uILabel5.transform.localPosition.x + 100f, uILabel5.transform.localPosition.y, uILabel5.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 9;
			NoSnap = true;
		}
		else if (Arrested || (Yandere.Sprayed && Yandere.Bloodiness > 0f && !Yandere.RedPaint) || Yandere.SprayedByJournalist)
		{
			Letters[0].text = string.Empty;
			Letters[1].text = "A";
			Letters[2].text = "R";
			Letters[3].text = "R";
			Letters[4].text = "E";
			Letters[5].text = "S";
			Letters[6].text = "T";
			Letters[7].text = "E";
			Letters[8].text = "D";
			Letters[9].text = string.Empty;
			Letters[10].text = string.Empty;
			UILabel[] letters = Letters;
			foreach (UILabel uILabel6 in letters)
			{
				uILabel6.transform.localPosition = new Vector3(uILabel6.transform.localPosition.x + 100f, uILabel6.transform.localPosition.y, uILabel6.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 9;
			NoSnap = true;
		}
		else if (Counselor.Expelled || Yandere.Sprayed)
		{
			Letters[0].text = string.Empty;
			Letters[1].text = "E";
			Letters[2].text = "X";
			Letters[3].text = "P";
			Letters[4].text = "E";
			Letters[5].text = "L";
			Letters[6].text = "L";
			Letters[7].text = "E";
			Letters[8].text = "D";
			Letters[9].text = string.Empty;
			Letters[10].text = string.Empty;
			UILabel[] letters = Letters;
			foreach (UILabel uILabel7 in letters)
			{
				uILabel7.transform.localPosition = new Vector3(uILabel7.transform.localPosition.x + 100f, uILabel7.transform.localPosition.y, uILabel7.transform.localPosition.z);
			}
			LetterID = 1;
			StopID = 9;
			NoSnap = true;
		}
		else
		{
			LetterID = 0;
			StopID = 11;
		}
		if (Yandere != null && Yandere.Egg)
		{
			NoSnap = true;
		}
		for (ID = 0; ID < Letters.Length; ID++)
		{
			UILabel uILabel8 = Letters[ID];
			uILabel8.transform.localScale = new Vector3(10f, 10f, 1f);
			uILabel8.color = new Color(uILabel8.color.r, uILabel8.color.g, uILabel8.color.b, 0f);
			Origins[ID] = uILabel8.transform.localPosition;
		}
		for (ID = 0; ID < Options.Length; ID++)
		{
			UILabel uILabel9 = Options[ID];
			uILabel9.color = new Color(uILabel9.color.r, uILabel9.color.g, uILabel9.color.b, 0f);
		}
		ID = 0;
		Subtitle.alpha = 0f;
		if (Noticed)
		{
			Background.color = new Color(Background.color.r, Background.color.g, Background.color.b, 0f);
			Ground.color = new Color(Ground.color.r, Ground.color.g, Ground.color.b, 0f);
		}
		else
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, 100f, base.transform.parent.transform.position.z);
		}
		if (Cursor.SnappedYandere != null)
		{
			int num = 0;
			WeaponScript[] weapons = Cursor.SnappedYandere.Weapons;
			for (int i = 0; i < weapons.Length; i++)
			{
				if (weapons[i] != null)
				{
					num++;
				}
			}
			if (num == 0 || NoSnap || Yandere.Police.GameOver || Yandere.StudentManager.Clock.HourTime >= 18f || Yandere.transform.position.y < -1f)
			{
				SNAP.SetActive(value: false);
				Cursor.Options = 4;
			}
			Clock.StopTime = true;
		}
		if (GameGlobals.Eighties)
		{
			base.gameObject.GetComponent<AudioSource>().clip = EightiesGameOver;
			if (Arial != null)
			{
				Subtitle.trueTypeFont = Arial;
				Subtitle.applyGradient = false;
				Subtitle.color = new Color(1f, 1f, 0f, 1f);
				Subtitle.fontStyle = FontStyle.Bold;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			base.gameObject.GetComponent<AudioSource>().Stop();
		}
		VibrationTimer = Mathf.MoveTowards(VibrationTimer, 0f, Time.deltaTime);
		if (VibrationTimer == 0f)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
		}
		if (Noticed)
		{
			Ground.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			Ground.transform.position = new Vector3(Ground.transform.position.x, Yandere.transform.position.y, Ground.transform.position.z);
		}
		Timer += Time.deltaTime;
		if (Timer > 3f)
		{
			if (Phase == 1)
			{
				if (Noticed)
				{
					UpdateSubtitle();
				}
				Phase += ((Subtitle.color.a > 0f) ? 1 : 2);
			}
			else if (Phase == 2)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					AudioTimer = 100f;
				}
				AudioTimer += Time.deltaTime;
				if (AudioTimer > Subtitle.GetComponent<AudioSource>().clip.length)
				{
					Phase++;
				}
			}
		}
		else if (Yandere != null && Yandere.Unmasked)
		{
			Yandere.ShoulderCamera.transform.position = Vector3.Lerp(Yandere.ShoulderCamera.transform.position, Yandere.ShoulderCamera.NoticedPOV.position, Time.deltaTime * 1f);
			Yandere.ShoulderCamera.transform.LookAt(Yandere.ShoulderCamera.NoticedFocus);
			if (Vector3.Distance(Yandere.transform.position, Yandere.Senpai.position) < 1.25f)
			{
				Yandere.MyController.Move(Yandere.transform.forward * (Time.deltaTime * -1f));
			}
		}
		if (Yandere != null && Yandere.CharacterAnimation["f02_heartBrokenFall_00"].time >= Yandere.CharacterAnimation["f02_heartBrokenFall_00"].length)
		{
			Debug.Log("Supposed to be switching to the heartbroken loop now.");
			Yandere.CharacterAnimation["f02_heartBrokenLoop_00"].speed = 0.1f;
			Yandere.CharacterAnimation.CrossFade("f02_heartBrokenLoop_00");
		}
		if (Background.color.a < 1f)
		{
			Background.color = new Color(Background.color.r, Background.color.g, Background.color.b, Background.color.a + Time.deltaTime);
			Ground.color = new Color(Ground.color.r, Ground.color.g, Ground.color.b, Ground.color.a + Time.deltaTime);
			if (Background.color.a >= 1f)
			{
				ConfessionUICamera.enabled = false;
				MainCamera.enabled = false;
			}
		}
		AudioSource component = GetComponent<AudioSource>();
		if (LetterID < StopID)
		{
			UILabel uILabel = Letters[LetterID];
			uILabel.transform.localScale = Vector3.MoveTowards(uILabel.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 100f);
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, uILabel.color.a + Time.deltaTime * 10f);
			if (uILabel.transform.localScale == new Vector3(1f, 1f, 1f))
			{
				component.PlayOneShot(Slam);
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				VibrationTimer = 0.1f;
				LetterID++;
				if (LetterID == StopID)
				{
					if (ChallengeFailed)
					{
						Failed.SetActive(value: true);
					}
					ID = 0;
				}
			}
			if (Radio != null)
			{
				Radio.MyAudio.volume -= Time.deltaTime;
			}
		}
		else if (Phase == 3)
		{
			if (Options[0].color.a == 0f)
			{
				Subtitle.alpha = 0f;
				if ((bool)Yandere)
				{
					Yandere.Subtitle.transform.localPosition = new Vector3(0f, 1000f, 0f);
				}
				component.Play();
			}
			if (ID < Options.Length)
			{
				UILabel uILabel2 = Options[ID];
				uILabel2.alpha += Time.deltaTime * 5f;
				if (uILabel2.color.a >= TargetAlpha[ID])
				{
					uILabel2.alpha = TargetAlpha[ID];
					ID++;
				}
			}
		}
		if (!Freeze)
		{
			for (ShakeID = 0; ShakeID < Letters.Length; ShakeID++)
			{
				UILabel uILabel3 = Letters[ShakeID];
				Vector3 vector = Origins[ShakeID];
				uILabel3.transform.localPosition = new Vector3(vector.x + Random.Range(-5f, 5f), vector.y + Random.Range(-5f, 5f), uILabel3.transform.localPosition.z);
			}
		}
		for (GrowID = 0; GrowID < 5; GrowID++)
		{
			UILabel uILabel4 = Options[GrowID];
			uILabel4.transform.localScale = Vector3.Lerp(uILabel4.transform.localScale, (Cursor.Selected - 1 != GrowID) ? new Vector3(0.5f, 0.5f, 0.5f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
	}

	private void UpdateSubtitle()
	{
		StudentScript component = Yandere.Senpai.GetComponent<StudentScript>();
		if (component != null && !component.Teacher && Yandere.Noticed)
		{
			Subtitle.alpha = 1f;
			GameOverType gameOverCause = component.GameOverCause;
			int num = 0;
			switch (gameOverCause)
			{
			case GameOverType.Stalking:
				num = 4;
				break;
			case GameOverType.Insanity:
				num = 3;
				break;
			case GameOverType.Weapon:
				num = 1;
				break;
			case GameOverType.Murder:
				num = 5;
				break;
			case GameOverType.Blood:
				num = 2;
				break;
			case GameOverType.Lewd:
				num = 6;
				break;
			}
			Subtitle.text = NoticedLines[num];
			Subtitle.GetComponent<AudioSource>().clip = NoticedClips[num];
			Subtitle.GetComponent<AudioSource>().Play();
		}
		else if (Headmaster)
		{
			Subtitle.alpha = 1f;
			if (!Yandere.StudentManager.Eighties)
			{
				Subtitle.text = NoticedLines[8];
				Subtitle.GetComponent<AudioSource>().clip = NoticedClips[8];
			}
			else
			{
				Subtitle.text = NoticedLines[9];
				Subtitle.GetComponent<AudioSource>().clip = NoticedClips[9];
			}
			Subtitle.GetComponent<AudioSource>().Play();
		}
	}

	public void Darken()
	{
		for (int i = 0; i < Letters.Length; i++)
		{
			if (Letters[i].color.a > 1f)
			{
				Letters[i].color = new Color(1f, 0f, 0f, 1f);
			}
			Letters[i].color = new Color(1f, 0f, 0f, Letters[i].color.a - 1f / 17f);
		}
		for (int i = 0; i < 4; i++)
		{
			if (Options[i].color.a > 1f)
			{
				Options[i].color = new Color(Options[i].color.r, Options[i].color.g, Options[i].color.b, 1f);
			}
			Options[i].color = new Color(Options[i].color.r, Options[i].color.g, Options[i].color.b, Options[i].color.a - 1f / 17f);
		}
	}
}
