using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour {
   private int _itemsCollected = 0;

   [SerializeField] private AudioSource collectionSoundEffect;
   
   [SerializeField] private Text itemsCollectedUItext;
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("Coin"))
      {
         Destroy(col.gameObject);
         collectionSoundEffect.Play();
         _itemsCollected++;
         itemsCollectedUItext.text = "Coins: " + _itemsCollected + "/4";
      }
   }
}
