using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600211B RID: 8475 RVA: 0x001E4A19 File Offset: 0x001E2C19
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x001E4A48 File Offset: 0x001E2C48
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			this.Timer += Time.deltaTime * this.Speed;
			if (this.Timer > 0.1f)
			{
				this.OpenDoors = true;
				if (this.LeftDoor != null)
				{
					this.LeftDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.LeftDoor.transform.localPosition.x, 1f, Time.deltaTime), this.LeftDoor.transform.localPosition.y, this.LeftDoor.transform.localPosition.z);
					this.RightDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.RightDoor.transform.localPosition.x, -1f, Time.deltaTime), this.RightDoor.transform.localPosition.y, this.RightDoor.transform.localPosition.z);
				}
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
		}
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E4BDB File Offset: 0x001E2DDB
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x0400488A RID: 18570
	public Transform StartPos;

	// Token: 0x0400488B RID: 18571
	public Transform EndPos;

	// Token: 0x0400488C RID: 18572
	public Transform RightDoor;

	// Token: 0x0400488D RID: 18573
	public Transform LeftDoor;

	// Token: 0x0400488E RID: 18574
	public Transform Target;

	// Token: 0x0400488F RID: 18575
	public bool OpenDoors;

	// Token: 0x04004890 RID: 18576
	public bool Begin;

	// Token: 0x04004891 RID: 18577
	public float Speed;

	// Token: 0x04004892 RID: 18578
	public float Timer;
}
