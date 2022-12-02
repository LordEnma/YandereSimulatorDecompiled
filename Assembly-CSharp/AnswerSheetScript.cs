using System;
using UnityEngine;

public class AnswerSheetScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public DoorGapScript DoorGap;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Mesh OriginalMesh;

	public MeshFilter MyMesh;

	public int Phase = 1;

	private void Start()
	{
		OriginalMesh = MyMesh.mesh;
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				Schemes.UpdateInstructions();
				Prompt.Yandere.Inventory.AnswerSheet = true;
				Prompt.Hide();
				Prompt.enabled = false;
				DoorGap.Prompt.enabled = true;
				MyMesh.mesh = null;
				Phase++;
			}
			else
			{
				SchemeGlobals.SetSchemeStage(5, 8);
				Schemes.UpdateInstructions();
				Prompt.Yandere.Inventory.AnswerSheet = false;
				Prompt.Hide();
				Prompt.enabled = false;
				MyMesh.mesh = OriginalMesh;
				Phase++;
			}
		}
	}
}
