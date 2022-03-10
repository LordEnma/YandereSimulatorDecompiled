using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600215B RID: 8539 RVA: 0x001EA5D5 File Offset: 0x001E87D5
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x001EA604 File Offset: 0x001E8804
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

	// Token: 0x0600215D RID: 8541 RVA: 0x001EA797 File Offset: 0x001E8997
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x04004937 RID: 18743
	public Transform StartPos;

	// Token: 0x04004938 RID: 18744
	public Transform EndPos;

	// Token: 0x04004939 RID: 18745
	public Transform RightDoor;

	// Token: 0x0400493A RID: 18746
	public Transform LeftDoor;

	// Token: 0x0400493B RID: 18747
	public Transform Target;

	// Token: 0x0400493C RID: 18748
	public bool OpenDoors;

	// Token: 0x0400493D RID: 18749
	public bool Begin;

	// Token: 0x0400493E RID: 18750
	public float Speed;

	// Token: 0x0400493F RID: 18751
	public float Timer;
}
