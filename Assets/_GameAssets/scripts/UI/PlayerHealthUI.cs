using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("REFERANCES")]
    [SerializeField] private Image[] _playerHealthImages;

    [Header("SPRİTES")]
    [SerializeField] private Sprite _playerHealthySprite;
    [SerializeField] private Sprite _playerUnHealthySprite;

    [Header("SETTİNGS")]
    [SerializeField] private float _scaleDuration;

    private RectTransform[] _playerHealthTransform;

    private void Awake()
    {
        _playerHealthTransform = new RectTransform[_playerHealthImages.Length];

        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            _playerHealthTransform[i] = _playerHealthImages[i].gameObject.GetComponent<RectTransform>();
        }
    }

    // FOR TESTİNG!
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AnimateDamage();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AnimateDamageForAll();
        }
    }

    public void AnimateDamage()
    {
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            if (_playerHealthImages[i].sprite == _playerHealthySprite)
            {
                AnimateDamageSprite(_playerHealthImages[i], _playerHealthTransform[i]);
                break;
            }
        }
    }

    public void AnimateDamageForAll()
    {
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            AnimateDamageSprite(_playerHealthImages[i], _playerHealthTransform[i]);
        }
    }

        private void AnimateDamageSprite(Image activeImage, RectTransform activeImageTransform)
    {
        activeImageTransform.DOScale(0f, _scaleDuration).SetEase(Ease.InBack).OnComplete(() =>
        {
            activeImage.sprite = _playerUnHealthySprite;
            activeImageTransform.DOScale(1f, _scaleDuration).SetEase(Ease.OutBack);
        });
    }
}
        