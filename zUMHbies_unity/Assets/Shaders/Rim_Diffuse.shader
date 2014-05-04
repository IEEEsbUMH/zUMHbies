Shader "Taronja/Rim/Diffuse" {
	Properties {
		_MainColor ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_RimColor ("Rim Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_RimPower ("Rim Power", Range(0.5, 5)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert exclude_path:prepass

		fixed4 _MainColor;
		sampler2D _MainTex;
		fixed4 _RimColor;
		half _RimPower;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
			float3 worldNormal;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb * _MainColor.rgb;
			o.Emission = pow((1.0 - saturate(dot(normalize(IN.viewDir), IN.worldNormal))), _RimPower) * _RimColor.rgb;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
