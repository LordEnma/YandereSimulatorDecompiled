// Decompiled with JetBrains decompiler
// Type: MemorialSceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MemorialSceneScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public CameraEffectsScript CameraEffects;
  public GameObject[] Canvases;
  public UITexture[] Portraits;
  public GameObject CanvasGroup;
  public GameObject FlowerVase;
  public GameObject Headmaster;
  public GameObject Counselor;
  public int MemorialStudents;
  public float BloomIntensity = 1f;
  public float BloomRadius = 4f;
  public float Speed;
  public bool Eulogized;
  public bool FadeOut;
  public GameObject YoungHeadmaster;
  public Material Transparency;
  public GameObject[] HeadmasterMesh;
  public GameObject CounselorMother;
  public GameObject[] CounselorMesh;

  private void Start()
  {
    if (PlayerPrefs.GetInt("LoadingSave") == 1)
    {
      int profile = GameGlobals.Profile;
      int num = PlayerPrefs.GetInt("SaveSlot");
      StudentGlobals.MemorialStudents = PlayerPrefs.GetInt("Profile_" + profile.ToString() + "_Slot_" + num.ToString() + "_MemorialStudents");
    }
    this.MemorialStudents = StudentGlobals.MemorialStudents;
    if (this.MemorialStudents % 2 == 0)
      this.CanvasGroup.transform.localPosition = new Vector3(-0.5f, 0.0f, -2f);
    int index1 = 0;
    for (int index2 = 1; index2 < 10; ++index2)
      this.Canvases[index2].SetActive(false);
    string str = "";
    if (GameGlobals.Eighties)
    {
      this.StudentManager.IdolStage.SetActive(false);
      str = "1989";
      this.TurnYoung();
    }
    int index3 = 0;
    for (; this.MemorialStudents > 0; --this.MemorialStudents)
    {
      ++index3;
      this.Canvases[index3].SetActive(true);
      if (this.MemorialStudents == 1)
        index1 = StudentGlobals.MemorialStudent1;
      else if (this.MemorialStudents == 2)
        index1 = StudentGlobals.MemorialStudent2;
      else if (this.MemorialStudents == 3)
        index1 = StudentGlobals.MemorialStudent3;
      else if (this.MemorialStudents == 4)
        index1 = StudentGlobals.MemorialStudent4;
      else if (this.MemorialStudents == 5)
        index1 = StudentGlobals.MemorialStudent5;
      else if (this.MemorialStudents == 6)
        index1 = StudentGlobals.MemorialStudent6;
      else if (this.MemorialStudents == 7)
        index1 = StudentGlobals.MemorialStudent7;
      else if (this.MemorialStudents == 8)
        index1 = StudentGlobals.MemorialStudent8;
      else if (this.MemorialStudents == 9)
        index1 = StudentGlobals.MemorialStudent9;
      WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + str + "/Student_" + index1.ToString() + ".png");
      this.Portraits[index3].mainTexture = (Texture) www.texture;
      GameObject gameObject = Object.Instantiate<GameObject>(this.FlowerVase, this.transform.position, Quaternion.identity);
      StudentJson student = this.StudentManager.JSON.Students[index1];
      Transform transform = this.StudentManager.Seats[student.Class].List[student.Seat];
      if ((double) transform.position.x > 0.0)
      {
        gameObject.transform.position = transform.position + new Vector3(0.33333f, 0.7711f, 0.0f);
      }
      else
      {
        gameObject.transform.position = transform.position + new Vector3(-0.33333f, 0.7711f, 0.0f);
        gameObject.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
      }
    }
  }

  private void Update()
  {
    this.Speed += Time.deltaTime;
    if ((double) this.Speed > 1.0)
    {
      if (!this.Eulogized)
      {
        if (!this.StudentManager.Eighties)
          this.StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 0, 8f);
        else
          this.StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 1, 8f);
        this.StudentManager.Yandere.PromptBar.Label[0].text = "Continue";
        this.StudentManager.Yandere.PromptBar.UpdateButtons();
        this.StudentManager.Yandere.PromptBar.Show = true;
        this.Eulogized = true;
      }
      this.StudentManager.MainCamera.position = Vector3.Lerp(this.StudentManager.MainCamera.position, new Vector3(38f, 4.125f, 68.825f), (float) (((double) this.Speed - 1.0) * (double) Time.deltaTime * 0.150000005960464));
      if (Input.GetButtonDown("A"))
      {
        this.StudentManager.Yandere.PromptBar.Show = false;
        this.FadeOut = true;
      }
    }
    if (!this.FadeOut)
      return;
    this.BloomIntensity = Mathf.MoveTowards(this.BloomIntensity, 500f, Time.deltaTime * 500f);
    this.BloomRadius = Mathf.MoveTowards(this.BloomRadius, 7f, Time.deltaTime * 7f);
    this.CameraEffects.UpdateBloom(this.BloomIntensity);
    this.CameraEffects.UpdateBloomRadius(this.BloomRadius);
    if ((double) this.BloomIntensity != 500.0)
      return;
    if (this.StudentManager.Eighties && DateGlobals.Week == 6)
    {
      this.StudentManager.IdolStage.SetActive(true);
      this.gameObject.SetActive(false);
    }
    this.StudentManager.Yandere.Casual = !this.StudentManager.Yandere.Casual;
    this.StudentManager.Yandere.ChangeSchoolwear();
    this.StudentManager.Yandere.transform.position = new Vector3(12f, 0.0f, 72f);
    this.StudentManager.Yandere.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
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
    this.enabled = false;
  }

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
}
