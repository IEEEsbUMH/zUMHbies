using UnityEngine;
using System.Collections;

public class InventoryLayout : MonoBehaviour
{
		public GameObject Player;
		public bool DisplayingInventory;

		public GUIStyle UnselectedStyle;
		public GUIStyle SelectedStyle;

		public Vector2 BoxDimensions;
		public int VerticalDistance;
		public int HorizontalDistance;

		private ItemManagement playerItemManagement;
		private int selectedIndex;
		
		// Use this for initialization
		void Start ()
		{
				playerItemManagement = Player.GetComponent<ItemManagement> ();
				selectedIndex = 0;
		}

		void OnGUI ()
		{
				//Returns if not displaying inventory
				if (!DisplayingInventory)
						return;

				if (selectedIndex > playerItemManagement.BagSize - 1)
						selectedIndex = 0;

				if (selectedIndex < 0)
						selectedIndex = playerItemManagement.BagSize - 1;
				

				//Bag Content
				for (int i=0; i<playerItemManagement.BagSize; i++) {
						GUIContent b_content;

						if (playerItemManagement.bagContent [i] != null) {
								b_content = new GUIContent (playerItemManagement.bagContent [i]._Name);
						} else
								b_content = GUIContent.none;

						GUI.Box (new Rect ((Screen.width - BoxDimensions.x) / 2, (Screen.height - BoxDimensions.y) / 2 - (selectedIndex - i) * VerticalDistance, BoxDimensions.x, BoxDimensions.y), b_content, UnselectedStyle);
				}

				//Hands Content
				for (int i=0; i<2; i++) {
						GUIContent b_content;
			
						if (playerItemManagement.handsContent [i] != null) {
								b_content = new GUIContent (playerItemManagement.handsContent [i]._Name);
						} else
								b_content = GUIContent.none;
			
						GUI.Box (new Rect ((Screen.width - BoxDimensions.x) / 2 - HorizontalDistance * (i == 0 ? 1 : -1) / 2, (Screen.height - BoxDimensions.y) / 2, BoxDimensions.x, BoxDimensions.y), b_content);
				}
		}

		//Update is called once per frame
		void Update ()
		{
				if (Input.GetButtonDown ("Inventory")) {
						DisplayingInventory = !DisplayingInventory;
				}
		
				if (DisplayingInventory) {
						if (Input.GetButtonDown ("InventoryUp")) {
								selectedIndex -= 1;
						}
						if (Input.GetButtonDown ("InventoryDown")) {
								selectedIndex += 1;
						}
				}
				//Equips items in hands
				if (Input.GetButtonDown ("InventoryLeft")) {
						playerItemManagement.PlaceInHand (selectedIndex, 0);
				}
		
				if (Input.GetButtonDown ("InventoryRight")) {
						playerItemManagement.PlaceInHand (selectedIndex, 1);
				}
		}

		public IPickable RetrieveSelectedPickable ()
		{
				return playerItemManagement.RetrievePickable (selectedIndex);
		}
}
