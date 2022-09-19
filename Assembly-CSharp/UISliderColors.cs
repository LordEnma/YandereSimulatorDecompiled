// Decompiled with JetBrains decompiler
// Type: UISliderColors
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
  public UISprite sprite;
  public Color[] colors = new Color[3]
  {
    Color.red,
    Color.yellow,
    Color.green
  };
  private UIProgressBar mBar;
  private UIBasicSprite mSprite;

  private void Start()
  {
    this.mBar = this.GetComponent<UIProgressBar>();
    this.mSprite = this.GetComponent<UIBasicSprite>();
    this.Update();
  }

  private void Update()
  {
    if ((Object) this.sprite == (Object) null || this.colors.Length == 0)
      return;
    float f = ((Object) this.mBar != (Object) null ? this.mBar.value : this.mSprite.fillAmount) * (float) (this.colors.Length - 1);
    int index = Mathf.FloorToInt(f);
    Color color = this.colors[0];
    if (index >= 0)
    {
      if (index + 1 < this.colors.Length)
      {
        float t = f - (float) index;
        color = Color.Lerp(this.colors[index], this.colors[index + 1], t);
      }
      else
        color = index >= this.colors.Length ? this.colors[this.colors.Length - 1] : this.colors[index];
    }
    color.a = this.sprite.color.a;
    this.sprite.color = color;
  }
}
