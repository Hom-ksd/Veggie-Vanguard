using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;

    private void Awake()
    {
        exitButton = GetComponent<Button>();
    }

    private void Start()
    {
        exitButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManagerUtility.instance.ChangeScene(1);
        Time.timeScale = 1f;
    }
}
