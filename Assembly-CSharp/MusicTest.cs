using UnityEngine;

public class MusicTest : MonoBehaviour
{
	public float[] freqData;

	public AudioSource MyAudioSource;

	public float[] band;

	public GameObject[] g;

	public GameObject EmptyTransform;

	private void Start()
	{
		int num = freqData.Length;
		int num2 = 0;
		for (int i = 0; i < freqData.Length; i++)
		{
			num /= 2;
			if (num == 0)
			{
				break;
			}
			num2++;
		}
		band = new float[num2 + 1];
		g = new GameObject[num2 + 1];
		for (int j = 0; j < band.Length; j++)
		{
			band[j] = 0f;
			g[j] = Object.Instantiate(EmptyTransform);
			g[j].transform.position = new Vector3(j, 0f, 0f);
		}
	}

	private void Update()
	{
		if (!(MyAudioSource != null) || !(MyAudioSource.clip != null))
		{
			return;
		}
		MyAudioSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
		int num = 0;
		int num2 = 2;
		for (int i = 0; i < freqData.Length; i++)
		{
			float num3 = freqData[i];
			float num4 = band[num];
			band[num] = ((num3 > num4) ? num3 : num4);
			if (i > num2 - 3)
			{
				num++;
				num2 *= 2;
				Transform transform = g[num].transform;
				transform.position = new Vector3(transform.position.x, band[num] * 32f, transform.position.z);
				band[num] = 0f;
			}
		}
	}
}
