
using UnityEngine;
    using UnityEngine.AI;
    
    public class NavigationController : MonoBehaviour 
    {
       void Start ()
        {
        // Save the initial values of the dropdowns to the static variables
        //currentLocation = CurrentLocationDropdown.selectedOption;
        //targetLocation = TargetDestinationDropdown.selectedOption2;
            Debug.Log(CurrentLocationDropdown.selectedValue);
            Debug.Log(TargetDestinationDropdown.selectedOption2);
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          GameObject.Find("Initial location").transform.position=GameObject.Find(CurrentLocationDropdown.selectedValue).transform.position;
          agent.destination=GameObject.Find(TargetDestinationDropdown.selectedOption2).transform.position; 
       }
    }