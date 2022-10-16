// Decompiled with JetBrains decompiler
// Type: DelinquentVoicesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DelinquentVoicesScript : MonoBehaviour
{
  public YandereScript Yandere;
  public RadioScript Radio;
  public SubtitleScript Subtitle;
  public float Timer;
  public int RandomID;
  public int LastID;

  private void Start()
  {
    if (GameGlobals.Eighties)
      this.enabled = false;
    else if (PlayerGlobals.GetStudentFriend(76) || PlayerGlobals.GetStudentFriend(77) || PlayerGlobals.GetStudentFriend(78) || PlayerGlobals.GetStudentFriend(79) || PlayerGlobals.GetStudentFriend(80))
      this.gameObject.SetActive(false);
    this.Timer = 5f;
  }

  private void Update()
  {
    if ((Object) this.Radio != (Object) null)
    {
      if (!this.Radio.MyAudio.isPlaying || !this.Yandere.CanMove || (double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) >= 5.0)
        return;
      this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
      if ((double) this.Timer != 0.0 || this.Yandere.Club == ClubType.Delinquent)
        return;
      if ((Object) this.Yandere.Container != (Object) null && this.Yandere.Container.CelloCase)
      {
        while (this.RandomID == this.LastID)
          this.RandomID = Random.Range(0, this.Subtitle.DelinquentCaseClips.Length);
        this.LastID = this.RandomID;
        this.Subtitle.UpdateLabel(SubtitleType.DelinquentCase, this.RandomID, 3f);
      }
      else
      {
        while (this.RandomID == this.LastID)
          this.RandomID = Random.Range(0, this.Subtitle.DelinquentAnnoyClips.Length);
        this.LastID = this.RandomID;
        this.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, this.RandomID, 3f);
      }
      this.Timer = 5f;
    }
    else
      Object.Destroy((Object) this.gameObject);
  }
}
