using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SlowMoScript : MonoBehaviour
{
	// Token: 0x06001CBC RID: 7356 RVA: 0x00155224 File Offset: 0x00153424
	private void Update()
	{
		if (Input.GetKeyDown("s"))
		{
			this.Spinning = !this.Spinning;
		}
		if (Input.GetKeyDown("a"))
		{
			Time.timeScale = 0.1f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("z"))
		{
			this.Speed += Time.deltaTime;
		}
		if (this.Speed > 0f)
		{
			base.transform.position += new Vector3(Time.deltaTime * 0.1f, 0f, Time.deltaTime * 0.1f);
		}
		if (this.Spinning)
		{
			base.transform.parent.transform.localEulerAngles += new Vector3(0f, Time.deltaTime * 36f, 0f);
		}
	}

	// Token: 0x040033A2 RID: 13218
	public bool Spinning;

	// Token: 0x040033A3 RID: 13219
	public float Speed;
}
