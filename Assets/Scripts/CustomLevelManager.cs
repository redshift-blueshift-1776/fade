using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomLevelManager : MonoBehaviour
{
    [Header("X Dimension")]
    [SerializeField] private Slider xDimensionSlider;
    [SerializeField] private TMP_Text xDimensionText;

    [Header("Z Dimension")]
    [SerializeField] private Slider zDimensionSlider;
    [SerializeField] private TMP_Text zDimensionText;

    [Header("X Width")]
    [SerializeField] private Slider xWidthSlider;
    [SerializeField] private TMP_Text xWidthText;

    [Header("Z Width")]
    [SerializeField] private Slider zWidthSlider;
    [SerializeField] private TMP_Text zWidthText;

    [Header("Probability of Tile Being Empty")]
    [SerializeField] private Slider emptyTileProbabilitySlider;
    [SerializeField] private TMP_Text emptyTileProbabilityText;

    [Header("Probability of Empty Tile Spawning Room")]
    [SerializeField] private Slider emptyRoomProbabilitySlider;
    [SerializeField] private TMP_Text emptyRoomProbabilityText;

    [Header("Number of door rooms")]
    [SerializeField] private Slider numberOfDoorRoomsSlider;
    [SerializeField] private TMP_Text numberOfDoorRoomsText;

    [Header("Shuffle door colors")]
    [SerializeField] private Toggle shuffleDoorColorsToggle;

    [Header("Will help the player")]
    [SerializeField] private Toggle willHelpPlayerToggle;

    [Header("Time before helping")]
    [SerializeField] private Slider timeBeforeHelpingSlider;
    [SerializeField] private TMP_Text timeBeforeHelpingText;
    void Start()
    {
        initializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        updatePrefsAndUI();
    }

    private void initializeUI()
    {
        if (PlayerPrefs.HasKey("xDim"))
        {
            xDimensionSlider.value = PlayerPrefs.GetInt("xDim");
        }

        if (PlayerPrefs.HasKey("zDim"))
        {
            zDimensionSlider.value = PlayerPrefs.GetInt("zDim");
        }

        if (PlayerPrefs.HasKey("xWidth"))
        {
            xWidthSlider.value = PlayerPrefs.GetInt("xWidth");
        }

        if (PlayerPrefs.HasKey("zWidth"))
        {
            zWidthSlider.value = PlayerPrefs.GetInt("zWidth");
        }

        if (PlayerPrefs.HasKey("emptyTileProb"))
        {
            emptyTileProbabilitySlider.value = PlayerPrefs.GetFloat("emptyTileProb");
        }

        if (PlayerPrefs.HasKey("emptyRoomProb"))
        {
            emptyRoomProbabilitySlider.value = PlayerPrefs.GetFloat("emptyRoomProb");
        }

        if (PlayerPrefs.HasKey("numDoorRooms"))
        {
            numberOfDoorRoomsSlider.value = PlayerPrefs.GetInt("numDoorRooms");
        }

        if (PlayerPrefs.HasKey("shuffleDoorColors"))
        {
            shuffleDoorColorsToggle.isOn = PlayerPrefs.GetInt("shuffleDoorColors") == 1 ? true : false;
        }

        if (PlayerPrefs.HasKey("willHelpPlayer"))
        {
            willHelpPlayerToggle.isOn = PlayerPrefs.GetInt("willHelpPlayer") == 1 ? true : false;
        }

        if (PlayerPrefs.HasKey("timeBeforeHelping"))
        {
            timeBeforeHelpingSlider.value = PlayerPrefs.GetInt("timeBeforeHelping");
        }
    }

    private void updatePrefsAndUI()
    {
        float xDimension = xDimensionSlider.value;
        xDimensionText.text = ((int)xDimension).ToString();
        PlayerPrefs.SetInt("xDim", (int)xDimension);

        float zDimension = zDimensionSlider.value;
        zDimensionText.text = ((int)zDimension).ToString();
        PlayerPrefs.SetInt("zDim", (int)zDimension);

        float xWidth = xWidthSlider.value;
        xWidthText.text = ((int)xWidth).ToString();
        PlayerPrefs.SetInt("xWidth", (int)xWidth);

        float zWidth = zWidthSlider.value;
        zWidthText.text = ((int)zWidth).ToString();
        PlayerPrefs.SetInt("zWidth", (int)zWidth);

        float emptyTileProb = emptyTileProbabilitySlider.value;
        if (emptyTileProb < 0.01)
        {
            emptyTileProb = 0;
        }
        else if (emptyTileProb > 0.99)
        {
            emptyTileProb = 1;
        }
        emptyTileProbabilityText.text = ((int)Mathf.Ceil(emptyTileProb * 100)).ToString() + "%";
        PlayerPrefs.SetFloat("emptyTileProb", emptyTileProb);

        float emptyRoomProb = emptyRoomProbabilitySlider.value;
        if (emptyRoomProb < 0.01)
        {
            emptyRoomProb = 0;
        }
        else if (emptyRoomProb > 0.99)
        {
            emptyRoomProb = 1;
        }
        emptyRoomProbabilityText.text = ((int)Mathf.Ceil(emptyRoomProb * 100)).ToString() + "%";
        PlayerPrefs.SetFloat("emptyRoomProb", emptyRoomProb);

        float numberOfDoorRooms = numberOfDoorRoomsSlider.value;
        numberOfDoorRoomsText.text = ((int)numberOfDoorRooms).ToString();
        PlayerPrefs.SetInt("numDoorRooms", (int)numberOfDoorRooms);

        bool shuffleDoorColors = shuffleDoorColorsToggle.isOn;
        PlayerPrefs.SetInt("shuffleDoorColors", shuffleDoorColors ? 1 : 0);

        bool willHelpPlayer = willHelpPlayerToggle.isOn;
        PlayerPrefs.SetInt("willHelpPlayer", willHelpPlayer ? 1 : 0);

        float timeBeforeHelping = timeBeforeHelpingSlider.value;
        timeBeforeHelpingText.text = ((int)timeBeforeHelping).ToString() + "s";
        PlayerPrefs.SetInt("timeBeforeHelping", (int)timeBeforeHelping);
        
        timeBeforeHelpingSlider.gameObject.SetActive(willHelpPlayer);

        PlayerPrefs.Save();
    }
}
