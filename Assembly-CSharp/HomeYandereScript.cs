using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200032E RID: 814
public class HomeYandereScript : MonoBehaviour
{
	// Token: 0x060018CD RID: 6349 RVA: 0x000F410C File Offset: 0x000F230C
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

	// Token: 0x060018CE RID: 6350 RVA: 0x000F4614 File Offset: 0x000F2814
	private void Update()
	{
		if (this.UpdateFace)
		{
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

	// Token: 0x060018CF RID: 6351 RVA: 0x000F4A00 File Offset: 0x000F2C00
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

	// Token: 0x060018D0 RID: 6352 RVA: 0x000F4A88 File Offset: 0x000F2C88
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

	// Token: 0x060018D1 RID: 6353 RVA: 0x000F4B08 File Offset: 0x000F2D08
	private void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	// Token: 0x060018D2 RID: 6354 RVA: 0x000F4B90 File Offset: 0x000F2D90
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
	}

	// Token: 0x060018D3 RID: 6355 RVA: 0x000F4C20 File Offset: 0x000F2E20
	private void Nude()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
	}

	// Token: 0x060018D4 RID: 6356 RVA: 0x000F4C86 File Offset: 0x000F2E86
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

	// Token: 0x060018D5 RID: 6357 RVA: 0x000F4C95 File Offset: 0x000F2E95
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

	// Token: 0x060018D6 RID: 6358 RVA: 0x000F4CA4 File Offset: 0x000F2EA4
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

	// Token: 0x040025D6 RID: 9686
	public CharacterController MyController;

	// Token: 0x040025D7 RID: 9687
	public StudentManagerScript StudentManager;

	// Token: 0x040025D8 RID: 9688
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x040025D9 RID: 9689
	public HomeCameraScript HomeCamera;

	// Token: 0x040025DA RID: 9690
	public UISprite HomeDarkness;

	// Token: 0x040025DB RID: 9691
	public Animation CharacterAnimation;

	// Token: 0x040025DC RID: 9692
	public GameObject CutsceneYandere;

	// Token: 0x040025DD RID: 9693
	public GameObject Controller;

	// Token: 0x040025DE RID: 9694
	public GameObject Character;

	// Token: 0x040025DF RID: 9695
	public GameObject RyobaHair;

	// Token: 0x040025E0 RID: 9696
	public GameObject Disc;

	// Token: 0x040025E1 RID: 9697
	public Renderer LongHairRenderer;

	// Token: 0x040025E2 RID: 9698
	public Renderer PonytailRenderer;

	// Token: 0x040025E3 RID: 9699
	public AudioClip MiyukiReaction;

	// Token: 0x040025E4 RID: 9700
	public AudioClip DiscScratch;

	// Token: 0x040025E5 RID: 9701
	public AudioSource MyAudio;

	// Token: 0x040025E6 RID: 9702
	public Texture EightiesSocks;

	// Token: 0x040025E7 RID: 9703
	public Texture BlondePony;

	// Token: 0x040025E8 RID: 9704
	public Texture BlondeLong;

	// Token: 0x040025E9 RID: 9705
	public float WalkSpeed;

	// Token: 0x040025EA RID: 9706
	public float RunSpeed;

	// Token: 0x040025EB RID: 9707
	public bool CannotAlphabet;

	// Token: 0x040025EC RID: 9708
	public bool UpdateFace;

	// Token: 0x040025ED RID: 9709
	public bool CanMove;

	// Token: 0x040025EE RID: 9710
	public bool Running;

	// Token: 0x040025EF RID: 9711
	public bool HidePony;

	// Token: 0x040025F0 RID: 9712
	public string IdleAnim = "";

	// Token: 0x040025F1 RID: 9713
	public string WalkAnim = "";

	// Token: 0x040025F2 RID: 9714
	public string RunAnim = "";

	// Token: 0x040025F3 RID: 9715
	public int Hairstyle;

	// Token: 0x040025F4 RID: 9716
	public int VictimID;

	// Token: 0x040025F5 RID: 9717
	public float Timer;

	// Token: 0x040025F6 RID: 9718
	public float BreastSize = 1f;

	// Token: 0x040025F7 RID: 9719
	public Transform BreastR;

	// Token: 0x040025F8 RID: 9720
	public Transform BreastL;

	// Token: 0x040025F9 RID: 9721
	public int AlphabetID;

	// Token: 0x040025FA RID: 9722
	public string[] Letter;

	// Token: 0x040025FB RID: 9723
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040025FC RID: 9724
	public Texture[] UniformTextures;

	// Token: 0x040025FD RID: 9725
	public Texture FaceTexture;

	// Token: 0x040025FE RID: 9726
	public Mesh[] Uniforms;

	// Token: 0x040025FF RID: 9727
	public RiggedAccessoryAttacher Pajamas;

	// Token: 0x04002600 RID: 9728
	public Texture PajamaTexture;

	// Token: 0x04002601 RID: 9729
	public Mesh PajamaMesh;

	// Token: 0x04002602 RID: 9730
	public Texture NudeTexture;

	// Token: 0x04002603 RID: 9731
	public Mesh NudeMesh;

	// Token: 0x04002604 RID: 9732
	public GameObject[] OriginalHairs;

	// Token: 0x04002605 RID: 9733
	public GameObject[] VtuberHairs;

	// Token: 0x04002606 RID: 9734
	public Texture[] VtuberFaces;

	// Token: 0x04002607 RID: 9735
	public Renderer[] Eyes;

	// Token: 0x04002608 RID: 9736
	public bool Vtuber;
}
