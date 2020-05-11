using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class inventory : MonoBehaviour
//{
//    public static inventory instance;
//    void Awake()
//    {
//        if (instance != null)
//        {
//            Debug.LogWarning("null item!");
//            return;
//        }
//        instance = this;
//    }
//    public delegate void OnItemChanged();
//    public OnItemChanged OnItemChangedCallback;
//    public int space = 20;
//    public List<Item> items = new List<Item>();


//    public void Add(Item item)
//    {
//        if (!item.isDefaultItem)
//        {
//            if (items.Count >= space)
//            {
//                Debug.Log("not Enough");

//            }
//            items.Add(item);
//        }

//    }

//    public void Removed(Item item)
//    {
//        items.Remove(item);
//    }



//}
