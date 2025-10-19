using UnityEngine;

public class TutorialPointer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject destination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (destination == null)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            return;
        }
        if (!destination.activeInHierarchy)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            return;
        }
        Vector3 midpoint = getMidpoint();
        float distance = getDistance();
        Vector3 direction = getDirection();

        transform.rotation = Quaternion.LookRotation(direction);
        transform.position = midpoint;
        transform.localScale = new Vector3(0.25f, 0.1f, distance + 0.1f);
    }

    public void setDestination(GameObject gameObject)
    {
        destination = gameObject;
        GetComponent<MeshRenderer>().enabled = true;
    }

    private Vector3 getMidpoint()
    {
        return (player.transform.position + destination.transform.position) / 2;
    }

    private float getDistance()
    {
        return (player.transform.position - destination.transform.position).magnitude;
    }

    private Vector3 getDirection()
    {
        return destination.transform.position - player.transform.position;
    }
    
    public bool isDestinationCollected()
    {
        return destination == null || !destination.activeInHierarchy;
    }
}
