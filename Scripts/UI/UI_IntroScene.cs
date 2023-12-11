using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_IntroScene : MonoBehaviour
{	
	[SerializeField]
	private Slider loadingSlider;
	
	[SerializeField]
	private Button startGameButton;
	
	protected void Awake()
	{
		startGameButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
		ResourceManager.Instance.LoadAllAsync("PreLoad", (key, count, totalCount) =>
		{
			loadingSlider.value = (float)count/totalCount;
			if (count == totalCount)
			{
				loadingSlider.gameObject.SetActive(false);
				startGameButton.gameObject.SetActive(true);
			}
		});

	}
}
