using UnityEngine;

public class SpeechBubbleScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public StudentScript Student;

	public string[] Dialogue;

	public int[] Speaker;

	public UILabel Label;

	public UISprite[] Bubbles;

	public UISprite Arrow;

	public int CurrentBubble;

	public int ID = 1;

	public bool FadeOut;

	public bool Stop;

	public float Timer;

	private void Start()
	{
		Resize();
	}

	private void LateUpdate()
	{
		if (!Stop)
		{
			if (Student != null)
			{
				Vector2 vector = StudentManager.Yandere.MainCamera.WorldToScreenPoint(Student.transform.position + base.transform.up * 2f);
				base.transform.position = StudentManager.Yandere.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
				if (Student.DistanceToPlayer < 5f && !Student.Alone)
				{
					if (!FadeOut)
					{
						Bubbles[CurrentBubble].alpha = Mathf.MoveTowards(Bubbles[CurrentBubble].alpha, 1f, Time.deltaTime);
						Arrow.alpha = Bubbles[CurrentBubble].alpha;
						Label.alpha = Arrow.alpha;
						Timer += Time.deltaTime;
						if (Timer > 6f)
						{
							FadeOut = true;
							Timer = 0f;
						}
						return;
					}
					Bubbles[CurrentBubble].alpha = Mathf.MoveTowards(Bubbles[CurrentBubble].alpha, 0f, Time.deltaTime);
					Arrow.alpha = Bubbles[CurrentBubble].alpha;
					Label.alpha = Arrow.alpha;
					if (Label.alpha == 0f)
					{
						FadeOut = false;
						ID++;
						if (ID < Speaker.Length)
						{
							Student = StudentManager.Students[Speaker[ID]];
							Label.text = Dialogue[ID];
						}
						else
						{
							Stop = true;
						}
						Resize();
					}
				}
				else
				{
					Bubbles[CurrentBubble].alpha = Mathf.MoveTowards(Bubbles[CurrentBubble].alpha, 0f, Time.deltaTime);
					Arrow.alpha = Bubbles[CurrentBubble].alpha;
					Label.alpha = Arrow.alpha;
				}
			}
			else
			{
				Student = StudentManager.Students[Speaker[ID]];
				Label.text = Dialogue[ID];
				Resize();
			}
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			Stop = false;
			ID = 1;
			Student = StudentManager.Students[Speaker[ID]];
			Label.text = Dialogue[ID];
			Resize();
		}
	}

	public void Resize()
	{
		Arrow.alpha = 0f;
		Label.alpha = 0f;
		Bubbles[1].enabled = false;
		Bubbles[2].enabled = false;
		Bubbles[3].enabled = false;
		Bubbles[4].enabled = false;
		Bubbles[5].enabled = false;
		Bubbles[1].alpha = 0f;
		Bubbles[2].alpha = 0f;
		Bubbles[3].alpha = 0f;
		Bubbles[4].alpha = 0f;
		Bubbles[5].alpha = 0f;
		if (Label.text.Length < 41)
		{
			CurrentBubble = 1;
		}
		else if (Label.text.Length < 81)
		{
			CurrentBubble = 2;
		}
		else if (Label.text.Length < 121)
		{
			CurrentBubble = 3;
		}
		else if (Label.text.Length < 161)
		{
			CurrentBubble = 4;
		}
		else
		{
			CurrentBubble = 5;
		}
		Bubbles[CurrentBubble].enabled = true;
	}
}
