using System;
using UnityEngine;

// Token: 0x0200051A RID: 1306
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002173 RID: 8563 RVA: 0x001EC53D File Offset: 0x001EA73D
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002174 RID: 8564 RVA: 0x001EC56C File Offset: 0x001EA76C
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

	// Token: 0x06002175 RID: 8565 RVA: 0x001EC6FF File Offset: 0x001EA8FF
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x04004996 RID: 18838
	public Transform StartPos;

	// Token: 0x04004997 RID: 18839
	public Transform EndPos;

	// Token: 0x04004998 RID: 18840
	public Transform RightDoor;

	// Token: 0x04004999 RID: 18841
	public Transform LeftDoor;

	// Token: 0x0400499A RID: 18842
	public Transform Target;

	// Token: 0x0400499B RID: 18843
	public bool OpenDoors;

	// Token: 0x0400499C RID: 18844
	public bool Begin;

	// Token: 0x0400499D RID: 18845
	public float Speed;

	// Token: 0x0400499E RID: 18846
	public float Timer;
}
