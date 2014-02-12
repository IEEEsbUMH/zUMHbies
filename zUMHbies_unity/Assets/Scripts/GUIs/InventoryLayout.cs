using UnityEngine;
using System.Collections;

public class InventoryLayout : MonoBehaviour
{
		public Rect MainBoxRect;
		public Rect InventoryRect;
		public Rect InternalInventoryRect;
		public Rect HandsRect;
		public Vector2 ItemsButtonSize;

		public Rect ToLeftRect;
		public Rect ToRightRect;

		public GameObject Player;

		private ItemManagement playerItemManagment;
		private IPickable[] playerInventory;
		private IPickable[] playerHands;

		private int inventorySelectionIndex;
		private int handsSelectionIndex;
		
		// Use this for initialization
		void Start ()
		{
				playerItemManagment = Player.GetComponent<ItemManagement> ();

				inventorySelectionIndex = -1;
				handsSelectionIndex = -1;
		}
	
		// OnGUI is called once per frame
		void OnGUI ()
		{
				playerInventory = playerItemManagment.bagContent;
				playerHands = playerItemManagment.handsContent;
				
				GUIContent[] t_inventoryContent = new GUIContent[playerInventory.Length + 1];
				GUIContent[] t_handsContent = new GUIContent[2];

				GUIContent t_emptyContent = new GUIContent ("Vacío");

				for (int i=0; i<playerInventory.Length; i++) {
						if(playerInventory[i]!=null){
							GUIContent t_newContent = new GUIContent (playerInventory[i].Name, playerInventory[i].Picture);
							t_inventoryContent [i] = t_newContent;
						} else {
							t_inventoryContent [i] = t_emptyContent;
						}
				}
				t_inventoryContent [t_inventoryContent.Length - 1] = t_emptyContent;

				for (int i=0; i<2; i++) {
						if (playerHands [i] != null) {
								GUIContent t_newContent = new GUIContent (playerHands [i].Name, playerHands [i].Picture);
								t_handsContent [i] = t_newContent;
						} else {
								t_handsContent [i] = t_emptyContent;
						}
				}

				//GUI.BeginGroup (MainBoxRect, "Inventory");
				GUI.BeginScrollView (InventoryRect, new Vector2 (), InternalInventoryRect);
				inventorySelectionIndex = GUI.Toolbar (InternalInventoryRect, inventorySelectionIndex, t_inventoryContent);
				GUI.EndScrollView ();
				handsSelectionIndex = GUI.Toolbar (HandsRect, handsSelectionIndex, t_handsContent);
				//GUI.EndGroup ();
		}

		void CheckSwitch ()
		{
				if (inventorySelectionIndex != playerInventory.Length) {
						IPickable t_switch = playerInventory [inventorySelectionIndex];
						playerInventory [inventorySelectionIndex] = playerHands [handsSelectionIndex];
						playerHands [handsSelectionIndex] = t_switch;
				}
		}
}
