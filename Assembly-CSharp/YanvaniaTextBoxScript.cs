using UnityEngine;

public class YanvaniaTextBoxScript : MonoBehaviour
{
	private TypewriterEffect NewTypewriter;

	private UILabel NewLabelScript;

	private GameObject NewLabel;

	public YanvaniaJukeboxScript Jukebox;

	public YanvaniaDraculaScript Dracula;

	public YanvaniaYanmontScript Yanmont;

	public Transform NewLabelSpawnPoint;

	public GameObject Glass;

	public GameObject Label;

	public UILabel SpeakerLabel;

	public UITexture BloodWipe;

	public UITexture Portrait;

	public UITexture Border;

	public UITexture BG;

	public bool UpdatePortrait;

	public bool Display;

	public bool Leave;

	public bool Grow;

	public string[] SpeakerNames;

	public Texture[] Portraits;

	public AudioClip[] Voices;

	public string[] Lines;

	public int PortraitID = 1;

	public int LineID;

	public float NewLineTimer;

	public float AnimTimer;

	public float Timer;

	private void Start()
	{
		Portrait.transform.localScale = Vector3.zero;
		BloodWipe.transform.localScale = new Vector3(0f, BloodWipe.transform.localScale.y, BloodWipe.transform.localScale.z);
		SpeakerLabel.text = string.Empty;
		Border.color = new Color(Border.color.r, Border.color.g, Border.color.b, 0f);
		BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 0f);
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (!Leave)
		{
			if (BloodWipe.transform.localScale.x == 0f)
			{
				BloodWipe.transform.localScale = new Vector3(BloodWipe.transform.localScale.x + Time.deltaTime, BloodWipe.transform.localScale.y, BloodWipe.transform.localScale.z);
			}
			if (BloodWipe.transform.localScale.x > 50f)
			{
				BloodWipe.color = new Color(BloodWipe.color.r, BloodWipe.color.g, BloodWipe.color.b, BloodWipe.color.a - Time.deltaTime);
				Border.color = new Color(Border.color.r, Border.color.g, Border.color.b, Border.color.a + Time.deltaTime);
				BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 0.5f);
			}
			else
			{
				BloodWipe.transform.localScale = new Vector3(BloodWipe.transform.localScale.x + BloodWipe.transform.localScale.x * 0.1f, BloodWipe.transform.localScale.y, BloodWipe.transform.localScale.z);
			}
			if (BloodWipe.color.a <= 0f)
			{
				if (!Display)
				{
					if (LineID < Lines.Length - 1)
					{
						if (NewLabel != null)
						{
							Object.Destroy(NewLabel);
						}
						UpdatePortrait = true;
						Display = true;
						PortraitID = ((PortraitID != 1) ? 1 : 2);
						SpeakerLabel.text = string.Empty;
					}
				}
				else if (NewLabelScript != null)
				{
					AudioSource component = GetComponent<AudioSource>();
					if (!NewLabelScript.enabled)
					{
						NewLabelScript.enabled = true;
						component.clip = Voices[LineID];
						NewLineTimer = 0f;
						component.Play();
					}
					else
					{
						NewLineTimer += Time.deltaTime;
						if (NewLineTimer > component.clip.length + 0.5f || Input.GetButtonDown(InputNames.Xbox_A) || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
						{
							Display = false;
						}
					}
				}
			}
			if (UpdatePortrait)
			{
				if (!Grow)
				{
					Portrait.transform.localScale = Vector3.MoveTowards(Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
					if (Portrait.transform.localScale.x == 0f)
					{
						Portrait.mainTexture = Portraits[PortraitID];
						Grow = true;
					}
				}
				else
				{
					Portrait.transform.localScale = Vector3.MoveTowards(Portrait.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (Portrait.transform.localScale.x == 1f)
					{
						SpeakerLabel.text = SpeakerNames[PortraitID];
						UpdatePortrait = false;
						AnimTimer = 0f;
						Grow = false;
						LineID++;
						SpawnLabel();
					}
				}
			}
			AnimTimer += Time.deltaTime;
			if (LineID == 2)
			{
				NewTypewriter.charsPerSecond = 15;
				NewTypewriter.delayOnPeriod = 1.5f;
				if (AnimTimer < 0.5f)
				{
					NewTypewriter.delayOnComma = true;
				}
			}
			Animation component2 = Yanmont.Character.GetComponent<Animation>();
			if (LineID == 3)
			{
				NewTypewriter.delayOnComma = true;
				NewTypewriter.delayOnPeriod = 0.75f;
				if (AnimTimer < 1f)
				{
					component2.CrossFade("f02_yanvaniaCutsceneAction1_00");
				}
				if (component2["f02_yanvaniaCutsceneAction1_00"].time >= component2["f02_yanvaniaCutsceneAction1_00"].length)
				{
					component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
			}
			Animation component3 = Dracula.Character.GetComponent<Animation>();
			if (LineID == 5)
			{
				NewTypewriter.charsPerSecond = 15;
				component2.CrossFade("f02_yanvaniaCutsceneAction2_00");
				if (component2["f02_yanvaniaCutsceneAction2_00"].time >= component2["f02_yanvaniaCutsceneAction2_00"].length)
				{
					component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
				if (AnimTimer > 4f)
				{
					component3.CrossFade("DraculaDrink");
				}
				if (AnimTimer > 4.5f)
				{
					Glass.GetComponent<Renderer>().materials[0].color = new Color(1f, 1f, 1f, 0.5f);
				}
				if (AnimTimer > 5f && component3["DraculaDrink"].time >= component3["DraculaDrink"].length)
				{
					component3.CrossFade("DraculaIdle");
				}
			}
			if (LineID == 6)
			{
				component2.CrossFade("f02_yanvaniaDramaticIdle_00");
				if (AnimTimer < 1f)
				{
					NewTypewriter.delayOnPeriod = 2.25f;
				}
				if (AnimTimer > 1f && AnimTimer < 2f)
				{
					component3.CrossFade("DraculaToss");
				}
				if (Glass != null)
				{
					Rigidbody component4 = Glass.GetComponent<Rigidbody>();
					if (AnimTimer > 1.4f && !component4.useGravity)
					{
						component4.useGravity = true;
						Glass.transform.parent = null;
						component4.AddForce(-100f, 100f, -100f);
					}
				}
				if (AnimTimer > 2f + component3["DraculaToss"].length && AnimTimer < 6f)
				{
					component3.CrossFade("DraculaIdle");
				}
				if (AnimTimer > 4f)
				{
					NewTypewriter.delayOnPeriod = 1f;
					NewTypewriter.charsPerSecond = 15;
				}
				if (AnimTimer > 6f && AnimTimer < 9.5f)
				{
					Dracula.transform.position = Vector3.Lerp(Dracula.transform.position, new Vector3(-34.675f, 7.5f, 2.8f), Time.deltaTime * 10f);
					component3.CrossFade("succubus_a_idle_01");
				}
				if (AnimTimer > 9.5f)
				{
					NewLabelScript.text = string.Empty;
					SpeakerLabel.text = string.Empty;
					Dracula.SpawnTeleportEffect();
					Dracula.enabled = true;
					Jukebox.BossBattle();
					Leave = true;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (NewLabel != null)
				{
					Object.Destroy(NewLabel);
				}
				if (NewLabelScript != null)
				{
					NewLabelScript.text = string.Empty;
				}
				SpeakerLabel.text = string.Empty;
				Dracula.SpawnTeleportEffect();
				Dracula.enabled = true;
				Jukebox.BossBattle();
				Object.Destroy(BloodWipe);
				Object.Destroy(Glass);
				Leave = true;
			}
			return;
		}
		Portrait.transform.localScale = Vector3.MoveTowards(Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
		if (Portrait.transform.localScale.x == 0f)
		{
			Border.transform.position = new Vector3(Border.transform.position.x, Border.transform.position.y + Time.deltaTime, Border.transform.position.z);
			BG.transform.position = new Vector3(BG.transform.position.x, BG.transform.position.y + Time.deltaTime, BG.transform.position.z);
			if (!Yanmont.enabled)
			{
				Yanmont.YanvaniaCamera.TargetZoom = 0f;
				Yanmont.Character.transform.localScale = new Vector3(-1f, 1f, 1f);
				Yanmont.EnterCutscene = false;
				Yanmont.Cutscene = false;
				Yanmont.enabled = true;
			}
		}
	}

	private void SpawnLabel()
	{
		NewLabel = Object.Instantiate(Label, base.transform.position, Quaternion.identity);
		NewLabel.transform.parent = NewLabelSpawnPoint;
		NewLabel.transform.localEulerAngles = Vector3.zero;
		NewLabel.transform.localPosition = Vector3.zero;
		NewLabel.transform.localScale = new Vector3(1f, 1f, 1f);
		NewTypewriter = NewLabel.GetComponent<TypewriterEffect>();
		NewLabelScript = NewLabel.GetComponent<UILabel>();
		NewLabelScript.text = Lines[LineID];
		NewLabelScript.enabled = false;
	}
}
