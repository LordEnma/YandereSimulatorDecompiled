// Decompiled with JetBrains decompiler
// Type: MovingEventScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class MovingEventScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public UILabel EventSubtitle;
  public YandereScript Yandere;
  public PortalScript Portal;
  public PromptScript Prompt;
  public ClockScript Clock;
  public StudentScript EventStudent;
  public Transform[] EventLocation;
  public AudioClip[] EventClip;
  public string[] EventSpeech;
  public string[] EventAnim;
  public Collider BenchCollider;
  public GameObject VoiceClip;
  public bool EventActive;
  public bool EventCheck;
  public bool EventOver;
  public bool Poisoned;
  public int EventPhase = 1;
  public DayOfWeek EventDay = DayOfWeek.Wednesday;
  public float Distance;
  public float Timer;

  private void Start()
  {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday != this.EventDay)
      return;
    this.EventCheck = true;
  }

  private void Update()
  {
    if (!this.Clock.StopTime && this.EventCheck && (double) this.Clock.HourTime > 13.0)
    {
      this.EventStudent = this.StudentManager.Students[30];
      if ((UnityEngine.Object) this.EventStudent != (UnityEngine.Object) null)
      {
        this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.BentoAnim].weight = 1f;
        this.EventStudent.CurrentDestination = this.EventLocation[0];
        this.EventStudent.Pathfinding.target = this.EventLocation[0];
        this.EventStudent.SmartPhone.SetActive(false);
        this.EventStudent.Scrubber.SetActive(false);
        this.EventStudent.Bento.SetActive(true);
        this.EventStudent.Pen.SetActive(false);
        this.EventStudent.MovingEvent = this;
        this.EventStudent.InEvent = true;
        this.EventStudent.Private = true;
        this.EventCheck = false;
        this.EventActive = true;
      }
    }
    if (!this.EventActive)
      return;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Poisoned = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if ((double) this.Clock.HourTime > 13.375 && !this.Poisoned || this.EventStudent.Dying || this.EventStudent.Splashed || this.EventStudent.Dodging)
    {
      this.EndEvent();
    }
    else
    {
      this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
      if (this.EventStudent.Alarmed || (double) this.EventStudent.DistanceToDestination >= (double) this.EventStudent.TargetDistance || this.EventStudent.Pathfinding.canMove)
        return;
      if (this.EventPhase == 0)
      {
        this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
        if ((double) this.Clock.HourTime > 13.050000190734863)
        {
          this.EventStudent.CurrentDestination = this.EventLocation[1];
          this.EventStudent.Pathfinding.target = this.EventLocation[1];
          ++this.EventPhase;
        }
      }
      else if (this.EventPhase == 1)
      {
        if (!this.StudentManager.Students[1].WitnessedCorpse)
        {
          if ((double) this.Timer == 0.0)
          {
            AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
            if ((double) this.Distance < 10.0)
              this.EventSubtitle.text = this.EventSpeech[1];
            this.EventStudent.Prompt.Hide();
            this.EventStudent.Prompt.enabled = false;
          }
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 2.0)
          {
            this.EventStudent.CurrentDestination = this.EventLocation[2];
            this.EventStudent.Pathfinding.target = this.EventLocation[2];
            if ((double) this.Distance < 10.0)
              this.EventSubtitle.text = string.Empty;
            ++this.EventPhase;
            this.Timer = 0.0f;
          }
        }
        else
        {
          this.EventPhase = 7;
          this.Timer = 3f;
        }
      }
      else if (this.EventPhase == 2)
      {
        Animation component = this.EventStudent.Character.GetComponent<Animation>();
        component[this.EventStudent.BentoAnim].weight -= Time.deltaTime;
        if ((double) this.Timer == 0.0)
          component.CrossFade("f02_bentoPlace_00");
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0 && (UnityEngine.Object) this.EventStudent.Bento.transform.parent != (UnityEngine.Object) null)
        {
          this.EventStudent.Bento.transform.parent = (Transform) null;
          this.EventStudent.Bento.transform.position = new Vector3(8f, 0.5f, -2.2965f);
          this.EventStudent.Bento.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
        }
        if ((double) this.Timer > 2.0)
        {
          if (this.Yandere.Inventory.LethalPoisons > 0)
            this.Prompt.HideButton[0] = false;
          this.EventStudent.CurrentDestination = this.EventLocation[3];
          this.EventStudent.Pathfinding.target = this.EventLocation[3];
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 3)
      {
        AudioClipPlayer.Play(this.EventClip[2], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
        this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_cornerPeek_00");
        if ((double) this.Distance < 10.0)
          this.EventSubtitle.text = this.EventSpeech[2];
        ++this.EventPhase;
      }
      else if (this.EventPhase == 4)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.5)
        {
          AudioClipPlayer.Play(this.EventClip[3], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
          if ((double) this.Distance < 10.0)
            this.EventSubtitle.text = this.EventSpeech[3];
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 5)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 5.5)
        {
          AudioClipPlayer.Play(this.EventClip[4], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
          if ((double) this.Distance < 10.0)
            this.EventSubtitle.text = this.EventSpeech[4];
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 6)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 3.0)
        {
          this.EventStudent.CurrentDestination = this.EventLocation[2];
          this.EventStudent.Pathfinding.target = this.EventLocation[2];
          if ((double) this.Distance < 10.0)
            this.EventSubtitle.text = string.Empty;
          ++this.EventPhase;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 7)
      {
        if ((double) this.Timer == 0.0)
        {
          Animation component = this.EventStudent.Character.GetComponent<Animation>();
          component["f02_bentoPlace_00"].time = component["f02_bentoPlace_00"].length;
          component["f02_bentoPlace_00"].speed = -1f;
          component.CrossFade("f02_bentoPlace_00");
        }
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0 && (UnityEngine.Object) this.EventStudent.Bento.transform.parent == (UnityEngine.Object) null)
        {
          this.EventStudent.Bento.transform.parent = this.EventStudent.LeftHand;
          this.EventStudent.Bento.transform.localPosition = new Vector3(0.0f, -0.0906f, -0.032f);
          this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0.0f, 90f, 90f);
          this.EventStudent.Bento.transform.localScale = new Vector3(1.4f, 1.5f, 1.4f);
        }
        if ((double) this.Timer > 2.0)
        {
          this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0.0f);
          this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0.0f, 165f, 82.5f);
          this.EventStudent.CurrentDestination = this.EventLocation[4];
          this.EventStudent.Pathfinding.target = this.EventLocation[4];
          this.EventStudent.Prompt.Hide();
          this.EventStudent.Prompt.enabled = false;
          ++this.EventPhase;
          this.Timer = 0.0f;
        }
      }
      else if (this.EventPhase == 8)
      {
        Animation component1 = this.EventStudent.Character.GetComponent<Animation>();
        if (!this.Poisoned)
        {
          component1[this.EventStudent.BentoAnim].weight = 0.0f;
          component1.CrossFade(this.EventStudent.EatAnim);
          if (!this.EventStudent.Chopsticks[0].activeInHierarchy)
          {
            this.EventStudent.Chopsticks[0].SetActive(true);
            this.EventStudent.Chopsticks[1].SetActive(true);
          }
        }
        else
        {
          component1.CrossFade("f02_poisonDeath_00");
          this.Timer += Time.deltaTime;
          if ((double) this.Timer < 13.550000190734863)
          {
            if (!this.EventStudent.Chopsticks[0].activeInHierarchy)
            {
              AudioClipPlayer.Play(this.EventClip[5], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip);
              this.EventStudent.Chopsticks[0].SetActive(true);
              this.EventStudent.Chopsticks[1].SetActive(true);
              this.EventStudent.Distracted = true;
            }
          }
          else if ((double) this.Timer < 16.333330154418945)
          {
            if ((UnityEngine.Object) this.EventStudent.Chopsticks[0].transform.parent != (UnityEngine.Object) this.EventStudent.Bento.transform)
            {
              this.EventStudent.Chopsticks[0].transform.parent = this.EventStudent.Bento.transform;
              this.EventStudent.Chopsticks[1].transform.parent = this.EventStudent.Bento.transform;
            }
            this.EventStudent.EyeShrink += Time.deltaTime;
            if ((double) this.EventStudent.EyeShrink > 0.89999997615814209)
              this.EventStudent.EyeShrink = 0.9f;
          }
          else if ((UnityEngine.Object) this.EventStudent.Bento.transform.parent != (UnityEngine.Object) null)
          {
            this.EventStudent.Bento.transform.parent = (Transform) null;
            this.EventStudent.Bento.GetComponent<Collider>().isTrigger = false;
            this.EventStudent.Bento.AddComponent<Rigidbody>();
            Rigidbody component2 = this.EventStudent.Bento.GetComponent<Rigidbody>();
            component2.AddRelativeForce(Vector3.up * 100f);
            component2.AddRelativeForce(Vector3.left * 100f);
            component2.AddRelativeForce(Vector3.forward * -100f);
          }
          if ((double) component1["f02_poisonDeath_00"].time > (double) component1["f02_poisonDeath_00"].length)
          {
            this.EventStudent.Ragdoll.Poisoned = true;
            this.EventStudent.BecomeRagdoll();
            this.Yandere.Police.PoisonScene = true;
            this.EventOver = true;
            this.EndEvent();
          }
        }
      }
      if ((double) this.Distance >= 11.0)
        return;
      if ((double) this.Distance < 10.0)
      {
        float num = Mathf.Abs((float) (((double) this.Distance - 10.0) * 0.20000000298023224));
        if ((double) num < 0.0)
          num = 0.0f;
        if ((double) num > 1.0)
          num = 1f;
        this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
      }
      else
        this.EventSubtitle.transform.localScale = Vector3.zero;
    }
  }

  private void EndEvent()
  {
    if (!this.EventOver)
    {
      if ((UnityEngine.Object) this.VoiceClip != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.VoiceClip);
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.BentoAnim].weight = 0.0f;
      this.EventStudent.Chopsticks[0].SetActive(false);
      this.EventStudent.Chopsticks[1].SetActive(false);
      this.EventStudent.Bento.SetActive(false);
      this.EventStudent.Prompt.enabled = true;
      this.EventStudent.MovingEvent = (MovingEventScript) null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    this.EventCheck = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }
}
