using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000D4 RID: 212
public class ArmDetectorScript : MonoBehaviour
{
	// Token: 0x060009DE RID: 2526 RVA: 0x00052214 File Offset: 0x00050414
	private void Start()
	{
		this.DemonDress.SetActive(false);
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x00052224 File Offset: 0x00050424
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
				if (this.ArmArray[1] != null)
				{
					for (int i = 1; i < 11; i++)
					{
						if (this.ArmArray[i] != null)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, this.ArmArray[i].transform.position, Quaternion.identity);
							UnityEngine.Object.Destroy(this.ArmArray[i]);
						}
					}
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					SchoolGlobals.SchoolAtmosphere = 0f;
					this.StudentManager.SetAtmosphere();
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "...revenge...at last...";
					this.BloodProjector.SetActive(true);
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.MyAudio.clip = this.DemonLine;
					this.MyAudio.Play();
					this.Yandere.Demonic = true;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					this.MyAudio.clip = this.DemonMusic;
					this.MyAudio.loop = true;
					this.MyAudio.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)this.ArmsSpawned)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
					gameObject.transform.parent = this.Yandere.transform;
					gameObject.transform.LookAt(this.Yandere.transform);
					gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 180f, gameObject.transform.localEulerAngles.z);
					this.ArmsSpawned++;
					gameObject.GetComponent<DemonArmScript>().IdleAnim = ((this.ArmsSpawned % 2 == 1) ? "DemonArmIdleOld" : "DemonArmIdle");
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
				foreach (RagdollScript ragdollScript in this.Police.CorpseList)
				{
					if (ragdollScript != null && ragdollScript.Burned && ragdollScript.Sacrifice && !ragdollScript.Dragged && !ragdollScript.Carried)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, ragdollScript.Prompt.transform.position, Quaternion.identity);
						UnityEngine.Object.Destroy(ragdollScript.gameObject);
						this.Yandere.NearBodies--;
						this.Police.Corpses--;
					}
				}
				this.Phase++;
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
					this.DemonSubtitle.color = new Color(1f, 0f, 0f, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.MyAudio.clip = this.FlameDemonLine;
					this.MyAudio.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
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
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					this.MyAudio.PlayOneShot(this.FlameActivate);
					this.RightFlame.SetActive(true);
					this.LeftFlame.SetActive(true);
					this.Phase++;
				}
			}
			else if (this.Phase == 8)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 10f)
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
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "At last...it is time to reclaim our rightful place.";
					this.BloodProjector.SetActive(true);
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.MyAudio.clip = this.EmptyDemonLine;
					this.MyAudio.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					GameGlobals.EmptyDemon = true;
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
		this.SacrificeTimer -= Time.deltaTime;
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x00053478 File Offset: 0x00051678
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.parent == this.LimbParent)
		{
			PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
			if (component != null)
			{
				BodyPartScript bodyPart = component.BodyPart;
				if (bodyPart.Sacrifice && (bodyPart.Type == 3 || bodyPart.Type == 4))
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BigDarkAura, other.gameObject.transform.position, Quaternion.identity);
					this.MyAudio.Play();
					UnityEngine.Object.Destroy(other.gameObject);
					this.Arms++;
				}
			}
		}
		if (this.SacrificeTimer < 0f)
		{
			StudentScript component2 = other.transform.root.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Ragdoll.Sacrifice)
			{
				if (component2.Ragdoll.Burned)
				{
					this.Sacrifices++;
					component2.Ragdoll.Prompt.Hide();
					UnityEngine.Object.Destroy(component2.gameObject);
					UnityEngine.Object.Instantiate<GameObject>(this.BigDarkAura, component2.Hips.position, Quaternion.identity);
					this.SacrificeTimer = 1f;
					this.MyAudio.Play();
				}
				else if (component2.Armband.activeInHierarchy)
				{
					this.Bodies++;
					component2.Ragdoll.Prompt.Hide();
					UnityEngine.Object.Destroy(component2.gameObject);
					UnityEngine.Object.Instantiate<GameObject>(this.BigDarkAura, component2.Hips.position, Quaternion.identity);
					this.SacrificeTimer = 1f;
					this.MyAudio.Play();
				}
				this.Police.Corpses--;
				Debug.Log("Police.Corpses is now: " + this.Police.Corpses.ToString());
				if (component2.Ragdoll.Dragged)
				{
					this.Yandere.EmptyHands();
				}
			}
		}
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x00053678 File Offset: 0x00051878
	private void Shuffle(int Start)
	{
		for (int i = Start; i < this.ArmArray.Length - 1; i++)
		{
			this.ArmArray[i] = this.ArmArray[i + 1];
		}
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x000536AC File Offset: 0x000518AC
	private void ShuffleBodies(int Start)
	{
		for (int i = Start; i < this.BodyArray.Length - 1; i++)
		{
			this.BodyArray[i] = this.BodyArray[i + 1];
		}
	}

	// Token: 0x04000A6B RID: 2667
	public StudentManagerScript StudentManager;

	// Token: 0x04000A6C RID: 2668
	public DebugMenuScript DebugMenu;

	// Token: 0x04000A6D RID: 2669
	public JukeboxScript Jukebox;

	// Token: 0x04000A6E RID: 2670
	public YandereScript Yandere;

	// Token: 0x04000A6F RID: 2671
	public PoliceScript Police;

	// Token: 0x04000A70 RID: 2672
	public SkullScript Skull;

	// Token: 0x04000A71 RID: 2673
	public UILabel DemonSubtitle;

	// Token: 0x04000A72 RID: 2674
	public UISprite Darkness;

	// Token: 0x04000A73 RID: 2675
	public Transform LimbParent;

	// Token: 0x04000A74 RID: 2676
	public Transform[] SpawnPoints;

	// Token: 0x04000A75 RID: 2677
	public GameObject[] BodyArray;

	// Token: 0x04000A76 RID: 2678
	public GameObject[] ArmArray;

	// Token: 0x04000A77 RID: 2679
	public GameObject RiggedAccessory;

	// Token: 0x04000A78 RID: 2680
	public GameObject BloodProjector;

	// Token: 0x04000A79 RID: 2681
	public GameObject SmallDarkAura;

	// Token: 0x04000A7A RID: 2682
	public GameObject BigDarkAura;

	// Token: 0x04000A7B RID: 2683
	public GameObject DemonDress;

	// Token: 0x04000A7C RID: 2684
	public GameObject RightFlame;

	// Token: 0x04000A7D RID: 2685
	public GameObject LeftFlame;

	// Token: 0x04000A7E RID: 2686
	public GameObject DemonArm;

	// Token: 0x04000A7F RID: 2687
	public bool SummonEmptyDemon;

	// Token: 0x04000A80 RID: 2688
	public bool SummonFlameDemon;

	// Token: 0x04000A81 RID: 2689
	public bool SummonDemon;

	// Token: 0x04000A82 RID: 2690
	public Mesh FlameDemonMesh;

	// Token: 0x04000A83 RID: 2691
	public int CorpsesCounted;

	// Token: 0x04000A84 RID: 2692
	public int ArmsSpawned;

	// Token: 0x04000A85 RID: 2693
	public int Sacrifices;

	// Token: 0x04000A86 RID: 2694
	public int Phase = 1;

	// Token: 0x04000A87 RID: 2695
	public int Bodies;

	// Token: 0x04000A88 RID: 2696
	public int Arms;

	// Token: 0x04000A89 RID: 2697
	public float SacrificeTimer;

	// Token: 0x04000A8A RID: 2698
	public float Timer;

	// Token: 0x04000A8B RID: 2699
	public AudioClip FlameDemonLine;

	// Token: 0x04000A8C RID: 2700
	public AudioClip FlameActivate;

	// Token: 0x04000A8D RID: 2701
	public AudioClip DemonMusic;

	// Token: 0x04000A8E RID: 2702
	public AudioClip DemonLine;

	// Token: 0x04000A8F RID: 2703
	public AudioClip EmptyDemonLine;

	// Token: 0x04000A90 RID: 2704
	public AudioSource MyAudio;
}
