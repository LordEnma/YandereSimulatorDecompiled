using System;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002140 RID: 8512 RVA: 0x001E864D File Offset: 0x001E684D
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x001E867C File Offset: 0x001E687C
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

	// Token: 0x06002142 RID: 8514 RVA: 0x001E880F File Offset: 0x001E6A0F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048F8 RID: 18680
	public Transform StartPos;

	// Token: 0x040048F9 RID: 18681
	public Transform EndPos;

	// Token: 0x040048FA RID: 18682
	public Transform RightDoor;

	// Token: 0x040048FB RID: 18683
	public Transform LeftDoor;

	// Token: 0x040048FC RID: 18684
	public Transform Target;

	// Token: 0x040048FD RID: 18685
	public bool OpenDoors;

	// Token: 0x040048FE RID: 18686
	public bool Begin;

	// Token: 0x040048FF RID: 18687
	public float Speed;

	// Token: 0x04004900 RID: 18688
	public float Timer;
}
