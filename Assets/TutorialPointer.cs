using System.Reflection;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour
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
        
        Vector3 midpoint = getMidpoint();
        float distance = getDistance();
        Vector3 direction = getDirection();

        transform.rotation = Quaternion.LookRotation(direction);
        transform.position = midpoint;
        transform.localScale = new Vector3(0.25f, 0.1f, distance + 0.1f);
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
}
