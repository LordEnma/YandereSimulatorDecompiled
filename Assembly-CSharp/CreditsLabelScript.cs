using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012F9 RID: 4857 RVA: 0x000A7DEC File Offset: 0x000A5FEC
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x000A7E3C File Offset: 0x000A603C
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

	// Token: 0x04001AFB RID: 6907
	public float RotationSpeed;

	// Token: 0x04001AFC RID: 6908
	public float MovementSpeed;

	// Token: 0x04001AFD RID: 6909
	public float Rotation;
}
