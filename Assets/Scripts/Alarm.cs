using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _startVolume;
    private float _step = 1f;
    private float _target = -1;
    private bool _isPlaying = false;

    private void Start()
    {
        _audioSource.volume = _startVolume;
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        var waitHalfSecond = new WaitForSeconds(0.5f);
        _isPlaying = true;
        var changeVolumeJob = StartCoroutine(ChangeVolume());

        while (_isPlaying == true)
        {
            _audioSource.Play();
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
            yield return waitHalfSecond;
            _target *= _target;
        }
        StopCoroutine(changeVolumeJob);
    }

    public void EndAlarm()
    {
        _isPlaying = false;
    }
}
