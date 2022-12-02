using UnityEngine;

public class RadioScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public GameObject RadioNotes;

	public GameObject AlarmDisc;

	public AudioSource MyAudio;

	public Renderer MyRenderer;

	public Texture OffTexture;

	public Texture OnTexture;

	public StudentScript Victim;

	public PromptScript Prompt;

	public float CooldownTimer;

	public bool Delinquent;

	public bool On;

	public int Proximity;

	public int ID;

	public AudioClip EightiesMusic;

	private void Start()
	{
		if (Delinquent && StudentGlobals.GetStudentExpelled(76))
		{
			Object.Destroy(base.gameObject);
		}
		if (GameGlobals.Eighties)
		{
			MyAudio.clip = EightiesMusic;
		}
	}

	private void Update()
	{
		if (base.transform.parent == null)
		{
			if (CooldownTimer > 0f)
			{
				CooldownTimer = Mathf.MoveTowards(CooldownTimer, 0f, Time.deltaTime);
				if (CooldownTimer == 0f)
				{
					Prompt.enabled = true;
				}
			}
			else
			{
				UISprite uISprite = Prompt.Circle[0];
				if (uISprite.fillAmount == 0f)
				{
					uISprite.fillAmount = 1f;
					if (!On)
					{
						Prompt.Yandere.PotentiallyAnnoyingTimer = 1f;
						TurnOn();
					}
					else
					{
						CooldownTimer = 1f;
						TurnOff();
					}
				}
			}
			if (On && Victim == null && AlarmDisc != null)
			{
				AlarmDiscScript component = Object.Instantiate(AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>();
				component.SourceRadio = this;
				component.NoScream = true;
				component.Radio = true;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
		if (!Delinquent)
		{
			return;
		}
		Proximity = 0;
		for (ID = 1; ID < 6; ID++)
		{
			if (StudentManager.Students[75 + ID] != null && Vector3.Distance(base.transform.position, StudentManager.Students[75 + ID].transform.position) < 1.1f)
			{
				if (!StudentManager.Students[75 + ID].Alarmed && !StudentManager.Students[75 + ID].Threatened && StudentManager.Students[75 + ID].Alive)
				{
					Proximity++;
				}
				else
				{
					Proximity = -100;
					ID = 5;
					MyAudio.Stop();
					Jukebox.ClubDip = 0f;
				}
			}
		}
		if (Prompt.Yandere.Talking && Prompt.Yandere.StudentManager.DialogueWheel.ClubLeader)
		{
			MyAudio.volume = 0f;
		}
		else
		{
			MyAudio.volume = 0.1f;
		}
		if (Proximity > 0)
		{
			if (!MyAudio.isPlaying)
			{
				MyAudio.Play();
			}
			float num = Vector3.Distance(Prompt.Yandere.transform.position, base.transform.position);
			if (num < 11f)
			{
				Jukebox.ClubDip = Mathf.MoveTowards(Jukebox.ClubDip, (10f - num) * 0.2f * Jukebox.Volume, Time.deltaTime);
				if (Jukebox.ClubDip < 0f)
				{
					Jukebox.ClubDip = 0f;
				}
				if (Jukebox.ClubDip > Jukebox.Volume)
				{
					Jukebox.ClubDip = Jukebox.Volume;
				}
			}
		}
		else if (MyAudio.isPlaying)
		{
			MyAudio.Stop();
			Jukebox.ClubDip = 0f;
		}
	}

	public void TurnOn()
	{
		Prompt.Label[0].text = "     Turn Off";
		MyRenderer.material.mainTexture = OnTexture;
		RadioNotes.SetActive(true);
		MyAudio.Play();
		On = true;
	}

	public void TurnOff()
	{
		Prompt.Label[0].text = "     Turn On";
		Prompt.enabled = false;
		Prompt.Hide();
		MyRenderer.material.mainTexture = OffTexture;
		RadioNotes.SetActive(false);
		CooldownTimer = 1f;
		MyAudio.Stop();
		Victim = null;
		On = false;
	}
}
