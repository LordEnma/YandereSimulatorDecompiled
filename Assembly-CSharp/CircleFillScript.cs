using System;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x06001251 RID: 4689 RVA: 0x0008CAC8 File Offset: 0x0008ACC8
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

	// Token: 0x0400171E RID: 5918
	public UISprite OsanaFill;

	// Token: 0x0400171F RID: 5919
	public UITexture OtherFill;

	// Token: 0x04001720 RID: 5920
	public UITexture Fill;

	// Token: 0x04001721 RID: 5921
	public float Speed;

	// Token: 0x04001722 RID: 5922
	public int Phase;
}
