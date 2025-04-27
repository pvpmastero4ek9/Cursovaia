using System.Collections;
using Mirror;
using UnityEngine;

namespace Core.Players
{
    public class LocalPlayer : MonoBehaviour
    {
        public Player Local_Player { get; private set; }

        public delegate void FoundPlayerHandler(Player LocalPlayer);
        public event FoundPlayerHandler FoundPlayer;

        private void Start()
        {
            StartCoroutine(WaitForPlayer());
        }

        // Update is called once per frame
        private IEnumerator WaitForPlayer()
        {
            yield return new WaitUntil(() => NetworkClient.localPlayer != null);

            Local_Player = NetworkClient.localPlayer.GetComponent<Player>();

            FoundPlayer?.Invoke(Local_Player);
        }
    }
}
