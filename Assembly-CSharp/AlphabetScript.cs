using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public MissionModeScript MissionMode;

	public InventoryScript Inventory;

	public ClassScript Class;

	public GameObject BodyHidingLockers;

	public GameObject AlphabetTools;

	public GameObject Jukebox;

	public GameObject AmnesiaBomb;

	public GameObject SmokeBomb;

	public GameObject StinkBomb;

	public UILabel ChallengeFailed;

	public UILabel DifficultyLabel;

	public UILabel TargetLabel;

	public UILabel BombLabel;

	public AudioSource MusicPlayer;

	public UITexture BombTexture;

	public Transform LocalArrow;

	public Renderer MyRenderer;

	public Transform Yandere;

	public bool AlternateMusic;

	public bool StopMusic;

	public bool Began;

	public int RemainingBombs;

	public int CurrentTarget;

	public int CurrentTrack;

	public int Cheats;

	public int Limit;

	public float LastTime;

	public float Timer;

	public AudioClip[] MusicTracks;

	public string[] DifficultyText;

	public string[] Names;

	public int[] EightiesIDs;

	public int[] IDs;

	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			TargetLabel.transform.parent.gameObject.SetActive(value: true);
			StudentManager.Yandere.NoDebug = true;
			BodyHidingLockers.SetActive(value: true);
			AlphabetTools.SetActive(value: true);
			Jukebox.SetActive(value: false);
			MyRenderer.enabled = true;
			StudentManager.Yandere.SpeedBonus = 5;
			Class.PhysicalGrade = 5;
			CurrentTrack = 1;
			Limit = 79;
			if (GameGlobals.Eighties)
			{
				StudentManager.EnableAllOutlines();
				if (GameGlobals.CustomMode)
				{
					EightiesIDs = GetSortedStudentIDs(StudentManager.Students);
				}
				IDs = EightiesIDs;
				Limit = IDs.Length - 1;
				StudentManager.Police.DeathLimit = Limit - 1;
			}
			MissionMode.RemoveBoxes();
			UpdateText();
			UpdateDifficultyLabel();
		}
		else
		{
			TargetLabel.transform.parent.gameObject.SetActive(value: false);
			BombLabel.transform.parent.gameObject.SetActive(value: false);
			AlphabetTools.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!Began && StudentManager.Yandere.CanMove)
		{
			StudentManager.TeleportEveryoneToDestination();
			MusicPlayer.Play();
			Began = true;
		}
		if (CurrentTarget >= IDs.Length)
		{
			return;
		}
		if (Input.GetKeyDown("m"))
		{
			if (MusicPlayer.isPlaying)
			{
				MusicPlayer.Stop();
				StopMusic = true;
				MusicPlayer.time = 0f;
				LastTime = 0f;
			}
			else
			{
				MusicPlayer.clip = MusicTracks[CurrentTrack];
				MusicPlayer.Play();
				StopMusic = false;
			}
		}
		if (MusicPlayer.time < 600f && MusicPlayer.time > LastTime)
		{
			LastTime = MusicPlayer.time;
		}
		if (Began && !MusicPlayer.isPlaying && !StopMusic)
		{
			MusicPlayer.Play();
			MusicPlayer.time = LastTime;
		}
		if (StudentManager.Yandere.CanMove && (Input.GetButtonDown(InputNames.Xbox_LS) || Input.GetKeyDown(KeyCode.T)))
		{
			if (StudentManager.Yandere.Inventory.SmokeBomb)
			{
				Object.Instantiate(SmokeBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = RemainingBombs.ToString() ?? "";
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.SmokeBomb = false;
				}
			}
			else if (StudentManager.Yandere.Inventory.StinkBomb)
			{
				Object.Instantiate(StinkBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = RemainingBombs.ToString() ?? "";
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.StinkBomb = false;
				}
			}
			else if (StudentManager.Yandere.Inventory.AmnesiaBomb)
			{
				Object.Instantiate(AmnesiaBomb, Yandere.position, Quaternion.identity);
				RemainingBombs--;
				BombLabel.text = RemainingBombs.ToString() ?? "";
				if (RemainingBombs == 0)
				{
					StudentManager.Yandere.Inventory.AmnesiaBomb = false;
				}
			}
		}
		LocalArrow.LookAt(StudentManager.Students[IDs[CurrentTarget]].transform.position);
		base.transform.eulerAngles = LocalArrow.eulerAngles - new Vector3(0f, StudentManager.MainCamera.transform.eulerAngles.y, 0f);
		if ((StudentManager.Yandere.Attacking && StudentManager.Yandere.TargetStudent.StudentID != IDs[CurrentTarget]) || (StudentManager.Yandere.Struggling && StudentManager.Yandere.TargetStudent.StudentID != IDs[CurrentTarget]) || StudentManager.Police.Show || StudentManager.Yandere.Noticed || StudentManager.Students[1].Fleeing)
		{
			ChallengeFailed.enabled = true;
		}
		for (int i = CurrentTarget + 1; i < IDs.Length; i++)
		{
			if ((StudentManager.Students[IDs[i]] != null && !StudentManager.Students[IDs[i]].gameObject.activeInHierarchy) || (StudentManager.Students[IDs[i]] != null && !StudentManager.Students[IDs[i]].Alive))
			{
				Debug.Log("Challenge Failed because " + StudentManager.Students[IDs[i]].Name + ", who was one the player's future targets, no longer exists or is already dead.");
				ChallengeFailed.enabled = true;
			}
		}
		if (!StudentManager.Students[IDs[CurrentTarget]].Alive)
		{
			CurrentTarget++;
			if (CurrentTarget > Limit)
			{
				TargetLabel.text = "Challenge Complete!";
				SceneManager.LoadScene("OsanaJokeScene");
			}
			else
			{
				UpdateText();
			}
		}
		if (ChallengeFailed.enabled)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	public void UpdateText()
	{
		TargetLabel.text = "(" + CurrentTarget + "/" + Limit + ") Current Target: " + StudentManager.JSON.Students[IDs[CurrentTarget]].Name;
		if (RemainingBombs > 0)
		{
			BombLabel.transform.parent.gameObject.SetActive(value: true);
			BombLabel.text = RemainingBombs.ToString() ?? "";
			if (BombTexture.color.a < 1f)
			{
				if (Inventory.StinkBomb)
				{
					BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
				}
				else if (Inventory.AmnesiaBomb)
				{
					BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
				}
				else
				{
					BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				}
			}
		}
		UpdateDifficultyLabel();
	}

	public void UpdateDifficultyLabel()
	{
		if (Cheats < DifficultyText.Length)
		{
			DifficultyLabel.text = "Difficulty: " + DifficultyText[Cheats];
		}
		else
		{
			Debug.Log("Can't update Difficulty Label.");
		}
	}

	public static int[] GetSortedStudentIDs(StudentScript[] students)
	{
		StudentScript[] array = (from student in students
			where student != null && student.StudentID != 1
			orderby student.Name
			select student).ToArray();
		int[] array2 = new int[array.Length + 1];
		array2[0] = 0;
		for (int i = 0; i < array.Length; i++)
		{
			array2[i + 1] = array[i].StudentID;
		}
		return array2;
	}
}
