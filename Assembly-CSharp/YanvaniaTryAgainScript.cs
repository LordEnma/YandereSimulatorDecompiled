// Decompiled with JetBrains decompiler
// Type: YanvaniaTryAgainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaTryAgainScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public GameObject ButtonEffect;
  public Transform Highlight;
  public UISprite Darkness;
  public bool FadeOut;
  public int Selected = 1;

  private void Start() => this.transform.localScale = Vector3.zero;

  private void Update()
  {
    if (!this.FadeOut)
    {
      if ((double) this.transform.localScale.x <= 0.89999997615814209)
        return;
      if (this.InputManager.TappedLeft)
        this.Selected = 1;
      if (this.InputManager.TappedRight)
        this.Selected = 2;
      if (this.Selected == 1)
      {
        this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
        this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, -1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
      }
      else
      {
        this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, 100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
        this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, 1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
      }
      if (!Input.GetButtonDown("A") && !Input.GetKeyDown("z") && !Input.GetKeyDown("x"))
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
      gameObject.transform.parent = this.Highlight;
      gameObject.transform.localPosition = Vector3.zero;
      this.FadeOut = true;
    }
    else
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if ((double) this.Darkness.color.a < 1.0)
        return;
      if (this.Selected == 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      else
        SceneManager.LoadScene("YanvaniaTitleScene");
    }
  }
}
