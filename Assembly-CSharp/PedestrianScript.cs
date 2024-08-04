using UnityEngine;

public class PedestrianScript : MonoBehaviour
{
	public Animation MyAnim;

	public string[] WalkAnims;

	public Renderer MyRenderer;

	public Shader CorrectShader;

	public int ClothingID;

	public int FaceID;

	public int HairID;

	public int SkinID;

	public float Speed;

	public bool Male;

	private void Start()
	{
		Speed = Random.Range(0.9f, 1.1f);
		string animation = WalkAnims[Random.Range(0, WalkAnims.Length)];
		MyAnim.Play(animation);
		MyAnim[animation].speed = Speed;
		MyRenderer.materials[ClothingID].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		MyRenderer.materials[HairID].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		MyRenderer.materials[ClothingID].shader = CorrectShader;
		MyRenderer.materials[HairID].shader = CorrectShader;
		MyRenderer.materials[ClothingID].SetFloat("_Saturation", 0f);
		MyRenderer.materials[HairID].SetFloat("_Saturation", 0f);
		MyRenderer.materials[ClothingID].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[HairID].SetFloat("_BlendAmount", 0f);
		MyRenderer.materials[ClothingID].SetFloat("_BlendAmount1", 0f);
		MyRenderer.materials[HairID].SetFloat("_BlendAmount1", 0f);
	}

	private void Update()
	{
		base.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
