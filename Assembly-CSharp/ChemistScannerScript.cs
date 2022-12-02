using UnityEngine;

public class ChemistScannerScript : MonoBehaviour
{
	public StudentScript Student;

	public Renderer MyRenderer;

	public Texture AlarmedEyes;

	public Texture DeadEyes;

	public Texture SadEyes;

	public Texture[] Textures;

	public float Timer;

	public int PreviousID;

	public int ID;

	private void Update()
	{
		if (Student.Ragdoll != null && Student.Ragdoll.enabled)
		{
			MyRenderer.materials[1].mainTexture = DeadEyes;
			base.enabled = false;
			return;
		}
		if (Student.Dying)
		{
			if (MyRenderer.materials[1].mainTexture != AlarmedEyes)
			{
				MyRenderer.materials[1].mainTexture = AlarmedEyes;
			}
			return;
		}
		if (Student.Emetic || Student.Lethal || Student.Tranquil || Student.Headache)
		{
			if (MyRenderer.materials[1].mainTexture != Textures[6])
			{
				MyRenderer.materials[1].mainTexture = Textures[6];
			}
			return;
		}
		if (Student.Grudge)
		{
			if (MyRenderer.materials[1].mainTexture != Textures[1])
			{
				MyRenderer.materials[1].mainTexture = Textures[1];
			}
			return;
		}
		if (Student.LostTeacherTrust)
		{
			if (MyRenderer.materials[1].mainTexture != SadEyes)
			{
				MyRenderer.materials[1].mainTexture = SadEyes;
			}
			return;
		}
		if (Student.WitnessedMurder || Student.WitnessedCorpse)
		{
			if (MyRenderer.materials[1].mainTexture != AlarmedEyes)
			{
				MyRenderer.materials[1].mainTexture = AlarmedEyes;
			}
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 2f)
		{
			while (ID == PreviousID)
			{
				ID = Random.Range(0, Textures.Length);
			}
			MyRenderer.materials[1].mainTexture = Textures[ID];
			PreviousID = ID;
			Timer = 0f;
		}
	}
}
