using UnityEngine;
using DG.Tweening;

public class FadeScreen : MonoBehaviour
{
	#region Fields
	[SerializeField] private bool _isFadeOnStart = true;
    [SerializeField] private float _fadeDuration = 2;
    [SerializeField] private Color _fadeColor;
    private Renderer _rend;

    #endregion

    #region Properties
    public float FadeDuration => _fadeDuration;

	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = false;

        if (_isFadeOnStart)
            FadeIn();
    }

	#endregion

	#region Methods
	public void FadeIn()
    {
        _rend.enabled = true;
        _fadeColor.a = 1;
        _rend.material.color = _fadeColor;        
        _rend.material.DOFade(0, _fadeDuration);
    }
    
    public void FadeOut()
    {
        _rend.enabled = true;
        _rend.material.color = _fadeColor;
        _rend.material.DOFade(1, _fadeDuration);
    }

	#endregion
}
