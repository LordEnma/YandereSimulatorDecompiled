// Decompiled with JetBrains decompiler
// Type: OsanaReleaseDateScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OsanaReleaseDateScript : MonoBehaviour
{
  public UISprite[] BlackRectangles;
  public bool ChooseRectangle = true;
  public int LettersRevealed;
  public int RandomID;

  private void Start()
  {
    Time.timeScale = 1f;
    foreach (UISprite blackRectangle in this.BlackRectangles)
    {
      if ((Object) blackRectangle != (Object) null)
        blackRectangle.alpha = 1f;
    }
  }

  private void Update()
  {
    if (Input.GetKeyDown("-"))
      --Time.timeScale;
    if (Input.GetKeyDown("="))
      ++Time.timeScale;
    if (this.ChooseRectangle)
    {
      if (this.LettersRevealed < 33)
      {
        this.RandomID = Random.Range(1, this.BlackRectangles.Length);
        while ((double) this.BlackRectangles[this.RandomID].alpha == 0.0 || this.RandomID > 28 && this.RandomID < 34)
          this.RandomID = Random.Range(1, this.BlackRectangles.Length);
      }
      else
      {
        this.RandomID = Random.Range(28, 34);
        while ((double) this.BlackRectangles[this.RandomID].alpha == 0.0)
          this.RandomID = Random.Range(1, this.BlackRectangles.Length);
      }
      this.ChooseRectangle = false;
    }
    else
    {
      this.BlackRectangles[this.RandomID].alpha = Mathf.MoveTowards(this.BlackRectangles[this.RandomID].alpha, 0.0f, Time.deltaTime * 0.6333333f);
      if ((double) this.BlackRectangles[this.RandomID].alpha != 0.0)
        return;
      ++this.LettersRevealed;
      if (this.LettersRevealed < 38)
        this.ChooseRectangle = true;
      else
        this.enabled = false;
    }
  }
}
