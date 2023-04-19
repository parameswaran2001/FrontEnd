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
            case 2: str1="Staff Room A-102";break;
            case 3: str1="Chemistry Lab/Physics Lab A-303";     break;
            case 4: str1="Lecture Hall A-306 CS-2"; break;
            case 5: str1="AI Lab B-204"; break;
            case 6: str1="Lecture Hall B-203"; break;
         }
         switch(DropDownHandler2.sendercopy2)
         {
            case 0: str2="Girls' Washroom A-10GW"; break;
            case 1: str2="Visitors Room A-101";   break;
            case 2: str2="Staff Room A-102";       break;
            case 3: str2="Chemistry Lab/Physics Lab A-303";     break;
            case 4: str2="Lecture Hall A-306 CS-2"; break;
            case 5: str2="AI Lab B-204"; break;
            case 6: str2="Lecture Hall B-203"; break;
         }
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          GameObject.Find("Initial location").transform.position=GameObject.Find(str1).transform.position;
          goal.transform.position =GameObject.Find(str2).transform.position; 
          agent.destination=goal.position;
       }
    }