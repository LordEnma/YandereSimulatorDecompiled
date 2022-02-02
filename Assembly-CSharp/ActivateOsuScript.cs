using System;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A2F RID: 6703 RVA: 0x00115E5C File Offset: 0x0011405C
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A30 RID: 6704 RVA: 0x00115E9C File Offset: 0x0011409C
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

	// Token: 0x06001A31 RID: 6705 RVA: 0x00115FD4 File Offset: 0x001141D4
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x00116044 File Offset: 0x00114244
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

	// Token: 0x04002ACD RID: 10957
	public StudentManagerScript StudentManager;

	// Token: 0x04002ACE RID: 10958
	public OsuScript[] OsuScripts;

	// Token: 0x04002ACF RID: 10959
	public StudentScript Student;

	// Token: 0x04002AD0 RID: 10960
	public ClockScript Clock;

	// Token: 0x04002AD1 RID: 10961
	public GameObject Music;

	// Token: 0x04002AD2 RID: 10962
	public Transform Mouse;

	// Token: 0x04002AD3 RID: 10963
	public GameObject Osu;

	// Token: 0x04002AD4 RID: 10964
	public int PlayerID;

	// Token: 0x04002AD5 RID: 10965
	public Vector3 OriginalMousePosition;

	// Token: 0x04002AD6 RID: 10966
	public Vector3 OriginalMouseRotation;
}
