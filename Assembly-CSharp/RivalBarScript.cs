// Decompiled with JetBrains decompiler
// Type: RivalBarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RivalBarScript : MonoBehaviour
{
  public int ID;
  public float Speed;
  public float Timer;
  public UISprite[] Bars;
  public float[] TargetHeights;

  private void Start()
  {
    for (int index = 1; index < 11; ++index)
      this.Bars[index].transform.localScale = new Vector3(1f, 0.0f, 1f);
  }

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.UpdateBars();
    this.Timer += Time.deltaTime;
    if (this.ID < 11)
    {
      if ((double) this.Timer > 1.0)
      {
        this.UpdateBars();
        this.Timer = 0.0f;
      }
    }
    else if ((double) this.Timer > 2.5)
    {
      this.UpdateBars();
      this.Timer = 0.0f;
    }
    for (int index = 1; index < this.ID; ++index)
    {
      this.Bars[index].transform.localScale = Vector3.Lerp(this.Bars[index].transform.localScale, new Vector3(1f, this.TargetHeights[index], 1f), Time.deltaTime * this.Speed);
      this.Bars[index].color = new Color(this.TargetHeights[index] / 7f, (float) (1.0 - (double) this.TargetHeights[index] / 7.0), 0.0f);
      if (index == 1)
      {
        float num = this.TargetHeights[index] / 7f;
        string str1 = num.ToString();
        num = (float) (1.0 - (double) this.TargetHeights[index] / 7.0);
        string str2 = num.ToString();
        Debug.Log((object) ("R is: " + str1 + " G is: " + str2));
      }
    }
  }

  private void UpdateBars()
  {
    int index = 1;
    if (this.ID < 11)
    {
      ++this.ID;
    }
    else
    {
      for (; index < this.ID; ++index)
        this.TargetHeights[index] = Random.Range(0.7f, 7f);
    }
  }
}
