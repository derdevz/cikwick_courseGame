using MaskTransitions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _MainMenuButton;
    [SerializeField] private TMP_Text _TimerText;

    private void OnEnable()
    {
        _TimerText.text = _timerUI.GetFinalTime();

        _tryAgainButton.onClick.AddListener(OnTryAgainButtonClicked);

        _MainMenuButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
        });
    }

    private void OnTryAgainButtonClicked()
    {
        TransitionManager.Instance.LoadLevel(Consts.SceneNames.GAME_SCENE);
    }
}