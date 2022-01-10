using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StreetCivilianScript : MonoBehaviour
{
	// Token: 0x06001D10 RID: 7440 RVA: 0x001598D1 File Offset: 0x00157AD1
	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x001598E8 File Offset: 0x00157AE8
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Destinations[this.ID].position) < 0.55f)
		{
			this.MoveTowardsTarget(this.Destinations[this.ID].position);
			this.MyAnimation.CrossFade("f02_idle_00");
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Timer += Time.deltaTime;
			if (this.Timer > 13.5f)
			{
				this.MyAnimation.CrossFade("f02_newWalk_00");
				this.ID++;
				if (this.ID == this.Destinations.Length)
				{
					this.ID = 0;
				}
				this.Pathfinding.target = this.Destinations[this.ID];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x001599F0 File Offset: 0x00157BF0
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		if (a.sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}

	// Token: 0x040034D2 RID: 13522
	public CharacterController MyController;

	// Token: 0x040034D3 RID: 13523
	public Animation MyAnimation;

	// Token: 0x040034D4 RID: 13524
	public AIPath Pathfinding;

	// Token: 0x040034D5 RID: 13525
	public Transform[] Destinations;

	// Token: 0x040034D6 RID: 13526
	public float Timer;

	// Token: 0x040034D7 RID: 13527
	public int ID;
}
