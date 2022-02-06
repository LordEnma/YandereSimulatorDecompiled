using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MusicTest : MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x001082A0 File Offset: 0x001064A0
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

	// Token: 0x060019C3 RID: 6595 RVA: 0x00108358 File Offset: 0x00106558
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

	// Token: 0x04002955 RID: 10581
	public float[] freqData;

	// Token: 0x04002956 RID: 10582
	public AudioSource MainSong;

	// Token: 0x04002957 RID: 10583
	public float[] band;

	// Token: 0x04002958 RID: 10584
	public GameObject[] g;
}
