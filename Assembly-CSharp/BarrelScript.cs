using UnityEngine;

public class BarrelScript : MonoBehaviour
{
	public GameObject Corpse;

	public PromptScript Prompt;

	public bool Fall;

	public int Frame;

	private void Update()
	{
		if (Fall)
		{
			Corpse.GetComponent<StudentScript>().CharacterAnimation.Stop();
			Corpse.GetComponent<StudentScript>().CharacterAnimation.enabled = false;
			Corpse.GetComponent<RagdollScript>().enabled = true;
			Fall = false;
			Frame = 0;
		}
		if (Prompt.Yandere.Carrying)
		{
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Corpse = Prompt.Yandere.Ragdoll;
				Prompt.Yandere.EmptyHands();
				Corpse.transform.position = base.transform.position + Vector3.up * 2.5833333f;
				Corpse.transform.eulerAngles = new Vector3(0f, 135f, 180f);
				RagdollScript component = Corpse.GetComponent<RagdollScript>();
				component.enabled = false;
				component.Student.CharacterAnimation.enabled = true;
				if (!component.Male)
				{
					component.Student.CharacterAnimation.Play("f02_idleShort_00");
				}
				else
				{
					component.Student.CharacterAnimation.Play(component.Student.IdleAnim);
				}
				Prompt.Hide();
				Prompt.enabled = false;
				Fall = true;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
