using UnityEngine;
using UnityEngine.Video;

public class TriviaManagerScript : MonoBehaviour
{
	public RenderTexture[] RenderTextures;

	public Material[] RenderMaterials;

	public string[] TriviaText;

	public VideoClip[] Video;

	public Transform TriviaPanelParent;

	public Transform[] TriviaPanel;

	public GameObject TriviaCard;

	public int CardsSpawned;

	public int CardTarget;

	public int Phase;

	public float FadeOutTimer;

	public float MoveTimer;

	public float TargetX;

	public float Timer;

	public UISprite Light;

	public bool CanSpawn;

	private void Start()
	{
		Time.timeScale = 1f;
		Light.alpha = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Phase == 0)
		{
			Timer = Mathf.MoveTowards(Timer, 1f, Time.deltaTime);
			if (Timer == 1f)
			{
				Light.alpha = Mathf.MoveTowards(Light.alpha, 0f, Time.deltaTime);
				if (Light.alpha == 0f)
				{
					Light.color = new Color(0f, 0f, 0f, 0f);
					Phase++;
				}
			}
		}
		else if (Phase == 1 && CanSpawn && TriviaPanelParent.transform.position.x < -0.6775f * (float)(CardsSpawned - 3) && CardsSpawned < CardTarget)
		{
			GameObject gameObject = Object.Instantiate(TriviaCard, base.transform.position, Quaternion.identity);
			if (CardsSpawned < 15)
			{
				gameObject.transform.parent = TriviaPanel[1];
			}
			else
			{
				gameObject.transform.parent = TriviaPanel[2];
			}
			gameObject.transform.localPosition = new Vector3(-675 + 675 * CardsSpawned, -300f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.GetComponent<TriviaCardScript>().TriviaManager = this;
			gameObject.GetComponent<TriviaCardScript>().Video.gameObject.GetComponent<MeshRenderer>().material = RenderMaterials[CardsSpawned];
			gameObject.GetComponent<TriviaCardScript>().Video.targetTexture = RenderTextures[CardsSpawned];
			gameObject.GetComponent<TriviaCardScript>().Label.text = TriviaText[CardsSpawned];
			gameObject.GetComponent<TriviaCardScript>().Video.clip = Video[CardsSpawned];
			CanSpawn = false;
			CardsSpawned++;
		}
		if ((CardsSpawned <= 2 || !CanSpawn) && MoveTimer != 1f)
		{
			return;
		}
		MoveTimer = Mathf.MoveTowards(MoveTimer, 1f, Time.deltaTime);
		if (MoveTimer != 1f)
		{
			return;
		}
		TargetX = ((float)CardTarget * 0.6775f - 2.0325f) * -1f + 0.045f;
		if (TriviaPanelParent.transform.position.x > TargetX)
		{
			TriviaPanelParent.transform.position -= new Vector3(Time.deltaTime * 0.1f, 0f, 0f);
			return;
		}
		FadeOutTimer += Time.deltaTime;
		if (FadeOutTimer > 5f)
		{
			Light.alpha = Mathf.MoveTowards(Light.alpha, 1f, Time.deltaTime * 0.2f);
			if (Light.alpha == 1f)
			{
				Debug.Log("Now.");
			}
		}
	}
}
