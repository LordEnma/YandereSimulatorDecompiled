// Decompiled with JetBrains decompiler
// Type: AboutScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AboutScript : MonoBehaviour
{
  public Transform[] Labels;
  public bool[] SlideOut;
  public bool[] SlideIn;
  public UILabel LinkLabel;
  public UITexture Yuno1;
  public UITexture Yuno2;
  public int SlideID;
  public int ID;
  public float Timer;

  private void Start()
  {
    foreach (Transform label in this.Labels)
    {
      Vector3 localPosition = label.localPosition with
      {
        x = 2000f
      };
      label.localPosition = localPosition;
    }
  }

  private void Update()
  {
    if (Input.GetButtonDown("A"))
    {
      if (this.SlideID < this.Labels.Length)
        this.SlideIn[this.SlideID] = true;
      ++this.SlideID;
    }
    if (this.SlideID < this.Labels.Length + 1)
    {
      for (this.ID = 0; this.ID < this.Labels.Length; ++this.ID)
      {
        if (this.SlideIn[this.ID])
        {
          Transform label = this.Labels[this.ID];
          Vector3 localPosition = label.localPosition;
          localPosition.x = Mathf.Lerp(localPosition.x, 0.0f, Time.deltaTime);
          label.localPosition = localPosition;
        }
      }
    }
    else
    {
      this.Timer += Time.deltaTime * 10f;
      for (this.ID = 0; this.ID < this.Labels.Length; ++this.ID)
      {
        if ((double) this.Timer > (double) this.ID)
        {
          this.SlideOut[this.ID] = true;
          Transform label = this.Labels[this.ID];
          Vector3 localPosition = label.localPosition;
          if ((double) localPosition.x > 0.0)
          {
            localPosition.x = -0.1f;
            label.localPosition = localPosition;
          }
        }
      }
      for (this.ID = 0; this.ID < this.Labels.Length; ++this.ID)
      {
        if (this.SlideOut[this.ID])
        {
          Transform label = this.Labels[this.ID];
          Vector3 localPosition = label.localPosition;
          localPosition.x += localPosition.x * 0.01f;
          label.localPosition = localPosition;
        }
      }
      if (this.SlideID > this.Labels.Length + 1)
      {
        Color color = this.LinkLabel.color;
        color.a += Time.deltaTime;
        this.LinkLabel.color = color;
      }
      if (this.SlideID > this.Labels.Length + 2)
      {
        Color color = this.Yuno1.color;
        color.a += Time.deltaTime;
        this.Yuno1.color = color;
      }
      if (this.SlideID <= this.Labels.Length + 3)
        return;
      Color color1 = this.Yuno2.color;
      color1.a += Time.deltaTime;
      this.Yuno2.color = color1;
      Vector3 localScale = this.Yuno2.transform.localScale;
      localScale.x += Time.deltaTime * 0.1f;
      localScale.y += Time.deltaTime * 0.1f;
      this.Yuno2.transform.localScale = localScale;
    }
  }
}
