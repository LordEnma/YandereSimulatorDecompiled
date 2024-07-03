using UnityEngine;

public class CutsceneManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public CounselorScript Counselor;

	public PromptBarScript PromptBar;

	public EndOfDayScript EndOfDay;

	public PortalScript Portal;

	public UISprite Darkness;

	public UILabel Subtitle;

	public AudioClip[] Voice;

	public string[] Text;

	public int Scheme;

	public int Phase = 1;

	public int Line = 1;

	public float R;

	public float G;

	public float B;

	public float A;

	private void Update()
	{
		bool flag = false;
		if (!GameGlobals.Eighties && DateGlobals.Week == 2)
		{
			Debug.Log("Amai's week. There should never be a scene where the counselor checks Amai's desk.");
			flag = true;
		}
		AudioSource component = GetComponent<AudioSource>();
		if (Phase == 1)
		{
			R = Mathf.MoveTowards(R, 0f, Time.deltaTime);
			G = Mathf.MoveTowards(R, 0f, Time.deltaTime);
			B = Mathf.MoveTowards(R, 0f, Time.deltaTime);
			Darkness.color = new Color(R, G, B, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a > 0.999f)
			{
				if (!flag && Scheme == 5)
				{
					Phase++;
				}
				else
				{
					Phase = 4;
				}
			}
		}
		else if (Phase == 2)
		{
			Subtitle.text = Text[Line];
			component.clip = Voice[Line];
			component.Play();
			Phase++;
		}
		else if (Phase == 3)
		{
			if (!component.isPlaying || Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Line < 2)
				{
					Phase--;
					Line++;
				}
				else
				{
					Subtitle.text = string.Empty;
					Phase++;
				}
			}
		}
		else if (Phase == 4)
		{
			Debug.Log("We're activating EndOfDay from CutsceneManager.");
			EndOfDay.gameObject.SetActive(value: true);
			EndOfDay.Phase = 14;
			if (!flag && Scheme == 5)
			{
				Counselor.LecturePhase = 5;
			}
			else
			{
				Counselor.LecturePhase = 1;
			}
			Phase++;
		}
		else if (Phase == 6)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			if (Scheme == 5)
			{
				_ = StudentManager.Students[StudentManager.RivalID] != null;
			}
			PromptBar.ClearButtons();
			PromptBar.Show = false;
			Portal.Proceed = true;
			base.gameObject.SetActive(value: false);
			Scheme = 0;
		}
	}
}
