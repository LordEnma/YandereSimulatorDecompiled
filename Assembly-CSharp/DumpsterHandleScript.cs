// Decompiled with JetBrains decompiler
// Type: DumpsterHandleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DumpsterHandleScript : MonoBehaviour
{
  public DumpsterLidScript DumpsterLid;
  public PromptBarScript PromptBar;
  public PromptScript Prompt;
  public Transform GrabSpot;
  public GameObject Panel;
  public bool Grabbed;
  public float Direction;
  public float PullLimit;
  public float PushLimit;

  private void Start() => this.Panel.SetActive(false);

  private void Update()
  {
    this.Prompt.HideButton[3] = (Object) this.Prompt.Yandere.PickUp != (Object) null || this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying;
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
      {
        this.Prompt.Yandere.DumpsterGrabbing = true;
        this.Prompt.Yandere.DumpsterHandle = this;
        this.Prompt.Yandere.CanMove = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[1].text = "STOP";
        this.PromptBar.Label[5].text = "PUSH / PULL";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.Grabbed = true;
      }
    }
    if (!this.Grabbed)
      return;
    this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * 10f);
    if ((double) Vector3.Distance(this.Prompt.Yandere.transform.position, this.GrabSpot.position) > 0.100000001490116)
      this.Prompt.Yandere.MoveTowardsTarget(this.GrabSpot.position);
    else
      this.Prompt.Yandere.transform.position = this.GrabSpot.position;
    if ((double) Input.GetAxis("Horizontal") > 0.5 || (double) Input.GetAxis("DpadX") > 0.5 || Input.GetKey("right"))
      this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.transform.parent.transform.position.z - Time.deltaTime);
    else if ((double) Input.GetAxis("Horizontal") < -0.5 || (double) Input.GetAxis("DpadX") < -0.5 || Input.GetKey("left"))
      this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.transform.parent.transform.position.z + Time.deltaTime);
    if ((double) this.PullLimit < (double) this.PushLimit)
    {
      if ((double) this.transform.parent.transform.position.z < (double) this.PullLimit)
        this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.PullLimit);
      else if ((double) this.transform.parent.transform.position.z > (double) this.PushLimit)
        this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.PushLimit);
    }
    else if ((double) this.transform.parent.transform.position.z > (double) this.PullLimit)
      this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.PullLimit);
    else if ((double) this.transform.parent.transform.position.z < (double) this.PushLimit)
      this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.PushLimit);
    this.Panel.SetActive((double) this.DumpsterLid.transform.position.z > (double) this.DumpsterLid.DisposalSpot - 0.0500000007450581 && (double) this.DumpsterLid.transform.position.z < (double) this.DumpsterLid.DisposalSpot + 0.0500000007450581);
    if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers <= 0 && !Input.GetButtonDown("B"))
      return;
    this.StopGrabbing();
  }

  private void StopGrabbing()
  {
    this.Prompt.Yandere.DumpsterGrabbing = false;
    this.Prompt.Yandere.CanMove = true;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Panel.SetActive(false);
    this.Grabbed = false;
  }
}
