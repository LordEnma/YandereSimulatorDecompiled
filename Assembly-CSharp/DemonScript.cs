// Decompiled with JetBrains decompiler
// Type: DemonScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DemonScript : MonoBehaviour
{
  public SkinnedMeshRenderer Face;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public UILabel DemonSubtitle;
  public UISprite Darkness;
  public UISprite Button;
  public AudioClip MouthOpen;
  public AudioClip MouthClose;
  public AudioClip[] Clips;
  public string[] Lines;
  public bool Communing;
  public bool Open;
  public float Intensity = 1f;
  public float Value;
  public Color MyColor;
  public int DemonID;
  public int Phase = 1;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      this.Communing = true;
    }
    if (this.DemonID == 1)
    {
      if ((double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) < 2.5)
      {
        if (!this.Open)
          AudioSource.PlayClipAtPoint(this.MouthOpen, this.transform.position);
        this.Open = true;
      }
      else
      {
        if (this.Open)
          AudioSource.PlayClipAtPoint(this.MouthClose, this.transform.position);
        this.Open = false;
      }
      this.Value = !this.Open ? Mathf.Lerp(this.Value, 0.0f, Time.deltaTime * 10f) : Mathf.Lerp(this.Value, 100f, Time.deltaTime * 10f);
      this.Face.SetBlendShapeWeight(0, this.Value);
    }
    if (!this.Communing)
      return;
    AudioSource component = this.GetComponent<AudioSource>();
    if (this.Phase == 1)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a != 1.0)
        return;
      this.DemonSubtitle.transform.localPosition = Vector3.zero;
      this.DemonSubtitle.text = this.Lines[this.ID];
      this.DemonSubtitle.color = this.MyColor;
      this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0.0f);
      ++this.Phase;
      if (!((Object) this.Clips[this.ID] != (Object) null))
        return;
      component.clip = this.Clips[this.ID];
      component.Play();
    }
    else if (this.Phase == 2)
    {
      this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-this.Intensity, this.Intensity), Random.Range(-this.Intensity, this.Intensity), Random.Range(-this.Intensity, this.Intensity));
      this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
      this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 1f, Time.deltaTime));
      if ((double) this.DemonSubtitle.color.a <= 0.899999976158142 || !Input.GetButtonDown("A"))
        return;
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      this.DemonSubtitle.transform.localPosition = new Vector3(Random.Range(-this.Intensity, this.Intensity), Random.Range(-this.Intensity, this.Intensity), Random.Range(-this.Intensity, this.Intensity));
      this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0.0f, Time.deltaTime));
      if ((double) this.DemonSubtitle.color.a != 0.0)
        return;
      ++this.ID;
      if (this.ID < this.Lines.Length)
      {
        --this.Phase;
        this.DemonSubtitle.text = this.Lines[this.ID];
        if (!((Object) this.Clips[this.ID] != (Object) null))
          return;
        component.clip = this.Clips[this.ID];
        component.Play();
      }
      else
        ++this.Phase;
    }
    else
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a != 0.0)
        return;
      this.Yandere.CanMove = true;
      this.Communing = false;
      this.Phase = 1;
      this.ID = 0;
      SchoolGlobals.SetDemonActive(this.DemonID, true);
      StudentGlobals.FemaleUniform = 1;
      StudentGlobals.MaleUniform = 1;
      GameGlobals.Paranormal = true;
    }
  }
}
