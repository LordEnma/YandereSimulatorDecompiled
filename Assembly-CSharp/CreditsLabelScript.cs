using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012FC RID: 4860 RVA: 0x000A82A8 File Offset: 0x000A64A8
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012FD RID: 4861 RVA: 0x000A82F8 File Offset: 0x000A64F8
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

	// Token: 0x04001B06 RID: 6918
	public float RotationSpeed;

	// Token: 0x04001B07 RID: 6919
	public float MovementSpeed;

	// Token: 0x04001B08 RID: 6920
	public float Rotation;
}
