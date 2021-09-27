using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI shipCodeText;
    public TMP_InputField searchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    public List<Material> capsuleColors;
    public List<Material> metalColors;
    public List<Material> neonColors;

    public ColourShip ship;

    int permutationCode = 0;

    // Start is called before the first frame update
    void Start()
    {
        searchCodeButton.onClick.AddListener(SearchCode);
        nextButton.onClick.AddListener(NextCombination);
        previousButton.onClick.AddListener(PreviousCombination);
        showCodesButton.onClick.AddListener(ShowCodes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SearchCode()
    {
        int value = int.Parse(searchCodeField.text);
        Debug.Log(value);
    }

    void NextCombination()
    {

    }

    void PreviousCombination()
    { 
    
    }

    void ShowCodes()
    {
        StartCoroutine(NextColor());
    }

    IEnumerator NextColor()
    {
        yield return new WaitForSeconds(0.05f);

        //Estoy encontrando el primer color de las luces
        int lightsIndex = permutationCode % neonColors.Count;
        Debug.Log($"lightsIndex is {lightsIndex} in permutation code: {permutationCode}");
        
        //Revisar ciclos de neon
        //De esos ciclos obtenbgo el index del holder
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        Debug.Log(permutationCode / neonColors.Count);

        //Revisar las permutaciones que voy a tener entre neonColors y metalColors
        //De estas permutaciones obtenbgo el index de la nave
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;

        //Revisar las permutaciones que voy a tener entre neonColors , metalColors y metalColors
        //Des este ciclo obtengo el index de capsule
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        shipCodeText.text = permutationCode.ToString();
        permutationCode++;

        StartCoroutine(NextColor());
    }
}
