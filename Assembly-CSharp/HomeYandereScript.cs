using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200032C RID: 812
public class HomeYandereScript : MonoBehaviour
{
	// Token: 0x060018C1 RID: 6337 RVA: 0x000F39B0 File Offset: 0x000F1BB0
	public void Start()
	{
		this.VtuberCheck();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Debug.Log("Here at the Home scene, GameGlobals.RivalEliminationID is currently: " + GameGlobals.RivalEliminationID.ToString());
		if (this.CutsceneYandere != null)
		{
			this.CutsceneYandere.GetComponent<Animation>()["f02_midoriTexting_00"].speed = 0.1f;
		}
		if (SceneManager.GetActiveScene().name == "HomeScene")
		{
			if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = Vector3.zero;
				base.transform.eulerAngles = Vector3.zero;
				if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					this.Nude();
				}
				else if (!HomeGlobals.Night)
				{
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						this.WearPajamas();
					}
					else
					{
						this.ChangeSchoolwear();
						base.StartCoroutine(this.ApplyCustomCostume());
					}
				}
				else
				{
					this.WearPajamas();
				}
			}
			else if (HomeGlobals.StartInBasement)
			{
				HomeGlobals.StartInBasement = false;
				base.transform.position = new Vector3(0f, -135f, 0f);
				base.transform.eulerAngles = Vector3.zero;
			}
			else if (HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.CharacterAnimation.Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.SetActive(true);
				this.WearPajamas();
				this.MyAudio.clip = this.MiyukiReaction;
			}
			else
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.CharacterAnimation.Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.SetActive(true);
				this.WearPajamas();
			}
			if (GameGlobals.BlondeHair)
			{
				this.PonytailRenderer.material.mainTexture = this.BlondePony;
				this.LongHairRenderer.material.mainTexture = this.BlondeLong;
			}
		}
		Time.timeScale = 1f;
		this.IdleAnim = "f02_idleShort_00";
		this.WalkAnim = "f02_newWalk_00";
		this.RunAnim = "f02_newSprint_00";
		if (GameGlobals.Eighties)
		{
			this.StudentManager.Eighties = true;
			this.RyobaHair.SetActive(true);
			this.Hairstyle = 0;
			this.UpdateHair();
			this.IdleAnim = "f02_ryobaIdle_00";
			this.WalkAnim = "f02_ryobaWalk_00";
			this.RunAnim = "f02_ryobaRun_00";
			if (DateGlobals.Weekday != DayOfWeek.Sunday)
			{
				if (!this.Pajamas.gameObject.activeInHierarchy && !this.Vtuber)
				{
					this.MyRenderer.SetBlendShapeWeight(0, 50f);
					this.MyRenderer.SetBlendShapeWeight(5, 25f);
					this.MyRenderer.SetBlendShapeWeight(9, 0f);
					this.MyRenderer.SetBlendShapeWeight(12, 100f);
					this.ChangeSchoolwear();
				}
				this.MyRenderer.materials[0].mainTexture = this.EightiesSocks;
			}
			this.BreastSize = 1.5f;
			this.BreastR.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.BreastL.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		}
		else
		{
			this.PonytailRenderer.transform.parent.gameObject.SetActive(true);
			this.RyobaHair.SetActive(false);
			if (HomeGlobals.Night)
			{
				this.Hairstyle = 2;
				this.UpdateHair();
			}
			else
			{
				this.Hairstyle = 1;
				this.UpdateHair();
			}
		}
		if (DateGlobals.Week != 1 || DateGlobals.Weekday != DayOfWeek.Monday)
		{
			this.CannotAlphabet = true;
		}
		PlayerGlobals.BringingItem = 0;
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3EB8 File Offset: 0x000F20B8
	private void Update()
	{
		if (this.UpdateFace)
		{
			Debug.Log("UpdateFace was true, so...");
			if (this.Pajamas.newRenderer != null)
			{
				if (!this.Vtuber)
				{
					this.Pajamas.newRenderer.SetBlendShapeWeight(0, 50f);
					this.Pajamas.newRenderer.SetBlendShapeWeight(5, 25f);
					this.Pajamas.newRenderer.SetBlendShapeWeight(9, 0f);
					this.Pajamas.newRenderer.SetBlendShapeWeight(12, 100f);
				}
				else
				{
					for (int i = 0; i < 13; i++)
					{
						this.Pajamas.newRenderer.SetBlendShapeWeight(i, 0f);
					}
					this.Pajamas.newRenderer.SetBlendShapeWeight(0, 100f);
					this.Pajamas.newRenderer.SetBlendShapeWeight(9, 100f);
					this.Pajamas.newRenderer.materials[1].mainTexture = this.FaceTexture;
					Debug.Log("Updating pajama mesh with Vtuber face.");
				}
			}
			this.UpdateFace = false;
		}
		if (!this.Disc.activeInHierarchy)
		{
			if (this.CanMove)
			{
				if (!OptionGlobals.ToggleRun)
				{
					this.Running = false;
					if (Input.GetButton("LB"))
					{
						this.Running = true;
					}
				}
				else if (Input.GetButtonDown("LB"))
				{
					this.Running = !this.Running;
				}
				this.MyController.Move(Physics.gravity * 0.01f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 vector = Camera.main.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 a = new Vector3(vector.z, 0f, -vector.x);
				Vector3 vector2 = axis2 * a + axis * vector;
				if (vector2 != Vector3.zero)
				{
					Quaternion b = Quaternion.LookRotation(vector2);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
				if (axis != 0f || axis2 != 0f)
				{
					if (this.Running)
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
						this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.MyController.Move(base.transform.forward * this.WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
				}
			}
			else
			{
				this.CharacterAnimation.CrossFade(this.IdleAnim);
			}
		}
		else if (this.HomeDarkness.color.a == 0f)
		{
			if (this.Timer == 0f)
			{
				this.MyAudio.Play();
			}
			else if (this.Timer > this.MyAudio.clip.length + 1f)
			{
				YanvaniaGlobals.DraculaDefeated = false;
				HomeGlobals.MiyukiDefeated = false;
				this.Disc.SetActive(false);
				this.HomeVideoGames.Quit();
			}
			this.Timer += Time.deltaTime;
		}
		Rigidbody component = base.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.velocity = Vector3.zero;
		}
		if (base.transform.position.y < -10f)
		{
			base.transform.position = new Vector3(base.transform.position.x, -10f, base.transform.position.z);
		}
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x000F42B0 File Offset: 0x000F24B0
	private void LateUpdate()
	{
		if (!this.CannotAlphabet && Input.GetKeyDown(this.Letter[this.AlphabetID]))
		{
			this.AlphabetID++;
			if (this.AlphabetID == this.Letter.Length)
			{
				GameGlobals.AlphabetMode = true;
				StudentGlobals.MemorialStudents = 0;
				for (int i = 1; i < 101; i++)
				{
					StudentGlobals.SetStudentDead(i, false);
					StudentGlobals.SetStudentKidnapped(i, false);
					StudentGlobals.SetStudentArrested(i, false);
					StudentGlobals.SetStudentExpelled(i, false);
				}
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	// Token: 0x060018C4 RID: 6340 RVA: 0x000F4338 File Offset: 0x000F2538
	private void UpdateHair()
	{
		if (this.Hairstyle == 0)
		{
			this.LongHairRenderer.gameObject.SetActive(false);
			this.PonytailRenderer.enabled = false;
			return;
		}
		if (this.Hairstyle == 1)
		{
			this.LongHairRenderer.gameObject.SetActive(false);
			this.PonytailRenderer.enabled = true;
			return;
		}
		if (this.Hairstyle == 2)
		{
			this.LongHairRenderer.gameObject.SetActive(true);
			this.PonytailRenderer.enabled = false;
		}
	}

	// Token: 0x060018C5 RID: 6341 RVA: 0x000F43B8 File Offset: 0x000F25B8
	private void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	// Token: 0x060018C6 RID: 6342 RVA: 0x000F4440 File Offset: 0x000F2640
	private void WearPajamas()
	{
		this.Pajamas.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = null;
		this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomFace());
		if (GameGlobals.Eighties)
		{
			this.UpdateFace = true;
		}
		Debug.Log("Now wearing pajamas.");
	}

	// Token: 0x060018C7 RID: 6343 RVA: 0x000F44D8 File Offset: 0x000F26D8
	private void Nude()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
	}

	// Token: 0x060018C8 RID: 6344 RVA: 0x000F453E File Offset: 0x000F273E
	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		base.StartCoroutine(this.ApplyCustomFace());
		yield break;
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x000F454D File Offset: 0x000F274D
	private IEnumerator ApplyCustomFace()
	{
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
			this.FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			this.PonytailRenderer.material.mainTexture = CustomHair.texture;
		}
		yield break;
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x000F455C File Offset: 0x000F275C
	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			for (int i = 1; i < this.OriginalHairs.Length; i++)
			{
				this.OriginalHairs[i].transform.localPosition = new Vector3(0f, 1f, 0f);
			}
			this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
			for (int i = 0; i < 13; i++)
			{
				this.MyRenderer.SetBlendShapeWeight(i, 0f);
			}
			this.MyRenderer.SetBlendShapeWeight(0, 100f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.FaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
			Debug.Log("FaceTexture changed to Vtuber's face texture.");
			this.Eyes[1].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.Eyes[2].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.UpdateFace = true;
			this.Vtuber = true;
			return;
		}
		this.VtuberHairs[1].SetActive(false);
	}

	// Token: 0x040025C0 RID: 9664
	public CharacterController MyController;

	// Token: 0x040025C1 RID: 9665
	public StudentManagerScript StudentManager;

	// Token: 0x040025C2 RID: 9666
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x040025C3 RID: 9667
	public HomeCameraScript HomeCamera;

	// Token: 0x040025C4 RID: 9668
	public UISprite HomeDarkness;

	// Token: 0x040025C5 RID: 9669
	public Animation CharacterAnimation;

	// Token: 0x040025C6 RID: 9670
	public GameObject CutsceneYandere;

	// Token: 0x040025C7 RID: 9671
	public GameObject Controller;

	// Token: 0x040025C8 RID: 9672
	public GameObject Character;

	// Token: 0x040025C9 RID: 9673
	public GameObject RyobaHair;

	// Token: 0x040025CA RID: 9674
	public GameObject Disc;

	// Token: 0x040025CB RID: 9675
	public Renderer LongHairRenderer;

	// Token: 0x040025CC RID: 9676
	public Renderer PonytailRenderer;

	// Token: 0x040025CD RID: 9677
	public AudioClip MiyukiReaction;

	// Token: 0x040025CE RID: 9678
	public AudioClip DiscScratch;

	// Token: 0x040025CF RID: 9679
	public AudioSource MyAudio;

	// Token: 0x040025D0 RID: 9680
	public Texture EightiesSocks;

	// Token: 0x040025D1 RID: 9681
	public Texture BlondePony;

	// Token: 0x040025D2 RID: 9682
	public Texture BlondeLong;

	// Token: 0x040025D3 RID: 9683
	public float WalkSpeed;

	// Token: 0x040025D4 RID: 9684
	public float RunSpeed;

	// Token: 0x040025D5 RID: 9685
	public bool CannotAlphabet;

	// Token: 0x040025D6 RID: 9686
	public bool UpdateFace;

	// Token: 0x040025D7 RID: 9687
	public bool CanMove;

	// Token: 0x040025D8 RID: 9688
	public bool Running;

	// Token: 0x040025D9 RID: 9689
	public bool HidePony;

	// Token: 0x040025DA RID: 9690
	public string IdleAnim = "";

	// Token: 0x040025DB RID: 9691
	public string WalkAnim = "";

	// Token: 0x040025DC RID: 9692
	public string RunAnim = "";

	// Token: 0x040025DD RID: 9693
	public int Hairstyle;

	// Token: 0x040025DE RID: 9694
	public int VictimID;

	// Token: 0x040025DF RID: 9695
	public float Timer;

	// Token: 0x040025E0 RID: 9696
	public float BreastSize = 1f;

	// Token: 0x040025E1 RID: 9697
	public Transform BreastR;

	// Token: 0x040025E2 RID: 9698
	public Transform BreastL;

	// Token: 0x040025E3 RID: 9699
	public int AlphabetID;

	// Token: 0x040025E4 RID: 9700
	public string[] Letter;

	// Token: 0x040025E5 RID: 9701
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040025E6 RID: 9702
	public Texture[] UniformTextures;

	// Token: 0x040025E7 RID: 9703
	public Texture FaceTexture;

	// Token: 0x040025E8 RID: 9704
	public Mesh[] Uniforms;

	// Token: 0x040025E9 RID: 9705
	public RiggedAccessoryAttacher Pajamas;

	// Token: 0x040025EA RID: 9706
	public Texture PajamaTexture;

	// Token: 0x040025EB RID: 9707
	public Mesh PajamaMesh;

	// Token: 0x040025EC RID: 9708
	public Texture NudeTexture;

	// Token: 0x040025ED RID: 9709
	public Mesh NudeMesh;

	// Token: 0x040025EE RID: 9710
	public GameObject[] OriginalHairs;

	// Token: 0x040025EF RID: 9711
	public GameObject[] VtuberHairs;

	// Token: 0x040025F0 RID: 9712
	public Texture[] VtuberFaces;

	// Token: 0x040025F1 RID: 9713
	public Renderer[] Eyes;

	// Token: 0x040025F2 RID: 9714
	public bool Vtuber;
}
