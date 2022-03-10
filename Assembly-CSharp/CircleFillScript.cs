using System;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x06001252 RID: 4690 RVA: 0x0008CDF0 File Offset: 0x0008AFF0
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

	// Token: 0x04001728 RID: 5928
	public UISprite OsanaFill;

	// Token: 0x04001729 RID: 5929
	public UITexture OtherFill;

	// Token: 0x0400172A RID: 5930
	public UITexture Fill;

	// Token: 0x0400172B RID: 5931
	public float Speed;

	// Token: 0x0400172C RID: 5932
	public int Phase;
}
