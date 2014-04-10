Shader "Custom/ViewDir" {
	Properties {
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

	
		struct Input {
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = IN.viewDir;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
