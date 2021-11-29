using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicTest : MonoBehaviour
{
	// Token: 0x060019B2 RID: 6578 RVA: 0x00106C14 File Offset: 0x00104E14
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

	// Token: 0x060019B3 RID: 6579 RVA: 0x00106CCC File Offset: 0x00104ECC
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

	// Token: 0x04002919 RID: 10521
	public float[] freqData;

	// Token: 0x0400291A RID: 10522
	public AudioSource MainSong;

	// Token: 0x0400291B RID: 10523
	public float[] band;

	// Token: 0x0400291C RID: 10524
	public GameObject[] g;
}
