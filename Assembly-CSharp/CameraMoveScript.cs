using System;
using UnityEngine;

// Token: 0x02000520 RID: 1312
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600218B RID: 8587 RVA: 0x001EE2DD File Offset: 0x001EC4DD
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600218C RID: 8588 RVA: 0x001EE30C File Offset: 0x001EC50C
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

	// Token: 0x0600218D RID: 8589 RVA: 0x001EE49F File Offset: 0x001EC69F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040049CC RID: 18892
	public Transform StartPos;

	// Token: 0x040049CD RID: 18893
	public Transform EndPos;

	// Token: 0x040049CE RID: 18894
	public Transform RightDoor;

	// Token: 0x040049CF RID: 18895
	public Transform LeftDoor;

	// Token: 0x040049D0 RID: 18896
	public Transform Target;

	// Token: 0x040049D1 RID: 18897
	public bool OpenDoors;

	// Token: 0x040049D2 RID: 18898
	public bool Begin;

	// Token: 0x040049D3 RID: 18899
	public float Speed;

	// Token: 0x040049D4 RID: 18900
	public float Timer;
}
