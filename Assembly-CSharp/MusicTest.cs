using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MusicTest : MonoBehaviour
{
	// Token: 0x060019E0 RID: 6624 RVA: 0x0010A2BC File Offset: 0x001084BC
	private void Start()
	{
		int num = this.freqData.Length;
		int num2 = 0;
		for (int i = 0; i < this.freqData.Length; i++)
		{
			num /= 2;
			if (num == 0)
			{
				break;
			}
			num2++;
		}
		this.band = new float[num2 + 1];
		this.g = new GameObject[num2 + 1];
		for (int j = 0; j < this.band.Length; j++)
		{
			this.band[j] = 0f;
			this.g[j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			this.g[j].transform.position = new Vector3((float)j, 0f, 0f);
		}
		base.InvokeRepeating("check", 0f, 0.033333335f);
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x0010A374 File Offset: 0x00108574
	private void check()
	{
		base.GetComponent<AudioSource>().GetSpectrumData(this.freqData, 0, FFTWindow.Rectangular);
		int num = 0;
		int num2 = 2;
		for (int i = 0; i < this.freqData.Length; i++)
		{
			float num3 = this.freqData[i];
			float num4 = this.band[num];
			this.band[num] = ((num3 > num4) ? num3 : num4);
			if (i > num2 - 3)
			{
				num++;
				num2 *= 2;
				Transform transform = this.g[num].transform;
				transform.position = new Vector3(transform.position.x, this.band[num] * 32f, transform.position.z);
				this.band[num] = 0f;
			}
		}
	}

	// Token: 0x040029B5 RID: 10677
	public float[] freqData;

	// Token: 0x040029B6 RID: 10678
	public AudioSource MainSong;

	// Token: 0x040029B7 RID: 10679
	public float[] band;

	// Token: 0x040029B8 RID: 10680
	public GameObject[] g;
}
