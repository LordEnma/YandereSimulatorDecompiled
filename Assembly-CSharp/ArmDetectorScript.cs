// Decompiled with JetBrains decompiler
// Type: ArmDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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

  private void Start() => this.DemonDress.SetActive(false);

  private void Update()
  {
    if (!this.SummonDemon && this.Arms > 9)
    {
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      this.SummonDemon = true;
      this.MyAudio.Play();
      this.Arms = -999;
    }
    if (!this.SummonFlameDemon && this.Sacrifices > 4 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      this.SummonFlameDemon = true;
      this.MyAudio.Play();
      this.Sacrifices = -999;
    }
    if (!this.SummonEmptyDemon && this.Bodies > 10 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      this.SummonEmptyDemon = true;
      this.MyAudio.Play();
      this.Bodies = -999;
    }
    if (this.SummonDemon)
    {
      if (this.Phase == 1)
      {
        if ((Object) this.ArmArray[1] != (Object) null)
        {
          for (int index = 1; index < 11; ++index)
          {
            if ((Object) this.ArmArray[index] != (Object) null)
            {
              Object.Instantiate<GameObject>(this.SmallDarkAura, this.ArmArray[index].transform.position, Quaternion.identity);
              Object.Destroy((Object) this.ArmArray[index]);
            }
          }
        }
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.0f, Time.deltaTime);
        if ((double) this.Darkness.color.a == 1.0)
        {
          SchoolGlobals.SchoolAtmosphere = 0.0f;
          this.StudentManager.SetAtmosphere();
          this.Yandere.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
          this.DemonSubtitle.text = "...revenge...at last...";
          this.BloodProjector.SetActive(true);
          this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0.0f);
          this.Skull.Prompt.Hide();
          this.Skull.Prompt.enabled = false;
          this.Skull.enabled = false;
          this.MyAudio.clip = this.DemonLine;
          this.MyAudio.Play();
          this.Yandere.Demonic = true;
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        if ((double) this.DemonSubtitle.color.a == 1.0 && Input.GetButtonDown("A"))
          ++this.Phase;
      }
      else if (this.Phase == 4)
      {
        this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0.0f, Time.deltaTime));
        if ((double) this.DemonSubtitle.color.a == 0.0)
        {
          this.MyAudio.clip = this.DemonMusic;
          this.MyAudio.loop = true;
          this.MyAudio.Play();
          this.DemonSubtitle.text = string.Empty;
          ++this.Phase;
        }
      }
      else if (this.Phase == 5)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
          ++this.Phase;
        }
      }
      else if (this.Phase == 6)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > (double) this.ArmsSpawned)
        {
          GameObject gameObject = Object.Instantiate<GameObject>(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
          gameObject.transform.parent = this.Yandere.transform;
          gameObject.transform.LookAt(this.Yandere.transform);
          gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 180f, gameObject.transform.localEulerAngles.z);
          ++this.ArmsSpawned;
          gameObject.GetComponent<DemonArmScript>().IdleAnim = this.ArmsSpawned % 2 == 1 ? "DemonArmIdleOld" : "DemonArmIdle";
        }
        if (this.ArmsSpawned == 10)
        {
          this.Yandere.CanMove = true;
          this.Yandere.IdleAnim = "f02_demonIdle_00";
          this.Yandere.WalkAnim = "f02_demonWalk_00";
          this.Yandere.RunAnim = "f02_demonRun_00";
          this.Yandere.Demonic = true;
          this.SummonDemon = false;
        }
      }
    }
    if (this.SummonFlameDemon)
    {
      if (this.Phase == 1)
      {
        foreach (RagdollScript corpse in this.Police.CorpseList)
        {
          if ((Object) corpse != (Object) null && corpse.Burned && corpse.Sacrifice && !corpse.Dragged && !corpse.Carried)
          {
            Object.Instantiate<GameObject>(this.SmallDarkAura, corpse.Prompt.transform.position, Quaternion.identity);
            Object.Destroy((Object) corpse.gameObject);
            --this.Yandere.NearBodies;
            --this.Police.Corpses;
          }
        }
        ++this.Phase;
      }
      else if (this.Phase == 2)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.0f, Time.deltaTime);
        if ((double) this.Darkness.color.a == 1.0)
        {
          this.Yandere.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
          this.DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
          this.DemonSubtitle.color = new Color(1f, 0.0f, 0.0f, 0.0f);
          this.Skull.Prompt.Hide();
          this.Skull.Prompt.enabled = false;
          this.Skull.enabled = false;
          this.MyAudio.clip = this.FlameDemonLine;
          this.MyAudio.Play();
          ++this.Phase;
        }
      }
      else if (this.Phase == 4)
      {
        this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        if ((double) this.DemonSubtitle.color.a == 1.0 && Input.GetButtonDown("A"))
          ++this.Phase;
      }
      else if (this.Phase == 5)
      {
        this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0.0f, Time.deltaTime));
        if ((double) this.DemonSubtitle.color.a == 0.0)
        {
          this.DemonDress.SetActive(true);
          this.Yandere.MyRenderer.sharedMesh = this.FlameDemonMesh;
          this.Yandere.PantyAttacher.newRenderer.enabled = false;
          this.RiggedAccessory.SetActive(true);
          this.Yandere.FlameDemonic = true;
          this.Yandere.Stance.Current = StanceType.Standing;
          this.Yandere.Sanity = 100f;
          this.Yandere.MyRenderer.materials[0].mainTexture = this.Yandere.FaceTexture;
          this.Yandere.MyRenderer.materials[1].mainTexture = this.Yandere.NudePanties;
          this.Yandere.MyRenderer.materials[2].mainTexture = this.Yandere.NudePanties;
          this.DebugMenu.UpdateCensor();
          this.DebugMenu.UpdateCensor();
          this.DemonSubtitle.text = string.Empty;
          ++this.Phase;
        }
      }
      else if (this.Phase == 6)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
          ++this.Phase;
        }
      }
      else if (this.Phase == 7)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.0)
        {
          this.MyAudio.PlayOneShot(this.FlameActivate);
          this.RightFlame.SetActive(true);
          this.LeftFlame.SetActive(true);
          ++this.Phase;
        }
      }
      else if (this.Phase == 8)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 10.0)
        {
          this.Yandere.CanMove = true;
          this.Yandere.IdleAnim = "f02_demonIdle_00";
          this.Yandere.WalkAnim = "f02_demonWalk_00";
          this.Yandere.RunAnim = "f02_demonRun_00";
          this.SummonFlameDemon = false;
          this.MyAudio.clip = this.DemonMusic;
          this.MyAudio.loop = true;
          this.MyAudio.Play();
        }
      }
    }
    if (this.SummonEmptyDemon)
    {
      if (this.Phase == 1)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.0f, Time.deltaTime);
        if ((double) this.Darkness.color.a == 1.0)
        {
          this.Yandere.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
          this.DemonSubtitle.text = "At last...it is time to reclaim our rightful place.";
          this.BloodProjector.SetActive(true);
          this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0.0f);
          this.Skull.Prompt.Hide();
          this.Skull.Prompt.enabled = false;
          this.Skull.enabled = false;
          this.MyAudio.clip = this.EmptyDemonLine;
          this.MyAudio.Play();
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        if ((double) this.DemonSubtitle.color.a == 1.0 && Input.GetButtonDown("A"))
          ++this.Phase;
      }
      else if (this.Phase == 4)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 1.0)
        {
          GameGlobals.EmptyDemon = true;
          SceneManager.LoadScene("LoadingScene");
        }
      }
    }
    this.SacrificeTimer -= Time.deltaTime;
  }

  private void OnTriggerEnter(Collider other)
  {
    if ((Object) other.transform.parent == (Object) this.LimbParent)
    {
      PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
      if ((Object) component != (Object) null)
      {
        BodyPartScript bodyPart = component.BodyPart;
        if (bodyPart.Sacrifice && (bodyPart.Type == 3 || bodyPart.Type == 4))
        {
          Object.Instantiate<GameObject>(this.BigDarkAura, other.gameObject.transform.position, Quaternion.identity);
          this.MyAudio.Play();
          Object.Destroy((Object) other.gameObject);
          ++this.Arms;
        }
      }
    }
    if ((double) this.SacrificeTimer >= 0.0)
      return;
    StudentScript component1 = other.transform.root.gameObject.GetComponent<StudentScript>();
    if (!((Object) component1 != (Object) null) || !component1.Ragdoll.Sacrifice)
      return;
    if (component1.Ragdoll.Burned)
    {
      ++this.Sacrifices;
      --this.Police.Corpses;
      component1.Ragdoll.Prompt.Hide();
      Object.Destroy((Object) component1.gameObject);
      Object.Instantiate<GameObject>(this.BigDarkAura, component1.Hips.position, Quaternion.identity);
      this.SacrificeTimer = 1f;
      this.MyAudio.Play();
    }
    else if (component1.Armband.activeInHierarchy)
    {
      ++this.Bodies;
      --this.Police.Corpses;
      component1.Ragdoll.Prompt.Hide();
      Object.Destroy((Object) component1.gameObject);
      Object.Instantiate<GameObject>(this.BigDarkAura, component1.Hips.position, Quaternion.identity);
      this.SacrificeTimer = 1f;
      this.MyAudio.Play();
    }
    Debug.Log((object) ("Police.Corpses is now: " + this.Police.Corpses.ToString()));
    if (!component1.Ragdoll.Dragged)
      return;
    this.Yandere.EmptyHands();
  }

  private void Shuffle(int Start)
  {
    for (int index = Start; index < this.ArmArray.Length - 1; ++index)
      this.ArmArray[index] = this.ArmArray[index + 1];
  }

  private void ShuffleBodies(int Start)
  {
    for (int index = Start; index < this.BodyArray.Length - 1; ++index)
      this.BodyArray[index] = this.BodyArray[index + 1];
  }
}
