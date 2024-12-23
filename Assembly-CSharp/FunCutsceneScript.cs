using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunCutsceneScript : MonoBehaviour
{
	public CameraFilterPack_NewGlitch1 Glitch1;

	public CameraFilterPack_NewGlitch3 Glitch3;

	public CameraFilterPack_NewGlitch4 Glitch4;

	public CameraFilterPack_NewGlitch6 Glitch6;

	public TypewriterEffect JapanTypewriter;

	public TypewriterEffect Typewriter;

	public YandereScript Yandere;

	public GameObject SkipButton;

	public GameObject FunChan;

	public AudioSource MyAudio;

	public AudioClip FunGlitch;

	public UILabel JapanLabel;

	public UILabel Label;

	public UIPanel FunPanel;

	public UIPanel Panel;

	public AudioClip[] Voices;

	public string[] JapanLines;

	public string[] Lines;

	public AudioClip[] EndVoices;

	public string[] EndJapanLines;

	public string[] EndLines;

	public float Timer;

	public int Phase;

	public int ID;

	public bool NoSkip;

	public bool Skip;

	private void Start()
	{
		if (Yandere != null)
		{
			AudioSource.PlayClipAtPoint(FunGlitch, Yandere.MainCamera.transform.position);
			Yandere.StudentManager.Tutorial.BGM[1].gameObject.SetActive(value: false);
			Yandere.StudentManager.Tutorial.BGM[2].gameObject.SetActive(value: false);
			Yandere.StudentManager.Tutorial.BGM[3].gameObject.SetActive(value: false);
		}
		else
		{
			AudioSource.PlayClipAtPoint(FunGlitch, base.transform.position);
		}
		if (DateGlobals.Week == 11)
		{
			Voices = EndVoices;
			JapanLines = EndJapanLines;
			Lines = EndLines;
		}
		Label.text = Lines[0];
	}

	private void Update()
	{
		if (Phase == 0)
		{
			Timer = Mathf.MoveTowards(Timer, 1.7f, Time.deltaTime);
			if (Timer > 1.69f)
			{
				Panel.gameObject.SetActive(value: true);
				JapanLabel.text = JapanLines[ID];
				Label.text = Lines[ID];
				Typewriter.ResetToBeginning();
				Typewriter.mFullText = Lines[ID];
				JapanTypewriter.ResetToBeginning();
				JapanTypewriter.mFullText = JapanLines[ID];
				MyAudio.clip = Voices[1];
				MyAudio.Play();
				Glitch1.enabled = false;
				Glitch4.enabled = false;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			if (!NoSkip && Input.GetButtonDown(InputNames.Xbox_X))
			{
				if (ID < 49)
				{
					ID = 49;
				}
				else
				{
					SkipButton.SetActive(value: false);
					NoSkip = true;
					ID = 57;
				}
				Skip = true;
			}
			if (!Input.GetButtonDown(InputNames.Xbox_A) && !Skip)
			{
				return;
			}
			if (ID < Lines.Length)
			{
				if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
				{
					JapanTypewriter.ResetToBeginning();
					Typewriter.ResetToBeginning();
					JapanTypewriter.Finish();
					Typewriter.Finish();
				}
				else
				{
					ID++;
					if (ID < Lines.Length)
					{
						MyAudio.clip = Voices[ID];
						MyAudio.Play();
						Typewriter.ResetToBeginning();
						Typewriter.mFullText = Lines[ID];
						JapanTypewriter.ResetToBeginning();
						JapanTypewriter.mFullText = JapanLines[ID];
						Typewriter.mFullText = Typewriter.mFullText.Replace('@', '\n');
						JapanTypewriter.mFullText = JapanTypewriter.mFullText.Replace('@', '\n');
					}
					else
					{
						End();
					}
				}
				Skip = false;
			}
			else
			{
				End();
			}
		}
		else
		{
			if (Phase != 2)
			{
				return;
			}
			Timer = Mathf.MoveTowards(Timer, 1.7f, Time.deltaTime);
			if (Yandere != null)
			{
				if (Timer > 1.69f)
				{
					Yandere.StudentManager.Tutorial.BGM[4].gameObject.SetActive(value: true);
					Yandere.StudentManager.Tutorial.BGM[4].Play();
					Yandere.StudentManager.Tutorial.SwitchTimelines();
					Yandere.RPGCamera.enabled = true;
					Yandere.CanMove = true;
					base.gameObject.SetActive(value: false);
					Timer = 0f;
					Phase++;
				}
				return;
			}
			FunChan.transform.localScale = Vector3.MoveTowards(FunChan.transform.localScale, new Vector3(20f, 20f, 20f), Time.deltaTime * 20f * 1.64f);
			FunChan.transform.localPosition = Vector3.MoveTowards(FunChan.transform.localPosition, new Vector3(0f, -7950f, 0f), Time.deltaTime * 7950f);
			if (!(Timer > 1f))
			{
				return;
			}
			if (DateGlobals.Week == 11)
			{
				PlayerPrefs.SetInt("FunTimeline", 1);
				SceneManager.LoadScene("NewTitleScene");
			}
			else
			{
				FunChan.SetActive(value: false);
				int profile = GameGlobals.Profile;
				int num = 11;
				int femaleUniform = StudentGlobals.FemaleUniform;
				int maleUniform = StudentGlobals.MaleUniform;
				if (File.Exists(Application.streamingAssetsPath + "/SaveFiles/Profile_" + profile + "_Slot_" + num + ".yansave"))
				{
					YanSave.LoadData("Profile_" + profile + "_Slot_" + num);
					YanSave.LoadPrefs("Profile_" + profile + "_Slot_" + num);
					Debug.Log("Successfully loaded the save in Slot #" + num);
				}
				else
				{
					Debug.Log("Attempted to load a save from Slot #" + num + ", but apparently it didn't exist.");
				}
				StudentGlobals.SetStudentDead(10 + DateGlobals.Week, value: false);
				StudentGlobals.SetStudentDying(10 + DateGlobals.Week, value: false);
				StudentGlobals.FemaleUniform = femaleUniform;
				StudentGlobals.MaleUniform = maleUniform;
				SceneManager.LoadScene("CalendarScene");
			}
			Phase++;
		}
	}

	public void End()
	{
		if (Yandere != null)
		{
			AudioSource.PlayClipAtPoint(FunGlitch, Yandere.MainCamera.transform.position);
			Glitch1.enabled = true;
			Glitch3.enabled = true;
			Glitch4.enabled = true;
			Glitch6.enabled = true;
		}
		else
		{
			AudioSource.PlayClipAtPoint(FunGlitch, base.transform.position);
			FunPanel.gameObject.SetActive(value: true);
		}
		Panel.gameObject.SetActive(value: false);
		Timer = 0f;
		Phase++;
	}
}
