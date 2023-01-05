using UnityEngine;

public class PantyDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public StudentScript Student;

	public int Frame;

	private void Update()
	{
		if (Frame == 1)
		{
			Yandere.StudentManager.UpdatePanties(false);
			Object.Destroy(base.gameObject);
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!Yandere.Shutter.Blocked && Student == null && other.gameObject.name == "Panties")
		{
			Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
			Yandere.ResetYandereEffects();
			Yandere.Shutter.PhotoDescLabel.text = "Photo of: " + Student.Name + "'s Panties";
			Yandere.Shutter.PhotoIcons.SetActive(true);
			Yandere.Shutter.PantiesX.SetActive(false);
			Yandere.Shutter.InfoX.SetActive(true);
			Yandere.Shutter.Student = Student;
			Time.timeScale = 0f;
			Yandere.Shutter.Panel.SetActive(true);
			Yandere.Shutter.MainMenu.SetActive(false);
			Yandere.PauseScreen.Show = true;
			Yandere.PauseScreen.Panel.enabled = true;
			Yandere.PromptBar.ClearButtons();
			Yandere.PromptBar.Label[1].text = "Exit";
			Yandere.PromptBar.UpdateButtons();
			Yandere.PromptBar.Show = true;
			Yandere.PauseScreen.Sideways = false;
			Yandere.Shutter.TextMessages.gameObject.SetActive(true);
			Yandere.Shutter.SpawnMessage();
		}
	}
}
