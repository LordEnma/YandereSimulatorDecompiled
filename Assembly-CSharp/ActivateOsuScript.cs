using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A60 RID: 6752 RVA: 0x00118C84 File Offset: 0x00116E84
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A61 RID: 6753 RVA: 0x00118CC4 File Offset: 0x00116EC4
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

	// Token: 0x06001A62 RID: 6754 RVA: 0x00118DFC File Offset: 0x00116FFC
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x00118E6C File Offset: 0x0011706C
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

	// Token: 0x04002B4D RID: 11085
	public StudentManagerScript StudentManager;

	// Token: 0x04002B4E RID: 11086
	public OsuScript[] OsuScripts;

	// Token: 0x04002B4F RID: 11087
	public StudentScript Student;

	// Token: 0x04002B50 RID: 11088
	public ClockScript Clock;

	// Token: 0x04002B51 RID: 11089
	public GameObject Music;

	// Token: 0x04002B52 RID: 11090
	public Transform Mouse;

	// Token: 0x04002B53 RID: 11091
	public GameObject Osu;

	// Token: 0x04002B54 RID: 11092
	public int PlayerID;

	// Token: 0x04002B55 RID: 11093
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B56 RID: 11094
	public Vector3 OriginalMouseRotation;
}
