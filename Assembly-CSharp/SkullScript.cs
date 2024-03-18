using UnityEngine;

public class SkullScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public VoidGoddessScript VoidGoddess;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public AudioSource MyAudio;

	public AudioClip FlameDemonVoice;

	public AudioClip FlameActivation;

	public GameObject HeartbeatCamera;

	public GameObject RitualKnife;

	public GameObject EmptyDemon;

	public GameObject DebugMenu;

	public GameObject DarkAura;

	public GameObject Hell;

	public GameObject FPS;

	public GameObject HUD;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public UISprite Darkness;

	public float FlameTimer;

	public float Timer;

	public bool MissionMode;

	private void Start()
	{
		OriginalPosition = RitualKnife.transform.position;
		OriginalRotation = RitualKnife.transform.eulerAngles;
		MissionMode = MissionModeGlobals.MissionMode;
		MyAudio = GetComponent<AudioSource>();
		if (!GameGlobals.Debug)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Yandere.Armed)
		{
			if (Yandere.EquippedWeapon.WeaponID == 8)
			{
				Prompt.enabled = true;
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				VoidGoddess.Follow = false;
				Yandere.EquippedWeapon.Drop();
				Yandere.EquippedWeapon = null;
				Yandere.Unequip();
				Yandere.DropTimer[Yandere.Equipped] = 0f;
				RitualKnife.transform.position = OriginalPosition;
				RitualKnife.transform.eulerAngles = OriginalRotation;
				RitualKnife.GetComponent<Rigidbody>().useGravity = false;
				if (!MissionMode)
				{
					if (RitualKnife.GetComponent<WeaponScript>().Heated && !RitualKnife.GetComponent<WeaponScript>().Flaming)
					{
						MyAudio.clip = FlameDemonVoice;
						MyAudio.Play();
						FlameTimer = 10f;
						RitualKnife.GetComponent<WeaponScript>().Prompt.Hide();
						RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = false;
					}
					else if (RitualKnife.GetComponent<WeaponScript>().Blood.enabled)
					{
						DebugMenu.SetActive(value: false);
						Yandere.Character.GetComponent<Animation>().CrossFade(Yandere.IdleAnim);
						Yandere.CanMove = false;
						Object.Instantiate(DarkAura, Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
						Timer += Time.deltaTime;
						Clock.StopTime = true;
						if (StudentManager.Students[21] == null || StudentManager.Students[26] == null || StudentManager.Students[31] == null || StudentManager.Students[36] == null || StudentManager.Students[41] == null || StudentManager.Students[46] == null || StudentManager.Students[51] == null || StudentManager.Students[56] == null || StudentManager.Students[61] == null || StudentManager.Students[66] == null || StudentManager.Students[71] == null)
						{
							EmptyDemon.SetActive(value: false);
						}
						else if (!StudentManager.Students[21].Alive || !StudentManager.Students[26].Alive || !StudentManager.Students[31].Alive || !StudentManager.Students[36].Alive || !StudentManager.Students[41].Alive || !StudentManager.Students[46].Alive || !StudentManager.Students[51].Alive || !StudentManager.Students[56].Alive || !StudentManager.Students[61].Alive || !StudentManager.Students[66].Alive || !StudentManager.Students[71].Alive)
						{
							EmptyDemon.SetActive(value: false);
						}
						if (StudentManager.EmptyDemon)
						{
							EmptyDemon.SetActive(value: false);
						}
					}
				}
			}
		}
		if (FlameTimer > 0f)
		{
			FlameTimer = Mathf.MoveTowards(FlameTimer, 0f, Time.deltaTime);
			if (FlameTimer == 0f)
			{
				RitualKnife.GetComponent<WeaponScript>().FireEffect.gameObject.SetActive(value: true);
				RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = true;
				RitualKnife.GetComponent<WeaponScript>().FireEffect.Play();
				RitualKnife.GetComponent<WeaponScript>().FireAudio.Play();
				RitualKnife.GetComponent<WeaponScript>().Flaming = true;
				Prompt.enabled = true;
				Prompt.Yandere.Police.Invalid = true;
				for (int i = 1; i < 101; i++)
				{
					Debug.Log("Removing all students' ability to pepper spray or fight back.");
					if (Prompt.Yandere.StudentManager.Students[i] != null)
					{
						Prompt.Yandere.StudentManager.Students[i].Persona = PersonaType.Coward;
						Prompt.Yandere.StudentManager.Students[i].Strength = 0;
						if (Prompt.Yandere.StudentManager.Students[i].Club == ClubType.Council)
						{
							Prompt.Yandere.StudentManager.Students[i].Club = ClubType.None;
						}
					}
				}
				MyAudio.clip = FlameActivation;
				MyAudio.Play();
			}
		}
		if (Timer > 0f)
		{
			if (Yandere.transform.position.y < 1000f)
			{
				Timer += Time.deltaTime;
				if (Timer > 4f)
				{
					Darkness.enabled = true;
					Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
					if (Darkness.color.a == 1f)
					{
						Yandere.transform.position = new Vector3(0f, 2000f, 0f);
						Yandere.Character.SetActive(value: true);
						Yandere.SetAnimationLayers();
						HeartbeatCamera.SetActive(value: false);
						FPS.SetActive(value: false);
						HUD.SetActive(value: false);
						Hell.SetActive(value: true);
					}
				}
				else if (Timer > 1f)
				{
					Yandere.Character.SetActive(value: false);
				}
			}
			else
			{
				Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0f, Time.deltaTime * 0.5f);
				if (Jukebox.Volume == 0f)
				{
					Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
					if (Darkness.color.a == 0f)
					{
						Yandere.CanMove = true;
						Timer = 0f;
					}
				}
			}
		}
		if (Yandere.Egg)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
