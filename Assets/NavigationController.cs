
/*using UnityEngine;
    using UnityEngine.AI;
    
    public class NavigationController : MonoBehaviour 
    {
         public Transform goal;
       void Start ()
        {
           
        // Save the initial values of the dropdowns to the static variables
        //currentLocation = CurrentLocationDropdown.selectedOption;
        //targetLocation = TargetDestinationDropdown.selectedOption2;
            Debug.Log(CurrentLocationDropdown.selectedValue1);
            Debug.Log(TargetDestinationDropdown.selectedValue2);
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          GameObject.Find("Initial location").transform.position=GameObject.Find(CurrentLocationDropdown.selectedValue1).transform.position;
           goal.transform.position=GameObject.Find(TargetDestinationDropdown.selectedValue2).transform.position; 
          agent.destination=goal.position; 
       }
    }*/

 /*using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public NavMeshAgent agent;
    string currentLocation = CurrentLocationDropdown.selectedValue1;
    string targetDestination = TargetDestinationDropdown.selectedValue2;
    

    private void Start()
    {
        // Assuming you have set up the references to the dropdown menus and the NavMesh agent in the Unity Inspector.
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(currentLocation);
        Debug.Log(targetDestination);
    }

    public void SetAgentDestination()
    {


        // Set the current location of the agent
        GameObject currentLocationObj = GameObject.Find(currentLocation);
        if (currentLocationObj != null)
        {
            agent.transform.position = currentLocationObj.transform.position;
        }
        else
        {
            Debug.LogError("Could not find current location: " + currentLocation);
            return;
        }

        // Set the destination for the agent
        GameObject targetDestinationObj = GameObject.Find("Destination");
        targetDestinationObj.transform.position=GameObject.Find(targetDestination).transform.position;

        if (targetDestinationObj != null)
        {
            agent.SetDestination(targetDestinationObj.transform.position);
        }
        else
        {
            Debug.LogError("Could not find target destination: " + targetDestination);
        }
    }
}*/
/*using UnityEngine;
    using UnityEngine.AI;
    
    public class PlayerController : MonoBehaviour {
       
       public Transform goal;

       void Start () {
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          GameObject.Find("Initial location").transform.position=GameObject.Find(CurrentLocationDropdown.selectedValue1).transform.position;
          goal.transform.position =GameObject.Find(TargetDestinationDropdown.selectedValue2).transform.position; 
          agent.destination=goal.position;
       }
    }
*/
/*using UnityEngine;
    using UnityEngine.AI;
    
    public class NavigationController : MonoBehaviour {
       
       public Transform goal;
       
       void Start () {
        //Debug.Log(CurrentLocationDropdown.selectedValue1);
            //Debug.Log(TargetDestinationDropdown.selectedValue2);
           
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          
          agent.destination = goal.position;}
  }*/
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
    public string currentLocation;
    public string targetDestination;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetAgentDestination();
    }

    private void SetAgentDestination()
    {
        currentLocation = CurrentLocationDropdown.selectedValue1;
        targetDestination = TargetDestinationDropdown.selectedValue2;

        GameObject currentLocationObj = GameObject.Find(currentLocation);
        GameObject targetDestinationObj = GameObject.Find(targetDestination);

        if (currentLocationObj != null && targetDestinationObj != null)
        {
            agent.speed=2.5f;
            agent.Warp(currentLocationObj.transform.position);
            agent.SetDestination(targetDestinationObj.transform.position);
        }
        else
        {
            Debug.LogError("Could not find current location or target destination GameObjects.");
        }
    }
}

