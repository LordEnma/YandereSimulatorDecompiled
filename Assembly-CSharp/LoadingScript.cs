using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
