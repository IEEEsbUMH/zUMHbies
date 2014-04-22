﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Edelweiss.DecalSystem;

public class RealtimeBloodStains : MonoBehaviour
{
		public DS_Decals DS_Prefab;
		public GameObject[] StainPrefabs;

		[Range(0.01f, 0.1f)]
		public float
				DecalOffset; //Offset from the stain position for the decal

		[Range(0.01f, 180f)]
		public float
				DecalCullingAngle;

		public int MaxNumberOfProjectors;

		private DS_Decals ds;
		//private Matrix4x4 worldToDecalsMatrix;

		private List<DecalProjector> decalProjectors = new List<DecalProjector> ();

		private DecalsMesh dMesh;
		private DecalsMeshCutter dMeshCutter;

		private Vector3 projectorsScale = new Vector3 (0.2f, 0.2f, 0.2f);

		private int uvRectIndex = 0;

		void Start ()
		{
				ds = Instantiate (DS_Prefab) as DS_Decals;

				if (ds == null) {
						Debug.LogError ("The decals prefab does not contain a DS_Decals instance!");
				} else {
						dMesh = new DecalsMesh (ds);
						dMeshCutter = new DecalsMeshCutter ();
						//worldToDecalsMatrix = ds.CachedTransform.worldToLocalMatrix;
				}
		}

		public void CreateStain (GameObject a_projectOnGO, Vector3 a_stainPosition, Vector3 a_upPosition) //Both in world space
		{
				uvRectIndex = Random.Range (0, StainPrefabs.Length - 1);

				DecalProjector n_projector = new DecalProjector (a_stainPosition, Quaternion.identity, projectorsScale, DecalCullingAngle, 0f, uvRectIndex, uvRectIndex);
				decalProjectors.Add (n_projector);
				dMesh.AddProjector (n_projector);

				//Required matrices
				Matrix4x4 l_WorldToMeshMatrix = a_projectOnGO.transform.parent.worldToLocalMatrix;
				Matrix4x4 l_MeshToWorldMatrix = a_projectOnGO.transform.parent.localToWorldMatrix;

				dMesh.Add (a_projectOnGO.GetClosestComponentInHierarchy<MeshFilter> ().mesh, l_WorldToMeshMatrix, l_MeshToWorldMatrix);
				dMeshCutter.CutDecalsPlanes (dMesh);
				dMesh.OffsetActiveProjectorVertices ();

				ds.UpdateDecalsMeshes (dMesh);

				if (decalProjectors.Count > MaxNumberOfProjectors) {
						DecalProjector t_dProjector = decalProjectors [0];
						decalProjectors.RemoveAt (0);
						dMesh.RemoveProjector (t_dProjector);
				}
		}
}