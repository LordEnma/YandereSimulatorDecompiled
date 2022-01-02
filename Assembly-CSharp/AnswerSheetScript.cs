using System;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class AnswerSheetScript : MonoBehaviour
{
	// Token: 0x060009C2 RID: 2498 RVA: 0x0005126F File Offset: 0x0004F46F
	private void Start()
	{
		this.OriginalMesh = this.MyMesh.mesh;
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x000512A4 File Offset: 0x0004F4A4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.MyMesh.mesh = null;
				this.Phase++;
				return;
			}
			SchemeGlobals.SetSchemeStage(5, 8);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.AnswerSheet = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.MyMesh.mesh = this.OriginalMesh;
			this.Phase++;
		}
	}

	// Token: 0x04000A1C RID: 2588
	public SchemesScript Schemes;

	// Token: 0x04000A1D RID: 2589
	public DoorGapScript DoorGap;

	// Token: 0x04000A1E RID: 2590
	public PromptScript Prompt;

	// Token: 0x04000A1F RID: 2591
	public ClockScript Clock;

	// Token: 0x04000A20 RID: 2592
	public Mesh OriginalMesh;

	// Token: 0x04000A21 RID: 2593
	public MeshFilter MyMesh;

	// Token: 0x04000A22 RID: 2594
	public int Phase = 1;
}
