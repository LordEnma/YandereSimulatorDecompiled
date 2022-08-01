// Decompiled with JetBrains decompiler
// Type: AudioSoftwareScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AudioSoftwareScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Quaternion targetRotation;
  public Collider ChairCollider;
  public UILabel EventSubtitle;
  public GameObject Screen;
  public Transform SitSpot;
  public bool ConversationRecorded;
  public bool AudioDoctored;
  public bool Editing;
  public float Timer;

  private void Start() => this.Screen.SetActive(false);

  private void Update()
  {
    if (this.ConversationRecorded && this.Yandere.Inventory.RivalPhone)
    {
      if (!this.Prompt.enabled)
        this.Prompt.enabled = true;
    }
    else if (this.Prompt.enabled)
      this.Prompt.enabled = false;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
      this.Yandere.MyController.radius = 0.1f;
      this.Yandere.CanMove = false;
      this.GetComponent<AudioSource>().Play();
      this.ChairCollider.enabled = false;
      this.Screen.SetActive(true);
      this.Editing = true;
    }
    if (!this.Editing)
      return;
    this.Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
    this.targetRotation = Quaternion.LookRotation(new Vector3(this.Screen.transform.position.x, this.Yandere.transform.position.y, this.Screen.transform.position.z) - this.Yandere.transform.position);
    this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
    this.Yandere.MoveTowardsTarget(this.SitSpot.position);
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 1.0)
      this.EventSubtitle.text = "Okay, how 'bout that boy from class 3-2? What do you think of him?";
    if ((double) this.Timer > 7.0)
      this.EventSubtitle.text = "He's just my childhood friend.";
    if ((double) this.Timer > 9.0)
      this.EventSubtitle.text = "Is he your boyfriend?";
    if ((double) this.Timer > 11.0)
      this.EventSubtitle.text = "What? HIM? Ugh, no way! That guy's a total creep! I wouldn't date him if he was the last man alive on earth! He can go jump off a cliff for all I care!";
    if ((double) this.Timer <= 22.0)
      return;
    this.Yandere.MyController.radius = 0.2f;
    this.Yandere.CanMove = true;
    this.ChairCollider.enabled = true;
    this.EventSubtitle.text = "";
    this.Screen.SetActive(false);
    this.AudioDoctored = true;
    this.Editing = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.enabled = false;
  }
}
