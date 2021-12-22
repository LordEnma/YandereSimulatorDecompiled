using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A28 RID: 6696 RVA: 0x00115298 File Offset: 0x00113498
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A29 RID: 6697 RVA: 0x001152D8 File Offset: 0x001134D8
	private void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.PlayerID];
			return;
		}
		if (!this.Osu.activeInHierarchy)
		{
			if (Vector3.Distance(base.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.CurrentDestination == this.Student.Destinations[this.Student.Phase] && this.Student.Actions[this.Student.Phase] == StudentActionType.Gaming)
			{
				this.ActivateOsu();
				return;
			}
		}
		else
		{
			this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
			if (!this.Student.Routine || this.Student.CurrentDestination != this.Student.Destinations[this.Student.Phase] || this.Student.Actions[this.Student.Phase] != StudentActionType.Gaming)
			{
				this.DeactivateOsu();
			}
		}
	}

	// Token: 0x06001A2A RID: 6698 RVA: 0x00115410 File Offset: 0x00113610
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A2B RID: 6699 RVA: 0x00115480 File Offset: 0x00113680
	private void DeactivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(false);
		this.Music.SetActive(false);
		OsuScript[] osuScripts = this.OsuScripts;
		for (int i = 0; i < osuScripts.Length; i++)
		{
			osuScripts[i].Timer = 0f;
		}
		this.Mouse.parent = base.transform.parent;
		this.Mouse.transform.position = this.OriginalMousePosition;
	}

	// Token: 0x04002ABA RID: 10938
	public StudentManagerScript StudentManager;

	// Token: 0x04002ABB RID: 10939
	public OsuScript[] OsuScripts;

	// Token: 0x04002ABC RID: 10940
	public StudentScript Student;

	// Token: 0x04002ABD RID: 10941
	public ClockScript Clock;

	// Token: 0x04002ABE RID: 10942
	public GameObject Music;

	// Token: 0x04002ABF RID: 10943
	public Transform Mouse;

	// Token: 0x04002AC0 RID: 10944
	public GameObject Osu;

	// Token: 0x04002AC1 RID: 10945
	public int PlayerID;

	// Token: 0x04002AC2 RID: 10946
	public Vector3 OriginalMousePosition;

	// Token: 0x04002AC3 RID: 10947
	public Vector3 OriginalMouseRotation;
}
