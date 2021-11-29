using System;
using UnityEngine;

// Token: 0x02000246 RID: 582
public class CircleFillScript : MonoBehaviour
{
	// Token: 0x0600124E RID: 4686 RVA: 0x0008C84C File Offset: 0x0008AA4C
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

	// Token: 0x04001717 RID: 5911
	public UISprite OsanaFill;

	// Token: 0x04001718 RID: 5912
	public UITexture OtherFill;

	// Token: 0x04001719 RID: 5913
	public UITexture Fill;

	// Token: 0x0400171A RID: 5914
	public float Speed;

	// Token: 0x0400171B RID: 5915
	public int Phase;
}
