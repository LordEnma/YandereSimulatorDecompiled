using System;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x06001254 RID: 4692 RVA: 0x0008D254 File Offset: 0x0008B454
	private void Update()
	{
		this.Speed += Time.deltaTime;
		this.Fill.transform.localPosition = Vector3.Lerp(this.Fill.transform.localPosition, new Vector3(-1024f, 0f, 0f), Time.deltaTime * this.Speed);
		if (this.Fill.transform.localPosition.x < -1023f)
		{
			if (this.Phase == 0)
			{
				this.Phase++;
				this.Speed = 0f;
			}
			this.Fill.fillAmount = Mathf.Lerp(this.Fill.fillAmount, 1f, Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x0400172F RID: 5935
	public UISprite OsanaFill;

	// Token: 0x04001730 RID: 5936
	public UITexture OtherFill;

	// Token: 0x04001731 RID: 5937
	public UITexture Fill;

	// Token: 0x04001732 RID: 5938
	public float Speed;

	// Token: 0x04001733 RID: 5939
	public int Phase;
}
