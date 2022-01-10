using System;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x06001251 RID: 4689 RVA: 0x0008C9F4 File Offset: 0x0008ABF4
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

	// Token: 0x04001719 RID: 5913
	public UISprite OsanaFill;

	// Token: 0x0400171A RID: 5914
	public UITexture OtherFill;

	// Token: 0x0400171B RID: 5915
	public UITexture Fill;

	// Token: 0x0400171C RID: 5916
	public float Speed;

	// Token: 0x0400171D RID: 5917
	public int Phase;
}
