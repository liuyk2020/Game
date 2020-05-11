
using UnityEngine;

using UnityEngine.UI;


public class PickUp : MonoBehaviour 

{
    
     GameObject player;
    public bool IconPicSwith;
     
    
    //public Item item;
    //public string ChatName;
   // private bool canchat = false;
    public bool canpick = false;
    public float dis;

    public void Awake()
    {
        player = GameObject.Find("FPSController");       

    }
    private void OnTriggerEnter(Collider other)
    {
        // canchat = true;
        canpick = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //canchat = false;
        canpick = false;


    }
    //private void pickitem()
    //{
    //    dis = vector3.distance(player.transform.position, transform.position);
    //    if (dis < 1.5f)
    //    {
    //        canpick = true;
    //    }
    //    else
    //    {
    //        canpick = false;
    //    }
    //}

   

    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Say();
            pickup();
            
        }

    }
  

    void pickup()
    {

        if (canpick)
        {
            //Debug.Log("pickup item"+item.name);
            //inventory.instance.Add(item);
            //penIcon = GameObject.Find("penIcon"); 放到Start 比较好 不会在UpDate 里无限调用
            //Destroy(gameObject);
            gameObject.transform.position = new Vector3(100, 100, 100);
            //GetComponent<Image>().enabled = true;
            //IconPicSwith = true;
            



        }
        
    }

   


    //void Say()
    //{
    //    if (canchat)
    //    {
    //        Debug.Log("chat");
    //        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    //        if (flowchart.HasBlock(ChatName))
    //        {
    //            flowchart.ExecuteBlock(ChatName);
    //        }

    //    }
    //}
}