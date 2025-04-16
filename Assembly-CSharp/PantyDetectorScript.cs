using UnityEngine;

public class PantyDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public StudentScript Student;

	public int Frame;

	private void Start()
	{
		Debug.Log("A PantyDetector has just been spawned.");
	}

	private void Update()
	{
		if (Frame == 1)
		{
			Yandere.StudentManager.UpdatePanties(Status: false);
			Object.Destroy(base.gameObject);
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("A PantyDetector has just collided with something!");
		if (!Yandere.Shutter.Blocked)
		{
			Debug.Log("Yandere.Shutter.Blocked was false.");
			if (Student == null)
			{
				Debug.Log("We collided with a student.");
				if (other.gameObject.name == "Panties")
				{
					Debug.Log("We collided with panties.");
					Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
					Yandere.ResetYandereEffects();
					Yandere.Shutter.PhotoDescLabel.text = "Photo of: " + Student.Name + "'s Panties";
					Yandere.Shutter.PhotoIcons.SetActive(value: true);
					Yandere.Shutter.PantiesX.SetActive(value: false);
					Yandere.Shutter.InfoX.SetActive(value: true);
					Yandere.Shutter.Student = Student;
					Time.timeScale = 0f;
					Yandere.Shutter.Panel.SetActive(value: true);
					Yandere.Shutter.MainMenu.SetActive(value: false);
					Yandere.PauseScreen.Show = true;
					Yandere.PauseScreen.Panel.enabled = true;
					Yandere.PromptBar.ClearButtons();
					Yandere.PromptBar.Label[1].text = "Exit";
					Yandere.PromptBar.UpdateButtons();
					Yandere.PromptBar.Show = true;
					Yandere.PauseScreen.Sideways = false;
					Yandere.Shutter.TextMessages.gameObject.SetActive(value: true);
					Yandere.Shutter.SpawnMessage();
					QuestTracker.IncrementPantyShots();
				}
				else
				{
					Debug.Log("We did not collide with panties.");
				}
			}
			else
			{
				Debug.Log("We did not collide with a student.");
			}
		}
		else
		{
			Debug.Log("Yandere.Shutter.Blocked was true.");
		}
	}
}
