using System;
using UnityEngine;

// Token: 0x0200051F RID: 1311
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002183 RID: 8579 RVA: 0x001EDDAD File Offset: 0x001EBFAD
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002184 RID: 8580 RVA: 0x001EDDDC File Offset: 0x001EBFDC
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

	// Token: 0x06002185 RID: 8581 RVA: 0x001EDF6F File Offset: 0x001EC16F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040049C8 RID: 18888
	public Transform StartPos;

	// Token: 0x040049C9 RID: 18889
	public Transform EndPos;

	// Token: 0x040049CA RID: 18890
	public Transform RightDoor;

	// Token: 0x040049CB RID: 18891
	public Transform LeftDoor;

	// Token: 0x040049CC RID: 18892
	public Transform Target;

	// Token: 0x040049CD RID: 18893
	public bool OpenDoors;

	// Token: 0x040049CE RID: 18894
	public bool Begin;

	// Token: 0x040049CF RID: 18895
	public float Speed;

	// Token: 0x040049D0 RID: 18896
	public float Timer;
}
