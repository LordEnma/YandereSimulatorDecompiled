// Decompiled with JetBrains decompiler
// Type: MechaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MechaScript : MonoBehaviour
{
  public CharacterController MyController;
  public GameObject StudentCrusher;
  public GameObject DestructiveShell;
  public GameObject MechaShell;
  public GameObject ShellType;
  public GameObject[] Sparks;
  public PromptScript Prompt;
  public Transform[] SpawnPoints;
  public Transform[] Wheels;
  public Camera MainCamera;
  public float Speed;
  public float Timer;
  public int ShotsFired;
  public bool Running;
  public bool Fire;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_riding_00");
      this.Prompt.Yandere.enabled = false;
      this.Prompt.Yandere.Riding = true;
      this.Prompt.Yandere.Egg = true;
      this.Prompt.Yandere.Jukebox.Egg = true;
      this.Prompt.Yandere.Jukebox.KillVolume();
      this.Prompt.Yandere.Jukebox.Ninja.enabled = true;
      this.Prompt.Yandere.transform.parent = this.transform;
      this.Prompt.Yandere.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.Prompt.Yandere.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      Physics.SyncTransforms();
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.MainCamera = this.Prompt.Yandere.MainCamera;
      this.transform.parent = (Transform) null;
      this.StudentCrusher.SetActive(true);
      this.gameObject.layer = 9;
    }
    if (this.Prompt.Yandere.Riding)
    {
      if (this.Prompt.Yandere.transform.localPosition != Vector3.zero)
      {
        this.transform.position = this.Prompt.Yandere.transform.position;
        this.Prompt.Yandere.transform.localPosition = Vector3.zero;
        Physics.SyncTransforms();
      }
      this.UpdateMovement();
      if (Input.GetButtonDown("RB"))
        this.Fire = true;
      if (Input.GetButtonDown("X"))
      {
        if ((Object) this.ShellType == (Object) this.MechaShell)
        {
          this.ShellType = this.DestructiveShell;
          this.Sparks[1].SetActive(true);
          this.Sparks[2].SetActive(true);
          this.Sparks[3].SetActive(true);
          this.Sparks[4].SetActive(true);
        }
        else
        {
          this.ShellType = this.MechaShell;
          this.Sparks[1].SetActive(false);
          this.Sparks[2].SetActive(false);
          this.Sparks[3].SetActive(false);
          this.Sparks[4].SetActive(false);
        }
      }
      if (this.Fire)
      {
        this.Timer += Time.deltaTime;
        if (this.ShotsFired < 1)
        {
          if ((double) this.Timer > 0.0)
          {
            Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[1].position, this.transform.rotation);
            ++this.ShotsFired;
          }
        }
        else if (this.ShotsFired < 2)
        {
          if ((double) this.Timer > 0.10000000149011612)
          {
            Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[2].position, this.transform.rotation);
            ++this.ShotsFired;
          }
        }
        else if (this.ShotsFired < 3)
        {
          if ((double) this.Timer > 0.20000000298023224)
          {
            Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[3].position, this.transform.rotation);
            ++this.ShotsFired;
          }
        }
        else if (this.ShotsFired < 4 && (double) this.Timer > 0.30000001192092896)
        {
          Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[4].position, this.transform.rotation);
          this.ShotsFired = 0;
          this.Fire = false;
          this.Timer = 0.0f;
        }
      }
      if (Input.GetButtonDown("RS") || Input.GetButtonDown("LS"))
      {
        this.Prompt.Yandere.transform.parent = (Transform) null;
        this.Prompt.Yandere.enabled = true;
        this.Prompt.Yandere.CanMove = true;
        this.Prompt.Yandere.Riding = false;
        this.Prompt.enabled = true;
        this.gameObject.layer = 17;
      }
    }
    if ((double) this.transform.position.z < -100.0)
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -100f);
    else if ((double) this.transform.position.z > 140.5)
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 140.5f);
    if ((double) this.transform.position.x > 71.0)
      this.transform.position = new Vector3(71f, this.transform.position.y, this.transform.position.z);
    else if ((double) this.transform.position.x < -71.0)
      this.transform.position = new Vector3(-71f, this.transform.position.y, this.transform.position.z);
    if ((double) this.transform.position.y >= 0.0)
      return;
    this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
  }

  private void UpdateMovement()
  {
    if (!this.Prompt.Yandere.ToggleRun)
    {
      this.Running = false;
      if (Input.GetButton("LB"))
        this.Running = true;
    }
    else if (Input.GetButtonDown("LB"))
      this.Running = !this.Running;
    int num1 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime);
    float axis1 = Input.GetAxis("Vertical");
    float axis2 = Input.GetAxis("Horizontal");
    Vector3 normalized = (this.MainCamera.transform.TransformDirection(Vector3.forward) with
    {
      y = 0.0f
    }).normalized;
    Vector3 vector3 = new Vector3(normalized.z, 0.0f, -normalized.x);
    Vector3 forward = axis2 * vector3 + axis1 * normalized;
    Quaternion b = Quaternion.identity;
    if (forward != Vector3.zero)
      b = Quaternion.LookRotation(forward);
    if (forward != Vector3.zero)
    {
      this.transform.rotation = Quaternion.Lerp(this.transform.rotation, b, Time.deltaTime);
      this.Wheels[0].rotation = Quaternion.Lerp(this.Wheels[0].rotation, b, Time.deltaTime * 10f);
    }
    else
      b = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.Speed = (double) axis1 != 0.0 || (double) axis2 != 0.0 ? (!this.Running ? Mathf.MoveTowards(this.Speed, 1f, Time.deltaTime * 10f) : Mathf.MoveTowards(this.Speed, 20f, Time.deltaTime * 2f)) : Mathf.Lerp(this.Speed, 0.0f, Time.deltaTime);
    int num2 = (int) this.MyController.Move(this.transform.forward * this.Speed * Time.deltaTime);
    for (int index = 0; index < 3; ++index)
      this.Wheels[index].Rotate((float) ((double) this.Speed * (double) Time.deltaTime * 360.0), 0.0f, 0.0f);
  }
}
