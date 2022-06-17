// Decompiled with JetBrains decompiler
// Type: StandScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StandScript : MonoBehaviour
{
  public AmplifyMotionEffect MotionBlur;
  public FalconPunchScript FalconPunch;
  public StandPunchScript StandPunch;
  public Transform SummonTransform;
  public GameObject SummonEffect;
  public GameObject StandCamera;
  public YandereScript Yandere;
  public GameObject Stand;
  public Transform[] Hands;
  public int FinishPhase;
  public int Finisher;
  public int Weapons;
  public int Phase;
  public AudioClip SummonSFX;
  public bool ReadyForFinisher;
  public bool SFX;

  private void Start()
  {
    if (!GameGlobals.LoveSick)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (!this.Stand.activeInHierarchy)
    {
      if (this.Weapons != 8 || (double) this.Yandere.transform.position.y <= 11.8999996185303 || !Input.GetButtonDown("RB") || MissionModeGlobals.MissionMode || this.Yandere.Laughing || !this.Yandere.CanMove)
        return;
      this.Yandere.Jojo();
    }
    else if (this.Phase == 0)
    {
      if ((double) this.Stand.GetComponent<Animation>()["StandSummon"].time >= 2.0 && (double) this.Stand.GetComponent<Animation>()["StandSummon"].time <= 2.5)
      {
        if (!this.SFX)
        {
          AudioSource.PlayClipAtPoint(this.SummonSFX, this.transform.position);
          this.SFX = true;
        }
        Object.Instantiate<GameObject>(this.SummonEffect, this.SummonTransform.position, Quaternion.identity);
      }
      if ((double) this.Stand.GetComponent<Animation>()["StandSummon"].time < (double) this.Stand.GetComponent<Animation>()["StandSummon"].length)
        return;
      this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
      ++this.Phase;
    }
    else
    {
      float axis1 = Input.GetAxis("Vertical");
      float axis2 = Input.GetAxis("Horizontal");
      if (this.Yandere.CanMove)
      {
        this.Return();
        if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
        {
          if (this.Yandere.Running)
            this.Stand.GetComponent<Animation>().CrossFade("StandRun");
          else
            this.Stand.GetComponent<Animation>().CrossFade("StandWalk");
        }
        else
          this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
      }
      else
      {
        if (!this.Yandere.RPGCamera.enabled)
          return;
        if (this.Yandere.Laughing)
        {
          if ((double) Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0.0f, 0.2f, -0.4f)) > 0.00999999977648258)
          {
            this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0.0f, 0.2f, 0.1f), Time.deltaTime * 10f);
            this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
          }
          this.Stand.GetComponent<Animation>().CrossFade("StandAttack");
          this.StandPunch.MyCollider.enabled = true;
          this.ReadyForFinisher = true;
        }
        else
        {
          if (!this.ReadyForFinisher)
            return;
          if (this.Phase == 1)
          {
            this.GetComponent<AudioSource>().Play();
            this.Finisher = Random.Range(1, 3);
            this.Stand.GetComponent<Animation>().CrossFade("StandFinisher" + this.Finisher.ToString());
            ++this.Phase;
          }
          else if (this.Phase == 2)
          {
            if ((double) this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time < 0.5)
              return;
            this.FalconPunch.MyCollider.enabled = true;
            this.StandPunch.MyCollider.enabled = false;
            ++this.Phase;
          }
          else
          {
            if (this.Phase != 3 || !this.StandPunch.MyCollider.enabled && (double) this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time < (double) this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].length)
              return;
            this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
            this.FalconPunch.MyCollider.enabled = false;
            this.ReadyForFinisher = false;
            this.Yandere.CanMove = true;
            this.Phase = 1;
          }
        }
      }
    }
  }

  public void Spawn()
  {
    this.FalconPunch.MyCollider.enabled = false;
    this.StandPunch.MyCollider.enabled = false;
    this.StandCamera.SetActive(true);
    this.MotionBlur.enabled = true;
    this.Stand.SetActive(true);
  }

  private void Return()
  {
    if ((double) Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0.0f, 0.0f, -0.5f)) <= 0.00999999977648258)
      return;
    this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0.0f, 0.0f, -0.5f), Time.deltaTime * 10f);
    this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 0.0f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
  }
}
