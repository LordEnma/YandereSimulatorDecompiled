using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002142 RID: 8514 RVA: 0x001E8965 File Offset: 0x001E6B65
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x001E8994 File Offset: 0x001E6B94
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

	// Token: 0x06002144 RID: 8516 RVA: 0x001E8B27 File Offset: 0x001E6D27
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048FE RID: 18686
	public Transform StartPos;

	// Token: 0x040048FF RID: 18687
	public Transform EndPos;

	// Token: 0x04004900 RID: 18688
	public Transform RightDoor;

	// Token: 0x04004901 RID: 18689
	public Transform LeftDoor;

	// Token: 0x04004902 RID: 18690
	public Transform Target;

	// Token: 0x04004903 RID: 18691
	public bool OpenDoors;

	// Token: 0x04004904 RID: 18692
	public bool Begin;

	// Token: 0x04004905 RID: 18693
	public float Speed;

	// Token: 0x04004906 RID: 18694
	public float Timer;
}
