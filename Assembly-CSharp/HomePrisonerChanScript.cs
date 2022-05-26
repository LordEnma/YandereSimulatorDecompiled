// Decompiled with JetBrains decompiler
// Type: HomePrisonerChanScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomePrisonerChanScript : MonoBehaviour
{
  public HomeYandereDetectorScript YandereDetector;
  public HomeCameraScript HomeCamera;
  public CosmeticScript Cosmetic;
  public JsonScript JSON;
  public Vector3 RightEyeRotOrigin;
  public Vector3 LeftEyeRotOrigin;
  public Vector3 PermanentAngleR;
  public Vector3 PermanentAngleL;
  public Vector3 RightEyeOrigin;
  public Vector3 LeftEyeOrigin;
  public Vector3 Twitch;
  public Quaternion LastRotation;
  public Transform HomeYandere;
  public Transform RightBreast;
  public Transform LeftBreast;
  public Transform TwintailR;
  public Transform TwintailL;
  public Transform RightEye;
  public Transform LeftEye;
  public Transform Skirt;
  public Transform Neck;
  public GameObject RightMindbrokenEye;
  public GameObject LeftMindbrokenEye;
  public GameObject AnkleRopes;
  public GameObject Blindfold;
  public GameObject Character;
  public GameObject Tripod;
  public float HairRotation;
  public float TwitchTimer;
  public float NextTwitch;
  public float BreastSize;
  public float EyeShrink;
  public float Sanity;
  public float HairRot1;
  public float HairRot2;
  public float HairRot3;
  public float HairRot4;
  public float HairRot5;
  public bool LookAhead;
  public bool Tortured;
  public bool Eighties;
  public bool Male;
  public int StudentID;

  private void Start()
  {
    if (SchoolGlobals.KidnapVictim > 0)
    {
      this.StudentID = SchoolGlobals.KidnapVictim;
      if ((double) StudentGlobals.GetStudentSanity(this.StudentID) == 100.0)
        this.AnkleRopes.SetActive(false);
      this.PermanentAngleR = this.TwintailR.eulerAngles;
      this.PermanentAngleL = this.TwintailL.eulerAngles;
      if (!StudentGlobals.GetStudentArrested(this.StudentID) && !StudentGlobals.GetStudentDead(this.StudentID))
      {
        this.Cosmetic.StudentID = this.StudentID;
        this.Cosmetic.enabled = true;
        this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
        this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
        this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
        this.RightEyeOrigin = this.RightEye.localPosition;
        this.LeftEyeOrigin = this.LeftEye.localPosition;
        this.UpdateSanity();
        this.TwintailR.transform.localEulerAngles = new Vector3(0.0f, 180f, -90f);
        this.TwintailL.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
        this.Blindfold.SetActive(false);
        this.Tripod.SetActive(false);
        if (this.StudentID == 81 && !StudentGlobals.GetStudentBroken(81) && SchemeGlobals.HelpingKokona)
        {
          this.Blindfold.SetActive(true);
          this.Tripod.SetActive(true);
        }
      }
      else
      {
        SchoolGlobals.KidnapVictim = 0;
        this.gameObject.SetActive(false);
      }
    }
    else
      this.gameObject.SetActive(false);
    if (!GameGlobals.Eighties)
      return;
    if (this.Eighties)
    {
      for (int index = 0; index < this.Cosmetic.Student.Ragdoll.AllRigidbodies.Length; ++index)
      {
        this.Cosmetic.Student.Ragdoll.AllRigidbodies[index].isKinematic = true;
        this.Cosmetic.Student.Ragdoll.AllColliders[index].enabled = false;
      }
      this.Cosmetic.Student.DisableFemaleProps();
      this.Cosmetic.Student.SetSplashes(false);
      this.Cosmetic.Student.DisableProps();
      this.Blindfold.SetActive(true);
    }
    else
      this.gameObject.SetActive(false);
  }

  private void LateUpdate()
  {
    this.Skirt.transform.localPosition = new Vector3(0.0f, -0.135f, 0.01f);
    this.Skirt.transform.localScale = new Vector3(this.Skirt.transform.localScale.x, 1.2f, this.Skirt.transform.localScale.z);
    if (!this.Tortured)
    {
      if ((double) this.Sanity > 0.0)
      {
        if (this.LookAhead)
          this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
        else if (this.YandereDetector.YandereDetected && (double) Vector3.Distance(this.transform.position, this.HomeYandere.position) < 2.0)
        {
          Quaternion b;
          if ((Object) this.HomeCamera.Target == (Object) this.HomeCamera.Targets[10])
          {
            b = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (float) (1.5 * ((100.0 - (double) this.Sanity) / 100.0)) - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot1, Time.deltaTime * 2f);
          }
          else
          {
            b = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot2, Time.deltaTime * 2f);
          }
          this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b, Time.deltaTime * 2f);
          this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
          this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0.0f, -90f);
        }
        else
        {
          if ((Object) this.HomeCamera.Target == (Object) this.HomeCamera.Targets[10])
          {
            Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (float) (1.5 * ((100.0 - (double) this.Sanity) / 100.0)) - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot3, Time.deltaTime * 2f);
          }
          else
            this.Neck.rotation = Quaternion.Slerp(this.LastRotation, Quaternion.LookRotation(this.transform.position + this.transform.forward - this.Neck.position), Time.deltaTime * 2f);
          this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot4, Time.deltaTime * 2f);
          this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
          this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0.0f, -90f);
        }
      }
      else
        this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
    }
    this.LastRotation = this.Neck.rotation;
    if (!this.Tortured && (double) this.Sanity < 100.0 && (double) this.Sanity > 0.0)
    {
      this.TwitchTimer += Time.deltaTime;
      if ((double) this.TwitchTimer > (double) this.NextTwitch)
      {
        this.Twitch = new Vector3((float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f), (float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f), (float) (1.0 - (double) this.Sanity / 100.0) * Random.Range(-10f, 10f));
        this.NextTwitch = Random.Range(0.0f, 1f);
        this.TwitchTimer = 0.0f;
      }
      this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
      this.Neck.localEulerAngles += this.Twitch;
    }
    if (!this.Tortured)
      return;
    this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot5, Time.deltaTime * 2f);
    this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
    this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0.0f, -90f);
  }

  public void UpdateSanity()
  {
    this.Sanity = StudentGlobals.GetStudentSanity(this.StudentID);
    bool flag = (double) this.Sanity == 0.0;
    this.RightMindbrokenEye.SetActive(flag);
    this.LeftMindbrokenEye.SetActive(flag);
  }
}
