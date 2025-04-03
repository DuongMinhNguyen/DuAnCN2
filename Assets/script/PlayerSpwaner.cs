using UnityEngine;
using Fusion;
using script;

public class PlayerSpwaner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(-2f, 2f),
                2,
                Random.Range(-2f, 2f)
            );
            Runner.Spawn(PlayerPrefab, randomSpawnPosition, Quaternion.identity,
                Runner.LocalPlayer, (runner, obj) =>
                {
                    var _player = obj.GetComponent<PlayerSetup>();
                    _player?.SetupCamera();
                }
            );

        }
    }
}
