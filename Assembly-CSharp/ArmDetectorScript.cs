using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmDetectorScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DebugMenuScript DebugMenu;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PoliceScript Police;

	public SkullScript Skull;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public Transform LimbParent;

	public Transform[] SpawnPoints;

	public GameObject[] BodyArray;

	public GameObject[] ArmArray;

	public GameObject RiggedAccessory;

	public GameObject BloodProjector;

	public GameObject SmallDarkAura;

	public GameObject BigDarkAura;

	public GameObject DemonDress;

	public GameObject RightFlame;

	public GameObject LeftFlame;

	public GameObject DemonArm;

	public bool SummonEmptyDemon;

	public bool SummonFlameDemon;

	public bool SummonDemon;

	public Mesh FlameDemonMesh;

	public int CorpsesCounted;

	public int ArmsSpawned;

	public int Sacrifices;

	public int Phase = 1;

	public int Bodies;

	public int Arms;

	public float SacrificeTimer;

	public float Timer;

	public AudioClip FlameDemonLine;

	public AudioClip FlameActivate;

	public AudioClip DemonMusic;

	public AudioClip DemonLine;

	public AudioClip EmptyDemonLine;

	public AudioSource MyAudio;

	private void Start()
	{
		DemonDress.SetActive(value: false);
	}

	private void Update()
	{
		if (!SummonDemon && Arms > 9)
		{
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.CanMove = false;
			SummonDemon = true;
			MyAudio.Play();
			Arms = -999;
		}
		if (!SummonFlameDemon && Sacrifices > 4 && !Yandere.Chased && Yandere.Chasers == 0)
		{
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.CanMove = false;
			SummonFlameDemon = true;
			MyAudio.Play();
			Sacrifices = -999;
		}
		if (!SummonEmptyDemon && Bodies > 10 && !Yandere.Chased && Yandere.Chasers == 0)
		{
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.CanMove = false;
			SummonEmptyDemon = true;
			MyAudio.Play();
			Bodies = -999;
		}
		if (SummonDemon)
		{
			if (Phase == 1)
			{
				if (ArmArray[1] != null)
				{
					for (int i = 1; i < 11; i++)
					{
						if (ArmArray[i] != null)
						{
							Object.Instantiate(SmallDarkAura, ArmArray[i].transform.position, Quaternion.identity);
							Object.Destroy(ArmArray[i]);
						}
					}
				}
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0f, Time.deltaTime);
				if (Darkness.color.a == 1f)
				{
					Skull.NeuterEveryone();
					SchoolGlobals.SchoolAtmosphere = 0f;
					StudentManager.SetAtmosphere();
					Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					DemonSubtitle.text = "...revenge...at last...";
					BloodProjector.SetActive(value: true);
					DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, 0f);
					Skull.Prompt.Hide();
					Skull.Prompt.enabled = false;
					Skull.enabled = false;
					MyAudio.clip = DemonLine;
					MyAudio.Play();
					Yandere.Demonic = true;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (DemonSubtitle.color.a == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (DemonSubtitle.color.a == 0f)
				{
					MyAudio.clip = DemonMusic;
					MyAudio.loop = true;
					MyAudio.Play();
					DemonSubtitle.text = string.Empty;
					Phase++;
				}
			}
			else if (Phase == 5)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Darkness.color.a == 0f)
				{
					Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
					Phase++;
				}
			}
			else if (Phase == 6)
			{
				Timer += Time.deltaTime;
				if (Timer > (float)ArmsSpawned)
				{
					GameObject gameObject = Object.Instantiate(DemonArm, SpawnPoints[ArmsSpawned].position, Quaternion.identity);
					gameObject.transform.parent = Yandere.transform;
					gameObject.transform.LookAt(Yandere.transform);
					gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 180f, gameObject.transform.localEulerAngles.z);
					ArmsSpawned++;
					gameObject.GetComponent<DemonArmScript>().IdleAnim = ((ArmsSpawned % 2 == 1) ? "DemonArmIdleOld" : "DemonArmIdle");
				}
				if (ArmsSpawned == 10)
				{
					Yandere.CanMove = true;
					Yandere.IdleAnim = "f02_demonIdle_00";
					Yandere.WalkAnim = "f02_demonWalk_00";
					Yandere.RunAnim = "f02_demonRun_00";
					Yandere.Demonic = true;
					SummonDemon = false;
				}
			}
		}
		if (SummonFlameDemon)
		{
			if (Phase == 1)
			{
				RagdollScript[] corpseList = Police.CorpseList;
				foreach (RagdollScript ragdollScript in corpseList)
				{
					if (ragdollScript != null && ragdollScript.Burned && ragdollScript.Sacrifice && !ragdollScript.Dragged && !ragdollScript.Carried)
					{
						Object.Instantiate(SmallDarkAura, ragdollScript.Prompt.transform.position, Quaternion.identity);
						Object.Destroy(ragdollScript.gameObject);
						Yandere.NearBodies--;
						Police.Corpses--;
					}
				}
				Phase++;
			}
			else if (Phase == 2)
			{
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0f, Time.deltaTime);
				if (Darkness.color.a == 1f)
				{
					Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
					DemonSubtitle.color = new Color(1f, 0f, 0f, 0f);
					Skull.Prompt.Hide();
					Skull.Prompt.enabled = false;
					Skull.enabled = false;
					MyAudio.clip = FlameDemonLine;
					MyAudio.Play();
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (DemonSubtitle.color.a == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
			}
			else if (Phase == 5)
			{
				DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (DemonSubtitle.color.a == 0f)
				{
					DemonDress.SetActive(value: true);
					Yandere.MyRenderer.sharedMesh = FlameDemonMesh;
					Yandere.PantyAttacher.newRenderer.enabled = false;
					RiggedAccessory.SetActive(value: true);
					Yandere.FlameDemonic = true;
					Yandere.Stance.Current = StanceType.Standing;
					Yandere.Sanity = 100f;
					Yandere.MyRenderer.materials[0].mainTexture = Yandere.FaceTexture;
					Yandere.MyRenderer.materials[1].mainTexture = Yandere.NudePanties;
					Yandere.MyRenderer.materials[2].mainTexture = Yandere.NudePanties;
					DebugMenu.UpdateCensor();
					DebugMenu.UpdateCensor();
					DemonSubtitle.text = string.Empty;
					Phase++;
				}
			}
			else if (Phase == 6)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
				if (Darkness.color.a == 0f)
				{
					Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
					Phase++;
				}
			}
			else if (Phase == 7)
			{
				Timer += Time.deltaTime;
				if (Timer > 5f)
				{
					MyAudio.PlayOneShot(FlameActivate);
					RightFlame.SetActive(value: true);
					LeftFlame.SetActive(value: true);
					Phase++;
				}
			}
			else if (Phase == 8)
			{
				Timer += Time.deltaTime;
				if (Timer > 10f)
				{
					Yandere.CanMove = true;
					Yandere.IdleAnim = "f02_demonIdle_00";
					Yandere.WalkAnim = "f02_demonWalk_00";
					Yandere.RunAnim = "f02_demonRun_00";
					SummonFlameDemon = false;
					MyAudio.clip = DemonMusic;
					MyAudio.loop = true;
					MyAudio.Play();
				}
			}
		}
		if (SummonEmptyDemon)
		{
			if (Phase == 1)
			{
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				Jukebox.Volume = Mathf.MoveTowards(Jukebox.Volume, 0f, Time.deltaTime);
				if (Darkness.color.a == 1f)
				{
					Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					DemonSubtitle.text = "At last...it is time to reclaim our rightful place.";
					BloodProjector.SetActive(value: true);
					DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, 0f);
					Skull.Prompt.Hide();
					Skull.Prompt.enabled = false;
					Skull.enabled = false;
					MyAudio.clip = EmptyDemonLine;
					MyAudio.Play();
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (DemonSubtitle.color.a == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (Darkness.color.a == 1f)
				{
					GameGlobals.EmptyDemon = true;
					StudentGlobals.MaleUniform = 1;
					StudentGlobals.FemaleUniform = 1;
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
		SacrificeTimer -= Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.parent == LimbParent)
		{
			PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
			if (component != null)
			{
				BodyPartScript bodyPart = component.BodyPart;
				if (bodyPart.Sacrifice && (bodyPart.Type == 3 || bodyPart.Type == 4))
				{
					Object.Instantiate(BigDarkAura, other.gameObject.transform.position, Quaternion.identity);
					MyAudio.Play();
					Object.Destroy(other.gameObject);
					Arms++;
				}
			}
		}
		if (!(SacrificeTimer < 0f))
		{
			return;
		}
		StudentScript component2 = other.transform.root.gameObject.GetComponent<StudentScript>();
		if (component2 != null && component2.Ragdoll.Sacrifice)
		{
			if (component2.Ragdoll.Burned)
			{
				Sacrifices++;
				Police.Corpses--;
				component2.Ragdoll.Prompt.Hide();
				Object.Destroy(component2.gameObject);
				Object.Instantiate(BigDarkAura, component2.Hips.position, Quaternion.identity);
				SacrificeTimer = 1f;
				MyAudio.Play();
			}
			else if (component2.Armband.activeInHierarchy)
			{
				Bodies++;
				Police.Corpses--;
				component2.Ragdoll.Prompt.Hide();
				Object.Destroy(component2.gameObject);
				Object.Instantiate(BigDarkAura, component2.Hips.position, Quaternion.identity);
				SacrificeTimer = 1f;
				MyAudio.Play();
			}
			Debug.Log("Police.Corpses is now: " + Police.Corpses);
			if (component2.Ragdoll.Dragged)
			{
				Yandere.EmptyHands();
			}
		}
	}

	private void Shuffle(int Start)
	{
		for (int i = Start; i < ArmArray.Length - 1; i++)
		{
			ArmArray[i] = ArmArray[i + 1];
		}
	}

	private void ShuffleBodies(int Start)
	{
		for (int i = Start; i < BodyArray.Length - 1; i++)
		{
			BodyArray[i] = BodyArray[i + 1];
		}
	}
}
