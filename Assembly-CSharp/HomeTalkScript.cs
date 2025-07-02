using UnityEngine;

public class HomeTalkScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public UIPanel DialoguePanel;

	public UILabel DialogueLabel;

	public UILabel SpeakerLabel;

	public UILabel Label;

	public UITexture BG;

	public bool Talking;

	public bool Out;

	public Color[] SpeakerColor;

	public string[] Dialogue;

	public string[] Speaker;

	public int ID;

	private void Update()
	{
		if (!Talking)
		{
			if (Vector3.Distance(HomeYandere.transform.position, base.transform.position) < 1f)
			{
				Label.alpha = Mathf.MoveTowards(Label.alpha, 1f, Time.deltaTime * 10f);
				if (Label.alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A))
				{
					HomeYandere.CharacterAnimation.CrossFade(HomeYandere.IdleAnim);
					HomeYandere.CanMove = false;
					Label.alpha = 0f;
					Talking = true;
					UpdateDialogue();
				}
			}
			else
			{
				Label.alpha = Mathf.MoveTowards(Label.alpha, 0f, Time.deltaTime * 10f);
			}
			if (Out)
			{
				DialoguePanel.transform.localPosition = Vector3.Lerp(DialoguePanel.transform.localPosition, new Vector3(0f, -0.51f, 1f), Time.deltaTime * 10f);
				if ((double)DialoguePanel.transform.localPosition.y < -0.5)
				{
					Out = false;
				}
			}
		}
		else
		{
			DialoguePanel.transform.localPosition = Vector3.Lerp(DialoguePanel.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				UpdateDialogue();
			}
		}
	}

	private void UpdateDialogue()
	{
		ID++;
		if (ID < Dialogue.Length)
		{
			DialogueLabel.text = Dialogue[ID];
			SpeakerLabel.text = Speaker[ID];
			BG.color = SpeakerColor[ID];
		}
		else
		{
			HomeYandere.CanMove = true;
			Talking = false;
			Out = true;
			ID = 0;
		}
	}
}
