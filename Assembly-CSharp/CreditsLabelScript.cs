using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012ED RID: 4845 RVA: 0x000A7260 File Offset: 0x000A5460
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012EE RID: 4846 RVA: 0x000A72B0 File Offset: 0x000A54B0
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

	// Token: 0x04001ACB RID: 6859
	public float RotationSpeed;

	// Token: 0x04001ACC RID: 6860
	public float MovementSpeed;

	// Token: 0x04001ACD RID: 6861
	public float Rotation;
}
