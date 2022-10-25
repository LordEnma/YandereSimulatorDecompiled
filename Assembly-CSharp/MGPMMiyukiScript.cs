// Decompiled with JetBrains decompiler
// Type: MGPMMiyukiScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
      this.MagicBar.parent.gameObject.SetActive(false);
    this.Eighties = GameGlobals.Eighties;
    if (!this.Eighties)
      return;
    this.MyRenderer.enabled = false;
    this.SpaceWitchSprite.SetActive(true);
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > (double) this.FPS)
    {
      this.Timer = 0.0f;
      ++this.Frame;
      if (this.Frame == 3)
      {
        this.Frame = 0;
        if (this.RightPhase == 1)
          this.RightPhase = 2;
        else if (this.RightPhase == 3)
          this.RightPhase = 0;
        if (this.LeftPhase == 1)
          this.LeftPhase = 2;
        else if (this.LeftPhase == 3)
          this.LeftPhase = 0;
      }
      if (this.RightPhase == 0 && this.LeftPhase == 0)
        this.MyRenderer.material.mainTexture = this.ForwardSprite[this.Frame];
      else if (this.RightPhase == 1)
        this.MyRenderer.material.mainTexture = this.TurnRightSprite[this.Frame];
      else if (this.RightPhase == 2)
        this.MyRenderer.material.mainTexture = this.RightSprite[this.Frame];
      else if (this.RightPhase == 3)
        this.MyRenderer.material.mainTexture = this.ReverseRightSprite[this.Frame];
      else if (this.LeftPhase == 1)
        this.MyRenderer.material.mainTexture = this.TurnLeftSprite[this.Frame];
      else if (this.LeftPhase == 2)
        this.MyRenderer.material.mainTexture = this.LeftSprite[this.Frame];
      else if (this.LeftPhase == 3)
        this.MyRenderer.material.mainTexture = this.ReverseLeftSprite[this.Frame];
    }
    this.MovementSpeed = 0.0f;
    this.MovementSpeed = !Input.GetButton("LB") ? this.Speed : this.Speed * 0.5f;
    if (this.Gameplay)
    {
      if (Input.GetKey("right") || this.InputManager.DPadRight || (double) Input.GetAxis("Horizontal") > 0.5)
      {
        if (!this.Eighties)
          this.MoveRight();
        else
          this.PositionY += this.MovementSpeed * Time.deltaTime;
      }
      else if (!this.Eighties && (this.RightPhase == 1 || this.RightPhase == 2))
      {
        this.RightPhase = 3;
        this.Frame = 0;
      }
      if (Input.GetKey("left") || this.InputManager.DPadLeft || (double) Input.GetAxis("Horizontal") < -0.5)
      {
        if (!this.Eighties)
          this.MoveLeft();
        else
          this.PositionY -= this.MovementSpeed * Time.deltaTime;
      }
      else if (!this.Eighties && (this.LeftPhase == 1 || this.LeftPhase == 2))
      {
        this.LeftPhase = 3;
        this.Frame = 0;
      }
      if (Input.GetKey("up") || this.InputManager.DPadUp || (double) Input.GetAxis("Vertical") > 0.5)
      {
        if (!this.Eighties)
          this.PositionY += this.MovementSpeed * Time.deltaTime;
        else
          this.MoveLeft();
      }
      else if (this.Eighties && (this.RightPhase == 1 || this.RightPhase == 2))
      {
        this.RightPhase = 3;
        this.Frame = 0;
      }
      if (Input.GetKey("down") || this.InputManager.DPadDown || (double) Input.GetAxis("Vertical") < -0.5)
      {
        if (!this.Eighties)
          this.PositionY -= this.MovementSpeed * Time.deltaTime;
        else
          this.MoveRight();
      }
      else if (this.Eighties && (this.LeftPhase == 1 || this.LeftPhase == 2))
      {
        this.LeftPhase = 3;
        this.Frame = 0;
      }
      if ((double) this.PositionX > 108.0)
        this.PositionX = 108f;
      if ((double) this.PositionX < -110.0)
        this.PositionX = -110f;
      if ((double) this.PositionY > 224.0)
        this.PositionY = 224f;
      if ((double) this.PositionY < -224.0)
        this.PositionY = -224f;
      this.transform.localPosition = new Vector3(this.PositionX, this.PositionY, 0.0f);
      if (Input.GetKey("z") || Input.GetKey("y") || Input.GetButton("A"))
      {
        if ((double) this.ShootTimer == 0.0)
        {
          GameObject gameObject1;
          if (this.MagicLevel == 0)
          {
            gameObject1 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
            gameObject1.transform.parent = this.transform.parent;
            gameObject1.transform.localPosition = new Vector3(gameObject1.transform.localPosition.x, gameObject1.transform.localPosition.y, 1f);
            gameObject1.transform.localScale = new Vector3(16f, 16f, 1f);
          }
          else if (this.MagicLevel == 1)
          {
            GameObject gameObject2 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.1f, 0.0f, 0.0f), Quaternion.identity);
            gameObject2.transform.parent = this.transform.parent;
            gameObject2.transform.localPosition = new Vector3(gameObject2.transform.localPosition.x, gameObject2.transform.localPosition.y, 1f);
            gameObject2.transform.localScale = new Vector3(16f, 16f, 1f);
            gameObject1 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.1f, 0.0f, 0.0f), Quaternion.identity);
            gameObject1.transform.parent = this.transform.parent;
            gameObject1.transform.localPosition = new Vector3(gameObject1.transform.localPosition.x, gameObject1.transform.localPosition.y, 1f);
            gameObject1.transform.localScale = new Vector3(16f, 16f, 1f);
          }
          else if (this.MagicLevel == 2)
          {
            GameObject gameObject3 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
            gameObject3.transform.parent = this.transform.parent;
            gameObject3.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y, 1f);
            gameObject3.transform.localScale = new Vector3(16f, 16f, 1f);
            GameObject gameObject4 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0.0f, 0.0f), Quaternion.identity);
            gameObject4.transform.parent = this.transform.parent;
            gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject4.transform.localPosition.y, 1f);
            gameObject4.transform.localScale = new Vector3(16f, 16f, 1f);
            gameObject1 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0.0f, 0.0f), Quaternion.identity);
            gameObject1.transform.parent = this.transform.parent;
            gameObject1.transform.localPosition = new Vector3(gameObject1.transform.localPosition.x, gameObject1.transform.localPosition.y, 1f);
            gameObject1.transform.localScale = new Vector3(16f, 16f, 1f);
          }
          else
          {
            GameObject gameObject5 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
            gameObject5.transform.parent = this.transform.parent;
            gameObject5.transform.localPosition = new Vector3(gameObject5.transform.localPosition.x, gameObject5.transform.localPosition.y, 1f);
            gameObject5.transform.localScale = new Vector3(16f, 16f, 1f);
            GameObject gameObject6 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0.0f, 0.0f), Quaternion.identity);
            gameObject6.transform.parent = this.transform.parent;
            gameObject6.transform.localPosition = new Vector3(gameObject6.transform.localPosition.x, gameObject6.transform.localPosition.y, 1f);
            gameObject6.transform.localScale = new Vector3(16f, 16f, 1f);
            GameObject gameObject7 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0.0f, 0.0f), Quaternion.identity);
            gameObject7.transform.parent = this.transform.parent;
            gameObject7.transform.localPosition = new Vector3(gameObject7.transform.localPosition.x, gameObject7.transform.localPosition.y, 1f);
            gameObject7.transform.localScale = new Vector3(16f, 16f, 1f);
            GameObject gameObject8 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.4f, 0.0f, 0.0f), Quaternion.identity);
            gameObject8.transform.parent = this.transform.parent;
            gameObject8.transform.localPosition = new Vector3(gameObject8.transform.localPosition.x, gameObject8.transform.localPosition.y, 1f);
            gameObject8.transform.localScale = new Vector3(16f, 16f, 1f);
            gameObject8.GetComponent<MGPMProjectileScript>().Angle = 1;
            gameObject1 = Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.4f, 0.0f, 0.0f), Quaternion.identity);
            gameObject1.transform.parent = this.transform.parent;
            gameObject1.transform.localPosition = new Vector3(gameObject1.transform.localPosition.x, gameObject1.transform.localPosition.y, 1f);
            gameObject1.transform.localScale = new Vector3(16f, 16f, 1f);
            gameObject1.GetComponent<MGPMProjectileScript>().Angle = -1;
          }
          if (this.Eighties)
            gameObject1.GetComponent<MGPMProjectileScript>().Eighties = this.Eighties;
          this.ShootTimer = 0.0f;
        }
        this.ShootTimer += Time.deltaTime;
        if ((double) this.ShootTimer >= 0.075000002980232239)
          this.ShootTimer = 0.0f;
      }
      if (Input.GetKeyUp("z") || Input.GetKeyUp("y") || Input.GetButtonUp("A"))
        this.ShootTimer = 0.0f;
      if (Input.GetKeyDown("r"))
        Application.LoadLevel(Application.loadedLevel);
    }
    if ((double) this.Invincibility <= 0.0)
      return;
    this.Invincibility = Mathf.MoveTowards(this.Invincibility, 0.0f, Time.deltaTime);
    if ((double) this.Invincibility != 0.0)
      return;
    this.MyRenderer.material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 0.0f));
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.layer == 9)
    {
      if ((double) this.Invincibility == 0.0)
      {
        --this.Health;
        if (GameGlobals.EasyMode)
        {
          this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
          this.Invincibility = 1f;
        }
        if (this.Health > 0)
        {
          GameObject gameObject = Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
          gameObject.transform.parent = this.transform.parent;
          gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
          if (!this.Eighties)
            AudioSource.PlayClipAtPoint(this.DamageSound, this.transform.position);
        }
        else
        {
          GameObject gameObject = Object.Instantiate<GameObject>(this.DeathExplosion, this.transform.position, Quaternion.identity);
          gameObject.transform.parent = this.transform.parent;
          gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
          if (!this.Eighties)
            AudioSource.PlayClipAtPoint(this.DeathSound, this.transform.position);
          this.GameplayManager.BeginGameOver();
          this.gameObject.SetActive(false);
        }
      }
      this.UpdateHearts();
    }
    else
    {
      if (collision.gameObject.layer != 15)
        return;
      AudioSource.PlayClipAtPoint(this.PickUpSound, this.transform.position);
      this.GameplayManager.Score += 10;
      ++this.Magic;
      if ((double) this.Magic == 20.0)
      {
        ++this.MagicLevel;
        if (this.MagicLevel > 3 && this.Health < 3)
        {
          ++this.Health;
          this.UpdateHearts();
        }
        this.Magic = 0.0f;
      }
      this.MagicBar.localScale = new Vector3(this.Magic / 20f, 1f, 1f);
      Object.Destroy((Object) collision.gameObject);
    }
  }

  private void UpdateHearts()
  {
    this.Hearts[1].SetActive(false);
    this.Hearts[2].SetActive(false);
    this.Hearts[3].SetActive(false);
    for (int index = 1; index < this.Health + 1; ++index)
      this.Hearts[index].SetActive(true);
  }

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
}
