using UnityEngine;

public class GlassShardSpawnerScript : MonoBehaviour
{
	public Camera TestCamera;

	public Transform BrokenGlassParent;

	public GameObject[] Shards;

	public GameObject[] SpawnedShards;

	public float FallTimer;

	public bool Fall;

	private void Start()
	{
		Shards = new GameObject[BrokenGlassParent.childCount];
		for (int i = 0; i < BrokenGlassParent.childCount; i++)
		{
			Shards[i] = BrokenGlassParent.GetChild(i).gameObject;
		}
		for (int j = 0; j < SpawnedShards.Length; j++)
		{
			GameObject gameObject = Object.Instantiate(Shards[Random.Range(1, Shards.Length)], base.transform.position, Quaternion.identity);
			gameObject.transform.position = new Vector3(0f, 0f, 1f) + new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), Random.Range(-2.5f, 7.5f));
			while (gameObject.transform.position.z < 1f && gameObject.transform.position.x > -1f && gameObject.transform.position.x < 1f)
			{
				gameObject.transform.position = new Vector3(0f, 0f, 1f) + new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), Random.Range(-2.5f, 7.5f));
			}
			gameObject.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
			gameObject.transform.localScale = new Vector3(50f, 50f, 50f);
			SpawnedShards[j] = gameObject;
		}
	}

	private void Update()
	{
		GameObject[] spawnedShards = SpawnedShards;
		foreach (GameObject gameObject in spawnedShards)
		{
			gameObject.transform.Rotate(new Vector3(36f, 36f, 36f) * Time.deltaTime);
			if (Fall)
			{
				FallTimer += Time.deltaTime;
				gameObject.transform.position -= new Vector3(0f, FallTimer * Time.deltaTime * 0.0025f, 0f);
			}
		}
	}

	public static bool isMeshInCameraView(Mesh mesh, Camera camera)
	{
		return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), mesh.bounds);
	}
}
