using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
public class MemorialSceneScript : MonoBehaviour
{
	// Token: 0x060019C1 RID: 6593 RVA: 0x00107BE0 File Offset: 0x00105DE0
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

	// Token: 0x060019C2 RID: 6594 RVA: 0x00107ED8 File Offset: 0x001060D8
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

	// Token: 0x060019C3 RID: 6595 RVA: 0x001082A0 File Offset: 0x001064A0
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

	// Token: 0x04002968 RID: 10600
	public StudentManagerScript StudentManager;

	// Token: 0x04002969 RID: 10601
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400296A RID: 10602
	public GameObject[] Canvases;

	// Token: 0x0400296B RID: 10603
	public UITexture[] Portraits;

	// Token: 0x0400296C RID: 10604
	public GameObject CanvasGroup;

	// Token: 0x0400296D RID: 10605
	public GameObject FlowerVase;

	// Token: 0x0400296E RID: 10606
	public GameObject Headmaster;

	// Token: 0x0400296F RID: 10607
	public GameObject Counselor;

	// Token: 0x04002970 RID: 10608
	public int MemorialStudents;

	// Token: 0x04002971 RID: 10609
	public float BloomIntensity = 1f;

	// Token: 0x04002972 RID: 10610
	public float BloomRadius = 4f;

	// Token: 0x04002973 RID: 10611
	public float Speed;

	// Token: 0x04002974 RID: 10612
	public bool Eulogized;

	// Token: 0x04002975 RID: 10613
	public bool FadeOut;

	// Token: 0x04002976 RID: 10614
	public GameObject YoungHeadmaster;

	// Token: 0x04002977 RID: 10615
	public Material Transparency;

	// Token: 0x04002978 RID: 10616
	public GameObject[] HeadmasterMesh;

	// Token: 0x04002979 RID: 10617
	public GameObject CounselorMother;

	// Token: 0x0400297A RID: 10618
	public GameObject[] CounselorMesh;
}
