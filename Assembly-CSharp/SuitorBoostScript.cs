// Decompiled with JetBrains decompiler
// Type: SuitorBoostScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SuitorBoostScript : MonoBehaviour
{
  public LoveManagerScript LoveManager;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public UISprite Darkness;
  public UILabel Label;
  public Transform YandereSitSpot;
  public Transform SuitorSitSpot;
  public Transform YandereChair;
  public Transform SuitorChair;
  public Transform YandereSpot;
  public Transform SuitorSpot;
  public Transform LookTarget;
  public Transform TextBox;
  public Transform BoostSpot;
  public bool TaughtSuitor;
  public bool TimeSkipping;
  public bool Boosting;
  public bool FadeOut;
  public float Timer;
  public string BoostText;
  public int TraitID = 2;
  public int Phase = 1;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        if (!this.TaughtSuitor)
        {
          if (this.Yandere.Followers > 0 && this.Yandere.Follower.StudentID == this.LoveManager.SuitorID && (double) this.Yandere.Follower.DistanceToPlayer < 2.0)
          {
            this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
            this.Yandere.RPGCamera.enabled = false;
            this.Yandere.CanMove = false;
            this.Yandere.Follower.CharacterAnimation.CrossFade(this.Yandere.Follower.IdleAnim);
            this.Yandere.Follower.Pathfinding.canSearch = false;
            this.Yandere.Follower.Pathfinding.canMove = false;
            this.Yandere.Follower.enabled = false;
            this.Darkness.enabled = true;
            this.Boosting = true;
            this.FadeOut = true;
            this.Label.text = this.BoostText;
          }
          else
          {
            this.Yandere.NotificationManager.CustomText = "your rival and bring him here.";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            this.Yandere.NotificationManager.CustomText = "Find a boy who has a crush on";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
        else
        {
          this.Yandere.NotificationManager.CustomText = "Can't! You already did that today!";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
      else
      {
        this.Yandere.NotificationManager.CustomText = "Can't! You're being chased!";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
    if (!this.Boosting)
      return;
    if (this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a <= 0.99900001287460327)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      if (this.Phase == 1)
      {
        this.Yandere.MainCamera.transform.position = this.BoostSpot.position;
        this.Yandere.MainCamera.transform.eulerAngles = this.BoostSpot.eulerAngles;
        this.Yandere.Follower.Character.transform.localScale = new Vector3(1f, 1f, 1f);
        if (this.TraitID == 1)
        {
          this.Yandere.Follower.CharacterAnimation.Play("paranoidIdle_00");
          this.Yandere.transform.position = this.YandereSpot.position;
          this.Yandere.transform.eulerAngles = this.YandereSpot.eulerAngles;
          this.Yandere.Follower.transform.position = this.SuitorSpot.position;
          this.Yandere.Follower.transform.eulerAngles = this.SuitorSpot.eulerAngles;
        }
        else if (this.TraitID == 2)
        {
          this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.6f);
          this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.6f);
          this.Yandere.CharacterAnimation.Play("f02_sit_01");
          this.Yandere.Follower.CharacterAnimation.Play("sit_01");
          this.Yandere.transform.eulerAngles = Vector3.zero;
          this.Yandere.Follower.transform.eulerAngles = Vector3.zero;
          this.Yandere.transform.position = this.YandereSitSpot.position;
          this.Yandere.Follower.transform.position = this.SuitorSitSpot.position;
        }
        else if (this.TraitID == 3)
        {
          this.Yandere.Follower.CharacterAnimation.Play("stretch_00_loop");
          this.Yandere.transform.position = this.YandereSpot.position;
          this.Yandere.transform.eulerAngles = this.YandereSpot.eulerAngles;
          this.Yandere.Follower.transform.position = this.SuitorSpot.position;
          this.Yandere.Follower.transform.eulerAngles = this.SuitorSpot.eulerAngles;
        }
      }
      else
      {
        this.Yandere.FixCamera();
        this.Yandere.Follower.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
        if (this.TraitID == 2)
        {
          this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.333333343f);
          this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.333333343f);
        }
        this.Yandere.CharacterAnimation.Play(this.Yandere.IdleAnim);
        this.Yandere.Follower.CharacterAnimation.Play(this.Yandere.Follower.IdleAnim);
        this.Yandere.transform.position = this.YandereSpot.position;
        this.Yandere.Follower.transform.position = this.SuitorSpot.position;
      }
      this.PromptBar.ClearButtons();
      this.FadeOut = false;
      ++this.Phase;
    }
    else
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a >= 1.0 / 1000.0)
        return;
      if (this.Phase == 2)
      {
        this.TextBox.gameObject.SetActive(true);
        this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if ((double) this.TextBox.localScale.x <= 0.89999997615814209)
          return;
        if (!this.PromptBar.Show)
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
        }
        if (!Input.GetButtonDown("A"))
          return;
        this.PromptBar.Show = false;
        ++this.Phase;
      }
      else if (this.Phase == 3)
      {
        if ((double) this.TextBox.localScale.x > 0.10000000149011612)
        {
          this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, Vector3.zero, Time.deltaTime * 10f);
        }
        else
        {
          this.TextBox.gameObject.SetActive(false);
          this.FadeOut = true;
          ++this.Phase;
        }
      }
      else
      {
        if (this.Phase != 5)
          return;
        this.Yandere.StudentManager.DatingMinigame.DataNeedsSaving = true;
        ++this.Yandere.StudentManager.DatingMinigame.Trait[this.TraitID];
        if (this.TraitID == 1)
          ++this.Yandere.StudentManager.DatingMinigame.CourageTrait;
        else if (this.TraitID == 2)
          ++this.Yandere.StudentManager.DatingMinigame.WisdomTrait;
        else if (this.TraitID == 3)
          ++this.Yandere.StudentManager.DatingMinigame.StrengthTrait;
        this.Yandere.RPGCamera.enabled = true;
        this.Darkness.enabled = false;
        this.Yandere.CanMove = true;
        this.Boosting = false;
        this.Yandere.Follower.Pathfinding.canSearch = true;
        this.Yandere.Follower.Pathfinding.canMove = true;
        this.Yandere.Follower.enabled = true;
        this.TaughtSuitor = true;
      }
    }
  }

  private void LateUpdate()
  {
    if (this.TraitID != 2 || !this.Boosting || this.Phase <= 1 || this.Phase >= 5)
      return;
    this.Yandere.Head.LookAt(this.LookTarget);
    this.Yandere.Follower.Head.LookAt(this.LookTarget);
  }
}
