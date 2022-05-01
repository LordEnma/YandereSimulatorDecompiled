using System;
using UnityEngine;

// Token: 0x02000521 RID: 1313
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600219B RID: 8603 RVA: 0x001F01C5 File Offset: 0x001EE3C5
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600219C RID: 8604 RVA: 0x001F01F4 File Offset: 0x001EE3F4
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

	// Token: 0x0600219D RID: 8605 RVA: 0x001F0387 File Offset: 0x001EE587
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040049F4 RID: 18932
	public Transform StartPos;

	// Token: 0x040049F5 RID: 18933
	public Transform EndPos;

	// Token: 0x040049F6 RID: 18934
	public Transform RightDoor;

	// Token: 0x040049F7 RID: 18935
	public Transform LeftDoor;

	// Token: 0x040049F8 RID: 18936
	public Transform Target;

	// Token: 0x040049F9 RID: 18937
	public bool OpenDoors;

	// Token: 0x040049FA RID: 18938
	public bool Begin;

	// Token: 0x040049FB RID: 18939
	public float Speed;

	// Token: 0x040049FC RID: 18940
	public float Timer;
}
