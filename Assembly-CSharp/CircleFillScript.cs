using System;
using UnityEngine;

// Token: 0x02000248 RID: 584
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x06001256 RID: 4694 RVA: 0x0008D81C File Offset: 0x0008BA1C
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

	// Token: 0x04001738 RID: 5944
	public UISprite OsanaFill;

	// Token: 0x04001739 RID: 5945
	public UITexture OtherFill;

	// Token: 0x0400173A RID: 5946
	public UITexture Fill;

	// Token: 0x0400173B RID: 5947
	public float Speed;

	// Token: 0x0400173C RID: 5948
	public int Phase;
}
