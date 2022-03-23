using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _startVolume;
    private float _step = 0.2f;
    private float _target = 1;
    private bool _isPlaying = false;

    private void Start()
    {
        _audioSource.volume = _startVolume;
    }

    public void StartCoroutine()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        var changeVolumeJob = StartCoroutine(ChangeVolume());
        var waitHalfSecond = new WaitForSeconds(0.5f);
        _isPlaying = true;
        _audioSource.Play();

        while (_isPlaying == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
            yield return waitHalfSecond;
            if(_target == 1)
            {
                _target = 0;
            }
            else if(_target == 0)
            {
                _target = 1;
            }
        }
        StopCoroutine(changeVolumeJob);
    }

    public void EndAlarm()
    {
        _isPlaying = false;
    }
}
