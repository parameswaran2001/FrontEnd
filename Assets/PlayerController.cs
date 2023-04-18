 using UnityEngine;
    using UnityEngine.AI;
    
    public class PlayerController : MonoBehaviour {
       
       public Transform goal;
       string str1,str2;
       void Start () {
         switch(DropDownHandler1.sendercopy1)
         {
            case 0: str1="Girls' Washroom A-10GW"; break;
            case 1: str1="Visitors Room A-101";   break;
            case 2: str1="Staff Room A-102";       break;
         }
         switch(DropDownHandler2.sendercopy2)
         {
            case 0: str2="Girls' Washroom A-10GW"; break;
            case 1: str2="Visitors Room A-101";   break;
            case 2: str2="Staff Room A-102";       break;
         }
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          agent.transform.position=GameObject.Find(str1).transform.position;
          goal.transform.position =GameObject.Find(str2).transform.position; 
          agent.destination=goal.position;
       }
    }