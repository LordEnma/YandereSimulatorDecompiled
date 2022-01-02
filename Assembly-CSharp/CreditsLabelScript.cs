using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012F4 RID: 4852 RVA: 0x000A7908 File Offset: 0x000A5B08
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x000A7958 File Offset: 0x000A5B58
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

	// Token: 0x04001AE6 RID: 6886
	public float RotationSpeed;

	// Token: 0x04001AE7 RID: 6887
	public float MovementSpeed;

	// Token: 0x04001AE8 RID: 6888
	public float Rotation;
}
