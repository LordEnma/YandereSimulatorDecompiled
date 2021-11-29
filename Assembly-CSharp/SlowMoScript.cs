using System;
using UnityEngine;

// Token: 0x02000426 RID: 1062
public class SlowMoScript : MonoBehaviour
{
	// Token: 0x06001C94 RID: 7316 RVA: 0x001510D4 File Offset: 0x0014F2D4
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

	// Token: 0x0400332F RID: 13103
	public bool Spinning;

	// Token: 0x04003330 RID: 13104
	public float Speed;
}
