
using UnityEngine;
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
    }