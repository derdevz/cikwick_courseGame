using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{
    [Header("REFERENCES")]
    [SerializeField] private Animator _spatulaAnimator;

    [Header("SETTINGS")]
    [SerializeField] private float _jumpforce;

    private bool _isActivated;

    public void boost(PlayerController playerController)
    {
        if(_isActivated) { return; }
        PlayBoostAnimation();
        Rigidbody playerRigidbody = playerController.GetPlayerRigidbody();

        playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z);
        playerRigidbody.AddForce(transform.forward * _jumpforce, ForceMode.Impulse);
        _isActivated = true;
        Invoke(nameof(ResetActivasion), 0.2f);
    }

    private void PlayBoostAnimation()
    {
        _spatulaAnimator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPİNG);
    }

    private void ResetActivasion()
    {
        _isActivated = false;
    }
}