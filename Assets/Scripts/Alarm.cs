using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _startVolume;

    private Coroutine _startCoroutine;
    private float _step = 0.2f;
    private float _target = 0;
    private bool _isPlaying = false;
    
    private IEnumerator RegulatingVolume()
    {
        var waitOneSecond = new WaitForSeconds(1f);
        _audioSource.Play();

        while(_isPlaying == false)
        {
            while (_audioSource.volume != _target)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
                yield return waitOneSecond;
            }
            _target = _target == 1 ? 0 : 1;
        }
    }

    public void TurnOn()
    {
        _startCoroutine = StartCoroutine(RegulatingVolume());
        _audioSource.volume = _startVolume;
    }

    

    public void TurnOff()
    {
        _isPlaying = false;
        _audioSource.Stop();
        StopCoroutine(_startCoroutine);
    }
}
