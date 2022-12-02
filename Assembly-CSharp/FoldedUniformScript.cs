using UnityEngine;

public class FoldedUniformScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SteamCloud;

	public bool ClubAttire;

	public bool InPosition = true;

	public bool Clean;

	public bool Spare;

	public float Timer;

	public int Type;

	public GameObject[] Uniforms;

	public Renderer[] MyRenderer;

	public Texture CleanTexture;

	public Texture EightiesTexture;

	public Texture BloodyEightiesTexture;

	private void Start()
	{
		for (int i = 1; i < Uniforms.Length; i++)
		{
			Uniforms[i].SetActive(false);
		}
		if (Uniforms.Length != 0)
		{
			Uniforms[StudentGlobals.FemaleUniform].SetActive(true);
		}
		if (Prompt != null && Prompt.Yandere != null)
		{
			Yandere = Prompt.Yandere;
		}
		else
		{
			GameObject gameObject = GameObject.Find("YandereChan");
			if (gameObject != null)
			{
				Yandere = gameObject.GetComponent<YandereScript>();
			}
		}
		bool flag = false;
		if (Spare && !GameGlobals.SpareUniform)
		{
			Object.Destroy(base.gameObject);
			flag = true;
		}
		if (!flag && Clean && Prompt.Button[0] != null)
		{
			Prompt.HideButton[0] = true;
			Yandere.StudentManager.NewUniforms++;
			Yandere.StudentManager.UpdateStudents();
			Yandere.StudentManager.Uniforms[Yandere.StudentManager.NewUniforms] = base.transform;
			Debug.Log("A new uniform has been spawned. The number of ''New Uniforms'' at school is now " + Yandere.StudentManager.NewUniforms + ".");
		}
		if (Type == 1)
		{
			base.gameObject.name = "School Uniform";
		}
		if (Type == 2)
		{
			base.gameObject.name = "Swimsuit";
		}
		else if (Type == 3)
		{
			base.gameObject.name = "Gym Uniform";
		}
		else
		{
			base.gameObject.name = "Folded Club Uniform";
		}
		if (GameGlobals.Eighties && BloodyEightiesTexture != null)
		{
			for (int j = 1; j < MyRenderer.Length; j++)
			{
				MyRenderer[j].material.mainTexture = BloodyEightiesTexture;
			}
		}
	}

	private void Update()
	{
		if (!Clean)
		{
			return;
		}
		InPosition = Yandere.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position);
		if (Yandere.MyRenderer.sharedMesh != Yandere.Towel || Yandere.Bloodiness != 0f || !InPosition)
		{
			Prompt.HideButton[0] = true;
		}
		else
		{
			Prompt.HideButton[0] = false;
		}
		if (Prompt.Circle[0] != null && Prompt.Circle[0].fillAmount == 0f)
		{
			Object.Instantiate(SteamCloud, Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
			Yandere.CurrentUniformOrigin = 2;
			Yandere.Stripping = true;
			Yandere.CanMove = false;
			if (Type > 1)
			{
				Yandere.MyLocker.Bloody[Type] = false;
				Yandere.MyLocker.UpdateButtons();
			}
			Timer += Time.deltaTime;
		}
		if (Timer > 0f)
		{
			Timer += Time.deltaTime;
			if (Timer > 1.5f)
			{
				if (!ClubAttire)
				{
					Yandere.Schoolwear = Type;
					Yandere.ChangeSchoolwear();
				}
				else
				{
					Debug.Log("Changing into club attire...");
					Yandere.ChangeClubwear();
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CannotChange = false;
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CheckYandereClub();
				}
				Object.Destroy(base.gameObject);
			}
		}
		if (CleanTexture != null && MyRenderer[1].material.mainTexture != CleanTexture)
		{
			Debug.Log("My name is " + base.gameObject.name + " and for some reason I had the incorrect texture a moment ago.");
			for (int i = 1; i < MyRenderer.Length; i++)
			{
				MyRenderer[i].material.mainTexture = CleanTexture;
			}
		}
	}

	public void CleanUp()
	{
		Debug.Log("A folded uniform is firing the ''CleanUp()'' function.");
		if (GameGlobals.Eighties && EightiesTexture != null)
		{
			CleanTexture = EightiesTexture;
		}
		Clean = true;
		for (int i = 1; i < MyRenderer.Length; i++)
		{
			MyRenderer[i].material.mainTexture = CleanTexture;
		}
	}
}
