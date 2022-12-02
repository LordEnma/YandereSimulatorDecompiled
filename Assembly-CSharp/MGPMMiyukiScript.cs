using UnityEngine;

public class MGPMMiyukiScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public InputManagerScript InputManager;

	public GameObject SpaceWitchSprite;

	public GameObject DeathExplosion;

	public GameObject Projectile;

	public GameObject Explosion;

	public AudioClip DamageSound;

	public AudioClip PickUpSound;

	public AudioClip DeathSound;

	public Transform SpawnPoint;

	public Transform MagicBar;

	public Renderer MyRenderer;

	public Texture[] ForwardSprite;

	public Texture[] ReverseRightSprite;

	public Texture[] TurnRightSprite;

	public Texture[] RightSprite;

	public Texture[] ReverseLeftSprite;

	public Texture[] TurnLeftSprite;

	public Texture[] LeftSprite;

	public GameObject[] Hearts;

	public int MagicLevel;

	public int Frame;

	public int RightPhase;

	public int LeftPhase;

	public int Health;

	public float Invincibility;

	public float MovementSpeed;

	public float ShootTimer;

	public float Magic;

	public float Speed;

	public float Timer;

	public float FPS;

	public float PositionX;

	public float PositionY;

	public bool Eighties;

	public bool Gameplay;

	private void Start()
	{
		Time.timeScale = 1f;
		if (!GameGlobals.EasyMode)
		{
			MagicBar.parent.gameObject.SetActive(false);
		}
		Eighties = GameGlobals.Eighties;
		if (Eighties)
		{
			MyRenderer.enabled = false;
			SpaceWitchSprite.SetActive(true);
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > FPS)
		{
			Timer = 0f;
			Frame++;
			if (Frame == 3)
			{
				Frame = 0;
				if (RightPhase == 1)
				{
					RightPhase = 2;
				}
				else if (RightPhase == 3)
				{
					RightPhase = 0;
				}
				if (LeftPhase == 1)
				{
					LeftPhase = 2;
				}
				else if (LeftPhase == 3)
				{
					LeftPhase = 0;
				}
			}
			if (RightPhase == 0 && LeftPhase == 0)
			{
				MyRenderer.material.mainTexture = ForwardSprite[Frame];
			}
			else if (RightPhase == 1)
			{
				MyRenderer.material.mainTexture = TurnRightSprite[Frame];
			}
			else if (RightPhase == 2)
			{
				MyRenderer.material.mainTexture = RightSprite[Frame];
			}
			else if (RightPhase == 3)
			{
				MyRenderer.material.mainTexture = ReverseRightSprite[Frame];
			}
			else if (LeftPhase == 1)
			{
				MyRenderer.material.mainTexture = TurnLeftSprite[Frame];
			}
			else if (LeftPhase == 2)
			{
				MyRenderer.material.mainTexture = LeftSprite[Frame];
			}
			else if (LeftPhase == 3)
			{
				MyRenderer.material.mainTexture = ReverseLeftSprite[Frame];
			}
		}
		MovementSpeed = 0f;
		if (Input.GetButton("LB"))
		{
			MovementSpeed = Speed * 0.5f;
		}
		else
		{
			MovementSpeed = Speed;
		}
		if (Gameplay)
		{
			if (Input.GetKey("right") || InputManager.DPadRight || Input.GetAxis("Horizontal") > 0.5f)
			{
				if (!Eighties)
				{
					MoveRight();
				}
				else
				{
					PositionY += MovementSpeed * Time.deltaTime;
				}
			}
			else if (!Eighties && (RightPhase == 1 || RightPhase == 2))
			{
				RightPhase = 3;
				Frame = 0;
			}
			if (Input.GetKey("left") || InputManager.DPadLeft || Input.GetAxis("Horizontal") < -0.5f)
			{
				if (!Eighties)
				{
					MoveLeft();
				}
				else
				{
					PositionY -= MovementSpeed * Time.deltaTime;
				}
			}
			else if (!Eighties && (LeftPhase == 1 || LeftPhase == 2))
			{
				LeftPhase = 3;
				Frame = 0;
			}
			if (Input.GetKey("up") || InputManager.DPadUp || Input.GetAxis("Vertical") > 0.5f)
			{
				if (!Eighties)
				{
					PositionY += MovementSpeed * Time.deltaTime;
				}
				else
				{
					MoveLeft();
				}
			}
			else if (Eighties && (RightPhase == 1 || RightPhase == 2))
			{
				RightPhase = 3;
				Frame = 0;
			}
			if (Input.GetKey("down") || InputManager.DPadDown || Input.GetAxis("Vertical") < -0.5f)
			{
				if (!Eighties)
				{
					PositionY -= MovementSpeed * Time.deltaTime;
				}
				else
				{
					MoveRight();
				}
			}
			else if (Eighties && (LeftPhase == 1 || LeftPhase == 2))
			{
				LeftPhase = 3;
				Frame = 0;
			}
			if (PositionX > 108f)
			{
				PositionX = 108f;
			}
			if (PositionX < -110f)
			{
				PositionX = -110f;
			}
			if (PositionY > 224f)
			{
				PositionY = 224f;
			}
			if (PositionY < -224f)
			{
				PositionY = -224f;
			}
			base.transform.localPosition = new Vector3(PositionX, PositionY, 0f);
			if (Input.GetKey("z") || Input.GetKey("y") || Input.GetButton("A"))
			{
				if (ShootTimer == 0f)
				{
					GameObject gameObject;
					if (MagicLevel == 0)
					{
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (MagicLevel == 1)
					{
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(-0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (MagicLevel == 2)
					{
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else
					{
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = 1;
						gameObject = Object.Instantiate(Projectile, SpawnPoint.position + new Vector3(-0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = -1;
					}
					if (Eighties)
					{
						gameObject.GetComponent<MGPMProjectileScript>().Eighties = Eighties;
					}
					ShootTimer = 0f;
				}
				ShootTimer += Time.deltaTime;
				if (ShootTimer >= 0.075f)
				{
					ShootTimer = 0f;
				}
			}
			if (Input.GetKeyUp("z") || Input.GetKeyUp("y") || Input.GetButtonUp("A"))
			{
				ShootTimer = 0f;
			}
			if (Input.GetKeyDown("r"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (Invincibility > 0f)
		{
			Invincibility = Mathf.MoveTowards(Invincibility, 0f, Time.deltaTime);
			if (Invincibility == 0f)
			{
				MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			if (Invincibility == 0f)
			{
				Health--;
				if (GameGlobals.EasyMode)
				{
					MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
					Invincibility = 1f;
				}
				if (Health > 0)
				{
					GameObject obj = Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
					obj.transform.parent = base.transform.parent;
					obj.transform.localScale = new Vector3(64f, 64f, 1f);
					if (!Eighties)
					{
						AudioSource.PlayClipAtPoint(DamageSound, base.transform.position);
					}
				}
				else
				{
					GameObject obj2 = Object.Instantiate(DeathExplosion, base.transform.position, Quaternion.identity);
					obj2.transform.parent = base.transform.parent;
					obj2.transform.localScale = new Vector3(128f, 128f, 1f);
					if (!Eighties)
					{
						AudioSource.PlayClipAtPoint(DeathSound, base.transform.position);
					}
					GameplayManager.BeginGameOver();
					base.gameObject.SetActive(false);
				}
			}
			UpdateHearts();
		}
		else
		{
			if (collision.gameObject.layer != 15)
			{
				return;
			}
			AudioSource.PlayClipAtPoint(PickUpSound, base.transform.position);
			GameplayManager.Score += 10;
			Magic += 1f;
			if (Magic == 20f)
			{
				MagicLevel++;
				if (MagicLevel > 3 && Health < 3)
				{
					Health++;
					UpdateHearts();
				}
				Magic = 0f;
			}
			MagicBar.localScale = new Vector3(Magic / 20f, 1f, 1f);
			Object.Destroy(collision.gameObject);
		}
	}

	private void UpdateHearts()
	{
		Hearts[1].SetActive(false);
		Hearts[2].SetActive(false);
		Hearts[3].SetActive(false);
		for (int i = 1; i < Health + 1; i++)
		{
			Hearts[i].SetActive(true);
		}
	}

	private void MoveRight()
	{
		if (RightPhase < 1)
		{
			RightPhase = 1;
			LeftPhase = 0;
			Frame = 0;
		}
		PositionX += MovementSpeed * Time.deltaTime;
	}

	private void MoveLeft()
	{
		if (LeftPhase < 1)
		{
			RightPhase = 0;
			LeftPhase = 1;
			Frame = 0;
		}
		PositionX -= MovementSpeed * Time.deltaTime;
	}
}
