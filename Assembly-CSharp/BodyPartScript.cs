using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
	public bool Sacrifice;

	public int StudentID;

	public int Type;

	public GameObject GarbageBag;

	public PromptScript Prompt;

	public AudioClip WrapSFX;

	private void Update()
	{
		if (!(Prompt != null))
		{
			return;
		}
		if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.GarbageBagBox)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				GameObject gameObject = Object.Instantiate(GarbageBag, base.transform.position, Quaternion.identity);
				gameObject.GetComponent<BodyPartScript>().StudentID = StudentID;
				gameObject.transform.parent = Prompt.Yandere.Police.GarbageParent;
				Prompt.Yandere.StudentManager.GarbageBagList[Prompt.Yandere.StudentManager.GarbageBags] = gameObject;
				Prompt.Yandere.StudentManager.GarbageBags++;
				AudioSource.PlayClipAtPoint(WrapSFX, base.transform.position);
				Object.Destroy(base.gameObject);
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}
}
