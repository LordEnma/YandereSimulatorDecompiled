// Decompiled with JetBrains decompiler
// Type: MusicTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicTest : MonoBehaviour
{
  public float[] freqData;
  public AudioSource MainSong;
  public float[] band;
  public GameObject[] g;

  private void Start()
  {
    int length = this.freqData.Length;
    int num = 0;
    for (int index = 0; index < this.freqData.Length; ++index)
    {
      length /= 2;
      if (length != 0)
        ++num;
      else
        break;
    }
    this.band = new float[num + 1];
    this.g = new GameObject[num + 1];
    for (int x = 0; x < this.band.Length; ++x)
    {
      this.band[x] = 0.0f;
      this.g[x] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      this.g[x].transform.position = new Vector3((float) x, 0.0f, 0.0f);
    }
    this.InvokeRepeating("check", 0.0f, 0.0333333351f);
  }

  private void check()
  {
    this.GetComponent<AudioSource>().GetSpectrumData(this.freqData, 0, FFTWindow.Rectangular);
    int index1 = 0;
    int num1 = 2;
    for (int index2 = 0; index2 < this.freqData.Length; ++index2)
    {
      float num2 = this.freqData[index2];
      float num3 = this.band[index1];
      this.band[index1] = (double) num2 > (double) num3 ? num2 : num3;
      if (index2 > num1 - 3)
      {
        ++index1;
        num1 *= 2;
        Transform transform = this.g[index1].transform;
        transform.position = new Vector3(transform.position.x, this.band[index1] * 32f, transform.position.z);
        this.band[index1] = 0.0f;
      }
    }
  }
}
