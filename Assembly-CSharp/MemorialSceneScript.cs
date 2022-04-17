using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class MemorialSceneScript : MonoBehaviour
{
	// Token: 0x060019B7 RID: 6583 RVA: 0x00106ED8 File Offset: 0x001050D8
	private void Start()
	{
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			StudentGlobals.MemorialStudents = PlayerPrefs.GetInt(string.Concat(new string[]
			{
				"Profile_",
				profile.ToString(),
				"_Slot_",
				@int.ToString(),
				"_MemorialStudents"
			}));
		}
		this.MemorialStudents = StudentGlobals.MemorialStudents;
		if (this.MemorialStudents % 2 == 0)
		{
			this.CanvasGroup.transform.localPosition = new Vector3(-0.5f, 0f, -2f);
		}
		int num = 0;
		int i;
		for (i = 1; i < 10; i++)
		{
			this.Canvases[i].SetActive(false);
		}
		string text = "";
		if (GameGlobals.Eighties)
		{
			this.StudentManager.IdolStage.SetActive(false);
			text = "1989";
			this.TurnYoung();
		}
		i = 0;
		while (this.MemorialStudents > 0)
		{
			i++;
			this.Canvases[i].SetActive(true);
			if (this.MemorialStudents == 1)
			{
				num = StudentGlobals.MemorialStudent1;
			}
			else if (this.MemorialStudents == 2)
			{
				num = StudentGlobals.MemorialStudent2;
			}
			else if (this.MemorialStudents == 3)
			{
				num = StudentGlobals.MemorialStudent3;
			}
			else if (this.MemorialStudents == 4)
			{
				num = StudentGlobals.MemorialStudent4;
			}
			else if (this.MemorialStudents == 5)
			{
				num = StudentGlobals.MemorialStudent5;
			}
			else if (this.MemorialStudents == 6)
			{
				num = StudentGlobals.MemorialStudent6;
			}
			else if (this.MemorialStudents == 7)
			{
				num = StudentGlobals.MemorialStudent7;
			}
			else if (this.MemorialStudents == 8)
			{
				num = StudentGlobals.MemorialStudent8;
			}
			else if (this.MemorialStudents == 9)
			{
				num = StudentGlobals.MemorialStudent9;
			}
			WWW www = new WWW(string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits",
				text,
				"/Student_",
				num.ToString(),
				".png"
			}));
			this.Portraits[i].mainTexture = www.texture;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.FlowerVase, base.transform.position, Quaternion.identity);
			StudentJson studentJson = this.StudentManager.JSON.Students[num];
			Transform transform = this.StudentManager.Seats[studentJson.Class].List[studentJson.Seat];
			if (transform.position.x > 0f)
			{
				gameObject.transform.position = transform.position + new Vector3(0.33333f, 0.7711f, 0f);
			}
			else
			{
				gameObject.transform.position = transform.position + new Vector3(-0.33333f, 0.7711f, 0f);
				gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			this.MemorialStudents--;
		}
	}

	// Token: 0x060019B8 RID: 6584 RVA: 0x001071D0 File Offset: 0x001053D0
	private void Update()
	{
		this.Speed += Time.deltaTime;
		if (this.Speed > 1f)
		{
			if (!this.Eulogized)
			{
				if (!this.StudentManager.Eighties)
				{
					this.StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 0, 8f);
				}
				else
				{
					this.StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 1, 8f);
				}
				this.StudentManager.Yandere.PromptBar.Label[0].text = "Continue";
				this.StudentManager.Yandere.PromptBar.UpdateButtons();
				this.StudentManager.Yandere.PromptBar.Show = true;
				this.Eulogized = true;
			}
			this.StudentManager.MainCamera.position = Vector3.Lerp(this.StudentManager.MainCamera.position, new Vector3(38f, 4.125f, 68.825f), (this.Speed - 1f) * Time.deltaTime * 0.15f);
			if (Input.GetButtonDown("A"))
			{
				this.StudentManager.Yandere.PromptBar.Show = false;
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.BloomIntensity = Mathf.MoveTowards(this.BloomIntensity, 500f, Time.deltaTime * 500f);
			this.BloomRadius = Mathf.MoveTowards(this.BloomRadius, 7f, Time.deltaTime * 7f);
			this.CameraEffects.UpdateBloom(this.BloomIntensity);
			this.CameraEffects.UpdateBloomRadius(this.BloomRadius);
			if (this.BloomIntensity == 500f)
			{
				if (this.StudentManager.Eighties && DateGlobals.Week == 6)
				{
					this.StudentManager.IdolStage.SetActive(true);
					base.gameObject.SetActive(false);
				}
				this.StudentManager.Yandere.Casual = !this.StudentManager.Yandere.Casual;
				this.StudentManager.Yandere.ChangeSchoolwear();
				this.StudentManager.Yandere.transform.position = new Vector3(12f, 0f, 72f);
				this.StudentManager.Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				this.StudentManager.Yandere.HeartCamera.enabled = true;
				this.StudentManager.Yandere.RPGCamera.enabled = true;
				this.StudentManager.Yandere.CanMove = true;
				this.StudentManager.Yandere.HUD.alpha = 1f;
				this.StudentManager.Clock.BloomIntensity = this.BloomIntensity;
				this.StudentManager.Clock.BloomRadius = this.BloomRadius;
				this.StudentManager.Clock.UpdateBloom = true;
				this.StudentManager.Clock.ReduceKnee = false;
				this.StudentManager.Clock.Lerp = true;
				this.StudentManager.Clock.StopTime = false;
				this.StudentManager.Clock.PresentTime = 450f;
				this.StudentManager.Clock.HourTime = 7.5f;
				this.StudentManager.Unstop();
				this.StudentManager.SkipTo8();
				this.Headmaster.SetActive(false);
				this.Counselor.SetActive(false);
				this.StudentManager.UpdateAllSleuthClothing();
				this.StudentManager.Clock.GivePlayerBroughtWeapon();
				base.enabled = false;
			}
		}
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x00107598 File Offset: 0x00105798
	private void TurnYoung()
	{
		this.YoungHeadmaster.SetActive(true);
		this.HeadmasterMesh[1].SetActive(false);
		this.HeadmasterMesh[2].SetActive(false);
		this.HeadmasterMesh[3].SetActive(false);
		this.HeadmasterMesh[4].SetActive(false);
		this.HeadmasterMesh[5].SetActive(false);
		this.CounselorMother.SetActive(true);
		this.CounselorMesh[1].SetActive(false);
		this.CounselorMesh[2].SetActive(false);
		this.CounselorMesh[3].SetActive(false);
		this.CounselorMesh[4].SetActive(false);
		this.CounselorMesh[5].SetActive(false);
		this.CounselorMesh[6].SetActive(false);
		this.CounselorMesh[7].SetActive(true);
	}

	// Token: 0x0400294E RID: 10574
	public StudentManagerScript StudentManager;

	// Token: 0x0400294F RID: 10575
	public CameraEffectsScript CameraEffects;

	// Token: 0x04002950 RID: 10576
	public GameObject[] Canvases;

	// Token: 0x04002951 RID: 10577
	public UITexture[] Portraits;

	// Token: 0x04002952 RID: 10578
	public GameObject CanvasGroup;

	// Token: 0x04002953 RID: 10579
	public GameObject FlowerVase;

	// Token: 0x04002954 RID: 10580
	public GameObject Headmaster;

	// Token: 0x04002955 RID: 10581
	public GameObject Counselor;

	// Token: 0x04002956 RID: 10582
	public int MemorialStudents;

	// Token: 0x04002957 RID: 10583
	public float BloomIntensity = 1f;

	// Token: 0x04002958 RID: 10584
	public float BloomRadius = 4f;

	// Token: 0x04002959 RID: 10585
	public float Speed;

	// Token: 0x0400295A RID: 10586
	public bool Eulogized;

	// Token: 0x0400295B RID: 10587
	public bool FadeOut;

	// Token: 0x0400295C RID: 10588
	public GameObject YoungHeadmaster;

	// Token: 0x0400295D RID: 10589
	public Material Transparency;

	// Token: 0x0400295E RID: 10590
	public GameObject[] HeadmasterMesh;

	// Token: 0x0400295F RID: 10591
	public GameObject CounselorMother;

	// Token: 0x04002960 RID: 10592
	public GameObject[] CounselorMesh;
}
