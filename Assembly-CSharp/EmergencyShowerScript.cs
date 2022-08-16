// Decompiled with JetBrains decompiler
// Type: EmergencyShowerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EmergencyShowerScript : MonoBehaviour
{
  public FoldedUniformScript CleanUniform;
  public SkinnedMeshRenderer Curtain;
  public TallLockerScript TallLocker;
  public GameObject CensorSteam;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform BatheSpot;
  public float OpenValue;
  public float Timer;
  public int Phase = 1;
  public bool Bathing;
  public AudioSource MyAudio;
  public AudioClip CurtainClose;
  public AudioClip CurtainOpen;
  public AudioClip ClothRustle;

  private void Update()
  {
    if (this.Yandere.Schoolwear == 2 && (double) this.Yandere.Bloodiness > 0.0 || this.Yandere.Schoolwear != 2 && (double) this.Yandere.Bloodiness > 0.0 && (Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Clothing && !this.Yandere.PickUp.Evidence && (Object) this.Yandere.PickUp.Gloves == (Object) null)
    {
      this.Prompt.HideButton[0] = false;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
        {
          this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
          this.Yandere.CannotBeSprayed = true;
          this.Yandere.CanMove = false;
          if ((Object) this.Yandere.PickUp != (Object) null)
          {
            this.CleanUniform = this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>();
            this.Yandere.EmptyHands();
            this.CleanUniform.transform.position = this.transform.position + this.transform.up + this.transform.forward * 1.5f;
          }
          AudioSource.PlayClipAtPoint(this.CurtainClose, this.transform.position);
          this.Bathing = true;
          this.Phase = 1;
          this.Timer = 0.0f;
        }
      }
    }
    else
      this.Prompt.HideButton[0] = true;
    if (!this.Bathing)
      return;
    this.Timer += Time.deltaTime;
    if (this.Phase == 1)
    {
      this.Yandere.MoveTowardsTarget(this.BatheSpot.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.BatheSpot.rotation, 10f * Time.deltaTime);
      this.OpenValue = Mathf.Lerp(this.OpenValue, 0.0f, Time.deltaTime * 10f);
      this.Curtain.SetBlendShapeWeight(1, this.OpenValue);
      if ((double) this.Timer <= 1.0)
        return;
      if (this.Yandere.Schoolwear != 2)
      {
        PickUpScript component;
        if (this.Yandere.ClubAttire)
        {
          component = Object.Instantiate<GameObject>(this.TallLocker.BloodyClubUniform[(int) this.Yandere.Club], this.Yandere.transform.position + this.Yandere.transform.forward + this.Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
          this.Yandere.StudentManager.ChangingBooths[(int) this.Yandere.Club].CannotChange = true;
          this.Yandere.StudentManager.ChangingBooths[(int) this.Yandere.Club].CheckYandereClub();
        }
        else
          component = Object.Instantiate<GameObject>(this.TallLocker.BloodyUniform[this.Yandere.Schoolwear], this.Yandere.transform.position + this.Yandere.transform.forward + this.Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
        AudioSource.PlayClipAtPoint(this.ClothRustle, this.transform.position);
        if (this.Yandere.RedPaint)
          component.RedPaint = true;
      }
      else
        ++this.Timer;
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      if ((double) this.Timer <= 2.0)
        return;
      this.CensorSteam.SetActive(true);
      this.MyAudio.Play();
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      if ((double) this.Timer <= 6.5)
        return;
      if (this.Yandere.Schoolwear != 2)
      {
        this.CleanUniform.Prompt.Hide();
        Object.Destroy((Object) this.CleanUniform.gameObject);
        --this.Yandere.StudentManager.NewUniforms;
        this.Yandere.ClubAttire = false;
        this.Yandere.Schoolwear = 1;
        this.Yandere.ChangeSchoolwear();
        AudioSource.PlayClipAtPoint(this.ClothRustle, this.transform.position);
      }
      else
      {
        --this.Yandere.Police.BloodyClothing;
        ++this.Timer;
      }
      this.Yandere.Bloodiness = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 4)
    {
      if ((double) this.Timer <= 7.5)
        return;
      AudioSource.PlayClipAtPoint(this.CurtainOpen, this.transform.position);
      ++this.Phase;
    }
    else
    {
      this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
      this.Curtain.SetBlendShapeWeight(1, this.OpenValue);
      if ((double) this.Timer <= 8.5)
        return;
      Debug.Log((object) ("As of now, # of OriginalUniforms is: " + this.Yandere.StudentManager.OriginalUniforms.ToString() + " and # of NewUniforms is: " + this.Yandere.StudentManager.NewUniforms.ToString()));
      this.CensorSteam.SetActive(false);
      this.Yandere.CannotBeSprayed = false;
      this.Yandere.CanMove = true;
      this.Bathing = false;
    }
  }
}
