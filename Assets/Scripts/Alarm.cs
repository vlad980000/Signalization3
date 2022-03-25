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


    public void StartCoroutine()
    {
        _startCoroutine = StartCoroutine(RegulatingVolume());
        _audioSource.volume = _startVolume;
    }

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
            if(_target == 1)
            {
                _target--;
            }
            else if(_target == 0)
            {
                _target++;
            }
        }     
    }

    public void InterruptAlarm()
    {
        _isPlaying = false;
        _audioSource.Stop();
        StopCoroutine(_startCoroutine);
    }
}
