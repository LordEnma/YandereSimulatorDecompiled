// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.CharacterHairPlacer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

namespace MaidDereMinigame
{
  public class CharacterHairPlacer : MonoBehaviour
  {
    public Sprite[] hairSprites;
    [HideInInspector]
    public SpriteRenderer hairInstance;

    private void Awake()
    {
      int index = UnityEngine.Random.Range(0, this.hairSprites.Length);
      this.hairInstance = new GameObject("Hair", new System.Type[1]
      {
        typeof (SpriteRenderer)
      }).GetComponent<SpriteRenderer>();
      Transform transform = this.hairInstance.transform;
      transform.parent = this.transform;
      transform.localPosition = new Vector3(0.0f, 0.0f, -0.1f);
      this.hairInstance.sprite = this.hairSprites[index];
    }

    public void WalkPose(float height) => this.hairInstance.transform.localPosition = new Vector3(0.0f, height, this.hairInstance.transform.localPosition.z);

    public void HairPose(string point)
    {
      string[] strArray = point.Split(',');
      float result1;
      float result2;
      if (float.TryParse(strArray[0], NumberStyles.Float, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result1) & float.TryParse(strArray[1], NumberStyles.Float, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result2))
        this.hairInstance.transform.localPosition = new Vector3(this.hairInstance.flipX ? -result1 : result1, result2, this.hairInstance.transform.localPosition.z);
      else
        Debug.Log((object) "There was an error while parsing the hair position in CharacterHairPlacer");
    }
  }
}
