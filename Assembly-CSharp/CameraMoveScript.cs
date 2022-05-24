using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x060021A7 RID: 8615 RVA: 0x001F1E79 File Offset: 0x001F0079
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x001F1EA8 File Offset: 0x001F00A8
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

	// Token: 0x060021A9 RID: 8617 RVA: 0x001F203B File Offset: 0x001F023B
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x04004A24 RID: 18980
	public Transform StartPos;

	// Token: 0x04004A25 RID: 18981
	public Transform EndPos;

	// Token: 0x04004A26 RID: 18982
	public Transform RightDoor;

	// Token: 0x04004A27 RID: 18983
	public Transform LeftDoor;

	// Token: 0x04004A28 RID: 18984
	public Transform Target;

	// Token: 0x04004A29 RID: 18985
	public bool OpenDoors;

	// Token: 0x04004A2A RID: 18986
	public bool Begin;

	// Token: 0x04004A2B RID: 18987
	public float Speed;

	// Token: 0x04004A2C RID: 18988
	public float Timer;
}
