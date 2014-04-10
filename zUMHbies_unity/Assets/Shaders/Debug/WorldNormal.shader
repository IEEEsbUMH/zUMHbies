Shader "Custom/WorldNormal" {
	Properties {
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

	
		struct Input {
			float3 worldNormal;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = IN.worldNormal;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
