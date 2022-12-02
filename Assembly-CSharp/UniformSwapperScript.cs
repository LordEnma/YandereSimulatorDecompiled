using UnityEngine;

public class UniformSwapperScript : MonoBehaviour
{
	public Texture[] UniformTextures;

	public Mesh[] UniformMeshes;

	public Texture FaceTexture;

	public SkinnedMeshRenderer MyRenderer;

	public int UniformID;

	public int FaceID;

	public int SkinID;

	public Transform LookTarget;

	public Transform Head;

	private void Start()
	{
		int maleUniform = StudentGlobals.MaleUniform;
		MyRenderer.sharedMesh = UniformMeshes[maleUniform];
		Texture mainTexture = UniformTextures[maleUniform];
		switch (maleUniform)
		{
		case 1:
			SkinID = 0;
			UniformID = 1;
			FaceID = 2;
			break;
		case 2:
			UniformID = 0;
			FaceID = 1;
			SkinID = 2;
			break;
		case 3:
			UniformID = 0;
			FaceID = 1;
			SkinID = 2;
			break;
		case 4:
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
			break;
		case 5:
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
			break;
		case 6:
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
			break;
		}
		MyRenderer.materials[FaceID].mainTexture = FaceTexture;
		MyRenderer.materials[SkinID].mainTexture = mainTexture;
		MyRenderer.materials[UniformID].mainTexture = mainTexture;
	}

	private void LateUpdate()
	{
		if (LookTarget != null)
		{
			Head.LookAt(LookTarget);
		}
	}
}
