// Decompiled with JetBrains decompiler
// Type: ChangingBoothScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChangingBoothScript : MonoBehaviour
{
  public YandereScript Yandere;
  public StudentScript Student;
  public PromptScript Prompt;
  public SkinnedMeshRenderer Curtains;
  public Transform ExitSpot;
  public Transform[] WaitSpots;
  public bool YandereChanging;
  public bool CannotChange;
  public bool Occupied;
  public AudioSource MyAudioSource;
  public AudioClip CurtainSound;
  public AudioClip ClothSound;
  public float OccupyTimer;
  public float Weight;
  public ClubType ClubID;
  public int Phase;

  private void Start()
  {
    if ((Object) this.Curtains == (Object) null)
      Debug.Log((object) this.gameObject.name);
    this.Curtains.SetBlendShapeWeight(1, 100f);
    this.CheckYandereClub();
  }

  private void Update()
  {
    if (!this.Occupied && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.EmptyHands();
      this.Yandere.CanMove = false;
      this.YandereChanging = true;
      this.Occupied = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (!this.Occupied)
      return;
    if ((double) this.OccupyTimer == 0.0)
    {
      if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0)
      {
        this.MyAudioSource.clip = this.CurtainSound;
        this.MyAudioSource.Play();
      }
    }
    else if ((double) this.OccupyTimer > 1.0 && this.Phase == 0)
    {
      if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0)
      {
        this.MyAudioSource.clip = this.ClothSound;
        this.MyAudioSource.Play();
      }
      ++this.Phase;
    }
    this.OccupyTimer += Time.deltaTime;
    if (this.YandereChanging)
    {
      if ((double) this.OccupyTimer < 2.0)
      {
        this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
        this.Weight = Mathf.Lerp(this.Weight, 0.0f, Time.deltaTime * 10f);
        this.Curtains.SetBlendShapeWeight(1, this.Weight);
        this.Yandere.MoveTowardsTarget(this.transform.position);
      }
      else if ((double) this.OccupyTimer < 3.0)
      {
        this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
        this.Curtains.SetBlendShapeWeight(1, this.Weight);
        if (this.Phase < 2)
        {
          this.MyAudioSource.clip = this.CurtainSound;
          this.MyAudioSource.Play();
          if (!this.Yandere.ClubAttire)
            this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
          this.Yandere.ChangeClubwear();
          ++this.Phase;
        }
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.transform.rotation, 10f * Time.deltaTime);
        this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
      }
      else
      {
        this.YandereChanging = false;
        this.Yandere.CanMove = true;
        this.Prompt.enabled = true;
        this.Occupied = false;
        this.OccupyTimer = 0.0f;
        this.Phase = 0;
      }
    }
    else if ((double) this.OccupyTimer < 2.0)
    {
      this.Weight = Mathf.Lerp(this.Weight, 0.0f, Time.deltaTime * 10f);
      this.Curtains.SetBlendShapeWeight(1, this.Weight);
    }
    else if ((double) this.OccupyTimer < 3.0)
    {
      this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
      this.Curtains.SetBlendShapeWeight(1, this.Weight);
      if (this.Phase >= 2)
        return;
      if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0)
      {
        this.MyAudioSource.clip = this.CurtainSound;
        this.MyAudioSource.Play();
      }
      this.Student.ChangeClubwear();
      ++this.Phase;
    }
    else
    {
      this.Student.WalkAnim = this.Student.OriginalWalkAnim;
      this.Occupied = false;
      this.OccupyTimer = 0.0f;
      this.Student = (StudentScript) null;
      this.Phase = 0;
      this.CheckYandereClub();
    }
  }

  public void CheckYandereClub()
  {
    if (this.Yandere.Club != this.ClubID)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    else if ((double) this.Yandere.Bloodiness == 0.0 && !this.CannotChange && this.Yandere.Schoolwear > 0)
    {
      if (!this.Occupied)
      {
        this.Prompt.enabled = true;
      }
      else
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }
}
