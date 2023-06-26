using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public bool isBridgeBuilt = false; // Geeft aan of de brug al gebouwd is
    public GameObject requiredObjectParent; // Het ouderobject dat het vereiste object bevat
    [SerializeField] private GridLevel3 grid;
    
     
    private void Start()
    {
        
    }
    public void Update()
    {
    }

    public void BuildBridge()
    {
        // Voer hier de acties uit om de brug te bouwen, bijvoorbeeld het activeren van een animatie of het verplaatsen van het brugmodel naar de juiste positie
        Debug.Log("Bridge built!");
        isBridgeBuilt= true;
        grid.GenerateBrugTile();
        // Voer eventuele andere acties uit die je wilt doen wanneer de brug is gebouwd
    }
}
