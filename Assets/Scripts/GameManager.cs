using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] private City_Generator cityGenerator;
    [SerializeField] private GameObject tutorialPointer;
    [SerializeField] GameObject player;
    [SerializeField] private Slider energyBarSlider;
    [SerializeField] private Image energyBarSymbol;
    [SerializeField] private TMP_Text energyNumberText;
    [SerializeField] private Image energyBarFill;
    [SerializeField] private bool willHelpPlayer = false;
    private PlayerMovement playerMovement;
    HashSet<float[]> lightpoleGlobalPositions = new HashSet<float[]>();
    private float energy = 100;
    private float energyGainMultiplier = 20f;
    private float energyLossPerSecond = 3f;
    private float minDistanceToLightpoleThreshold = 10f;

    private bool isInCutscene = false;

    [SerializeField] public int nextScene;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        initializeEnvironment();
        if (willHelpPlayer)
        {
            StartCoroutine(handleHelpPlayer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleEnergy();
        updateEnergyDisplay();
    }

    private void initializeEnvironment()
    {
        RenderSettings.skybox = null;
        RenderSettings.sun = null;
        RenderSettings.subtractiveShadowColor = Color.black;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = Color.black;
        RenderSettings.ambientSkyColor = Color.black;
        RenderSettings.ambientIntensity = 0f;
        RenderSettings.reflectionIntensity = 0.2f;

        DynamicGI.UpdateEnvironment(); 
    }

    public void handleEnergy() {
        float distance = getDistanceToClosestLightpole();
        
        if (distance < minDistanceToLightpoleThreshold)
        {
            energy += energyGainMultiplier * Time.deltaTime / distance;
            energy = Mathf.Min(100, energy);
        }
        else if (!isInCutscene)
        {
            float energyLossMultiplier = playerMovement.isBoosting ? 2 : 1;
            energy -= energyLossPerSecond * energyLossMultiplier * Time.deltaTime;
        }

        if (energy < 0)
        {
            killPlayer();
        }
    }

    //can not be called in Start, as generation might be finished after
    public void storeLightpoleGlobalPositions()
    {
        lightpoleGlobalPositions = cityGenerator.getLightpoleGlobalPositions();
        //debugLightpoleGlobalPositions();
    }

    private void debugLightpoleGlobalPositions()
    {
        foreach (float[] pos in lightpoleGlobalPositions)
        {
            Debug.Log(pos[0] + " " + pos[1] + " " + pos[2]);
        }
    }

    private float getDistanceToClosestLightpole()
    {
        float minDist = Mathf.Infinity;
        Vector3 playerPos = player.transform.position;

        foreach (float[] pos in lightpoleGlobalPositions)
        {
            Vector3 lightpolePos = new Vector3(pos[0], pos[1], pos[2]);
            float dist = (playerPos - lightpolePos).magnitude;
            minDist = Mathf.Min(dist, minDist);

            //tiny optimization
            if (minDist < minDistanceToLightpoleThreshold)
            {
                return minDist;
            }
        }
        return minDist;
    }

    private void updateEnergyDisplay()
    {
        energyNumberText.text = Mathf.Ceil(Mathf.Clamp(energy, 0, 100)).ToString();
        energyBarSlider.value = Mathf.Clamp(energy, 0, 100);
        Color color = Color.Lerp(Color.green, Color.red, 1 - energy / 100);
        energyBarSymbol.color = color;
        energyBarFill.color = color;
    }

    private void killPlayer()
    {
        SceneManager.LoadScene(19);
    }

    public void setIsInCutscene(bool b)
    {
        isInCutscene = b;
    }
    
    public void collectedCollectible()
    {
        StartCoroutine(toNextScene());
    }

    public IEnumerator toNextScene()
    {
        isInCutscene = true;
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isInCutscene = false;
        StopAllCoroutines();
        SceneManager.LoadScene(nextScene);
    }

    [SerializeField] private float timeUntilHelp = 120f;
    private IEnumerator handleHelpPlayer()
    {
        yield return new WaitForSeconds(2f);
        List<GameObject> keysAndCollectibles = cityGenerator.getKeysAndCollectible();

        keysAndCollectibles.Reverse();
        Stack<GameObject> stack = new Stack<GameObject>(keysAndCollectibles);

        GameObject currPointer = GameObject.FindWithTag("TutorialPointer");
        if (currPointer == null)
        {
            currPointer = Instantiate(tutorialPointer);
        }
        TutorialPointer script = currPointer.GetComponent<TutorialPointer>();

        float t = 0;
        bool waitingToShowNext = false;

        while (true)
        {
            if (script.isDestinationCollected() && !waitingToShowNext && stack.Count > 0)
            {
                waitingToShowNext = true;
                t = 0;
            }

            if (waitingToShowNext)
            {
                t += Time.deltaTime;
                if (t >= timeUntilHelp)
                {
                    script.setDestination(stack.Pop());
                    waitingToShowNext = false;
                }
            }
            yield return null;
        }
    }
}
