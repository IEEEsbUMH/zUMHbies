Shader "Taronja/LittleEmissive/Diffuse" {
	Properties {
		_MainColor ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_EmissionColor ("Emission Color", Color) = (1.0, 1.0, 1.0, 0.2)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		float4 _MainColor;
		sampler2D _MainTex;
		float4 _EmissionColor;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb * _MainColor.rgb;
			o.Emission = _EmissionColor.rgb * _EmissionColor.a * o.Albedo;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
