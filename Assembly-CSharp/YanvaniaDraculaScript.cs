using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaDraculaScript : MonoBehaviour
{
	public YanvaniaCameraScript YanvaniaCamera;

	public YanvaniaYanmontScript Yanmont;

	public UITexture HealthBarParent;

	public UITexture Photograph;

	public AudioClip DeathScream;

	public AudioClip FinalLine;

	public GameObject NewTeleportEffect;

	public GameObject NewAttack;

	public GameObject DoubleFireball;

	public GameObject TripleFireball;

	public GameObject MainCamera;

	public GameObject EndCamera;

	public GameObject TeleportEffect;

	public GameObject Explosion;

	public GameObject Character;

	public Transform HealthBar;

	public Transform RightHand;

	public Transform Head;

	public Renderer MyRenderer;

	public UILabel Label;

	public AudioClip[] Injuries;

	public float ExplosionTimer;

	public float TeleportTimer = 10f;

	public float AttackTimer;

	public float FinalTimer;

	public float DeathTimer;

	public float FlashTimer;

	public float Distance;

	public float MaxHealth = 100f;

	public float Health = 100f;

	public bool FinalLineSpoken;

	public bool PhotoTaken;

	public bool Screamed;

	public bool Injured;

	public bool Shrink;

	public bool Grow;

	public bool Red;

	public int AttackID;

	public int Frames;

	public int Frame;

	private void Awake()
	{
		Animation component = Character.GetComponent<Animation>();
		component["succubus_a_damage_l"].speed = 0.1f;
		component["succubus_a_charm_02"].speed = 2.4f;
		component["succubus_a_charm_03"].speed = 4.66666f;
	}

	private void Update()
	{
		Animation component = Character.GetComponent<Animation>();
		Label.enabled = false;
		if (Yanmont.Health > 0f)
		{
			if (Health > 0f)
			{
				if (base.transform.position.z == 0f)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, (Yanmont.transform.position.x > base.transform.position.x) ? (-90f) : 90f, base.transform.localEulerAngles.z);
				}
				if (NewTeleportEffect == null)
				{
					if (base.transform.position.y > 0f)
					{
						Distance = Mathf.Abs(Yanmont.transform.position.x) - Mathf.Abs(base.transform.position.x);
						if (Mathf.Abs(Distance) < 0.61f && Yanmont.FlashTimer == 0f)
						{
							Yanmont.TakeDamage(5);
						}
						if (AttackID == 0)
						{
							AttackID = Random.Range(1, 3);
							TeleportTimer = 5f;
							AttackTimer = 0f;
							NewAttack = null;
							if (AttackID == 1)
							{
								component["succubus_a_charm_02"].time = 0f;
								component.CrossFade("succubus_a_charm_02");
							}
							else
							{
								component["succubus_a_charm_03"].time = 0f;
								component.CrossFade("succubus_a_charm_03");
							}
						}
						else
						{
							AttackTimer += Time.deltaTime;
							if (AttackID == 1)
							{
								if (component["succubus_a_charm_02"].time > 3.5f && NewAttack == null)
								{
									NewAttack = Object.Instantiate(TripleFireball, RightHand.position, Quaternion.identity);
									NewAttack.GetComponent<YanvaniaTripleFireballScript>().Dracula = base.transform;
								}
								if (component["succubus_a_charm_02"].time >= component["succubus_a_charm_02"].length)
								{
									component.CrossFade("succubus_a_idle_01");
								}
							}
							else
							{
								if (component["succubus_a_charm_03"].time > 4f && NewAttack == null)
								{
									NewAttack = Object.Instantiate(DoubleFireball, RightHand.position, Quaternion.identity);
									NewAttack.GetComponent<YanvaniaDoubleFireballScript>().Dracula = base.transform;
								}
								if (component["succubus_a_charm_03"].time >= component["succubus_a_charm_03"].length)
								{
									component.CrossFade("succubus_a_idle_01");
								}
							}
							TeleportTimer -= Time.deltaTime;
						}
					}
					else
					{
						TeleportTimer -= Time.deltaTime;
					}
					if (TeleportTimer < 0f)
					{
						if (base.transform.position.y < 0f)
						{
							base.transform.position = new Vector3(Random.Range(-38.5f, -31f), base.transform.position.y, base.transform.position.z);
						}
						SpawnTeleportEffect();
					}
				}
				else
				{
					if (Shrink)
					{
						base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, new Vector3(0f, 2f, 0f), Time.deltaTime * 0.5f * 2f);
						if (base.transform.localScale.x == 0f)
						{
							NewTeleportEffect = null;
							Shrink = false;
							Teleport();
						}
					}
					if (Grow)
					{
						base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.deltaTime * 1.5f * 2f);
						if (base.transform.localScale.x > 1.49f)
						{
							NewTeleportEffect = null;
							base.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
							Grow = false;
						}
					}
				}
				if (FlashTimer > 0f)
				{
					FlashTimer -= Time.deltaTime;
					if (!Red)
					{
						Material[] materials = MyRenderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].color = new Color(1f, 0f, 0f, 1f);
						}
						Frames++;
						if (Frames == 5)
						{
							Frames = 0;
							Red = true;
						}
					}
					else
					{
						Material[] materials = MyRenderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].color = new Color(1f, 1f, 1f, 1f);
						}
						Frames++;
						if (Frames == 5)
						{
							Frames = 0;
							Red = false;
						}
					}
				}
				else
				{
					Material[] materials = MyRenderer.materials;
					for (int i = 0; i < materials.Length; i++)
					{
						materials[i].color = new Color(1f, 1f, 1f, 1f);
					}
				}
			}
			else
			{
				HealthBarParent.transform.localPosition = new Vector3(HealthBarParent.transform.localPosition.x, HealthBarParent.transform.localPosition.y - Time.deltaTime * 0.2f, HealthBarParent.transform.localPosition.z);
				HealthBarParent.transform.localScale = new Vector3(HealthBarParent.transform.localScale.x, HealthBarParent.transform.localScale.y + Time.deltaTime * 0.2f, HealthBarParent.transform.localScale.z);
				HealthBarParent.color = new Color(HealthBarParent.color.r, HealthBarParent.color.g, HealthBarParent.color.b, HealthBarParent.color.a - Time.deltaTime * 0.2f);
				component.Play("succubus_a_damage_l");
				ExplosionTimer += Time.deltaTime;
				DeathTimer += Time.deltaTime;
				AudioSource component2 = GetComponent<AudioSource>();
				if (DeathTimer < 5f)
				{
					if (DeathTimer > 1f && !FinalLineSpoken)
					{
						FinalLineSpoken = true;
						component2.clip = FinalLine;
						component2.Play();
					}
					if (ExplosionTimer > 0.1f)
					{
						Object.Instantiate(Explosion, base.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2.5f), Random.Range(-1f, 1f)), Quaternion.identity);
						ExplosionTimer = 0f;
					}
				}
				else
				{
					if (!Screamed)
					{
						Screamed = true;
						component2.clip = DeathScream;
						component2.Play();
					}
					if (DeathTimer > 5f)
					{
						if (!PhotoTaken)
						{
							Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0f, 1f / 60f);
							if (Time.timeScale == 0f)
							{
								ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/Dracula.png");
								if (Frame > 0)
								{
									StartCoroutine(ApplyScreenshot());
								}
								Frame++;
							}
						}
						else if (Photograph.mainTexture != null)
						{
							Photograph.transform.localEulerAngles = new Vector3(Photograph.transform.localEulerAngles.x + Time.deltaTime * 3.6f, Photograph.transform.localEulerAngles.y, Photograph.transform.localEulerAngles.z - Time.deltaTime * 3.6f);
							Photograph.transform.localScale = Vector3.MoveTowards(Photograph.transform.localScale, Vector3.zero, Time.deltaTime * 0.2f);
							Photograph.color = new Color(Photograph.color.r, Photograph.color.g - Time.deltaTime * 0.2f, Photograph.color.b - Time.deltaTime * 0.2f, Photograph.color.a);
							if (Photograph.transform.localScale == Vector3.zero)
							{
								FinalTimer += Time.deltaTime;
								if (FinalTimer > 1f)
								{
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Yanvania", 1);
										PlayerPrefs.SetInt("a", 1);
									}
									YanvaniaGlobals.DraculaDefeated = true;
									SceneManager.LoadScene("YanvaniaTitleScene");
								}
							}
						}
					}
				}
			}
		}
		else
		{
			component.CrossFade("succubus_a_talk_01");
		}
		HealthBar.parent.transform.localPosition = new Vector3(Mathf.Lerp(HealthBar.parent.transform.localPosition.x, 1025f, Time.deltaTime * 10f), HealthBar.parent.transform.localPosition.y, HealthBar.parent.transform.localPosition.z);
		HealthBar.localScale = new Vector3(HealthBar.localScale.x, Mathf.Lerp(HealthBar.localScale.y, Health / MaxHealth, Time.deltaTime * 10f), HealthBar.localScale.z);
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			base.transform.position = new Vector3(base.transform.position.x, 6.5f, 0f);
			Health = 1f;
			TakeDamage();
		}
	}

	public void SpawnTeleportEffect()
	{
		Animation component = Character.GetComponent<Animation>();
		if (base.transform.position.y > 0f)
		{
			NewTeleportEffect = Object.Instantiate(TeleportEffect, new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z), Quaternion.identity);
			component["DraculaTeleport"].time = component["DraculaTeleport"].length;
			component["DraculaTeleport"].speed = -2f;
			component.Play("DraculaTeleport");
			Shrink = true;
		}
		else
		{
			Teleport();
			NewTeleportEffect = Object.Instantiate(TeleportEffect, new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z), Quaternion.identity);
			component["DraculaTeleport"].speed = 1.7f;
			component["DraculaTeleport"].time = 0f;
			component.Play("DraculaTeleport");
			Grow = true;
		}
		NewTeleportEffect.GetComponent<YanvaniaTeleportEffectScript>().Dracula = this;
		TeleportTimer = 1f;
		AttackID = 0;
	}

	private void Teleport()
	{
		base.transform.position = new Vector3(base.transform.position.x, (base.transform.position.y > 0f) ? (-10f) : 6.5f, 0f);
	}

	public void TakeDamage()
	{
		Health -= 5f + ((float)Yanmont.Level * 5f - 5f);
		if (Health <= 0f)
		{
			YanvaniaCamera.StopMusic = true;
			Health = 0f;
			return;
		}
		FlashTimer = 1f;
		Injured = true;
		AudioSource component = GetComponent<AudioSource>();
		component.clip = Injuries[Random.Range(0, Injuries.Length)];
		component.Play();
	}

	private IEnumerator ApplyScreenshot()
	{
		PhotoTaken = true;
		string url = "file:///" + Application.streamingAssetsPath + "/Dracula.png";
		WWW www = new WWW(url);
		yield return www;
		Photograph.mainTexture = www.texture;
		MainCamera.SetActive(value: false);
		EndCamera.GetComponent<AudioListener>().enabled = true;
		Time.timeScale = 1f;
	}
}
