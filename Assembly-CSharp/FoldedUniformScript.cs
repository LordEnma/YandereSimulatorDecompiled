// Decompiled with JetBrains decompiler
// Type: FoldedUniformScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FoldedUniformScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public GameObject SteamCloud;
  public bool ClubAttire;
  public bool InPosition = true;
  public bool Clean;
  public bool Spare;
  public float Timer;
  public int Type;
  public GameObject[] Uniforms;
  public Renderer[] MyRenderer;
  public Texture CleanTexture;
  public Texture EightiesTexture;
  public Texture BloodyEightiesTexture;

  private void Start()
  {
    for (int index = 1; index < this.Uniforms.Length; ++index)
      this.Uniforms[index].SetActive(false);
    if (this.Uniforms.Length != 0)
      this.Uniforms[StudentGlobals.FemaleUniform].SetActive(true);
    if ((Object) this.Prompt != (Object) null && (Object) this.Prompt.Yandere != (Object) null)
    {
      this.Yandere = this.Prompt.Yandere;
    }
    else
    {
      GameObject gameObject = GameObject.Find("YandereChan");
      if ((Object) gameObject != (Object) null)
        this.Yandere = gameObject.GetComponent<YandereScript>();
    }
    bool flag = false;
    if (this.Spare && !GameGlobals.SpareUniform)
    {
      Object.Destroy((Object) this.gameObject);
      flag = true;
    }
    if (!flag && this.Clean && (Object) this.Prompt.Button[0] != (Object) null)
    {
      this.Prompt.HideButton[0] = true;
      ++this.Yandere.StudentManager.NewUniforms;
      this.Yandere.StudentManager.UpdateStudents();
      this.Yandere.StudentManager.Uniforms[this.Yandere.StudentManager.NewUniforms] = this.transform;
      Debug.Log((object) ("A new uniform has been spawned. The number of ''New Uniforms'' at school is now " + this.Yandere.StudentManager.NewUniforms.ToString() + "."));
    }
    if (this.Type == 1)
      this.gameObject.name = "School Uniform";
    if (this.Type == 2)
      this.gameObject.name = "Swimsuit";
    else if (this.Type == 3)
      this.gameObject.name = "Gym Uniform";
    else
      this.gameObject.name = "Folded Club Uniform";
    if (!GameGlobals.Eighties || !((Object) this.BloodyEightiesTexture != (Object) null))
      return;
    for (int index = 1; index < this.MyRenderer.Length; ++index)
      this.MyRenderer[index].material.mainTexture = this.BloodyEightiesTexture;
  }

  private void Update()
  {
    if (!this.Clean)
      return;
    this.InPosition = this.Yandere.StudentManager.LockerRoomArea.bounds.Contains(this.transform.position);
    this.Prompt.HideButton[0] = (Object) this.Yandere.MyRenderer.sharedMesh != (Object) this.Yandere.Towel || (double) this.Yandere.Bloodiness != 0.0 || !this.InPosition;
    if ((Object) this.Prompt.Circle[0] != (Object) null && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
      this.Yandere.CurrentUniformOrigin = 2;
      this.Yandere.Stripping = true;
      this.Yandere.CanMove = false;
      if (this.Type > 1)
      {
        this.Yandere.MyLocker.Bloody[this.Type] = false;
        this.Yandere.MyLocker.UpdateButtons();
      }
      this.Timer += Time.deltaTime;
    }
    if ((double) this.Timer > 0.0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.5)
      {
        this.Yandere.Schoolwear = this.Type;
        this.Yandere.ChangeSchoolwear();
        Object.Destroy((Object) this.gameObject);
      }
    }
    if (!((Object) this.CleanTexture != (Object) null) || !((Object) this.MyRenderer[1].material.mainTexture != (Object) this.CleanTexture))
      return;
    Debug.Log((object) ("My name is " + this.gameObject.name + " and for some reason I had the incorrect texture a moment ago."));
    for (int index = 1; index < this.MyRenderer.Length; ++index)
      this.MyRenderer[index].material.mainTexture = this.CleanTexture;
  }

  public void CleanUp()
  {
    Debug.Log((object) "A folded uniform is firing the ''CleanUp()'' function.");
    if (GameGlobals.Eighties && (Object) this.EightiesTexture != (Object) null)
      this.CleanTexture = this.EightiesTexture;
    this.Clean = true;
    for (int index = 1; index < this.MyRenderer.Length; ++index)
      this.MyRenderer[index].material.mainTexture = this.CleanTexture;
  }
}
