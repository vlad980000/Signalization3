using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _startVolume;
    private float _step = 0.2f;
    private float _target = 0;
    private bool _isPlaying = false;
    
    public void StartCoroutine()
    {
        var stratAlarmController = StartCoroutine(AlarmController());
        _audioSource.volume = _startVolume;
    }

    private IEnumerator AlarmController()
    {
        var waitOneSecond = new WaitForSeconds(1f);
        _audioSource.Play();

        while(_isPlaying == false)
        {
            while (_audioSource.volume != _target)
            {
                VolumeCotroller();
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

    private void VolumeCotroller()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
    }

    public void AlarmEnd()
    {
        _isPlaying = false;
        _audioSource.Stop();
    }
}
