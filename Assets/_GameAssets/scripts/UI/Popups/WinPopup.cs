using MaskTransitions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private Button _OneMoreButton;
    [SerializeField] private Button _MainMenuButton;
    [SerializeField] private TMP_Text _TimerText;

    private void OnEnable()
    {
        _TimerText.text = _timerUI.GetFinalTime();

        _OneMoreButton.onClick.AddListener(OnOneMoreClicked);
        
        _MainMenuButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
        });
    }

    private void OnOneMoreClicked()
    {
        TransitionManager.Instance.LoadLevel(Consts.SceneNames.GAME_SCENE);
    }
}