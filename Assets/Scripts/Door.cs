using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _isPlayerInsight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _isPlayerInsight = !_isPlayerInsight;

            if(_isPlayerInsight == true)
            {
                _alarm.TurnOn();
            }
            else
            {
                _alarm.TurnOff();
            }
        }
    }
}
