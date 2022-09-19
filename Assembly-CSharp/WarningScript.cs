// Decompiled with JetBrains decompiler
// Type: WarningScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningScript : MonoBehaviour
{
  public float[] Triggers;
  public string[] Text;
  public UILabel WarningLabel;
  public UISprite Darkness;
  public UILabel Label;
  public bool FadeOut;
  public float Timer;
  public int ID;

  private void Start()
  {
    this.WarningLabel.gameObject.SetActive(false);
    this.Label.text = string.Empty;
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
  }

  private void Update()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if (!this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 0.0)
      {
        if ((double) this.Timer == 0.0)
        {
          this.WarningLabel.gameObject.SetActive(true);
          component.Play();
        }
        this.Timer += Time.deltaTime;
        if (this.ID < this.Triggers.Length && (double) this.Timer > (double) this.Triggers[this.ID])
        {
          this.Label.text = this.Text[this.ID];
          ++this.ID;
        }
      }
    }
    else
    {
      component.volume = Mathf.MoveTowards(component.volume, 0.0f, Time.deltaTime);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0)
        SceneManager.LoadScene("SponsorScene");
    }
    if (!Input.anyKey)
      return;
    this.FadeOut = true;
  }
}
