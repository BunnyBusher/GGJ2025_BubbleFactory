using UnityEngine;

public class WoodDrop : Pickup, iCollectible
{
   

    public void Collect()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        player.GatherRessource(this.gameObject);
    }
}
