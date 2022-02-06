using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012F5 RID: 4853 RVA: 0x000A7B58 File Offset: 0x000A5D58
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x000A7BA8 File Offset: 0x000A5DA8
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

	// Token: 0x04001AEE RID: 6894
	public float RotationSpeed;

	// Token: 0x04001AEF RID: 6895
	public float MovementSpeed;

	// Token: 0x04001AF0 RID: 6896
	public float Rotation;
}
