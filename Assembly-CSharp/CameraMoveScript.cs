using System;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600212F RID: 8495 RVA: 0x001E673D File Offset: 0x001E493D
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x001E676C File Offset: 0x001E496C
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

	// Token: 0x06002131 RID: 8497 RVA: 0x001E68FF File Offset: 0x001E4AFF
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048D2 RID: 18642
	public Transform StartPos;

	// Token: 0x040048D3 RID: 18643
	public Transform EndPos;

	// Token: 0x040048D4 RID: 18644
	public Transform RightDoor;

	// Token: 0x040048D5 RID: 18645
	public Transform LeftDoor;

	// Token: 0x040048D6 RID: 18646
	public Transform Target;

	// Token: 0x040048D7 RID: 18647
	public bool OpenDoors;

	// Token: 0x040048D8 RID: 18648
	public bool Begin;

	// Token: 0x040048D9 RID: 18649
	public float Speed;

	// Token: 0x040048DA RID: 18650
	public float Timer;
}
