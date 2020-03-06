using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
	GameObject musica;
	public string s;

	void Awake()
	{
		musica = GameObject.Find("music");
		Destroy(musica);
		s = PlayerPrefs.GetString("proximaCena");
		Invoke("iniciarRotina", 5f);
	}

	void iniciarRotina(){
		StartCoroutine(LoadYourAsyncScene(s));
	}

	IEnumerator LoadYourAsyncScene(string s)
	{
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(s);

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
