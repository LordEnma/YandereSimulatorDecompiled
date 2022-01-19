using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600213C RID: 8508 RVA: 0x001E7DAD File Offset: 0x001E5FAD
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x001E7DDC File Offset: 0x001E5FDC
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

	// Token: 0x0600213E RID: 8510 RVA: 0x001E7F6F File Offset: 0x001E616F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048ED RID: 18669
	public Transform StartPos;

	// Token: 0x040048EE RID: 18670
	public Transform EndPos;

	// Token: 0x040048EF RID: 18671
	public Transform RightDoor;

	// Token: 0x040048F0 RID: 18672
	public Transform LeftDoor;

	// Token: 0x040048F1 RID: 18673
	public Transform Target;

	// Token: 0x040048F2 RID: 18674
	public bool OpenDoors;

	// Token: 0x040048F3 RID: 18675
	public bool Begin;

	// Token: 0x040048F4 RID: 18676
	public float Speed;

	// Token: 0x040048F5 RID: 18677
	public float Timer;
}
