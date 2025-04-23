using UnityEngine;
using Core.Entitys;
using Mirror;
using System.Linq;
using Core.Players;

public class Enemys : Entity
{
    [SerializeField] private int _giveExpirienceValue;
    protected override void Die()
    {
        GiveExpiriencePlayer();

        Destroy(gameObject);
    }

    private void GiveExpiriencePlayer()
    {
        GameObject[] _playersTransform = GameObject.FindGameObjectsWithTag("Player");
        GameObject _currentPlayer = _playersTransform.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
        _currentPlayer.GetComponent<Player>().PlayerData.PlayerExpirience += _giveExpirienceValue;
    }
}
