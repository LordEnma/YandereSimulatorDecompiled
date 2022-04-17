using System;
using UnityEngine;

// Token: 0x02000520 RID: 1312
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002192 RID: 8594 RVA: 0x001EED39 File Offset: 0x001ECF39
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002193 RID: 8595 RVA: 0x001EED68 File Offset: 0x001ECF68
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

	// Token: 0x06002194 RID: 8596 RVA: 0x001EEEFB File Offset: 0x001ED0FB
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040049DE RID: 18910
	public Transform StartPos;

	// Token: 0x040049DF RID: 18911
	public Transform EndPos;

	// Token: 0x040049E0 RID: 18912
	public Transform RightDoor;

	// Token: 0x040049E1 RID: 18913
	public Transform LeftDoor;

	// Token: 0x040049E2 RID: 18914
	public Transform Target;

	// Token: 0x040049E3 RID: 18915
	public bool OpenDoors;

	// Token: 0x040049E4 RID: 18916
	public bool Begin;

	// Token: 0x040049E5 RID: 18917
	public float Speed;

	// Token: 0x040049E6 RID: 18918
	public float Timer;
}
