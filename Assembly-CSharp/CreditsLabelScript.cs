using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012FD RID: 4861 RVA: 0x000A84D0 File Offset: 0x000A66D0
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012FE RID: 4862 RVA: 0x000A8520 File Offset: 0x000A6720
	private void Update()
	{
		this.Rotation += Time.deltaTime * this.RotationSpeed;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + Time.deltaTime * this.MovementSpeed, base.transform.localPosition.z);
		if (this.Rotation > 90f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001B0A RID: 6922
	public float RotationSpeed;

	// Token: 0x04001B0B RID: 6923
	public float MovementSpeed;

	// Token: 0x04001B0C RID: 6924
	public float Rotation;
}
