using System;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class MGPMMiyukiScript : MonoBehaviour
{
	// Token: 0x06000038 RID: 56 RVA: 0x00005C6C File Offset: 0x00003E6C
	private void Start()
	{
		Time.timeScale = 1f;
		if (!GameGlobals.EasyMode)
		{
			this.MagicBar.parent.gameObject.SetActive(false);
		}
		this.Eighties = GameGlobals.Eighties;
		if (this.Eighties)
		{
			this.MyRenderer.enabled = false;
			this.SpaceWitchSprite.SetActive(true);
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00005CCC File Offset: 0x00003ECC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame == 3)
			{
				this.Frame = 0;
				if (this.RightPhase == 1)
				{
					this.RightPhase = 2;
				}
				else if (this.RightPhase == 3)
				{
					this.RightPhase = 0;
				}
				if (this.LeftPhase == 1)
				{
					this.LeftPhase = 2;
				}
				else if (this.LeftPhase == 3)
				{
					this.LeftPhase = 0;
				}
			}
			if (this.RightPhase == 0 && this.LeftPhase == 0)
			{
				this.MyRenderer.material.mainTexture = this.ForwardSprite[this.Frame];
			}
			else if (this.RightPhase == 1)
			{
				this.MyRenderer.material.mainTexture = this.TurnRightSprite[this.Frame];
			}
			else if (this.RightPhase == 2)
			{
				this.MyRenderer.material.mainTexture = this.RightSprite[this.Frame];
			}
			else if (this.RightPhase == 3)
			{
				this.MyRenderer.material.mainTexture = this.ReverseRightSprite[this.Frame];
			}
			else if (this.LeftPhase == 1)
			{
				this.MyRenderer.material.mainTexture = this.TurnLeftSprite[this.Frame];
			}
			else if (this.LeftPhase == 2)
			{
				this.MyRenderer.material.mainTexture = this.LeftSprite[this.Frame];
			}
			else if (this.LeftPhase == 3)
			{
				this.MyRenderer.material.mainTexture = this.ReverseLeftSprite[this.Frame];
			}
		}
		this.MovementSpeed = 0f;
		if (Input.GetButton("LB"))
		{
			this.MovementSpeed = this.Speed * 0.5f;
		}
		else
		{
			this.MovementSpeed = this.Speed;
		}
		if (this.Gameplay)
		{
			if (Input.GetKey("right") || this.InputManager.DPadRight || Input.GetAxis("Horizontal") > 0.5f)
			{
				if (!this.Eighties)
				{
					this.MoveRight();
				}
				else
				{
					this.PositionY += this.MovementSpeed * Time.deltaTime;
				}
			}
			else if (!this.Eighties && (this.RightPhase == 1 || this.RightPhase == 2))
			{
				this.RightPhase = 3;
				this.Frame = 0;
			}
			if (Input.GetKey("left") || this.InputManager.DPadLeft || Input.GetAxis("Horizontal") < -0.5f)
			{
				if (!this.Eighties)
				{
					this.MoveLeft();
				}
				else
				{
					this.PositionY -= this.MovementSpeed * Time.deltaTime;
				}
			}
			else if (!this.Eighties && (this.LeftPhase == 1 || this.LeftPhase == 2))
			{
				this.LeftPhase = 3;
				this.Frame = 0;
			}
			if (Input.GetKey("up") || this.InputManager.DPadUp || Input.GetAxis("Vertical") > 0.5f)
			{
				if (!this.Eighties)
				{
					this.PositionY += this.MovementSpeed * Time.deltaTime;
				}
				else
				{
					this.MoveLeft();
				}
			}
			else if (this.Eighties && (this.RightPhase == 1 || this.RightPhase == 2))
			{
				this.RightPhase = 3;
				this.Frame = 0;
			}
			if (Input.GetKey("down") || this.InputManager.DPadDown || Input.GetAxis("Vertical") < -0.5f)
			{
				if (!this.Eighties)
				{
					this.PositionY -= this.MovementSpeed * Time.deltaTime;
				}
				else
				{
					this.MoveRight();
				}
			}
			else if (this.Eighties && (this.LeftPhase == 1 || this.LeftPhase == 2))
			{
				this.LeftPhase = 3;
				this.Frame = 0;
			}
			if (this.PositionX > 108f)
			{
				this.PositionX = 108f;
			}
			if (this.PositionX < -110f)
			{
				this.PositionX = -110f;
			}
			if (this.PositionY > 224f)
			{
				this.PositionY = 224f;
			}
			if (this.PositionY < -224f)
			{
				this.PositionY = -224f;
			}
			base.transform.localPosition = new Vector3(this.PositionX, this.PositionY, 0f);
			if (Input.GetKey("z") || Input.GetKey("y") || Input.GetButton("A"))
			{
				if (this.ShootTimer == 0f)
				{
					GameObject gameObject;
					if (this.MagicLevel == 0)
					{
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (this.MagicLevel == 1)
					{
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (this.MagicLevel == 2)
					{
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else
					{
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = 1;
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = -1;
					}
					if (this.Eighties)
					{
						gameObject.GetComponent<MGPMProjectileScript>().Eighties = this.Eighties;
					}
					this.ShootTimer = 0f;
				}
				this.ShootTimer += Time.deltaTime;
				if (this.ShootTimer >= 0.075f)
				{
					this.ShootTimer = 0f;
				}
			}
			if (Input.GetKeyUp("z") || Input.GetKeyUp("y") || Input.GetButtonUp("A"))
			{
				this.ShootTimer = 0f;
			}
			if (Input.GetKeyDown("r"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (this.Invincibility > 0f)
		{
			this.Invincibility = Mathf.MoveTowards(this.Invincibility, 0f, Time.deltaTime);
			if (this.Invincibility == 0f)
			{
				this.MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
			}
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00006948 File Offset: 0x00004B48
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			if (this.Invincibility == 0f)
			{
				this.Health--;
				if (GameGlobals.EasyMode)
				{
					this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
					this.Invincibility = 1f;
				}
				if (this.Health > 0)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
					gameObject.transform.parent = base.transform.parent;
					gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
					if (!this.Eighties)
					{
						AudioSource.PlayClipAtPoint(this.DamageSound, base.transform.position);
					}
				}
				else
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.DeathExplosion, base.transform.position, Quaternion.identity);
					gameObject2.transform.parent = base.transform.parent;
					gameObject2.transform.localScale = new Vector3(128f, 128f, 1f);
					if (!this.Eighties)
					{
						AudioSource.PlayClipAtPoint(this.DeathSound, base.transform.position);
					}
					this.GameplayManager.BeginGameOver();
					base.gameObject.SetActive(false);
				}
			}
			this.UpdateHearts();
			return;
		}
		if (collision.gameObject.layer == 15)
		{
			AudioSource.PlayClipAtPoint(this.PickUpSound, base.transform.position);
			this.GameplayManager.Score += 10;
			this.Magic += 1f;
			if (this.Magic == 20f)
			{
				this.MagicLevel++;
				if (this.MagicLevel > 3 && this.Health < 3)
				{
					this.Health++;
					this.UpdateHearts();
				}
				this.Magic = 0f;
			}
			this.MagicBar.localScale = new Vector3(this.Magic / 20f, 1f, 1f);
			UnityEngine.Object.Destroy(collision.gameObject);
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00006B9C File Offset: 0x00004D9C
	private void UpdateHearts()
	{
		this.Hearts[1].SetActive(false);
		this.Hearts[2].SetActive(false);
		this.Hearts[3].SetActive(false);
		for (int i = 1; i < this.Health + 1; i++)
		{
			this.Hearts[i].SetActive(true);
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00006BF4 File Offset: 0x00004DF4
	private void MoveRight()
	{
		if (this.RightPhase < 1)
		{
			this.RightPhase = 1;
			this.LeftPhase = 0;
			this.Frame = 0;
		}
		this.PositionX += this.MovementSpeed * Time.deltaTime;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00006C2D File Offset: 0x00004E2D
	private void MoveLeft()
	{
		if (this.LeftPhase < 1)
		{
			this.RightPhase = 0;
			this.LeftPhase = 1;
			this.Frame = 0;
		}
		this.PositionX -= this.MovementSpeed * Time.deltaTime;
	}

	// Token: 0x040000CF RID: 207
	public MGPMManagerScript GameplayManager;

	// Token: 0x040000D0 RID: 208
	public InputManagerScript InputManager;

	// Token: 0x040000D1 RID: 209
	public GameObject SpaceWitchSprite;

	// Token: 0x040000D2 RID: 210
	public GameObject DeathExplosion;

	// Token: 0x040000D3 RID: 211
	public GameObject Projectile;

	// Token: 0x040000D4 RID: 212
	public GameObject Explosion;

	// Token: 0x040000D5 RID: 213
	public AudioClip DamageSound;

	// Token: 0x040000D6 RID: 214
	public AudioClip PickUpSound;

	// Token: 0x040000D7 RID: 215
	public AudioClip DeathSound;

	// Token: 0x040000D8 RID: 216
	public Transform SpawnPoint;

	// Token: 0x040000D9 RID: 217
	public Transform MagicBar;

	// Token: 0x040000DA RID: 218
	public Renderer MyRenderer;

	// Token: 0x040000DB RID: 219
	public Texture[] ForwardSprite;

	// Token: 0x040000DC RID: 220
	public Texture[] ReverseRightSprite;

	// Token: 0x040000DD RID: 221
	public Texture[] TurnRightSprite;

	// Token: 0x040000DE RID: 222
	public Texture[] RightSprite;

	// Token: 0x040000DF RID: 223
	public Texture[] ReverseLeftSprite;

	// Token: 0x040000E0 RID: 224
	public Texture[] TurnLeftSprite;

	// Token: 0x040000E1 RID: 225
	public Texture[] LeftSprite;

	// Token: 0x040000E2 RID: 226
	public GameObject[] Hearts;

	// Token: 0x040000E3 RID: 227
	public int MagicLevel;

	// Token: 0x040000E4 RID: 228
	public int Frame;

	// Token: 0x040000E5 RID: 229
	public int RightPhase;

	// Token: 0x040000E6 RID: 230
	public int LeftPhase;

	// Token: 0x040000E7 RID: 231
	public int Health;

	// Token: 0x040000E8 RID: 232
	public float Invincibility;

	// Token: 0x040000E9 RID: 233
	public float MovementSpeed;

	// Token: 0x040000EA RID: 234
	public float ShootTimer;

	// Token: 0x040000EB RID: 235
	public float Magic;

	// Token: 0x040000EC RID: 236
	public float Speed;

	// Token: 0x040000ED RID: 237
	public float Timer;

	// Token: 0x040000EE RID: 238
	public float FPS;

	// Token: 0x040000EF RID: 239
	public float PositionX;

	// Token: 0x040000F0 RID: 240
	public float PositionY;

	// Token: 0x040000F1 RID: 241
	public bool Eighties;

	// Token: 0x040000F2 RID: 242
	public bool Gameplay;
}
