using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
	public MeshRenderer MyRenderer;

	public Shader OriginalShader;

	public GameObject GarbageBag;

	public PromptScript Prompt;

	public MeshFilter MyFilter;

	public AudioClip WrapSFX;

	public Texture[] OriginalTextures;

	public Texture[] Textures;

	public Mesh[] Meshes;

	public bool OriginalTexturesGathered;

	public bool Sacrifice;

	public bool Tutorial;

	public bool Female;

	public int StudentID;

	public int Type;

	public int UniformID;

	public void Start()
	{
		Debug.Log("The Start() function of this " + base.gameObject.name + " is now running.");
		if (!OriginalTexturesGathered)
		{
			OriginalTextures = new Texture[MyRenderer.materials.Length];
			for (int i = 0; i < MyRenderer.materials.Length; i++)
			{
				OriginalTextures[i] = MyRenderer.materials[i].mainTexture;
			}
			OriginalShader = MyRenderer.sharedMaterial.shader;
			OriginalTexturesGathered = true;
		}
		Tutorial = Prompt.Yandere.StudentManager.KokonaTutorial;
		QualityManagerScript qualityManager = Prompt.Yandere.StudentManager.QualityManager;
		if (qualityManager.TVHeads || qualityManager.CensorCorpses)
		{
			if (Female && Type == 2)
			{
				MyRenderer.materials[0].shader = qualityManager.Hologram;
				MyRenderer.materials[1].shader = qualityManager.Hologram;
				qualityManager.ApplyMatrixSettings(MyRenderer.materials[0], qualityManager.MatrixTexture);
				qualityManager.ApplyMatrixSettings(MyRenderer.materials[1], qualityManager.MatrixTexture);
			}
			else
			{
				for (int j = 0; j < MyRenderer.materials.Length; j++)
				{
					MyRenderer.materials[j].shader = qualityManager.Hologram;
					qualityManager.ApplyMatrixSettings(MyRenderer.materials[j], qualityManager.MatrixTexture);
				}
			}
			return;
		}
		if (UniformID == 0)
		{
			if (Female)
			{
				UniformID = StudentGlobals.FemaleUniform;
			}
			else
			{
				UniformID = StudentGlobals.MaleUniform;
			}
		}
		if (Female && Type == 2)
		{
			MyFilter.mesh = Meshes[UniformID];
			if (UniformID < 2)
			{
				MyRenderer.materials[0].shader = OriginalShader;
				MyRenderer.materials[1].shader = OriginalShader;
				MyRenderer.materials[0].mainTexture = Textures[UniformID];
				MyRenderer.materials[1].mainTexture = Textures[UniformID];
			}
		}
		else
		{
			for (int k = 0; k < MyRenderer.materials.Length && k < OriginalTextures.Length; k++)
			{
				MyRenderer.materials[k].shader = OriginalShader;
				MyRenderer.materials[k].mainTexture = OriginalTextures[k];
			}
		}
	}

	private void Update()
	{
		if (Prompt != null)
		{
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
		else
		{
			Prompt = base.gameObject.GetComponent<PromptScript>();
		}
		if (Prompt.Yandere.StudentManager.KokonaTutorialObject.Phase == 2)
		{
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
		if ((double)base.transform.position.x > -32.16667 && base.transform.position.x < -31f && base.transform.position.z > 23.5f && base.transform.position.z < 24.5f && base.transform.position.y < 0f && !Tutorial)
		{
			Debug.Log("Destroying a body part or trash bag that fell through the floor.");
			Object.Destroy(base.gameObject);
		}
	}
}
