using UnityEngine;

public class GlassShardSpawnerScript : MonoBehaviour
{
	public Camera TestCamera;

	public Transform BrokenGlassParent;

	public GameObject[] Shards;

	public GameObject[] SpawnedShards;

	public Vector3[] ShardOrigins;

	public float minX = -5f;

	public float maxX = 5f;

	public float minY;

	public float maxY = 5f;

	public float minZ = 2.5f;

	public float maxZ = 7.5f;

	public bool Dream;

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
			gameObject.transform.position = new Vector3(0f, 0f, 1f) + new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
			while (gameObject.transform.position.z < 1f && gameObject.transform.position.x > -1f && gameObject.transform.position.x < 1f)
			{
				gameObject.transform.position = new Vector3(0f, 0f, 1f) + new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
			}
			if (Dream)
			{
				while (gameObject.transform.position.x > -1f && gameObject.transform.position.x < 1f)
				{
					gameObject.transform.position = new Vector3(0f, 0f, 1f) + new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
				}
			}
			gameObject.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
			gameObject.transform.localScale = new Vector3(50f, 50f, 50f);
			SpawnedShards[j] = gameObject;
			ShardOrigins[j] = gameObject.transform.position;
			gameObject.transform.parent = base.transform;
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

	public void RestoreShards()
	{
		base.enabled = true;
		FallTimer = 0f;
		Fall = false;
		int num = 0;
		GameObject[] spawnedShards = SpawnedShards;
		for (int i = 0; i < spawnedShards.Length; i++)
		{
			spawnedShards[i].transform.position = ShardOrigins[num];
			num++;
		}
	}
}
