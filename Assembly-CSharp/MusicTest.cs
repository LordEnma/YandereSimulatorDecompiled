using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MusicTest : MonoBehaviour
{
	// Token: 0x060019D2 RID: 6610 RVA: 0x00108EF4 File Offset: 0x001070F4
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

	// Token: 0x060019D3 RID: 6611 RVA: 0x00108FAC File Offset: 0x001071AC
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

	// Token: 0x0400296A RID: 10602
	public float[] freqData;

	// Token: 0x0400296B RID: 10603
	public AudioSource MainSong;

	// Token: 0x0400296C RID: 10604
	public float[] band;

	// Token: 0x0400296D RID: 10605
	public GameObject[] g;
}
