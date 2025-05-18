using UnityEngine;
using Core.Entitys;
using Mirror;
using System.Linq;
using Core.Players;

public class Enemys : Entity
{
    [SerializeField] private int _giveExpirienceValue;
    
    private void OnEnable()
    {
        DiedEntity += GiveExpiriencePlayer;
    }

    private void GiveExpiriencePlayer()
    {
        GameObject[] _playersTransform = GameObject.FindGameObjectsWithTag("Player");
        GameObject _currentPlayer = _playersTransform.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
        _currentPlayer.GetComponent<Player>().PlayerData.PlayerExpirience += _giveExpirienceValue;
    }
}
