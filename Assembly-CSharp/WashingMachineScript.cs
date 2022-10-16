// Decompiled with JetBrains decompiler
// Type: WashingMachineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WashingMachineScript : MonoBehaviour
{
  public GameObject CleanUniform;
  public GameObject Colliders;
  public GameObject Panel;
  public AudioSource MyAudio;
  public AudioClip OpenSFX;
  public AudioClip ShutSFX;
  public AudioClip WashSFX;
  public PromptScript Prompt;
  public Transform Tumbler;
  public Transform Door;
  public UILabel TimeLabel;
  public UISprite Circle;
  public float AnimationTimer;
  public float WashTimer;
  public float Rotation;
  public float Speed;
  public bool Washing;
  public bool Open;
  public PickUpScript[] ClothingList;
  public int ClothingInMachine;

  private void Start() => this.Panel.SetActive(false);

  private void Update()
  {
    if (!this.Washing)
    {
      if ((Object) this.Prompt != (Object) null && (Object) this.Prompt.Yandere != (Object) null)
        this.Prompt.HideButton[3] = !((Object) this.Prompt.Yandere.PickUp != (Object) null) || !this.Prompt.Yandere.PickUp.Clothing || !this.Prompt.Yandere.PickUp.Evidence;
    }
    else
    {
      this.Tumbler.Rotate(0.0f, 0.0f, 360f * Time.deltaTime, Space.Self);
      this.WashTimer -= Time.deltaTime;
      this.Circle.fillAmount = (float) (1.0 - (double) this.WashTimer / 60.0);
      double num = (double) Mathf.CeilToInt(this.WashTimer * 60f);
      this.TimeLabel.text = string.Format("{0:00}:{1:00}", (object) Mathf.Floor((float) (num / 60.0)), (object) (float) Mathf.RoundToInt((float) (num % 60.0)));
      if ((double) this.WashTimer <= 0.0)
      {
        for (int index = 0; index < this.ClothingList.Length; ++index)
        {
          if ((Object) this.ClothingList[index] != (Object) null)
          {
            if (this.ClothingList[index].gameObject.name == "Raincoat" || this.ClothingList[index].gameObject.name == "SilkGloves")
            {
              this.ClothingList[index].transform.position = this.transform.position + new Vector3(0.0f, 0.6f, -0.66666f);
              this.ClothingList[index].transform.localScale = new Vector3(1f, 1f, 1f);
              this.ClothingList[index].Evidence = false;
              this.ClothingList[index].gameObject.GetComponent<GloveScript>().Blood.enabled = false;
              if (this.ClothingList[index].gameObject.name == "Raincoat")
                this.Prompt.Yandere.CoatBloodiness = 0.0f;
              else
                this.Prompt.Yandere.GloveAttacher.newRenderer.material.mainTexture = this.Prompt.Yandere.GloveTexture;
              OutlineScript component = this.ClothingList[index].GetComponent<OutlineScript>();
              if ((Object) component != (Object) null)
                component.color = new Color(0.0f, 1f, 1f, 1f);
            }
            else if (this.ClothingList[index].gameObject.name == "Mask")
            {
              this.ClothingList[index].transform.position = this.transform.position + new Vector3(0.0f, 0.6f, -0.66666f);
              this.ClothingList[index].transform.localScale = new Vector3(1f, 1f, 1f);
              this.ClothingList[index].Evidence = false;
              this.ClothingList[index].gameObject.GetComponent<MaskScript>().Blood.enabled = false;
            }
            else
            {
              if (this.ClothingList[index].RedPaint)
              {
                --this.Prompt.Yandere.Police.RedPaintClothing;
                this.ClothingList[index].RedPaint = false;
              }
              FoldedUniformScript component = this.ClothingList[index].GetComponent<FoldedUniformScript>();
              Debug.Log((object) ("FoldedUniform is: " + ((object) component)?.ToString()));
              if ((Object) component != (Object) null && component.Type == 2 || (Object) component != (Object) null && component.Type == 3 || (Object) component != (Object) null && component.ClubAttire)
              {
                Debug.Log((object) "The player put something into the washing machine that was not a regular school uniform.");
                this.ClothingList[index].transform.position = this.transform.position + new Vector3(0.0f, 0.6f, -0.66666f);
                this.ClothingList[index].transform.localScale = new Vector3(1f, 1f, 1f);
                this.ClothingList[index].Evidence = false;
                component.CleanUp();
              }
              else
              {
                Object.Instantiate<GameObject>(this.CleanUniform, this.transform.position + new Vector3(0.0f, 0.6f, -0.66666f), Quaternion.identity);
                Object.Destroy((Object) this.ClothingList[index].gameObject);
              }
              component.gameObject.GetComponent<PickUpScript>().OriginalColor = new Color(0.0f, 1f, 1f, 1f);
              foreach (OutlineScript outlineScript in component.gameObject.GetComponent<PickUpScript>().Outline)
                outlineScript.color = new Color(0.0f, 1f, 1f, 1f);
            }
            --this.Prompt.Yandere.Police.BloodyClothing;
            this.ClothingList[index] = (PickUpScript) null;
          }
        }
        this.Prompt.Yandere.StudentManager.OriginalUniforms += this.ClothingInMachine;
        this.ClothingInMachine = 0;
        this.Colliders.SetActive(false);
        this.Panel.SetActive(false);
        this.Washing = false;
        this.MyAudio.clip = this.OpenSFX;
        this.MyAudio.loop = false;
        this.MyAudio.Play();
      }
    }
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      this.ClothingList[this.ClothingInMachine] = this.Prompt.Yandere.PickUp;
      this.Prompt.Yandere.EmptyHands();
      if (this.ClothingList[this.ClothingInMachine].gameObject.name == "Raincoat")
      {
        this.ClothingList[this.ClothingInMachine].transform.position = this.transform.position + new Vector3(0.0f, 0.475f, 0.11f);
        this.ClothingList[this.ClothingInMachine].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
      }
      else
        this.ClothingList[this.ClothingInMachine].transform.position = this.transform.position + new Vector3(0.0f, 0.6f, 0.1f);
      this.ClothingList[this.ClothingInMachine].MyRigidbody.isKinematic = false;
      this.ClothingList[this.ClothingInMachine].MyRigidbody.useGravity = true;
      this.ClothingList[this.ClothingInMachine].KeepGravity = true;
      ++this.ClothingInMachine;
      this.Colliders.SetActive(true);
      this.AnimationTimer = 2f;
      this.Speed = 0.0f;
      this.Open = true;
      this.Prompt.HideButton[0] = false;
      this.MyAudio.clip = this.OpenSFX;
      this.MyAudio.loop = false;
      this.MyAudio.Play();
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if ((double) this.AnimationTimer <= 0.0)
      {
        this.Prompt.HideButton[0] = true;
        this.Prompt.HideButton[3] = true;
        this.Panel.SetActive(true);
        this.WashTimer = 60f;
        this.Washing = true;
        this.MyAudio.clip = this.WashSFX;
        this.MyAudio.loop = true;
        this.MyAudio.Play();
      }
    }
    if ((double) this.AnimationTimer <= 0.0)
      return;
    this.AnimationTimer -= Time.deltaTime;
    if ((double) this.AnimationTimer < 1.0)
      this.Open = false;
    if (this.Open)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 125f, Time.deltaTime * 10f);
    }
    else
    {
      this.Speed += Time.deltaTime * 360f;
      this.Rotation = Mathf.MoveTowards(this.Rotation, 0.0f, Time.deltaTime * this.Speed);
      if ((double) this.Rotation == 0.0 && (Object) this.MyAudio.clip != (Object) this.ShutSFX)
      {
        this.MyAudio.clip = this.ShutSFX;
        this.MyAudio.loop = false;
        this.MyAudio.Play();
      }
    }
    this.Door.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
  }
}
