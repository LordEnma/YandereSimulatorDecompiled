using System;
using UnityEngine;

// Token: 0x02000267 RID: 615
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x06001303 RID: 4867 RVA: 0x000A8BB0 File Offset: 0x000A6DB0
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x06001304 RID: 4868 RVA: 0x000A8C00 File Offset: 0x000A6E00
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

	// Token: 0x04001B19 RID: 6937
	public float RotationSpeed;

	// Token: 0x04001B1A RID: 6938
	public float MovementSpeed;

	// Token: 0x04001B1B RID: 6939
	public float Rotation;
}
